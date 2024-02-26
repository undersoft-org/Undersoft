using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using T = System.String;
using TContext = System.String;
using TService = System.String;

namespace Undersoft.SDK.Service.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ServiceRegistry"/>.
/// </summary>
public partial class ServiceRegistryTests
{
    private class TestServiceRegistry : ServiceRegistry
    {
        public TestServiceRegistry() : base()
        {
        }

        public TestServiceRegistry(IServiceCollection services, IServiceManager manager) : base(services, manager)
        {
        }

        public bool PublicInnerAdd(ServiceDescriptor value)
        {
            return base.InnerAdd(value);
        }

        public ISeriesItem<ServiceDescriptor> PublicInnerPut(ServiceDescriptor value)
        {
            return base.InnerPut(value);
        }

        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

    private TestServiceRegistry _testClass;
    private IFixture _fixture;
    private Mock<IServiceCollection> _services;
    private Mock<IServiceManager> _manager;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServiceRegistry"/>.
    /// </summary>
    public ServiceRegistryTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._services = _fixture.Freeze<Mock<IServiceCollection>>();
        this._manager = _fixture.Freeze<Mock<IServiceManager>>();
        this._testClass = _fixture.Create<TestServiceRegistry>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestServiceRegistry();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestServiceRegistry(this._services.Object, this._manager.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServices()
    {
        FluentActions.Invoking(() => new TestServiceRegistry(default(IServiceCollection), this._manager.Object)).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that instance construction throws when the manager parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullManager()
    {
        FluentActions.Invoking(() => new TestServiceRegistry(this._services.Object, default(IServiceManager))).Should().Throw<ArgumentNullException>().WithParameterName("manager");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithContextType()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.Get(contextType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithContextTypeWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.Get(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithTService()
    {
        // Act
        var result = this._testClass.Get<TService>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGet()
    {
        // Act
        var result = this._testClass.TryGet<TService>(out var profile);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAdd()
    {
        // Arrange
        var profile = _fixture.Create<ServiceDescriptor>();

        // Act
        var result = this._testClass.TryAdd(profile);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAdd method throws when the profile parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryAddWithNullProfile()
    {
        FluentActions.Invoking(() => this._testClass.TryAdd(default(ServiceDescriptor))).Should().Throw<ArgumentNullException>().WithParameterName("profile");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithTContext()
    {
        // Act
        var result = this._testClass.Remove<TContext>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerAdd()
    {
        // Arrange
        var value = _fixture.Create<ServiceDescriptor>();

        // Act
        var result = this._testClass.PublicInnerAdd(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerAdd method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerAddWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerAdd(default(ServiceDescriptor))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the PublicInnerPut method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerPut()
    {
        // Arrange
        var value = _fixture.Create<ServiceDescriptor>();

        // Act
        var result = this._testClass.PublicInnerPut(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerPut method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerPutWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerPut(default(ServiceDescriptor))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the PublicInnerPut maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void InnerPutPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<ServiceDescriptor>();

        // Act
        var result = this._testClass.PublicInnerPut(value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSet()
    {
        // Arrange
        var descriptor = _fixture.Create<ServiceDescriptor>();

        // Act
        var result = this._testClass.Set(descriptor);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the descriptor parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithNullDescriptor()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(ServiceDescriptor))).Should().Throw<ArgumentNullException>().WithParameterName("descriptor");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAdd()
    {
        // Arrange
        var item = _fixture.Create<ServiceDescriptor>();

        // Act
        this._testClass.Add(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(ServiceDescriptor))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the GetKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetKeyWithServiceDescriptor()
    {
        // Arrange
        var item = _fixture.Create<ServiceDescriptor>();

        // Act
        var result = this._testClass.GetKey(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetKey method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetKeyWithServiceDescriptorWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.GetKey(default(ServiceDescriptor))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the GetKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetKeyWithType()
    {
        // Arrange
        var item = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetKey(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetKey method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetKeyWithTypeWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.GetKey(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the GetKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetKeyWithString()
    {
        // Arrange
        var item = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetKey(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetKey method throws when the item parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetKeyWithStringWithInvalidItem(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetKey(value)).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the GetKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetKeyWithT()
    {
        // Act
        var result = this._testClass.GetKey<T>();

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
    /// Checks that the IndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIndexOf()
    {
        // Arrange
        var item = _fixture.Create<ServiceDescriptor>();

        // Act
        var result = this._testClass.IndexOf(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIndexOfWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.IndexOf(default(ServiceDescriptor))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Insert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsert()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var item = _fixture.Create<ServiceDescriptor>();

        // Act
        this._testClass.Insert(index, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Insert method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInsertWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Insert(_fixture.Create<int>(), default(ServiceDescriptor))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContains()
    {
        // Arrange
        var item = _fixture.Create<ServiceDescriptor>();

        // Act
        var result = this._testClass.Contains(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Contains(default(ServiceDescriptor))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the CopyTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyTo()
    {
        // Arrange
        var array = _fixture.Create<ServiceDescriptor[]>();
        var arrayIndex = _fixture.Create<int>();

        // Act
        this._testClass.CopyTo(array, arrayIndex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyToWithNullArray()
    {
        FluentActions.Invoking(() => this._testClass.CopyTo(default(ServiceDescriptor[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithServiceDescriptor()
    {
        // Arrange
        var item = _fixture.Create<ServiceDescriptor>();

        // Act
        var result = this._testClass.Remove(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveWithServiceDescriptorWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Remove(default(ServiceDescriptor))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ContainsKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsKeyWithTService()
    {
        // Act
        var result = this._testClass.ContainsKey<TService>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ContainsKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsKeyWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.ContainsKey(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ContainsKey method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsKeyWithTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.ContainsKey(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the MergeServices method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMergeServicesWithActualizeExternalServices()
    {
        // Arrange
        var actualizeExternalServices = _fixture.Create<bool>();

        // Act
        this._testClass.MergeServices(actualizeExternalServices);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MergeServices method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMergeServicesWithServicesAndActualizeExternalServices()
    {
        // Arrange
        var services = _fixture.Create<IServiceCollection>();
        var actualizeExternalServices = _fixture.Create<bool>();

        // Act
        this._testClass.MergeServices(services, actualizeExternalServices);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MergeServices method throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMergeServicesWithServicesAndActualizeExternalServicesWithNullServices()
    {
        FluentActions.Invoking(() => this._testClass.MergeServices(default(IServiceCollection), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that setting the Services property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetServices()
    {
        this._testClass.CheckProperty(x => x.Services, _fixture.Create<IServiceCollection>(), _fixture.Create<IServiceCollection>());
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForString()
    {
        var testValue = _fixture.Create<ServiceDescriptor>();
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<ServiceDescriptor>();
        this._testClass[_fixture.Create<string>()] = testValue;
        this._testClass[_fixture.Create<string>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForType()
    {
        var testValue = _fixture.Create<ServiceDescriptor>();
        this._testClass[_fixture.Create<Type>()].Should().BeAssignableTo<ServiceDescriptor>();
        this._testClass[_fixture.Create<Type>()] = testValue;
        this._testClass[_fixture.Create<Type>()].Should().BeSameAs(testValue);
    }
}