using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event.Provider.RabbitMq;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="RabbitMqOptions"/>.
/// </summary>
[TestClass]
public class RabbitMqOptionsTests
{
    private RabbitMqOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RabbitMqOptions"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RabbitMqOptions>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RabbitMqOptions();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Connections property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetConnections()
    {
        // Assert
        this._testClass.Connections.Should().BeAssignableTo<RabbitMqConnections>();

        Assert.Fail("Create or modify test");
    }
}