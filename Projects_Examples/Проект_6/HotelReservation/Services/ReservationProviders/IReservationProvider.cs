using HotelReservation.Models;

namespace HotelReservation.Services.ReservationProviders;

/// <summary> Интерфейс поставщика данных </summary>
public interface IReservationProvider {
    Task<IEnumerable<Reservation>> GetAllReservations();
}
