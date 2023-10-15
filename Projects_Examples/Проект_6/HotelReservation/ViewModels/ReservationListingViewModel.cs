using HotelReservation.Commands;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HotelReservation.ViewModels;

/// <summary> Модель - представление забронированных номеров отеля </summary>
public class ReservationListingViewModel : BaseViewModel {

    /// <summary> Хранитель в памяти объектов из БД </summary>
    private readonly HotelStore _hotelStore;

    /// <summary> Коллекция забронированных номеров отеля </summary>
    private readonly ObservableCollection<ReservationViewModel> _reservations;

    /// <summary> Коллекция забронированных номеров отеля </summary>
    public IEnumerable<ReservationViewModel> Reservations => _reservations;

    /// <summary> Сообщение об ошибке </summary>
    private string _errorMessage;

    /// <summary> Сообщение об ошибке </summary>
    public string ErrorMessage {
        get => _errorMessage;
        set {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
            OnPropertyChanged(nameof(HasErrorMessage));
        }
    }

    /// <summary> Проверка на наличие ошибки </summary>
    public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

    /// <summary> Флаг для ожидания загрузки данных </summary>
    private bool _isLoading;

    /// <summary> Флаг для ожидания загрузки данных </summary>
    public bool IsLoading {
        get => _isLoading;
        set { _isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
    }

    /// <summary> Свойство для примера концепции реактивности </summary>
    public MakeReservationViewModel MakeReservationViewModel { get; }

    /// <summary> Команда загрузки записей брони </summary>
    public ICommand LoadReservationCommand { get; }

    /// <summary> Создать запись о резервирование номера </summary>
    public ICommand MakeReservationCommand { get; }

    public ReservationListingViewModel(HotelStore hotelStore,
                                       MakeReservationViewModel makeReservationViewModel,
                                       NavigationService makeReservationNavigationService)
    {
        _hotelStore = hotelStore;
        _reservations = new();
        MakeReservationViewModel = makeReservationViewModel;

        MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);
        LoadReservationCommand = new LoadReservationsCommand(this, hotelStore);
        // UpdateReservations();
        _hotelStore.ReservationMade += OnReservationMade;
    }

    /// <summary> Освобождение ресурсов </summary>
    public override void Dispose() {
        _hotelStore.ReservationMade -= OnReservationMade;
        base.Dispose();
    }

    private void OnReservationMade(Reservation reservation) {
        ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
        _reservations.Add(reservationViewModel);
    }

    public static ReservationListingViewModel LoadViewModel(HotelStore hotelStore,
                                                            MakeReservationViewModel makeReservationViewModel,
                                                            NavigationService makeReservationNavigationService) 
    {
        ReservationListingViewModel viewModel = 
            new ReservationListingViewModel(hotelStore, makeReservationViewModel, makeReservationNavigationService);

        viewModel.LoadReservationCommand.Execute(null);
        return viewModel;
    }

    public void UpdateReservations(IEnumerable<Reservation> reservations) {
        _reservations.Clear();

        foreach (Reservation reservation in reservations) {
            ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
            _reservations.Add(reservationViewModel);
        }
    }
}
