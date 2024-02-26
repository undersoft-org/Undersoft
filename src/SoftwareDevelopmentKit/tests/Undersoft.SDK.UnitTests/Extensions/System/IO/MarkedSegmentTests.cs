using System;
using System.IO;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="MarkedSegment"/>.
/// </summary>
public class MarkedSegmentTests
{
    private MarkedSegment _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MarkedSegment"/>.
    /// </summary>
    public MarkedSegmentTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<MarkedSegment>();
    }

    /// <summary>
    /// Checks that the ItemOffset method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallItemOffset()
    {
        // Arrange
        var index = _fixture.Create<int>();

        // Act
        var result = this._testClass.ItemOffset(index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Count property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetCount()
    {
        // Assert
        this._testClass.Count.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }
}