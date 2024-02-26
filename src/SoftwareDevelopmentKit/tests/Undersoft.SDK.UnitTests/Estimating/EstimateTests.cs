using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Estimating;

namespace Undersoft.SDK.UnitTests.Estimating;

/// <summary>
/// Unit tests for the type <see cref="Estimate"/>.
/// </summary>
public class EstimateTests
{
    private Estimate _testClass;
    private IFixture _fixture;
    private EstimatorInput<EstimatorSeries, EstimatorSeries> _input;
    private EstimatorMethod _method;
    private EstimatorSeries _x;
    private EstimatorSeries _y;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Estimate"/>.
    /// </summary>
    public EstimateTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._input = _fixture.Create<EstimatorInput<EstimatorSeries, EstimatorSeries>>();
        this._method = _fixture.Create<EstimatorMethod>();
        this._x = _fixture.Create<EstimatorSeries>();
        this._y = _fixture.Create<EstimatorSeries>();
        this._testClass = _fixture.Create<Estimate>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Estimate(this._input, this._method);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Estimate(this._x, this._y, this._method);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInput()
    {
        FluentActions.Invoking(() => new Estimate(default(EstimatorInput<EstimatorSeries, EstimatorSeries>), this._method)).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that instance construction throws when the x parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullX()
    {
        FluentActions.Invoking(() => new Estimate(default(EstimatorSeries), this._y, this._method)).Should().Throw<ArgumentNullException>().WithParameterName("x");
    }

    /// <summary>
    /// Checks that instance construction throws when the y parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullY()
    {
        FluentActions.Invoking(() => new Estimate(this._x, default(EstimatorSeries), this._method)).Should().Throw<ArgumentNullException>().WithParameterName("y");
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
    /// Checks that the SetDefaultMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetDefaultMethod()
    {
        // Arrange
        var @method = _fixture.Create<EstimatorMethod>();

        // Act
        var result = this._testClass.SetDefaultMethod(method);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetAdvancedParameters method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetAdvancedParameters()
    {
        // Arrange
        var advParameters = _fixture.Create<IList<object>>();

        // Act
        this._testClass.SetAdvancedParameters(advParameters);

        // Assert
        Assert.Fail("Create or modify test");
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

    /// <summary>
    /// Checks that the GetDefaultMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDefaultMethod()
    {
        // Act
        var result = this._testClass.GetDefaultMethod();

        // Assert
        Assert.Fail("Create or modify test");
    }
}