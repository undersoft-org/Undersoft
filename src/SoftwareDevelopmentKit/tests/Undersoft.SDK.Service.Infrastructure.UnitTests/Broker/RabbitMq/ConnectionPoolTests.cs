using System;
using System.Collections.Concurrent;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQ.Client;
using Undersoft.SDK.Service.Data.Event.Provider.RabbitMq;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ConnectionPool"/>.
/// </summary>
[TestClass]
public class ConnectionPoolTests
{
    private class TestConnectionPool : ConnectionPool
    {
        public TestConnectionPool(IOptions<RabbitMqOptions> options) : base(options)
        {
        }

        public RabbitMqOptions PublicOptions => base.Options;

        public ConcurrentDictionary<string, Lazy<IConnection>> PublicConnections => base.Connections;
    }

    private TestConnectionPool _testClass;
    private IFixture _fixture;
    private Mock<IOptions<RabbitMqOptions>> _options;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ConnectionPool"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._options = _fixture.Freeze<Mock<IOptions<RabbitMqOptions>>>();
        this._testClass = _fixture.Create<TestConnectionPool>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestConnectionPool(this._options.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new TestConnectionPool(default(IOptions<RabbitMqOptions>))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var connectionName = _fixture.Create<string>();

        // Act
        var result = this._testClass.Get(connectionName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the connectionName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetWithInvalidConnectionName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Get(value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionName");
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
    /// Checks that the PublicOptions property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicOptions()
    {
        // Assert
        this._testClass.PublicOptions.Should().BeAssignableTo<RabbitMqOptions>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicConnections property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicConnections()
    {
        // Assert
        this._testClass.PublicConnections.Should().BeAssignableTo<ConcurrentDictionary<string, Lazy<IConnection>>>();

        Assert.Fail("Create or modify test");
    }
}