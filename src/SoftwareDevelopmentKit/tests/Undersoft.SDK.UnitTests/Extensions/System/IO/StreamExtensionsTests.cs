using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="StreamExtensions"/>.
/// </summary>
public class StreamExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetAllBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetAllBytes()
    {
        // Arrange
        var stream = _fixture.Create<Stream>();

        // Act
        var result = stream.GetAllBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetAllBytes method throws when the stream parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetAllBytesWithNullStream()
    {
        FluentActions.Invoking(() => default(Stream).GetAllBytes()).Should().Throw<ArgumentNullException>().WithParameterName("stream");
    }

    /// <summary>
    /// Checks that the GetAllBytesAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetAllBytesAsync()
    {
        // Arrange
        var stream = _fixture.Create<Stream>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await stream.GetAllBytesAsync(cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetAllBytesAsync method throws when the stream parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetAllBytesAsyncWithNullStreamAsync()
    {
        await FluentActions.Invoking(() => default(Stream).GetAllBytesAsync(_fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("stream");
    }

    /// <summary>
    /// Checks that the CopyToAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallCopyToAsync()
    {
        // Arrange
        var stream = _fixture.Create<Stream>();
        var destination = _fixture.Create<Stream>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        await stream.CopyToAsync(destination, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyToAsync method throws when the stream parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallCopyToAsyncWithNullStreamAsync()
    {
        await FluentActions.Invoking(() => default(Stream).CopyToAsync(_fixture.Create<Stream>(), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("stream");
    }

    /// <summary>
    /// Checks that the CopyToAsync method throws when the destination parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallCopyToAsyncWithNullDestinationAsync()
    {
        await FluentActions.Invoking(() => _fixture.Create<Stream>().CopyToAsync(default(Stream), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("destination");
    }
}