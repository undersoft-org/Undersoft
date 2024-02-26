using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMQ.Client;
using Undersoft.SDK.Service.Data.Event.Provider.RabbitMq;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="QueueDeclareConfiguration"/>.
/// </summary>
[TestClass]
public class QueueDeclareConfigurationTests
{
    private QueueDeclareConfiguration _testClass;
    private IFixture _fixture;
    private string _queueName;
    private bool _durable;
    private bool _exclusive;
    private bool _autoDelete;
    private ushort? _prefetchCount;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="QueueDeclareConfiguration"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._queueName = _fixture.Create<string>();
        this._durable = _fixture.Create<bool>();
        this._exclusive = _fixture.Create<bool>();
        this._autoDelete = _fixture.Create<bool>();
        this._prefetchCount = _fixture.Create<ushort?>();
        this._testClass = _fixture.Create<QueueDeclareConfiguration>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new QueueDeclareConfiguration(this._queueName, this._durable, this._exclusive, this._autoDelete, this._prefetchCount);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the queueName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidQueueName(string value)
    {
        FluentActions.Invoking(() => new QueueDeclareConfiguration(value, this._durable, this._exclusive, this._autoDelete, this._prefetchCount)).Should().Throw<ArgumentNullException>().WithParameterName("queueName");
    }

    /// <summary>
    /// Checks that the Declare method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeclare()
    {
        // Arrange
        var channel = _fixture.Create<IModel>();

        // Act
        var result = this._testClass.Declare(channel);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Declare method throws when the channel parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeclareWithNullChannel()
    {
        FluentActions.Invoking(() => this._testClass.Declare(default(IModel))).Should().Throw<ArgumentNullException>().WithParameterName("channel");
    }

    /// <summary>
    /// Checks that the Durable property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDurable()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.Durable = testValue;

        // Assert
        this._testClass.Durable.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Exclusive property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetExclusive()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.Exclusive = testValue;

        // Assert
        this._testClass.Exclusive.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the AutoDelete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAutoDelete()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.AutoDelete = testValue;

        // Assert
        this._testClass.AutoDelete.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the PrefetchCount property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPrefetchCount()
    {
        // Arrange
        var testValue = _fixture.Create<ushort?>();

        // Act
        this._testClass.PrefetchCount = testValue;

        // Assert
        this._testClass.PrefetchCount.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Arguments property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetArguments()
    {
        // Assert
        this._testClass.Arguments.Should().BeAssignableTo<IDictionary<string, object>>();

        Assert.Fail("Create or modify test");
    }
}