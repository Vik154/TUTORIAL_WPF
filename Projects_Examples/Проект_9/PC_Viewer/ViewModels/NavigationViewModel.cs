using PC_Viewer.Core;
using PC_Viewer.Models;
using PC_Viewer.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace PC_Viewer.ViewModels;

/// <summary> Навигация по моделям </summary>
public class NavigationViewModel : BaseViewModel {

    #region ПОЛЯ
    private readonly DesktopViewModel  _desktopViewModel  = new();
    private readonly HomeViewModel     _homeViewModel     = new();
    private readonly DocumentViewModel _documentViewModel = new();
    private readonly DownloadViewModel _downloadViewModel = new();
    private readonly MovieViewModel    _movieViewModel    = new();

    /// <summary> Позволяет отделять исходную коллекцию от представления и манипулировать ею 
    /// без изменения фактической коллекции. Другими словами позволяет привязывать 
    /// одну и ту же коллекцию источников к нескольким представлениям </summary>
    private CollectionViewSource _menuItemsCollection;

    /// <summary> Этот интерфейс представляет собой абстракцию представления (View)
    /// для заданного источника данных (data source).  Это значит, что создается связь между источником 
    /// данных и его представлением и любое изменение в источнике данных будет отображено в его представлении.
    public ICollectionView SourceCollection => _menuItemsCollection.View;
    #endregion

    #region СВОЙСТВА
    /// <summary> Фильтр текстового поиска </summary>
    private string filterText = "";

    /// <summary> Фильтр текстового поиска </summary>
    public string FilterText {
        get => filterText;
        set {
            OnPropertyChanged(ref filterText, value);
            _menuItemsCollection.View.Refresh();
        }
    }

    /// <summary> Текущая модель - представление </summary>
    private object? _selectedViewModel;

    /// <summary> Текущая модель - представление </summary>
    public object? SelectedViewModel {
        get => _selectedViewModel;
        set { OnPropertyChanged(ref _selectedViewModel, value); }
    }
    #endregion

    #region КОМАНДЫ
    /// <summary> Команда для кнопки "меню" </summary>
    public ICommand MenuCommand => _menucommand is null ? new RelayCommand(p => SwitchViews(p)) : _menucommand;
    private ICommand? _menucommand;

    /// <summary> Команда для кнопки "текущая модель-пред. для PC" </summary>
    public ICommand ThisPCCommand => _pccommand is null ? new RelayCommand(p => PCView()) : _pccommand;
    private ICommand? _pccommand;

    /// <summary> Команда для кнопки "вернуться назад" </summary>
    public ICommand BackHomeCommand => _backHomeCommand is null ? new RelayCommand(p => ShowHome()) : _backHomeCommand;
    private ICommand? _backHomeCommand;

    /// <summary> Команда для кнопки "закрыть" </summary>
    public ICommand CloseAppCommand => _closeCommand is null ? new RelayCommand(p => CloseApp(p)) : _closeCommand;
    private ICommand? _closeCommand;

    #endregion

    #region КОНСТРУКТОРЫ
    public NavigationViewModel() {

        ObservableCollection<MenuItems> menuItems = new ObservableCollection<MenuItems> {
                new MenuItems { MenuName = "Главная",      MenuImage = @"../Assets/Home_Icon.png" },
                new MenuItems { MenuName = "Рабочий стол", MenuImage = @"../Assets/Desktop_Icon.png" },
                new MenuItems { MenuName = "Документы",    MenuImage = @"../Assets/Document_Icon.png" },
                new MenuItems { MenuName = "Загрузки",     MenuImage = @"../Assets/Download_Icon.png" },
                new MenuItems { MenuName = "Изображения",  MenuImage = @"../Assets/Images_Icon.png" },
                new MenuItems { MenuName = "Музыка",       MenuImage = @"../Assets/Music_Icon.png" },
                new MenuItems { MenuName = "Видео",        MenuImage = @"../Assets/Movies_Icon.png" },
                new MenuItems { MenuName = "Корзина",      MenuImage = @"../Assets/Trash_Icon.png" }
        };
        _menuItemsCollection = new CollectionViewSource { Source = menuItems };
        _menuItemsCollection.Filter += MenuItems_Filter;
        SelectedViewModel = _homeViewModel;
    }

    #endregion

    #region МЕТОДЫ

    /// <summary> Выбрать ПК модель - представление </summary>
    public void PCView() {
        // SelectedViewModel = new PCViewModel();
    }

    /// <summary> Выбрать домашнюю модель - представление </summary>
    private void ShowHome() => SelectedViewModel = _homeViewModel;

    /// <summary> Метод закрытия окна </summary>
    public void CloseApp(object obj) {
        MainWindow? win = obj as MainWindow;
        win?.Close();
    }

    /// <summary> Фильтр по имени элемента </summary>
    private void MenuItems_Filter(object sender, FilterEventArgs e) {
        if (string.IsNullOrEmpty(FilterText)) {
            e.Accepted = true;
            return;
        }

        MenuItems? _item = e.Item as MenuItems;
        if (_item == null) { return; }
        if (_item.MenuName.ToUpper().Contains(FilterText.ToUpper())) {
            e.Accepted = true;
        }
        else {
            e.Accepted = false;
        }
    }

    /// <summary> Выбор модели - представления </summary>
    public void SwitchViews(object parameter) {
        switch (parameter) {
            case "Главная":      SelectedViewModel = _homeViewModel;        break;
            case "Рабочий стол": SelectedViewModel = _desktopViewModel;     break;
            case "Документы":    SelectedViewModel = _documentViewModel;    break;
            case "Загрузки":     SelectedViewModel = _downloadViewModel;    break;
            case "Видео":        SelectedViewModel = _movieViewModel;       break;
            //case "Pictures":
            //    SelectedViewModel = new PictureViewModel();
            //    break;
            //case "Music":
            //    SelectedViewModel = new MusicViewModel();
            //    break;
            //case "Trash":
            //    SelectedViewModel = new TrashViewModel();
            //    break;
            default:
                SelectedViewModel = _homeViewModel;
                break;
        }
    }
    #endregion
}
