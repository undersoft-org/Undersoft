using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Estimating;

namespace Undersoft.SDK.UnitTests.Estimating;

/// <summary>
/// Unit tests for the type <see cref="EstimatorCluster"/>.
/// </summary>
public class EstimatorClusterTests
{
    private EstimatorCluster _testClass;
    private IFixture _fixture;
    private EstimatorItem _item;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EstimatorCluster"/>.
    /// </summary>
    public EstimatorClusterTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._item = _fixture.Create<EstimatorItem>();
        this._testClass = _fixture.Create<EstimatorCluster>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EstimatorCluster(this._item);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullItem()
    {
        FluentActions.Invoking(() => new EstimatorCluster(default(EstimatorItem))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the RemoveItemFromCluster method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveItemFromCluster()
    {
        // Arrange
        var item = _fixture.Create<EstimatorItem>();

        // Act
        var result = this._testClass.RemoveItemFromCluster(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveItemFromCluster method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveItemFromClusterWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.RemoveItemFromCluster(default(EstimatorItem))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the AddItemToCluster method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddItemToCluster()
    {
        // Arrange
        var item = _fixture.Create<EstimatorItem>();

        // Act
        this._testClass.AddItemToCluster(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddItemToCluster method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddItemToClusterWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.AddItemToCluster(default(EstimatorItem))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ClusterVector property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClusterVector()
    {
        // Arrange
        var testValue = _fixture.Create<double[]>();

        // Act
        this._testClass.ClusterVector = testValue;

        // Assert
        this._testClass.ClusterVector.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the ClusterItems property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClusterItems()
    {
        // Arrange
        var testValue = _fixture.Create<EstimatorSeries>();

        // Act
        this._testClass.ClusterItems = testValue;

        // Assert
        this._testClass.ClusterItems.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the ClusterVectorSummary property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClusterVectorSummary()
    {
        // Arrange
        var testValue = _fixture.Create<double[]>();

        // Act
        this._testClass.ClusterVectorSummary = testValue;

        // Assert
        this._testClass.ClusterVectorSummary.Should().BeSameAs(testValue);
    }
}