using System;
using System.Threading;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob;
using Undersoft.SDK.Service.Data.Blob.Container;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob;

/// <summary>
/// Unit tests for the type <see cref="BlobProviderArgs"/>.
/// </summary>
public class BlobProviderArgsTests
{
    private BlobProviderArgs _testClass;
    private IFixture _fixture;
    private string _containerName;
    private BlobContainerConfiguration _configuration;
    private string _blobName;
    private CancellationToken _cancellationToken;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BlobProviderArgs"/>.
    /// </summary>
    public BlobProviderArgsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._containerName = _fixture.Create<string>();
        this._configuration = _fixture.Create<BlobContainerConfiguration>();
        this._blobName = _fixture.Create<string>();
        this._cancellationToken = _fixture.Create<CancellationToken>();
        this._testClass = _fixture.Create<BlobProviderArgs>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new BlobProviderArgs(this._containerName, this._configuration, this._blobName, this._cancellationToken);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfiguration()
    {
        FluentActions.Invoking(() => new BlobProviderArgs(this._containerName, default(BlobContainerConfiguration), this._blobName, this._cancellationToken)).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }

    /// <summary>
    /// Checks that the constructor throws when the containerName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidContainerName(string value)
    {
        FluentActions.Invoking(() => new BlobProviderArgs(value, this._configuration, this._blobName, this._cancellationToken)).Should().Throw<ArgumentNullException>().WithParameterName("containerName");
    }

    /// <summary>
    /// Checks that the constructor throws when the blobName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidBlobName(string value)
    {
        FluentActions.Invoking(() => new BlobProviderArgs(this._containerName, this._configuration, value, this._cancellationToken)).Should().Throw<ArgumentNullException>().WithParameterName("blobName");
    }
}