namespace Trading.Domain.Services;

/// <summary> Интерфейс получения данных из БД </summary>
public interface IDataService<T> {

    /// <summary> Получить все данные </summary>
    Task<IEnumerable<T>> GetAll();

    /// <summary> Получить данные по идентификатору </summary>
    Task<T> Get(int id);

    /// <summary> Создать данные </summary>
    Task<T> Create(T entity);

    /// <summary> Обновить данные </summary>
    Task<T> Update(int id, T entity);

    /// <summary> Удалить данные </summary>
    Task<bool> Delete(int id);
}
