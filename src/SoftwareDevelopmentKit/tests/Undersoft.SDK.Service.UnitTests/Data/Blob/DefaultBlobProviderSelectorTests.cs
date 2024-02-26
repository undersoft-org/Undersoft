using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Blob;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob;

/// <summary>
/// Unit tests for the type <see cref="DefaultBlobProviderSelector"/>.
/// </summary>
public class DefaultBlobProviderSelectorTests
{
    private DefaultBlobProviderSelector _testClass;
    private IFixture _fixture;
    private Mock<IBlobContainerConfigurationProvider> _configurationProvider;
    private IEnumerable<IBlobProvider> _blobProviders;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DefaultBlobProviderSelector"/>.
    /// </summary>
    public DefaultBlobProviderSelectorTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._configurationProvider = _fixture.Freeze<Mock<IBlobContainerConfigurationProvider>>();
        this._blobProviders = _fixture.Create<IEnumerable<IBlobProvider>>();
        this._testClass = _fixture.Create<DefaultBlobProviderSelector>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DefaultBlobProviderSelector(this._configurationProvider.Object, this._blobProviders);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the configurationProvider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfigurationProvider()
    {
        FluentActions.Invoking(() => new DefaultBlobProviderSelector(default(IBlobContainerConfigurationProvider), this._blobProviders)).Should().Throw<ArgumentNullException>().WithParameterName("configurationProvider");
    }

    /// <summary>
    /// Checks that instance construction throws when the blobProviders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullBlobProviders()
    {
        FluentActions.Invoking(() => new DefaultBlobProviderSelector(this._configurationProvider.Object, default(IEnumerable<IBlobProvider>))).Should().Throw<ArgumentNullException>().WithParameterName("blobProviders");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var containerName = _fixture.Create<string>();

        // Act
        var result = this._testClass.Get(containerName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the containerName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetWithInvalidContainerName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Get(value)).Should().Throw<ArgumentNullException>().WithParameterName("containerName");
    }
}