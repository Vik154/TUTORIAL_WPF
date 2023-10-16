using HotelReservation.Commands;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.Stores;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

    /// <summary> Проверка на наличие записей в книге бронирования номеров </summary>
    public bool HasReservations => _reservations.Any();

    /// <summary> Сообщение об ошибке </summary>
    private string _errorMessage = "";

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

    public ReservationListingViewModel(HotelStore hotelStore, NavigationService<MakeReservationViewModel> makeReservationNavigationService)
    {
        _hotelStore = hotelStore;
        _reservations = new();

        MakeReservationCommand = new NavigateCommand<MakeReservationViewModel>(makeReservationNavigationService);
        LoadReservationCommand = new LoadReservationsCommand(this, hotelStore);
        
        // UpdateReservations();
        
        _hotelStore.ReservationMade += OnReservationMade;
        _reservations.CollectionChanged += OnReservationsChanged;
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

    private void OnReservationsChanged(object? sender, NotifyCollectionChangedEventArgs e) {
        OnPropertyChanged(nameof(HasReservations));
    }

    public static ReservationListingViewModel LoadViewModel(HotelStore hotelStore, NavigationService<MakeReservationViewModel> makeReservationNavigationService) {

        ReservationListingViewModel viewModel = 
            new ReservationListingViewModel(hotelStore, makeReservationNavigationService);

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
