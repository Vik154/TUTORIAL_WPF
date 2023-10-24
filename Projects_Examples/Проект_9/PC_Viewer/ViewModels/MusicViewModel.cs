using PC_Viewer.Core;
using PC_Viewer.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace PC_Viewer.ViewModels;

public class MusicViewModel : BaseViewModel {

    private CollectionViewSource MusicItemsCollection;
    public ICollectionView MusicSourceCollection => MusicItemsCollection.View;

    private string filterText;
    public string FilterText {
        get => filterText;
        set {
            OnPropertyChanged(ref filterText, value);
            MusicItemsCollection.View.Refresh();
        }
    }

    public MusicViewModel() {
        ObservableCollection<MusicItems> musicItems = new ObservableCollection<MusicItems> {
                new MusicItems { MusicName = "Bass", MusicImage = @"../Assets/note_icon.png" },
                new MusicItems { MusicName = "Beats", MusicImage = @"../Assets/note_icon.png" },
                new MusicItems { MusicName = "Electronic", MusicImage = @"../Assets/note_icon.png" },
                new MusicItems { MusicName = "Hip hop", MusicImage = @"../Assets/note_icon.png" },
                new MusicItems { MusicName = "Deep House", MusicImage = @"../Assets/note_icon.png" },
                new MusicItems { MusicName = "Instrumental", MusicImage = @"../Assets/note_icon.png" }
        };
        MusicItemsCollection = new CollectionViewSource { Source = musicItems };
        MusicItemsCollection.Filter += MenuItems_Filter;
    }

    private void MenuItems_Filter(object sender, FilterEventArgs e) {
        if (string.IsNullOrEmpty(FilterText)) {
            e.Accepted = true;
            return;
        }

        MusicItems? _item = e.Item as MusicItems;
        if (_item == null) return;
        if (_item.MusicName.ToUpper().Contains(FilterText.ToUpper())) {
            e.Accepted = true;
        }
        else {
            e.Accepted = false;
        }
    }
}
