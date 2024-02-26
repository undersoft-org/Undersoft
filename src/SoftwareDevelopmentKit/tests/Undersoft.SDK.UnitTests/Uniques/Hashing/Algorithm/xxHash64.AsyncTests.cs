using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
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
    /// Checks that the ComputeHashAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallComputeHashAsyncWithStreamAndBufferSizeAndSeedAsync()
    {
        // Arrange
        var stream = _fixture.Create<Stream>();
        var bufferSize = _fixture.Create<int>();
        var seed = _fixture.Create<ulong>();

        // Act
        var result = await xxHash64.ComputeHashAsync(stream, bufferSize, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeHashAsync method throws when the stream parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallComputeHashAsyncWithStreamAndBufferSizeAndSeedWithNullStreamAsync()
    {
        await FluentActions.Invoking(() => xxHash64.ComputeHashAsync(default(Stream), _fixture.Create<int>(), _fixture.Create<ulong>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("stream");
    }

    /// <summary>
    /// Checks that the ComputeHashAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallComputeHashAsyncWithStreamAndBufferSizeAndSeedAndCancellationTokenAsync()
    {
        // Arrange
        var stream = _fixture.Create<Stream>();
        var bufferSize = _fixture.Create<int>();
        var seed = _fixture.Create<ulong>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await xxHash64.ComputeHashAsync(stream, bufferSize, seed, cancellationToken
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeHashAsync method throws when the stream parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallComputeHashAsyncWithStreamAndBufferSizeAndSeedAndCancellationTokenWithNullStreamAsync()
    {
        await FluentActions.Invoking(() => xxHash64.ComputeHashAsync(default(Stream), _fixture.Create<int>(), _fixture.Create<ulong>(), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("stream");
    }
}