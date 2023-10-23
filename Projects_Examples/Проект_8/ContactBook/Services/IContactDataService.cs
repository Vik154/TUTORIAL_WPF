using ContactBook.Models;

namespace ContactBook.Services;

/// <summary> Манипуляции с контактами </summary>
public interface IContactDataService {

    /// <summary> Получить список контактов </summary>
    IEnumerable<Contact> GetContacts();

    /// <summary> Сохранить список контактов </summary>
    void Save(IEnumerable<Contact> contacts);
}
