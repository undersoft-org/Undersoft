using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Event.Handler;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Handler;

/// <summary>
/// Unit tests for the type <see cref="EventHandlerSingletonFactory"/>.
/// </summary>
public class EventHandlerSingletonFactoryTests
{
    private EventHandlerSingletonFactory _testClass;
    private IFixture _fixture;
    private Mock<IEventHandler> _handler;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventHandlerSingletonFactory"/>.
    /// </summary>
    public EventHandlerSingletonFactoryTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._handler = _fixture.Freeze<Mock<IEventHandler>>();
        this._testClass = _fixture.Create<EventHandlerSingletonFactory>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EventHandlerSingletonFactory(this._handler.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the handler parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullHandler()
    {
        FluentActions.Invoking(() => new EventHandlerSingletonFactory(default(IEventHandler))).Should().Throw<ArgumentNullException>().WithParameterName("handler");
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
    /// Checks that the HandlerType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetHandlerType()
    {
        // Assert
        this._testClass.HandlerType.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the HandlerInstance property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetHandlerInstance()
    {
        // Assert
        this._testClass.HandlerInstance.Should().BeAssignableTo<IEventHandler>();

        Assert.Fail("Create or modify test");
    }
}