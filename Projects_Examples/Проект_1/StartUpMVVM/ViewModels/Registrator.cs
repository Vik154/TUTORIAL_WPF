using Microsoft.Extensions.DependencyInjection;

namespace StartUpMVVM.ViewModels;

internal static class Registrator {
    
    public static IServiceCollection RegisterViewModels(this IServiceCollection services) {
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<CountriesStatisticViewModel>();
        services.AddSingleton<WebServerViewModel>();
        services.AddTransient<StudentsManagementViewModel>();
        return services;
    }
}
