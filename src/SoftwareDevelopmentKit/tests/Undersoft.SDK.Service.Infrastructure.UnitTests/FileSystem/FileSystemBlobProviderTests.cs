using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Blob;
using Undersoft.SDK.Service.Infrastructure.FileSystem;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests.FileSystem;

/// <summary>
/// Unit tests for the type <see cref="FileSystemBlobProvider"/>.
/// </summary>
[TestClass]
public class FileSystemBlobProviderTests
{
    private class TestFileSystemBlobProvider : FileSystemBlobProvider
    {
        public TestFileSystemBlobProvider(IBlobFilePathCalculator filePathCalculator) : base(filePathCalculator)
        {
        }

        public Task<bool> PublicExistsAsync(string filePath)
        {
            return base.ExistsAsync(filePath);
        }

        public IBlobFilePathCalculator PublicFilePathCalculator => base.FilePathCalculator;
    }

    private TestFileSystemBlobProvider _testClass;
    private IFixture _fixture;
    private Mock<IBlobFilePathCalculator> _filePathCalculator;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="FileSystemBlobProvider"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._filePathCalculator = _fixture.Freeze<Mock<IBlobFilePathCalculator>>();
        this._testClass = _fixture.Create<TestFileSystemBlobProvider>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestFileSystemBlobProvider(this._filePathCalculator.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the filePathCalculator parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullFilePathCalculator()
    {
        FluentActions.Invoking(() => new TestFileSystemBlobProvider(default(IBlobFilePathCalculator))).Should().Throw<ArgumentNullException>().WithParameterName("filePathCalculator");
    }

    /// <summary>
    /// Checks that the SaveAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSaveAsync()
    {
        // Arrange
        var args = _fixture.Create<BlobProviderSaveArgs>();

        // Act
        await this._testClass.SaveAsync(args);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SaveAsync method throws when the args parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSaveAsyncWithNullArgsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SaveAsync(default(BlobProviderSaveArgs))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that the DeleteAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDeleteAsync()
    {
        // Arrange
        var args = _fixture.Create<BlobProviderArgs>();

        // Act
        var result = await this._testClass.DeleteAsync(args);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeleteAsync method throws when the args parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallDeleteAsyncWithNullArgsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.DeleteAsync(default(BlobProviderArgs))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that the ExistsAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExistsAsyncWithBlobProviderArgsAsync()
    {
        // Arrange
        var args = _fixture.Create<BlobProviderArgs>();

        // Act
        var result = await this._testClass.ExistsAsync(args);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExistsAsync method throws when the args parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExistsAsyncWithBlobProviderArgsWithNullArgsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.ExistsAsync(default(BlobProviderArgs))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that the GetOrNullAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetOrNullAsync()
    {
        // Arrange
        var args = _fixture.Create<BlobProviderArgs>();

        // Act
        var result = await this._testClass.GetOrNullAsync(args);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetOrNullAsync method throws when the args parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetOrNullAsyncWithNullArgsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.GetOrNullAsync(default(BlobProviderArgs))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that the PublicExistsAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExistsAsyncWithFilePathAsync()
    {
        // Arrange
        var filePath = _fixture.Create<string>();

        // Act
        var result = await this._testClass.PublicExistsAsync(filePath);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicExistsAsync method throws when the filePath parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallExistsAsyncWithFilePathWithInvalidFilePathAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.PublicExistsAsync(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("filePath");
    }

    /// <summary>
    /// Checks that the PublicFilePathCalculator property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicFilePathCalculator()
    {
        // Assert
        this._testClass.PublicFilePathCalculator.Should().BeAssignableTo<IBlobFilePathCalculator>();

        Assert.Fail("Create or modify test");
    }
}