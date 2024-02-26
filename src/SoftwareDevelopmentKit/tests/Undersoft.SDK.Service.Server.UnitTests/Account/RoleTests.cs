using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="Role"/>.
/// </summary>
[TestClass]
public class RoleTests
{
    private Role _testClass;
    private IFixture _fixture;
    private string _roleName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Role"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._roleName = _fixture.Create<string>();
        this._testClass = _fixture.Create<Role>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Role();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Role(this._roleName);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the roleName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidRoleName(string value)
    {
        FluentActions.Invoking(() => new Role(value)).Should().Throw<ArgumentNullException>().WithParameterName("roleName");
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
    /// Checks that the Claims property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClaims()
    {
        // Arrange
        var testValue = _fixture.Create<Listing<RoleClaim>>();

        // Act
        this._testClass.Claims = testValue;

        // Assert
        this._testClass.Claims.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Accounts property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccounts()
    {
        // Arrange
        var testValue = _fixture.Create<Listing<Account>>();

        // Act
        this._testClass.Accounts = testValue;

        // Assert
        this._testClass.Accounts.Should().BeSameAs(testValue);
    }
}