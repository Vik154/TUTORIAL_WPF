using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Trading.Domain.Models;
using Trading.Domain.Services;
using Trading.Domain.Services.AuthenticationServices;
using Trading.Domain.Services.TransactionServices;
using Trading.EntityFramework;
using Trading.EntityFramework.Services;
using Trading.FinancialModelingPrepAPI.Services;
using Trading.WPF.State.Navigators;
using Trading.WPF.ViewModels;
using Trading.WPF.ViewModels.Factories;

namespace Trading.WPF; 


public partial class App : Application {

    protected override async void OnStartup(StartupEventArgs e) {

        IServiceProvider serviceProvider = CreateServiceProvider();
        IAuthenticationService authentication = serviceProvider.GetRequiredService<IAuthenticationService>();
        authentication.Login("Singleton", "test123");
        
        //IBuyStockService buyStockService = serviceProvider.GetRequiredService<IBuyStockService>();

        //IDataService<Account> dataService = new AccountDataService(
        //    new EntityFramework.SimpleTraderDbContextFactory());
        //IStockPriceService stockPriceService = new StockPriceService();

        //IBuyStockService buyStockService = new BuyStockService(stockPriceService, dataService);

        //Account buyer = await dataService.Get(1);

        //await buyStockService.BuyStock(buyer, "AFLT", 5);

        Window window = serviceProvider.GetRequiredService<MainWindow>();
        window.Show();

        // StockPriceService stock = new StockPriceService();

        // var res = stock.GetPrice("SBER");
        // var res2 = stock.GetPrice("VTBR");
        // var res3 = stock.GetPrice("OLOL");

        base.OnStartup(e);
    }

    private IServiceProvider CreateServiceProvider() {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<SimpleTraderDbContextFactory>();
        services.AddSingleton<IDataService<Account>, AccountDataService>();
        services.AddSingleton<IAccountService, AccountDataService>();
        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IStockPriceService, StockPriceService>();
        services.AddSingleton<IBuyStockService, BuyStockService>();
        services.AddSingleton<IMajorIndexService, MajorIndexService>();

        services.AddSingleton<IPasswordHasher, PasswordHasher>();

        services.AddSingleton<IRootSimpleTraderViewModelFactory, RootSimpleTraderViewModelFactory>();
        services.AddSingleton<ISimpleTraderViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
        services.AddSingleton<ISimpleTraderViewModelFactory<PortfolioViewModel>, PortfolioViewModelFactory>();
        services.AddSingleton<ISimpleTraderViewModelFactory<MajorIndexListingViewModel>, MajorIndexListingViewModelFactory>();

        services.AddScoped<INavigator, Navigator>();
        services.AddScoped<MainViewModel>();
        services.AddScoped<BuyViewModel>();

        services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

        return services.BuildServiceProvider();
    }
}
