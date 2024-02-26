using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="IntPtrBinaryExtension"/>.
/// </summary>
public class IntPtrBinaryExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the And method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAnd()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var value = _fixture.Create<nint>();

        // Act
        var result = pointer.And(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Not method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNot()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();

        // Act
        var result = pointer.Not();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Or method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOr()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var value = _fixture.Create<nint>();

        // Act
        var result = pointer.Or(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Xor method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallXor()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var value = _fixture.Create<nint>();

        // Act
        var result = pointer.Xor(value);

        // Assert
        Assert.Fail("Create or modify test");
    }
}