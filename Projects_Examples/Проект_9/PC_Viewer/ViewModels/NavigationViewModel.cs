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

    /// <summary> Позволяет отделять исходную коллекцию от представления и манипулировать ею 
    /// без изменения фактической коллекции. Другими словами позволяет привязывать 
    /// одну и ту же коллекцию источников к нескольким представлениям </summary>
    private CollectionViewSource _menuItemsCollection;

    /// <summary> Этот интерфейс представляет собой абстракцию представления (View)
    /// для заданного источника данных (data source).  Это значит, что создается связь между источником 
    /// данных и его представлением и любое изменение в источнике данных будет отображено в его представлении.
    public ICollectionView SourceCollection => _menuItemsCollection.View;

    /// <summary> Фильтр текстового поиска </summary>
    private string filterText;

    /// <summary> Фильтр текстового поиска </summary>
    public string FilterText {
        get => filterText;
        set {
            OnPropertyChanged(ref filterText, value);
            _menuItemsCollection.View.Refresh();
        }
    }

    /// <summary> Текущая модель - представление </summary>
    private object _selectedViewModel;

    /// <summary> Текущая модель - представление </summary>
    public object SelectedViewModel {
        get => _selectedViewModel;
        set { OnPropertyChanged(ref _selectedViewModel, value); }
    }


    /// <summary> Команда для кнопки "меню" </summary>
    private ICommand _menucommand;

    /// <summary> Команда для кнопки "меню" </summary>
    public ICommand MenuCommand => _menucommand is null ? new RelayCommand(p => SwitchViews(p)) : _menucommand;


    // Show PC View
    public void PCView() {
        // SelectedViewModel = new PCViewModel();
    }

    // This PC button Command
    private ICommand _pccommand;
    public ICommand ThisPCCommand {
        get {
            if (_pccommand == null) {
                _pccommand = new RelayCommand(param => PCView());
            }
            return _pccommand;
        }
    }

    // Show Home View
    private void ShowHome() {
        SelectedViewModel = new HomeViewModel();
    }

    // Back button Command
    private ICommand _backHomeCommand;
    public ICommand BackHomeCommand {
        get {
            if (_backHomeCommand == null) {
                _backHomeCommand = new RelayCommand(p => ShowHome());
            }
            return _backHomeCommand;
        }
    }

    // Close App
    public void CloseApp(object obj) {
        MainWindow? win = obj as MainWindow;
        win?.Close();
    }

    // Close App Command
    private ICommand _closeCommand;
    public ICommand CloseAppCommand {
        get {
            if (_closeCommand == null) {
                _closeCommand = new RelayCommand(p => CloseApp(p));
            }
            return _closeCommand;
        }
    }





    public NavigationViewModel() {

        ObservableCollection<MenuItems> menuItems = new ObservableCollection<MenuItems> {
                new MenuItems { MenuName = "Главная", MenuImage = @"../Assets/Home_Icon.png" },
                new MenuItems { MenuName = "Рабочий стол", MenuImage = @"../Assets/Desktop_Icon.png" },
                new MenuItems { MenuName = "Документы", MenuImage = @"../Assets/Document_Icon.png" },
                new MenuItems { MenuName = "Загрузки", MenuImage = @"../Assets/Download_Icon.png" },
                new MenuItems { MenuName = "Изображения", MenuImage = @"../Assets/Images_Icon.png" },
                new MenuItems { MenuName = "Музыка", MenuImage = @"../Assets/Music_Icon.png" },
                new MenuItems { MenuName = "Видео", MenuImage = @"../Assets/Movies_Icon.png" },
                new MenuItems { MenuName = "Корзина", MenuImage = @"../Assets/Trash_Icon.png" }
            };

        _menuItemsCollection = new CollectionViewSource { Source = menuItems };
        _menuItemsCollection.Filter += MenuItems_Filter;

        // Set Startup Page
        SelectedViewModel = new DesktopViewModel();
    }

    private void MenuItems_Filter(object sender, FilterEventArgs e) {
        if (string.IsNullOrEmpty(FilterText)) {
            e.Accepted = true;
            return;
        }

        MenuItems? _item = e.Item as MenuItems;
        if (_item.MenuName.ToUpper().Contains(FilterText.ToUpper())) {
            e.Accepted = true;
        }
        else {
            e.Accepted = false;
        }
    }

    public void SwitchViews(object parameter) {
        switch (parameter) {
            case "Home":
                SelectedViewModel = new HomeViewModel();
                break;
            case "Desktop":
                SelectedViewModel = new DesktopViewModel();
                break;
            //case "Documents":
            //    SelectedViewModel = new DocumentViewModel();
            //    break;
            //case "Downloads":
            //    SelectedViewModel = new DownloadViewModel();
            //    break;
            //case "Pictures":
            //    SelectedViewModel = new PictureViewModel();
            //    break;
            //case "Music":
            //    SelectedViewModel = new MusicViewModel();
            //    break;
            //case "Movies":
            //    SelectedViewModel = new MovieViewModel();
            //    break;
            //case "Trash":
            //    SelectedViewModel = new TrashViewModel();
            //    break;
            default:
                SelectedViewModel = new HomeViewModel();
                break;
        }
    }
}
