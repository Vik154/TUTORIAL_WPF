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
}
