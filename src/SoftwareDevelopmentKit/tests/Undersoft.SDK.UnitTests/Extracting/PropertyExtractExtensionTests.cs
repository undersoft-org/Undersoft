using System;
using System.Reflection;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Extracting;

namespace Undersoft.SDK.UnitTests.Extracting;

/// <summary>
/// Unit tests for the type <see cref="PropertyInfoExtractExtenstion"/>.
/// </summary>
public class PropertyInfoExtractExtenstionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetBackingFieldName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBackingFieldName()
    {
        // Arrange
        var propertyName = _fixture.Create<string>();

        // Act
        var result = PropertyInfoExtractExtenstion.GetBackingFieldName(propertyName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBackingFieldName method throws when the propertyName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetBackingFieldNameWithInvalidPropertyName(string value)
    {
        FluentActions.Invoking(() => PropertyInfoExtractExtenstion.GetBackingFieldName(value)).Should().Throw<ArgumentNullException>().WithParameterName("propertyName");
    }

    /// <summary>
    /// Checks that the HaveBackingField method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallHaveBackingFieldWithString()
    {
        // Arrange
        var propertyName = _fixture.Create<string>();

        // Act
        var result = PropertyInfoExtractExtenstion.HaveBackingField(propertyName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the HaveBackingField method throws when the propertyName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallHaveBackingFieldWithStringWithInvalidPropertyName(string value)
    {
        FluentActions.Invoking(() => PropertyInfoExtractExtenstion.HaveBackingField(value)).Should().Throw<ArgumentNullException>().WithParameterName("propertyName");
    }

    /// <summary>
    /// Checks that the HaveBackingField method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallHaveBackingFieldWithProperty()
    {
        // Arrange
        var @property = _fixture.Create<PropertyInfo>();

        // Act
        var result = property.HaveBackingField();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the HaveBackingField method throws when the property parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallHaveBackingFieldWithPropertyWithNullProperty()
    {
        FluentActions.Invoking(() => default(PropertyInfo).HaveBackingField()).Should().Throw<ArgumentNullException>().WithParameterName("property");
    }
}