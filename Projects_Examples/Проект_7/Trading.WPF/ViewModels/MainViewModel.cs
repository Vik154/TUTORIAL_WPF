using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.WPF.State.Authenticators;
using Trading.WPF.State.Navigators;

namespace Trading.WPF.ViewModels;

public class MainViewModel : BaseViewModel {

    public INavigator Navigator { get; set; }
    public IAuthenticator Authenticator { get; }

    public MainViewModel(INavigator navigator, IAuthenticator authenticator) {
        Navigator = navigator;
        Authenticator = authenticator;
        Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Login);
    }
}
