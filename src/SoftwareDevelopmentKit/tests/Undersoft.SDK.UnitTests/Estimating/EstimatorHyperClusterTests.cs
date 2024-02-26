using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Estimating;

namespace Undersoft.SDK.UnitTests.Estimating;

/// <summary>
/// Unit tests for the type <see cref="EstimatorHyperCluster"/>.
/// </summary>
public class EstimatorHyperClusterTests
{
    private EstimatorHyperCluster _testClass;
    private IFixture _fixture;
    private EstimatorCluster _cluster;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EstimatorHyperCluster"/>.
    /// </summary>
    public EstimatorHyperClusterTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._cluster = _fixture.Create<EstimatorCluster>();
        this._testClass = _fixture.Create<EstimatorHyperCluster>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EstimatorHyperCluster(this._cluster);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the cluster parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCluster()
    {
        FluentActions.Invoking(() => new EstimatorHyperCluster(default(EstimatorCluster))).Should().Throw<ArgumentNullException>().WithParameterName("cluster");
    }

    /// <summary>
    /// Checks that the RemoveClusterFromHyperCluster method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveClusterFromHyperCluster()
    {
        // Arrange
        var cluster = _fixture.Create<EstimatorCluster>();

        // Act
        var result = this._testClass.RemoveClusterFromHyperCluster(cluster);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveClusterFromHyperCluster method throws when the cluster parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveClusterFromHyperClusterWithNullCluster()
    {
        FluentActions.Invoking(() => this._testClass.RemoveClusterFromHyperCluster(default(EstimatorCluster))).Should().Throw<ArgumentNullException>().WithParameterName("cluster");
    }

    /// <summary>
    /// Checks that the AddClusterToHyperCluster method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddClusterToHyperCluster()
    {
        // Arrange
        var cluster = _fixture.Create<EstimatorCluster>();

        // Act
        this._testClass.AddClusterToHyperCluster(cluster);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddClusterToHyperCluster method throws when the cluster parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddClusterToHyperClusterWithNullCluster()
    {
        FluentActions.Invoking(() => this._testClass.AddClusterToHyperCluster(default(EstimatorCluster))).Should().Throw<ArgumentNullException>().WithParameterName("cluster");
    }

    /// <summary>
    /// Checks that the GetHyperClusterItems method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHyperClusterItems()
    {
        // Act
        var result = this._testClass.GetHyperClusterItems();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the HyperClusterVector property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetHyperClusterVector()
    {
        // Arrange
        var testValue = _fixture.Create<double[]>();

        // Act
        this._testClass.HyperClusterVector = testValue;

        // Assert
        this._testClass.HyperClusterVector.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Clusters property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClusters()
    {
        // Arrange
        var testValue = _fixture.Create<List<EstimatorCluster>>();

        // Act
        this._testClass.Clusters = testValue;

        // Assert
        this._testClass.Clusters.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the HyperClusterItems property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetHyperClusterItems()
    {
        // Arrange
        var testValue = _fixture.Create<EstimatorSeries>();

        // Act
        this._testClass.HyperClusterItems = testValue;

        // Assert
        this._testClass.HyperClusterItems.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the HyperClusterVectorSummary property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetHyperClusterVectorSummary()
    {
        // Arrange
        var testValue = _fixture.Create<double[]>();

        // Act
        this._testClass.HyperClusterVectorSummary = testValue;

        // Assert
        this._testClass.HyperClusterVectorSummary.Should().BeSameAs(testValue);
    }
}