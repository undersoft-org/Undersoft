using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob;
using Undersoft.SDK.Service.Data.Blob.Container;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob.Container;

/// <summary>
/// Unit tests for the type <see cref="BlobContainerExtensions"/>.
/// </summary>
public class BlobContainerExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the SaveAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSaveAsync()
    {
        // Arrange
        var container = _fixture.Create<IBlobContainer>();
        var name = _fixture.Create<string>();
        var bytes = _fixture.Create<byte[]>();
        var overrideExisting = _fixture.Create<bool>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        await container.SaveAsync(name, bytes, overrideExisting, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SaveAsync method throws when the container parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSaveAsyncWithNullContainerAsync()
    {
        await FluentActions.Invoking(() => default(IBlobContainer).SaveAsync(_fixture.Create<string>(), _fixture.Create<byte[]>(), _fixture.Create<bool>(), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("container");
    }

    /// <summary>
    /// Checks that the SaveAsync method throws when the bytes parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSaveAsyncWithNullBytesAsync()
    {
        await FluentActions.Invoking(() => _fixture.Create<IBlobContainer>().SaveAsync(_fixture.Create<string>(), default(byte[]), _fixture.Create<bool>(), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the SaveAsync method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSaveAsyncWithInvalidNameAsync(string value)
    {
        await FluentActions.Invoking(() => _fixture.Create<IBlobContainer>().SaveAsync(value, _fixture.Create<byte[]>(), _fixture.Create<bool>(), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetAllBytesAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetAllBytesAsync()
    {
        // Arrange
        var container = _fixture.Create<IBlobContainer>();
        var name = _fixture.Create<string>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await container.GetAllBytesAsync(name, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetAllBytesAsync method throws when the container parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetAllBytesAsyncWithNullContainerAsync()
    {
        await FluentActions.Invoking(() => default(IBlobContainer).GetAllBytesAsync(_fixture.Create<string>(), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("container");
    }

    /// <summary>
    /// Checks that the GetAllBytesAsync method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallGetAllBytesAsyncWithInvalidNameAsync(string value)
    {
        await FluentActions.Invoking(() => _fixture.Create<IBlobContainer>().GetAllBytesAsync(value, _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetAllBytesOrNullAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetAllBytesOrNullAsync()
    {
        // Arrange
        var container = _fixture.Create<IBlobContainer>();
        var name = _fixture.Create<string>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await container.GetAllBytesOrNullAsync(name, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetAllBytesOrNullAsync method throws when the container parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetAllBytesOrNullAsyncWithNullContainerAsync()
    {
        await FluentActions.Invoking(() => default(IBlobContainer).GetAllBytesOrNullAsync(_fixture.Create<string>(), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("container");
    }

    /// <summary>
    /// Checks that the GetAllBytesOrNullAsync method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallGetAllBytesOrNullAsyncWithInvalidNameAsync(string value)
    {
        await FluentActions.Invoking(() => _fixture.Create<IBlobContainer>().GetAllBytesOrNullAsync(value, _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }
}