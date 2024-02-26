using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Series;

namespace Undersoft.SDK.UnitTests.Instant.Series;

/// <summary>
/// Unit tests for the type <see cref="InstantSeriesAggregator"/>.
/// </summary>
public class InstantSeriesAggregatorTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Aggregate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAggregate()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        var onlyView = _fixture.Create<bool>();

        // Act
        var result = series.Aggregate(onlyView);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Aggregate method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAggregateWithNullSeries()
    {
        FluentActions.Invoking(() => default(IInstantSeries).Aggregate(_fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }
}