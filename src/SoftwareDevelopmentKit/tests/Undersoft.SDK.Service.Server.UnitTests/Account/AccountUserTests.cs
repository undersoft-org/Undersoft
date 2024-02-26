using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountUser"/>.
/// </summary>
[TestClass]
public class AccountUserTests
{
    private AccountUser _testClass;
    private IFixture _fixture;
    private string _email;
    private string _userName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountUser"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._email = _fixture.Create<string>();
        this._userName = _fixture.Create<string>();
        this._testClass = _fixture.Create<AccountUser>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccountUser();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new AccountUser(this._email);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new AccountUser(this._userName, this._email);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the email parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidEmail(string value)
    {
        FluentActions.Invoking(() => new AccountUser(value)).Should().Throw<ArgumentNullException>().WithParameterName("email");
        FluentActions.Invoking(() => new AccountUser(this._userName, value)).Should().Throw<ArgumentNullException>().WithParameterName("email");
    }

    /// <summary>
    /// Checks that the constructor throws when the userName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidUserName(string value)
    {
        FluentActions.Invoking(() => new AccountUser(value, this._email)).Should().Throw<ArgumentNullException>().WithParameterName("userName");
    }

    /// <summary>
    /// Checks that the RegistrationCompleted property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRegistrationCompleted()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.RegistrationCompleted = testValue;

        // Assert
        this._testClass.RegistrationCompleted.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the IsLockedOut property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsLockedOut()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.IsLockedOut = testValue;

        // Assert
        this._testClass.IsLockedOut.Should().Be(testValue);
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