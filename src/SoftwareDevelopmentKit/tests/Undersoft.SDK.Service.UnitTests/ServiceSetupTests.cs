using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Data.Mapper;
using TProfile = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ServiceSetup"/>.
/// </summary>
public partial class ServiceSetupTests
{
    private class TestServiceSetup : ServiceSetup
    {
        public TestServiceSetup(IServiceCollection services) : base(services)
        {
        }

        public TestServiceSetup(IServiceCollection services, IConfiguration configuration) : base(services, configuration)
        {
        }

        public string PublicGetStoreRoutes(Type iface, string routePrefix)
        {
            return base.GetStoreRoutes(iface, routePrefix);
        }

        public IServiceConfiguration Publicconfiguration => base.configuration;

        public IServiceManager Publicmanager => base.manager;

        public IServiceRegistry Publicregistry => base.registry;

        public IServiceCollection Publicservices => base.services;
    }

    private TestServiceSetup _testClass;
    private IFixture _fixture;
    private Mock<IServiceCollection> _services;
    private Mock<IConfiguration> _configuration;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServiceSetup"/>.
    /// </summary>
    public ServiceSetupTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._services = _fixture.Freeze<Mock<IServiceCollection>>();
        this._configuration = _fixture.Freeze<Mock<IConfiguration>>();
        this._testClass = _fixture.Create<TestServiceSetup>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestServiceSetup(this._services.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestServiceSetup(this._services.Object, this._configuration.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServices()
    {
        FluentActions.Invoking(() => new TestServiceSetup(default(IServiceCollection))).Should().Throw<ArgumentNullException>().WithParameterName("services");
        FluentActions.Invoking(() => new TestServiceSetup(default(IServiceCollection), this._configuration.Object)).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that instance construction throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfiguration()
    {
        FluentActions.Invoking(() => new TestServiceSetup(this._services.Object, default(IConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }

    /// <summary>
    /// Checks that the AddCaching method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddCaching()
    {
        // Act
        var result = this._testClass.AddCaching();

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
    /// Checks that the AddJsonSerializerDefaults method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddJsonSerializerDefaults()
    {
        // Act
        this._testClass.AddJsonSerializerDefaults();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddLogging method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddLogging()
    {
        // Act
        var result = this._testClass.AddLogging();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddPropertyInjection method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddPropertyInjection()
    {
        // Act
        var result = this._testClass.AddPropertyInjection();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddImplementations method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddImplementations()
    {
        // Act
        var result = this._testClass.AddImplementations();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddMapper method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddMapperWithTProfile()
    {
        // Act
        var result = this._testClass.AddMapper<TProfile>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddMapper method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddMapperWithProfiles()
    {
        // Arrange
        var profiles = _fixture.Create<MapperProfile[]>();

        // Act
        var result = this._testClass.AddMapper(profiles);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddMapper method throws when the profiles parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddMapperWithProfilesWithNullProfiles()
    {
        FluentActions.Invoking(() => this._testClass.AddMapper(default(MapperProfile[]))).Should().Throw<ArgumentNullException>().WithParameterName("profiles");
    }

    /// <summary>
    /// Checks that the AddMapper method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddMapperWithMapper()
    {
        // Arrange
        var mapper = _fixture.Create<IDataMapper>();

        // Act
        var result = this._testClass.AddMapper(mapper);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddMapper method throws when the mapper parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddMapperWithMapperWithNullMapper()
    {
        FluentActions.Invoking(() => this._testClass.AddMapper(default(IDataMapper))).Should().Throw<ArgumentNullException>().WithParameterName("mapper");
    }

    /// <summary>
    /// Checks that the AddRepositoryClients method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRepositoryClientsWithNoParameters()
    {
        // Act
        var result = this._testClass.AddRepositoryClients();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRepositoryClients method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRepositoryClientsWithServiceTypes()
    {
        // Arrange
        var serviceTypes = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.AddRepositoryClients(serviceTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRepositoryClients method throws when the serviceTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRepositoryClientsWithServiceTypesWithNullServiceTypes()
    {
        FluentActions.Invoking(() => this._testClass.AddRepositoryClients(default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("serviceTypes");
    }

    /// <summary>
    /// Checks that the ConfigureServices method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigureServices()
    {
        // Arrange
        var clientTypes = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.ConfigureServices(clientTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MergeServices method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMergeServices()
    {
        // Act
        var result = this._testClass.MergeServices();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddStoreCache method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddStoreCacheWithTstore()
    {
        // Arrange
        var tstore = _fixture.Create<Type>();

        // Act
        var result = this._testClass.AddStoreCache(tstore);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddStoreCache method throws when the tstore parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddStoreCacheWithTstoreWithNullTstore()
    {
        FluentActions.Invoking(() => this._testClass.AddStoreCache(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("tstore");
    }

    /// <summary>
    /// Checks that the PublicGetStoreRoutes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetStoreRoutes()
    {
        // Arrange
        var iface = _fixture.Create<Type>();
        var routePrefix = _fixture.Create<string>();

        // Act
        var result = this._testClass.PublicGetStoreRoutes(iface, routePrefix);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicGetStoreRoutes method throws when the iface parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetStoreRoutesWithNullIface()
    {
        FluentActions.Invoking(() => this._testClass.PublicGetStoreRoutes(default(Type), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("iface");
    }

    /// <summary>
    /// Checks that the PublicGetStoreRoutes method throws when the routePrefix parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetStoreRoutesWithInvalidRoutePrefix(string value)
    {
        FluentActions.Invoking(() => this._testClass.PublicGetStoreRoutes(_fixture.Create<Type>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("routePrefix");
    }

    /// <summary>
    /// Checks that the Publicconfiguration property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicconfiguration()
    {
        // Assert
        this._testClass.Publicconfiguration.Should().BeAssignableTo<IServiceConfiguration>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Publicmanager property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicmanager()
    {
        // Assert
        this._testClass.Publicmanager.Should().BeAssignableTo<IServiceManager>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Publicregistry property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicregistry()
    {
        // Assert
        this._testClass.Publicregistry.Should().BeAssignableTo<IServiceRegistry>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Publicservices property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicservices()
    {
        // Assert
        this._testClass.Publicservices.Should().BeAssignableTo<IServiceCollection>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Manager property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetManager()
    {
        // Assert
        this._testClass.Manager.Should().BeAssignableTo<IServiceManager>();

        Assert.Fail("Create or modify test");
    }
}