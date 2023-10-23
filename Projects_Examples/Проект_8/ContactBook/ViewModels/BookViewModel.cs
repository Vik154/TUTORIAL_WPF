using ContactBook.Services;
using ContactBook.Utility;
using System.Windows.Input;

namespace ContactBook.ViewModels;

public class BookViewModel : ObservableObject {

    #region ПОЛЯ И СЛУЖБЫ

    /// <summary> Сервис хранения контактов </summary>
    private IContactDataService _contactDataService;


    #endregion

    #region СВОЙСТВА
    /// <summary> Заголовок главного окна </summary>
    private string _title = "Книга";

    /// <summary> Заголовок главного окна </summary>
    public string Title {
        get => _title;
        set => OnPropertyChanged(ref _title, value);
    }

    /// <summary> Модель - представление списка контактов </summary>
    private ContactsViewModel? _contactsViewModel;

    /// <summary> Модель - представление списка контактов </summary>
    public ContactsViewModel? ContactsViewModel {
        get => _contactsViewModel;
        set => OnPropertyChanged(ref _contactsViewModel, value);
    }
    #endregion

    #region КОМАНДЫ
    /// <summary> Загрузка списка контактов </summary>
    public ICommand LoadContactsCommand { get; private set; }

    /// <summary> Загрузка списка избранных контактов </summary>
    public ICommand LoadFavoritesContactsCommand { get; private set; }

    #endregion

    #region КОНСТРУКТОРЫ
    public BookViewModel(IContactDataService dataService) {
        ContactsViewModel = new ContactsViewModel(dataService);
        _contactDataService = dataService;

        LoadContactsCommand = new RelayCommand(LoadContacts);
        LoadFavoritesContactsCommand = new RelayCommand(LoadFavorites);
        
    }
    #endregion

    #region МЕТОДЫ ДЛЯ КОМАНД

    /// <summary> Загрузка списка контактов </summary>
    private void LoadContacts() {
        _contactsViewModel?.LoadContacts(_contactDataService.GetContacts());
    }

    /// <summary> Загрузка списка избранных контактов </summary>
    public void LoadFavorites() {
        var favorites = _contactDataService.GetContacts().Where(c => c.IsFavorite);
        _contactsViewModel?.LoadContacts(favorites);
    }
    #endregion
}
