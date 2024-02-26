using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Event.Provider.RabbitMq;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="RabbitMqMessageConsumerFactory"/>.
/// </summary>
[TestClass]
public class RabbitMqMessageConsumerFactoryTests
{
    private class TestRabbitMqMessageConsumerFactory : RabbitMqMessageConsumerFactory
    {
        public TestRabbitMqMessageConsumerFactory(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public IServiceScope PublicServiceScope => base.ServiceScope;
    }

    private TestRabbitMqMessageConsumerFactory _testClass;
    private IFixture _fixture;
    private Mock<IServiceScopeFactory> _serviceScopeFactory;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RabbitMqMessageConsumerFactory"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._serviceScopeFactory = _fixture.Freeze<Mock<IServiceScopeFactory>>();
        this._testClass = _fixture.Create<TestRabbitMqMessageConsumerFactory>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRabbitMqMessageConsumerFactory(this._serviceScopeFactory.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceScopeFactory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceScopeFactory()
    {
        FluentActions.Invoking(() => new TestRabbitMqMessageConsumerFactory(default(IServiceScopeFactory))).Should().Throw<ArgumentNullException>().WithParameterName("serviceScopeFactory");
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreate()
    {
        // Arrange
        var exchange = _fixture.Create<ExchangeDeclareConfiguration>();
        var queue = _fixture.Create<QueueDeclareConfiguration>();
        var connectionName = _fixture.Create<string>();

        // Act
        var result = this._testClass.Create(exchange, queue, connectionName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method throws when the exchange parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateWithNullExchange()
    {
        FluentActions.Invoking(() => this._testClass.Create(default(ExchangeDeclareConfiguration), _fixture.Create<QueueDeclareConfiguration>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("exchange");
    }

    /// <summary>
    /// Checks that the Create method throws when the queue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateWithNullQueue()
    {
        FluentActions.Invoking(() => this._testClass.Create(_fixture.Create<ExchangeDeclareConfiguration>(), default(QueueDeclareConfiguration), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("queue");
    }

    /// <summary>
    /// Checks that the Create method throws when the connectionName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCreateWithInvalidConnectionName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Create(_fixture.Create<ExchangeDeclareConfiguration>(), _fixture.Create<QueueDeclareConfiguration>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionName");
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
    /// Checks that the PublicServiceScope property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicServiceScope()
    {
        // Assert
        this._testClass.PublicServiceScope.Should().BeAssignableTo<IServiceScope>();

        Assert.Fail("Create or modify test");
    }
}