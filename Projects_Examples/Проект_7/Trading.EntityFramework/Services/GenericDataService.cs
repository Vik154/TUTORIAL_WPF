using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Domain.Services;

namespace Trading.EntityFramework.Services;

/// <summary> 
/// Универсальный сервис передачи данных (обработка всех операций от доменной модели) 
/// чтобы не создавать сервис для каждой модели отдельно
/// </summary>
public class GenericDataService<T> : IDataService<T> {

    /// <summary>Контекст данных</summary>
    private readonly SimpleTraderDbContext _context;

    public Task<T> Create(T entity) {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id) {
        throw new NotImplementedException();
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
