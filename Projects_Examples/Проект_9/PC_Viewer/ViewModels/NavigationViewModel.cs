using PC_Viewer.Core;
using PC_Viewer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

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



    public NavigationViewModel() {

        ObservableCollection<MenuItems> menuItems = new ObservableCollection<MenuItems> {
                new MenuItems { MenuName = "Home", MenuImage = @"../Assets/Home_Icon.png" },
                new MenuItems { MenuName = "Desktop", MenuImage = @"../Assets/Desktop_Icon.png" },
                new MenuItems { MenuName = "Documents", MenuImage = @"../Assets/Document_Icon.png" },
                new MenuItems { MenuName = "Downloads", MenuImage = @"../Assets/Download_Icon.png" },
                new MenuItems { MenuName = "Pictures", MenuImage = @"../Assets/Images_Icon.png" },
                new MenuItems { MenuName = "Music", MenuImage = @"../Assets/Music_Icon.png" },
                new MenuItems { MenuName = "Movies", MenuImage = @"../Assets/Movies_Icon.png" },
                new MenuItems { MenuName = "Trash", MenuImage = @"../Assets/Trash_Icon.png" }
            };

        _menuItemsCollection = new CollectionViewSource { Source = menuItems };
        _menuItemsCollection.Filter += MenuItems_Filter;

        // Set Startup Page
        // SelectedViewModel = new StartupViewModel();
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

    //public void SwitchViews(object parameter) {
    //    switch (parameter) {
    //        case "Home":
    //            SelectedViewModel = new HomeViewModel();
    //            break;
    //        case "Desktop":
    //            SelectedViewModel = new DesktopViewModel();
    //            break;
    //        case "Documents":
    //            SelectedViewModel = new DocumentViewModel();
    //            break;
    //        case "Downloads":
    //            SelectedViewModel = new DownloadViewModel();
    //            break;
    //        case "Pictures":
    //            SelectedViewModel = new PictureViewModel();
    //            break;
    //        case "Music":
    //            SelectedViewModel = new MusicViewModel();
    //            break;
    //        case "Movies":
    //            SelectedViewModel = new MovieViewModel();
    //            break;
    //        case "Trash":
    //            SelectedViewModel = new TrashViewModel();
    //            break;
    //        default:
    //            SelectedViewModel = new HomeViewModel();
    //            break;
    //    }
    //}
}
