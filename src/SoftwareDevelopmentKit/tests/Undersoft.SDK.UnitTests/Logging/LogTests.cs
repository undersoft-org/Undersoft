using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog.Events;
using Undersoft.SDK.Logging;

namespace Undersoft.SDK.UnitTests.Logging;

/// <summary>
/// Unit tests for the type <see cref="Log"/>.
/// </summary>
public partial class LogTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAdd()
    {
        // Arrange
        var logLevel = _fixture.Create<LogEventLevel>();
        var category = _fixture.Create<string>();
        var message = _fixture.Create<string>();
        var state = _fixture.Create<ILogSate>();

        // Act
        Log.Add(logLevel, category, message, state);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the state parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithNullState()
    {
        FluentActions.Invoking(() => Log.Add(_fixture.Create<LogEventLevel>(), _fixture.Create<string>(), _fixture.Create<string>(), default(ILogSate))).Should().Throw<ArgumentNullException>().WithParameterName("state");
    }

    /// <summary>
    /// Checks that the Add method throws when the category parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallAddWithInvalidCategory(string value)
    {
        FluentActions.Invoking(() => Log.Add(_fixture.Create<LogEventLevel>(), value, _fixture.Create<string>(), _fixture.Create<ILogSate>())).Should().Throw<ArgumentNullException>().WithParameterName("category");
    }

    /// <summary>
    /// Checks that the Add method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallAddWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => Log.Add(_fixture.Create<LogEventLevel>(), _fixture.Create<string>(), value, _fixture.Create<ILogSate>())).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the ClearLog method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClearLog()
    {
        // Act
        Log.ClearLog();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateHandler method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateHandler()
    {
        // Arrange
        var level = _fixture.Create<LogEventLevel>();

        // Act
        Log.CreateHandler(level);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetLevel method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetLevel()
    {
        // Arrange
        var logLevel = _fixture.Create<int>();

        // Act
        Log.SetLevel(logLevel);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Start method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStart()
    {
        // Arrange
        var logLevel = _fixture.Create<int>();

        // Act
        Log.Start(logLevel);

        // Assert
        Assert.Fail("Create or modify test");
    }
}