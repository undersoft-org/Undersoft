using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Hosting;

namespace Undersoft.SDK.Service.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="ServiceHostSetup"/>.
/// </summary>
public partial class ServiceHostSetupTests
{
    private ServiceHostSetup _testClass;
    private IFixture _fixture;
    private Mock<IHostBuilder> _host;
    private Mock<IServiceManager> _manager;
    private Mock<IHostEnvironment> _environment;
    private bool _useSwagger;
    private string[] _apiVersions;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServiceHostSetup"/>.
    /// </summary>
    public ServiceHostSetupTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._host = _fixture.Freeze<Mock<IHostBuilder>>();
        this._manager = _fixture.Freeze<Mock<IServiceManager>>();
        this._environment = _fixture.Freeze<Mock<IHostEnvironment>>();
        this._useSwagger = _fixture.Create<bool>();
        this._apiVersions = _fixture.Create<string[]>();
        this._testClass = _fixture.Create<ServiceHostSetup>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ServiceHostSetup(this._host.Object, this._manager.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ServiceHostSetup(this._host.Object, this._manager.Object, this._environment.Object, this._useSwagger);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ServiceHostSetup(this._host.Object, this._manager.Object, this._environment.Object, this._apiVersions);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the host parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullHost()
    {
        FluentActions.Invoking(() => new ServiceHostSetup(default(IHostBuilder), this._manager.Object)).Should().Throw<ArgumentNullException>().WithParameterName("host");
        FluentActions.Invoking(() => new ServiceHostSetup(default(IHostBuilder), this._manager.Object, this._environment.Object, this._useSwagger)).Should().Throw<ArgumentNullException>().WithParameterName("host");
        FluentActions.Invoking(() => new ServiceHostSetup(default(IHostBuilder), this._manager.Object, this._environment.Object, this._apiVersions)).Should().Throw<ArgumentNullException>().WithParameterName("host");
    }

    /// <summary>
    /// Checks that instance construction throws when the manager parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullManager()
    {
        FluentActions.Invoking(() => new ServiceHostSetup(this._host.Object, default(IServiceManager))).Should().Throw<ArgumentNullException>().WithParameterName("manager");
        FluentActions.Invoking(() => new ServiceHostSetup(this._host.Object, default(IServiceManager), this._environment.Object, this._useSwagger)).Should().Throw<ArgumentNullException>().WithParameterName("manager");
        FluentActions.Invoking(() => new ServiceHostSetup(this._host.Object, default(IServiceManager), this._environment.Object, this._apiVersions)).Should().Throw<ArgumentNullException>().WithParameterName("manager");
    }

    /// <summary>
    /// Checks that instance construction throws when the environment parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEnvironment()
    {
        FluentActions.Invoking(() => new ServiceHostSetup(this._host.Object, this._manager.Object, default(IHostEnvironment), this._useSwagger)).Should().Throw<ArgumentNullException>().WithParameterName("environment");
        FluentActions.Invoking(() => new ServiceHostSetup(this._host.Object, this._manager.Object, default(IHostEnvironment), this._apiVersions)).Should().Throw<ArgumentNullException>().WithParameterName("environment");
    }

    /// <summary>
    /// Checks that the RebuildProviders method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRebuildProviders()
    {
        // Arrange
        _host.Setup(mock => mock.UseServiceProviderFactory<IServiceCollection>(It.IsAny<IServiceProviderFactory<IServiceCollection>>())).Returns(_fixture.Create<IHostBuilder>());
        _manager.Setup(mock => mock.GetProviderFactory()).Returns(_fixture.Create<IServiceProviderFactory<IServiceCollection>>());

        // Act
        var result = this._testClass.RebuildProviders();

        // Assert
        _host.Verify(mock => mock.UseServiceProviderFactory<IServiceCollection>(It.IsAny<IServiceProviderFactory<IServiceCollection>>()));
        _manager.Verify(mock => mock.GetProviderFactory());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseDataServices method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseDataServices()
    {
        // Act
        var result = this._testClass.UseDataServices();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseDataMigrations method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseDataMigrations()
    {
        // Arrange
        _manager.Setup(mock => mock.CreateScope()).Returns(_fixture.Create<IServiceScope>());

        // Act
        var result = this._testClass.UseDataMigrations();

        // Assert
        _manager.Verify(mock => mock.CreateScope());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseInternalProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseInternalProvider()
    {
        // Arrange
        _host.Setup(mock => mock.UseServiceProviderFactory<IServiceCollection>(It.IsAny<IServiceProviderFactory<IServiceCollection>>())).Returns(_fixture.Create<IHostBuilder>());
        _manager.Setup(mock => mock.GetProviderFactory()).Returns(_fixture.Create<IServiceProviderFactory<IServiceCollection>>());
        _manager.Setup(mock => mock.Registry).Returns(_fixture.Create<IServiceRegistry>());

        // Act
        var result = this._testClass.UseInternalProvider();

        // Assert
        _host.Verify(mock => mock.UseServiceProviderFactory<IServiceCollection>(It.IsAny<IServiceProviderFactory<IServiceCollection>>()));
        _manager.Verify(mock => mock.GetProviderFactory());

        Assert.Fail("Create or modify test");
    }
}