using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Query;

namespace Undersoft.SDK.Service.UnitTests.Data.Query;

/// <summary>
/// Unit tests for the type <see cref="FilterItem"/>.
/// </summary>
public class FilterItemTests
{
    private FilterItem _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="FilterItem"/>.
    /// </summary>
    public FilterItemTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<FilterItem>();
    }

    /// <summary>
    /// Checks that the Property property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProperty()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Property = testValue;

        // Assert
        this._testClass.Property.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Operand property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOperand()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Operand = testValue;

        // Assert
        this._testClass.Operand.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Data property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetData()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Data = testValue;

        // Assert
        this._testClass.Data.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Value property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetValue()
    {
        // Arrange
        var testValue = _fixture.Create<object>();

        // Act
        this._testClass.Value = testValue;

        // Assert
        this._testClass.Value.Should().BeSameAs(testValue);
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

    /// <summary>
    /// Checks that the Logic property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLogic()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Logic = testValue;

        // Assert
        this._testClass.Logic.Should().Be(testValue);
    }
}