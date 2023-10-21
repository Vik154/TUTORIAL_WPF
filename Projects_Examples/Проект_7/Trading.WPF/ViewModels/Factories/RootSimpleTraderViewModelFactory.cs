using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.WPF.State.Navigators;

namespace Trading.WPF.ViewModels.Factories;

public class RootSimpleTraderViewModelFactory : IRootSimpleTraderViewModelFactory {

    private readonly ISimpleTraderViewModelFactory<HomeViewModel> _homeViewModelFactory;
    private readonly ISimpleTraderViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;
    private readonly BuyViewModel _buyViewModel;

    public RootSimpleTraderViewModelFactory(ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory, 
        ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory,
        BuyViewModel buyViewModel)
    {
        _homeViewModelFactory = homeViewModelFactory;
        _portfolioViewModelFactory = portfolioViewModelFactory;
        _buyViewModel = buyViewModel;
    }

    public BaseViewModel CreateViewModel(ViewType viewType) {
     
        switch (viewType) {
            case ViewType.Home:
                return _homeViewModelFactory.CreateViewModel();
            case ViewType.Portfolio:
                return _portfolioViewModelFactory.CreateViewModel();
            case ViewType.Buy:
                return _buyViewModel;
            default:
                throw new ArgumentException("ViewModel not found");
        }
    }
}
