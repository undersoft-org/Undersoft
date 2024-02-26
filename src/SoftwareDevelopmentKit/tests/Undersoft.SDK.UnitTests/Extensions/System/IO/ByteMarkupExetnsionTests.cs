using System;
using System.IO;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ByteMarkupExtension"/>.
/// </summary>
public class ByteMarkupExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the IsMarkup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsMarkup()
    {
        // Arrange
        var checknoise = _fixture.Create<byte>();

        // Act
        var result = checknoise.IsMarkup(out var noisekind);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsSpliter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsSpliter()
    {
        // Arrange
        var checknoise = _fixture.Create<byte>();

        // Act
        var result = checknoise.IsSpliter(out var spliterkind);

        // Assert
        Assert.Fail("Create or modify test");
    }
}