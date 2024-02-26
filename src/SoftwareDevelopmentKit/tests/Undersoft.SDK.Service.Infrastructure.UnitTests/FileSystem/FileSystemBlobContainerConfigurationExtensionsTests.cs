using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob.Container;
using Undersoft.SDK.Service.Infrastructure.FileSystem;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests.FileSystem;

/// <summary>
/// Unit tests for the type <see cref="FileSystemBlobContainerConfigurationExtensions"/>.
/// </summary>
[TestClass]
public class FileSystemBlobContainerConfigurationExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetFileSystemConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetFileSystemConfiguration()
    {
        // Arrange
        var containerConfiguration = _fixture.Create<BlobContainerConfiguration>();

        // Act
        var result = containerConfiguration.GetFileSystemConfiguration();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetFileSystemConfiguration method throws when the containerConfiguration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetFileSystemConfigurationWithNullContainerConfiguration()
    {
        FluentActions.Invoking(() => default(BlobContainerConfiguration).GetFileSystemConfiguration()).Should().Throw<ArgumentNullException>().WithParameterName("containerConfiguration");
    }

    /// <summary>
    /// Checks that the UseFileSystem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseFileSystem()
    {
        // Arrange
        var containerConfiguration = _fixture.Create<BlobContainerConfiguration>();
        Action<FileSystemBlobProviderConfiguration> fileSystemConfigureAction = x => { };

        // Act
        var result = containerConfiguration.UseFileSystem(fileSystemConfigureAction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseFileSystem method throws when the containerConfiguration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseFileSystemWithNullContainerConfiguration()
    {
        FluentActions.Invoking(() => default(BlobContainerConfiguration).UseFileSystem(x => { })).Should().Throw<ArgumentNullException>().WithParameterName("containerConfiguration");
    }

    /// <summary>
    /// Checks that the UseFileSystem method throws when the fileSystemConfigureAction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseFileSystemWithNullFileSystemConfigureAction()
    {
        FluentActions.Invoking(() => _fixture.Create<BlobContainerConfiguration>().UseFileSystem(default(Action<FileSystemBlobProviderConfiguration>))).Should().Throw<ArgumentNullException>().WithParameterName("fileSystemConfigureAction");
    }
}