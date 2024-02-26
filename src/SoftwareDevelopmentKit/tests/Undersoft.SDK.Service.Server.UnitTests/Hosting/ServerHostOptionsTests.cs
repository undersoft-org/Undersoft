using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Hosting;

namespace Undersoft.SDK.Service.Server.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="ServerHostOptions"/>.
/// </summary>
[TestClass]
public class ServerHostOptionsTests
{
    private ServerHostOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServerHostOptions"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<ServerHostOptions>();
    }

    /// <summary>
    /// Checks that the ServerName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetServerName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ServerName = testValue;

        // Assert
        this._testClass.ServerName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Host property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetHost()
    {
        // Arrange
        var testValue = _fixture.Create<IHost>();

        // Act
        this._testClass.Host = testValue;

        // Assert
        this._testClass.Host.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the HostName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetHostName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.HostName = testValue;

        // Assert
        this._testClass.HostName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Port property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPort()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.Port = testValue;

        // Assert
        this._testClass.Port.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Route property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRoute()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Route = testValue;

        // Assert
        this._testClass.Route.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the TenantId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTenantId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.TenantId = testValue;

        // Assert
        this._testClass.TenantId.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the TenantName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTenantName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.TenantName = testValue;

        // Assert
        this._testClass.TenantName.Should().Be(testValue);
    }
}