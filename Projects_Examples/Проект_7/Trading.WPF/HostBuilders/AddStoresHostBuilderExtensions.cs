using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trading.WPF.State.Accounts;
using Trading.WPF.State.Assets;
using Trading.WPF.State.Authenticators;
using Trading.WPF.State.Navigators;

namespace Trading.WPF.HostBuilders;
public static class AddStoresHostBuilderExtensions {
    public static IHostBuilder AddStores(this IHostBuilder host) {
        host.ConfigureServices(services => {
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAccountStore, AccountStore>();
            services.AddSingleton<AssetStore>();
        });

        return host;
    }
}
