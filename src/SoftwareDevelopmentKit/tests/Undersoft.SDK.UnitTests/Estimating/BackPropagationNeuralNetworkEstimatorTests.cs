using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Estimating;

namespace Undersoft.SDK.UnitTests.Estimating;

/// <summary>
/// Unit tests for the type <see cref="BackPropagationNeuralNetworkEstimator"/>.
/// </summary>
public class BackPropagationNeuralNetworkEstimatorTests
{
    private BackPropagationNeuralNetworkEstimator _testClass;
    private IFixture _fixture;
    private int _numInput;
    private int _numHidden;
    private int _numOutput;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BackPropagationNeuralNetworkEstimator"/>.
    /// </summary>
    public BackPropagationNeuralNetworkEstimatorTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._numInput = _fixture.Create<int>();
        this._numHidden = _fixture.Create<int>();
        this._numOutput = _fixture.Create<int>();
        this._testClass = _fixture.Create<BackPropagationNeuralNetworkEstimator>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new BackPropagationNeuralNetworkEstimator(this._numInput, this._numHidden, this._numOutput);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the SetWeights method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWeights()
    {
        // Arrange
        var weights = _fixture.Create<double[]>();

        // Act
        this._testClass.SetWeights(weights);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetWeights method throws when the weights parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWeightsWithNullWeights()
    {
        FluentActions.Invoking(() => this._testClass.SetWeights(default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("weights");
    }

    /// <summary>
    /// Checks that the GetWeights method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWeights()
    {
        // Act
        var result = this._testClass.GetWeights();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetOutputs method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetOutputs()
    {
        // Act
        var result = this._testClass.GetOutputs();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeOutputs method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeOutputs()
    {
        // Arrange
        var xValues = _fixture.Create<double[]>();

        // Act
        var result = this._testClass.ComputeOutputs(xValues);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeOutputs method throws when the xValues parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeOutputsWithNullXValues()
    {
        FluentActions.Invoking(() => this._testClass.ComputeOutputs(default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("xValues");
    }

    /// <summary>
    /// Checks that the UpdateWeights method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdateWeights()
    {
        // Arrange
        var tValues = _fixture.Create<double[]>();
        var learn = _fixture.Create<double>();
        var mom = _fixture.Create<double>();

        // Act
        this._testClass.UpdateWeights(tValues, learn, mom);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UpdateWeights method throws when the tValues parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateWeightsWithNullTValues()
    {
        FluentActions.Invoking(() => this._testClass.UpdateWeights(default(double[]), _fixture.Create<double>(), _fixture.Create<double>())).Should().Throw<ArgumentNullException>().WithParameterName("tValues");
    }

    /// <summary>
    /// Checks that the CreateMatrix method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateMatrix()
    {
        // Arrange
        var rows = _fixture.Create<int>();
        var cols = _fixture.Create<int>();

        // Act
        var result = BackPropagationNeuralNetworkEstimator.CreateMatrix(rows, cols);

        // Assert
        Assert.Fail("Create or modify test");
    }
}