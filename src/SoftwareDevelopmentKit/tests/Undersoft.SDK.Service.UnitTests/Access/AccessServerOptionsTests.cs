using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Access;

namespace Undersoft.SDK.Service.UnitTests.Access;

/// <summary>
/// Unit tests for the type <see cref="AccessServerOptions"/>.
/// </summary>
public class AccessServerOptionsTests
{
    private AccessServerOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccessServerOptions"/>.
    /// </summary>
    public AccessServerOptionsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccessServerOptions>();
    }

    /// <summary>
    /// Checks that the ServiceName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetServiceName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ServiceName = testValue;

        // Assert
        this._testClass.ServiceName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the ServiceVersion property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetServiceVersion()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ServiceVersion = testValue;

        // Assert
        this._testClass.ServiceVersion.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the ServerBaseUrl property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetServerBaseUrl()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ServerBaseUrl = testValue;

        // Assert
        this._testClass.ServerBaseUrl.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the ServiceBaseUrl property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetServiceBaseUrl()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ServiceBaseUrl = testValue;

        // Assert
        this._testClass.ServiceBaseUrl.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the ServiceClientId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetServiceClientId()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ServiceClientId = testValue;

        // Assert
        this._testClass.ServiceClientId.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the RequireHttpsMetadata property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRequireHttpsMetadata()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.RequireHttpsMetadata = testValue;

        // Assert
        this._testClass.RequireHttpsMetadata.Should().Be(testValue);
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
    /// Checks that the Scopes property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetScopes()
    {
        // Arrange
        var testValue = _fixture.Create<string[]>();

        // Act
        this._testClass.Scopes = testValue;

        // Assert
        this._testClass.Scopes.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Roles property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRoles()
    {
        // Arrange
        var testValue = _fixture.Create<string[]>();

        // Act
        this._testClass.Roles = testValue;

        // Assert
        this._testClass.Roles.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Claims property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClaims()
    {
        // Arrange
        var testValue = _fixture.Create<string[]>();

        // Act
        this._testClass.Claims = testValue;

        // Assert
        this._testClass.Claims.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the AdministrationRole property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAdministrationRole()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.AdministrationRole = testValue;

        // Assert
        this._testClass.AdministrationRole.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the CorsAllowAnyOrigin property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCorsAllowAnyOrigin()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.CorsAllowAnyOrigin = testValue;

        // Assert
        this._testClass.CorsAllowAnyOrigin.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the CorsAllowOrigins property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCorsAllowOrigins()
    {
        // Arrange
        var testValue = _fixture.Create<string[]>();

        // Act
        this._testClass.CorsAllowOrigins = testValue;

        // Assert
        this._testClass.CorsAllowOrigins.Should().BeSameAs(testValue);
    }
}