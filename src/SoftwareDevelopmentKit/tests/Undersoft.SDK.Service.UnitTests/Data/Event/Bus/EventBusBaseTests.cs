using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Event.Bus;
using Undersoft.SDK.Service.Data.Event.Handler;
using TEvent = System.String;
using THandler = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Bus;

/// <summary>
/// Unit tests for the type <see cref="EventBusBase"/>.
/// </summary>
public class EventBusBaseTests
{
    private class TestEventBusBase : EventBusBase
    {
        public TestEventBusBase(
            IServiceScopeFactory serviceScopeFactory,
            IEventHandlerInvoker eventHandlerInvoker) : base(serviceScopeFactory, eventHandlerInvoker)
        {
        }

        public Task PublicTriggerHandlersAsync(Type eventType, object eventData, List<Exception> exceptions)
        {
            return base.TriggerHandlersAsync(eventType, eventData, exceptions);
        }

        public Task PublicTriggerHandlerAsync(IEventHandlerFactory asyncHandlerFactory, Type eventType, object eventData, List<Exception> exceptions)
        {
            return base.TriggerHandlerAsync(asyncHandlerFactory, eventType, eventData, exceptions);
        }

        public void PublicThrowOriginalExceptions(Type eventType, List<Exception> exceptions)
        {
            base.ThrowOriginalExceptions(eventType, exceptions);
        }

        public void PublicSubscribeHandlers(IList<IEventHandler> handlers)
        {
            base.SubscribeHandlers(handlers);
        }

        public IServiceScopeFactory PublicServiceScopeFactory => base.ServiceScopeFactory;

        public IEventHandlerInvoker PublicEventHandlerInvoker => base.EventHandlerInvoker;

        public override IDisposable Subscribe(Type eventType, IEventHandlerFactory factory)
        {
            return default(IDisposable);
        }

        public override void Unsubscribe<TEvent>(Func<TEvent, Task> action)
        {
        }

        public override void Unsubscribe(Type eventType, IEventHandler handler)
        {
        }

        public override void Unsubscribe(Type eventType, IEventHandlerFactory factory)
        {
        }

        public override void UnsubscribeAll(Type eventType)
        {
        }

        protected override Task PublishToEventBusAsync(Type eventType, object eventData)
        {
            return default(Task);
        }

        protected override IEnumerable<EventBusBase.EventWithHandlerFactories> GetHandlerFactories(Type eventType)
        {
            return default(IEnumerable<EventBusBase.EventWithHandlerFactories>);
        }
    }

    private TestEventBusBase _testClass;
    private IFixture _fixture;
    private Mock<IServiceScopeFactory> _serviceScopeFactory;
    private Mock<IEventHandlerInvoker> _eventHandlerInvoker;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventBusBase"/>.
    /// </summary>
    public EventBusBaseTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._serviceScopeFactory = _fixture.Freeze<Mock<IServiceScopeFactory>>();
        this._eventHandlerInvoker = _fixture.Freeze<Mock<IEventHandlerInvoker>>();
        this._testClass = _fixture.Create<TestEventBusBase>();
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceScopeFactory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceScopeFactory()
    {
        FluentActions.Invoking(() => new TestEventBusBase(default(IServiceScopeFactory), this._eventHandlerInvoker.Object)).Should().Throw<ArgumentNullException>().WithParameterName("serviceScopeFactory");
    }

    /// <summary>
    /// Checks that instance construction throws when the eventHandlerInvoker parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEventHandlerInvoker()
    {
        FluentActions.Invoking(() => new TestEventBusBase(this._serviceScopeFactory.Object, default(IEventHandlerInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("eventHandlerInvoker");
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
    /// Checks that the Unsubscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUnsubscribeWithHandler()
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
    public void CannotCallUnsubscribeWithHandlerWithNullHandler()
    {
        FluentActions.Invoking(() => this._testClass.Unsubscribe<TEvent>(default(IEventHandler<TEvent>))).Should().Throw<ArgumentNullException>().WithParameterName("handler");
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
    /// Checks that the TriggerHandlersAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallTriggerHandlersAsyncWithTypeAndObjectAsync()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();
        var eventData = _fixture.Create<object>();

        // Act
        await this._testClass.TriggerHandlersAsync(eventType, eventData);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TriggerHandlersAsync method throws when the eventType parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallTriggerHandlersAsyncWithTypeAndObjectWithNullEventTypeAsync()
    {
        await FluentActions.Invoking(() => this._testClass.TriggerHandlersAsync(default(Type), _fixture.Create<object>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the TriggerHandlersAsync method throws when the eventData parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallTriggerHandlersAsyncWithTypeAndObjectWithNullEventDataAsync()
    {
        await FluentActions.Invoking(() => this._testClass.TriggerHandlersAsync(_fixture.Create<Type>(), default(object))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventData");
    }

    /// <summary>
    /// Checks that the PublicTriggerHandlersAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallTriggerHandlersAsyncWithEventTypeAndEventDataAndExceptionsAsync()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();
        var eventData = _fixture.Create<object>();
        var exceptions = _fixture.Create<List<Exception>>();

        // Act
        await this._testClass.PublicTriggerHandlersAsync(eventType, eventData, exceptions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicTriggerHandlersAsync method throws when the eventType parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallTriggerHandlersAsyncWithEventTypeAndEventDataAndExceptionsWithNullEventTypeAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicTriggerHandlersAsync(default(Type), _fixture.Create<object>(), _fixture.Create<List<Exception>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the PublicTriggerHandlersAsync method throws when the eventData parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallTriggerHandlersAsyncWithEventTypeAndEventDataAndExceptionsWithNullEventDataAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicTriggerHandlersAsync(_fixture.Create<Type>(), default(object), _fixture.Create<List<Exception>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventData");
    }

    /// <summary>
    /// Checks that the PublicTriggerHandlersAsync method throws when the exceptions parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallTriggerHandlersAsyncWithEventTypeAndEventDataAndExceptionsWithNullExceptionsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicTriggerHandlersAsync(_fixture.Create<Type>(), _fixture.Create<object>(), default(List<Exception>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("exceptions");
    }

    /// <summary>
    /// Checks that the PublicTriggerHandlerAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallTriggerHandlerAsync()
    {
        // Arrange
        var asyncHandlerFactory = _fixture.Create<IEventHandlerFactory>();
        var eventType = _fixture.Create<Type>();
        var eventData = _fixture.Create<object>();
        var exceptions = _fixture.Create<List<Exception>>();

        // Act
        await this._testClass.PublicTriggerHandlerAsync(asyncHandlerFactory, eventType, eventData, exceptions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicTriggerHandlerAsync method throws when the asyncHandlerFactory parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallTriggerHandlerAsyncWithNullAsyncHandlerFactoryAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicTriggerHandlerAsync(default(IEventHandlerFactory), _fixture.Create<Type>(), _fixture.Create<object>(), _fixture.Create<List<Exception>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("asyncHandlerFactory");
    }

    /// <summary>
    /// Checks that the PublicTriggerHandlerAsync method throws when the eventType parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallTriggerHandlerAsyncWithNullEventTypeAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicTriggerHandlerAsync(_fixture.Create<IEventHandlerFactory>(), default(Type), _fixture.Create<object>(), _fixture.Create<List<Exception>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the PublicTriggerHandlerAsync method throws when the eventData parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallTriggerHandlerAsyncWithNullEventDataAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicTriggerHandlerAsync(_fixture.Create<IEventHandlerFactory>(), _fixture.Create<Type>(), default(object), _fixture.Create<List<Exception>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventData");
    }

    /// <summary>
    /// Checks that the PublicTriggerHandlerAsync method throws when the exceptions parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallTriggerHandlerAsyncWithNullExceptionsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicTriggerHandlerAsync(_fixture.Create<IEventHandlerFactory>(), _fixture.Create<Type>(), _fixture.Create<object>(), default(List<Exception>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("exceptions");
    }

    /// <summary>
    /// Checks that the PublicThrowOriginalExceptions method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallThrowOriginalExceptions()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();
        var exceptions = _fixture.Create<List<Exception>>();

        // Act
        this._testClass.PublicThrowOriginalExceptions(eventType, exceptions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicThrowOriginalExceptions method throws when the eventType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallThrowOriginalExceptionsWithNullEventType()
    {
        FluentActions.Invoking(() => this._testClass.PublicThrowOriginalExceptions(default(Type), _fixture.Create<List<Exception>>())).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the PublicThrowOriginalExceptions method throws when the exceptions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallThrowOriginalExceptionsWithNullExceptions()
    {
        FluentActions.Invoking(() => this._testClass.PublicThrowOriginalExceptions(_fixture.Create<Type>(), default(List<Exception>))).Should().Throw<ArgumentNullException>().WithParameterName("exceptions");
    }

    /// <summary>
    /// Checks that the PublicSubscribeHandlers method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSubscribeHandlers()
    {
        // Arrange
        var handlers = _fixture.Create<IList<IEventHandler>>();

        // Act
        this._testClass.PublicSubscribeHandlers(handlers);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicSubscribeHandlers method throws when the handlers parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSubscribeHandlersWithNullHandlers()
    {
        FluentActions.Invoking(() => this._testClass.PublicSubscribeHandlers(default(IList<IEventHandler>))).Should().Throw<ArgumentNullException>().WithParameterName("handlers");
    }

    /// <summary>
    /// Checks that the PublicServiceScopeFactory property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicServiceScopeFactory()
    {
        // Assert
        this._testClass.PublicServiceScopeFactory.Should().BeAssignableTo<IServiceScopeFactory>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicEventHandlerInvoker property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicEventHandlerInvoker()
    {
        // Assert
        this._testClass.PublicEventHandlerInvoker.Should().BeAssignableTo<IEventHandlerInvoker>();

        Assert.Fail("Create or modify test");
    }
}