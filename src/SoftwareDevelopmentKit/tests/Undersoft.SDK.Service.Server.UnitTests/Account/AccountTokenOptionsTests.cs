using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountTokenOptions"/>.
/// </summary>
[TestClass]
public class AccountTokenOptionsTests
{
    private AccountTokenOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountTokenOptions"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountTokenOptions>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccountTokenOptions();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the SecurityKey property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSecurityKey()
    {
        // Arrange
        var testValue = _fixture.Create<byte[]>();

        // Act
        this._testClass.SecurityKey = testValue;

        // Assert
        this._testClass.SecurityKey.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Issuer property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIssuer()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Issuer = testValue;

        // Assert
        this._testClass.Issuer.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Audience property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAudience()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Audience = testValue;

        // Assert
        this._testClass.Audience.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the MinutesToExpire property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMinutesToExpire()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.MinutesToExpire = testValue;

        // Assert
        this._testClass.MinutesToExpire.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Value property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetValue()
    {
        // Assert
        this._testClass.Value.Should().BeAssignableTo<AccountTokenOptions>();

        Assert.Fail("Create or modify test");
    }
}