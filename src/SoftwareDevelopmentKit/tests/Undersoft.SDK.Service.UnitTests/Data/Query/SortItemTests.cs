using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Query;

namespace Undersoft.SDK.Service.UnitTests.Data.Query;

/// <summary>
/// Unit tests for the type <see cref="SortItem"/>.
/// </summary>
public class SortItemTests
{
    private SortItem _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SortItem"/>.
    /// </summary>
    public SortItemTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<SortItem>();
    }

    /// <summary>
    /// Checks that the Direction property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDirection()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Direction = testValue;

        // Assert
        this._testClass.Direction.Should().Be(testValue);
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
}