using HotelReservation.DbContexts;
using HotelReservation.DTOs;
using HotelReservation.Models;

namespace HotelReservation.Services.ReservationCreators;

public class DatabaseReservationCreator : IReservationCreator {

    private readonly ReservoomDbContextFactory _dbContextFactory;

    public DatabaseReservationCreator(ReservoomDbContextFactory dbContextFactory) {
        _dbContextFactory = dbContextFactory;
    }

    public async Task CreateReservation(Reservation reservation) {
        using (ReservoomDbContext context = _dbContextFactory.CreateDbContext()) {
            ReservationDTO reservationDTO = ToReservationDTO(reservation);

            context.Reservations.Add(reservationDTO);
            await context.SaveChangesAsync();
        }
    }

    private ReservationDTO ToReservationDTO(Reservation reservation) {
        return new ReservationDTO() {
            FloorNumber = reservation.RoomID?.FloorNumber ?? 0,
            RoomNumber = reservation.RoomID?.RoomNumber ?? 0,
            Username = reservation.UserName,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime,
        };
    }
}
