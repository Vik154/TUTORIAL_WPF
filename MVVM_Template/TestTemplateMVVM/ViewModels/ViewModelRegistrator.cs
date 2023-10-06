using Microsoft.Extensions.DependencyInjection;

namespace TestTemplateMVVM.ViewModels;


internal static class ViewModelRegistrator {

    public static IServiceCollection AddViews(this IServiceCollection services) => services
       .AddSingleton<MainWindowViewModel>();
}
