using Microsoft.Extensions.DependencyInjection;
using StartUpMVVM.Services.Interfaces;

namespace StartUpMVVM.Services;

internal static class Registrator {

    public static IServiceCollection RegisterServices(this IServiceCollection services) {
        services.AddSingleton<IDataService, DataService>();
        //services.AddTransient<IDataService, DataService>();
        //services.AddScoped<IDataService, DataService>();

        services.AddTransient<IAsyncDataService, AsyncDataService>();
        services.AddTransient<IWebServerService, HttpListenerWebSeverer>();

        //services.AddSingleton<StudentsRepository>();
        //services.AddSingleton<GroupsRepository>();
        //services.AddSingleton<StudentsManager>();

        //services.AddTransient<IUserDialogService, WindowsUserDialogService>();

        return services;
    }
}
