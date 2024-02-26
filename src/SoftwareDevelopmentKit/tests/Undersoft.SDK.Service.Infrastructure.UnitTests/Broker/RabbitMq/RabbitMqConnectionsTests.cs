using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMQ.Client;
using Undersoft.SDK.Service.Data.Event.Provider.RabbitMq;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="RabbitMqConnections"/>.
/// </summary>
[TestClass]
public class RabbitMqConnectionsTests
{
    private RabbitMqConnections _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RabbitMqConnections"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RabbitMqConnections>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RabbitMqConnections();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the GetOrDefault method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetOrDefault()
    {
        // Arrange
        var connectionName = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetOrDefault(connectionName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetOrDefault method throws when the connectionName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetOrDefaultWithInvalidConnectionName(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetOrDefault(value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionName");
    }

    /// <summary>
    /// Checks that setting the Default property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDefault()
    {
        this._testClass.CheckProperty(x => x.Default, _fixture.Create<ConnectionFactory>(), _fixture.Create<ConnectionFactory>());
    }
}