using Microsoft.Extensions.DependencyInjection;
using TestTemplateMVVM.Services.Interfaces;

namespace TestTemplateMVVM.Services;

// Чтобы использовать - нужно установить пакет Microsoft.Extensions
// using Microsoft.Extensions.DependencyInjection;

static class ServiceRegistrator {
    public static IServiceCollection AddServices(this IServiceCollection services) => services
        .AddTransient<IDataService, DataService>()
        .AddTransient<IUserDialog, UserDialog>();
}
