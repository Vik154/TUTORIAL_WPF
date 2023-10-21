using System.Windows.Input;
using Trading.WPF.Commands;
using Trading.WPF.State.Authenticators;

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


 
    public ICommand LoginCommand { get; }

    public LoginViewModel(IAuthenticator authenticator) {

       // LoginCommand = new LoginCommand(this, authenticator);
    }

}
