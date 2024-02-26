using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Estimating;

namespace Undersoft.SDK.UnitTests.Estimating;

/// <summary>
/// Unit tests for the type <see cref="Estimator"/>.
/// </summary>
public class EstimatorTests
{
    private class TestEstimator : Estimator
    {
        public static double[][] PublicCreateMatrix(EstimatorSeries input)
        {
            return CreateMatrix(input);
        }

        public override void Prepare(EstimatorInput<EstimatorSeries, EstimatorSeries> input)
        {
        }

        public override void Prepare(EstimatorSeries x, EstimatorSeries y)
        {
        }

        public override void Update(EstimatorInput<EstimatorSeries, EstimatorSeries> input)
        {
        }

        public override void Update(EstimatorSeries x, EstimatorSeries y)
        {
        }

        public override void Create()
        {
        }

        public override EstimatorItem Evaluate(EstimatorItem x)
        {
            return default(EstimatorItem);
        }

        public override EstimatorItem Evaluate(object x)
        {
            return default(EstimatorItem);
        }

        public override double[][] GetParameters()
        {
            return default(double[][]);
        }
    }

    private TestEstimator _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Estimator"/>.
    /// </summary>
    public EstimatorTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestEstimator>();
    }

    /// <summary>
    /// Checks that the PublicCreateMatrix method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateMatrix()
    {
        // Arrange
        var input = _fixture.Create<EstimatorSeries>();

        // Act
        var result = TestEstimator.PublicCreateMatrix(input);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicCreateMatrix method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateMatrixWithNullInput()
    {
        FluentActions.Invoking(() => TestEstimator.PublicCreateMatrix(default(EstimatorSeries))).Should().Throw<ArgumentNullException>().WithParameterName("input");
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
}