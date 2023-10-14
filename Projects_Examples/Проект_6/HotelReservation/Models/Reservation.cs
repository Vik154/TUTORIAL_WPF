namespace HotelReservation.Models;

/// <summary> Запись на бронирование </summary>
public class Reservation {

    /// <summary> Имя пользователя зарезервировавшего номер </summary>
    public string UserName { get; }

    /// <summary> Идентификатор номера отеля </summary>
    public RoomID RoomID { get; }

    /// <summary> Время начала бронирования </summary>
    public DateTime StartTime { get; }

    /// <summary> Время окончания брони </summary>
    public DateTime EndTime { get; }

    /// <summary> Продолжительность времени бронирования </summary>
    public TimeSpan Length => EndTime.Subtract(StartTime);

    /// <summary>
    /// Конструктор принимающий ID, Время начала и окончания срока бронирования номера
    /// </summary>
    /// <param name="roomID"></param>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    public Reservation(RoomID roomID, string userName, DateTime startTime, DateTime endTime) {
        RoomID = roomID;
        UserName = userName;
        StartTime = startTime;
        EndTime = endTime;
    }

    /// <summary> Проверка забронированного номера </summary>
    public bool Conflicts(Reservation reservation) {
        if (reservation.RoomID != RoomID)
            return false;
        return reservation.StartTime < EndTime && reservation.EndTime > StartTime;
    }
}
