using HotelReservation.Commands;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HotelReservation.ViewModels;

/// <summary> Модель - представление забронированных номеров отеля </summary>
public class ReservationListingViewModel : BaseViewModel {

    /// <summary> Коллекция забронированных номеров отеля </summary>
    private readonly ObservableCollection<ReservationViewModel> _reservations;

    /// <summary> Коллекция забронированных номеров отеля </summary>
    public IEnumerable<ReservationViewModel> Reservations => _reservations;

    /// <summary> Команда загрузки записей брони </summary>
    public ICommand LoadReservationCommand { get; }

    /// <summary> Создать запись о резервирование номера </summary>
    public ICommand MakeReservationCommand { get; }

    public ReservationListingViewModel(HotelStore hotelStore, NavigationService makeReservationNavigationService) {
        _reservations = new();
        MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);
        LoadReservationCommand = new LoadReservationsCommand(this, hotelStore);
        // UpdateReservations();
    }

    public static ReservationListingViewModel LoadViewModel(HotelStore hotelStore, NavigationService makeReservationNavigationService) {
        ReservationListingViewModel viewModel = new ReservationListingViewModel(hotelStore, makeReservationNavigationService);

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
