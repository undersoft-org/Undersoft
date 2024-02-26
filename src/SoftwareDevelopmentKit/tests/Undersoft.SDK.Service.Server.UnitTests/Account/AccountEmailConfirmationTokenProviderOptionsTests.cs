using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountEmailConfirmationTokenProviderOptions"/>.
/// </summary>
[TestClass]
public class AccountEmailConfirmationTokenProviderOptionsTests
{
    private AccountEmailConfirmationTokenProviderOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountEmailConfirmationTokenProviderOptions"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountEmailConfirmationTokenProviderOptions>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccountEmailConfirmationTokenProviderOptions();

        // Assert
        instance.Should().NotBeNull();
    }
}