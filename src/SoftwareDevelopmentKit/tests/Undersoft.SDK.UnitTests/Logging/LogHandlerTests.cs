using System;
using System.Text.Json;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog.Events;
using Undersoft.SDK.Logging;
using TState = System.String;

namespace Undersoft.SDK.UnitTests.Logging;

/// <summary>
/// Unit tests for the type <see cref="LogHandler"/>.
/// </summary>
public class LogHandlerTests
{
    private LogHandler _testClass;
    private IFixture _fixture;
    private JsonSerializerOptions _jsonoptions;
    private LogEventLevel _level;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="LogHandler"/>.
    /// </summary>
    public LogHandlerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._jsonoptions = _fixture.Create<JsonSerializerOptions>();
        this._level = _fixture.Create<LogEventLevel>();
        this._testClass = _fixture.Create<LogHandler>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new LogHandler(this._jsonoptions, this._level);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the jsonoptions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullJsonoptions()
    {
        FluentActions.Invoking(() => new LogHandler(default(JsonSerializerOptions), this._level)).Should().Throw<ArgumentNullException>().WithParameterName("jsonoptions");
    }

    /// <summary>
    /// Checks that the GetLogger method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetLogger()
    {
        // Arrange
        var state = _fixture.Create<TState>();

        // Act
        var result = this._testClass.GetLogger<TState>(state);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Clean method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClean()
    {
        // Arrange
        var olderThen = _fixture.Create<DateTime>();

        // Act
        var result = this._testClass.Clean(olderThen);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsEnabled method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsEnabled()
    {
        // Arrange
        var logLevel = _fixture.Create<LogEventLevel>();

        // Act
        var result = this._testClass.IsEnabled(logLevel);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWrite()
    {
        // Arrange
        var log = _fixture.Create<Starlog>();

        // Act
        this._testClass.Write(log);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method throws when the log parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithNullLog()
    {
        FluentActions.Invoking(() => this._testClass.Write(default(Starlog))).Should().Throw<ArgumentNullException>().WithParameterName("log");
    }

    /// <summary>
    /// Checks that the SetLevel method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetLevel()
    {
        // Arrange
        var level = _fixture.Create<LogEventLevel>();

        // Act
        this._testClass.SetLevel(level);

        // Assert
        Assert.Fail("Create or modify test");
    }
}