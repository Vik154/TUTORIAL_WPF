using Microsoft.EntityFrameworkCore;

namespace HotelReservation.DbContexts;

/// <summary> Фабрика контекста данных, против жестко закодированных строк подключения </summary>
public class ReservoomDbContextFactory {
    
    private readonly string _connectionString;

    public ReservoomDbContextFactory(string connectionString) => _connectionString = connectionString;

    public ReservoomDbContext CreateDbContext() {
        DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

        return new ReservoomDbContext(options);
    }
}
