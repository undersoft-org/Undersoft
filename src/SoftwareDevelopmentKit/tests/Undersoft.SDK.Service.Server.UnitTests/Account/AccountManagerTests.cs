using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Data.Store.Repository;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountManager"/>.
/// </summary>
[TestClass]
public class AccountManagerTests
{
    private AccountManager _testClass;
    private IFixture _fixture;
    private UserManager<AccountUser> _user;
    private RoleManager<Role> _role;
    private SignInManager<AccountUser> _signIn;
    private AccountTokenGenerator _token;
    private Mock<IStoreRepository<IAccountStore, Account>> _accounts;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountManager"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._user = _fixture.Create<UserManager<AccountUser>>();
        this._role = _fixture.Create<RoleManager<Role>>();
        this._signIn = _fixture.Create<SignInManager<AccountUser>>();
        this._token = _fixture.Create<AccountTokenGenerator>();
        this._accounts = _fixture.Freeze<Mock<IStoreRepository<IAccountStore, Account>>>();
        this._testClass = _fixture.Create<AccountManager>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccountManager();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new AccountManager(this._user, this._role, this._signIn, this._token, this._accounts.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the user parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullUser()
    {
        FluentActions.Invoking(() => new AccountManager(default(UserManager<AccountUser>), this._role, this._signIn, this._token, this._accounts.Object)).Should().Throw<ArgumentNullException>().WithParameterName("user");
    }

    /// <summary>
    /// Checks that instance construction throws when the role parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRole()
    {
        FluentActions.Invoking(() => new AccountManager(this._user, default(RoleManager<Role>), this._signIn, this._token, this._accounts.Object)).Should().Throw<ArgumentNullException>().WithParameterName("role");
    }

    /// <summary>
    /// Checks that instance construction throws when the signIn parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSignIn()
    {
        FluentActions.Invoking(() => new AccountManager(this._user, this._role, default(SignInManager<AccountUser>), this._token, this._accounts.Object)).Should().Throw<ArgumentNullException>().WithParameterName("signIn");
    }

    /// <summary>
    /// Checks that instance construction throws when the token parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullToken()
    {
        FluentActions.Invoking(() => new AccountManager(this._user, this._role, this._signIn, default(AccountTokenGenerator), this._accounts.Object)).Should().Throw<ArgumentNullException>().WithParameterName("token");
    }

    /// <summary>
    /// Checks that instance construction throws when the accounts parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullAccounts()
    {
        FluentActions.Invoking(() => new AccountManager(this._user, this._role, this._signIn, this._token, default(IStoreRepository<IAccountStore, Account>))).Should().Throw<ArgumentNullException>().WithParameterName("accounts");
    }

    /// <summary>
    /// Checks that the GetToken method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetTokenWithStringAndStringAsync()
    {
        // Arrange
        var email = _fixture.Create<string>();
        var password = _fixture.Create<string>();

        // Act
        var result = await this._testClass.GetToken(email, password);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetToken method throws when the email parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallGetTokenWithStringAndStringWithInvalidEmailAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.GetToken(value, _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("email");
    }

    /// <summary>
    /// Checks that the GetToken method throws when the password parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallGetTokenWithStringAndStringWithInvalidPasswordAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.GetToken(_fixture.Create<string>(), value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("password");
    }

    /// <summary>
    /// Checks that the GetToken method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetTokenWithAuthAsync()
    {
        // Arrange
        var auth = _fixture.Create<IAuthorization>();

        // Act
        var result = await this._testClass.GetToken(auth);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetToken method throws when the auth parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetTokenWithAuthWithNullAuthAsync()
    {
        await FluentActions.Invoking(() => this._testClass.GetToken(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("auth");
    }

    /// <summary>
    /// Checks that the CheckToken method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallCheckTokenAsync()
    {
        // Arrange
        var token = _fixture.Create<string>();

        // Act
        var result = await this._testClass.CheckToken(token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CheckToken method throws when the token parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallCheckTokenWithInvalidTokenAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.CheckToken(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("token");
    }

    /// <summary>
    /// Checks that the RenewToken method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallRenewTokenAsync()
    {
        // Arrange
        var token = _fixture.Create<string>();

        // Act
        var result = await this._testClass.RenewToken(token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RenewToken method throws when the token parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallRenewTokenWithInvalidTokenAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.RenewToken(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("token");
    }

    /// <summary>
    /// Checks that the CheckPassword method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallCheckPasswordAsync()
    {
        // Arrange
        var email = _fixture.Create<string>();
        var password = _fixture.Create<string>();

        // Act
        var result = await this._testClass.CheckPassword(email, password);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CheckPassword method throws when the email parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallCheckPasswordWithInvalidEmailAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.CheckPassword(value, _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("email");
    }

    /// <summary>
    /// Checks that the CheckPassword method throws when the password parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallCheckPasswordWithInvalidPasswordAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.CheckPassword(_fixture.Create<string>(), value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("password");
    }

    /// <summary>
    /// Checks that the SetUser method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetUserAsync()
    {
        // Arrange
        var username = _fixture.Create<string>();
        var email = _fixture.Create<string>();
        var password = _fixture.Create<string>();
        var roles = _fixture.Create<IEnumerable<string>>();
        var scopes = _fixture.Create<IEnumerable<string>>();

        // Act
        var result = await this._testClass.SetUser(username, email, password, roles, scopes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetUser method throws when the roles parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetUserWithNullRolesAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SetUser(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), default(IEnumerable<string>), _fixture.Create<IEnumerable<string>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("roles");
    }

    /// <summary>
    /// Checks that the SetUser method throws when the username parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSetUserWithInvalidUsernameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.SetUser(value, _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<IEnumerable<string>>(), _fixture.Create<IEnumerable<string>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("username");
    }

    /// <summary>
    /// Checks that the SetUser method throws when the email parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSetUserWithInvalidEmailAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.SetUser(_fixture.Create<string>(), value, _fixture.Create<string>(), _fixture.Create<IEnumerable<string>>(), _fixture.Create<IEnumerable<string>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("email");
    }

    /// <summary>
    /// Checks that the SetUser method throws when the password parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSetUserWithInvalidPasswordAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.SetUser(_fixture.Create<string>(), _fixture.Create<string>(), value, _fixture.Create<IEnumerable<string>>(), _fixture.Create<IEnumerable<string>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("password");
    }

    /// <summary>
    /// Checks that the SetUser maps values from the input to the returned instance.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task SetUserPerformsMappingAsync()
    {
        // Arrange
        var username = _fixture.Create<string>();
        var email = _fixture.Create<string>();
        var password = _fixture.Create<string>();
        var roles = _fixture.Create<IEnumerable<string>>();
        var scopes = _fixture.Create<IEnumerable<string>>();

        // Act
        var result = await this._testClass.SetUser(username, email, password, roles, scopes);

        // Assert
        result.Roles.Should().BeSameAs(roles);
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDeleteAsync()
    {
        // Arrange
        var email = _fixture.Create<string>();

        // Act
        var result = await this._testClass.Delete(email);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Delete method throws when the email parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallDeleteWithInvalidEmailAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Delete(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("email");
    }

    /// <summary>
    /// Checks that the SetUserRole method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetUserRole()
    {
        // Arrange
        var email = _fixture.Create<string>();
        var current = _fixture.Create<string>();
        var previous = _fixture.Create<string>();

        // Act
        var result = this._testClass.SetUserRole(email, current, previous);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetUserRole method throws when the email parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetUserRoleWithInvalidEmail(string value)
    {
        FluentActions.Invoking(() => this._testClass.SetUserRole(value, _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("email");
    }

    /// <summary>
    /// Checks that the SetUserRole method throws when the current parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetUserRoleWithInvalidCurrent(string value)
    {
        FluentActions.Invoking(() => this._testClass.SetUserRole(_fixture.Create<string>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("current");
    }

    /// <summary>
    /// Checks that the SetUserRole method throws when the previous parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetUserRoleWithInvalidPrevious(string value)
    {
        FluentActions.Invoking(() => this._testClass.SetUserRole(_fixture.Create<string>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("previous");
    }

    /// <summary>
    /// Checks that the SetUserClaim method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetUserClaimAsync()
    {
        // Arrange
        var email = _fixture.Create<string>();
        var claim = _fixture.Create<Claim>();

        // Act
        var result = await this._testClass.SetUserClaim(email, claim);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetUserClaim method throws when the claim parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetUserClaimWithNullClaimAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SetUserClaim(_fixture.Create<string>(), default(Claim))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("claim");
    }

    /// <summary>
    /// Checks that the SetUserClaim method throws when the email parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSetUserClaimWithInvalidEmailAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.SetUserClaim(value, _fixture.Create<Claim>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("email");
    }

    /// <summary>
    /// Checks that the SetRole method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetRoleAsync()
    {
        // Arrange
        var roleName = _fixture.Create<string>();

        // Act
        var result = await this._testClass.SetRole(roleName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetRole method throws when the roleName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSetRoleWithInvalidRoleNameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.SetRole(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("roleName");
    }

    /// <summary>
    /// Checks that the SetRoleClaim method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetRoleClaimAsync()
    {
        // Arrange
        var roleName = _fixture.Create<string>();
        var claim = _fixture.Create<Claim>();

        // Act
        var result = await this._testClass.SetRoleClaim(roleName, claim);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetRoleClaim method throws when the claim parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetRoleClaimWithNullClaimAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SetRoleClaim(_fixture.Create<string>(), default(Claim))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("claim");
    }

    /// <summary>
    /// Checks that the SetRoleClaim method throws when the roleName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSetRoleClaimWithInvalidRoleNameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.SetRoleClaim(value, _fixture.Create<Claim>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("roleName");
    }

    /// <summary>
    /// Checks that the TryGetByEmail method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetByEmail()
    {
        // Arrange
        var email = _fixture.Create<string>();

        // Act
        var result = this._testClass.TryGetByEmail(email, out var account);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGetByEmail method throws when the email parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallTryGetByEmailWithInvalidEmail(string value)
    {
        FluentActions.Invoking(() => this._testClass.TryGetByEmail(value, out _)).Should().Throw<ArgumentNullException>().WithParameterName("email");
    }

    /// <summary>
    /// Checks that the TryGetById method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetById()
    {
        // Arrange
        var id = _fixture.Create<long>();

        // Act
        var result = this._testClass.TryGetById(id, out var account);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGetByName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetByName()
    {
        // Arrange
        var name = _fixture.Create<string>();

        // Act
        var result = this._testClass.TryGetByName(name, out var account);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGetByName method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallTryGetByNameWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.TryGetByName(value, out _)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetByName method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetByNameAsync()
    {
        // Arrange
        var name = _fixture.Create<string>();

        // Act
        var result = await this._testClass.GetByName(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetByName method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallGetByNameWithInvalidNameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.GetByName(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetByEmail method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetByEmailAsync()
    {
        // Arrange
        var email = _fixture.Create<string>();

        // Act
        var result = await this._testClass.GetByEmail(email);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetByEmail method throws when the email parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallGetByEmailWithInvalidEmailAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.GetByEmail(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("email");
    }

    /// <summary>
    /// Checks that the GetById method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetByIdAsync()
    {
        // Arrange
        var id = _fixture.Create<long>();

        // Act
        var result = await this._testClass.GetById(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapAccount method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallMapAccountAsync()
    {
        // Arrange
        var account = _fixture.Create<Account>();

        // Act
        var result = await this._testClass.MapAccount(account);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapAccount method throws when the account parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallMapAccountWithNullAccountAsync()
    {
        await FluentActions.Invoking(() => this._testClass.MapAccount(default(Account))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("account");
    }

    /// <summary>
    /// Checks that setting the Accounts property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccounts()
    {
        this._testClass.CheckProperty(x => x.Accounts, _fixture.Create<IStoreRepository<IAccountStore, Account>>(), _fixture.Create<IStoreRepository<IAccountStore, Account>>());
    }

    /// <summary>
    /// Checks that setting the User property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUser()
    {
        this._testClass.CheckProperty(x => x.User, _fixture.Create<UserManager<AccountUser>>(), _fixture.Create<UserManager<AccountUser>>());
    }

    /// <summary>
    /// Checks that setting the Role property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRole()
    {
        this._testClass.CheckProperty(x => x.Role, _fixture.Create<RoleManager<Role>>(), _fixture.Create<RoleManager<Role>>());
    }

    /// <summary>
    /// Checks that setting the SignIn property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSignIn()
    {
        this._testClass.CheckProperty(x => x.SignIn, _fixture.Create<SignInManager<AccountUser>>(), _fixture.Create<SignInManager<AccountUser>>());
    }

    /// <summary>
    /// Checks that setting the Token property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetToken()
    {
        this._testClass.CheckProperty(x => x.Token, _fixture.Create<AccountTokenGenerator>(), _fixture.Create<AccountTokenGenerator>());
    }
}