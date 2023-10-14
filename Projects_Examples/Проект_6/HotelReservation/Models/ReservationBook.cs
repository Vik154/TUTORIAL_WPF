using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Models;

/// <summary> Учетная книга бронирования номеров отеля </summary>
public class ReservationBook {

    /// <summary> Словарь забронированных номеров </summary>
    // private readonly Dictionary<RoomID, List<Reservation>> _roomsToReservations = new();

    /// <summary> Список забронированных номеров </summary>
    private readonly List<Reservation> _reservations = new();

    /// <summary> Возвращает коллекцию забронированных номеров пользователем по его имени </summary>
    public IEnumerable<Reservation> GetReservationsForUser(string userName) {
        return _reservations.Where(x => x.UserName == userName);
    }

    /// <summary> Добавление записи о бронировании номера </summary>
    public void AddReservation(Reservation reservation) {
        
        // Проверка уже забронированных номеров
        for
        
        _reservations.Add(reservation);
    }
}
