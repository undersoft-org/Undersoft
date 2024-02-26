using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Estimating;

namespace Undersoft.SDK.UnitTests.Estimating;

/// <summary>
/// Unit tests for the type <see cref="EstimatorItem"/>.
/// </summary>
public class EstimatorItemTests
{
    private EstimatorItem _testClass;
    private IFixture _fixture;
    private long _id;
    private string _name;
    private object _vector;
    private EstimatorItem _item;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EstimatorItem"/>.
    /// </summary>
    public EstimatorItemTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._id = _fixture.Create<long>();
        this._name = _fixture.Create<string>();
        this._vector = _fixture.Create<object>();
        this._item = _fixture.Create<EstimatorItem>();
        this._testClass = _fixture.Create<EstimatorItem>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EstimatorItem();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new EstimatorItem(this._id, this._name, this._vector);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new EstimatorItem(this._item);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new EstimatorItem(this._vector);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullVector()
    {
        FluentActions.Invoking(() => new EstimatorItem(this._id, this._name, default(object))).Should().Throw<ArgumentNullException>().WithParameterName("vector");
        FluentActions.Invoking(() => new EstimatorItem(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }

    /// <summary>
    /// Checks that instance construction throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullItem()
    {
        FluentActions.Invoking(() => new EstimatorItem(default(EstimatorItem))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the constructor throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidName(string value)
    {
        FluentActions.Invoking(() => new EstimatorItem(this._id, value, this._vector)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the SetVector method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetVector()
    {
        // Arrange
        var vector = _fixture.Create<object>();

        // Act
        this._testClass.SetVector(vector);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetVector method throws when the vector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetVectorWithNullVector()
    {
        FluentActions.Invoking(() => this._testClass.SetVector(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("vector");
    }
}