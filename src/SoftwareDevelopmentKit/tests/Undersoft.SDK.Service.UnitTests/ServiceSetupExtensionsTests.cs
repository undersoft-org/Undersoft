using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service;

namespace Undersoft.SDK.Service.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ServiceSetupExtensions"/>.
/// </summary>
public class ServiceSetupExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the AddServiceSetup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddServiceSetupWithServices()
    {
        // Arrange
        var services = _fixture.Create<IServiceCollection>();

        // Act
        var result = services.AddServiceSetup();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddServiceSetup method throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddServiceSetupWithServicesWithNullServices()
    {
        FluentActions.Invoking(() => default(IServiceCollection).AddServiceSetup()).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that the AddServiceSetup maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void AddServiceSetupWithServicesPerformsMapping()
    {
        // Arrange
        var services = _fixture.Create<IServiceCollection>();

        // Act
        var result = services.AddServiceSetup();

        // Assert
        result.Services.Should().BeSameAs(services);
    }

    /// <summary>
    /// Checks that the AddServiceSetup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddServiceSetupWithServicesAndConfiguration()
    {
        // Arrange
        var services = _fixture.Create<IServiceCollection>();
        var configuration = _fixture.Create<IConfiguration>();

        // Act
        var result = services.AddServiceSetup(configuration);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddServiceSetup method throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddServiceSetupWithServicesAndConfigurationWithNullServices()
    {
        FluentActions.Invoking(() => default(IServiceCollection).AddServiceSetup(_fixture.Create<IConfiguration>())).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that the AddServiceSetup method throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddServiceSetupWithServicesAndConfigurationWithNullConfiguration()
    {
        FluentActions.Invoking(() => _fixture.Create<IServiceCollection>().AddServiceSetup(default(IConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }

    /// <summary>
    /// Checks that the AddServiceSetup maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void AddServiceSetupWithServicesAndConfigurationPerformsMapping()
    {
        // Arrange
        var services = _fixture.Create<IServiceCollection>();
        var configuration = _fixture.Create<IConfiguration>();

        // Act
        var result = services.AddServiceSetup(configuration);

        // Assert
        result.Services.Should().BeSameAs(services);
    }
}