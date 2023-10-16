using Microsoft.EntityFrameworkCore;
using Trading.Domain.Models;

namespace Trading.EntityFramework;

/// <summary> Класс представляющий трейдера </summary>
public class SimpleTraderDbContext : DbContext {

    public SimpleTraderDbContext(DbContextOptions options) : base(options) { }

    /// <summary> Таблица пользователей </summary>
    public DbSet<User> Users { get; set; }

    /// <summary> Таблица аккаунтов </summary>
    public DbSet<Account> Accounts { get; set; }

    /// <summary> Таблица сделок с активами </summary>
    public DbSet<AssetTransaction> AssetTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Stock);
        base.OnModelCreating(modelBuilder);
    }

}
