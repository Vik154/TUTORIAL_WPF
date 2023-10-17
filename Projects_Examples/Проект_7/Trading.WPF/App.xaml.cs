using System.Configuration;
using System.Data;
using System.Windows;
using Trading.Domain.Models;
using Trading.Domain.Services;
using Trading.FinancialModelingPrepAPI.Services;
using Trading.WPF.ViewModels;

namespace Trading.WPF; 


public partial class App : Application {

    protected override void OnStartup(StartupEventArgs e) {

        new MajorIndexService().GetMajorIndex(MajorIndexType.RTS).ContinueWith(task => {
            var index = task.Result;
        });


        Window window = new MainWindow();
        window.DataContext = new MainViewModel();
        window.Show();

        base.OnStartup(e);
    }
}
