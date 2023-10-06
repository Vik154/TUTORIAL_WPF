using Bookinist.DAL.Context;
using Bookinist.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Bookinist.Data;


class DbInitializer {
    private readonly BookinistDB _db;
    private readonly ILogger<DbInitializer> _Logger;

    public DbInitializer(BookinistDB dB, ILogger<DbInitializer> logger) {
        _db = dB;
        _Logger = logger;
    }

    public async Task InitializeAsync() {

        // Таймер + логгер
        var timer = Stopwatch.StartNew();
        _Logger.LogInformation("Инициализация БД....");

        _Logger.LogInformation("Удаление существующей БД....");

        // В начале для отладки - удалять БД каждый раз
        // _db.Database.EnsureDeleted();
        await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
        // _db.Database.EnsureCreated();
        _Logger.LogInformation($"Удаление существующей БД выполнено за " +
            $"{timer.ElapsedMilliseconds} мс");

        // Позволяет создать БД и накатить все миграции существующие на текущий момент
        // _db.Database.Migrate();
        _Logger.LogInformation("Миграция БД....");
        await _db.Database.MigrateAsync();
        _Logger.LogInformation($"Миграция БД выполнена за {timer.ElapsedMilliseconds} мс");

        // Если есть хоть одна книга в БД, значит БД уже проинициализирована
        // и ниче делать не надо, просто выйти из инициализатора
        if (await _db.Books.AnyAsync()) return;

        // Важен порядок --->
        await InitializeCategories();
        await InitializeBooks();
        await InitializeSellers();
        await InitializeBuyers();
        await InitializeDeals();

        _Logger.LogInformation($"Инициализация БД выполнена за {timer.Elapsed.TotalSeconds} мс");
    }

    #region Категории
    private const int __CategoriesCount = 10;
    private Category[] _Categories;

    private async Task InitializeCategories() {

        var timer = Stopwatch.StartNew();
        _Logger.LogInformation("Инициализация Категорий");

        _Categories = new Category[__CategoriesCount];
        for (var i = 0; i < __CategoriesCount; i++)
            _Categories[i] = new Category {
                Name = $"Категория {i}"
            };
        await _db.Categories.AddRangeAsync(_Categories);
        await _db.SaveChangesAsync();

        _Logger.LogInformation($"Инициализация категорий выполнена за " +
            $"{timer.ElapsedMilliseconds} мс");
    }
    #endregion

    #region Книги
    private const int __BooksCount = 10;
    private Book[] _Books;

    private async Task InitializeBooks() {

        var timer = Stopwatch.StartNew();
        _Logger.LogInformation("Инициализация Книг");

        var rnd = new Random();

        _Books = Enumerable.Range(1, __BooksCount)
            .Select(i => new Book {
                Name = $"Книга {i}",
                Category = rnd.NextItemExtension(items: _Categories)
            })
            .ToArray();

        await _db.Books.AddRangeAsync(_Books);
        await _db.SaveChangesAsync();

        _Logger.LogInformation($"Инициализация книг выполнена за " +
            $"{timer.ElapsedMilliseconds} мс");
    }
    #endregion

    #region Продавцы
    private const int __SellersCount = 10;
    private Seller[] _Sellers;

    private async Task InitializeSellers() {

        var timer = Stopwatch.StartNew();
        _Logger.LogInformation("Инициализация Продавцов");

        _Sellers = Enumerable.Range(1, __SellersCount)
            .Select(i => new Seller {
                Name = $"Продавец Имя: {i}",
                Surname = $"Продавец Фамилия: {i}",
                Patronymic = $"Продавец Отчество: {i}"
            })
            .ToArray();

        await _db.Sellers.AddRangeAsync(_Sellers);
        await _db.SaveChangesAsync();

        _Logger.LogInformation($"Инициализация продавцов выполнена за " +
            $"{timer.ElapsedMilliseconds} мс");
    }
    #endregion

    #region Покупатели
    private const int __BuyersCount = 10;
    private Buyer[] _Buyers;

    private async Task InitializeBuyers() {

        var timer = Stopwatch.StartNew();
        _Logger.LogInformation("Инициализация Покупателей");

        _Buyers = Enumerable.Range(1, __BuyersCount)
            .Select(i => new Buyer {
                Name = $"Покупатель Имя: {i}",
                Surname = $"Покупатель Фамилия: {i}",
                Patronymic = $"Покупатель Отчество: {i}"
            })
            .ToArray();

        await _db.Buyers.AddRangeAsync(_Buyers);
        await _db.SaveChangesAsync();

        _Logger.LogInformation($"Инициализация покупателей выполнена за " +
            $"{timer.ElapsedMilliseconds} мс");
    }
    #endregion

    #region Сделки
    private const int __DealsCount = 1000;
    
    private async Task InitializeDeals() {

        var timer = Stopwatch.StartNew();
        _Logger.LogInformation("Инициализация Сделок");

        var rnd = new Random();

        var deals = Enumerable.Range(0, __DealsCount)
            .Select(i => new Deal {
                Book = rnd.NextItemExtension(_Books),
                Seller = rnd.NextItemExtension(_Sellers),
                Buyer = rnd.NextItemExtension(_Buyers),
                Price = (decimal) (rnd.NextDouble() * 4000 + 700)
            });

        await _db.Deals.AddRangeAsync(deals);
        await _db.SaveChangesAsync();

        _Logger.LogInformation($"Инициализация сделок выполнена за " +
            $"{timer.ElapsedMilliseconds} мс");
    }
    #endregion
}
