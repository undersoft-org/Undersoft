using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Blob;
using Undersoft.SDK.Service.Data.Blob.Container;
using Undersoft.SDK.Service.Server.Resource.Container;

namespace Undersoft.SDK.Service.Server.UnitTests.Resource.Container;

/// <summary>
/// Unit tests for the type <see cref="ResourceFileContainer"/>.
/// </summary>
[TestClass]
public class ResourceFileContainerTests
{
    private ResourceFileContainer _testClass;
    private IFixture _fixture;
    private string _containerName;
    private BlobContainerConfiguration _configuration;
    private Mock<IBlobProvider> _provider;
    private Mock<IBlobNormalizeNamingService> _blobNormalizeNamingService;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ResourceFileContainer"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._containerName = _fixture.Create<string>();
        this._configuration = _fixture.Create<BlobContainerConfiguration>();
        this._provider = _fixture.Freeze<Mock<IBlobProvider>>();
        this._blobNormalizeNamingService = _fixture.Freeze<Mock<IBlobNormalizeNamingService>>();
        this._testClass = _fixture.Create<ResourceFileContainer>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ResourceFileContainer(this._containerName);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ResourceFileContainer(this._containerName, this._configuration, this._provider.Object, this._blobNormalizeNamingService.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfiguration()
    {
        FluentActions.Invoking(() => new ResourceFileContainer(this._containerName, default(BlobContainerConfiguration), this._provider.Object, this._blobNormalizeNamingService.Object)).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }

    /// <summary>
    /// Checks that instance construction throws when the provider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullProvider()
    {
        FluentActions.Invoking(() => new ResourceFileContainer(this._containerName, this._configuration, default(IBlobProvider), this._blobNormalizeNamingService.Object)).Should().Throw<ArgumentNullException>().WithParameterName("provider");
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
        FluentActions.Invoking(() => new ResourceFileContainer(value)).Should().Throw<ArgumentNullException>().WithParameterName("containerName");
        FluentActions.Invoking(() => new ResourceFileContainer(value, this._configuration, this._provider.Object, this._blobNormalizeNamingService.Object)).Should().Throw<ArgumentNullException>().WithParameterName("containerName");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var filename = _fixture.Create<string>();

        // Act
        var result = this._testClass.Get(filename);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the filename parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetWithInvalidFilename(string value)
    {
        FluentActions.Invoking(() => this._testClass.Get(value)).Should().Throw<ArgumentNullException>().WithParameterName("filename");
    }

    /// <summary>
    /// Checks that the Get maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetPerformsMapping()
    {
        // Arrange
        var filename = _fixture.Create<string>();

        // Act
        var result = this._testClass.Get(filename);

        // Assert
        result.FileName.Should().BeSameAs(filename);
    }
}