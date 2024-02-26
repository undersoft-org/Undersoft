using System;
using System.Globalization;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="CultureHelper"/>.
/// </summary>
public class CultureHelperTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Use method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseWithStringAndString()
    {
        // Arrange
        var culture = _fixture.Create<string>();
        var uiCulture = _fixture.Create<string>();

        // Act
        CultureHelper.Use(culture, uiCulture);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Use method throws when the culture parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallUseWithStringAndStringWithInvalidCulture(string value)
    {
        FluentActions.Invoking(() => CultureHelper.Use(value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("culture");
    }

    /// <summary>
    /// Checks that the Use method throws when the uiCulture parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallUseWithStringAndStringWithInvalidUiCulture(string value)
    {
        FluentActions.Invoking(() => CultureHelper.Use(_fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("uiCulture");
    }

    /// <summary>
    /// Checks that the Use method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseWithCultureInfoAndCultureInfo()
    {
        // Arrange
        var culture = _fixture.Create<CultureInfo>();
        var uiCulture = _fixture.Create<CultureInfo>();

        // Act
        CultureHelper.Use(culture, uiCulture);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Use method throws when the culture parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseWithCultureInfoAndCultureInfoWithNullCulture()
    {
        FluentActions.Invoking(() => CultureHelper.Use(default(CultureInfo), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("culture");
    }

    /// <summary>
    /// Checks that the IsValidCultureCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsValidCultureCode()
    {
        // Arrange
        var cultureCode = _fixture.Create<string>();

        // Act
        var result = CultureHelper.IsValidCultureCode(cultureCode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsValidCultureCode method throws when the cultureCode parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallIsValidCultureCodeWithInvalidCultureCode(string value)
    {
        FluentActions.Invoking(() => CultureHelper.IsValidCultureCode(value)).Should().Throw<ArgumentNullException>().WithParameterName("cultureCode");
    }

    /// <summary>
    /// Checks that the GetBaseCultureName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBaseCultureName()
    {
        // Arrange
        var cultureName = _fixture.Create<string>();

        // Act
        var result = CultureHelper.GetBaseCultureName(cultureName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBaseCultureName method throws when the cultureName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetBaseCultureNameWithInvalidCultureName(string value)
    {
        FluentActions.Invoking(() => CultureHelper.GetBaseCultureName(value)).Should().Throw<ArgumentNullException>().WithParameterName("cultureName");
    }

    /// <summary>
    /// Checks that the IsCompatibleCulture method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsCompatibleCulture()
    {
        // Arrange
        var sourceCultureName = _fixture.Create<string>();
        var targetCultureName = _fixture.Create<string>();

        // Act
        var result = CultureHelper.IsCompatibleCulture(sourceCultureName, targetCultureName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsCompatibleCulture method throws when the sourceCultureName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallIsCompatibleCultureWithInvalidSourceCultureName(string value)
    {
        FluentActions.Invoking(() => CultureHelper.IsCompatibleCulture(value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("sourceCultureName");
    }

    /// <summary>
    /// Checks that the IsCompatibleCulture method throws when the targetCultureName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallIsCompatibleCultureWithInvalidTargetCultureName(string value)
    {
        FluentActions.Invoking(() => CultureHelper.IsCompatibleCulture(_fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("targetCultureName");
    }

    /// <summary>
    /// Checks that the IsRtl property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIsRtl()
    {
        // Assert
        CultureHelper.IsRtl.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }
}