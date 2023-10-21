using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trading.WPF.State.Authenticators;
using Trading.WPF.ViewModels;

namespace Trading.WPF.Commands;

public class LoginCommand : ICommand {

    private readonly IAuthenticator _authenticator;
    private readonly LoginViewModel _loginViewModel;
    public event EventHandler? CanExecuteChanged;

    public LoginCommand(IAuthenticator authenticator, LoginViewModel loginViewModel) {
        _authenticator = authenticator;
        _loginViewModel = loginViewModel;
    }

    public bool CanExecute(object? parameter) => true;

    public async void Execute(object? parameter) {
         await _authenticator.Login(_loginViewModel.Username, parameter.ToString());
    }
}
