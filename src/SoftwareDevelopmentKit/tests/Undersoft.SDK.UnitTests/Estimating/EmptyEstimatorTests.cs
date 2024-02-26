using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Estimating;

namespace Undersoft.SDK.UnitTests.Estimating;

/// <summary>
/// Unit tests for the type <see cref="EmptyEstimator"/>.
/// </summary>
public class EmptyEstimatorTests
{
    private EmptyEstimator _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EmptyEstimator"/>.
    /// </summary>
    public EmptyEstimatorTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<EmptyEstimator>();
    }

    /// <summary>
    /// Checks that the Prepare method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPrepareWithEstimatorInputOfEstimatorSeriesAndEstimatorSeries()
    {
        // Arrange
        var input = _fixture.Create<EstimatorInput<EstimatorSeries, EstimatorSeries>>();

        // Act
        this._testClass.Prepare(input);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Prepare method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPrepareWithEstimatorInputOfEstimatorSeriesAndEstimatorSeriesWithNullInput()
    {
        FluentActions.Invoking(() => this._testClass.Prepare(default(EstimatorInput<EstimatorSeries, EstimatorSeries>))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the Prepare method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPrepareWithEstimatorSeriesAndEstimatorSeries()
    {
        // Arrange
        var x = _fixture.Create<EstimatorSeries>();
        var y = _fixture.Create<EstimatorSeries>();

        // Act
        this._testClass.Prepare(x, y);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Prepare method throws when the x parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPrepareWithEstimatorSeriesAndEstimatorSeriesWithNullX()
    {
        FluentActions.Invoking(() => this._testClass.Prepare(default(EstimatorSeries), _fixture.Create<EstimatorSeries>())).Should().Throw<ArgumentNullException>().WithParameterName("x");
    }

    /// <summary>
    /// Checks that the Prepare method throws when the y parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPrepareWithEstimatorSeriesAndEstimatorSeriesWithNullY()
    {
        FluentActions.Invoking(() => this._testClass.Prepare(_fixture.Create<EstimatorSeries>(), default(EstimatorSeries))).Should().Throw<ArgumentNullException>().WithParameterName("y");
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreate()
    {
        // Act
        this._testClass.Create();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Evaluate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEvaluateWithObject()
    {
        // Arrange
        var x = _fixture.Create<object>();

        // Act
        var result = this._testClass.Evaluate(x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Evaluate method throws when the x parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEvaluateWithObjectWithNullX()
    {
        FluentActions.Invoking(() => this._testClass.Evaluate(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("x");
    }

    /// <summary>
    /// Checks that the Evaluate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEvaluateWithEstimatorItem()
    {
        // Arrange
        var x = _fixture.Create<EstimatorItem>();

        // Act
        var result = this._testClass.Evaluate(x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Evaluate method throws when the x parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEvaluateWithEstimatorItemWithNullX()
    {
        FluentActions.Invoking(() => this._testClass.Evaluate(default(EstimatorItem))).Should().Throw<ArgumentNullException>().WithParameterName("x");
    }

    /// <summary>
    /// Checks that the Update method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdateWithEstimatorInputOfEstimatorSeriesAndEstimatorSeries()
    {
        // Arrange
        var input = _fixture.Create<EstimatorInput<EstimatorSeries, EstimatorSeries>>();

        // Act
        this._testClass.Update(input);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Update method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateWithEstimatorInputOfEstimatorSeriesAndEstimatorSeriesWithNullInput()
    {
        FluentActions.Invoking(() => this._testClass.Update(default(EstimatorInput<EstimatorSeries, EstimatorSeries>))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the Update method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdateWithEstimatorSeriesAndEstimatorSeries()
    {
        // Arrange
        var x = _fixture.Create<EstimatorSeries>();
        var y = _fixture.Create<EstimatorSeries>();

        // Act
        this._testClass.Update(x, y);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Update method throws when the x parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateWithEstimatorSeriesAndEstimatorSeriesWithNullX()
    {
        FluentActions.Invoking(() => this._testClass.Update(default(EstimatorSeries), _fixture.Create<EstimatorSeries>())).Should().Throw<ArgumentNullException>().WithParameterName("x");
    }

    /// <summary>
    /// Checks that the Update method throws when the y parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateWithEstimatorSeriesAndEstimatorSeriesWithNullY()
    {
        FluentActions.Invoking(() => this._testClass.Update(_fixture.Create<EstimatorSeries>(), default(EstimatorSeries))).Should().Throw<ArgumentNullException>().WithParameterName("y");
    }

    /// <summary>
    /// Checks that the GetParameters method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetParameters()
    {
        // Act
        var result = this._testClass.GetParameters();

        // Assert
        Assert.Fail("Create or modify test");
    }
}