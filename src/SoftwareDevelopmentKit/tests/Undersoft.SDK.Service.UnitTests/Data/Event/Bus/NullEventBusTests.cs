using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event.Bus;
using Undersoft.SDK.Service.Data.Event.Handler;
using TEvent = System.String;
using THandler = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Bus;

/// <summary>
/// Unit tests for the type <see cref="NullEventBus"/>.
/// </summary>
public class NullEventBusTests
{
    private NullEventBus _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="NullEventBus"/>.
    /// </summary>
    public NullEventBusTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<NullEventBus>();
    }

    /// <summary>
    /// Checks that the Subscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSubscribeWithTEventAndFuncOfTEventAndTask()
    {
        // Arrange
        Func<TEvent, Task> action = x => _fixture.Create<Task>();

        // Act
        var result = this._testClass.Subscribe<TEvent>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Subscribe method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSubscribeWithTEventAndFuncOfTEventAndTaskWithNullAction()
    {
        FluentActions.Invoking(() => this._testClass.Subscribe<TEvent>(default(Func<TEvent, Task>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the Subscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSubscribeWithTEventAndIEventHandlerOfTEvent()
    {
        // Arrange
        var handler = _fixture.Create<IEventHandler<TEvent>>();

        // Act
        var result = this._testClass.Subscribe<TEvent>(handler);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Subscribe method throws when the handler parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSubscribeWithTEventAndIEventHandlerOfTEventWithNullHandler()
    {
        FluentActions.Invoking(() => this._testClass.Subscribe<TEvent>(default(IEventHandler<TEvent>))).Should().Throw<ArgumentNullException>().WithParameterName("handler");
    }

    /// <summary>
    /// Checks that the Subscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSubscribeWithTEventAndTHandler()
    {
        // Act
        var result = this._testClass.Subscribe<TEvent, THandler>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Subscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSubscribeWithTypeAndIEventHandler()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();
        var handler = _fixture.Create<IEventHandler>();

        // Act
        var result = this._testClass.Subscribe(eventType, handler);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Subscribe method throws when the eventType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSubscribeWithTypeAndIEventHandlerWithNullEventType()
    {
        FluentActions.Invoking(() => this._testClass.Subscribe(default(Type), _fixture.Create<IEventHandler>())).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the Subscribe method throws when the handler parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSubscribeWithTypeAndIEventHandlerWithNullHandler()
    {
        FluentActions.Invoking(() => this._testClass.Subscribe(_fixture.Create<Type>(), default(IEventHandler))).Should().Throw<ArgumentNullException>().WithParameterName("handler");
    }

    /// <summary>
    /// Checks that the Subscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSubscribeWithTEventAndIEventHandlerFactory()
    {
        // Arrange
        var factory = _fixture.Create<IEventHandlerFactory>();

        // Act
        var result = this._testClass.Subscribe<TEvent>(factory);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Subscribe method throws when the factory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSubscribeWithTEventAndIEventHandlerFactoryWithNullFactory()
    {
        FluentActions.Invoking(() => this._testClass.Subscribe<TEvent>(default(IEventHandlerFactory))).Should().Throw<ArgumentNullException>().WithParameterName("factory");
    }

    /// <summary>
    /// Checks that the Subscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSubscribeWithTypeAndIEventHandlerFactory()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();
        var factory = _fixture.Create<IEventHandlerFactory>();

        // Act
        var result = this._testClass.Subscribe(eventType, factory);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Subscribe method throws when the eventType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSubscribeWithTypeAndIEventHandlerFactoryWithNullEventType()
    {
        FluentActions.Invoking(() => this._testClass.Subscribe(default(Type), _fixture.Create<IEventHandlerFactory>())).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the Subscribe method throws when the factory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSubscribeWithTypeAndIEventHandlerFactoryWithNullFactory()
    {
        FluentActions.Invoking(() => this._testClass.Subscribe(_fixture.Create<Type>(), default(IEventHandlerFactory))).Should().Throw<ArgumentNullException>().WithParameterName("factory");
    }

    /// <summary>
    /// Checks that the Unsubscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUnsubscribeWithTEventAndFuncOfTEventAndTask()
    {
        // Arrange
        Func<TEvent, Task> action = x => _fixture.Create<Task>();

        // Act
        this._testClass.Unsubscribe<TEvent>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Unsubscribe method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUnsubscribeWithTEventAndFuncOfTEventAndTaskWithNullAction()
    {
        FluentActions.Invoking(() => this._testClass.Unsubscribe<TEvent>(default(Func<TEvent, Task>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the Unsubscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUnsubscribeWithTEventAndIEventHandlerOfTEvent()
    {
        // Arrange
        var handler = _fixture.Create<IEventHandler<TEvent>>();

        // Act
        this._testClass.Unsubscribe<TEvent>(handler);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Unsubscribe method throws when the handler parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUnsubscribeWithTEventAndIEventHandlerOfTEventWithNullHandler()
    {
        FluentActions.Invoking(() => this._testClass.Unsubscribe<TEvent>(default(IEventHandler<TEvent>))).Should().Throw<ArgumentNullException>().WithParameterName("handler");
    }

    /// <summary>
    /// Checks that the Unsubscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUnsubscribeWithTypeAndIEventHandler()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();
        var handler = _fixture.Create<IEventHandler>();

        // Act
        this._testClass.Unsubscribe(eventType, handler);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Unsubscribe method throws when the eventType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUnsubscribeWithTypeAndIEventHandlerWithNullEventType()
    {
        FluentActions.Invoking(() => this._testClass.Unsubscribe(default(Type), _fixture.Create<IEventHandler>())).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the Unsubscribe method throws when the handler parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUnsubscribeWithTypeAndIEventHandlerWithNullHandler()
    {
        FluentActions.Invoking(() => this._testClass.Unsubscribe(_fixture.Create<Type>(), default(IEventHandler))).Should().Throw<ArgumentNullException>().WithParameterName("handler");
    }

    /// <summary>
    /// Checks that the Unsubscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUnsubscribeWithTEventAndIEventHandlerFactory()
    {
        // Arrange
        var factory = _fixture.Create<IEventHandlerFactory>();

        // Act
        this._testClass.Unsubscribe<TEvent>(factory);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Unsubscribe method throws when the factory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUnsubscribeWithTEventAndIEventHandlerFactoryWithNullFactory()
    {
        FluentActions.Invoking(() => this._testClass.Unsubscribe<TEvent>(default(IEventHandlerFactory))).Should().Throw<ArgumentNullException>().WithParameterName("factory");
    }

    /// <summary>
    /// Checks that the Unsubscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUnsubscribeWithTypeAndIEventHandlerFactory()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();
        var factory = _fixture.Create<IEventHandlerFactory>();

        // Act
        this._testClass.Unsubscribe(eventType, factory);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Unsubscribe method throws when the eventType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUnsubscribeWithTypeAndIEventHandlerFactoryWithNullEventType()
    {
        FluentActions.Invoking(() => this._testClass.Unsubscribe(default(Type), _fixture.Create<IEventHandlerFactory>())).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the Unsubscribe method throws when the factory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUnsubscribeWithTypeAndIEventHandlerFactoryWithNullFactory()
    {
        FluentActions.Invoking(() => this._testClass.Unsubscribe(_fixture.Create<Type>(), default(IEventHandlerFactory))).Should().Throw<ArgumentNullException>().WithParameterName("factory");
    }

    /// <summary>
    /// Checks that the UnsubscribeAll method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUnsubscribeAllWithTEvent()
    {
        // Act
        this._testClass.UnsubscribeAll<TEvent>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UnsubscribeAll method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUnsubscribeAllWithEventType()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();

        // Act
        this._testClass.UnsubscribeAll(eventType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UnsubscribeAll method throws when the eventType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUnsubscribeAllWithEventTypeWithNullEventType()
    {
        FluentActions.Invoking(() => this._testClass.UnsubscribeAll(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the PublishAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPublishAsyncWithEventDataAndOnUnitOfWorkCompleteAsync()
    {
        // Arrange
        var eventData = _fixture.Create<TEvent>();
        var onUnitOfWorkComplete = _fixture.Create<bool>();

        // Act
        await this._testClass.PublishAsync<TEvent>(eventData, onUnitOfWorkComplete);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublishAsync method throws when the eventData parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishAsyncWithEventDataAndOnUnitOfWorkCompleteWithNullEventDataAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublishAsync<TEvent>(default(TEvent), _fixture.Create<bool>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventData");
    }

    /// <summary>
    /// Checks that the PublishAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPublishAsyncWithEventTypeAndEventDataAndOnUnitOfWorkCompleteAsync()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();
        var eventData = _fixture.Create<object>();
        var onUnitOfWorkComplete = _fixture.Create<bool>();

        // Act
        await this._testClass.PublishAsync(eventType, eventData, onUnitOfWorkComplete);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublishAsync method throws when the eventType parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishAsyncWithEventTypeAndEventDataAndOnUnitOfWorkCompleteWithNullEventTypeAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublishAsync(default(Type), _fixture.Create<object>(), _fixture.Create<bool>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the PublishAsync method throws when the eventData parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishAsyncWithEventTypeAndEventDataAndOnUnitOfWorkCompleteWithNullEventDataAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublishAsync(_fixture.Create<Type>(), default(object), _fixture.Create<bool>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventData");
    }

    /// <summary>
    /// Checks that the Instance property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetInstance()
    {
        // Assert
        NullEventBus.Instance.Should().BeAssignableTo<NullEventBus>();

        Assert.Fail("Create or modify test");
    }
}