using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Data.Blob;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob;

/// <summary>
/// Unit tests for the type <see cref="BlobStoringModule"/>.
/// </summary>
public class BlobStoringModuleTests
{
    private BlobStoringModule _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BlobStoringModule"/>.
    /// </summary>
    public BlobStoringModuleTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<BlobStoringModule>();
    }

    /// <summary>
    /// Checks that the ConfigureServices method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigureServices()
    {
        // Arrange
        var context = _fixture.Create<ServiceConfigurationContext>();

        // Act
        this._testClass.ConfigureServices(context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ConfigureServices method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureServicesWithNullContext()
    {
        FluentActions.Invoking(() => this._testClass.ConfigureServices(default(ServiceConfigurationContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }
}