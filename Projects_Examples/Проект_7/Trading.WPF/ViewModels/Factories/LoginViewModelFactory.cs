using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.WPF.State.Authenticators;
using Trading.WPF.State.Navigators;

namespace Trading.WPF.ViewModels.Factories;

public class LoginViewModelFactory : ISimpleTraderViewModelFactory<LoginViewModel> {

    private readonly IAuthenticator _authenticator;
    private readonly INavigator _navigator;

    public LoginViewModelFactory(IAuthenticator authenticator, INavigator navigator) {
        _authenticator = authenticator;
        _navigator = navigator;
    }

    public LoginViewModel CreateViewModel() {
        return new LoginViewModel(_authenticator, _navigator);
    }
}
