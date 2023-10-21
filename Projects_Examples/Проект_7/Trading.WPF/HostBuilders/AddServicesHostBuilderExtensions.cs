using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trading.Domain.Models;
using Trading.Domain.Services;
using Trading.Domain.Services.AuthenticationServices;
using Trading.Domain.Services.TransactionServices;
using Trading.EntityFramework.Services;
using Trading.FinancialModelingPrepAPI.Services;

namespace Trading.WPF.HostBuilders;
public static class AddServicesHostBuilderExtensions {
    public static IHostBuilder AddServices(this IHostBuilder host) {
        host.ConfigureServices(services => {
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<IAccountService, AccountDataService>();
            services.AddSingleton<IStockPriceService, StockPriceService>();
            services.AddSingleton<IBuyStockService, BuyStockService>();
            services.AddSingleton<ISellStockService, SellStockService>();
            services.AddSingleton<IMajorIndexService, MajorIndexService>();
        });

        return host;
    }
}
