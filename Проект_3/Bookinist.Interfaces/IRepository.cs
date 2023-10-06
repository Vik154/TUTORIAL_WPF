using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.Interfaces;

// Шаблонный интерфейс, который имеет ограничение на шаблон,
// он должен быть классом, иметь базовый конструктор и наследовать IEntity
public interface IRepository<T> where T : class, IEntity, new() {
    IEnumerable<T> Items {  get; }
    T Get(int id);
    T Add(T item);
    void Update(T item);
    void Remove(int id);
}
