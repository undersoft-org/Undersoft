using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T = System.String;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="IntPtrArithmeticExtension"/>.
/// </summary>
public class IntPtrArithmeticExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Decrement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDecrementWithNintAndInt()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var value = _fixture.Create<int>();

        // Act
        var result = pointer.Decrement(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Decrement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDecrementWithNintAndLong()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var value = _fixture.Create<long>();

        // Act
        var result = pointer.Decrement(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Decrement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDecrementWithNintAndNint()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var value = _fixture.Create<nint>();

        // Act
        var result = pointer.Decrement(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Increment method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIncrementWithNintAndInt()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var value = _fixture.Create<int>();

        // Act
        var result = pointer.Increment(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Increment method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIncrementWithNintAndLong()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var value = _fixture.Create<long>();

        // Act
        var result = pointer.Increment(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Increment method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIncrementWithNintAndNint()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var value = _fixture.Create<nint>();

        // Act
        var result = pointer.Increment(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Increment method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIncrementWithPtr()
    {
        // Arrange
        var ptr = _fixture.Create<nint>();

        // Act
        var result = ptr.Increment<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }
}