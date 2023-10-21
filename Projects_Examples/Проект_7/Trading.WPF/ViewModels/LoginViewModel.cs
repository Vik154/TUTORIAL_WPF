using System.Windows.Input;
using Trading.WPF.Commands;
using Trading.WPF.State.Authenticators;
using Trading.WPF.State.Navigators;

namespace Trading.WPF.ViewModels;

public class LoginViewModel : BaseViewModel {

    private string _username = "SingletonSean";
    public string Username {
        get {
            return _username;
        }
        set {
            _username = value;
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(CanLogin));
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
            OnPropertyChanged(nameof(CanLogin));
        }
    }

    public bool CanLogin => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

    public MessageViewModel ErrorMessageViewModel { get; }

    public string ErrorMessage {
        set => ErrorMessageViewModel.Message = value;
    }

    public ICommand LoginCommand { get; }
    public ICommand ViewRegisterCommand { get; }

    public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator, IRenavigator registerRenavigator) {
        ErrorMessageViewModel = new MessageViewModel();

        LoginCommand = new LoginCommand(this, authenticator, loginRenavigator);
        ViewRegisterCommand = new RenavigateCommand(registerRenavigator);
    }

    public override void Dispose() {
        ErrorMessageViewModel.Dispose();

        base.Dispose();
    }
}