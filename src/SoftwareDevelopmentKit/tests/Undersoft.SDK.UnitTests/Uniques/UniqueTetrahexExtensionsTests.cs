using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="UniqueTetrahexExtensions"/>.
/// </summary>
public class UniqueTetrahexExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ToTetrahexByte method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToTetrahexByte()
    {
        // Arrange
        var phchar = _fixture.Create<char>();

        // Act
        var result = phchar.ToTetrahexByte();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToTetrahexChar method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToTetrahexChar()
    {
        // Arrange
        var phbyte = _fixture.Create<byte>();

        // Act
        var result = phbyte.ToTetrahexChar();

        // Assert
        Assert.Fail("Create or modify test");
    }
}