using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountRegistrationConfirmationTokenProviderOptions"/>.
/// </summary>
[TestClass]
public class AccountRegistrationConfirmationTokenProviderOptionsTests
{
    private AccountRegistrationConfirmationTokenProviderOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountRegistrationConfirmationTokenProviderOptions"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountRegistrationConfirmationTokenProviderOptions>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccountRegistrationConfirmationTokenProviderOptions();

        // Assert
        instance.Should().NotBeNull();
    }
}