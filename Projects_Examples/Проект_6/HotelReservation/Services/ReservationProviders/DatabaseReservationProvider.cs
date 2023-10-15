using HotelReservation.Models;

namespace HotelReservation.Services.ReservationProviders;

public class DatabaseReservationProvider : IReservationProvider {
    public Task<IEnumerable<Reservation>> GetAllReservations() {
        throw new NotImplementedException();
    }
}
