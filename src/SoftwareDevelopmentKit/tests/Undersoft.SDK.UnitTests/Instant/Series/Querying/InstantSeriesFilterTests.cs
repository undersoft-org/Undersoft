using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Series.Querying;

namespace Undersoft.SDK.UnitTests.Instant.Series.Querying;

/// <summary>
/// Unit tests for the type <see cref="InstantSeriesFilter"/>.
/// </summary>
public class InstantSeriesFilterTests
{
    private InstantSeriesFilter _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _series;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSeriesFilter"/>.
    /// </summary>
    public InstantSeriesFilterTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._series = _fixture.Freeze<Mock<IInstantSeries>>();
        this._testClass = _fixture.Create<InstantSeriesFilter>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSeriesFilter(this._series.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSeries()
    {
        FluentActions.Invoking(() => new InstantSeriesFilter(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the GetExpression method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetExpression()
    {
        // Arrange
        var stage = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetExpression(stage);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Query method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQueryWithToQueryAndStage()
    {
        // Arrange
        var toQuery = _fixture.Create<ICollection<IInstant>>();
        var stage = _fixture.Create<int>();

        // Act
        var result = this._testClass.Query(toQuery, stage);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Query method throws when the toQuery parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryWithToQueryAndStageWithNullToQuery()
    {
        FluentActions.Invoking(() => this._testClass.Query(default(ICollection<IInstant>), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("toQuery");
    }

    /// <summary>
    /// Checks that the Query method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQueryWithInt()
    {
        // Arrange
        var stage = _fixture.Create<int>();

        // Act
        var result = this._testClass.Query(stage);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InstantSeriesCreator property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInstantSeriesCreator()
    {
        // Arrange
        var testValue = _fixture.Create<IInstantSeries>();

        // Act
        this._testClass.InstantSeriesCreator = testValue;

        // Assert
        this._testClass.InstantSeriesCreator.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Reducer property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetReducer()
    {
        // Arrange
        var testValue = _fixture.Create<InstantSeriesFilterTerms>();

        // Act
        this._testClass.Reducer = testValue;

        // Assert
        this._testClass.Reducer.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Terms property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTerms()
    {
        // Arrange
        var testValue = _fixture.Create<InstantSeriesFilterTerms>();

        // Act
        this._testClass.Terms = testValue;

        // Assert
        this._testClass.Terms.Should().BeSameAs(testValue);
    }
}