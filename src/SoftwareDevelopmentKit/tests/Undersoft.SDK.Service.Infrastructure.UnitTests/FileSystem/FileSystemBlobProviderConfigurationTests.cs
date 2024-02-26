using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob.Container;
using Undersoft.SDK.Service.Infrastructure.FileSystem;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests.FileSystem;

/// <summary>
/// Unit tests for the type <see cref="FileSystemBlobProviderConfiguration"/>.
/// </summary>
[TestClass]
public class FileSystemBlobProviderConfigurationTests
{
    private FileSystemBlobProviderConfiguration _testClass;
    private IFixture _fixture;
    private BlobContainerConfiguration _containerConfiguration;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="FileSystemBlobProviderConfiguration"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._containerConfiguration = _fixture.Create<BlobContainerConfiguration>();
        this._testClass = _fixture.Create<FileSystemBlobProviderConfiguration>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new FileSystemBlobProviderConfiguration(this._containerConfiguration);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the containerConfiguration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullContainerConfiguration()
    {
        FluentActions.Invoking(() => new FileSystemBlobProviderConfiguration(default(BlobContainerConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("containerConfiguration");
    }

    /// <summary>
    /// Checks that the BasePath property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBasePath()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.BasePath = testValue;

        // Assert
        this._testClass.BasePath.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the AppendContainerNameToBasePath property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAppendContainerNameToBasePath()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.AppendContainerNameToBasePath = testValue;

        // Assert
        this._testClass.AppendContainerNameToBasePath.Should().Be(testValue);
    }
}