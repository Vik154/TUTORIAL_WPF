using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Trading.Domain.Models;
using Trading.Domain.Services;

namespace Trading.EntityFramework.Services;

/// <summary> 
/// Универсальный сервис передачи данных (обработка всех операций от доменной модели) 
/// чтобы не создавать сервис для каждой модели отдельно
/// </summary>
public class GenericDataService<T> : IDataService<T> where T : DomainObject {

    /// <summary>Контекст данных</summary>
    private readonly SimpleTraderDbContextFactory _contextFactory;

    public GenericDataService(SimpleTraderDbContextFactory contextFactory) {
        _contextFactory = contextFactory;
    }

    public async Task<T> Create(T entity) {
        using (SimpleTraderDbContext db = _contextFactory.CreateDbContext()) {
            
            EntityEntry<T> createdEntity = await db.Set<T>().AddAsync(entity);
            await db.SaveChangesAsync();

            return createdEntity.Entity;
        }
    }

    public async Task<bool> Delete(int id) {
        using (SimpleTraderDbContext db = _contextFactory.CreateDbContext()) {
            
            T? findEntity = await db.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            
            if (findEntity != null)
                db.Set<T>().Remove(findEntity);
            
            await db.SaveChangesAsync();

            return true;
        }
    }

    public async Task<T> Get(int id) {
        using (SimpleTraderDbContext db = _contextFactory.CreateDbContext()) {
            T findEntity = await db.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            return findEntity;
        }
    }

    public async Task<IEnumerable<T>> GetAll() {
        using (SimpleTraderDbContext db = _contextFactory.CreateDbContext()) {
            IEnumerable<T> entities = await db.Set<T>().ToListAsync();
            return entities;
        }
    }

    public async Task<T> Update(int id, T entity) {
        using (SimpleTraderDbContext db = _contextFactory.CreateDbContext()) {

            entity.Id = id;
            db.Set<T>().Update(entity);
            await db.SaveChangesAsync();

            return entity;
        }
    }
}
