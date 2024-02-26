using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Math.Set;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.UnitTests.Instant.Math.Set;

/// <summary>
/// Unit tests for the type <see cref="MathSetItem"/>.
/// </summary>
public class MathSetItemTests
{
    private MathSetItem _testClass;
    private IFixture _fixture;
    private Mock<ISeriesItem<MathSetFormula>> _valueISeriesItemMathSetFormula;
    private long _keyInt64;
    private MathSetFormula _valueMathSetFormula;
    private object _keyObject;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MathSetItem"/>.
    /// </summary>
    public MathSetItemTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._valueISeriesItemMathSetFormula = _fixture.Freeze<Mock<ISeriesItem<MathSetFormula>>>();
        this._keyInt64 = _fixture.Create<long>();
        this._valueMathSetFormula = _fixture.Create<MathSetFormula>();
        this._keyObject = _fixture.Create<object>();
        this._testClass = _fixture.Create<MathSetItem>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new MathSetItem();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MathSetItem(this._valueISeriesItemMathSetFormula.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MathSetItem(this._keyInt64, this._valueMathSetFormula);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MathSetItem(this._valueMathSetFormula);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MathSetItem(this._keyObject, this._valueMathSetFormula);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullValue()
    {
        FluentActions.Invoking(() => new MathSetItem(default(ISeriesItem<MathSetFormula>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new MathSetItem(this._keyInt64, default(MathSetFormula))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new MathSetItem(default(MathSetFormula))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new MathSetItem(this._keyObject, default(MathSetFormula))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that instance construction throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKey()
    {
        FluentActions.Invoking(() => new MathSetItem(default(long), this._valueMathSetFormula)).Should().Throw<ArgumentNullException>().WithParameterName("key");
        FluentActions.Invoking(() => new MathSetItem(default(object), this._valueMathSetFormula)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithISeriesItemOfMathSetFormula()
    {
        // Arrange
        var other = _fixture.Create<ISeriesItem<MathSetFormula>>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithISeriesItemOfMathSetFormulaWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(ISeriesItem<MathSetFormula>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithObject()
    {
        // Arrange
        var other = _fixture.Create<object>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithObjectWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithLong()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.CompareTo(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithY()
    {
        // Arrange
        var y = _fixture.Create<object>();

        // Act
        var result = this._testClass.Equals(y);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the y parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithYWithNullY()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("y");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithLong()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.Equals(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytes()
    {
        // Act
        var result = this._testClass.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCode()
    {
        // Act
        var result = this._testClass.GetHashCode();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIdBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIdBytes()
    {
        // Act
        var result = this._testClass.GetIdBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithItem()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<MathSetFormula>>();

        // Act
        this._testClass.Set(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithItemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(ISeriesItem<MathSetFormula>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithValue()
    {
        // Arrange
        var value = _fixture.Create<MathSetFormula>();

        // Act
        this._testClass.Set(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithValueWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(MathSetFormula))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithKeyAndValue()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<MathSetFormula>();

        // Act
        this._testClass.Set(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithKeyAndValueWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(object), _fixture.Create<MathSetFormula>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Set method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithKeyAndValueWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<object>(), default(MathSetFormula))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Id property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.Id = testValue;

        // Assert
        this._testClass.Id.Should().Be(testValue);
    }
}