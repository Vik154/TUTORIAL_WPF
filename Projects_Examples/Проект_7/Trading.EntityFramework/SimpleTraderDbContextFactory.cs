using Microsoft.EntityFrameworkCore;

namespace Trading.EntityFramework;

public class SimpleTraderDbContextFactory {

    private readonly Action<DbContextOptionsBuilder> _configureDbContext;

    public SimpleTraderDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext) {
        _configureDbContext = configureDbContext;
    }

    public SimpleTraderDbContext CreateDbContext() {
        DbContextOptionsBuilder<SimpleTraderDbContext> options = new DbContextOptionsBuilder<SimpleTraderDbContext>();

        _configureDbContext(options);

        return new SimpleTraderDbContext(options.Options);
    }
}

/// <summary> При запуске миграций EF запускает наследников IDesignTime... </summary>
//public class SimpleTraderDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderDbContext> {
//    public SimpleTraderDbContext CreateDbContext(string[]? args = null) {
//        var optioms = new DbContextOptionsBuilder<SimpleTraderDbContext>();
//        optioms.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TradingDB;Trusted_Connection=True;");
//        return new SimpleTraderDbContext(optioms.Options);
//    }
//}
