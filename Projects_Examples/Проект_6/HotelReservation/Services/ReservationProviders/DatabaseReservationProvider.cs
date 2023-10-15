using HotelReservation.DbContexts;
using HotelReservation.DTOs;
using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Services.ReservationProviders;

public class DatabaseReservationProvider : IReservationProvider {

    private readonly ReservoomDbContextFactory _dbContextFactory;

    public DatabaseReservationProvider(ReservoomDbContextFactory dbContextFactory) {
        _dbContextFactory = dbContextFactory;
    }
    public async Task<IEnumerable<Reservation>> GetAllReservations() {
        using (ReservoomDbContext context = _dbContextFactory.CreateDbContext()) {
            IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();

            return reservationDTOs.Select(r => ToReservation(r));
        }
    }
    private static Reservation ToReservation(ReservationDTO dto) {
        return new Reservation(new RoomID(dto.FloorNumber, dto.RoomNumber), dto.Username, dto.StartTime, dto.EndTime);
    }
}
