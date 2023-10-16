using System.Configuration;
using System.Data;
using System.Windows;

namespace Trading.WPF; 


public partial class App : Application {

    protected override void OnStartup(StartupEventArgs e) {

        Window window = new Window();
        window.Show();

        base.OnStartup(e);
    }
}
