using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Models;

/// <summary> Идентификационный номер номера отеля </summary>
public class RoomID {

    /// <summary> Номер этажа </summary>
    public int FloorNumber { get; }

    /// <summary> Номер комнаты </summary>
    public int RoomNumber { get; }

    /// <summary>
    /// Принимает номер этажа и номер комнаты
    /// </summary>
    /// <param name="floorNumber"></param>
    /// <param name="roomNumber"></param>
    public RoomID(int floorNumber, int roomNumber) {
        FloorNumber = floorNumber;
        RoomNumber = roomNumber;
    }

    /// <summary>
    /// Логика сравнения ключей для словаря забронированных номеров
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) {
        return obj is RoomID roomID && 
               FloorNumber == roomID.FloorNumber && 
               RoomNumber == roomID.RoomNumber;
    }

    /// <summary>
    /// Логика Хэш-кода для вставки (поиска/сортировки) объектов в словаре
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() {
        return HashCode.Combine(FloorNumber, RoomNumber);
    }

    /// <summary>
    /// Возвращает номер этажа и номер комнаты
    /// </summary>
    /// <returns></returns>
    public override string ToString() {
        return $"{FloorNumber}{RoomNumber}";
    }
}
