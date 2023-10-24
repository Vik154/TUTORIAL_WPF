using PC_Viewer.Core;
using PC_Viewer.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace PC_Viewer.ViewModels;

public class HomeViewModel : BaseViewModel {

    private CollectionViewSource HomeItemsCollection;
    public ICollectionView HomeSourceCollection => HomeItemsCollection.View;

    public HomeViewModel() {
        ObservableCollection<HomeItems> homeItems = new ObservableCollection<HomeItems> {
                new HomeItems { HomeName = "This PC", HomeImage = @"../Assets/pc_icon.png" },
            };

        HomeItemsCollection = new CollectionViewSource { Source = homeItems };
    }
}
