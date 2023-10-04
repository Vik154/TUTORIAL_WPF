using Microsoft.Extensions.DependencyInjection;
using StartUpMVVM.Services.Interfaces;

namespace StartUpMVVM.Services;

internal static class Registrator {

    public static IServiceCollection RegisterServices(this IServiceCollection services) {
        services.AddSingleton<IDataService, DataService>();
        services.AddTransient<IAsyncDataService, AsyncDataService>();
        services.AddTransient<IWebServerService, HttpListenerWebSeverer>();

        services.AddSingleton<StudentsRepository>();
        services.AddSingleton<GroupRepository>();
        //services.AddSingleton<StudentsManager>();

        //services.AddTransient<IUserDialogService, WindowsUserDialogService>();

        return services;
    }
}
