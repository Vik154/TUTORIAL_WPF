using Microsoft.Extensions.DependencyInjection;

namespace FileEncryptor.WPF.ViewModels;

// Регистрация всех моделей представления
internal static class ViewModelsRegistrator {

    // Регистрация модели главного окна  
    public static IServiceCollection AddViewModels(this IServiceCollection services) =>
        services.AddSingleton<MainWindowViewModel>();
}
