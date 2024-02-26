using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="BinaryJsonConverter"/>.
/// </summary>
public class BinaryJsonConverterTests
{
    private BinaryJsonConverter _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BinaryJsonConverter"/>.
    /// </summary>
    public BinaryJsonConverterTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<BinaryJsonConverter>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new BinaryJsonConverter();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRead()
    {
        // Arrange
        var reader = _fixture.Create<Utf8JsonReader>();
        var typeToConvert = _fixture.Create<Type>();
        var options = _fixture.Create<JsonSerializerOptions>();

        // Act
        var result = this._testClass.Read(ref reader, typeToConvert, options);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method throws when the typeToConvert parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithNullTypeToConvert()
    {
        var reader = _fixture.Create<Utf8JsonReader>();
        FluentActions.Invoking(() => this._testClass.Read(ref reader, default(Type), _fixture.Create<JsonSerializerOptions>())).Should().Throw<ArgumentNullException>().WithParameterName("typeToConvert");
    }

    /// <summary>
    /// Checks that the Read method throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithNullOptions()
    {
        var reader = _fixture.Create<Utf8JsonReader>();
        FluentActions.Invoking(() => this._testClass.Read(ref reader, _fixture.Create<Type>(), default(JsonSerializerOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWrite()
    {
        // Arrange
        var writer = _fixture.Create<Utf8JsonWriter>();
        var value = _fixture.Create<byte[]>();
        var options = _fixture.Create<JsonSerializerOptions>();

        // Act
        this._testClass.Write(writer, value, options);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method throws when the writer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithNullWriter()
    {
        FluentActions.Invoking(() => this._testClass.Write(default(Utf8JsonWriter), _fixture.Create<byte[]>(), _fixture.Create<JsonSerializerOptions>())).Should().Throw<ArgumentNullException>().WithParameterName("writer");
    }

    /// <summary>
    /// Checks that the Write method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Write(_fixture.Create<Utf8JsonWriter>(), default(byte[]), _fixture.Create<JsonSerializerOptions>())).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Write method throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithNullOptions()
    {
        FluentActions.Invoking(() => this._testClass.Write(_fixture.Create<Utf8JsonWriter>(), _fixture.Create<byte[]>(), default(JsonSerializerOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }
}