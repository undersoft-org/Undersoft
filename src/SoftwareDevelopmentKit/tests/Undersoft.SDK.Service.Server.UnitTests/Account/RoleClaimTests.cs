using System;
using System.Security.Claims;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="RoleClaim"/>.
/// </summary>
[TestClass]
public class RoleClaimTests
{
    private RoleClaim _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RoleClaim"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RoleClaim>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RoleClaim();

        // Assert
        instance.Should().NotBeNull();
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
    /// Checks that the AccountRoleId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccountRoleId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.AccountRoleId = testValue;

        // Assert
        this._testClass.AccountRoleId.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Role property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRole()
    {
        // Arrange
        var testValue = _fixture.Create<Role>();

        // Act
        this._testClass.Role = testValue;

        // Assert
        this._testClass.Role.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Claim property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClaim()
    {
        // Arrange
        var testValue = _fixture.Create<Claim>();

        // Act
        this._testClass.Claim = testValue;

        // Assert
        this._testClass.Claim.Should().BeSameAs(testValue);
    }
}