using Trading.Domain.Models;
using Trading.Domain.Services.AuthenticationServices;
using Trading.WPF.Models;

namespace Trading.WPF.State.Authenticators;

public class Authenticator : ObservableObject, IAuthenticator {

    private readonly IAuthenticationService _authenticationService;
    // private readonly IAccountStore _accountStore;

    public Authenticator(IAuthenticationService authenticationService /*IAccountStore accountStore*/) {
        _authenticationService = authenticationService;
        //_accountStore = accountStore;
    }

    private Account _currentAccount;
    public Account CurrentAccount {
        get {
            return _currentAccount;
        }
        private set {
            _currentAccount = value;
            OnPropertyChanged(nameof(CurrentAccount));
            OnPropertyChanged(nameof(IsLoggedIn));
        }
    }

    public bool IsLoggedIn => CurrentAccount != null;

    public event Action StateChanged;

    public async Task<bool> Login(string username, string password) {

        bool success = true;

        try {
            CurrentAccount = await _authenticationService.Login(username, password);
        }
        catch (Exception) {

            success = false;
        }
        return success;
    }

    public void Logout() {
        CurrentAccount = null;
    }

    public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword) {
        return await _authenticationService.Register(email, username, password, confirmPassword);
    }

    Task IAuthenticator.Login(string username, string password) {
        throw new NotImplementedException();
    }
}
