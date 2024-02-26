using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob.Container;
using T = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob.Container;

/// <summary>
/// Unit tests for the type <see cref="BlobContainerConfigurationExtensions"/>.
/// </summary>
public class BlobContainerConfigurationExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetConfigurationWithTAndBlobContainerConfigurationAndString()
    {
        // Arrange
        var containerConfiguration = _fixture.Create<BlobContainerConfiguration>();
        var name = _fixture.Create<string>();

        // Act
        var result = containerConfiguration.GetConfiguration<T>(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetConfiguration method throws when the containerConfiguration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetConfigurationWithTAndBlobContainerConfigurationAndStringWithNullContainerConfiguration()
    {
        FluentActions.Invoking(() => default(BlobContainerConfiguration).GetConfiguration<T>(_fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("containerConfiguration");
    }

    /// <summary>
    /// Checks that the GetConfiguration method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetConfigurationWithTAndBlobContainerConfigurationAndStringWithInvalidName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<BlobContainerConfiguration>().GetConfiguration<T>(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetConfigurationWithBlobContainerConfigurationAndString()
    {
        // Arrange
        var containerConfiguration = _fixture.Create<BlobContainerConfiguration>();
        var name = _fixture.Create<string>();

        // Act
        var result = containerConfiguration.GetConfiguration(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetConfiguration method throws when the containerConfiguration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetConfigurationWithBlobContainerConfigurationAndStringWithNullContainerConfiguration()
    {
        FluentActions.Invoking(() => default(BlobContainerConfiguration).GetConfiguration(_fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("containerConfiguration");
    }

    /// <summary>
    /// Checks that the GetConfiguration method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetConfigurationWithBlobContainerConfigurationAndStringWithInvalidName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<BlobContainerConfiguration>().GetConfiguration(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }
}