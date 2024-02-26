using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob.Container;
using TContainer = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob.Container;

/// <summary>
/// Unit tests for the type <see cref="BlobContainerConfigurations"/>.
/// </summary>
public class BlobContainerConfigurationsTests
{
    private BlobContainerConfigurations _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BlobContainerConfigurations"/>.
    /// </summary>
    public BlobContainerConfigurationsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<BlobContainerConfigurations>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new BlobContainerConfigurations();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigureWithTContainerAndActionOfBlobContainerConfiguration()
    {
        // Arrange
        Action<BlobContainerConfiguration> configureAction = x => { };

        // Act
        var result = this._testClass.Configure<TContainer>(configureAction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the configureAction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithTContainerAndActionOfBlobContainerConfigurationWithNullConfigureAction()
    {
        FluentActions.Invoking(() => this._testClass.Configure<TContainer>(default(Action<BlobContainerConfiguration>))).Should().Throw<ArgumentNullException>().WithParameterName("configureAction");
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigureWithNameAndConfigureAction()
    {
        // Arrange
        var name = _fixture.Create<string>();
        Action<BlobContainerConfiguration> configureAction = x => { };

        // Act
        var result = this._testClass.Configure(name, configureAction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the configureAction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithNameAndConfigureActionWithNullConfigureAction()
    {
        FluentActions.Invoking(() => this._testClass.Configure(_fixture.Create<string>(), default(Action<BlobContainerConfiguration>))).Should().Throw<ArgumentNullException>().WithParameterName("configureAction");
    }

    /// <summary>
    /// Checks that the Configure method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallConfigureWithNameAndConfigureActionWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Configure(value, x => { })).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ConfigureDefault method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigureDefault()
    {
        // Arrange
        Action<BlobContainerConfiguration> configureAction = x => { };

        // Act
        var result = this._testClass.ConfigureDefault(configureAction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ConfigureDefault method throws when the configureAction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureDefaultWithNullConfigureAction()
    {
        FluentActions.Invoking(() => this._testClass.ConfigureDefault(default(Action<BlobContainerConfiguration>))).Should().Throw<ArgumentNullException>().WithParameterName("configureAction");
    }

    /// <summary>
    /// Checks that the ConfigureAll method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigureAll()
    {
        // Arrange
        Action<long, BlobContainerConfiguration> configureAction = (x, y) => { };

        // Act
        var result = this._testClass.ConfigureAll(configureAction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ConfigureAll method throws when the configureAction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureAllWithNullConfigureAction()
    {
        FluentActions.Invoking(() => this._testClass.ConfigureAll(default(Action<long, BlobContainerConfiguration>))).Should().Throw<ArgumentNullException>().WithParameterName("configureAction");
    }

    /// <summary>
    /// Checks that the GetConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetConfigurationWithNoParameters()
    {
        // Act
        var result = this._testClass.GetConfiguration<TContainer>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetConfigurationWithName()
    {
        // Arrange
        var name = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetConfiguration(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetConfiguration method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetConfigurationWithNameWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetConfiguration(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }
}