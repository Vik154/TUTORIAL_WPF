using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Windows;
using TestTemplateMVVM.ViewModels;
using TestTemplateMVVM.Services;

namespace TestTemplateMVVM;

public partial class App {
    public static Window? ActivedWindow => 
        Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);

    public static Window? FocusedWindow => 
        Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsFocused);

    private static IHost? __Host;

    public static IHost Host => __Host ??= Microsoft.Extensions.Hosting.Host
       .CreateDefaultBuilder(Environment.GetCommandLineArgs())
       .ConfigureAppConfiguration(cfg => cfg.AddJsonFile("appsettings.json", true, true))
       .ConfigureServices((host, services) => services
           .AddViews()
           .AddServices()
            )
       .Build();

    public static IServiceProvider Services => Host.Services;

    protected override async void OnStartup(StartupEventArgs e) {
        var host = Host;
        base.OnStartup(e);
        await host.StartAsync();
    }

    protected override async void OnExit(ExitEventArgs e) {
        base.OnExit(e);
        using var host = Host;
        await host.StopAsync();
    }
}
