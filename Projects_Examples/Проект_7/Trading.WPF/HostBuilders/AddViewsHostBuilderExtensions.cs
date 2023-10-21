using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trading.WPF.ViewModels;

namespace Trading.WPF.HostBuilders;

public static class AddViewsHostBuilderExtensions {
    public static IHostBuilder AddViews(this IHostBuilder host) {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
        });

        return host;
    }
}
