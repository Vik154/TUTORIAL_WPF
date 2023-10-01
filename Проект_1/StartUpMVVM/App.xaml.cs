using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StartUpMVVM.Services;
using StartUpMVVM.ViewModels;
using System.Configuration;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace StartUpMVVM;


public partial class App : Application {

    // Флаг выполнения - работает из exe или из дизайнера
    // для проверки виртуализации и нагрузки
    public static bool IsDesignModel { get; private set; } = true;

    // Хост
    /*-----------------------------------------------------------------*/
    private static IHost? _Host;

    public static IHost Host {
        get => _Host ?? Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
    }

    protected override async void OnStartup(StartupEventArgs e) {
        IsDesignModel = false;
        var host = Host;
        base.OnStartup(e);

        // ConfigureAwait(false) - против DeadLock
        await host.StartAsync().ConfigureAwait(false);
    }

    protected override async void OnExit(ExitEventArgs e) {
        base.OnExit(e);

        var host = Host;
        await host.StopAsync().ConfigureAwait(false);
        host.Dispose();
        _Host = null;
    }

    public static void ConfigureServices(HostBuilderContext context, 
                                         IServiceCollection collection)
    {
        collection.AddSingleton<DataService>();
        collection.AddSingleton<CountriesStatisticViewModel>();
    }

    public static string? CurrentDirectory => IsDesignModel
        ? Path.GetDirectoryName(GetSourceCodePath())
        : Environment.CurrentDirectory;

    private static string? GetSourceCodePath([CallerFilePath] string? path = null) => path;

}
