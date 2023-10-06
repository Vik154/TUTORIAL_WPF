using Bookinist.DAL.Entityes.Base;
using Bookinist.Interfaces;

namespace Bookinist.DAL;

class DbRepository<T> : IRepository<T> where T : Entity, new() {
    public IEnumerable<T> Items => throw new NotImplementedException();

    public T Add(T item) {
        throw new NotImplementedException();
    }

    public Task<T> AddAsync(T item, CancellationToken Cancel = default) {
        throw new NotImplementedException();
    }

    public T Get(int id) {
        throw new NotImplementedException();
    }

    public Task<T> GetAsync(int id, CancellationToken Cancel = default) {
        throw new NotImplementedException();
    }

    public void Remove(int id) {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int id, CancellationToken Cancel = default) {
        throw new NotImplementedException();
    }

    public void Update(T item) {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T item, CancellationToken Cancel = default) {
        throw new NotImplementedException();
    }
}
