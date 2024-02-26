using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Series.Querying;

namespace Undersoft.SDK.UnitTests.Instant.Series.Querying;

/// <summary>
/// Unit tests for the type <see cref="InstantSeriesSort"/>.
/// </summary>
public class InstantSeriesSortTests
{
    private InstantSeriesSort _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _series;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSeriesSort"/>.
    /// </summary>
    public InstantSeriesSortTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._series = _fixture.Freeze<Mock<IInstantSeries>>();
        this._testClass = _fixture.Create<InstantSeriesSort>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSeriesSort(this._series.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSeries()
    {
        FluentActions.Invoking(() => new InstantSeriesSort(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }
}