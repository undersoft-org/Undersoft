using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Server.Resource;
using Undersoft.SDK.Service.Server.Resource.Container;

namespace Undersoft.SDK.Service.Server.UnitTests.Resource;

/// <summary>
/// Unit tests for the type <see cref="ResourceFile"/>.
/// </summary>
[TestClass]
public class ResourceFileTests
{
    private ResourceFile _testClass;
    private IFixture _fixture;
    private ResourceFileContainer _container;
    private string _filename;
    private string _containerName;
    private string _path;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ResourceFile"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._container = _fixture.Create<ResourceFileContainer>();
        this._filename = _fixture.Create<string>();
        this._containerName = _fixture.Create<string>();
        this._path = _fixture.Create<string>();
        this._testClass = _fixture.Create<ResourceFile>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ResourceFile(this._container, this._filename);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ResourceFile(this._containerName, this._filename);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ResourceFile(this._path);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the container parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullContainer()
    {
        FluentActions.Invoking(() => new ResourceFile(default(ResourceFileContainer), this._filename)).Should().Throw<ArgumentNullException>().WithParameterName("container");
    }

    /// <summary>
    /// Checks that the constructor throws when the filename parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidFilename(string value)
    {
        FluentActions.Invoking(() => new ResourceFile(this._container, value)).Should().Throw<ArgumentNullException>().WithParameterName("filename");
        FluentActions.Invoking(() => new ResourceFile(this._containerName, value)).Should().Throw<ArgumentNullException>().WithParameterName("filename");
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
        FluentActions.Invoking(() => new ResourceFile(value, this._filename)).Should().Throw<ArgumentNullException>().WithParameterName("containerName");
    }

    /// <summary>
    /// Checks that the constructor throws when the path parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidPath(string value)
    {
        FluentActions.Invoking(() => new ResourceFile(value)).Should().Throw<ArgumentNullException>().WithParameterName("path");
    }

    /// <summary>
    /// Checks that the CopyTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyTo()
    {
        // Arrange
        var target = _fixture.Create<Stream>();

        // Act
        this._testClass.CopyTo(target);

        // Assert
        _filename.Verify(mock => mock.CopyTo(It.IsAny<Stream>()));
    }

    /// <summary>
    /// Checks that the CopyTo method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyToWithNullTarget()
    {
        FluentActions.Invoking(() => this._testClass.CopyTo(default(Stream))).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the CopyToAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallCopyToAsync()
    {
        // Arrange
        var target = _fixture.Create<Stream>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.CopyToAsync(target, cancellationToken);

        // Assert
        _filename.Verify(mock => mock.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()));
    }

    /// <summary>
    /// Checks that the CopyToAsync method throws when the target parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallCopyToAsyncWithNullTargetAsync()
    {
        await FluentActions.Invoking(() => this._testClass.CopyToAsync(default(Stream), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the OpenReadStream method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOpenReadStream()
    {
        // Arrange
        var expectedReturnValue = _fixture.Create<Stream>();
        _filename.Setup(mock => mock.OpenReadStream()).Returns(expectedReturnValue);

        // Act
        var result = this._testClass.OpenReadStream();

        // Assert
        _filename.Verify(mock => mock.OpenReadStream());
        result.Should().BeSameAs(expectedReturnValue);
    }

    /// <summary>
    /// Checks that the ContentType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetContentType()
    {
        // Arrange
        var expectedValue = _fixture.Create<string>();
        _filename.Setup(mock => mock.ContentType).Returns(expectedValue);

        // Assert
        this._testClass.ContentType.Should().Be(expectedValue);
    }

    /// <summary>
    /// Checks that the ContentDisposition property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetContentDisposition()
    {
        // Arrange
        var expectedValue = _fixture.Create<string>();
        _filename.Setup(mock => mock.ContentDisposition).Returns(expectedValue);

        // Assert
        this._testClass.ContentDisposition.Should().Be(expectedValue);
    }

    /// <summary>
    /// Checks that the Headers property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetHeaders()
    {
        // Arrange
        _filename.Setup(mock => mock.Headers).Returns(_fixture.Create<IHeaderDictionary>());

        // Assert
        this._testClass.Headers.Should().BeAssignableTo<IHeaderDictionary>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Length property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetLength()
    {
        // Arrange
        var expectedValue = _fixture.Create<long>();
        _filename.Setup(mock => mock.Length).Returns(expectedValue);

        // Assert
        this._testClass.Length.Should().Be(expectedValue);
    }

    /// <summary>
    /// Checks that the Name property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetName()
    {
        // Arrange
        var expectedValue = _fixture.Create<string>();
        _filename.Setup(mock => mock.Name).Returns(expectedValue);

        // Assert
        this._testClass.Name.Should().Be(expectedValue);
    }
}