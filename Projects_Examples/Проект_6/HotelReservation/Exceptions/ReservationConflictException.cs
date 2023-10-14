using HotelReservation.Models;

namespace HotelReservation.Exceptions;

/// <summary> Класс исключений бронирования номеров </summary>
public class ReservationConflictException : Exception {

    /// <summary> Существующее бронирование </summary>
    public Reservation ExistingReservation { get; }

    /// <summary> Поступающее бронирование </summary>
    public Reservation IncomingReservation { get; }

    public ReservationConflictException(Reservation existingReservation, Reservation incomingReservation) {
        ExistingReservation = existingReservation;
        IncomingReservation = incomingReservation;
    }

    public ReservationConflictException(string? message, Reservation existingReservation, Reservation incomingReservation) : base(message) {
        ExistingReservation = existingReservation;
        IncomingReservation = incomingReservation;
    }

    public ReservationConflictException(string? message, Exception? innerException, Reservation existingReservation, Reservation incomingReservation) : base(message, innerException) {
        ExistingReservation = existingReservation;
        IncomingReservation = incomingReservation;
    }
}
