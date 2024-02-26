using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Infrastructure.FileSystem;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests.FileSystem;

/// <summary>
/// Unit tests for the type <see cref="FileSystemBlobNamingNormalizer"/>.
/// </summary>
[TestClass]
public class FileSystemBlobNamingNormalizerTests
{
    private class TestFileSystemBlobNamingNormalizer : FileSystemBlobNamingNormalizer
    {
        public TestFileSystemBlobNamingNormalizer() : base()
        {
        }

        public string PublicNormalize(string fileName)
        {
            return base.Normalize(fileName);
        }
    }

    private TestFileSystemBlobNamingNormalizer _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="FileSystemBlobNamingNormalizer"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestFileSystemBlobNamingNormalizer>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestFileSystemBlobNamingNormalizer();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the NormalizeContainerName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNormalizeContainerName()
    {
        // Arrange
        var containerName = _fixture.Create<string>();

        // Act
        var result = this._testClass.NormalizeContainerName(containerName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NormalizeContainerName method throws when the containerName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNormalizeContainerNameWithInvalidContainerName(string value)
    {
        FluentActions.Invoking(() => this._testClass.NormalizeContainerName(value)).Should().Throw<ArgumentNullException>().WithParameterName("containerName");
    }

    /// <summary>
    /// Checks that the NormalizeBlobName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNormalizeBlobName()
    {
        // Arrange
        var blobName = _fixture.Create<string>();

        // Act
        var result = this._testClass.NormalizeBlobName(blobName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NormalizeBlobName method throws when the blobName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNormalizeBlobNameWithInvalidBlobName(string value)
    {
        FluentActions.Invoking(() => this._testClass.NormalizeBlobName(value)).Should().Throw<ArgumentNullException>().WithParameterName("blobName");
    }

    /// <summary>
    /// Checks that the PublicNormalize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNormalize()
    {
        // Arrange
        var fileName = _fixture.Create<string>();

        // Act
        var result = this._testClass.PublicNormalize(fileName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicNormalize method throws when the fileName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNormalizeWithInvalidFileName(string value)
    {
        FluentActions.Invoking(() => this._testClass.PublicNormalize(value)).Should().Throw<ArgumentNullException>().WithParameterName("fileName");
    }
}