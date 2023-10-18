using System.Windows.Input;
using Trading.FinancialModelingPrepAPI.Services;
using Trading.WPF.State.Navigators;
using Trading.WPF.ViewModels;

namespace Trading.WPF.Commands;


public class UpdateCurrentViewModelCommand : ICommand {
    
    public event EventHandler? CanExecuteChanged;
    private INavigator _navigator;

    public UpdateCurrentViewModelCommand(INavigator navigator) => _navigator = navigator;

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter) {
        
        if (parameter is ViewType) {
            ViewType viewType = (ViewType)parameter;

            switch (viewType) {
                case ViewType.Home:
                    _navigator.CurrentViewModel = new HomeViewModel(MajorIndexListingViewModel
                        .LoadMajorIndexViewModel(new MajorIndexService()));
                    break;
                case ViewType.Portfolio:
                    _navigator.CurrentViewModel = new PortfolioViewModel();
                    break;
                default:
                    break;
            }
        }

    }
}
