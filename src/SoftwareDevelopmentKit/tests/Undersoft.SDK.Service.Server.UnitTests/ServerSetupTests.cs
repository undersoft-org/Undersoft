using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Server;
using TContext = System.String;
using TServiceStore = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ServerSetup"/>.
/// </summary>
[TestClass]
public partial class ServerSetupTests
{
    private ServerSetup _testClass;
    private IFixture _fixture;
    private Mock<IServiceCollection> _services;
    private Mock<IMvcBuilder> _mvcBuilder;
    private Mock<IConfiguration> _configuration;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServerSetup"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._services = _fixture.Freeze<Mock<IServiceCollection>>();
        this._mvcBuilder = _fixture.Freeze<Mock<IMvcBuilder>>();
        this._configuration = _fixture.Freeze<Mock<IConfiguration>>();
        this._testClass = _fixture.Create<ServerSetup>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ServerSetup(this._services.Object, this._mvcBuilder.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ServerSetup(this._services.Object, this._configuration.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServices()
    {
        FluentActions.Invoking(() => new ServerSetup(default(IServiceCollection), this._mvcBuilder.Object)).Should().Throw<ArgumentNullException>().WithParameterName("services");
        FluentActions.Invoking(() => new ServerSetup(default(IServiceCollection), this._configuration.Object)).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that instance construction throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfiguration()
    {
        FluentActions.Invoking(() => new ServerSetup(this._services.Object, default(IConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }

    /// <summary>
    /// Checks that the AddDataServer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddDataServer()
    {
        // Arrange
        var dataServerTypes = _fixture.Create<DataServerTypes>();
        Action<DataServerBuilder> builder = x => { };

        // Act
        var result = this._testClass.AddDataServer<TServiceStore>(dataServerTypes, builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddSourceProviderConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddSourceProviderConfiguration()
    {
        // Act
        var result = this._testClass.AddSourceProviderConfiguration();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddHealthChecks method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddHealthChecks()
    {
        // Act
        var result = this._testClass.AddHealthChecks();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddOpenTelemetry method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddOpenTelemetry()
    {
        // Act
        var result = this._testClass.AddOpenTelemetry();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddAccessServer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddAccessServer()
    {
        // Act
        var result = this._testClass.AddAccessServer<TContext>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddAuthentication method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddAuthentication()
    {
        // Act
        var result = this._testClass.AddAuthentication();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddAuthorization method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddAuthorization()
    {
        // Act
        var result = this._testClass.AddAuthorization();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddSwagger method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddSwagger()
    {
        // Act
        var result = this._testClass.AddSwagger();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRepositorySources method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRepositorySourcesWithNoParameters()
    {
        // Act
        var result = this._testClass.AddRepositorySources();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRepositorySources method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRepositorySourcesWithStoreTypes()
    {
        // Arrange
        var storeTypes = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.AddRepositorySources(storeTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRepositorySources method throws when the storeTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRepositorySourcesWithStoreTypesWithNullStoreTypes()
    {
        FluentActions.Invoking(() => this._testClass.AddRepositorySources(default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("storeTypes");
    }

    /// <summary>
    /// Checks that the AddApiVersions method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddApiVersions()
    {
        // Arrange
        var apiVersions = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.AddApiVersions(apiVersions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddApiVersions method throws when the apiVersions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddApiVersionsWithNullApiVersions()
    {
        FluentActions.Invoking(() => this._testClass.AddApiVersions(default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("apiVersions");
    }

    /// <summary>
    /// Checks that the ConfigureServer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigureServer()
    {
        // Arrange
        var includeSwagger = _fixture.Create<bool>();
        var sourceTypes = _fixture.Create<Type[]>();
        var clientTypes = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.ConfigureServer(includeSwagger, sourceTypes, clientTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseServiceClients method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseServiceClients()
    {
        // Act
        var result = this._testClass.UseServiceClients();

        // Assert
        Assert.Fail("Create or modify test");
    }
}