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

        Window window = new MainWindow();
        window.DataContext = new MainViewModel();
        window.Show();

        StockPriceService stock = new StockPriceService();

        // var res = stock.GetPrice("SBER");
        // var res2 = stock.GetPrice("VTBR");
        var res3 = stock.GetPrice("OLOL");

        base.OnStartup(e);
    }
}
