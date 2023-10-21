using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trading.Domain.Services;
using Trading.WPF.State.Authenticators;
using Trading.WPF.State.Navigators;
using Trading.WPF.ViewModels;
using Trading.WPF.ViewModels.Factories;

namespace Trading.WPF.HostBuilders;

public static class AddViewModelsHostBuilderExtensions {
    public static IHostBuilder AddViewModels(this IHostBuilder host) {
        host.ConfigureServices(services => {
            services.AddTransient(CreateHomeViewModel);
            services.AddTransient<PortfolioViewModel>();
            services.AddTransient<BuyViewModel>();
            services.AddTransient<SellViewModel>();
            services.AddTransient<AssetSummaryViewModel>();
            services.AddTransient<MainViewModel>();

            services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());
            services.AddSingleton<CreateViewModel<PortfolioViewModel>>(services => () => services.GetRequiredService<PortfolioViewModel>());
            services.AddSingleton<CreateViewModel<BuyViewModel>>(services => () => services.GetRequiredService<BuyViewModel>());
            services.AddSingleton<CreateViewModel<SellViewModel>>(services => () => services.GetRequiredService<SellViewModel>());
            services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
            services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => CreateRegisterViewModel(services));

            services.AddSingleton<ISimpleTraderViewModelFactory, SimpleTraderViewModelFactory>();

            services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
        });

        return host;
    }

    private static HomeViewModel CreateHomeViewModel(IServiceProvider services) {
        return new HomeViewModel(
            services.GetRequiredService<AssetSummaryViewModel>(),
            MajorIndexListingViewModel.LoadMajorIndexViewModel(services.GetRequiredService<IMajorIndexService>()));
    }

    private static LoginViewModel CreateLoginViewModel(IServiceProvider services) {
        return new LoginViewModel(
            services.GetRequiredService<IAuthenticator>(),
            services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
            services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>());
    }

    private static RegisterViewModel CreateRegisterViewModel(IServiceProvider services) {
        return new RegisterViewModel(
            services.GetRequiredService<IAuthenticator>(),
            services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
            services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>());
    }
}
