using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using T = System.String;

namespace Undersoft.SDK.Service.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ServiceRegistry"/>.
/// </summary>
public partial class ServiceRegistryTests
{
    private ServiceRegistry _testClass;
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
        this._testClass = _fixture.Create<ServiceRegistry>();
    }

    /// <summary>
    /// Checks that the TryAddObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAddObjectWithT()
    {
        // Act
        var result = this._testClass.TryAddObject<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAddObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAddObjectWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.TryAddObject(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAddObject method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryAddObjectWithTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.TryAddObject(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the AddObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddObjectWithT()
    {
        // Act
        var result = this._testClass.AddObject<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddObjectWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.AddObject(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddObject method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddObjectWithTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.AddObject(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the AddObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddObjectWithTypeAndObj()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var obj = _fixture.Create<object>();

        // Act
        var result = this._testClass.AddObject(type, obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddObject method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddObjectWithTypeAndObjWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.AddObject(default(Type), _fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the AddObject method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddObjectWithTypeAndObjWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.AddObject(_fixture.Create<Type>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the AddObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddObjectWithObj()
    {
        // Arrange
        var obj = _fixture.Create<T>();

        // Act
        var result = this._testClass.AddObject<T>(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddObject method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddObjectWithObjWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.AddObject<T>(default(T))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the AddObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddObjectWithAccessor()
    {
        // Arrange
        var accessor = _fixture.Create<ServiceObject<T>>();

        // Act
        var result = this._testClass.AddObject<T>(accessor);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddObject method throws when the accessor parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddObjectWithAccessorWithNullAccessor()
    {
        FluentActions.Invoking(() => this._testClass.AddObject<T>(default(ServiceObject<T>))).Should().Throw<ArgumentNullException>().WithParameterName("accessor");
    }

    /// <summary>
    /// Checks that the GetObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetObjectWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetObject(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetObject method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetObjectWithTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.GetObject(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetObjectWithT()
    {
        // Act
        var result = this._testClass.GetObject<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRequiredObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRequiredObject()
    {
        // Act
        var result = this._testClass.GetRequiredObject<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }
}