using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event.Provider.RabbitMq;
using T = System.String;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="Utf8JsonRabbitMqSerializer"/>.
/// </summary>
[TestClass]
public class Utf8JsonRabbitMqSerializerTests
{
    private Utf8JsonRabbitMqSerializer _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Utf8JsonRabbitMqSerializer"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Utf8JsonRabbitMqSerializer>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Utf8JsonRabbitMqSerializer();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Serialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSerializeWithObject()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = this._testClass.Serialize(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Serialize method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSerializeWithObjectWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Serialize(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Serialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSerializeWithT()
    {
        // Arrange
        var obj = _fixture.Create<T>();

        // Act
        var result = this._testClass.Serialize<T>(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Deserialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeserializeWithValueAndType()
    {
        // Arrange
        var value = _fixture.Create<byte[]>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.Deserialize(value, type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Deserialize method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeserializeWithValueAndTypeWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Deserialize(default(byte[]), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Deserialize method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeserializeWithValueAndTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.Deserialize(_fixture.Create<byte[]>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the Deserialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeserializeWithValue()
    {
        // Arrange
        var value = _fixture.Create<byte[]>();

        // Act
        var result = this._testClass.Deserialize<T>(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Deserialize method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeserializeWithValueWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Deserialize<T>(default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }
}