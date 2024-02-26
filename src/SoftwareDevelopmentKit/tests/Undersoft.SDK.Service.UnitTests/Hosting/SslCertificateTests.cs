using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Hosting;

namespace Undersoft.SDK.Service.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="SslCertificate"/>.
/// </summary>
public class SslCertificateTests
{
    private SslCertificate _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SslCertificate"/>.
    /// </summary>
    public SslCertificateTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<SslCertificate>();
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
    /// Checks that the Protocols property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProtocols()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Protocols = testValue;

        // Assert
        this._testClass.Protocols.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Path property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPath()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Path = testValue;

        // Assert
        this._testClass.Path.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the KeyPath property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetKeyPath()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.KeyPath = testValue;

        // Assert
        this._testClass.KeyPath.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Password property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPassword()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Password = testValue;

        // Assert
        this._testClass.Password.Should().Be(testValue);
    }
}