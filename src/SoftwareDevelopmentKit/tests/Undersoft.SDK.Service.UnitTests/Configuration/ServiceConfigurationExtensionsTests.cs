using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Configuration;

namespace Undersoft.SDK.Service.UnitTests.Configuration;

/// <summary>
/// Unit tests for the type <see cref="ServiceConfigurationExtensions"/>.
/// </summary>
public class ServiceConfigurationExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the BuildConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuildConfigurationWithConfig()
    {
        // Arrange
        var config = _fixture.Create<IConfiguration>();

        // Act
        var result = config.BuildConfiguration();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BuildConfiguration method throws when the config parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBuildConfigurationWithConfigWithNullConfig()
    {
        FluentActions.Invoking(() => default(IConfiguration).BuildConfiguration()).Should().Throw<ArgumentNullException>().WithParameterName("config");
    }

    /// <summary>
    /// Checks that the BuildConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuildConfigurationWithConfigAndServices()
    {
        // Arrange
        var config = _fixture.Create<IConfiguration>();
        var services = _fixture.Create<IServiceCollection>();

        // Act
        var result = config.BuildConfiguration(services
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BuildConfiguration method throws when the config parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBuildConfigurationWithConfigAndServicesWithNullConfig()
    {
        FluentActions.Invoking(() => default(IConfiguration).BuildConfiguration(_fixture.Create<IServiceCollection>())).Should().Throw<ArgumentNullException>().WithParameterName("config");
    }

    /// <summary>
    /// Checks that the BuildConfiguration method throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBuildConfigurationWithConfigAndServicesWithNullServices()
    {
        FluentActions.Invoking(() => _fixture.Create<IConfiguration>().BuildConfiguration(default(IServiceCollection))).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that the ReplaceConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReplaceConfiguration()
    {
        // Arrange
        var services = _fixture.Create<IServiceCollection>();
        var configuration = _fixture.Create<IConfiguration>();

        // Act
        var result = services.ReplaceConfiguration(configuration);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReplaceConfiguration method throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReplaceConfigurationWithNullServices()
    {
        FluentActions.Invoking(() => default(IServiceCollection).ReplaceConfiguration(_fixture.Create<IConfiguration>())).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that the ReplaceConfiguration method throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReplaceConfigurationWithNullConfiguration()
    {
        FluentActions.Invoking(() => _fixture.Create<IServiceCollection>().ReplaceConfiguration(default(IConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }

    /// <summary>
    /// Checks that the GetConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetConfiguration()
    {
        // Arrange
        var services = _fixture.Create<IServiceRegistry>();

        // Act
        var result = services.GetConfiguration();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetConfiguration method throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetConfigurationWithNullServices()
    {
        FluentActions.Invoking(() => default(IServiceRegistry).GetConfiguration()).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that the OnRegistred method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOnRegistred()
    {
        // Arrange
        var services = _fixture.Create<IServiceRegistry>();
        Action<IOnServiceRegistredContext> registrationAction = x => { };

        // Act
        services.OnRegistred(registrationAction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the OnRegistred method throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnRegistredWithNullServices()
    {
        FluentActions.Invoking(() => default(IServiceRegistry).OnRegistred(x => { })).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that the OnRegistred method throws when the registrationAction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnRegistredWithNullRegistrationAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IServiceRegistry>().OnRegistred(default(Action<IOnServiceRegistredContext>))).Should().Throw<ArgumentNullException>().WithParameterName("registrationAction");
    }

    /// <summary>
    /// Checks that the GetRegistrationActionList method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRegistrationActionList()
    {
        // Arrange
        var services = _fixture.Create<IServiceRegistry>();

        // Act
        var result = services.GetRegistrationActionList();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRegistrationActionList method throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRegistrationActionListWithNullServices()
    {
        FluentActions.Invoking(() => default(IServiceRegistry).GetRegistrationActionList()).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }
}

/// <summary>
/// Unit tests for the type <see cref="ServiceRegistrationActionList"/>.
/// </summary>
public class ServiceRegistrationActionListTests
{
    private ServiceRegistrationActionList _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServiceRegistrationActionList"/>.
    /// </summary>
    public ServiceRegistrationActionListTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<ServiceRegistrationActionList>();
    }

    /// <summary>
    /// Checks that the IsClassInterceptorsDisabled property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsClassInterceptorsDisabled()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.IsClassInterceptorsDisabled = testValue;

        // Assert
        this._testClass.IsClassInterceptorsDisabled.Should().Be(testValue);
    }
}