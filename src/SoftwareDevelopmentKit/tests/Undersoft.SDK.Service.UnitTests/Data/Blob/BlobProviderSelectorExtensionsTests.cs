using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob;
using TContainer = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob;

/// <summary>
/// Unit tests for the type <see cref="BlobProviderSelectorExtensions"/>.
/// </summary>
public class BlobProviderSelectorExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var selector = _fixture.Create<IBlobProviderSelector>();

        // Act
        var result = selector.Get<TContainer>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithNullSelector()
    {
        FluentActions.Invoking(() => default(IBlobProviderSelector).Get<TContainer>()).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }
}