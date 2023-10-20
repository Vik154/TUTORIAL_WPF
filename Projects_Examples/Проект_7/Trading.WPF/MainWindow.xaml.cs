using System.Windows;

namespace Trading.WPF;


public partial class MainWindow : Window {
    public MainWindow(object dataContext) {
        InitializeComponent();
        DataContext = dataContext;
    }
}