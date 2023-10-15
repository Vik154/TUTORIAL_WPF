using HotelReservation.Models;

namespace HotelReservation.Services.ReservationConflictValidators;

/// <summary> Интерфейс для проверки конфликтов при регистрации номеров </summary>
public interface IReservationConflictValidator {
    Task<Reservation> GetConflictingReservation(Reservation reservation);
}
