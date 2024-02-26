using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Blob;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob;

/// <summary>
/// Unit tests for the type <see cref="DefaultBlobContainerConfigurationProvider"/>.
/// </summary>
public class DefaultBlobContainerConfigurationProviderTests
{
    private DefaultBlobContainerConfigurationProvider _testClass;
    private IFixture _fixture;
    private Mock<IOptions<BlobStoringOptions>> _options;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DefaultBlobContainerConfigurationProvider"/>.
    /// </summary>
    public DefaultBlobContainerConfigurationProviderTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._options = _fixture.Freeze<Mock<IOptions<BlobStoringOptions>>>();
        this._testClass = _fixture.Create<DefaultBlobContainerConfigurationProvider>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DefaultBlobContainerConfigurationProvider(this._options.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new DefaultBlobContainerConfigurationProvider(default(IOptions<BlobStoringOptions>))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var name = _fixture.Create<string>();

        // Act
        var result = this._testClass.Get(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Get(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }
}