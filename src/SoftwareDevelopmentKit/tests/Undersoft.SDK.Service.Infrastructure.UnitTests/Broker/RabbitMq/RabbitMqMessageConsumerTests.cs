using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Timers;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Undersoft.SDK.Service.Data.Event.Provider.RabbitMq;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="RabbitMqMessageConsumer"/>.
/// </summary>
[TestClass]
public class RabbitMqMessageConsumerTests
{
    private class TestRabbitMqMessageConsumer : RabbitMqMessageConsumer
    {
        public TestRabbitMqMessageConsumer(
            IConnectionPool connectionPool) : base(connectionPool)
        {
        }

        public Task PublicTrySendQueueBindCommandsAsync()
        {
            return base.TrySendQueueBindCommandsAsync();
        }

        public void PublicTimer_Elapsed(object sender, ElapsedEventArgs args)
        {
            base.Timer_Elapsed(sender, args);
        }

        public Task PublicTryCreateChannelAsync()
        {
            return base.TryCreateChannelAsync();
        }

        public Task PublicHandleIncomingMessageAsync(object sender, BasicDeliverEventArgs basicDeliverEventArgs)
        {
            return base.HandleIncomingMessageAsync(sender, basicDeliverEventArgs);
        }

        public void PublicDisposeChannel()
        {
            base.DisposeChannel();
        }

        public IConnectionPool PublicConnectionPool => base.ConnectionPool;

        public Timer PublicTimer => base.Timer;

        public ExchangeDeclareConfiguration PublicExchange => base.Exchange;

        public QueueDeclareConfiguration PublicQueue => base.Queue;

        public string PublicConnectionName => base.ConnectionName;

        public ConcurrentBag<Func<IModel, BasicDeliverEventArgs, Task>> PublicCallbacks => base.Callbacks;

        public IModel PublicChannel => base.Channel;

        public ConcurrentQueue<RabbitMqMessageConsumer.QueueBindCommand> PublicQueueBindCommands => base.QueueBindCommands;

        public object PublicChannelSendSyncLock => base.ChannelSendSyncLock;
    }

    private TestRabbitMqMessageConsumer _testClass;
    private IFixture _fixture;
    private Mock<IConnectionPool> _connectionPool;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RabbitMqMessageConsumer"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._connectionPool = _fixture.Freeze<Mock<IConnectionPool>>();
        this._testClass = _fixture.Create<TestRabbitMqMessageConsumer>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRabbitMqMessageConsumer(this._connectionPool.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the connectionPool parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConnectionPool()
    {
        FluentActions.Invoking(() => new TestRabbitMqMessageConsumer(default(IConnectionPool))).Should().Throw<ArgumentNullException>().WithParameterName("connectionPool");
    }

    /// <summary>
    /// Checks that the Initialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInitialize()
    {
        // Arrange
        var exchange = _fixture.Create<ExchangeDeclareConfiguration>();
        var queue = _fixture.Create<QueueDeclareConfiguration>();
        var connectionName = _fixture.Create<string>();

        // Act
        this._testClass.Initialize(exchange, queue, connectionName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Initialize method throws when the exchange parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInitializeWithNullExchange()
    {
        FluentActions.Invoking(() => this._testClass.Initialize(default(ExchangeDeclareConfiguration), _fixture.Create<QueueDeclareConfiguration>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("exchange");
    }

    /// <summary>
    /// Checks that the Initialize method throws when the queue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInitializeWithNullQueue()
    {
        FluentActions.Invoking(() => this._testClass.Initialize(_fixture.Create<ExchangeDeclareConfiguration>(), default(QueueDeclareConfiguration), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("queue");
    }

    /// <summary>
    /// Checks that the Initialize method throws when the connectionName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallInitializeWithInvalidConnectionName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Initialize(_fixture.Create<ExchangeDeclareConfiguration>(), _fixture.Create<QueueDeclareConfiguration>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionName");
    }

    /// <summary>
    /// Checks that the BindAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallBindAsync()
    {
        // Arrange
        var routingKey = _fixture.Create<string>();

        // Act
        await this._testClass.BindAsync(routingKey);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BindAsync method throws when the routingKey parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallBindAsyncWithInvalidRoutingKeyAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.BindAsync(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("routingKey");
    }

    /// <summary>
    /// Checks that the UnbindAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallUnbindAsync()
    {
        // Arrange
        var routingKey = _fixture.Create<string>();

        // Act
        await this._testClass.UnbindAsync(routingKey);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UnbindAsync method throws when the routingKey parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallUnbindAsyncWithInvalidRoutingKeyAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.UnbindAsync(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("routingKey");
    }

    /// <summary>
    /// Checks that the PublicTrySendQueueBindCommandsAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallTrySendQueueBindCommandsAsync()
    {
        // Act
        await this._testClass.PublicTrySendQueueBindCommandsAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the OnMessageReceived method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOnMessageReceived()
    {
        // Arrange
        Func<IModel, BasicDeliverEventArgs, Task> callback = (x, y) => _fixture.Create<Task>();

        // Act
        this._testClass.OnMessageReceived(callback);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the OnMessageReceived method throws when the callback parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnMessageReceivedWithNullCallback()
    {
        FluentActions.Invoking(() => this._testClass.OnMessageReceived(default(Func<IModel, BasicDeliverEventArgs, Task>))).Should().Throw<ArgumentNullException>().WithParameterName("callback");
    }

    /// <summary>
    /// Checks that the PublicTimer_Elapsed method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTimer_Elapsed()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var args = _fixture.Create<ElapsedEventArgs>();

        // Act
        this._testClass.PublicTimer_Elapsed(sender, args);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicTimer_Elapsed method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTimer_ElapsedWithNullSender()
    {
        FluentActions.Invoking(() => this._testClass.PublicTimer_Elapsed(default(object), _fixture.Create<ElapsedEventArgs>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the PublicTimer_Elapsed method throws when the args parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTimer_ElapsedWithNullArgs()
    {
        FluentActions.Invoking(() => this._testClass.PublicTimer_Elapsed(_fixture.Create<object>(), default(ElapsedEventArgs))).Should().Throw<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that the PublicTryCreateChannelAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallTryCreateChannelAsync()
    {
        // Act
        await this._testClass.PublicTryCreateChannelAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicHandleIncomingMessageAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHandleIncomingMessageAsync()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var basicDeliverEventArgs = _fixture.Create<BasicDeliverEventArgs>();

        // Act
        await this._testClass.PublicHandleIncomingMessageAsync(sender, basicDeliverEventArgs);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicHandleIncomingMessageAsync method throws when the sender parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallHandleIncomingMessageAsyncWithNullSenderAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicHandleIncomingMessageAsync(default(object), _fixture.Create<BasicDeliverEventArgs>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the PublicHandleIncomingMessageAsync method throws when the basicDeliverEventArgs parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallHandleIncomingMessageAsyncWithNullBasicDeliverEventArgsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicHandleIncomingMessageAsync(_fixture.Create<object>(), default(BasicDeliverEventArgs))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("basicDeliverEventArgs");
    }

    /// <summary>
    /// Checks that the PublicDisposeChannel method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDisposeChannel()
    {
        // Act
        this._testClass.PublicDisposeChannel();

        // Assert
        Assert.Fail("Create or modify test");
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

    /// <summary>
    /// Checks that the Logger property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLogger()
    {
        // Arrange
        var testValue = _fixture.Create<ILogger<RabbitMqMessageConsumer>>();

        // Act
        this._testClass.Logger = testValue;

        // Assert
        this._testClass.Logger.Should().BeSameAs(testValue);
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
    /// Checks that the PublicTimer property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicTimer()
    {
        // Assert
        this._testClass.PublicTimer.Should().BeAssignableTo<Timer>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicExchange property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicExchange()
    {
        // Assert
        this._testClass.PublicExchange.Should().BeAssignableTo<ExchangeDeclareConfiguration>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicQueue property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicQueue()
    {
        // Assert
        this._testClass.PublicQueue.Should().BeAssignableTo<QueueDeclareConfiguration>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicConnectionName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicConnectionName()
    {
        // Assert
        this._testClass.PublicConnectionName.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicCallbacks property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicCallbacks()
    {
        // Assert
        this._testClass.PublicCallbacks.Should().BeAssignableTo<ConcurrentBag<Func<IModel, BasicDeliverEventArgs, Task>>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicChannel property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicChannel()
    {
        // Assert
        this._testClass.PublicChannel.Should().BeAssignableTo<IModel>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicQueueBindCommands property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicQueueBindCommands()
    {
        // Assert
        this._testClass.PublicQueueBindCommands.Should().BeAssignableTo<ConcurrentQueue<RabbitMqMessageConsumer.QueueBindCommand>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicChannelSendSyncLock property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicChannelSendSyncLock()
    {
        // Assert
        this._testClass.PublicChannelSendSyncLock.Should().BeAssignableTo<object>();

        Assert.Fail("Create or modify test");
    }
}