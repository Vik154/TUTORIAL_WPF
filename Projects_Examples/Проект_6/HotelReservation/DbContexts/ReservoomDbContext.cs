using HotelReservation.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.DbContexts;

/// <summary> Контекст базы данных </summary>
public class ReservoomDbContext : DbContext {
    public DbSet<ReservationDTO> Reservations { get; set; }

    public ReservoomDbContext(DbContextOptions options) : base(options) { }
}
