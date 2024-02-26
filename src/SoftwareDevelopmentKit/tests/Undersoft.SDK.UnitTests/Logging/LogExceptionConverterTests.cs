using System;
using System.Text.Json;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Logging;

namespace Undersoft.SDK.UnitTests.Logging;

/// <summary>
/// Unit tests for the type <see cref="LogExceptionConverter"/>.
/// </summary>
public class LogExceptionConverterTests
{
    private LogExceptionConverter _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="LogExceptionConverter"/>.
    /// </summary>
    public LogExceptionConverterTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<LogExceptionConverter>();
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
        var result = this._testClass.Read(ref reader, typeToConvert, options
        );

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
        var value = _fixture.Create<Exception>();
        var options = _fixture.Create<JsonSerializerOptions>();

        // Act
        this._testClass.Write(writer, value, options
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method throws when the writer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithNullWriter()
    {
        FluentActions.Invoking(() => this._testClass.Write(default(Utf8JsonWriter), _fixture.Create<Exception>(), _fixture.Create<JsonSerializerOptions>())).Should().Throw<ArgumentNullException>().WithParameterName("writer");
    }

    /// <summary>
    /// Checks that the Write method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Write(_fixture.Create<Utf8JsonWriter>(), default(Exception), _fixture.Create<JsonSerializerOptions>())).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Write method throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithNullOptions()
    {
        FluentActions.Invoking(() => this._testClass.Write(_fixture.Create<Utf8JsonWriter>(), _fixture.Create<Exception>(), default(JsonSerializerOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }
}