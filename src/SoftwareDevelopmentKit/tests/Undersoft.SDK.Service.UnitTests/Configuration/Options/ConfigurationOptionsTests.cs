using System;
using System.Reflection;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Configuration.Options;

namespace Undersoft.SDK.Service.UnitTests.Configuration.Options;

/// <summary>
/// Unit tests for the type <see cref="ConfigurationOptions"/>.
/// </summary>
public class ConfigurationOptionsTests
{
    private ConfigurationOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ConfigurationOptions"/>.
    /// </summary>
    public ConfigurationOptionsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<ConfigurationOptions>();
    }

    /// <summary>
    /// Checks that the BasePath property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBasePath()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.BasePath = testValue;

        // Assert
        this._testClass.BasePath.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the CommandLineArgs property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCommandLineArgs()
    {
        // Arrange
        var testValue = _fixture.Create<string[]>();

        // Act
        this._testClass.CommandLineArgs = testValue;

        // Assert
        this._testClass.CommandLineArgs.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the EnvironmentName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEnvironmentName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.EnvironmentName = testValue;

        // Assert
        this._testClass.EnvironmentName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the EnvironmentVariablesPrefix property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEnvironmentVariablesPrefix()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.EnvironmentVariablesPrefix = testValue;

        // Assert
        this._testClass.EnvironmentVariablesPrefix.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the GeneralFileName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetGeneralFileName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.GeneralFileName = testValue;

        // Assert
        this._testClass.GeneralFileName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the OptionalFileNames property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOptionalFileNames()
    {
        // Arrange
        var testValue = _fixture.Create<string[]>();

        // Act
        this._testClass.OptionalFileNames = testValue;

        // Assert
        this._testClass.OptionalFileNames.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the UserSecretsAssembly property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUserSecretsAssembly()
    {
        // Arrange
        var testValue = _fixture.Create<Assembly>();

        // Act
        this._testClass.UserSecretsAssembly = testValue;

        // Assert
        this._testClass.UserSecretsAssembly.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the UserSecretsId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUserSecretsId()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.UserSecretsId = testValue;

        // Assert
        this._testClass.UserSecretsId.Should().Be(testValue);
    }
}