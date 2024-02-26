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
    public void CanCallComputeHashWithDataAndSeed()
    {
        // Arrange
        var data = _fixture.Create<ArraySegment<byte>>();
        var seed = _fixture.Create<uint>();

        // Act
        var result = xxHash32.ComputeHash(data, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeHash method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeHashWithDataAndLengthAndSeed()
    {
        // Arrange
        var data = _fixture.Create<byte[]>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<uint>();

        // Act
        var result = xxHash32.ComputeHash(data, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeHash method throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeHashWithDataAndLengthAndSeedWithNullData()
    {
        FluentActions.Invoking(() => xxHash32.ComputeHash(default(byte[]), _fixture.Create<int>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that the ComputeHash method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeHashWithDataAndOffsetAndLengthAndSeed()
    {
        // Arrange
        var data = _fixture.Create<byte[]>();
        var offset = _fixture.Create<int>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<uint>();

        // Act
        var result = xxHash32.ComputeHash(data, offset, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeHash method throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeHashWithDataAndOffsetAndLengthAndSeedWithNullData()
    {
        FluentActions.Invoking(() => xxHash32.ComputeHash(default(byte[]), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }
}