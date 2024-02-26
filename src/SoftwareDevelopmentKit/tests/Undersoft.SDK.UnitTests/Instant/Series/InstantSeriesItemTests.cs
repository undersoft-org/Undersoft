using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Series;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.UnitTests.Instant.Series;

/// <summary>
/// Unit tests for the type <see cref="InstantSeriesItem"/>.
/// </summary>
public class InstantSeriesItemTests
{
    private InstantSeriesItem _testClass;
    private IFixture _fixture;
    private object _keyObject;
    private Mock<IInstant> _valueIInstant;
    private ulong _keyUInt64;
    private Mock<ISeriesItem<IInstant>> _valueISeriesItemIInstant;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSeriesItem"/>.
    /// </summary>
    public InstantSeriesItemTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._keyObject = _fixture.Create<object>();
        this._valueIInstant = _fixture.Freeze<Mock<IInstant>>();
        this._keyUInt64 = _fixture.Create<ulong>();
        this._valueISeriesItemIInstant = _fixture.Freeze<Mock<ISeriesItem<IInstant>>>();
        this._testClass = _fixture.Create<InstantSeriesItem>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSeriesItem();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesItem(this._keyObject, this._valueIInstant.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesItem(this._keyUInt64, this._valueIInstant.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesItem(this._valueIInstant.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesItem(this._valueISeriesItemIInstant.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKey()
    {
        FluentActions.Invoking(() => new InstantSeriesItem(default(object), this._valueIInstant.Object)).Should().Throw<ArgumentNullException>().WithParameterName("key");
        FluentActions.Invoking(() => new InstantSeriesItem(default(ulong), this._valueIInstant.Object)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that instance construction throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullValue()
    {
        FluentActions.Invoking(() => new InstantSeriesItem(this._keyObject, default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new InstantSeriesItem(this._keyUInt64, default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new InstantSeriesItem(default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new InstantSeriesItem(default(ISeriesItem<IInstant>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the System.IEquatable interface is implemented correctly.
    /// </summary>
    [TestMethod]
    public void ImplementsIEquatable_IInstant()
    {
        // Arrange
        var same = _fixture.Create<IInstant>();
        var different = _fixture.Create<IInstant>();

        // Assert
        this._testClass.Equals(default(object)).Should().BeFalse();
        this._testClass.Equals(new object()).Should().BeFalse();
        this._testClass.Equals((object)same).Should().BeTrue();
        this._testClass.Equals((object)different).Should().BeFalse();
        this._testClass.Equals(same).Should().BeTrue();
        this._testClass.Equals(different).Should().BeFalse();
        this._testClass.GetHashCode().Should().Be(same.GetHashCode());
        this._testClass.GetHashCode().Should().NotBe(different.GetHashCode());
        (this._testClass == same).Should().BeTrue();
        (this._testClass == different).Should().BeFalse();
        (this._testClass != same).Should().BeFalse();
        (this._testClass != different).Should().BeTrue();
    }

    /// <summary>
    /// Checks that the System.IComparable interface is implemented correctly.
    /// </summary>
    [TestMethod]
    public void ImplementsIComparable_IInstant()
    {
        // Arrange
        InstantSeriesItem baseValue = default(InstantSeriesItem);
        IInstant equalToBaseValue = default(IInstant);
        IInstant greaterThanBaseValue = default(IInstant);

        // Assert
        baseValue.CompareTo(equalToBaseValue).Should().Be(0);
        baseValue.CompareTo(greaterThanBaseValue).Should().BeLessThan(0);
        greaterThanBaseValue.CompareTo(baseValue).Should().BeGreaterThan(0);
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithKeyAndValue()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<IInstant>();

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
        FluentActions.Invoking(() => this._testClass.Set(default(object), _fixture.Create<IInstant>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Set method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithKeyAndValueWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<object>(), default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithValue()
    {
        // Arrange
        var value = _fixture.Create<IInstant>();

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
        FluentActions.Invoking(() => this._testClass.Set(default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithItem()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<IInstant>>();

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
        FluentActions.Invoking(() => this._testClass.Set(default(ISeriesItem<IInstant>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
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
    public void CanCallEqualsWithIInstant()
    {
        // Arrange
        var other = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.Equals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithIInstantWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("other");
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
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithISeriesItemOfIInstant()
    {
        // Arrange
        var other = _fixture.Create<ISeriesItem<IInstant>>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithISeriesItemOfIInstantWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(ISeriesItem<IInstant>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithIInstant()
    {
        // Arrange
        var other = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithIInstantWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("other");
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

    /// <summary>
    /// Checks that the Code property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCode()
    {
        // Arrange
        var testValue = _fixture.Create<Uscn>();

        // Act
        this._testClass.Code = testValue;

        // Assert
        this._testClass.Code.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the InstantSeries property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInstantSeries()
    {
        // Arrange
        var testValue = _fixture.Create<IInstantSeries>();

        // Act
        this._testClass.InstantSeries = testValue;

        // Assert
        this._testClass.InstantSeries.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForInt()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForString()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<string>()] = testValue;
        this._testClass[_fixture.Create<string>()].Should().BeSameAs(testValue);
    }
}