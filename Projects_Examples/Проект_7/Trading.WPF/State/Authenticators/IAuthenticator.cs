using Trading.Domain.Models;
using Trading.Domain.Services.AuthenticationServices;

namespace Trading.WPF.State.Authenticators;

public interface IAuthenticator {
    Account CurrentAccount { get; }
    bool IsLoggedIn { get; }

    event Action StateChanged;

    Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);

    Task Login(string username, string password);

    void Logout();
}
