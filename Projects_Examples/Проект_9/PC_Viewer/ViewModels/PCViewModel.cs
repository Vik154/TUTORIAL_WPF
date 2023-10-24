using PC_Viewer.Core;
using PC_Viewer.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace PC_Viewer.ViewModels;

public class PCViewModel : BaseViewModel {

    private readonly CollectionViewSource PCItemsCollection;
    public ICollectionView PCSourceCollection => PCItemsCollection.View;

    public PCViewModel() {
        ObservableCollection<PCItems> pcItems = new ObservableCollection<PCItems> {
                new PCItems { PCName = "Local Disk (C:)", PCImage = @"../Assets/drive_icon.png" },
                new PCItems { PCName = "Local Disk (D:)", PCImage = @"../Assets/drive_icon.png" },
                new PCItems { PCName = "Local Disk (E:)", PCImage = @"../Assets/drive_icon.png" },
                new PCItems { PCName = "Local Disk (F:)", PCImage = @"../Assets/drive_icon.png" }
        };  
        PCItemsCollection = new CollectionViewSource { Source = pcItems };
    }
}
