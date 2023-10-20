using System.Windows.Input;
using Trading.FinancialModelingPrepAPI.Services;
using Trading.WPF.State.Navigators;
using Trading.WPF.ViewModels;
using Trading.WPF.ViewModels.Factories;

namespace Trading.WPF.Commands;


public class UpdateCurrentViewModelCommand : ICommand {
    
    public event EventHandler? CanExecuteChanged;
    private readonly INavigator _navigator;
    private readonly ISimpleTraderViewModelAbstractFactory _viewModelFactory;

    public UpdateCurrentViewModelCommand(INavigator navigator, 
        ISimpleTraderViewModelAbstractFactory viewModelFactory) 
    {
        _navigator = navigator;
        _viewModelFactory = viewModelFactory;
    }

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter) {
        
        if (parameter is ViewType) {
            ViewType viewType = (ViewType)parameter;
        
            _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
        }

    }
}
