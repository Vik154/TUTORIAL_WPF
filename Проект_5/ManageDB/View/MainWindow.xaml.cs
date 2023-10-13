using ManageDB.ViewModel;
using System.Windows;

namespace ManageDB.View;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        DataContext = new DataManageVM();
    }
}
