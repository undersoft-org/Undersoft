using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Uniques.Hashing;

namespace Undersoft.SDK.UnitTests.Uniques.Hashing;

/// <summary>
/// Unit tests for the type <see cref="Hasher64"/>.
/// </summary>
public class Hasher64Tests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ComputeBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeBytesWithBytesAndLengthAndSeed()
    {
        // Arrange
        var bytes = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = Hasher64.ComputeBytes(bytes, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeBytesWithArrayOfByteAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = Hasher64.ComputeBytes(bytes, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeBytes method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeBytesWithArrayOfByteAndLongWithNullBytes()
    {
        FluentActions.Invoking(() => Hasher64.ComputeBytes(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the ComputeKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeKeyWithPtrAndLengthAndSeed()
    {
        // Arrange
        var ptr = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = Hasher64.ComputeKey(ptr, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeKeyWithArrayOfByteAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = Hasher64.ComputeKey(bytes, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeKey method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeKeyWithArrayOfByteAndLongWithNullBytes()
    {
        FluentActions.Invoking(() => Hasher64.ComputeKey(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }
}