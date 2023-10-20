using System.Configuration;
using System.Data;
using System.Windows;
using Trading.Domain.Models;
using Trading.Domain.Services;
using Trading.Domain.Services.TransactionServices;
using Trading.EntityFramework.Services;
using Trading.FinancialModelingPrepAPI.Services;
using Trading.WPF.ViewModels;

namespace Trading.WPF; 


public partial class App : Application {

    protected override async void OnStartup(StartupEventArgs e) {

        IDataService<Account> dataService = new AccountDataService(
            new EntityFramework.SimpleTraderDbContextFactory());
        IStockPriceService stockPriceService = new StockPriceService();

        IBuyStockService buyStockService = new BuyStockService(stockPriceService, dataService);

        Account buyer = await dataService.Get(1);

        await buyStockService.BuyStock(buyer, "AFLT", 5);

        Window window = new MainWindow();
        window.DataContext = new MainViewModel();
        window.Show();

        // StockPriceService stock = new StockPriceService();

        // var res = stock.GetPrice("SBER");
        // var res2 = stock.GetPrice("VTBR");
        // var res3 = stock.GetPrice("OLOL");

        base.OnStartup(e);
    }
}
