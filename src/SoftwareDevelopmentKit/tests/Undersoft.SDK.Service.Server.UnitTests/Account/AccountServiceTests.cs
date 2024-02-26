using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountService"/>.
/// </summary>
[TestClass]
public class AccountServiceTests
{
    private AccountService _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;
    private Mock<IAccountManager> _accountManager;
    private Mock<IEmailSender> _email;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountService"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._accountManager = _fixture.Freeze<Mock<IAccountManager>>();
        this._email = _fixture.Freeze<Mock<IEmailSender>>();
        this._testClass = _fixture.Create<AccountService>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccountService();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new AccountService(this._servicer.Object, this._accountManager.Object, this._email.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new AccountService(default(IServicer), this._accountManager.Object, this._email.Object)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that instance construction throws when the accountManager parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullAccountManager()
    {
        FluentActions.Invoking(() => new AccountService(this._servicer.Object, default(IAccountManager), this._email.Object)).Should().Throw<ArgumentNullException>().WithParameterName("accountManager");
    }

    /// <summary>
    /// Checks that instance construction throws when the email parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEmail()
    {
        FluentActions.Invoking(() => new AccountService(this._servicer.Object, this._accountManager.Object, default(IEmailSender))).Should().Throw<ArgumentNullException>().WithParameterName("email");
    }

    /// <summary>
    /// Checks that the SignIn method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSignInAsync()
    {
        // Arrange
        var identity = _fixture.Create<IAuthorization>();

        _accountManager.Setup(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>())).Returns(_fixture.Create<bool>());
        _accountManager.Setup(mock => mock.CheckPassword(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(_fixture.Create<Account>());
        _accountManager.Setup(mock => mock.GetByEmail(It.IsAny<string>())).ReturnsAsync(_fixture.Create<Account>());
        _accountManager.Setup(mock => mock.GetToken(It.IsAny<IAuthorization>())).ReturnsAsync(_fixture.Create<string>());
        _accountManager.Setup(mock => mock.User).Returns(_fixture.Create<UserManager<AccountUser>>());
        _accountManager.Setup(mock => mock.SignIn).Returns(_fixture.Create<SignInManager<AccountUser>>());

        // Act
        var result = await this._testClass.SignIn(identity);

        // Assert
        _servicer.Verify(mock => mock.Serve<IEmailSender>(It.IsAny<Func<IEmailSender, Task>>()));
        _accountManager.Verify(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>()));
        _accountManager.Verify(mock => mock.CheckPassword(It.IsAny<string>(), It.IsAny<string>()));
        _accountManager.Verify(mock => mock.GetByEmail(It.IsAny<string>()));
        _accountManager.Verify(mock => mock.GetToken(It.IsAny<IAuthorization>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SignIn method throws when the identity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSignInWithNullIdentityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SignIn(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("identity");
    }

    /// <summary>
    /// Checks that the SignUp method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSignUpAsync()
    {
        // Arrange
        var identity = _fixture.Create<IAuthorization>();

        _accountManager.Setup(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>())).Returns(_fixture.Create<bool>());
        _accountManager.Setup(mock => mock.SetUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>())).ReturnsAsync(_fixture.Create<Account>());
        _accountManager.Setup(mock => mock.CheckPassword(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(_fixture.Create<Account>());
        _accountManager.Setup(mock => mock.GetByEmail(It.IsAny<string>())).ReturnsAsync(_fixture.Create<Account>());

        // Act
        var result = await this._testClass.SignUp(identity);

        // Assert
        _servicer.Verify(mock => mock.Serve<IEmailSender>(It.IsAny<Func<IEmailSender, Task>>()));
        _accountManager.Verify(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>()));
        _accountManager.Verify(mock => mock.SetUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()));
        _accountManager.Verify(mock => mock.CheckPassword(It.IsAny<string>(), It.IsAny<string>()));
        _accountManager.Verify(mock => mock.GetByEmail(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SignUp method throws when the identity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSignUpWithNullIdentityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SignUp(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("identity");
    }

    /// <summary>
    /// Checks that the SignOut method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSignOutAsync()
    {
        // Arrange
        var identity = _fixture.Create<IAuthorization>();

        _accountManager.Setup(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>())).Returns(_fixture.Create<bool>());
        _accountManager.Setup(mock => mock.SignIn).Returns(_fixture.Create<SignInManager<AccountUser>>());
        _accountManager.Setup(mock => mock.User).Returns(_fixture.Create<UserManager<AccountUser>>());

        // Act
        var result = await this._testClass.SignOut(identity);

        // Assert
        _accountManager.Verify(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SignOut method throws when the identity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSignOutWithNullIdentityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SignOut(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("identity");
    }

    /// <summary>
    /// Checks that the Renew method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallRenewAsync()
    {
        // Arrange
        var identity = _fixture.Create<IAuthorization>();

        _accountManager.Setup(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>())).Returns(_fixture.Create<bool>());
        _accountManager.Setup(mock => mock.RenewToken(It.IsAny<string>())).ReturnsAsync(_fixture.Create<string>());

        // Act
        var result = await this._testClass.Renew(identity);

        // Assert
        _accountManager.Verify(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>()));
        _accountManager.Verify(mock => mock.RenewToken(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Renew method throws when the identity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallRenewWithNullIdentityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Renew(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("identity");
    }

    /// <summary>
    /// Checks that the AccountInfo method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAccountInfoAsync()
    {
        // Arrange
        var identity = _fixture.Create<IAuthorization>();

        _accountManager.Setup(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>())).Returns(_fixture.Create<bool>());

        // Act
        var result = await this._testClass.AccountInfo(identity);

        // Assert
        _accountManager.Verify(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AccountInfo method throws when the identity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallAccountInfoWithNullIdentityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.AccountInfo(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("identity");
    }

    /// <summary>
    /// Checks that the Authenticate method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAuthenticateAsync()
    {
        // Arrange
        var account = _fixture.Create<IAuthorization>();

        _accountManager.Setup(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>())).Returns(_fixture.Create<bool>());
        _accountManager.Setup(mock => mock.CheckPassword(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(_fixture.Create<Account>());

        // Act
        var result = await this._testClass.Authenticate(account);

        // Assert
        _accountManager.Verify(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>()));
        _accountManager.Verify(mock => mock.CheckPassword(It.IsAny<string>(), It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Authenticate method throws when the account parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallAuthenticateWithNullAccountAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Authenticate(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("account");
    }

    /// <summary>
    /// Checks that the ConfirmEmail method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallConfirmEmailAsync()
    {
        // Arrange
        var account = _fixture.Create<IAuthorization>();

        _accountManager.Setup(mock => mock.GetByEmail(It.IsAny<string>())).ReturnsAsync(_fixture.Create<Account>());
        _accountManager.Setup(mock => mock.User).Returns(_fixture.Create<UserManager<AccountUser>>());

        // Act
        var result = await this._testClass.ConfirmEmail(account);

        // Assert
        _servicer.Verify(mock => mock.Serve<IEmailSender>(It.IsAny<Func<IEmailSender, Task>>()));
        _accountManager.Verify(mock => mock.GetByEmail(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ConfirmEmail method throws when the account parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallConfirmEmailWithNullAccountAsync()
    {
        await FluentActions.Invoking(() => this._testClass.ConfirmEmail(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("account");
    }

    /// <summary>
    /// Checks that the ResetPassword method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallResetPasswordAsync()
    {
        // Arrange
        var account = _fixture.Create<IAuthorization>();

        _accountManager.Setup(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>())).Returns(_fixture.Create<bool>());
        _accountManager.Setup(mock => mock.GetByEmail(It.IsAny<string>())).ReturnsAsync(_fixture.Create<Account>());
        _accountManager.Setup(mock => mock.User).Returns(_fixture.Create<UserManager<AccountUser>>());

        // Act
        var result = await this._testClass.ResetPassword(account);

        // Assert
        _servicer.Verify(mock => mock.Serve<IEmailSender>(It.IsAny<Func<IEmailSender, Task>>()));
        _accountManager.Verify(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>()));
        _accountManager.Verify(mock => mock.GetByEmail(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ResetPassword method throws when the account parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallResetPasswordWithNullAccountAsync()
    {
        await FluentActions.Invoking(() => this._testClass.ResetPassword(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("account");
    }

    /// <summary>
    /// Checks that the ChangePassword method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallChangePasswordAsync()
    {
        // Arrange
        var account = _fixture.Create<IAuthorization>();

        _accountManager.Setup(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>())).Returns(_fixture.Create<bool>());
        _accountManager.Setup(mock => mock.CheckPassword(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(_fixture.Create<Account>());
        _accountManager.Setup(mock => mock.GetByEmail(It.IsAny<string>())).ReturnsAsync(_fixture.Create<Account>());
        _accountManager.Setup(mock => mock.User).Returns(_fixture.Create<UserManager<AccountUser>>());

        // Act
        var result = await this._testClass.ChangePassword(account);

        // Assert
        _accountManager.Verify(mock => mock.TryGetByEmail(It.IsAny<string>(), It.IsAny<IAccount>()));
        _accountManager.Verify(mock => mock.CheckPassword(It.IsAny<string>(), It.IsAny<string>()));
        _accountManager.Verify(mock => mock.GetByEmail(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ChangePassword method throws when the account parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallChangePasswordWithNullAccountAsync()
    {
        await FluentActions.Invoking(() => this._testClass.ChangePassword(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("account");
    }

    /// <summary>
    /// Checks that the CompleteRegistration method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallCompleteRegistrationAsync()
    {
        // Arrange
        var account = _fixture.Create<IAuthorization>();

        _accountManager.Setup(mock => mock.GetByEmail(It.IsAny<string>())).ReturnsAsync(_fixture.Create<Account>());
        _accountManager.Setup(mock => mock.User).Returns(_fixture.Create<UserManager<AccountUser>>());

        // Act
        var result = await this._testClass.CompleteRegistration(account);

        // Assert
        _accountManager.Verify(mock => mock.GetByEmail(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompleteRegistration method throws when the account parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallCompleteRegistrationWithNullAccountAsync()
    {
        await FluentActions.Invoking(() => this._testClass.CompleteRegistration(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("account");
    }

    /// <summary>
    /// Checks that the GenerateRandomPassword method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGenerateRandomPassword()
    {
        // Arrange
        var opts = _fixture.Create<PasswordOptions>();

        // Act
        var result = AccountService.GenerateRandomPassword(opts);

        // Assert
        Assert.Fail("Create or modify test");
    }
}