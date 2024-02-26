using System;
using System.Collections.Concurrent;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Event.Provider.RabbitMq;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ChannelPool"/>.
/// </summary>
[TestClass]
public class ChannelPoolTests
{
    private class TestChannelPool : ChannelPool
    {
        public TestChannelPool(IConnectionPool connectionPool) : base(connectionPool)
        {
        }

        public IModel PublicCreateChannel(string channelName, string connectionName)
        {
            return base.CreateChannel(channelName, connectionName);
        }

        public void PublicCheckDisposed()
        {
            base.CheckDisposed();
        }

        public IConnectionPool PublicConnectionPool => base.ConnectionPool;

        public ConcurrentDictionary<string, ChannelPool.ChannelPoolItem> PublicChannels => base.Channels;

        public bool PublicIsDisposed => base.IsDisposed;

        public TimeSpan PublicTotalDisposeWaitDuration { get => base.TotalDisposeWaitDuration; set => base.TotalDisposeWaitDuration = value; }
    }

    private TestChannelPool _testClass;
    private IFixture _fixture;
    private Mock<IConnectionPool> _connectionPool;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ChannelPool"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._connectionPool = _fixture.Freeze<Mock<IConnectionPool>>();
        this._testClass = _fixture.Create<TestChannelPool>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestChannelPool(this._connectionPool.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the connectionPool parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConnectionPool()
    {
        FluentActions.Invoking(() => new TestChannelPool(default(IConnectionPool))).Should().Throw<ArgumentNullException>().WithParameterName("connectionPool");
    }

    /// <summary>
    /// Checks that the Acquire method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAcquire()
    {
        // Arrange
        var channelName = _fixture.Create<string>();
        var connectionName = _fixture.Create<string>();

        // Act
        var result = this._testClass.Acquire(channelName, connectionName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Acquire method throws when the channelName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallAcquireWithInvalidChannelName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Acquire(value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("channelName");
    }

    /// <summary>
    /// Checks that the Acquire method throws when the connectionName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallAcquireWithInvalidConnectionName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Acquire(_fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionName");
    }

    /// <summary>
    /// Checks that the PublicCreateChannel method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateChannel()
    {
        // Arrange
        var channelName = _fixture.Create<string>();
        var connectionName = _fixture.Create<string>();

        // Act
        var result = this._testClass.PublicCreateChannel(channelName, connectionName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicCreateChannel method throws when the channelName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCreateChannelWithInvalidChannelName(string value)
    {
        FluentActions.Invoking(() => this._testClass.PublicCreateChannel(value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("channelName");
    }

    /// <summary>
    /// Checks that the PublicCreateChannel method throws when the connectionName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCreateChannelWithInvalidConnectionName(string value)
    {
        FluentActions.Invoking(() => this._testClass.PublicCreateChannel(_fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionName");
    }

    /// <summary>
    /// Checks that the PublicCheckDisposed method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCheckDisposed()
    {
        // Act
        this._testClass.PublicCheckDisposed();

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
    /// Checks that the PublicChannels property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicChannels()
    {
        // Assert
        this._testClass.PublicChannels.Should().BeAssignableTo<ConcurrentDictionary<string, ChannelPool.ChannelPoolItem>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicIsDisposed property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicIsDisposed()
    {
        // Assert
        this._testClass.PublicIsDisposed.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicTotalDisposeWaitDuration property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPublicTotalDisposeWaitDuration()
    {
        // Arrange
        var testValue = _fixture.Create<TimeSpan>();

        // Act
        this._testClass.PublicTotalDisposeWaitDuration = testValue;

        // Assert
        this._testClass.PublicTotalDisposeWaitDuration.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Logger property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLogger()
    {
        // Arrange
        var testValue = _fixture.Create<ILogger<ChannelPool>>();

        // Act
        this._testClass.Logger = testValue;

        // Assert
        this._testClass.Logger.Should().BeSameAs(testValue);
    }
}