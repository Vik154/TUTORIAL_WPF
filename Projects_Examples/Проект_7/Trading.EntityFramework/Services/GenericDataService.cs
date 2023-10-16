using Microsoft.EntityFrameworkCore;
using Trading.Domain.Services;

namespace Trading.EntityFramework.Services;

/// <summary> 
/// Универсальный сервис передачи данных (обработка всех операций от доменной модели) 
/// чтобы не создавать сервис для каждой модели отдельно
/// </summary>
public class GenericDataService<T> : IDataService<T> where T : class {

    /// <summary>Контекст данных</summary>
    private readonly SimpleTraderDbContextFactory _contextFactory;

    public GenericDataService(SimpleTraderDbContextFactory contextFactory) {
        _contextFactory = contextFactory;
    }

    public async Task<T> Create(T entity) {
        using (SimpleTraderDbContext db = _contextFactory.CreateDbContext()) {
            var createdEntity = await db.Set<T>().AddAsync(entity);
            await db.SaveChangesAsync();

            return createdEntity.Entity;
        }
    }

    public Task<bool> Delete(int id) {
        using (SimpleTraderDbContext db = _contextFactory.CreateDbContext()) {
            T findEntity = await db.Set<T>().FirstOrDefaultAsync((e) => e.)
            await db.SaveChangesAsync();

            return createdEntity.Entity;
        }
    }

    public Task<T> Get(int id) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAll() {
        throw new NotImplementedException();
    }

    public Task<T> Update(int id, T entity) {
        throw new NotImplementedException();
    }
}
