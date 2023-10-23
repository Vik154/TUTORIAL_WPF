using ContactBook.Models;
using ContactBook.Utility;
using System.Collections.ObjectModel;

namespace ContactBook.ViewModels;

/// <summary> Модель - представление хранящая все существующие контакты в записной книге </summary>
public class ContactsViewModel : ObservableObject {

    /// <summary> Выбранный контакт из списка контактов </summary>
    private Contact? _selectedContact;

    /// <summary> Выбранный контакт из списка контактов </summary>
    public Contact? SelectedContact {
        get => _selectedContact;
        set => OnPropertyChanged(ref _selectedContact, value);
    }

    /// <summary> Список контактов </summary>
    public ObservableCollection<Contact> Contacts { get; set; }

    public ContactsViewModel() { }

    /// <summary> Загрузка списка контактов </summary>
    public void LoadContacts(IEnumerable<Contact> contacts) {
        Contacts = new ObservableCollection<Contact>(contacts);
        OnPropertyChanged("Contacts");
    }
}
