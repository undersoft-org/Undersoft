using System;
using System.Collections;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK;
using Undersoft.SDK.Series;
using Undersoft.SDK.Series.Base;
using Undersoft.SDK.Uniques;
using V = System.String;

namespace Undersoft.SDK.UnitTests.Series.Base;

/// <summary>
/// Unit tests for the type <see cref="SeriesItemBase"/>.
/// </summary>
public class SeriesItemBase_1Tests
{
    private class TestSeriesItemBase : SeriesItemBase<V>
    {
        public TestSeriesItemBase() : base()
        {
        }

        public TestSeriesItemBase(ISeriesItem<V> value) : base(value)
        {
        }

        public TestSeriesItemBase(object key, V value) : base(key, value)
        {
        }

        public TestSeriesItemBase(long key, V value) : base(key, value)
        {
        }

        public TestSeriesItemBase(V value) : base(value)
        {
        }

        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public override int CompareTo(object other)
        {
            return default(int);
        }

        public override bool Equals(object y)
        {
            return default(bool);
        }

        public override byte[] GetBytes()
        {
            return default(byte[]);
        }

        public override int GetHashCode()
        {
            return default(int);
        }

        public override byte[] GetIdBytes()
        {
            return default(byte[]);
        }

        public override void Set(ISeriesItem<V> item)
        {
        }

        public override void Set(object key, V value)
        {
        }

        public override void Set(V value)
        {
        }

        public override long Id { get; set; }
    }

    private TestSeriesItemBase _testClass;
    private IFixture _fixture;
    private Mock<ISeriesItem<V>> _valueISeriesItemV;
    private object _keyObject;
    private V _valueUnknownType;
    private long _keyInt64;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SeriesItemBase"/>.
    /// </summary>
    public SeriesItemBase_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._valueISeriesItemV = _fixture.Freeze<Mock<ISeriesItem<V>>>();
        this._keyObject = _fixture.Create<object>();
        this._valueUnknownType = _fixture.Create<V>();
        this._keyInt64 = _fixture.Create<long>();
        this._testClass = _fixture.Create<TestSeriesItemBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestSeriesItemBase();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestSeriesItemBase(this._valueISeriesItemV.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestSeriesItemBase(this._keyObject, this._valueUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestSeriesItemBase(this._keyInt64, this._valueUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestSeriesItemBase(this._valueUnknownType);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullValue()
    {
        FluentActions.Invoking(() => new TestSeriesItemBase(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new TestSeriesItemBase(this._keyObject, default(V))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new TestSeriesItemBase(this._keyInt64, default(V))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new TestSeriesItemBase(default(V))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that instance construction throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKey()
    {
        FluentActions.Invoking(() => new TestSeriesItemBase(default(object), this._valueUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("key");
        FluentActions.Invoking(() => new TestSeriesItemBase(default(long), this._valueUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("key");
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
    public void CanCallCompareToWithIUnique()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithIUniqueWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
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
    /// Checks that the Dispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDisposeWithNoParameters()
    {
        // Act
        this._testClass.Dispose();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithISeriesItemOfV()
    {
        // Arrange
        var y = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.Equals(y);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the y parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithISeriesItemOfVWithNullY()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("y");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithIUnique()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.Equals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithIUniqueWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
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
    /// Checks that the GetUniqueType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetUniqueType()
    {
        // Act
        var result = this._testClass.GetUniqueType();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        this._testClass.Set(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MoveNext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMoveNext()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.MoveNext(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MoveNext method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMoveNextWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.MoveNext(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicDispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDisposeWithDisposing()
    {
        // Arrange
        var disposing = _fixture.Create<bool>();

        // Act
        this._testClass.PublicDispose(disposing);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AsValues method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAsValues()
    {
        // Act
        var result = this._testClass.AsValues();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AsItems method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAsItems()
    {
        // Act
        var result = this._testClass.AsItems();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEnumerator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEnumeratorWithNoParameters()
    {
        // Act
        var result = this._testClass.GetEnumerator();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithIIdentifiable()
    {
        // Arrange
        var other = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.Equals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithIIdentifiableWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithIIdentifiable()
    {
        // Arrange
        var other = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithIIdentifiableWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the GetEnumerator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEnumeratorForIEnumerable_V_WithNoParameters()
    {
        // Act
        var result = ((IEnumerable<V>)this._testClass).GetEnumerator();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEnumerator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEnumeratorForIEnumerableWithNoParameters()
    {
        // Act
        var result = ((IEnumerable)this._testClass).GetEnumerator();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Empty property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetEmpty()
    {
        // Assert
        this._testClass.Empty.Should().BeAssignableTo<IUnique>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Extended property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetExtended()
    {
        // Arrange
        var testValue = _fixture.Create<ISeriesItem<V>>();

        // Act
        this._testClass.Extended = testValue;

        // Assert
        this._testClass.Extended.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Index property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndex()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.Index = testValue;

        // Assert
        this._testClass.Index.Should().Be(testValue);
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
    /// Checks that the Next property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNext()
    {
        // Arrange
        var testValue = _fixture.Create<ISeriesItem<V>>();

        // Act
        this._testClass.Next = testValue;

        // Assert
        this._testClass.Next.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Removed property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRemoved()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.Removed = testValue;

        // Assert
        this._testClass.Removed.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Repeated property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRepeated()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.Repeated = testValue;

        // Assert
        this._testClass.Repeated.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the IsUnique property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsUnique()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.IsUnique = testValue;

        // Assert
        this._testClass.IsUnique.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the UniqueValue property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUniqueValue()
    {
        // Arrange
        var testValue = _fixture.Create<V>();

        // Act
        this._testClass.UniqueValue = testValue;

        // Assert
        this._testClass.UniqueValue.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the TypeId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.TypeId = testValue;

        // Assert
        this._testClass.TypeId.Should().Be(testValue);
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