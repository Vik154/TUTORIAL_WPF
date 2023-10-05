using FileEncryptor.WPF.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FileEncryptor.WPF.Services;

// Регистратор всех сервисов приложения
internal static class ServicesRegistrator {

    // Добавление сервиса  
    public static IServiceCollection AddServices(this IServiceCollection services) => services
        .AddTransient<IUserDialog, UserDialogService>()
        .AddTransient<IEncryptor, Rfc2898Encryptor>();
}
