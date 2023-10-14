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
    /// <returns>Номер этажа и номер комнаты</returns>
    public override string ToString() {
        return $"{FloorNumber}{RoomNumber}";
    }

    /// <summary>
    /// Проверка на null, т.к. Equals возвращает false если оба null
    /// </summary>
    /// <param name="roomID1"></param>
    /// <param name="roomID2"></param>
    /// <returns></returns>
    public static bool operator ==(RoomID roomID1, RoomID roomID2) {
        if (roomID1 is null && roomID2 is null) {
            return true;
        }
        return !(roomID1 is null) && roomID1.Equals(roomID2);
    }

    public static bool operator !=(RoomID roomID1, RoomID roomID2) {
        return !(roomID1 == roomID2);
    }
}
