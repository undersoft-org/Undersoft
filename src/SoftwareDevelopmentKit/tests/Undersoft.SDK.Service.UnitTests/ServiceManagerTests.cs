using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Configuration;
using T = System.String;

namespace Undersoft.SDK.Service.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ServiceManager"/>.
/// </summary>
public class ServiceManagerTests
{
    private class TestServiceManager : ServiceManager
    {
        public TestServiceManager() : base()
        {
        }

        public TestServiceManager(IServiceManager serviceManager) : base(serviceManager)
        {
        }

        public TestServiceManager(IServiceCollection services) : base(services)
        {
        }

        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

    private TestServiceManager _testClass;
    private IFixture _fixture;
    private Mock<IServiceManager> _serviceManager;
    private Mock<IServiceCollection> _services;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServiceManager"/>.
    /// </summary>
    public ServiceManagerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._serviceManager = _fixture.Freeze<Mock<IServiceManager>>();
        this._services = _fixture.Freeze<Mock<IServiceCollection>>();
        this._testClass = _fixture.Create<TestServiceManager>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestServiceManager();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestServiceManager(this._serviceManager.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestServiceManager(this._services.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceManager parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceManager()
    {
        FluentActions.Invoking(() => new TestServiceManager(default(IServiceManager))).Should().Throw<ArgumentNullException>().WithParameterName("serviceManager");
    }

    /// <summary>
    /// Checks that instance construction throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServices()
    {
        FluentActions.Invoking(() => new TestServiceManager(default(IServiceCollection))).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that the BuildServiceProviderFactory method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuildServiceProviderFactory()
    {
        // Arrange
        var registry = _fixture.Create<IServiceRegistry>();

        _serviceManager.Setup(mock => mock.Services).Returns(_fixture.Create<IServiceCollection>());
        _services.Setup(mock => mock.Services).Returns(_fixture.Create<IServiceCollection>());

        // Act
        var result = this._testClass.BuildServiceProviderFactory(registry);

        // Assert
        _serviceManager.Verify(mock => mock.MergeServices(It.IsAny<bool>()));
        _services.Verify(mock => mock.MergeServices(It.IsAny<bool>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BuildServiceProviderFactory method throws when the registry parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBuildServiceProviderFactoryWithNullRegistry()
    {
        FluentActions.Invoking(() => this._testClass.BuildServiceProviderFactory(default(IServiceRegistry))).Should().Throw<ArgumentNullException>().WithParameterName("registry");
    }

    /// <summary>
    /// Checks that the GetRootService method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRootServiceWithT()
    {
        // Act
        var result = this._testClass.GetRootService<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRootServices method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRootServices()
    {
        // Act
        var result = this._testClass.GetRootServices<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRequiredRootService method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRequiredRootService()
    {
        // Act
        var result = this._testClass.GetRequiredRootService<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRootService method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRootServiceWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetRootService(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRootService method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRootServiceWithTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.GetRootService(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetService method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetServiceWithT()
    {
        // Act
        var result = this._testClass.GetService<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetServices method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetServicesWithT()
    {
        // Act
        var result = this._testClass.GetServices<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRequiredService method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRequiredServiceWithT()
    {
        // Act
        var result = this._testClass.GetRequiredService<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetService method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetServiceWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetService(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetService method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetServiceWithTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.GetService(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetServices method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetServicesWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetServices(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetServices method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetServicesWithTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.GetServices(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetRequiredServiceLazy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRequiredServiceLazy()
    {
        // Act
        var result = this._testClass.GetRequiredServiceLazy<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetServiceLazy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetServiceLazy()
    {
        // Act
        var result = this._testClass.GetServiceLazy<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetServicesLazy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetServicesLazy()
    {
        // Act
        var result = this._testClass.GetServicesLazy<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSingleton method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSingletonWithT()
    {
        // Act
        var result = this._testClass.GetSingleton<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSingleton method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSingletonWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        _serviceManager.Setup(mock => mock.GetObject(It.IsAny<Type>())).Returns(_fixture.Create<object>());
        _services.Setup(mock => mock.GetObject(It.IsAny<Type>())).Returns(_fixture.Create<object>());

        // Act
        var result = this._testClass.GetSingleton(type);

        // Assert
        _serviceManager.Verify(mock => mock.GetObject(It.IsAny<Type>()));
        _services.Verify(mock => mock.GetObject(It.IsAny<Type>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSingleton method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetSingletonWithTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.GetSingleton(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetRequiredService method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRequiredServiceWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetRequiredService(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRequiredService method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRequiredServiceWithTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.GetRequiredService(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the InitializeRootService method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInitializeRootService()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.InitializeRootService<T>(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InitializeRootService method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInitializeRootServiceWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.InitializeRootService<T>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the EnsureGetRootService method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEnsureGetRootService()
    {
        // Act
        var result = this._testClass.EnsureGetRootService<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetProvider()
    {
        // Arrange
        var serviceProvider = _fixture.Create<IServiceProvider>();

        // Act
        TestServiceManager.SetProvider(serviceProvider);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetProvider method throws when the serviceProvider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetProviderWithNullServiceProvider()
    {
        FluentActions.Invoking(() => TestServiceManager.SetProvider(default(IServiceProvider))).Should().Throw<ArgumentNullException>().WithParameterName("serviceProvider");
    }

    /// <summary>
    /// Checks that the ReplaceProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReplaceProvider()
    {
        // Arrange
        var serviceProvider = _fixture.Create<IServiceProvider>();

        _serviceManager.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());
        _services.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());

        // Act
        var result = this._testClass.ReplaceProvider(serviceProvider);

        // Assert
        _serviceManager.Verify(mock => mock.GetProvider());
        _services.Verify(mock => mock.GetProvider());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReplaceProvider method throws when the serviceProvider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReplaceProviderWithNullServiceProvider()
    {
        FluentActions.Invoking(() => this._testClass.ReplaceProvider(default(IServiceProvider))).Should().Throw<ArgumentNullException>().WithParameterName("serviceProvider");
    }

    /// <summary>
    /// Checks that the BuildInternalProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuildInternalProvider()
    {
        // Arrange
        var withPropertyInjection = _fixture.Create<bool>();

        _serviceManager.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());
        _services.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());

        // Act
        var result = this._testClass.BuildInternalProvider(withPropertyInjection);

        // Assert
        _serviceManager.Verify(mock => mock.GetProvider());
        _services.Verify(mock => mock.GetProvider());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BuildInternalRootProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuildInternalRootProvider()
    {
        // Arrange
        var withPropertyInjection = _fixture.Create<bool>();

        // Act
        var result = TestServiceManager.BuildInternalRootProvider(withPropertyInjection);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRootProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRootProvider()
    {
        // Act
        var result = TestServiceManager.GetRootProvider();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddPropertyInjection method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddPropertyInjection()
    {
        // Arrange
        _serviceManager.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());
        _services.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());

        // Act
        var result = this._testClass.AddPropertyInjection();

        // Assert
        _serviceManager.Verify(mock => mock.GetProvider());
        _services.Verify(mock => mock.GetProvider());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetProvider()
    {
        // Arrange
        _serviceManager.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());
        _services.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());

        // Act
        var result = this._testClass.GetProvider();

        // Assert
        _serviceManager.Verify(mock => mock.GetProvider());
        _services.Verify(mock => mock.GetProvider());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetProviderFactory method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetProviderFactory()
    {
        // Act
        var result = this._testClass.GetProviderFactory();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateProviderFromFacotry method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateProviderFromFacotry()
    {
        // Act
        var result = this._testClass.CreateProviderFromFacotry();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRootProviderFactory method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRootProviderFactory()
    {
        // Act
        var result = TestServiceManager.GetRootProviderFactory();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateFactory method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateFactoryWithConstrTypes()
    {
        // Arrange
        var constrTypes = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.CreateFactory<T>(constrTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateFactory method throws when the constrTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateFactoryWithConstrTypesWithNullConstrTypes()
    {
        FluentActions.Invoking(() => this._testClass.CreateFactory<T>(default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("constrTypes");
    }

    /// <summary>
    /// Checks that the CreateFactory method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateFactoryWithInstanceTypeAndConstrTypes()
    {
        // Arrange
        var instanceType = _fixture.Create<Type>();
        var constrTypes = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.CreateFactory(instanceType, constrTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateFactory method throws when the instanceType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateFactoryWithInstanceTypeAndConstrTypesWithNullInstanceType()
    {
        FluentActions.Invoking(() => this._testClass.CreateFactory(default(Type), _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("instanceType");
    }

    /// <summary>
    /// Checks that the CreateFactory method throws when the constrTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateFactoryWithInstanceTypeAndConstrTypesWithNullConstrTypes()
    {
        FluentActions.Invoking(() => this._testClass.CreateFactory(_fixture.Create<Type>(), default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("constrTypes");
    }

    /// <summary>
    /// Checks that the Initialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInitializeWithBesidesInjectedArguments()
    {
        // Arrange
        var besidesInjectedArguments = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Initialize<T>(besidesInjectedArguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Initialize method throws when the besidesInjectedArguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInitializeWithBesidesInjectedArgumentsWithNullBesidesInjectedArguments()
    {
        FluentActions.Invoking(() => this._testClass.Initialize<T>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("besidesInjectedArguments");
    }

    /// <summary>
    /// Checks that the Initialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInitializeWithTypeAndBesidesInjectedArguments()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var besidesInjectedArguments = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Initialize(type, besidesInjectedArguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Initialize method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInitializeWithTypeAndBesidesInjectedArgumentsWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.Initialize(default(Type), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the Initialize method throws when the besidesInjectedArguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInitializeWithTypeAndBesidesInjectedArgumentsWithNullBesidesInjectedArguments()
    {
        FluentActions.Invoking(() => this._testClass.Initialize(_fixture.Create<Type>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("besidesInjectedArguments");
    }

    /// <summary>
    /// Checks that the EnsureGetService method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEnsureGetServiceWithT()
    {
        // Act
        var result = this._testClass.EnsureGetService<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EnsureGetService method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEnsureGetServiceWithTAndType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.EnsureGetService<T>(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EnsureGetService method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEnsureGetServiceWithTAndTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.EnsureGetService<T>(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetObject()
    {
        // Arrange
        _serviceManager.Setup(mock => mock.GetObject<T>()).Returns(_fixture.Create<T>());
        _services.Setup(mock => mock.GetObject<T>()).Returns(_fixture.Create<T>());

        // Act
        var result = this._testClass.GetObject<T>();

        // Assert
        _serviceManager.Verify(mock => mock.GetObject<T>());
        _services.Verify(mock => mock.GetObject<T>());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddObjectWithTAndT()
    {
        // Arrange
        var obj = _fixture.Create<T>();

        _serviceManager.Setup(mock => mock.AddObject<T>(It.IsAny<T>())).Returns(_fixture.Create<ServiceObject<T>>());
        _services.Setup(mock => mock.AddObject<T>(It.IsAny<T>())).Returns(_fixture.Create<ServiceObject<T>>());

        // Act
        var result = this._testClass.AddObject<T>(obj);

        // Assert
        _serviceManager.Verify(mock => mock.AddObject<T>(It.IsAny<T>()));
        _services.Verify(mock => mock.AddObject<T>(It.IsAny<T>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddObject method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddObjectWithTAndTWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.AddObject<T>(default(T))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the AddObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddObjectWithT()
    {
        // Arrange
        _serviceManager.Setup(mock => mock.AddObject<T>(It.IsAny<T>())).Returns(_fixture.Create<ServiceObject<T>>());
        _services.Setup(mock => mock.AddObject<T>(It.IsAny<T>())).Returns(_fixture.Create<ServiceObject<T>>());

        // Act
        var result = this._testClass.AddObject<T>();

        // Assert
        _serviceManager.Verify(mock => mock.AddObject<T>(It.IsAny<T>()));
        _services.Verify(mock => mock.AddObject<T>(It.IsAny<T>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRootObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRootObject()
    {
        // Act
        var result = TestServiceManager.GetRootObject<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRootObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRootObjectWithTAndT()
    {
        // Arrange
        var obj = _fixture.Create<T>();

        // Act
        var result = TestServiceManager.AddRootObject<T>(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRootObject method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRootObjectWithTAndTWithNullObj()
    {
        FluentActions.Invoking(() => TestServiceManager.AddRootObject<T>(default(T))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the AddRootObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRootObjectWithT()
    {
        // Act
        var result = TestServiceManager.AddRootObject<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSession method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSession()
    {
        // Arrange
        _serviceManager.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());
        _services.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());

        // Act
        var result = this._testClass.GetSession();

        // Assert
        _serviceManager.Verify(mock => mock.GetProvider());
        _services.Verify(mock => mock.GetProvider());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateSession method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateSession()
    {
        // Arrange
        _serviceManager.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());
        _services.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());

        // Act
        var result = this._testClass.CreateSession();

        // Assert
        _serviceManager.Verify(mock => mock.GetProvider());
        _services.Verify(mock => mock.GetProvider());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateRootSession method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateRootSession()
    {
        // Act
        var result = TestServiceManager.CreateRootSession();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateScope method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateScope()
    {
        // Arrange
        _serviceManager.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());
        _services.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());

        // Act
        var result = this._testClass.CreateScope();

        // Assert
        _serviceManager.Verify(mock => mock.GetProvider());
        _services.Verify(mock => mock.GetProvider());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRootManager method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRootManager()
    {
        // Act
        var result = TestServiceManager.GetRootManager();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetManager method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetManager()
    {
        // Act
        var result = this._testClass.GetManager();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRootRegistry method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRootRegistry()
    {
        // Act
        var result = TestServiceManager.GetRootRegistry();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRegistry method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRegistryWithNoParameters()
    {
        // Act
        var result = this._testClass.GetRegistry();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRegistry method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRegistryWithServices()
    {
        // Arrange
        var services = _fixture.Create<IServiceCollection>();

        // Act
        var result = this._testClass.GetRegistry(services);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRegistry method throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRegistryWithServicesWithNullServices()
    {
        FluentActions.Invoking(() => this._testClass.GetRegistry(default(IServiceCollection))).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that the GetRegistry maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetRegistryWithServicesPerformsMapping()
    {
        // Arrange
        var services = _fixture.Create<IServiceCollection>();

        // Act
        var result = this._testClass.GetRegistry(services);

        // Assert
        result.Services.Should().BeSameAs(services);
    }

    /// <summary>
    /// Checks that the GetRootConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRootConfiguration()
    {
        // Act
        var result = TestServiceManager.GetRootConfiguration();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetConfiguration()
    {
        // Act
        var result = this._testClass.GetConfiguration();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDispose()
    {
        // Arrange
        var disposing = _fixture.Create<bool>();

        // Act
        this._testClass.PublicDispose(disposing);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DisposeAsyncCore method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDisposeAsyncCoreAsync()
    {
        // Act
        await this._testClass.DisposeAsyncCore();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RootProvider property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRootProvider()
    {
        // Assert
        this._testClass.RootProvider.Should().BeAssignableTo<IServiceProvider>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Provider property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetProvider()
    {
        // Arrange
        _serviceManager.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());
        _services.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());

        // Assert
        this._testClass.Provider.Should().BeAssignableTo<IServiceProvider>();

        _serviceManager.Verify(mock => mock.GetProvider());
        _services.Verify(mock => mock.GetProvider());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Session property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSession()
    {
        // Arrange
        _serviceManager.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());
        _services.Setup(mock => mock.GetProvider()).Returns(_fixture.Create<IServiceProvider>());

        // Assert
        this._testClass.Session.Should().BeAssignableTo<IServiceScope>();

        _serviceManager.Verify(mock => mock.GetProvider());
        _services.Verify(mock => mock.GetProvider());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Configuration property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetConfiguration()
    {
        this._testClass.CheckProperty(x => x.Configuration, _fixture.Create<IServiceConfiguration>(), _fixture.Create<IServiceConfiguration>());
    }

    /// <summary>
    /// Checks that the Registry property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRegistry()
    {
        // Assert
        this._testClass.Registry.Should().BeAssignableTo<IServiceRegistry>();

        Assert.Fail("Create or modify test");
    }
}