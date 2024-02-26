using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series;
using Undersoft.SDK.Series.Base;
using Undersoft.SDK.Uniques;
using V = Undersoft.SDK.Origin;

namespace Undersoft.SDK.UnitTests.Series.Base;

/// <summary>
/// Unit tests for the type <see cref="TypedChainBase"/>.
/// </summary>
public class TypedChainBase_1Tests
{
    private class TestTypedChainBase : TypedChainBase<V>
    {
        public TestTypedChainBase(
            IEnumerable<IUnique<V>> collection,
            int capacity = 17,
            HashBits bits = HashBits.bit64
        ) : base(collection, capacity, bits)
        {
        }

        public TestTypedChainBase(
            IEnumerable<V> collection,
            int capacity = 17,
            HashBits bits = HashBits.bit64
        ) : base(collection, capacity, bits)
        {
        }

        public TestTypedChainBase(
            IList<IUnique<V>> collection,
            int capacity = 17,
            HashBits bits = HashBits.bit64
        ) : base(collection, capacity, bits)
        {
        }

        public TestTypedChainBase(IList<V> collection, int capacity = 17, HashBits bits = HashBits.bit64) : base(collection, capacity, bits)
        {
        }

        public TestTypedChainBase(int capacity = 17, HashBits bits = HashBits.bit64) : base(capacity, bits)
        {
        }

        public ISeriesItem<V> PubliccreateNew(ISeriesItem<V> value)
        {
            return base.createNew(value);
        }

        public ISeriesItem<V> PubliccreateNew(long key, V value)
        {
            return base.createNew(key, value);
        }

        public bool PublicInnerAdd(ISeriesItem<V> value)
        {
            return base.InnerAdd(value);
        }

        public bool PublicInnerAdd(long key, V value)
        {
            return base.InnerAdd(key, value);
        }

        public bool PublicInnerAdd(V value)
        {
            return base.InnerAdd(value);
        }

        public void PublicInnerInsert(int index, ISeriesItem<V> item)
        {
            base.InnerInsert(index, item);
        }

        public ISeriesItem<V> PublicInnerPut(ISeriesItem<V> value)
        {
            return base.InnerPut(value);
        }

        public ISeriesItem<V> PublicInnerPut(long key, V value)
        {
            return base.InnerPut(key, value);
        }

        public ISeriesItem<V> PublicInnerPut(V value)
        {
            return base.InnerPut(value);
        }

        public void PublicReindex()
        {
            base.Reindex();
        }

        public override ISeriesItem<V> EmptyItem()
        {
            return default(ISeriesItem<V>);
        }

        public override ISeriesItem<V> NewItem(long key, V value)
        {
            return default(ISeriesItem<V>);
        }

        public override ISeriesItem<V> NewItem(object key, V value)
        {
            return default(ISeriesItem<V>);
        }

        public override ISeriesItem<V> NewItem(ISeriesItem<V> item)
        {
            return default(ISeriesItem<V>);
        }

        public override ISeriesItem<V> NewItem(V item)
        {
            return default(ISeriesItem<V>);
        }

        public override ISeriesItem<V>[] EmptyTable(int size)
        {
            return default(ISeriesItem<V>[]);
        }
    }

    private TestTypedChainBase _testClass;
    private IFixture _fixture;
    private IEnumerable<IUnique<V>> _collectionIEnumerableIUniqueV;
    private int _capacity;
    private HashBits _bits;
    private IEnumerable<V> _collectionIEnumerableV;
    private IList<IUnique<V>> _collectionIListIUniqueV;
    private IList<V> _collectionIListV;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TypedChainBase"/>.
    /// </summary>
    public TypedChainBase_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._collectionIEnumerableIUniqueV = _fixture.Create<IEnumerable<IUnique<V>>>();
        this._capacity = _fixture.Create<int>();
        this._bits = _fixture.Create<HashBits>();
        this._collectionIEnumerableV = _fixture.Create<IEnumerable<V>>();
        this._collectionIListIUniqueV = _fixture.Create<IList<IUnique<V>>>();
        this._collectionIListV = _fixture.Create<IList<V>>();
        this._testClass = _fixture.Create<TestTypedChainBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestTypedChainBase(this._collectionIEnumerableIUniqueV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedChainBase(this._collectionIEnumerableV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedChainBase(this._collectionIListIUniqueV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedChainBase(this._collectionIListV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedChainBase(this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCollection()
    {
        FluentActions.Invoking(() => new TestTypedChainBase(default(IEnumerable<IUnique<V>>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedChainBase(default(IEnumerable<V>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedChainBase(default(IList<IUnique<V>>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedChainBase(default(IList<V>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the GetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetItem()
    {
        // Arrange
        var index = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetItem(index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetItemPerformsMapping()
    {
        // Arrange
        var index = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetItem(index);

        // Assert
        result.Index.Should().Be(index);
    }

    /// <summary>
    /// Checks that the PubliccreateNew method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallcreateNewWithISeriesItemOfV()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.PubliccreateNew(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PubliccreateNew method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallcreateNewWithISeriesItemOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PubliccreateNew(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the PubliccreateNew maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void createNewWithISeriesItemOfVPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.PubliccreateNew(value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the PubliccreateNew method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallcreateNewWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PubliccreateNew(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PubliccreateNew maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void createNewWithLongAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PubliccreateNew(key, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the PublicInnerAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerAddWithISeriesItemOfV()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.PublicInnerAdd(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerAdd method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerAddWithISeriesItemOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerAdd(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the PublicInnerAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerAddWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerAdd(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerAddWithV()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerAdd(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerInsert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerInsert()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        this._testClass.PublicInnerInsert(index, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerInsert method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerInsertWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerInsert(_fixture.Create<int>(), default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicInnerPut method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerPutWithISeriesItemOfV()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.PublicInnerPut(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerPut method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerPutWithISeriesItemOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerPut(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the PublicInnerPut maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void InnerPutWithISeriesItemOfVPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.PublicInnerPut(value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the PublicInnerPut method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerPutWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerPut(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerPut maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void InnerPutWithLongAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerPut(key, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the PublicInnerPut method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerPutWithV()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerPut(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerPut maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void InnerPutWithVPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerPut(value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the PublicReindex method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReindex()
    {
        // Act
        this._testClass.PublicReindex();

        // Assert
        Assert.Fail("Create or modify test");
    }
}