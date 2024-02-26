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
/// Unit tests for the type <see cref="BlobContainerFactoryExtensions"/>.
/// </summary>
public class BlobContainerFactoryExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreate()
    {
        // Arrange
        var blobContainerFactory = _fixture.Create<IBlobContainerFactory>();

        // Act
        var result = blobContainerFactory
        .Create<TContainer>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method throws when the blobContainerFactory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateWithNullBlobContainerFactory()
    {
        FluentActions.Invoking(() => default(IBlobContainerFactory).Create<TContainer>()).Should().Throw<ArgumentNullException>().WithParameterName("blobContainerFactory");
    }
}