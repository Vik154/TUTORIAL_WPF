using HotelReservation.Exceptions;
using HotelReservation.Services.ReservationConflictValidators;
using HotelReservation.Services.ReservationCreators;
using HotelReservation.Services.ReservationProviders;

namespace HotelReservation.Models;

/// <summary> Учетная книга бронирования номеров отеля </summary>
public class ReservationBook {

    // Сервисы данных
    private readonly IReservationProvider _reservationProvider;
    private readonly IReservationCreator _reservationCreator;
    private readonly IReservationConflictValidator _reservationConflictValidator;

    /// <summary> Конструктор принимающий поставщика и создателя данных, и валидатор повторяющихся записей </summary>
    /// <param name="reservationProvider"></param>
    /// <param name="reservationCreator"></param>
    /// <param name="reservationConflictValidator"></param>
    public ReservationBook(IReservationProvider reservationProvider, 
                           IReservationCreator reservationCreator, 
                           IReservationConflictValidator reservationConflictValidator) 
    {
        _reservationProvider = reservationProvider;
        _reservationCreator = reservationCreator;
        _reservationConflictValidator = reservationConflictValidator;
    }

    /// <summary> Возвращает коллекцию забронированных номеров пользователем по его имени </summary>
    public async Task<IEnumerable<Reservation>> GetAllReservations() {
        return await _reservationProvider.GetAllReservations();
    }

    /// <summary> Добавление записи о бронировании номера </summary>
    public async Task AddReservation(Reservation reservation) {

        Reservation conflictRreservation = await _reservationConflictValidator.GetConflictingReservation(reservation);

        if (conflictRreservation != null) {
            throw new ReservationConflictException(conflictRreservation, reservation);
        }
        await _reservationCreator.CreateReservation(reservation);
    }

    /*-------------------------------------------------------------------------------------*/

    /// <summary> Словарь забронированных номеров </summary>
    // private readonly Dictionary<RoomID, List<Reservation>> _roomsToReservations = new();

    /// <summary> Список забронированных номеров </summary>
    // private readonly List<Reservation> _reservations = new();

    /// <summary> Возвращает коллекцию забронированных номеров пользователем по его имени </summary>
    //public IEnumerable<Reservation> GetAllReservations() {
    //    return _reservations;
    //}

    /// <summary> Добавление записи о бронировании номера </summary>
    //public void AddReservation(Reservation reservation) {

    //    // Проверка уже забронированных номеров
    //    foreach (Reservation existingReservation in _reservations) {
    //        if (existingReservation.Conflicts(reservation))
    //            throw new ReservationConflictException(existingReservation, reservation);
    //    }

    //    _reservations.Add(reservation);
    //}
}
