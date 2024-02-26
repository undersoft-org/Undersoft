using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Blob;
using Undersoft.SDK.Service.Data.Blob.Container;
using TContainer = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob.Container;

/// <summary>
/// Unit tests for the type <see cref="BlobContainer"/>.
/// </summary>
public class BlobContainer_1Tests
{
    private BlobContainer<TContainer> _testClass;
    private IFixture _fixture;
    private Mock<IBlobContainerFactory> _blobContainerFactory;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BlobContainer"/>.
    /// </summary>
    public BlobContainer_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._blobContainerFactory = _fixture.Freeze<Mock<IBlobContainerFactory>>();
        this._testClass = _fixture.Create<BlobContainer<TContainer>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new BlobContainer<TContainer>(this._blobContainerFactory.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the blobContainerFactory parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullBlobContainerFactory()
    {
        FluentActions.Invoking(() => new BlobContainer<TContainer>(default(IBlobContainerFactory))).Should().Throw<ArgumentNullException>().WithParameterName("blobContainerFactory");
    }

    /// <summary>
    /// Checks that the SaveAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSaveAsync()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var stream = _fixture.Create<Stream>();
        var overrideExisting = _fixture.Create<bool>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.SaveAsync(name, stream, overrideExisting, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SaveAsync method throws when the stream parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSaveAsyncWithNullStreamAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SaveAsync(_fixture.Create<string>(), default(Stream), _fixture.Create<bool>(), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("stream");
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
        await FluentActions.Invoking(() => this._testClass.SaveAsync(value, _fixture.Create<Stream>(), _fixture.Create<bool>(), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the DeleteAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDeleteAsync()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.DeleteAsync(name, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeleteAsync method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallDeleteAsyncWithInvalidNameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.DeleteAsync(value, _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ExistsAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExistsAsync()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.ExistsAsync(name, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExistsAsync method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallExistsAsyncWithInvalidNameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.ExistsAsync(value, _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetAsync()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.GetAsync(name, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetAsync method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallGetAsyncWithInvalidNameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.GetAsync(value, _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetOrNullAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetOrNullAsync()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.GetOrNullAsync(name, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetOrNullAsync method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallGetOrNullAsyncWithInvalidNameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.GetOrNullAsync(value, _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }
}

/// <summary>
/// Unit tests for the type <see cref="BlobContainer"/>.
/// </summary>
public class BlobContainerTests
{
    private BlobContainer _testClass;
    private IFixture _fixture;
    private string _containerName;
    private BlobContainerConfiguration _configuration;
    private Mock<IBlobProvider> _provider;
    private Mock<IBlobNormalizeNamingService> _blobNormalizeNamingService;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BlobContainer"/>.
    /// </summary>
    public BlobContainerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._containerName = _fixture.Create<string>();
        this._configuration = _fixture.Create<BlobContainerConfiguration>();
        this._provider = _fixture.Freeze<Mock<IBlobProvider>>();
        this._blobNormalizeNamingService = _fixture.Freeze<Mock<IBlobNormalizeNamingService>>();
        this._testClass = _fixture.Create<BlobContainer>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new BlobContainer(this._containerName, this._configuration, this._provider.Object, this._blobNormalizeNamingService.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfiguration()
    {
        FluentActions.Invoking(() => new BlobContainer(this._containerName, default(BlobContainerConfiguration), this._provider.Object, this._blobNormalizeNamingService.Object)).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }

    /// <summary>
    /// Checks that instance construction throws when the provider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullProvider()
    {
        FluentActions.Invoking(() => new BlobContainer(this._containerName, this._configuration, default(IBlobProvider), this._blobNormalizeNamingService.Object)).Should().Throw<ArgumentNullException>().WithParameterName("provider");
    }

    /// <summary>
    /// Checks that the constructor throws when the containerName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidContainerName(string value)
    {
        FluentActions.Invoking(() => new BlobContainer(value, this._configuration, this._provider.Object, this._blobNormalizeNamingService.Object)).Should().Throw<ArgumentNullException>().WithParameterName("containerName");
    }

    /// <summary>
    /// Checks that the SaveAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSaveAsync()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var stream = _fixture.Create<Stream>();
        var overrideExisting = _fixture.Create<bool>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.SaveAsync(name, stream, overrideExisting, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SaveAsync method throws when the stream parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSaveAsyncWithNullStreamAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SaveAsync(_fixture.Create<string>(), default(Stream), _fixture.Create<bool>(), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("stream");
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
        await FluentActions.Invoking(() => this._testClass.SaveAsync(value, _fixture.Create<Stream>(), _fixture.Create<bool>(), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the DeleteAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDeleteAsync()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.DeleteAsync(name, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeleteAsync method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallDeleteAsyncWithInvalidNameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.DeleteAsync(value, _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ExistsAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExistsAsync()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.ExistsAsync(name, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExistsAsync method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallExistsAsyncWithInvalidNameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.ExistsAsync(value, _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetAsync()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.GetAsync(name, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetAsync method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallGetAsyncWithInvalidNameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.GetAsync(value, _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetOrNullAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetOrNullAsync()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.GetOrNullAsync(name, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetOrNullAsync method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallGetOrNullAsyncWithInvalidNameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.GetOrNullAsync(value, _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ContainerName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetContainerName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ContainerName = testValue;

        // Assert
        this._testClass.ContainerName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the CancellationTokenProvider property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetCancellationTokenProvider()
    {
        // Assert
        this._testClass.CancellationTokenProvider.As<object>().Should().BeAssignableTo<CancellationToken>();

        Assert.Fail("Create or modify test");
    }
}