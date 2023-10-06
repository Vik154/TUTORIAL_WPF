﻿namespace Bookinist.Interfaces;

// Шаблонный интерфейс, который имеет ограничение на шаблон,
// он должен быть классом, иметь базовый конструктор и наследовать IEntity
public interface IRepository<T> where T : class, IEntity, new() {
    IEnumerable<T> Items {  get; }
    
    T Get(int id);
    Task<T> GetAsync(int id, CancellationToken Cancel = default);

    T Add(T item);
    Task<T> AddAsync(T item, CancellationToken Cancel = default);
    
    void Update(T item);
    Task UpdateAsync(T item, CancellationToken Cancel = default);
    
    void Remove(int id);
    Task RemoveAsync(int id, CancellationToken Cancel = default);
}
