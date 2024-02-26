using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountCredentials"/>.
/// </summary>
[TestClass]
public class AccountCredentialsTests
{
    private AccountCredentials _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountCredentials"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountCredentials>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccountCredentials();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the MapUser method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapUser()
    {
        // Arrange
        var account = _fixture.Create<IdentityUser<long>>();

        // Act
        this._testClass.MapUser(account);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapUser method throws when the account parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapUserWithNullAccount()
    {
        FluentActions.Invoking(() => this._testClass.MapUser(default(IdentityUser<long>))).Should().Throw<ArgumentNullException>().WithParameterName("account");
    }
}