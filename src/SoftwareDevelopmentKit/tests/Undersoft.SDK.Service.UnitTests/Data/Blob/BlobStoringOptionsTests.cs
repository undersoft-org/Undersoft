using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob;
using Undersoft.SDK.Service.Data.Blob.Container;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob;

/// <summary>
/// Unit tests for the type <see cref="BlobStoringOptions"/>.
/// </summary>
public class BlobStoringOptionsTests
{
    private BlobStoringOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BlobStoringOptions"/>.
    /// </summary>
    public BlobStoringOptionsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<BlobStoringOptions>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new BlobStoringOptions();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Containers property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetContainers()
    {
        // Assert
        this._testClass.Containers.Should().BeAssignableTo<BlobContainerConfigurations>();

        Assert.Fail("Create or modify test");
    }
}