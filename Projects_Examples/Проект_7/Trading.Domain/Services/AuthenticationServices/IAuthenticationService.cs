using Trading.Domain.Models;

namespace Trading.Domain.Services.AuthenticationServices;

public enum RegistrationResult {
    Success,
    PasswordsDoNotMatch,
    EmailAlreadyExists,
    UsernameAlreadyExists
}

public interface IAuthenticationService {
    Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);

    Task<Account> Login(string username, string password);
}
