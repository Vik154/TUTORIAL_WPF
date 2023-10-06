using Microsoft.Extensions.DependencyInjection;

namespace Bookinist.ViewModels;

static class ServicesRegistrator {
    public static IServiceCollection AddServices(this IServiceCollection services) => services
        .AddSingleton<MainWindowViewModel>()
        ;
}
