using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Event.Handler;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Handler;

/// <summary>
/// Unit tests for the type <see cref="EventHandlerScopeFactory"/>.
/// </summary>
public class EventHandlerScopeFactoryTests
{
    private EventHandlerScopeFactory _testClass;
    private IFixture _fixture;
    private Mock<IServiceScopeFactory> _scopeFactory;
    private Type _handlerType;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventHandlerScopeFactory"/>.
    /// </summary>
    public EventHandlerScopeFactoryTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._scopeFactory = _fixture.Freeze<Mock<IServiceScopeFactory>>();
        this._handlerType = _fixture.Create<Type>();
        this._testClass = _fixture.Create<EventHandlerScopeFactory>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EventHandlerScopeFactory(this._scopeFactory.Object, this._handlerType);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the scopeFactory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullScopeFactory()
    {
        FluentActions.Invoking(() => new EventHandlerScopeFactory(default(IServiceScopeFactory), this._handlerType)).Should().Throw<ArgumentNullException>().WithParameterName("scopeFactory");
    }

    /// <summary>
    /// Checks that instance construction throws when the handlerType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullHandlerType()
    {
        FluentActions.Invoking(() => new EventHandlerScopeFactory(this._scopeFactory.Object, default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("handlerType");
    }

    /// <summary>
    /// Checks that the GetHandler method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHandler()
    {
        // Act
        var result = this._testClass.GetHandler();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsInFactories method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsInFactories()
    {
        // Arrange
        var handlerFactories = _fixture.Create<List<IEventHandlerFactory>>();

        // Act
        var result = this._testClass.IsInFactories(handlerFactories);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsInFactories method throws when the handlerFactories parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsInFactoriesWithNullHandlerFactories()
    {
        FluentActions.Invoking(() => this._testClass.IsInFactories(default(List<IEventHandlerFactory>))).Should().Throw<ArgumentNullException>().WithParameterName("handlerFactories");
    }

    /// <summary>
    /// Checks that the Dispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDispose()
    {
        // Act
        this._testClass.Dispose();

        // Assert
        Assert.Fail("Create or modify test");
    }
}