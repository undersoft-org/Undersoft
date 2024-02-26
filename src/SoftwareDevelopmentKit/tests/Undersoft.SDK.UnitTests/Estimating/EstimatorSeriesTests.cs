using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Estimating;

namespace Undersoft.SDK.UnitTests.Estimating;

/// <summary>
/// Unit tests for the type <see cref="EstimatorSeries"/>.
/// </summary>
public class EstimatorSeriesTests
{
    private class TestEstimatorSeries : EstimatorSeries
    {
        public TestEstimatorSeries() : base()
        {
        }

        public TestEstimatorSeries(IList<EstimatorItem> range) : base(range)
        {
        }

        public long PublicGetKeyForItem(EstimatorItem item)
        {
            return base.GetKeyForItem(item);
        }
    }

    private TestEstimatorSeries _testClass;
    private IFixture _fixture;
    private IList<EstimatorItem> _range;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EstimatorSeries"/>.
    /// </summary>
    public EstimatorSeriesTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._range = _fixture.Create<IList<EstimatorItem>>();
        this._testClass = _fixture.Create<TestEstimatorSeries>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestEstimatorSeries();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestEstimatorSeries(this._range);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the range parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRange()
    {
        FluentActions.Invoking(() => new TestEstimatorSeries(default(IList<EstimatorItem>))).Should().Throw<ArgumentNullException>().WithParameterName("range");
    }

    /// <summary>
    /// Checks that the AddRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRange()
    {
        // Arrange
        var range = _fixture.Create<IEnumerable<EstimatorItem>>();

        // Act
        this._testClass.AddRange(range);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRange method throws when the range parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRangeWithNullRange()
    {
        FluentActions.Invoking(() => this._testClass.AddRange(default(IEnumerable<EstimatorItem>))).Should().Throw<ArgumentNullException>().WithParameterName("range");
    }

    /// <summary>
    /// Checks that the PublicGetKeyForItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetKeyForItem()
    {
        // Arrange
        var item = _fixture.Create<EstimatorItem>();

        // Act
        var result = this._testClass.PublicGetKeyForItem(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicGetKeyForItem method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetKeyForItemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicGetKeyForItem(default(EstimatorItem))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }
}