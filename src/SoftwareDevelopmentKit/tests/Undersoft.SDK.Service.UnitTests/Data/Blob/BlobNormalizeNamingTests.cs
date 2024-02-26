using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob;

/// <summary>
/// Unit tests for the type <see cref="BlobNormalizeNaming"/>.
/// </summary>
public class BlobNormalizeNamingTests
{
    private BlobNormalizeNaming _testClass;
    private IFixture _fixture;
    private string _containerName;
    private string _blobName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BlobNormalizeNaming"/>.
    /// </summary>
    public BlobNormalizeNamingTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._containerName = _fixture.Create<string>();
        this._blobName = _fixture.Create<string>();
        this._testClass = _fixture.Create<BlobNormalizeNaming>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new BlobNormalizeNaming(this._containerName, this._blobName);

        // Assert
        instance.Should().NotBeNull();
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
        FluentActions.Invoking(() => new BlobNormalizeNaming(value, this._blobName)).Should().Throw<ArgumentNullException>().WithParameterName("containerName");
    }

    /// <summary>
    /// Checks that the constructor throws when the blobName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidBlobName(string value)
    {
        FluentActions.Invoking(() => new BlobNormalizeNaming(this._containerName, value)).Should().Throw<ArgumentNullException>().WithParameterName("blobName");
    }
}