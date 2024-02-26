using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Rubrics;

namespace Undersoft.SDK.UnitTests.Instant.Math;

/// <summary>
/// Unit tests for the type <see cref="InstantMathExtensions"/>.
/// </summary>
public class InstantMathExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Compute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeWithIInstantSeries()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();

        // Act
        var result = series.Compute();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compute method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeWithIInstantSeriesWithNullSeries()
    {
        FluentActions.Invoking(() => default(IInstantSeries).Compute()).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the Compute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeWithIInstantSeriesAndIListOfMemberRubric()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        var rubrics = _fixture.Create<IList<MemberRubric>>();

        // Act
        var result = series.Compute(rubrics);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compute method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeWithIInstantSeriesAndIListOfMemberRubricWithNullSeries()
    {
        FluentActions.Invoking(() => default(IInstantSeries).Compute(_fixture.Create<IList<MemberRubric>>())).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the Compute method throws when the rubrics parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeWithIInstantSeriesAndIListOfMemberRubricWithNullRubrics()
    {
        FluentActions.Invoking(() => _fixture.Create<IInstantSeries>().Compute(default(IList<MemberRubric>))).Should().Throw<ArgumentNullException>().WithParameterName("rubrics");
    }

    /// <summary>
    /// Checks that the Compute maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void ComputeWithIInstantSeriesAndIListOfMemberRubricPerformsMapping()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        var rubrics = _fixture.Create<IList<MemberRubric>>();

        // Act
        var result = series.Compute(rubrics);

        // Assert
        result.Rubrics.Should().BeSameAs(rubrics);
    }

    /// <summary>
    /// Checks that the Compute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeWithIInstantSeriesAndIListOfString()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        var rubricNames = _fixture.Create<IList<string>>();

        // Act
        var result = series.Compute(rubricNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compute method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeWithIInstantSeriesAndIListOfStringWithNullSeries()
    {
        FluentActions.Invoking(() => default(IInstantSeries).Compute(_fixture.Create<IList<string>>())).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the Compute method throws when the rubricNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeWithIInstantSeriesAndIListOfStringWithNullRubricNames()
    {
        FluentActions.Invoking(() => _fixture.Create<IInstantSeries>().Compute(default(IList<string>))).Should().Throw<ArgumentNullException>().WithParameterName("rubricNames");
    }

    /// <summary>
    /// Checks that the Compute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeWithSeriesAndRubric()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        var rubric = _fixture.Create<MemberRubric>();

        // Act
        var result = series.Compute(rubric);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compute method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeWithSeriesAndRubricWithNullSeries()
    {
        FluentActions.Invoking(() => default(IInstantSeries).Compute(_fixture.Create<MemberRubric>())).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the Compute method throws when the rubric parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeWithSeriesAndRubricWithNullRubric()
    {
        FluentActions.Invoking(() => _fixture.Create<IInstantSeries>().Compute(default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("rubric");
    }

    /// <summary>
    /// Checks that the Compute maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void ComputeWithSeriesAndRubricPerformsMapping()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        var rubric = _fixture.Create<MemberRubric>();

        // Act
        var result = series.Compute(rubric);

        // Assert
        result.InstantType.Should().BeSameAs(rubric.InstantType);
        result.Rubrics.Should().BeSameAs(rubric.Rubrics);
    }

    /// <summary>
    /// Checks that the ComputeParallel method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeParallelWithIInstantSeries()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();

        // Act
        var result = series.ComputeParallel();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeParallel method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeParallelWithIInstantSeriesWithNullSeries()
    {
        FluentActions.Invoking(() => default(IInstantSeries).ComputeParallel()).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the ComputeParallel method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeParallelWithIInstantSeriesAndIListOfMemberRubric()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        var rubrics = _fixture.Create<IList<MemberRubric>>();

        // Act
        var result = series.ComputeParallel(rubrics);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeParallel method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeParallelWithIInstantSeriesAndIListOfMemberRubricWithNullSeries()
    {
        FluentActions.Invoking(() => default(IInstantSeries).ComputeParallel(_fixture.Create<IList<MemberRubric>>())).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the ComputeParallel method throws when the rubrics parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeParallelWithIInstantSeriesAndIListOfMemberRubricWithNullRubrics()
    {
        FluentActions.Invoking(() => _fixture.Create<IInstantSeries>().ComputeParallel(default(IList<MemberRubric>))).Should().Throw<ArgumentNullException>().WithParameterName("rubrics");
    }

    /// <summary>
    /// Checks that the ComputeParallel maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void ComputeParallelWithIInstantSeriesAndIListOfMemberRubricPerformsMapping()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        var rubrics = _fixture.Create<IList<MemberRubric>>();

        // Act
        var result = series.ComputeParallel(rubrics);

        // Assert
        result.Rubrics.Should().BeSameAs(rubrics);
    }

    /// <summary>
    /// Checks that the ComputeParallel method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeParallelWithIInstantSeriesAndIListOfString()
    {
        // Arrange
        var series = _fixture.Create<IInstantSeries>();
        var rubricNames = _fixture.Create<IList<string>>();

        // Act
        var result = series.ComputeParallel(rubricNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeParallel method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeParallelWithIInstantSeriesAndIListOfStringWithNullSeries()
    {
        FluentActions.Invoking(() => default(IInstantSeries).ComputeParallel(_fixture.Create<IList<string>>())).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the ComputeParallel method throws when the rubricNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeParallelWithIInstantSeriesAndIListOfStringWithNullRubricNames()
    {
        FluentActions.Invoking(() => _fixture.Create<IInstantSeries>().ComputeParallel(default(IList<string>))).Should().Throw<ArgumentNullException>().WithParameterName("rubricNames");
    }
}