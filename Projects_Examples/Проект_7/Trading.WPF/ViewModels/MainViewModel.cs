using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trading.WPF.Commands;
using Trading.WPF.State.Authenticators;
using Trading.WPF.State.Navigators;
using Trading.WPF.ViewModels.Factories;

namespace Trading.WPF.ViewModels;

public class MainViewModel : BaseViewModel {

    private readonly IRootSimpleTraderViewModelFactory _viewModelFactory;

    public INavigator Navigator { get; set; }
    public IAuthenticator Authenticator { get; }
    public ICommand UpdateCurrentViewModelCommand { get; }

    public MainViewModel(INavigator navigator, 
                         IRootSimpleTraderViewModelFactory viewModelFactory, 
                         IAuthenticator authenticator) 
    {
        Navigator = navigator;
        _viewModelFactory = viewModelFactory;
        Authenticator = authenticator;

        UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
        UpdateCurrentViewModelCommand.Execute(ViewType.Login);
    }
}
