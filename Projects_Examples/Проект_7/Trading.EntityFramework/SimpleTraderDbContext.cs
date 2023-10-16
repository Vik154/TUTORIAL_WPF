using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System;
using Trading.Domain.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Trading.EntityFramework;

/// <summary> Класс представляющий трейдера </summary>
public class SimpleTraderDbContext : DbContext {

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TradingDB;Trusted_Connection=True;");
        base.OnConfiguring(optionsBuilder);
    }
}
