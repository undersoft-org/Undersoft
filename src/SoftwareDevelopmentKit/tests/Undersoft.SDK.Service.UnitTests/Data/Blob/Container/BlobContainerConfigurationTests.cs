using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob;
using Undersoft.SDK.Service.Data.Blob.Container;
using T = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Blob.Container;

/// <summary>
/// Unit tests for the type <see cref="BlobContainerConfiguration"/>.
/// </summary>
public class BlobContainerConfigurationTests
{
    private BlobContainerConfiguration _testClass;
    private IFixture _fixture;
    private BlobContainerConfiguration _fallbackConfiguration;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BlobContainerConfiguration"/>.
    /// </summary>
    public BlobContainerConfigurationTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._fallbackConfiguration = _fixture.Create<BlobContainerConfiguration>();
        this._testClass = _fixture.Create<BlobContainerConfiguration>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new BlobContainerConfiguration(this._fallbackConfiguration);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the GetConfigurationOrDefault method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetConfigurationOrDefault()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var defaultValue = _fixture.Create<T>();

        // Act
        var result = this._testClass.GetConfigurationOrDefault<T>(name, defaultValue);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetConfigurationOrDefault method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetConfigurationOrDefaultWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetConfigurationOrDefault<T>(value, _fixture.Create<T>())).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetConfigurationOrNull method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetConfigurationOrNull()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var defaultValue = _fixture.Create<object>();

        // Act
        var result = this._testClass.GetConfigurationOrNull(name, defaultValue);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetConfigurationOrNull method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetConfigurationOrNullWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetConfigurationOrNull(value, _fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the SetConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetConfiguration()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var value = _fixture.Create<object>();

        // Act
        var result = this._testClass.SetConfiguration(name, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetConfiguration method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetConfigurationWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.SetConfiguration(_fixture.Create<string>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the SetConfiguration method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetConfigurationWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.SetConfiguration(value, _fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ClearConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClearConfiguration()
    {
        // Arrange
        var name = _fixture.Create<string>();

        // Act
        var result = this._testClass.ClearConfiguration(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ClearConfiguration method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallClearConfigurationWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.ClearConfiguration(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ProviderType property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProviderType()
    {
        // Arrange
        var testValue = _fixture.Create<Type>();

        // Act
        this._testClass.ProviderType = testValue;

        // Assert
        this._testClass.ProviderType.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the NamingNormalizers property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetNamingNormalizers()
    {
        // Assert
        this._testClass.NamingNormalizers.Should().BeAssignableTo<IList<IBlobNamingNormalizer>>();

        Assert.Fail("Create or modify test");
    }
}