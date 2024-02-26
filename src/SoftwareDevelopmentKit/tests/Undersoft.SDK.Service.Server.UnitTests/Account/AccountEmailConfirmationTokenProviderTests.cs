using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Server.Accounts;
using TUser = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountEmailConfirmationTokenProvider"/>.
/// </summary>
[TestClass]
public class AccountEmailConfirmationTokenProvider_1Tests
{
    private AccountEmailConfirmationTokenProvider<TUser> _testClass;
    private IFixture _fixture;
    private Mock<IDataProtectionProvider> _dataProtectionProvider;
    private Mock<IOptions<AccountEmailConfirmationTokenProviderOptions>> _options;
    private Mock<ILogger<DataProtectorTokenProvider<TUser>>> _logger;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountEmailConfirmationTokenProvider"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._dataProtectionProvider = _fixture.Freeze<Mock<IDataProtectionProvider>>();
        this._options = _fixture.Freeze<Mock<IOptions<AccountEmailConfirmationTokenProviderOptions>>>();
        this._logger = _fixture.Freeze<Mock<ILogger<DataProtectorTokenProvider<TUser>>>>();
        this._testClass = _fixture.Create<AccountEmailConfirmationTokenProvider<TUser>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccountEmailConfirmationTokenProvider<TUser>(this._dataProtectionProvider.Object, this._options.Object, this._logger.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the dataProtectionProvider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullDataProtectionProvider()
    {
        FluentActions.Invoking(() => new AccountEmailConfirmationTokenProvider<TUser>(default(IDataProtectionProvider), this._options.Object, this._logger.Object)).Should().Throw<ArgumentNullException>().WithParameterName("dataProtectionProvider");
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new AccountEmailConfirmationTokenProvider<TUser>(this._dataProtectionProvider.Object, default(IOptions<AccountEmailConfirmationTokenProviderOptions>), this._logger.Object)).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that instance construction throws when the logger parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullLogger()
    {
        FluentActions.Invoking(() => new AccountEmailConfirmationTokenProvider<TUser>(this._dataProtectionProvider.Object, this._options.Object, default(ILogger<DataProtectorTokenProvider<TUser>>))).Should().Throw<ArgumentNullException>().WithParameterName("logger");
    }
}