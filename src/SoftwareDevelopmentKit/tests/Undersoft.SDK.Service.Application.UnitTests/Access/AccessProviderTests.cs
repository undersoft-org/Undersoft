using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.JSInterop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Application.Access;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Data.Store;
using TAccount = Undersoft.SDK.Service.Access.Authorization;

namespace Undersoft.SDK.Service.Application.UnitTests.Access;

/// <summary>
/// Unit tests for the type <see cref="AccessProvider"/>.
/// </summary>
[TestClass]
public class AccessProvider_1Tests
{
    private AccessProvider<TAccount> _testClass;
    private IFixture _fixture;
    private Mock<IJSRuntime> _js;
    private Mock<IRemoteRepository<IAccountStore, TAccount>> _repository;
    private Mock<IAuthorization> _authorization;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccessProvider"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._js = _fixture.Freeze<Mock<IJSRuntime>>();
        this._repository = _fixture.Freeze<Mock<IRemoteRepository<IAccountStore, TAccount>>>();
        this._authorization = _fixture.Freeze<Mock<IAuthorization>>();
        this._testClass = _fixture.Create<AccessProvider<TAccount>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccessProvider<TAccount>(this._js.Object, this._repository.Object, this._authorization.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the js parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullJs()
    {
        FluentActions.Invoking(() => new AccessProvider<TAccount>(default(IJSRuntime), this._repository.Object, this._authorization.Object)).Should().Throw<ArgumentNullException>().WithParameterName("js");
    }

    /// <summary>
    /// Checks that instance construction throws when the repository parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepository()
    {
        FluentActions.Invoking(() => new AccessProvider<TAccount>(this._js.Object, default(IRemoteRepository<IAccountStore, TAccount>), this._authorization.Object)).Should().Throw<ArgumentNullException>().WithParameterName("repository");
    }

    /// <summary>
    /// Checks that instance construction throws when the authorization parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullAuthorization()
    {
        FluentActions.Invoking(() => new AccessProvider<TAccount>(this._js.Object, this._repository.Object, default(IAuthorization))).Should().Throw<ArgumentNullException>().WithParameterName("authorization");
    }

    /// <summary>
    /// Checks that the GetAuthenticationStateAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetAuthenticationStateAsync()
    {
        // Act
        var result = await this._testClass.GetAuthenticationStateAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetAccessState method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetAccessState()
    {
        // Arrange
        var token = _fixture.Create<string>();

        _authorization.Setup(mock => mock.Credentials).Returns(_fixture.Create<Credentials>());

        // Act
        var result = this._testClass.GetAccessState(token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetAccessState method throws when the token parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetAccessStateWithInvalidToken(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetAccessState(value)).Should().Throw<ArgumentNullException>().WithParameterName("token");
    }

    /// <summary>
    /// Checks that the SignIn method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSignInAsync()
    {
        // Arrange
        var auth = _fixture.Create<IAuthorization>();

        // Act
        var result = await this._testClass.SignIn(auth);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SignIn method throws when the auth parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSignInWithNullAuthAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SignIn(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("auth");
    }

    /// <summary>
    /// Checks that the SignUp method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSignUpAsync()
    {
        // Arrange
        var auth = _fixture.Create<IAuthorization>();

        // Act
        var result = await this._testClass.SignUp(auth);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SignUp method throws when the auth parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSignUpWithNullAuthAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SignUp(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("auth");
    }

    /// <summary>
    /// Checks that the SignOut method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSignOutAsync()
    {
        // Arrange
        var auth = _fixture.Create<IAuthorization>();

        // Act
        var result = await this._testClass.SignOut(auth);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SignOut method throws when the auth parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSignOutWithNullAuthAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SignOut(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("auth");
    }

    /// <summary>
    /// Checks that the Renew method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallRenewAsync()
    {
        // Arrange
        var auth = _fixture.Create<IAuthorization>();

        // Act
        var result = await this._testClass.Renew(auth);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Renew method throws when the auth parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallRenewWithNullAuthAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Renew(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("auth");
    }

    /// <summary>
    /// Checks that the ResetPassword method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallResetPasswordAsync()
    {
        // Arrange
        var auth = _fixture.Create<IAuthorization>();

        // Act
        var result = await this._testClass.ResetPassword(auth);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ResetPassword method throws when the auth parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallResetPasswordWithNullAuthAsync()
    {
        await FluentActions.Invoking(() => this._testClass.ResetPassword(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("auth");
    }

    /// <summary>
    /// Checks that the ChangePassword method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallChangePasswordAsync()
    {
        // Arrange
        var auth = _fixture.Create<IAuthorization>();

        // Act
        var result = await this._testClass.ChangePassword(auth);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ChangePassword method throws when the auth parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallChangePasswordWithNullAuthAsync()
    {
        await FluentActions.Invoking(() => this._testClass.ChangePassword(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("auth");
    }

    /// <summary>
    /// Checks that the AccountInfo method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAccountInfoAsync()
    {
        // Arrange
        var auth = _fixture.Create<IAuthorization>();

        // Act
        var result = await this._testClass.AccountInfo(auth);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AccountInfo method throws when the auth parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallAccountInfoWithNullAuthAsync()
    {
        await FluentActions.Invoking(() => this._testClass.AccountInfo(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("auth");
    }

    /// <summary>
    /// Checks that the ConfirmEmail method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallConfirmEmailAsync()
    {
        // Arrange
        var auth = _fixture.Create<IAuthorization>();

        // Act
        var result = await this._testClass.ConfirmEmail(auth);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ConfirmEmail method throws when the auth parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallConfirmEmailWithNullAuthAsync()
    {
        await FluentActions.Invoking(() => this._testClass.ConfirmEmail(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("auth");
    }

    /// <summary>
    /// Checks that the CompleteRegistration method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallCompleteRegistrationAsync()
    {
        // Arrange
        var auth = _fixture.Create<IAuthorization>();

        // Act
        var result = await this._testClass.CompleteRegistration(auth);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompleteRegistration method throws when the auth parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallCompleteRegistrationWithNullAuthAsync()
    {
        await FluentActions.Invoking(() => this._testClass.CompleteRegistration(default(IAuthorization))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("auth");
    }
}