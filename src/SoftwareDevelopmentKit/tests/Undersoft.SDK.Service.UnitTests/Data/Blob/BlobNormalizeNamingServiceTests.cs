using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Blob;
using Undersoft.SDK.Service.Data.Blob.Container;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob;

/// <summary>
/// Unit tests for the type <see cref="BlobNormalizeNamingService"/>.
/// </summary>
public class BlobNormalizeNamingServiceTests
{
    private BlobNormalizeNamingService _testClass;
    private IFixture _fixture;
    private Mock<IServiceProvider> _serviceProvider;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BlobNormalizeNamingService"/>.
    /// </summary>
    public BlobNormalizeNamingServiceTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._serviceProvider = _fixture.Freeze<Mock<IServiceProvider>>();
        this._testClass = _fixture.Create<BlobNormalizeNamingService>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new BlobNormalizeNamingService(this._serviceProvider.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceProvider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceProvider()
    {
        FluentActions.Invoking(() => new BlobNormalizeNamingService(default(IServiceProvider))).Should().Throw<ArgumentNullException>().WithParameterName("serviceProvider");
    }

    /// <summary>
    /// Checks that the NormalizeNaming method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNormalizeNaming()
    {
        // Arrange
        var configuration = _fixture.Create<BlobContainerConfiguration>();
        var containerName = _fixture.Create<string>();
        var blobName = _fixture.Create<string>();

        // Act
        var result = this._testClass.NormalizeNaming(configuration, containerName, blobName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NormalizeNaming method throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNormalizeNamingWithNullConfiguration()
    {
        FluentActions.Invoking(() => this._testClass.NormalizeNaming(default(BlobContainerConfiguration), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }

    /// <summary>
    /// Checks that the NormalizeNaming method throws when the containerName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNormalizeNamingWithInvalidContainerName(string value)
    {
        FluentActions.Invoking(() => this._testClass.NormalizeNaming(_fixture.Create<BlobContainerConfiguration>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("containerName");
    }

    /// <summary>
    /// Checks that the NormalizeNaming method throws when the blobName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNormalizeNamingWithInvalidBlobName(string value)
    {
        FluentActions.Invoking(() => this._testClass.NormalizeNaming(_fixture.Create<BlobContainerConfiguration>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("blobName");
    }

    /// <summary>
    /// Checks that the NormalizeNaming maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NormalizeNamingPerformsMapping()
    {
        // Arrange
        var configuration = _fixture.Create<BlobContainerConfiguration>();
        var containerName = _fixture.Create<string>();
        var blobName = _fixture.Create<string>();

        // Act
        var result = this._testClass.NormalizeNaming(configuration, containerName, blobName);

        // Assert
        result.ContainerName.Should().BeSameAs(containerName);
        result.BlobName.Should().BeSameAs(blobName);
    }

    /// <summary>
    /// Checks that the NormalizeContainerName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNormalizeContainerName()
    {
        // Arrange
        var configuration = _fixture.Create<BlobContainerConfiguration>();
        var containerName = _fixture.Create<string>();

        // Act
        var result = this._testClass.NormalizeContainerName(configuration, containerName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NormalizeContainerName method throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNormalizeContainerNameWithNullConfiguration()
    {
        FluentActions.Invoking(() => this._testClass.NormalizeContainerName(default(BlobContainerConfiguration), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }

    /// <summary>
    /// Checks that the NormalizeContainerName method throws when the containerName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNormalizeContainerNameWithInvalidContainerName(string value)
    {
        FluentActions.Invoking(() => this._testClass.NormalizeContainerName(_fixture.Create<BlobContainerConfiguration>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("containerName");
    }

    /// <summary>
    /// Checks that the NormalizeBlobName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNormalizeBlobName()
    {
        // Arrange
        var configuration = _fixture.Create<BlobContainerConfiguration>();
        var blobName = _fixture.Create<string>();

        // Act
        var result = this._testClass.NormalizeBlobName(configuration, blobName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NormalizeBlobName method throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNormalizeBlobNameWithNullConfiguration()
    {
        FluentActions.Invoking(() => this._testClass.NormalizeBlobName(default(BlobContainerConfiguration), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }

    /// <summary>
    /// Checks that the NormalizeBlobName method throws when the blobName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNormalizeBlobNameWithInvalidBlobName(string value)
    {
        FluentActions.Invoking(() => this._testClass.NormalizeBlobName(_fixture.Create<BlobContainerConfiguration>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("blobName");
    }
}