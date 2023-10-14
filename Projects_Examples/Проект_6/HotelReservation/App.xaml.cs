using HotelReservation.Exceptions;
using HotelReservation.Models;
using System.Windows;

namespace HotelReservation;


public partial class App : Application {

    protected override void OnStartup(StartupEventArgs e) {
        Hotel hotel = new Hotel("SingletonSean Suites");

        try {
            hotel.MakeReservation(new Reservation(
                new RoomID(1, 2),
                "SingletonSean",
                new DateTime(2000, 1, 1),
                new DateTime(2000, 1, 2)));

            hotel.MakeReservation(new Reservation(
                new RoomID(1, 2),
                "SingletonSean",
                new DateTime(2000, 1, 3),
                new DateTime(2000, 1, 4)));
        }
        catch (ReservationConflictException ex) { }

        IEnumerable<Reservation> reservations = hotel.GetReservationsForUser("SingletonSean");

        base.OnStartup(e);
    }
}
