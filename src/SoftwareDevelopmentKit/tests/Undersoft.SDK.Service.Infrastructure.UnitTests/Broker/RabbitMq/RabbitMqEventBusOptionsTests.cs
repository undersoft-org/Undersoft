using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event.Provider.RabbitMq;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="RabbitMqEventBusOptions"/>.
/// </summary>
[TestClass]
public class RabbitMqEventBusOptionsTests
{
    private RabbitMqEventBusOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RabbitMqEventBusOptions"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RabbitMqEventBusOptions>();
    }

    /// <summary>
    /// Checks that the GetExchangeTypeOrDefault method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetExchangeTypeOrDefault()
    {
        // Act
        var result = this._testClass.GetExchangeTypeOrDefault();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ConnectionName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetConnectionName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ConnectionName = testValue;

        // Assert
        this._testClass.ConnectionName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the ClientName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClientName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ClientName = testValue;

        // Assert
        this._testClass.ClientName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the ExchangeName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetExchangeName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ExchangeName = testValue;

        // Assert
        this._testClass.ExchangeName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the ExchangeType property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetExchangeType()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ExchangeType = testValue;

        // Assert
        this._testClass.ExchangeType.Should().Be(testValue);
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
}