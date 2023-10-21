using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Domain.Exceptions;
using Trading.Domain.Models;

namespace Trading.Domain.Services.AuthenticationServices;

public class AuthenticationService : IAuthenticationService {

    private readonly IAccountService _accountService;
    private readonly IPasswordHasher _passwordHasher;

    public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher) {
        _accountService = accountService;
        _passwordHasher = passwordHasher;
    }

    public async Task<Account> Login(string username, string password) {
        Account storedAccount = await _accountService.GetByUsername(username);

        if (storedAccount == null) {
            throw new UserNotFoundException(username);
        }

        PasswordVerificationResult passwordResult = _passwordHasher
            .VerifyHashedPassword(storedAccount.AccountHolder.PasswordHash, password);

        if (passwordResult != PasswordVerificationResult.Success) {
            throw new InvalidPasswordException(username, password);
        }
        return storedAccount;
    }

    public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword) {

        RegistrationResult result = RegistrationResult.Success;

        if (password != confirmPassword) {
            result = RegistrationResult.PasswordsDoNotMatch;
        }

        Account emailAccount = await _accountService.GetByEmail(email);

        if (emailAccount != null) {
            result = RegistrationResult.EmailAlreadyExists;
        }

        Account userNameAccount = await _accountService.GetByUsername(username);

        if (userNameAccount != null) {
            result = RegistrationResult.UsernameAlreadyExists;
        }

        if (result == RegistrationResult.Success) {
            string hashedPassword = _passwordHasher.HashPassword(password);

            User user = new User {
                Email = email,
                Username = username,
                PasswordHash = hashedPassword,
                DateJoined = DateTime.Now
            };

            Account account = new Account {
                AccountHolder = user
            };

            await _accountService.Create(account);
        }

        return result;
    }
}
