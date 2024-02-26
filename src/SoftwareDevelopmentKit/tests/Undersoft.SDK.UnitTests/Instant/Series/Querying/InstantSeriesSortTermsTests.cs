using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Series.Querying;

namespace Undersoft.SDK.UnitTests.Instant.Series.Querying;

/// <summary>
/// Unit tests for the type <see cref="InstantSeriesSortTerms"/>.
/// </summary>
public class InstantSeriesSortTermsTests
{
    private InstantSeriesSortTerms _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _series;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSeriesSortTerms"/>.
    /// </summary>
    public InstantSeriesSortTermsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._series = _fixture.Freeze<Mock<IInstantSeries>>();
        this._testClass = _fixture.Create<InstantSeriesSortTerms>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSeriesSortTerms();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesSortTerms(this._series.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSeries()
    {
        FluentActions.Invoking(() => new InstantSeriesSortTerms(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithICollectionOfInstantSeriesSortTerm()
    {
        // Arrange
        var terms = _fixture.Create<ICollection<InstantSeriesSortTerm>>();

        // Act
        this._testClass.Add(terms);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the terms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithICollectionOfInstantSeriesSortTermWithNullTerms()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(ICollection<InstantSeriesSortTerm>))).Should().Throw<ArgumentNullException>().WithParameterName("terms");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIInstantSeriesSortTerm()
    {
        // Arrange
        var item = _fixture.Create<IInstantSeriesSortTerm>();

        // Act
        this._testClass.Add(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIInstantSeriesSortTermWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IInstantSeriesSortTerm))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithInstantSeriesSortTerm()
    {
        // Arrange
        var value = _fixture.Create<InstantSeriesSortTerm>();

        // Act
        var result = this._testClass.Add(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithInstantSeriesSortTermWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(InstantSeriesSortTerm))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the AddNew method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddNew()
    {
        // Act
        var result = this._testClass.AddNew();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Clone method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClone()
    {
        // Act
        var result = this._testClass.Clone();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContains()
    {
        // Arrange
        var item = _fixture.Create<IInstantSeriesSortTerm>();

        // Act
        var result = this._testClass.Contains(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Contains(default(IInstantSeriesSortTerm))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the CopyTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyTo()
    {
        // Arrange
        var array = _fixture.Create<IInstantSeriesSortTerm[]>();
        var arrayIndex = _fixture.Create<int>();

        // Act
        this._testClass.CopyTo(array, arrayIndex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyToWithNullArray()
    {
        FluentActions.Invoking(() => this._testClass.CopyTo(default(IInstantSeriesSortTerm[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFind()
    {
        // Arrange
        var data = _fixture.Create<InstantSeriesSortTerm>();

        // Act
        var result = this._testClass.Find(data);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithNullData()
    {
        FluentActions.Invoking(() => this._testClass.Find(default(InstantSeriesSortTerm))).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithNoParameters()
    {
        // Act
        var result = this._testClass.Get();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithRubricNames()
    {
        // Arrange
        var RubricNames = _fixture.Create<List<string>>();

        // Act
        var result = this._testClass.Get(RubricNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the RubricNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithRubricNamesWithNullRubricNames()
    {
        FluentActions.Invoking(() => this._testClass.Get(default(List<string>))).Should().Throw<ArgumentNullException>().WithParameterName("RubricNames");
    }

    /// <summary>
    /// Checks that the Get maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetWithRubricNamesPerformsMapping()
    {
        // Arrange
        var RubricNames = _fixture.Create<List<string>>();

        // Act
        var result = this._testClass.Get(RubricNames);

        // Assert
        result.Capacity.Should().Be(RubricNames.Capacity);
        result.Count.Should().Be(RubricNames.Count);
    }

    /// <summary>
    /// Checks that the GetTerms method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetTerms()
    {
        // Arrange
        var RubricName = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetTerms(RubricName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetTerms method throws when the RubricName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetTermsWithInvalidRubricName(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetTerms(value)).Should().Throw<ArgumentNullException>().WithParameterName("RubricName");
    }

    /// <summary>
    /// Checks that the Have method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallHave()
    {
        // Arrange
        var RubricName = _fixture.Create<string>();

        // Act
        var result = this._testClass.Have(RubricName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Have method throws when the RubricName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallHaveWithInvalidRubricName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Have(value)).Should().Throw<ArgumentNullException>().WithParameterName("RubricName");
    }

    /// <summary>
    /// Checks that the IndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIndexOf()
    {
        // Arrange
        var value = _fixture.Create<object>();

        // Act
        var result = this._testClass.IndexOf(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexOf method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIndexOfWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.IndexOf(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithICollectionOfInstantSeriesSortTerm()
    {
        // Arrange
        var value = _fixture.Create<ICollection<InstantSeriesSortTerm>>();

        // Act
        this._testClass.Remove(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveWithICollectionOfInstantSeriesSortTermWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Remove(default(ICollection<InstantSeriesSortTerm>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithIInstantSeriesSortTerm()
    {
        // Arrange
        var item = _fixture.Create<IInstantSeriesSortTerm>();

        // Act
        var result = this._testClass.Remove(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveWithIInstantSeriesSortTermWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Remove(default(IInstantSeriesSortTerm))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Renew method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRenew()
    {
        // Arrange
        var terms = _fixture.Create<ICollection<InstantSeriesSortTerm>>();

        // Act
        this._testClass.Renew(terms);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Renew method throws when the terms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRenewWithNullTerms()
    {
        FluentActions.Invoking(() => this._testClass.Renew(default(ICollection<InstantSeriesSortTerm>))).Should().Throw<ArgumentNullException>().WithParameterName("terms");
    }

    /// <summary>
    /// Checks that the SetRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetRange()
    {
        // Arrange
        var data = _fixture.Create<InstantSeriesSortTerm[]>();

        // Act
        this._testClass.SetRange(data);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetRange method throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetRangeWithNullData()
    {
        FluentActions.Invoking(() => this._testClass.SetRange(default(InstantSeriesSortTerm[]))).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that the InstantSeriesCreator property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInstantSeriesCreator()
    {
        // Arrange
        var testValue = _fixture.Create<IInstantSeries>();

        // Act
        this._testClass.InstantSeriesCreator = testValue;

        // Assert
        this._testClass.InstantSeriesCreator.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the IsReadOnly property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIsReadOnly()
    {
        // Assert
        this._testClass.IsReadOnly.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }
}