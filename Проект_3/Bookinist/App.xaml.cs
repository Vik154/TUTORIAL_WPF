﻿using Bookinist.Data;
using Bookinist.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Bookinist;

public partial class App : Application {

    private static IHost __Host;

    public static IHost Host =>__Host 
        ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

    public static IServiceProvider Services =>__Host.Services;

    internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
        .AddDataBase(host.Configuration.GetSection("Database"))
        .AddServices()
        .AddViewModels()
    ;

    

    protected override async void OnStartup(StartupEventArgs e) {
        var host = Host;
        base.OnStartup(e);
        await host.StartAsync();
    }

    protected override async void OnExit(ExitEventArgs e) {
        using var host = Host;
        base.OnExit(e);
        await host.StopAsync();
    }
}
