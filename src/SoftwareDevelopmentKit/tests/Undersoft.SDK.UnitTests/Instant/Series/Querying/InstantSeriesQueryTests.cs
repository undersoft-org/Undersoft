using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Series.Querying;

namespace Undersoft.SDK.UnitTests.Instant.Series.Querying;

/// <summary>
/// Unit tests for the type <see cref="InstantSeriesQuery"/>.
/// </summary>
public class InstantSeriesQueryTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Query method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQueryWithFigureArrayAndQueryFormula()
    {
        // Arrange
        var figureArray = _fixture.Create<IInstant[]>();
        Func<IInstant, bool> queryFormula = x => _fixture.Create<bool>();

        // Act
        var result = figureArray.Query(queryFormula
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Query method throws when the figureArray parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryWithFigureArrayAndQueryFormulaWithNullFigureArray()
    {
        FluentActions.Invoking(() => default(IInstant[]).Query(x => _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("figureArray");
    }

    /// <summary>
    /// Checks that the Query method throws when the queryFormula parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryWithFigureArrayAndQueryFormulaWithNullQueryFormula()
    {
        FluentActions.Invoking(() => _fixture.Create<IInstant[]>().Query(default(Func<IInstant, bool>))).Should().Throw<ArgumentNullException>().WithParameterName("queryFormula");
    }

    /// <summary>
    /// Checks that the Query method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQueryWithSeriesAndQueryFormula()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        Func<IInstant, bool> queryFormula = x => _fixture.Create<bool>();

        // Act
        var result = series.Query(queryFormula
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Query method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryWithSeriesAndQueryFormulaWithNullSeries()
    {
        FluentActions.Invoking(() => default(IInstantSeries).Query(x => _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the Query method throws when the queryFormula parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryWithSeriesAndQueryFormulaWithNullQueryFormula()
    {
        FluentActions.Invoking(() => _fixture.Create<IInstantSeries>().Query(default(Func<IInstant, bool>))).Should().Throw<ArgumentNullException>().WithParameterName("queryFormula");
    }

    /// <summary>
    /// Checks that the Query method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQueryWithSeriesAndAppendseriesAndStage()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        var appendseries = _fixture.Create<IInstant[]>();
        var stage = _fixture.Create<int>();

        // Act
        var result = series.Query(appendseries, stage);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Query method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryWithSeriesAndAppendseriesAndStageWithNullSeries()
    {
        FluentActions.Invoking(() => default(IInstantSeries).Query(_fixture.Create<IInstant[]>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the Query method throws when the appendseries parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryWithSeriesAndAppendseriesAndStageWithNullAppendseries()
    {
        FluentActions.Invoking(() => _fixture.Create<IInstantSeries>().Query(default(IInstant[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("appendseries");
    }

    /// <summary>
    /// Checks that the Query method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQueryWithSeriesAndFilterListAndSortListAndSaveonlyAndClearonendAndStage()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        var filterList = _fixture.Create<IList<InstantSeriesFilterTerm>>();
        var sortList = _fixture.Create<IList<InstantSeriesSortTerm>>();
        var saveonly = _fixture.Create<bool>();
        var clearonend = _fixture.Create<bool>();
        var stage = _fixture.Create<int>();

        // Act
        var result = series.Query(filterList, sortList, saveonly, clearonend, stage);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Query method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryWithSeriesAndFilterListAndSortListAndSaveonlyAndClearonendAndStageWithNullSeries()
    {
        FluentActions.Invoking(() => default(IInstantSeries).Query(_fixture.Create<IList<InstantSeriesFilterTerm>>(), _fixture.Create<IList<InstantSeriesSortTerm>>(), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the Query method throws when the filterList parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryWithSeriesAndFilterListAndSortListAndSaveonlyAndClearonendAndStageWithNullFilterList()
    {
        FluentActions.Invoking(() => _fixture.Create<IInstantSeries>().Query(default(IList<InstantSeriesFilterTerm>), _fixture.Create<IList<InstantSeriesSortTerm>>(), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("filterList");
    }

    /// <summary>
    /// Checks that the Query method throws when the sortList parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryWithSeriesAndFilterListAndSortListAndSaveonlyAndClearonendAndStageWithNullSortList()
    {
        FluentActions.Invoking(() => _fixture.Create<IInstantSeries>().Query(_fixture.Create<IList<InstantSeriesFilterTerm>>(), default(IList<InstantSeriesSortTerm>), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("sortList");
    }

    /// <summary>
    /// Checks that the Query method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQueryWithSeriesAndStageAndFilterAndSortAndSaveonlyAndClearonend()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        var stage = _fixture.Create<int>();
        var filter = _fixture.Create<InstantSeriesFilterTerms>();
        var sort = _fixture.Create<InstantSeriesSortTerms>();
        var saveonly = _fixture.Create<bool>();
        var clearonend = _fixture.Create<bool>();

        // Act
        var result = series.Query(stage, filter, sort, saveonly, clearonend);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Query method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryWithSeriesAndStageAndFilterAndSortAndSaveonlyAndClearonendWithNullSeries()
    {
        FluentActions.Invoking(() => default(IInstantSeries).Query(_fixture.Create<int>(), _fixture.Create<InstantSeriesFilterTerms>(), _fixture.Create<InstantSeriesSortTerms>(), _fixture.Create<bool>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the Query method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQueryWithSeriesAndSortedAndFilteredAndStage()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        var stage = _fixture.Create<int>();

        // Act
        var result = series.Query(out var sorted, out var filtered, stage);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Query method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryWithSeriesAndSortedAndFilteredAndStageWithNullSeries()
    {
        FluentActions.Invoking(() => default(IInstantSeries).Query(out _, out _, _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }
}