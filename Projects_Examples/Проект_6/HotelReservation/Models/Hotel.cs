using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Models;

/// <summary> Класс представляющий - Отель </summary>
public class Hotel {

    /// <summary> Книга бронирования номеров отеля </summary>
    private readonly ReservationBook _reservationBook = new();

    /// <summary> Имя отеля </summary>
    public string Name { get; }

    public Hotel(string name) {
        Name = name;
    }

    /// <summary> Возвращает коллекцию забронированных номеров пользователем по его имени </summary>
    public IEnumerable<Reservation> GetAllReservations() {
        return _reservationBook.GetAllReservations();
    }

    /// <summary> Добавление записи о брони в книгу бронирования </summary>
    public void MakeReservation(Reservation reservation) {
        _reservationBook.AddReservation(reservation);
    }
}
