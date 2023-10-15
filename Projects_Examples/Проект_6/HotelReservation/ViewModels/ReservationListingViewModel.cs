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
    private readonly Hotel _hotel;

    /// <summary> Коллекция забронированных номеров отеля </summary>
    public IEnumerable<ReservationViewModel> Reservations => _reservations;

    /// <summary> Создать запись о резервирование номера </summary>
    public ICommand MakeReservationCommand { get; }

    public ReservationListingViewModel(Hotel hotel, NavigationService makeReservationNavigationService) {
        _reservations = new();
        _hotel = hotel;
        MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);
        UpdateReservations();
    }

    private void UpdateReservations() {
        _reservations.Clear();

        foreach (Reservation reservation in _hotel.GetAllReservations()) {
            ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
            _reservations.Add(reservationViewModel);
        }
    }
}
