using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Repository.Source;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository.Source;

/// <summary>
/// Unit tests for the type <see cref="RepositorySourceOptions"/>.
/// </summary>
public class RepositorySourceOptionsTests
{
    private RepositorySourceOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RepositorySourceOptions"/>.
    /// </summary>
    public RepositorySourceOptionsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RepositorySourceOptions>();
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
    /// Checks that the UserId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUserId()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.UserId = testValue;

        // Assert
        this._testClass.UserId.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Database property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDatabase()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Database = testValue;

        // Assert
        this._testClass.Database.Should().Be(testValue);
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
    /// Checks that the SourceProvider property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSourceProvider()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.SourceProvider = testValue;

        // Assert
        this._testClass.SourceProvider.Should().Be(testValue);
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