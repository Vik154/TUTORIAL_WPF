using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Stores;

/// <summary> Класс хранения данных после их выгрузки из БД </summary>
public class HotelStore {

    /// <summary> Список записей о бронирование из БД </summary>
    private readonly List<Reservation> _reservations;
    private Lazy<Task> _initializeLazy;
    private readonly Hotel _hotel;

    /// <summary> Получение списка забронированных номеров </summary>
    public IEnumerable<Reservation> Reservations => _reservations;

    public event Action<Reservation>? ReservationMade;

    public HotelStore(Hotel hotel) {
        _hotel = hotel;
        _initializeLazy = new Lazy<Task>(Initialize);
        _reservations = new List<Reservation>();
    }

    /// <summary> Ленивая Асинхронная загрузка данных из БД не блокируя UI </summary>
    /// <returns> Список забронированных номеров </returns>
    public async Task Load() {
        try {
            await _initializeLazy.Value;
        }
        catch (Exception) {
            _initializeLazy = new Lazy<Task>(Initialize);
            throw;
        }
    }

    /// <summary>
    /// Добавляет запись о бронировании номера как в БД, так и локально в память
    /// </summary>
    /// <param name="reservation">Список забронированных номеров</param>
    public async Task MakeReservation(Reservation reservation) {
        await _hotel.MakeReservation(reservation);

        _reservations.Add(reservation);

        OnReservationMade(reservation);
    }

    private void OnReservationMade(Reservation reservation) {
        ReservationMade?.Invoke(reservation);
    }

    /// <summary> Инициализация списка забронированных номеров </summary>
    private async Task Initialize() {
        IEnumerable<Reservation> reservations = await _hotel.GetAllReservations();

        _reservations.Clear();
        _reservations.AddRange(reservations);
    }
}
