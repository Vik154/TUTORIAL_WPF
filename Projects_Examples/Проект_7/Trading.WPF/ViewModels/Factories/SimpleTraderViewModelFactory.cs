using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.WPF.State.Navigators;

namespace Trading.WPF.ViewModels.Factories;

public class SimpleTraderViewModelAbstarctFactory : ISimpleTraderViewModelAbstractFactory {

    private readonly ISimpleTraderViewModelFactory<HomeViewModel> _homeViewModelFactory;
    private readonly ISimpleTraderViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;

    public SimpleTraderViewModelAbstarctFactory(ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory, 
        ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory)
    {
        _homeViewModelFactory = homeViewModelFactory;
        _portfolioViewModelFactory = portfolioViewModelFactory;
    }

    public BaseViewModel CreateViewModel(ViewType viewType) {
     
        switch (viewType) {
            case ViewType.Home:
                return _homeViewModelFactory.CreateViewModel();
            case ViewType.Portfolio:
                return _portfolioViewModelFactory.CreateViewModel();
            default:
                throw new ArgumentException("ViewModel not found");
        }
    }
}
