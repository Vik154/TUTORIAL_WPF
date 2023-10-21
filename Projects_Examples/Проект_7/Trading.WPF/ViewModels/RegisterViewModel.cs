using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trading.WPF.Commands;
using Trading.WPF.State.Authenticators;
using Trading.WPF.State.Navigators;

namespace Trading.WPF.ViewModels;

public class RegisterViewModel : BaseViewModel {
    private string _email;
    public string Email {
        get {
            return _email;
        }
        set {
            _email = value;
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(CanRegister));
        }
    }

    private string _username;
    public string Username {
        get {
            return _username;
        }
        set {
            _username = value;
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(CanRegister));
        }
    }

    private string _password;
    public string Password {
        get {
            return _password;
        }
        set {
            _password = value;
            OnPropertyChanged(nameof(Password));
            OnPropertyChanged(nameof(CanRegister));
        }
    }

    private string _confirmPassword;
    public string ConfirmPassword {
        get {
            return _confirmPassword;
        }
        set {
            _confirmPassword = value;
            OnPropertyChanged(nameof(ConfirmPassword));
            OnPropertyChanged(nameof(CanRegister));
        }
    }

    public bool CanRegister => !string.IsNullOrEmpty(Email) &&
        !string.IsNullOrEmpty(Username) &&
        !string.IsNullOrEmpty(Password) &&
        !string.IsNullOrEmpty(ConfirmPassword);

    public ICommand RegisterCommand { get; }

    public ICommand ViewLoginCommand { get; }

    public MessageViewModel ErrorMessageViewModel { get; }

    public string ErrorMessage {
        set => ErrorMessageViewModel.Message = value;
    }

    public RegisterViewModel(IAuthenticator authenticator, IRenavigator registerRenavigator, IRenavigator loginRenavigator) {
        ErrorMessageViewModel = new MessageViewModel();

        RegisterCommand = new RegisterCommand(this, authenticator, registerRenavigator);
        ViewLoginCommand = new RenavigateCommand(loginRenavigator);
    }

    public override void Dispose() {
        ErrorMessageViewModel.Dispose();

        base.Dispose();
    }
}
