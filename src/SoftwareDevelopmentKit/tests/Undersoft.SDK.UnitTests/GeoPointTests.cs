using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="GeoPoint"/>.
/// </summary>
public class GeoPointTests
{
    private GeoPoint _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="GeoPoint"/>.
    /// </summary>
    public GeoPointTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<GeoPoint>();
    }

    /// <summary>
    /// Checks that the Latitude property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLatitude()
    {
        // Arrange
        var testValue = _fixture.Create<double>();

        // Act
        this._testClass.Latitude = testValue;

        // Assert
        this._testClass.Latitude.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Longitude property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLongitude()
    {
        // Arrange
        var testValue = _fixture.Create<double>();

        // Act
        this._testClass.Longitude = testValue;

        // Assert
        this._testClass.Longitude.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Measure property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMeasure()
    {
        // Arrange
        var testValue = _fixture.Create<double>();

        // Act
        this._testClass.Measure = testValue;

        // Assert
        this._testClass.Measure.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Altitude property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAltitude()
    {
        // Arrange
        var testValue = _fixture.Create<double>();

        // Act
        this._testClass.Altitude = testValue;

        // Assert
        this._testClass.Altitude.Should().Be(testValue);
    }
}