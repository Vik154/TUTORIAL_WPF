using PC_Viewer.Core;
using PC_Viewer.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace PC_Viewer.ViewModels;

public class TrashViewModel : BaseViewModel {

    private CollectionViewSource TrashItemsCollection;
    public ICollectionView TrashSourceCollection => TrashItemsCollection.View;

    private string filterText = "";
    public string FilterText {
        get => filterText;
        set {
            OnPropertyChanged(ref filterText, value);
            TrashItemsCollection.View.Refresh();
        }
    }

    public TrashViewModel() {
        ObservableCollection<TrashItems> trashItems = new ObservableCollection<TrashItems> {
            new TrashItems { TrashName = "Data.txt", TrashImage = @"../Assets/notepad_icon.png" }
        };
        TrashItemsCollection = new CollectionViewSource { Source = trashItems };
        TrashItemsCollection.Filter += MenuItems_Filter;
    }

    private void MenuItems_Filter(object sender, FilterEventArgs e) {
        if (string.IsNullOrEmpty(FilterText)) {
            e.Accepted = true;
            return;
        }

        TrashItems? _item = e.Item as TrashItems;
        if (_item == null) { return; }
        if (_item.TrashName.ToUpper().Contains(FilterText.ToUpper())) {
            e.Accepted = true;
        }
        else {
            e.Accepted = false;
        }
    }
}
