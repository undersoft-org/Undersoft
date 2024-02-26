using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Uniques.Hashing.Algorithm;

namespace Undersoft.SDK.UnitTests.Uniques.Hashing.Algorithm;

/// <summary>
/// Unit tests for the type <see cref="xxHash32"/>.
/// </summary>
public partial class xxHash32Tests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ComputeHash method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeHashWithReadOnlySpanOfByteAndIntAndUint()
    {
        // Arrange
        var data = _fixture.Create<ReadOnlySpan<byte>>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<uint>();

        // Act
        var result = xxHash32.ComputeHash(data, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeHash method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeHashWithSpanOfByteAndIntAndUint()
    {
        // Arrange
        var data = _fixture.Create<Span<byte>>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<uint>();

        // Act
        var result = xxHash32.ComputeHash(data, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }
}