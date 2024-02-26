using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="IntPtrComparisionExtension"/>.
/// </summary>
public class IntPtrComparisionExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithNintAndInt()
    {
        // Arrange
        var left = _fixture.Create<nint>();
        var right = _fixture.Create<int>();

        // Act
        var result = left.CompareTo(right);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithNintAndNint()
    {
        // Arrange
        var left = _fixture.Create<nint>();
        var right = _fixture.Create<nint>();

        // Act
        var result = left.CompareTo(right);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithNintAndUint()
    {
        // Arrange
        var left = _fixture.Create<nint>();
        var right = _fixture.Create<uint>();

        // Act
        var result = left.CompareTo(right);

        // Assert
        Assert.Fail("Create or modify test");
    }
}