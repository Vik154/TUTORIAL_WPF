using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Trading.EntityFramework;

/// <summary> При запуске миграций EF запускает наследников IDesignTime... </summary>
public class DesignTimeDbContextOptionsFactory : IDesignTimeDbContextFactory<SimpleTraderDbContext> {
    public SimpleTraderDbContext CreateDbContext(string[] args) {
        var optioms = new DbContextOptionsBuilder<SimpleTraderDbContext>();
        optioms.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TradingDB;Trusted_Connection=True;");
        return new SimpleTraderDbContext(optioms.Options);
    }
}
