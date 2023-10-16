using System.Configuration;
using System.Data;
using System.Windows;
using Trading.WPF.ViewModels;

namespace Trading.WPF; 


public partial class App : Application {

    protected override void OnStartup(StartupEventArgs e) {

        Window window = new MainWindow();
        window.DataContext = new MainViewModel();
        window.Show();

        base.OnStartup(e);
    }
}
