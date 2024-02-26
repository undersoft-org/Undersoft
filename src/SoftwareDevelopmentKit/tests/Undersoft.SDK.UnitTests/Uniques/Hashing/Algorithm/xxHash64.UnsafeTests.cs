using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Uniques.Hashing.Algorithm;

namespace Undersoft.SDK.UnitTests.Uniques.Hashing.Algorithm;

/// <summary>
/// Unit tests for the type <see cref="xxHash64"/>.
/// </summary>
public partial class xxHash64Tests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the UnsafeComputeHash method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUnsafeComputeHash()
    {
        // Arrange
        var ptr = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<ulong>();

        // Act
        var result = xxHash64.UnsafeComputeHash(ptr, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }
}