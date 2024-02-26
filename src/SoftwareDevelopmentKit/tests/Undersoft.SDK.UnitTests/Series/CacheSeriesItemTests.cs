using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Series;
using V = System.String;

namespace Undersoft.SDK.UnitTests.Series;

/// <summary>
/// Unit tests for the type <see cref="CacheSeriesItem"/>.
/// </summary>
public class CacheSeriesItem_1Tests
{
    private CacheSeriesItem<V> _testClass;
    private IFixture _fixture;
    private Mock<ISeriesItem<V>> _valueISeriesItemV;
    private TimeSpan? _lifeTime;
    private Mock<IInvoker> _deputy;
    private object _keyObject;
    private V _valueUnknownType;
    private long _keyInt64;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="CacheSeriesItem"/>.
    /// </summary>
    public CacheSeriesItem_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._valueISeriesItemV = _fixture.Freeze<Mock<ISeriesItem<V>>>();
        this._lifeTime = _fixture.Create<TimeSpan?>();
        this._deputy = _fixture.Freeze<Mock<IInvoker>>();
        this._keyObject = _fixture.Create<object>();
        this._valueUnknownType = _fixture.Create<V>();
        this._keyInt64 = _fixture.Create<long>();
        this._testClass = _fixture.Create<CacheSeriesItem<V>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new CacheSeriesItem<V>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new CacheSeriesItem<V>(this._valueISeriesItemV.Object, this._lifeTime, this._deputy.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new CacheSeriesItem<V>(this._keyObject, this._valueUnknownType, this._lifeTime, this._deputy.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new CacheSeriesItem<V>(this._keyInt64, this._valueUnknownType, this._lifeTime, this._deputy.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new CacheSeriesItem<V>(this._valueUnknownType, this._lifeTime, this._deputy.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullValue()
    {
        FluentActions.Invoking(() => new CacheSeriesItem<V>(default(ISeriesItem<V>), this._lifeTime, this._deputy.Object)).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new CacheSeriesItem<V>(this._keyObject, default(V), this._lifeTime, this._deputy.Object)).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new CacheSeriesItem<V>(this._keyInt64, default(V), this._lifeTime, this._deputy.Object)).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new CacheSeriesItem<V>(default(V), this._lifeTime, this._deputy.Object)).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that instance construction throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKey()
    {
        FluentActions.Invoking(() => new CacheSeriesItem<V>(default(object), this._valueUnknownType, this._lifeTime, this._deputy.Object)).Should().Throw<ArgumentNullException>().WithParameterName("key");
        FluentActions.Invoking(() => new CacheSeriesItem<V>(default(long), this._valueUnknownType, this._lifeTime, this._deputy.Object)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the SetupExpiration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetupExpiration()
    {
        // Arrange
        var lifetime = _fixture.Create<TimeSpan?>();
        var callback = _fixture.Create<IInvoker>();

        // Act
        this._testClass.SetupExpiration(lifetime, callback);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithISeriesItemOfV()
    {
        // Arrange
        var other = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithISeriesItemOfVWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
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
        var item = _fixture.Create<ISeriesItem<V>>();

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
        FluentActions.Invoking(() => this._testClass.Set(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithKeyAndValue()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<V>();

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
        FluentActions.Invoking(() => this._testClass.Set(default(object), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithValue()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        this._testClass.Set(value);

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
    /// Checks that the Value property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetValue()
    {
        // Arrange
        var testValue = _fixture.Create<V>();

        // Act
        this._testClass.Value = testValue;

        // Assert
        this._testClass.Value.Should().Be(testValue);
    }
}