using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Trading.EntityFramework;

namespace Trading.WPF;

public partial class App : Application {

    private readonly IHost _host;

    public App() {
        _host = CreateHostBuilder().Build();
    }

    public static IHostBuilder CreateHostBuilder(string[] args = null) {
        return Host.CreateDefaultBuilder(args)
            .AddConfiguration()
            .AddFinanceAPI()
            .AddDbContext()
            .AddServices()
            .AddStores()
            .AddViewModels()
            .AddViews();
    }

    protected override void OnStartup(StartupEventArgs e) {
        _host.Start();

        SimpleTraderDbContextFactory contextFactory = _host.Services.GetRequiredService<SimpleTraderDbContextFactory>();
        using (SimpleTraderDbContext context = contextFactory.CreateDbContext()) {
            context.Database.Migrate();
        }

        Window window = _host.Services.GetRequiredService<MainWindow>();
        window.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e) {
        await _host.StopAsync();
        _host.Dispose();

        base.OnExit(e);
    }
}


//public partial class App : Application {

//    protected override async void OnStartup(StartupEventArgs e) {

//        IServiceProvider serviceProvider = CreateServiceProvider();
//        IAuthenticationService authentication = serviceProvider.GetRequiredService<IAuthenticationService>();
//        authentication.Login("Singleton", "test123");

//        //IBuyStockService buyStockService = serviceProvider.GetRequiredService<IBuyStockService>();

//        //IDataService<Account> dataService = new AccountDataService(
//        //    new EntityFramework.SimpleTraderDbContextFactory());
//        //IStockPriceService stockPriceService = new StockPriceService();

//        //IBuyStockService buyStockService = new BuyStockService(stockPriceService, dataService);

//        //Account buyer = await dataService.Get(1);

//        //await buyStockService.BuyStock(buyer, "AFLT", 5);

//        Window window = serviceProvider.GetRequiredService<MainWindow>();
//        window.Show();

//        // StockPriceService stock = new StockPriceService();

//        // var res = stock.GetPrice("SBER");
//        // var res2 = stock.GetPrice("VTBR");
//        // var res3 = stock.GetPrice("OLOL");

//        base.OnStartup(e);
//    }

//    private IServiceProvider CreateServiceProvider() {
//        IServiceCollection services = new ServiceCollection();

//        services.AddSingleton<SimpleTraderDbContextFactory>();
//        services.AddSingleton<IDataService<Account>, AccountDataService>();
//        services.AddSingleton<IAccountService, AccountDataService>();
//        services.AddSingleton<IAuthenticationService, AuthenticationService>();
//        services.AddSingleton<IStockPriceService, StockPriceService>();
//        services.AddSingleton<IBuyStockService, BuyStockService>();
//        services.AddSingleton<IMajorIndexService, MajorIndexService>();

//        services.AddSingleton<IPasswordHasher, PasswordHasher>();

//        services.AddSingleton<ISimpleTraderViewModelFactory, SimpleTraderViewModelFactory>();
//        services.AddSingleton<ISimpleTraderViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
//        services.AddSingleton<ISimpleTraderViewModelFactory<PortfolioViewModel>, PortfolioViewModelFactory>();
//        services.AddSingleton<ISimpleTraderViewModelFactory<MajorIndexListingViewModel>, MajorIndexListingViewModelFactory>();
//        services.AddSingleton<ISimpleTraderViewModelFactory<LoginViewModel>, LoginViewModelFactory>();

//        services.AddScoped<INavigator, Navigator>();
//        services.AddScoped<IAuthenticator, Authenticator>();
//        services.AddScoped<MainViewModel>();
//        services.AddScoped<BuyViewModel>();

//        services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

//        return services.BuildServiceProvider();
//    }
//}
