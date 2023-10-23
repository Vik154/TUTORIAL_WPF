using ContactBook.Utility;
using System.Windows.Input;

namespace ContactBook.ViewModels;

public class BookViewModel : ObservableObject {

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
    private ContactsViewModel? ContactsViewModel {
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
    public BookViewModel() {
        ContactsViewModel = new ContactsViewModel();

        LoadContactsCommand = new RelayCommand(LoadContacts);
        LoadFavoritesContactsCommand = new RelayCommand(LoadFavorites);
        
    }
    #endregion

    #region МЕТОДЫ ДЛЯ КОМАНД

    /// <summary> Загрузка списка контактов </summary>
    private void LoadContacts() {

    }

    /// <summary> Загрузка списка избранных контактов </summary>
    public void LoadFavorites() {

    }
    #endregion
}
