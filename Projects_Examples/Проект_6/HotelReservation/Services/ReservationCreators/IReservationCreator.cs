using HotelReservation.Models;

namespace HotelReservation.Services.ReservationCreators;

public interface IReservationCreator {
    Task CreateReservation(Reservation reservation);
}
