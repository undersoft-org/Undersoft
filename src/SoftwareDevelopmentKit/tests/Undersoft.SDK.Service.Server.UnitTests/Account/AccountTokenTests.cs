using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountToken"/>.
/// </summary>
[TestClass]
public class AccountTokenTests
{
    private AccountToken _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountToken"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountToken>();
    }

    /// <summary>
    /// Checks that the Id property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.Id = testValue;

        // Assert
        this._testClass.Id.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the TypeId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.TypeId = testValue;

        // Assert
        this._testClass.TypeId.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the AccountId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccountId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.AccountId = testValue;

        // Assert
        this._testClass.AccountId.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Account property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccount()
    {
        // Arrange
        var testValue = _fixture.Create<Account>();

        // Act
        this._testClass.Account = testValue;

        // Assert
        this._testClass.Account.Should().BeSameAs(testValue);
    }
}