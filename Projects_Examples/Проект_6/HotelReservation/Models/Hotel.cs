namespace HotelReservation.Models;

/// <summary> Класс представляющий - Отель </summary>
public class Hotel {

    /// <summary> Книга бронирования номеров отеля </summary>
    private readonly ReservationBook _reservationBook;

    /// <summary> Имя отеля </summary>
    public string Name { get; }

    public Hotel(string name, ReservationBook reservationBook) {
        Name = name;
        _reservationBook = reservationBook;
    }

    /// <summary> Возвращает коллекцию забронированных номеров пользователем по его имени </summary>
    public async Task<IEnumerable<Reservation>> GetAllReservations() {
        return await _reservationBook.GetAllReservations();
    }

    /// <summary> Добавление записи о брони в книгу бронирования </summary>
    public async Task MakeReservation(Reservation reservation) {
        await _reservationBook.AddReservation(reservation);
    }

    /* ------------------------------------------------------------------------------------------- */

    /// <summary> Возвращает коллекцию забронированных номеров пользователем по его имени </summary>
    //public IEnumerable<Reservation> GetAllReservations() {
    //    return _reservationBook.GetAllReservations();
    //}

    /// <summary> Добавление записи о брони в книгу бронирования </summary>
    //public void MakeReservation(Reservation reservation) {
    //    _reservationBook.AddReservation(reservation);
    //}
}
