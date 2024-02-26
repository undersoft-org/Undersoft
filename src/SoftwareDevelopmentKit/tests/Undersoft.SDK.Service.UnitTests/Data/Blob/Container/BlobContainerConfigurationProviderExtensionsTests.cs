using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob;
using Undersoft.SDK.Service.Data.Blob.Container;
using TContainer = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob.Container;

/// <summary>
/// Unit tests for the type <see cref="BlobContainerConfigurationProviderExtensions"/>.
/// </summary>
public class BlobContainerConfigurationProviderExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var configurationProvider = _fixture.Create<IBlobContainerConfigurationProvider>();

        // Act
        var result = configurationProvider.Get<TContainer>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the configurationProvider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithNullConfigurationProvider()
    {
        FluentActions.Invoking(() => default(IBlobContainerConfigurationProvider).Get<TContainer>()).Should().Throw<ArgumentNullException>().WithParameterName("configurationProvider");
    }
}