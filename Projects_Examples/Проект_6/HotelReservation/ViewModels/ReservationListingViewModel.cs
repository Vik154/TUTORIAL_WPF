using HotelReservation.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HotelReservation.ViewModels;

/// <summary> Модель - представление забронированных номеров отеля </summary>
public class ReservationListingViewModel : BaseViewModel {

    /// <summary> Коллекция забронированных номеров отеля </summary>
    private readonly ObservableCollection<ReservationViewModel> _reservations;

    /// <summary> Коллекция забронированных номеров отеля </summary>
    public IEnumerable<ReservationViewModel> Reservations => _reservations;

    /// <summary> Создать запись о резервирование номера </summary>
    public ICommand MakeReservationCommand { get; }

    public ReservationListingViewModel() {
        _reservations = new() {
            new ReservationViewModel(new Reservation(new RoomID(1, 2), "Tom", DateTime.Now, DateTime.Now)),
            new ReservationViewModel(new Reservation(new RoomID(3, 2), "Bob", DateTime.Now, DateTime.Now)),
            new ReservationViewModel(new Reservation(new RoomID(2, 4), "Sam", DateTime.Now, DateTime.Now))
        };
    }
}
