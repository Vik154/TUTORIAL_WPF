using PC_Viewer.Core;
using PC_Viewer.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace PC_Viewer.ViewModels;

public class PictureViewModel : BaseViewModel {

    private CollectionViewSource PictureItemsCollection;
    public ICollectionView PictureSourceCollection => PictureItemsCollection.View;

    private string filterText = "";
    public string FilterText {
        get => filterText;
        set {
            OnPropertyChanged(ref filterText, value);
            PictureItemsCollection.View.Refresh();
        }
    }

    public PictureViewModel() {
        ObservableCollection<PictureItems> pictureItems = new ObservableCollection<PictureItems> {
            new PictureItems { PictureName = "Logo", PictureImage = @"../Assets/channel_icon.png" }
        };
        PictureItemsCollection = new CollectionViewSource { Source = pictureItems };
        PictureItemsCollection.Filter += MenuItems_Filter;
    }


    private void MenuItems_Filter(object sender, FilterEventArgs e) {
        if (string.IsNullOrEmpty(FilterText)) {
            e.Accepted = true;
            return;
        }

        PictureItems? _item = e.Item as PictureItems;
        if (_item == null) return;
        if (_item.PictureName.ToUpper().Contains(FilterText.ToUpper())) {
            e.Accepted = true;
        }
        else {
            e.Accepted = false;
        }
    }
}
