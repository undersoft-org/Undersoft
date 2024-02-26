using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Estimating;

namespace Undersoft.SDK.UnitTests.Estimating;

/// <summary>
/// Unit tests for the type <see cref="AdaptiveResonainceTheoryEstimator"/>.
/// </summary>
public class AdaptiveResonainceTheoryEstimatorTests
{
    private AdaptiveResonainceTheoryEstimator _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AdaptiveResonainceTheoryEstimator"/>.
    /// </summary>
    public AdaptiveResonainceTheoryEstimatorTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AdaptiveResonainceTheoryEstimator>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AdaptiveResonainceTheoryEstimator();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateWithNoParameters()
    {
        // Act
        this._testClass.Create();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateWithICollectionOfEstimatorItem()
    {
        // Arrange
        var itemCollection = _fixture.Create<ICollection<EstimatorItem>>();

        // Act
        this._testClass.Create(itemCollection);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method throws when the itemCollection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateWithICollectionOfEstimatorItemWithNullItemCollection()
    {
        FluentActions.Invoking(() => this._testClass.Create(default(ICollection<EstimatorItem>))).Should().Throw<ArgumentNullException>().WithParameterName("itemCollection");
    }

    /// <summary>
    /// Checks that the Append method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAppendWithICollectionOfEstimatorItem()
    {
        // Arrange
        var itemCollection = _fixture.Create<ICollection<EstimatorItem>>();

        // Act
        this._testClass.Append(itemCollection);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Append method throws when the itemCollection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAppendWithICollectionOfEstimatorItemWithNullItemCollection()
    {
        FluentActions.Invoking(() => this._testClass.Append(default(ICollection<EstimatorItem>))).Should().Throw<ArgumentNullException>().WithParameterName("itemCollection");
    }

    /// <summary>
    /// Checks that the Append method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAppendWithEstimatorItem()
    {
        // Arrange
        var item = _fixture.Create<EstimatorItem>();

        // Act
        this._testClass.Append(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Append method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAppendWithEstimatorItemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Append(default(EstimatorItem))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the AssignCluster method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAssignCluster()
    {
        // Arrange
        var item = _fixture.Create<EstimatorItem>();

        // Act
        this._testClass.AssignCluster(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AssignCluster method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAssignClusterWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.AssignCluster(default(EstimatorItem))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the AssignHyperCluster method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAssignHyperCluster()
    {
        // Act
        this._testClass.AssignHyperCluster();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SimilarTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSimilarTo()
    {
        // Arrange
        var item = _fixture.Create<EstimatorItem>();

        // Act
        var result = this._testClass.SimilarTo(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SimilarTo method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSimilarToWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.SimilarTo(default(EstimatorItem))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the SimilarInGroupsTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSimilarInGroupsTo()
    {
        // Arrange
        var item = _fixture.Create<EstimatorItem>();

        // Act
        var result = this._testClass.SimilarInGroupsTo(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SimilarInGroupsTo method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSimilarInGroupsToWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.SimilarInGroupsTo(default(EstimatorItem))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the SimilarInOtherGroupsTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSimilarInOtherGroupsTo()
    {
        // Arrange
        var item = _fixture.Create<EstimatorItem>();

        // Act
        var result = this._testClass.SimilarInOtherGroupsTo(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SimilarInOtherGroupsTo method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSimilarInOtherGroupsToWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.SimilarInOtherGroupsTo(default(EstimatorItem))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the CalculateIntersection method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCalculateIntersection()
    {
        // Arrange
        var input = _fixture.Create<EstimatorSeries>();
        var output = _fixture.Create<double[]>();

        // Act
        var result = AdaptiveResonainceTheoryEstimator.CalculateIntersection(input, output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CalculateIntersection method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCalculateIntersectionWithNullInput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.CalculateIntersection(default(EstimatorSeries), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the CalculateIntersection method throws when the output parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCalculateIntersectionWithNullOutput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.CalculateIntersection(_fixture.Create<EstimatorSeries>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("output");
    }

    /// <summary>
    /// Checks that the CalculateSummary method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCalculateSummary()
    {
        // Arrange
        var input = _fixture.Create<EstimatorSeries>();
        var output = _fixture.Create<double[]>();

        // Act
        var result = AdaptiveResonainceTheoryEstimator.CalculateSummary(input, output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CalculateSummary method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCalculateSummaryWithNullInput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.CalculateSummary(default(EstimatorSeries), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the CalculateSummary method throws when the output parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCalculateSummaryWithNullOutput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.CalculateSummary(_fixture.Create<EstimatorSeries>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("output");
    }

    /// <summary>
    /// Checks that the UpdateIntersectionByLast method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdateIntersectionByLast()
    {
        // Arrange
        var input = _fixture.Create<EstimatorSeries>();
        var output = _fixture.Create<double[]>();

        // Act
        var result = AdaptiveResonainceTheoryEstimator.UpdateIntersectionByLast(input, output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UpdateIntersectionByLast method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateIntersectionByLastWithNullInput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.UpdateIntersectionByLast(default(EstimatorSeries), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the UpdateIntersectionByLast method throws when the output parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateIntersectionByLastWithNullOutput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.UpdateIntersectionByLast(_fixture.Create<EstimatorSeries>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("output");
    }

    /// <summary>
    /// Checks that the UpdateSummaryByLast method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdateSummaryByLast()
    {
        // Arrange
        var input = _fixture.Create<EstimatorSeries>();
        var output = _fixture.Create<double[]>();

        // Act
        var result = AdaptiveResonainceTheoryEstimator.UpdateSummaryByLast(input, output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UpdateSummaryByLast method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateSummaryByLastWithNullInput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.UpdateSummaryByLast(default(EstimatorSeries), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the UpdateSummaryByLast method throws when the output parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateSummaryByLastWithNullOutput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.UpdateSummaryByLast(_fixture.Create<EstimatorSeries>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("output");
    }

    /// <summary>
    /// Checks that the CalculateClusterIntersection method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCalculateClusterIntersection()
    {
        // Arrange
        var input = _fixture.Create<List<EstimatorCluster>>();
        var output = _fixture.Create<double[]>();

        // Act
        var result = AdaptiveResonainceTheoryEstimator.CalculateClusterIntersection(input, output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CalculateClusterIntersection method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCalculateClusterIntersectionWithNullInput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.CalculateClusterIntersection(default(List<EstimatorCluster>), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the CalculateClusterIntersection method throws when the output parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCalculateClusterIntersectionWithNullOutput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.CalculateClusterIntersection(_fixture.Create<List<EstimatorCluster>>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("output");
    }

    /// <summary>
    /// Checks that the CalculateClusterSummary method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCalculateClusterSummary()
    {
        // Arrange
        var input = _fixture.Create<List<EstimatorCluster>>();
        var output = _fixture.Create<double[]>();

        // Act
        var result = AdaptiveResonainceTheoryEstimator.CalculateClusterSummary(input, output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CalculateClusterSummary method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCalculateClusterSummaryWithNullInput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.CalculateClusterSummary(default(List<EstimatorCluster>), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the CalculateClusterSummary method throws when the output parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCalculateClusterSummaryWithNullOutput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.CalculateClusterSummary(_fixture.Create<List<EstimatorCluster>>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("output");
    }

    /// <summary>
    /// Checks that the UpdateClusterIntersectionByLast method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdateClusterIntersectionByLast()
    {
        // Arrange
        var input = _fixture.Create<List<EstimatorCluster>>();
        var output = _fixture.Create<double[]>();

        // Act
        var result = AdaptiveResonainceTheoryEstimator.UpdateClusterIntersectionByLast(input, output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UpdateClusterIntersectionByLast method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateClusterIntersectionByLastWithNullInput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.UpdateClusterIntersectionByLast(default(List<EstimatorCluster>), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the UpdateClusterIntersectionByLast method throws when the output parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateClusterIntersectionByLastWithNullOutput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.UpdateClusterIntersectionByLast(_fixture.Create<List<EstimatorCluster>>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("output");
    }

    /// <summary>
    /// Checks that the UpdateClusterSummaryByLast method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdateClusterSummaryByLast()
    {
        // Arrange
        var input = _fixture.Create<List<EstimatorCluster>>();
        var output = _fixture.Create<double[]>();

        // Act
        var result = AdaptiveResonainceTheoryEstimator.UpdateClusterSummaryByLast(input, output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UpdateClusterSummaryByLast method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateClusterSummaryByLastWithNullInput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.UpdateClusterSummaryByLast(default(List<EstimatorCluster>), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the UpdateClusterSummaryByLast method throws when the output parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateClusterSummaryByLastWithNullOutput()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.UpdateClusterSummaryByLast(_fixture.Create<List<EstimatorCluster>>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("output");
    }

    /// <summary>
    /// Checks that the NormalizeItemList method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNormalizeItemList()
    {
        // Arrange
        var featureItemList = _fixture.Create<EstimatorSeries>();

        // Act
        var result = AdaptiveResonainceTheoryEstimator.NormalizeItemList(featureItemList);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NormalizeItemList method throws when the featureItemList parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNormalizeItemListWithNullFeatureItemList()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.NormalizeItemList(default(EstimatorSeries))).Should().Throw<ArgumentNullException>().WithParameterName("featureItemList");
    }

    /// <summary>
    /// Checks that the CalculateVectorMagnitude method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCalculateVectorMagnitude()
    {
        // Arrange
        var vector = _fixture.Create<double[]>();

        // Act
        var result = AdaptiveResonainceTheoryEstimator.CalculateVectorMagnitude(vector);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CalculateVectorMagnitude method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCalculateVectorMagnitudeWithNullVector()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.CalculateVectorMagnitude(default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that the CaulculateVectorIntersectionMagnitude method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCaulculateVectorIntersectionMagnitude()
    {
        // Arrange
        var vector1 = _fixture.Create<double[]>();
        var vector2 = _fixture.Create<double[]>();

        // Act
        var result = AdaptiveResonainceTheoryEstimator.CaulculateVectorIntersectionMagnitude(vector1, vector2
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CaulculateVectorIntersectionMagnitude method throws when the vector1 parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCaulculateVectorIntersectionMagnitudeWithNullVector1()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.CaulculateVectorIntersectionMagnitude(default(double[]), _fixture.Create<double[]>())).Should().Throw<ArgumentNullException>().WithParameterName("vector1");
    }

    /// <summary>
    /// Checks that the CaulculateVectorIntersectionMagnitude method throws when the vector2 parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCaulculateVectorIntersectionMagnitudeWithNullVector2()
    {
        FluentActions.Invoking(() => AdaptiveResonainceTheoryEstimator.CaulculateVectorIntersectionMagnitude(_fixture.Create<double[]>(), default(double[]))).Should().Throw<ArgumentNullException>().WithParameterName("vector2");
    }

    /// <summary>
    /// Checks that the LoadFile method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadFile()
    {
        // Arrange
        var fileLocation = _fixture.Create<string>();

        // Act
        this._testClass.LoadFile(fileLocation);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadFile method throws when the fileLocation parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallLoadFileWithInvalidFileLocation(string value)
    {
        FluentActions.Invoking(() => this._testClass.LoadFile(value)).Should().Throw<ArgumentNullException>().WithParameterName("fileLocation");
    }

    /// <summary>
    /// Checks that the NameList property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNameList()
    {
        // Arrange
        var testValue = _fixture.Create<List<string>>();

        // Act
        this._testClass.NameList = testValue;

        // Assert
        this._testClass.NameList.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the ItemSize property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetItemSize()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.ItemSize = testValue;

        // Assert
        this._testClass.ItemSize.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Items property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetItems()
    {
        // Arrange
        var testValue = _fixture.Create<EstimatorSeries>();

        // Act
        this._testClass.Items = testValue;

        // Assert
        this._testClass.Items.Should().BeSameAs(testValue);
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
    /// Checks that the HyperClusters property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetHyperClusters()
    {
        // Arrange
        var testValue = _fixture.Create<List<EstimatorHyperCluster>>();

        // Act
        this._testClass.HyperClusters = testValue;

        // Assert
        this._testClass.HyperClusters.Should().BeSameAs(testValue);
    }
}