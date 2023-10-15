using HotelReservation.Models;

namespace HotelReservation.ViewModels;

/// <summary> Модель - представление зарезервированных номеров </summary>
public class ReservationViewModel : BaseViewModel {
    
    /// <summary> Зарезервированные номера </summary>
    private readonly Reservation _reservation;

    /// <summary> Возвращает номер комнаты </summary>
    public string? RoomID => _reservation.RoomID?.ToString();

    /// <summary> Возвращает имя пользователя </summary>
    public string Username => _reservation.UserName;

    /// <summary> Возвращает время начала брони </summary>
    public string StartDate => _reservation.StartTime.ToString("d");

    /// <summary> Возвращает окончания начала брони </summary>
    public string EndDate => _reservation.EndTime.ToString("d");

    public ReservationViewModel(Reservation reservation) {
        _reservation = reservation;
    }
}
