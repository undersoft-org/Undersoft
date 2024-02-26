using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using T = System.String;
using TContainerBuilder = System.String;

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
    /// Checks that the BuildServiceProviderFromFactory method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuildServiceProviderFromFactoryWithNoParameters()
    {
        // Act
        var result = this._testClass.BuildServiceProviderFromFactory();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BuildServiceProviderFromFactory method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuildServiceProviderFromFactoryWithBuilderAction()
    {
        // Arrange
        Action<TContainerBuilder> builderAction = x => { };

        // Act
        var result = this._testClass.BuildServiceProviderFromFactory<TContainerBuilder>(builderAction);

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
    /// Checks that the GetRequiredServiceLazy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRequiredServiceLazyWithT()
    {
        // Act
        var result = this._testClass.GetRequiredServiceLazy<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRequiredServiceLazy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRequiredServiceLazyWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetRequiredServiceLazy(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRequiredServiceLazy method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRequiredServiceLazyWithTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.GetRequiredServiceLazy(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetServiceLazy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetServiceLazyWithT()
    {
        // Act
        var result = this._testClass.GetServiceLazy<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetServiceLazy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetServiceLazyWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetServiceLazy(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetServiceLazy method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetServiceLazyWithTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.GetServiceLazy(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetProvider()
    {
        // Act
        var result = this._testClass.GetProvider();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRequiredSingleton method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRequiredSingleton()
    {
        // Act
        var result = this._testClass.GetRequiredSingleton<T>();

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

        // Act
        var result = this._testClass.GetSingleton(type);

        // Assert
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
    /// Checks that the IsAdded method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsAddedWithT()
    {
        // Act
        var result = this._testClass.IsAdded<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsAdded method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsAddedWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.IsAdded(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsAdded method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsAddedWithTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.IsAdded(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
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
}