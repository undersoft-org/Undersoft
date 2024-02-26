using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Logging;

namespace Undersoft.SDK.UnitTests.Logging;

/// <summary>
/// Unit tests for the type <see cref="LogMessage"/>.
/// </summary>
public class LogMessageTests
{
    private LogMessage _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="LogMessage"/>.
    /// </summary>
    public LogMessageTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<LogMessage>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new LogMessage();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Id property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.Id = testValue;

        // Assert
        this._testClass.Id.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Level property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLevel()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.Level = testValue;

        // Assert
        this._testClass.Level.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Message property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMessage()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Message = testValue;

        // Assert
        this._testClass.Message.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Milliseconds property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMilliseconds()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.Milliseconds = testValue;

        // Assert
        this._testClass.Milliseconds.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Time property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTime()
    {
        // Arrange
        var testValue = _fixture.Create<DateTime>();

        // Act
        this._testClass.Time = testValue;

        // Assert
        this._testClass.Time.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Type property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetType()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Type = testValue;

        // Assert
        this._testClass.Type.Should().Be(testValue);
    }
}