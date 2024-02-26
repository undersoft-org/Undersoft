using System;
using System.IO;
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
    /// Checks that the ComputeHash method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeHash()
    {
        // Arrange
        var stream = _fixture.Create<Stream>();
        var bufferSize = _fixture.Create<int>();
        var seed = _fixture.Create<ulong>();

        // Act
        var result = xxHash64.ComputeHash(stream, bufferSize, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeHash method throws when the stream parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeHashWithNullStream()
    {
        FluentActions.Invoking(() => xxHash64.ComputeHash(default(Stream), _fixture.Create<int>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("stream");
    }
}