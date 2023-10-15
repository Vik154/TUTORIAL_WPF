using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelReservation.DbContexts;

/// <summary> Класс используемый для миграций </summary>
public class ReservoomDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReservoomDbContext> {
    public ReservoomDbContext CreateDbContext(string[] args) {
        DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=reservoom.db").Options;

        return new ReservoomDbContext(options);
    }
}
