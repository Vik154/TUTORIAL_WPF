using Microsoft.AspNet.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Domain.Exceptions;
using Trading.Domain.Models;
using Trading.Domain.Services;
using Trading.Domain.Services.AuthenticationServices;

namespace Trading.Domain.Tests.Services.AuthenticationServices;

[TestFixture]
public class AuthenticationServiceTests {

    Mock<IAccountService> _mockAccountService;
    Mock<IPasswordHasher> _mockPasswordHasher;
    AuthenticationService _authenticationService;

    [SetUp]
    public void SetUp() {
        _mockAccountService = new Mock<IAccountService>();
        _mockPasswordHasher = new Mock<IPasswordHasher>();
        _authenticationService = new AuthenticationService(_mockAccountService.Object, _mockPasswordHasher.Object);

    }

    [Test]
    public async Task Login_WithCorrectPasswordForExistingUsername_ReturnsAccountForCorrectUsername() {

        // Arrange
        string expectedUsername = "testUser";
        string password = "test123";

        _mockAccountService.Setup(s => s.GetByUsername(expectedUsername)).ReturnsAsync(new Account { AccountHolder = new User { Username = expectedUsername } });        
        _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Success);
        
        // Act
        Account account = await _authenticationService.Login(expectedUsername, password);

        // Assert
        string actualUserName = account.AccountHolder.Username;
        Assert.AreEqual(expectedUsername, actualUserName);
    }

    [Test]
    public void Login_WithIncorrectPasswordForExistingUsername_ThrowsInvalidPasswordExceptionForUsername() {
        // Arrange
        string expectedUsername = "testUser";
        string password = "test123";

        _mockAccountService.Setup(s => s.GetByUsername(expectedUsername)).ReturnsAsync(new Account { AccountHolder = new User { Username = expectedUsername } });
        _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

        // Act
        InvalidPasswordException exception = Assert.ThrowsAsync<InvalidPasswordException>(() => 
                _authenticationService.Login(expectedUsername, password));

        // Assert
        string actualUserName = exception.Username;
        Assert.AreEqual(expectedUsername, actualUserName);
    }

    [Test]
    public void Login_WithNonExistingUsername_ThrowsInvalidPasswordExceptionForUsername() {
        string expectedUsername = "testUser";
        string password = "test123";
        _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

        UserNotFoundException exception = Assert.ThrowsAsync<UserNotFoundException>(() => _authenticationService.Login(expectedUsername, password));

        string actualUsername = exception.Username;
        Assert.AreEqual(expectedUsername, actualUsername);
    }

    [Test]
    public async Task Register_WithPasswordsNotMatching_ReturnsPasswordsDoNotMatch() {
        string password = "testUser";
        string confirmPassword = "test";
        RegistrationResult expected = RegistrationResult.PasswordsDoNotMatch;

        RegistrationResult actual = await _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), password, confirmPassword);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public async Task Register_WithAlreadyExistingEmail_ReturnsEmailAlreadyExists() {
        string email = "test@gmail.com";
        _mockAccountService.Setup(s => s.GetByEmail(email)).ReturnsAsync(new Account());
        RegistrationResult expected = RegistrationResult.EmailAlreadyExists;

        RegistrationResult actual = await _authenticationService.Register(email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public async Task Register_WithAlreadyExistingUsername_ReturnsUsernameAlreadyExists() {
        string username = "testuser";
        _mockAccountService.Setup(s => s.GetByUsername(username)).ReturnsAsync(new Account());
        RegistrationResult expected = RegistrationResult.UsernameAlreadyExists;

        RegistrationResult actual = await _authenticationService.Register(It.IsAny<string>(), username, It.IsAny<string>(), It.IsAny<string>());

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public async Task Register_WithNonExistingUserAndMatchingPasswords_ReturnsSuccess() {
        RegistrationResult expected = RegistrationResult.Success;

        RegistrationResult actual = await _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

        Assert.AreEqual(expected, actual);
    }
}
