using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQ.Client;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Data.Event.Bus;
using Undersoft.SDK.Service.Data.Event.Handler;
using Undersoft.SDK.Service.Data.Event.Provider.RabbitMq;
using TEvent = System.String;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="RabbitMqEventBus"/>.
/// </summary>
[TestClass]
public class RabbitMqEventBusTests
{
    private class TestRabbitMqEventBus : RabbitMqEventBus
    {
        public TestRabbitMqEventBus(
            IOptions<RabbitMqEventBusOptions> options,
            IConnectionPool connectionPool,
            IRabbitMqSerializer serializer,
            IServiceScopeFactory serviceScopeFactory,
            IOptions<EventBusOptions> eventBusOptions,
            IRabbitMqMessageConsumerFactory messageConsumerFactory,
            IEventHandlerInvoker eventHandlerInvoker) : base(options, connectionPool, serializer, serviceScopeFactory, eventBusOptions, messageConsumerFactory, eventHandlerInvoker)
        {
        }

        public Task PublicPublishToEventBusAsync(Type eventType, object eventData)
        {
            return base.PublishToEventBusAsync(eventType, eventData);
        }

        public byte[] PublicSerialize(object eventData)
        {
            return base.Serialize(eventData);
        }

        public Task PublicPublishAsync(string eventName, byte[] body, IBasicProperties properties, Dictionary<string, object> headersArguments, long? eventId)
        {
            return base.PublishAsync(eventName, body, properties, headersArguments, eventId);
        }

        public Task PublicPublishAsync(IModel channel, string eventName, byte[] body, IBasicProperties properties, Dictionary<string, object> headersArguments, long? eventId)
        {
            return base.PublishAsync(channel, eventName, body, properties, headersArguments, eventId);
        }

        public RabbitMqEventBusOptions PublicrabbitMqEventBusOptions => base.rabbitMqEventBusOptions;

        public IConnectionPool PublicConnectionPool => base.ConnectionPool;

        public IRabbitMqSerializer PublicSerializer => base.Serializer;

        public Registry<Type> PublicEventTypes => base.EventTypes;

        public IRabbitMqMessageConsumerFactory PublicMessageConsumerFactory => base.MessageConsumerFactory;

        public IRabbitMqMessageConsumer PublicConsumer => base.Consumer;
    }

    private TestRabbitMqEventBus _testClass;
    private IFixture _fixture;
    private Mock<IOptions<RabbitMqEventBusOptions>> _options;
    private Mock<IConnectionPool> _connectionPool;
    private Mock<IRabbitMqSerializer> _serializer;
    private Mock<IServiceScopeFactory> _serviceScopeFactory;
    private Mock<IOptions<EventBusOptions>> _eventBusOptions;
    private Mock<IRabbitMqMessageConsumerFactory> _messageConsumerFactory;
    private Mock<IEventHandlerInvoker> _eventHandlerInvoker;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RabbitMqEventBus"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._options = _fixture.Freeze<Mock<IOptions<RabbitMqEventBusOptions>>>();
        this._connectionPool = _fixture.Freeze<Mock<IConnectionPool>>();
        this._serializer = _fixture.Freeze<Mock<IRabbitMqSerializer>>();
        this._serviceScopeFactory = _fixture.Freeze<Mock<IServiceScopeFactory>>();
        this._eventBusOptions = _fixture.Freeze<Mock<IOptions<EventBusOptions>>>();
        this._messageConsumerFactory = _fixture.Freeze<Mock<IRabbitMqMessageConsumerFactory>>();
        this._eventHandlerInvoker = _fixture.Freeze<Mock<IEventHandlerInvoker>>();
        this._testClass = _fixture.Create<TestRabbitMqEventBus>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRabbitMqEventBus(this._options.Object, this._connectionPool.Object, this._serializer.Object, this._serviceScopeFactory.Object, this._eventBusOptions.Object, this._messageConsumerFactory.Object, this._eventHandlerInvoker.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new TestRabbitMqEventBus(default(IOptions<RabbitMqEventBusOptions>), this._connectionPool.Object, this._serializer.Object, this._serviceScopeFactory.Object, this._eventBusOptions.Object, this._messageConsumerFactory.Object, this._eventHandlerInvoker.Object)).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that instance construction throws when the connectionPool parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConnectionPool()
    {
        FluentActions.Invoking(() => new TestRabbitMqEventBus(this._options.Object, default(IConnectionPool), this._serializer.Object, this._serviceScopeFactory.Object, this._eventBusOptions.Object, this._messageConsumerFactory.Object, this._eventHandlerInvoker.Object)).Should().Throw<ArgumentNullException>().WithParameterName("connectionPool");
    }

    /// <summary>
    /// Checks that instance construction throws when the serializer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSerializer()
    {
        FluentActions.Invoking(() => new TestRabbitMqEventBus(this._options.Object, this._connectionPool.Object, default(IRabbitMqSerializer), this._serviceScopeFactory.Object, this._eventBusOptions.Object, this._messageConsumerFactory.Object, this._eventHandlerInvoker.Object)).Should().Throw<ArgumentNullException>().WithParameterName("serializer");
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceScopeFactory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceScopeFactory()
    {
        FluentActions.Invoking(() => new TestRabbitMqEventBus(this._options.Object, this._connectionPool.Object, this._serializer.Object, default(IServiceScopeFactory), this._eventBusOptions.Object, this._messageConsumerFactory.Object, this._eventHandlerInvoker.Object)).Should().Throw<ArgumentNullException>().WithParameterName("serviceScopeFactory");
    }

    /// <summary>
    /// Checks that instance construction throws when the eventBusOptions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEventBusOptions()
    {
        FluentActions.Invoking(() => new TestRabbitMqEventBus(this._options.Object, this._connectionPool.Object, this._serializer.Object, this._serviceScopeFactory.Object, default(IOptions<EventBusOptions>), this._messageConsumerFactory.Object, this._eventHandlerInvoker.Object)).Should().Throw<ArgumentNullException>().WithParameterName("eventBusOptions");
    }

    /// <summary>
    /// Checks that instance construction throws when the messageConsumerFactory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMessageConsumerFactory()
    {
        FluentActions.Invoking(() => new TestRabbitMqEventBus(this._options.Object, this._connectionPool.Object, this._serializer.Object, this._serviceScopeFactory.Object, this._eventBusOptions.Object, default(IRabbitMqMessageConsumerFactory), this._eventHandlerInvoker.Object)).Should().Throw<ArgumentNullException>().WithParameterName("messageConsumerFactory");
    }

    /// <summary>
    /// Checks that instance construction throws when the eventHandlerInvoker parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEventHandlerInvoker()
    {
        FluentActions.Invoking(() => new TestRabbitMqEventBus(this._options.Object, this._connectionPool.Object, this._serializer.Object, this._serviceScopeFactory.Object, this._eventBusOptions.Object, this._messageConsumerFactory.Object, default(IEventHandlerInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("eventHandlerInvoker");
    }

    /// <summary>
    /// Checks that the Initialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInitialize()
    {
        // Act
        this._testClass.Initialize();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Subscribe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSubscribe()
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
    public void CannotCallSubscribeWithNullEventType()
    {
        FluentActions.Invoking(() => this._testClass.Subscribe(default(Type), _fixture.Create<IEventHandlerFactory>())).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the Subscribe method throws when the factory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSubscribeWithNullFactory()
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
    /// Checks that the PublicSerialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSerialize()
    {
        // Arrange
        var eventData = _fixture.Create<object>();

        // Act
        var result = this._testClass.PublicSerialize(eventData);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicSerialize method throws when the eventData parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSerializeWithNullEventData()
    {
        FluentActions.Invoking(() => this._testClass.PublicSerialize(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("eventData");
    }

    /// <summary>
    /// Checks that the PublishAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPublishAsyncWithEventTypeAndEventDataAndPropertiesAndHeadersArgumentsAsync()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();
        var eventData = _fixture.Create<object>();
        var properties = _fixture.Create<IBasicProperties>();
        var headersArguments = _fixture.Create<Dictionary<string, object>>();

        // Act
        await this._testClass.PublishAsync(eventType, eventData, properties, headersArguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublishAsync method throws when the eventType parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishAsyncWithEventTypeAndEventDataAndPropertiesAndHeadersArgumentsWithNullEventTypeAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublishAsync(default(Type), _fixture.Create<object>(), _fixture.Create<IBasicProperties>(), _fixture.Create<Dictionary<string, object>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the PublishAsync method throws when the eventData parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishAsyncWithEventTypeAndEventDataAndPropertiesAndHeadersArgumentsWithNullEventDataAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublishAsync(_fixture.Create<Type>(), default(object), _fixture.Create<IBasicProperties>(), _fixture.Create<Dictionary<string, object>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventData");
    }

    /// <summary>
    /// Checks that the PublishAsync method throws when the properties parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishAsyncWithEventTypeAndEventDataAndPropertiesAndHeadersArgumentsWithNullPropertiesAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublishAsync(_fixture.Create<Type>(), _fixture.Create<object>(), default(IBasicProperties), _fixture.Create<Dictionary<string, object>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("properties");
    }

    /// <summary>
    /// Checks that the PublicPublishAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPublishAsyncWithEventNameAndBodyAndPropertiesAndHeadersArgumentsAndEventIdAsync()
    {
        // Arrange
        var eventName = _fixture.Create<string>();
        var body = _fixture.Create<byte[]>();
        var properties = _fixture.Create<IBasicProperties>();
        var headersArguments = _fixture.Create<Dictionary<string, object>>();
        var eventId = _fixture.Create<long?>();

        // Act
        await this._testClass.PublicPublishAsync(eventName, body, properties, headersArguments, eventId);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicPublishAsync method throws when the body parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishAsyncWithEventNameAndBodyAndPropertiesAndHeadersArgumentsAndEventIdWithNullBodyAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicPublishAsync(_fixture.Create<string>(), default(byte[]), _fixture.Create<IBasicProperties>(), _fixture.Create<Dictionary<string, object>>(), _fixture.Create<long?>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("body");
    }

    /// <summary>
    /// Checks that the PublicPublishAsync method throws when the properties parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishAsyncWithEventNameAndBodyAndPropertiesAndHeadersArgumentsAndEventIdWithNullPropertiesAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicPublishAsync(_fixture.Create<string>(), _fixture.Create<byte[]>(), default(IBasicProperties), _fixture.Create<Dictionary<string, object>>(), _fixture.Create<long?>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("properties");
    }

    /// <summary>
    /// Checks that the PublicPublishAsync method throws when the eventName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallPublishAsyncWithEventNameAndBodyAndPropertiesAndHeadersArgumentsAndEventIdWithInvalidEventNameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.PublicPublishAsync(value, _fixture.Create<byte[]>(), _fixture.Create<IBasicProperties>(), _fixture.Create<Dictionary<string, object>>(), _fixture.Create<long?>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventName");
    }

    /// <summary>
    /// Checks that the PublicPublishAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPublishAsyncWithChannelAndEventNameAndBodyAndPropertiesAndHeadersArgumentsAndEventIdAsync()
    {
        // Arrange
        var channel = _fixture.Create<IModel>();
        var eventName = _fixture.Create<string>();
        var body = _fixture.Create<byte[]>();
        var properties = _fixture.Create<IBasicProperties>();
        var headersArguments = _fixture.Create<Dictionary<string, object>>();
        var eventId = _fixture.Create<long?>();

        // Act
        await this._testClass.PublicPublishAsync(channel, eventName, body, properties, headersArguments, eventId);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicPublishAsync method throws when the channel parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishAsyncWithChannelAndEventNameAndBodyAndPropertiesAndHeadersArgumentsAndEventIdWithNullChannelAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicPublishAsync(default(IModel), _fixture.Create<string>(), _fixture.Create<byte[]>(), _fixture.Create<IBasicProperties>(), _fixture.Create<Dictionary<string, object>>(), _fixture.Create<long?>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("channel");
    }

    /// <summary>
    /// Checks that the PublicPublishAsync method throws when the body parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishAsyncWithChannelAndEventNameAndBodyAndPropertiesAndHeadersArgumentsAndEventIdWithNullBodyAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicPublishAsync(_fixture.Create<IModel>(), _fixture.Create<string>(), default(byte[]), _fixture.Create<IBasicProperties>(), _fixture.Create<Dictionary<string, object>>(), _fixture.Create<long?>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("body");
    }

    /// <summary>
    /// Checks that the PublicPublishAsync method throws when the properties parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishAsyncWithChannelAndEventNameAndBodyAndPropertiesAndHeadersArgumentsAndEventIdWithNullPropertiesAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicPublishAsync(_fixture.Create<IModel>(), _fixture.Create<string>(), _fixture.Create<byte[]>(), default(IBasicProperties), _fixture.Create<Dictionary<string, object>>(), _fixture.Create<long?>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("properties");
    }

    /// <summary>
    /// Checks that the PublicPublishAsync method throws when the eventName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallPublishAsyncWithChannelAndEventNameAndBodyAndPropertiesAndHeadersArgumentsAndEventIdWithInvalidEventNameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.PublicPublishAsync(_fixture.Create<IModel>(), value, _fixture.Create<byte[]>(), _fixture.Create<IBasicProperties>(), _fixture.Create<Dictionary<string, object>>(), _fixture.Create<long?>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventName");
    }

    /// <summary>
    /// Checks that the PublicrabbitMqEventBusOptions property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicrabbitMqEventBusOptions()
    {
        // Assert
        this._testClass.PublicrabbitMqEventBusOptions.Should().BeAssignableTo<RabbitMqEventBusOptions>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicConnectionPool property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicConnectionPool()
    {
        // Assert
        this._testClass.PublicConnectionPool.Should().BeAssignableTo<IConnectionPool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicSerializer property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicSerializer()
    {
        // Assert
        this._testClass.PublicSerializer.Should().BeAssignableTo<IRabbitMqSerializer>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicEventTypes property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicEventTypes()
    {
        // Assert
        this._testClass.PublicEventTypes.Should().BeAssignableTo<Registry<Type>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicMessageConsumerFactory property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicMessageConsumerFactory()
    {
        // Assert
        this._testClass.PublicMessageConsumerFactory.Should().BeAssignableTo<IRabbitMqMessageConsumerFactory>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicConsumer property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicConsumer()
    {
        // Assert
        this._testClass.PublicConsumer.Should().BeAssignableTo<IRabbitMqMessageConsumer>();

        Assert.Fail("Create or modify test");
    }
}