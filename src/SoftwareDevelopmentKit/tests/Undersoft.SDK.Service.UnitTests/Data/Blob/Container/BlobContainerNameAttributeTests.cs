using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob.Container;
using T = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob.Container;

/// <summary>
/// Unit tests for the type <see cref="BlobContainerNameAttribute"/>.
/// </summary>
public class BlobContainerNameAttributeTests
{
    private BlobContainerNameAttribute _testClass;
    private IFixture _fixture;
    private string _name;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BlobContainerNameAttribute"/>.
    /// </summary>
    public BlobContainerNameAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._name = _fixture.Create<string>();
        this._testClass = _fixture.Create<BlobContainerNameAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new BlobContainerNameAttribute(this._name);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidName(string value)
    {
        FluentActions.Invoking(() => new BlobContainerNameAttribute(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetName()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetName(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetName method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetNameWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.GetName(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetContainerName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetContainerNameWithNoParameters()
    {
        // Act
        var result = BlobContainerNameAttribute.GetContainerName<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetContainerName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetContainerNameWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = BlobContainerNameAttribute.GetContainerName(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetContainerName method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetContainerNameWithTypeWithNullType()
    {
        FluentActions.Invoking(() => BlobContainerNameAttribute.GetContainerName(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }
}