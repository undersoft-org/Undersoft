using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Data.Event.Bus;
using Undersoft.SDK.Service.Data.Event.Handler;
using TEvent = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Bus;

/// <summary>
/// Unit tests for the type <see cref="EventBus"/>.
/// </summary>
public class EventBusTests
{
    private class TestEventBus : EventBus
    {
        public TestEventBus(
            IOptions<EventBusOptions> options,
            IServiceScopeFactory serviceScopeFactory,
            IEventHandlerInvoker eventHandlerInvoker) : base(options, serviceScopeFactory, eventHandlerInvoker)
        {
        }

        public Task PublicPublishToEventBusAsync(Type eventType, object eventData)
        {
            return base.PublishToEventBusAsync(eventType, eventData);
        }

        public IEnumerable<EventBusBase.EventWithHandlerFactories> PublicGetHandlerFactories(Type eventType)
        {
            return base.GetHandlerFactories(eventType);
        }

        public EventBusOptions PublicOptions => base.Options;

        public Registry<EventBusBase.EventWithHandlerFactories> PublicHandlerFactories { get => base.HandlerFactories; set => base.HandlerFactories = value; }
    }

    private TestEventBus _testClass;
    private IFixture _fixture;
    private Mock<IOptions<EventBusOptions>> _options;
    private Mock<IServiceScopeFactory> _serviceScopeFactory;
    private Mock<IEventHandlerInvoker> _eventHandlerInvoker;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventBus"/>.
    /// </summary>
    public EventBusTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._options = _fixture.Freeze<Mock<IOptions<EventBusOptions>>>();
        this._serviceScopeFactory = _fixture.Freeze<Mock<IServiceScopeFactory>>();
        this._eventHandlerInvoker = _fixture.Freeze<Mock<IEventHandlerInvoker>>();
        this._testClass = _fixture.Create<TestEventBus>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestEventBus(this._options.Object, this._serviceScopeFactory.Object, this._eventHandlerInvoker.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new TestEventBus(default(IOptions<EventBusOptions>), this._serviceScopeFactory.Object, this._eventHandlerInvoker.Object)).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceScopeFactory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceScopeFactory()
    {
        FluentActions.Invoking(() => new TestEventBus(this._options.Object, default(IServiceScopeFactory), this._eventHandlerInvoker.Object)).Should().Throw<ArgumentNullException>().WithParameterName("serviceScopeFactory");
    }

    /// <summary>
    /// Checks that instance construction throws when the eventHandlerInvoker parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEventHandlerInvoker()
    {
        FluentActions.Invoking(() => new TestEventBus(this._options.Object, this._serviceScopeFactory.Object, default(IEventHandlerInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("eventHandlerInvoker");
    }

    /// <summary>
    /// Checks that the Subscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSubscribeWithHandler()
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
    public void CannotCallSubscribeWithHandlerWithNullHandler()
    {
        FluentActions.Invoking(() => this._testClass.Subscribe<TEvent>(default(IEventHandler<TEvent>))).Should().Throw<ArgumentNullException>().WithParameterName("handler");
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
    public void CanCallUnsubscribeWithAction()
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
    public void CannotCallUnsubscribeWithActionWithNullAction()
    {
        FluentActions.Invoking(() => this._testClass.Unsubscribe<TEvent>(default(Func<TEvent, Task>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the Unsubscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUnsubscribeWithEventTypeAndHandler()
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
    public void CannotCallUnsubscribeWithEventTypeAndHandlerWithNullEventType()
    {
        FluentActions.Invoking(() => this._testClass.Unsubscribe(default(Type), _fixture.Create<IEventHandler>())).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the Unsubscribe method throws when the handler parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUnsubscribeWithEventTypeAndHandlerWithNullHandler()
    {
        FluentActions.Invoking(() => this._testClass.Unsubscribe(_fixture.Create<Type>(), default(IEventHandler))).Should().Throw<ArgumentNullException>().WithParameterName("handler");
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
    public void CanCallUnsubscribeAll()
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
    public void CannotCallUnsubscribeAllWithNullEventType()
    {
        FluentActions.Invoking(() => this._testClass.UnsubscribeAll(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the PublicPublishToEventBusAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPublishToEventBusAsync()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();
        var eventData = _fixture.Create<object>();

        // Act
        await this._testClass.PublicPublishToEventBusAsync(eventType, eventData);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicPublishToEventBusAsync method throws when the eventType parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishToEventBusAsyncWithNullEventTypeAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicPublishToEventBusAsync(default(Type), _fixture.Create<object>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the PublicPublishToEventBusAsync method throws when the eventData parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishToEventBusAsyncWithNullEventDataAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicPublishToEventBusAsync(_fixture.Create<Type>(), default(object))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventData");
    }

    /// <summary>
    /// Checks that the PublishAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPublishAsync()
    {
        // Arrange
        var localEventMessage = _fixture.Create<EventMessage>();

        // Act
        await this._testClass.PublishAsync(localEventMessage);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublishAsync method throws when the localEventMessage parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishAsyncWithNullLocalEventMessageAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublishAsync(default(EventMessage))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("localEventMessage");
    }

    /// <summary>
    /// Checks that the PublicGetHandlerFactories method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHandlerFactories()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.PublicGetHandlerFactories(eventType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicGetHandlerFactories method throws when the eventType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetHandlerFactoriesWithNullEventType()
    {
        FluentActions.Invoking(() => this._testClass.PublicGetHandlerFactories(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the Logger property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLogger()
    {
        // Arrange
        var testValue = _fixture.Create<ILogger<EventBus>>();

        // Act
        this._testClass.Logger = testValue;

        // Assert
        this._testClass.Logger.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the PublicOptions property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicOptions()
    {
        // Assert
        this._testClass.PublicOptions.Should().BeAssignableTo<EventBusOptions>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicHandlerFactories property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPublicHandlerFactories()
    {
        // Arrange
        var testValue = _fixture.Create<Registry<EventBusBase.EventWithHandlerFactories>>();

        // Act
        this._testClass.PublicHandlerFactories = testValue;

        // Assert
        this._testClass.PublicHandlerFactories.Should().BeSameAs(testValue);
    }
}