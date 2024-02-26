using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob;

/// <summary>
/// Unit tests for the type <see cref="BlobProviderBase"/>.
/// </summary>
public class BlobProviderBaseTests
{
    private class TestBlobProviderBase : BlobProviderBase
    {
        public Task<Stream> PublicTryCopyToMemoryStreamAsync(Stream stream, CancellationToken cancellationToken)
        {
            return base.TryCopyToMemoryStreamAsync(stream, cancellationToken);
        }

        public override Task SaveAsync(BlobProviderSaveArgs args)
        {
            return default(Task);
        }

        public override Task<bool> DeleteAsync(BlobProviderArgs args)
        {
            return default(Task<bool>);
        }

        public override Task<bool> ExistsAsync(BlobProviderArgs args)
        {
            return default(Task<bool>);
        }

        public override Task<Stream> GetOrNullAsync(BlobProviderArgs args)
        {
            return default(Task<Stream>);
        }
    }

    private TestBlobProviderBase _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BlobProviderBase"/>.
    /// </summary>
    public BlobProviderBaseTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestBlobProviderBase>();
    }

    /// <summary>
    /// Checks that the PublicTryCopyToMemoryStreamAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallTryCopyToMemoryStreamAsync()
    {
        // Arrange
        var stream = _fixture.Create<Stream>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.PublicTryCopyToMemoryStreamAsync(stream, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicTryCopyToMemoryStreamAsync method throws when the stream parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallTryCopyToMemoryStreamAsyncWithNullStreamAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicTryCopyToMemoryStreamAsync(default(Stream), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("stream");
    }
}