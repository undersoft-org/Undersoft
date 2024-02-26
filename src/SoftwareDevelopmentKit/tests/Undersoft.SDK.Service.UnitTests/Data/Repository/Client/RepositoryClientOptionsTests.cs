using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Repository.Client;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository.Client;

/// <summary>
/// Unit tests for the type <see cref="RepositoryClientOptions"/>.
/// </summary>
public class RepositoryClientOptionsTests
{
    private RepositoryClientOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RepositoryClientOptions"/>.
    /// </summary>
    public RepositoryClientOptionsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RepositoryClientOptions>();
    }

    /// <summary>
    /// Checks that the ConnectionString property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetConnectionString()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ConnectionString = testValue;

        // Assert
        this._testClass.ConnectionString.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Host property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetHost()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Host = testValue;

        // Assert
        this._testClass.Host.Should().Be(testValue);
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
    /// Checks that the Pooling property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPooling()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.Pooling = testValue;

        // Assert
        this._testClass.Pooling.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the ClientProvider property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClientProvider()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ClientProvider = testValue;

        // Assert
        this._testClass.ClientProvider.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the PoolSize property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPoolSize()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.PoolSize = testValue;

        // Assert
        this._testClass.PoolSize.Should().Be(testValue);
    }
}