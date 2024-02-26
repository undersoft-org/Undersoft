using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Event.Bus;
using Undersoft.SDK.Service.Data.Event.Handler;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Handler;

/// <summary>
/// Unit tests for the type <see cref="EventHandlerFactoryUnregistrar"/>.
/// </summary>
public class EventHandlerFactoryUnregistrarTests
{
    private EventHandlerFactoryUnregistrar _testClass;
    private IFixture _fixture;
    private Mock<IEventBus> _eventBus;
    private Type _eventType;
    private Mock<IEventHandlerFactory> _factory;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventHandlerFactoryUnregistrar"/>.
    /// </summary>
    public EventHandlerFactoryUnregistrarTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._eventBus = _fixture.Freeze<Mock<IEventBus>>();
        this._eventType = _fixture.Create<Type>();
        this._factory = _fixture.Freeze<Mock<IEventHandlerFactory>>();
        this._testClass = _fixture.Create<EventHandlerFactoryUnregistrar>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EventHandlerFactoryUnregistrar(this._eventBus.Object, this._eventType, this._factory.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the eventBus parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEventBus()
    {
        FluentActions.Invoking(() => new EventHandlerFactoryUnregistrar(default(IEventBus), this._eventType, this._factory.Object)).Should().Throw<ArgumentNullException>().WithParameterName("eventBus");
    }

    /// <summary>
    /// Checks that instance construction throws when the eventType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEventType()
    {
        FluentActions.Invoking(() => new EventHandlerFactoryUnregistrar(this._eventBus.Object, default(Type), this._factory.Object)).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that instance construction throws when the factory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullFactory()
    {
        FluentActions.Invoking(() => new EventHandlerFactoryUnregistrar(this._eventBus.Object, this._eventType, default(IEventHandlerFactory))).Should().Throw<ArgumentNullException>().WithParameterName("factory");
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
        _eventBus.Verify(mock => mock.Unsubscribe(It.IsAny<Type>(), It.IsAny<IEventHandlerFactory>()));

        Assert.Fail("Create or modify test");
    }
}