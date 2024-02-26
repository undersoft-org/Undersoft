using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Blob;
using Undersoft.SDK.Service.Data.Blob.Container;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob.Container;

/// <summary>
/// Unit tests for the type <see cref="BlobContainerFactory"/>.
/// </summary>
public class BlobContainerFactoryTests
{
    private BlobContainerFactory _testClass;
    private IFixture _fixture;
    private Mock<IBlobContainerConfigurationProvider> _configurationProvider;
    private Mock<IBlobProviderSelector> _providerSelector;
    private Mock<IServiceProvider> _serviceProvider;
    private Mock<IBlobNormalizeNamingService> _blobNormalizeNamingService;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BlobContainerFactory"/>.
    /// </summary>
    public BlobContainerFactoryTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._configurationProvider = _fixture.Freeze<Mock<IBlobContainerConfigurationProvider>>();
        this._providerSelector = _fixture.Freeze<Mock<IBlobProviderSelector>>();
        this._serviceProvider = _fixture.Freeze<Mock<IServiceProvider>>();
        this._blobNormalizeNamingService = _fixture.Freeze<Mock<IBlobNormalizeNamingService>>();
        this._testClass = _fixture.Create<BlobContainerFactory>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new BlobContainerFactory(this._configurationProvider.Object, this._providerSelector.Object, this._serviceProvider.Object, this._blobNormalizeNamingService.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the configurationProvider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfigurationProvider()
    {
        FluentActions.Invoking(() => new BlobContainerFactory(default(IBlobContainerConfigurationProvider), this._providerSelector.Object, this._serviceProvider.Object, this._blobNormalizeNamingService.Object)).Should().Throw<ArgumentNullException>().WithParameterName("configurationProvider");
    }

    /// <summary>
    /// Checks that instance construction throws when the providerSelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullProviderSelector()
    {
        FluentActions.Invoking(() => new BlobContainerFactory(this._configurationProvider.Object, default(IBlobProviderSelector), this._serviceProvider.Object, this._blobNormalizeNamingService.Object)).Should().Throw<ArgumentNullException>().WithParameterName("providerSelector");
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceProvider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceProvider()
    {
        FluentActions.Invoking(() => new BlobContainerFactory(this._configurationProvider.Object, this._providerSelector.Object, default(IServiceProvider), this._blobNormalizeNamingService.Object)).Should().Throw<ArgumentNullException>().WithParameterName("serviceProvider");
    }

    /// <summary>
    /// Checks that instance construction throws when the blobNormalizeNamingService parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullBlobNormalizeNamingService()
    {
        FluentActions.Invoking(() => new BlobContainerFactory(this._configurationProvider.Object, this._providerSelector.Object, this._serviceProvider.Object, default(IBlobNormalizeNamingService))).Should().Throw<ArgumentNullException>().WithParameterName("blobNormalizeNamingService");
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreate()
    {
        // Arrange
        var name = _fixture.Create<string>();

        // Act
        var result = this._testClass.Create(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCreateWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Create(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }
}