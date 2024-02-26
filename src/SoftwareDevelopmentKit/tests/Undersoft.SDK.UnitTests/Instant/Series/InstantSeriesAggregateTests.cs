using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Rubrics;

namespace Undersoft.SDK.UnitTests.Instant.Series;

/// <summary>
/// Unit tests for the type <see cref="InstantSeriesAggregate"/>.
/// </summary>
public class InstantSeriesAggregateTests
{
    private InstantSeriesAggregate _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _series;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSeriesAggregate"/>.
    /// </summary>
    public InstantSeriesAggregateTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._series = _fixture.Freeze<Mock<IInstantSeries>>();
        this._testClass = _fixture.Create<InstantSeriesAggregate>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSeriesAggregate(this._series.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSeries()
    {
        FluentActions.Invoking(() => new InstantSeriesAggregate(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the Rubrics property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRubrics()
    {
        // Assert
        this._testClass.Rubrics.Should().BeAssignableTo<IRubrics>();

        Assert.Fail("Create or modify test");
    }
}