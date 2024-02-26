using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event.Provider.RabbitMq;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ExchangeDeclareConfiguration"/>.
/// </summary>
[TestClass]
public class ExchangeDeclareConfigurationTests
{
    private ExchangeDeclareConfiguration _testClass;
    private IFixture _fixture;
    private string _exchangeName;
    private string _type;
    private bool _durable;
    private bool _autoDelete;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ExchangeDeclareConfiguration"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._exchangeName = _fixture.Create<string>();
        this._type = _fixture.Create<string>();
        this._durable = _fixture.Create<bool>();
        this._autoDelete = _fixture.Create<bool>();
        this._testClass = _fixture.Create<ExchangeDeclareConfiguration>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ExchangeDeclareConfiguration(this._exchangeName, this._type, this._durable, this._autoDelete);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the exchangeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidExchangeName(string value)
    {
        FluentActions.Invoking(() => new ExchangeDeclareConfiguration(value, this._type, this._durable, this._autoDelete)).Should().Throw<ArgumentNullException>().WithParameterName("exchangeName");
    }

    /// <summary>
    /// Checks that the constructor throws when the type parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidType(string value)
    {
        FluentActions.Invoking(() => new ExchangeDeclareConfiguration(this._exchangeName, value, this._durable, this._autoDelete)).Should().Throw<ArgumentNullException>().WithParameterName("type");
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