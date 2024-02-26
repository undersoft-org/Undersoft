using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="IntPtrEqualityExtension"/>.
/// </summary>
public class IntPtrEqualityExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithLeftAndPtr2()
    {
        // Arrange
        var left = _fixture.Create<nint>();
        var ptr2 = _fixture.Create<nint>();

        // Act
        var result = left.Equals(ptr2);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithNintAndInt()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var value = _fixture.Create<int>();

        // Act
        var result = pointer.Equals(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithNintAndLong()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var value = _fixture.Create<long>();

        // Act
        var result = pointer.Equals(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithNintAndUint()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var value = _fixture.Create<uint>();

        // Act
        var result = pointer.Equals(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithNintAndUlong()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var value = _fixture.Create<ulong>();

        // Act
        var result = pointer.Equals(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithArrayOfNintAndArrayOfNint()
    {
        // Arrange
        var left = _fixture.Create<nint[]>();
        var right = _fixture.Create<nint[]>();

        // Act
        var result = left.Equals(right);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the left parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithArrayOfNintAndArrayOfNintWithNullLeft()
    {
        FluentActions.Invoking(() => default(nint[]).Equals(_fixture.Create<nint[]>())).Should().Throw<ArgumentNullException>().WithParameterName("left");
    }

    /// <summary>
    /// Checks that the Equals method throws when the right parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithArrayOfNintAndArrayOfNintWithNullRight()
    {
        FluentActions.Invoking(() => _fixture.Create<nint[]>().Equals(default(nint[]))).Should().Throw<ArgumentNullException>().WithParameterName("right");
    }

    /// <summary>
    /// Checks that the isGreaterThanOrEqualTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallisGreaterThanOrEqualTo()
    {
        // Arrange
        var left = _fixture.Create<nint>();
        var right = _fixture.Create<nint>();

        // Act
        var result = left.isGreaterThanOrEqualTo(right);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsLessThanOrEqualTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsLessThanOrEqualTo()
    {
        // Arrange
        var left = _fixture.Create<nint>();
        var right = _fixture.Create<nint>();

        // Act
        var result = left.IsLessThanOrEqualTo(right);

        // Assert
        Assert.Fail("Create or modify test");
    }
}