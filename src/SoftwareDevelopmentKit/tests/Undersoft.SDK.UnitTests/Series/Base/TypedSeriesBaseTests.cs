using System;
using System.Collections;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Series;
using Undersoft.SDK.Series.Base;
using Undersoft.SDK.Uniques;
using V = Undersoft.SDK.Origin;

namespace Undersoft.SDK.UnitTests.Series.Base;

/// <summary>
/// Unit tests for the type <see cref="TypedSeriesBase"/>.
/// </summary>
public class TypedSeriesBase_1Tests
{
    private class TestTypedSeriesBase : TypedSeriesBase<V>
    {
        public TestTypedSeriesBase(int capacity = 17, HashBits bits = HashBits.bit64) : base(capacity, bits)
        {
        }

        public TestTypedSeriesBase(
                                                                                                  IList<ISeriesItem<V>> collection,
                                                                                                  int capacity = 17,
                                                                                                  HashBits bits = HashBits.bit64
                                                                                              ) : base(collection, capacity, bits)
        {
        }

        public TestTypedSeriesBase(
                                                                                                  IList<V> collection,
                                                                                                  int capacity = 17,
                                                                                                  HashBits bits = HashBits.bit64
                                                                                              ) : base(collection, capacity, bits)
        {
        }

        public TestTypedSeriesBase(
                                                                                                  IEnumerable<ISeriesItem<V>> collection,
                                                                                                  int capacity = 17,
                                                                                                  HashBits bits = HashBits.bit64
                                                                                              ) : base(collection, capacity, bits)
        {
        }

        public TestTypedSeriesBase(
                                                                                                  IEnumerable<V> collection,
                                                                                                  int capacity = 17,
                                                                                                  HashBits bits = HashBits.bit64
                                                                                              ) : base(collection, capacity, bits)
        {
        }

        public int PublicnextSize()
        {
            return base.nextSize();
        }

        public int PublicpreviousSize()
        {
            return base.previousSize();
        }

        public void PubliccountIncrement()
        {
            base.countIncrement();
        }

        public void PublicconflictIncrement()
        {
            base.conflictIncrement();
        }

        public void PublicremovedIncrement()
        {
            base.removedIncrement();
        }

        public void PublicremovedDecrement()
        {
            base.removedDecrement();
        }

        public V PublicInnerGet(long key)
        {
            return base.InnerGet(key);
        }

        public bool PublicInnerTryGet(long key, out ISeriesItem<V> output)
        {
            return base.InnerTryGet(key, out output);
        }

        public ISeriesItem<V> PublicInnerGetItem(long key)
        {
            return base.InnerGetItem(key);
        }

        public ISeriesItem<V> PublicInnerSet(long key, V value)
        {
            return base.InnerSet(key, value);
        }

        public ISeriesItem<V> PublicInnerSet(ISeriesItem<V> value)
        {
            return base.InnerSet(value);
        }

        public ISeriesItem<V> PublicInnerPut(long key, long seed, V value)
        {
            return base.InnerPut(key, seed, value);
        }

        public ISeriesItem<V> PublicInnerPut(V value, long seed)
        {
            return base.InnerPut(value, seed);
        }

        public bool PublicInnerAdd(long key, long seed, V value)
        {
            return base.InnerAdd(key, seed, value);
        }

        public bool PublicInnerAdd(V value, long seed)
        {
            return base.InnerAdd(value, seed);
        }

        public void PublicrenewClear(int capacity)
        {
            base.renewClear(capacity);
        }

        public bool PublicInnerContainsKey(long key)
        {
            return base.InnerContainsKey(key);
        }

        public Func<V, V, bool> PublicgetValueComparer()
        {
            return base.getValueComparer();
        }

        public V PublicInnerRemove(long key)
        {
            return base.InnerRemove(key);
        }

        public V PublicInnerRemove(long key, V item)
        {
            return base.InnerRemove(key, item);
        }

        public int PublicIndexOf(long key, V value)
        {
            return base.IndexOf(key, value);
        }

        public ulong PublicgetPosition(long key)
        {
            return base.getPosition(key);
        }

        public static ulong PublicgetPosition(long key, uint tableMaxId)
        {
            return getPosition(key, tableMaxId);
        }

        public void PublicRehash(int newSize)
        {
            base.Rehash(newSize);
        }

        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public override ISeriesItem<V> GetItem(int index)
        {
            return default(ISeriesItem<V>);
        }

        protected override ISeriesItem<V> InnerPut(long key, V value)
        {
            return default(ISeriesItem<V>);
        }

        protected override ISeriesItem<V> InnerPut(V value)
        {
            return default(ISeriesItem<V>);
        }

        protected override ISeriesItem<V> InnerPut(ISeriesItem<V> value)
        {
            return default(ISeriesItem<V>);
        }

        protected override bool InnerAdd(long key, V value)
        {
            return default(bool);
        }

        protected override bool InnerAdd(V value)
        {
            return default(bool);
        }

        protected override bool InnerAdd(ISeriesItem<V> value)
        {
            return default(bool);
        }

        protected override void InnerInsert(int index, ISeriesItem<V> item)
        {
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

    private TestTypedSeriesBase _testClass;
    private IFixture _fixture;
    private int _capacity;
    private HashBits _bits;
    private IList<ISeriesItem<V>> _collectionIListISeriesItemV;
    private IList<V> _collectionIListV;
    private IEnumerable<ISeriesItem<V>> _collectionIEnumerableISeriesItemV;
    private IEnumerable<V> _collectionIEnumerableV;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TypedSeriesBase"/>.
    /// </summary>
    public TypedSeriesBase_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._capacity = _fixture.Create<int>();
        this._bits = _fixture.Create<HashBits>();
        this._collectionIListISeriesItemV = _fixture.Create<IList<ISeriesItem<V>>>();
        this._collectionIListV = _fixture.Create<IList<V>>();
        this._collectionIEnumerableISeriesItemV = _fixture.Create<IEnumerable<ISeriesItem<V>>>();
        this._collectionIEnumerableV = _fixture.Create<IEnumerable<V>>();
        this._testClass = _fixture.Create<TestTypedSeriesBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestTypedSeriesBase(this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedSeriesBase(this._collectionIListISeriesItemV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedSeriesBase(this._collectionIListV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedSeriesBase(this._collectionIEnumerableISeriesItemV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedSeriesBase(this._collectionIEnumerableV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCollection()
    {
        FluentActions.Invoking(() => new TestTypedSeriesBase(default(IList<ISeriesItem<V>>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedSeriesBase(default(IList<V>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedSeriesBase(default(IEnumerable<ISeriesItem<V>>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedSeriesBase(default(IEnumerable<V>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the PublicnextSize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallnextSize()
    {
        // Act
        var result = this._testClass.PublicnextSize();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicpreviousSize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallpreviousSize()
    {
        // Act
        var result = this._testClass.PublicpreviousSize();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PubliccountIncrement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallcountIncrement()
    {
        // Act
        this._testClass.PubliccountIncrement();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicconflictIncrement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallconflictIncrement()
    {
        // Act
        this._testClass.PublicconflictIncrement();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicremovedIncrement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallremovedIncrement()
    {
        // Act
        this._testClass.PublicremovedIncrement();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicremovedDecrement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallremovedDecrement()
    {
        // Act
        this._testClass.PublicremovedDecrement();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerGet()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerGet(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithLong()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.Get(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithObject()
    {
        // Arrange
        var key = _fixture.Create<object>();

        // Act
        var result = this._testClass.Get(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithObjectWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Get(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithObjectAndLong()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Get(key, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithObjectAndLongWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Get(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithIIdentifiable()
    {
        // Arrange
        var key = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.Get(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithIIdentifiableWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Get(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithIUniqueOfV()
    {
        // Arrange
        var key = _fixture.Create<IUnique<V>>();

        // Act
        var result = this._testClass.Get(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithIUniqueOfVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Get(default(IUnique<V>))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the PublicInnerTryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerTryGet()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerTryGet(key, out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetWithLongAndISeriesItemOfV()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.TryGet(key, out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetWithObjectAndISeriesItemOfV()
    {
        // Arrange
        var key = _fixture.Create<object>();

        // Act
        var result = this._testClass.TryGet(key, out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGet method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryGetWithObjectAndISeriesItemOfVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.TryGet(default(object), out _)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the TryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetWithObjectAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();

        // Act
        var result = this._testClass.TryGet(key, out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGet method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryGetWithObjectAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.TryGet(default(object), out _)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the TryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetWithObjectAndLongAndISeriesItemOfV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.TryGet(key, seed, out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGet method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryGetWithObjectAndLongAndISeriesItemOfVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.TryGet(default(object), _fixture.Create<long>(), out _)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the TryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetWithObjectAndLongAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.TryGet(key, seed, out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGet method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryGetWithObjectAndLongAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.TryGet(default(object), _fixture.Create<long>(), out _)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the TryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.TryGet(key, out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetWithIIdentifiableAndISeriesItemOfV()
    {
        // Arrange
        var key = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.TryGet(key, out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGet method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryGetWithIIdentifiableAndISeriesItemOfVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.TryGet(default(IIdentifiable), out _)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the TryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetWithIUniqueOfVAndISeriesItemOfV()
    {
        // Arrange
        var key = _fixture.Create<IUnique<V>>();

        // Act
        var result = this._testClass.TryGet(key, out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGet method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryGetWithIUniqueOfVAndISeriesItemOfVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.TryGet(default(IUnique<V>), out _)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the PublicInnerGetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerGetItem()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerGetItem(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetItemWithLong()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.GetItem(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetItemWithIIdentifiable()
    {
        // Arrange
        var key = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.GetItem(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetItem method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetItemWithIIdentifiableWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.GetItem(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the GetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetItemWithIUniqueOfV()
    {
        // Arrange
        var key = _fixture.Create<IUnique<V>>();

        // Act
        var result = this._testClass.GetItem(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetItem method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetItemWithIUniqueOfVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.GetItem(default(IUnique<V>))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the PublicInnerSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerSetWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerSet(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerSet maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void InnerSetWithLongAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerSet(key, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the PublicInnerSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerSetWithISeriesItemOfV()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.PublicInnerSet(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerSet method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerSetWithISeriesItemOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerSet(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the PublicInnerSet maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void InnerSetWithISeriesItemOfVPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.PublicInnerSet(value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithObjectAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Set(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithObjectAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(object), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Set maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void SetWithObjectAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Set(key, value);

        // Assert
        result.Value.Should().Be(value);
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
        var result = this._testClass.Set(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void SetWithLongAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Set(key, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithIIdentifiableAndV()
    {
        // Arrange
        var key = _fixture.Create<IIdentifiable>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Set(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithIIdentifiableAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(IIdentifiable), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Set maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void SetWithIIdentifiableAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<IIdentifiable>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Set(key, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithIUniqueOfVAndV()
    {
        // Arrange
        var key = _fixture.Create<IUnique<V>>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Set(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithIUniqueOfVAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(IUnique<V>), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Set maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void SetWithIUniqueOfVAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<IUnique<V>>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Set(key, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithV()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Set(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void SetWithVPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Set(value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithIUniqueOfV()
    {
        // Arrange
        var value = _fixture.Create<IUnique<V>>();

        // Act
        var result = this._testClass.Set(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithIUniqueOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(IUnique<V>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Set maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void SetWithIUniqueOfVPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<IUnique<V>>();

        // Act
        var result = this._testClass.Set(value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithISeriesItemOfV()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.Set(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithISeriesItemOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Set maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void SetWithISeriesItemOfVPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.Set(value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithIEnumerableOfV()
    {
        // Arrange
        var values = _fixture.Create<IEnumerable<V>>();

        // Act
        var result = this._testClass.Set(values);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the values parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithIEnumerableOfVWithNullValues()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("values");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithIListOfV()
    {
        // Arrange
        var values = _fixture.Create<IList<V>>();

        // Act
        var result = this._testClass.Set(values);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the values parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithIListOfVWithNullValues()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(IList<V>))).Should().Throw<ArgumentNullException>().WithParameterName("values");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithIEnumerableOfISeriesItemOfV()
    {
        // Arrange
        var values = _fixture.Create<IEnumerable<ISeriesItem<V>>>();

        // Act
        var result = this._testClass.Set(values);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the values parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithIEnumerableOfISeriesItemOfVWithNullValues()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(IEnumerable<ISeriesItem<V>>))).Should().Throw<ArgumentNullException>().WithParameterName("values");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithIEnumerableOfIUniqueOfV()
    {
        // Arrange
        var values = _fixture.Create<IEnumerable<IUnique<V>>>();

        // Act
        var result = this._testClass.Set(values);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the values parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithIEnumerableOfIUniqueOfVWithNullValues()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(IEnumerable<IUnique<V>>))).Should().Throw<ArgumentNullException>().WithParameterName("values");
    }

    /// <summary>
    /// Checks that the EnsureGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEnsureGetWithObjectAndFuncOfLongAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        Func<long, V> sureaction = x => _fixture.Create<V>();

        // Act
        var result = this._testClass.EnsureGet(key, sureaction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EnsureGet method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEnsureGetWithObjectAndFuncOfLongAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.EnsureGet(default(object), x => _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the EnsureGet method throws when the sureaction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEnsureGetWithObjectAndFuncOfLongAndVWithNullSureaction()
    {
        FluentActions.Invoking(() => this._testClass.EnsureGet(_fixture.Create<object>(), default(Func<long, V>))).Should().Throw<ArgumentNullException>().WithParameterName("sureaction");
    }

    /// <summary>
    /// Checks that the EnsureGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEnsureGetWithLongAndFuncOfLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        Func<long, V> sureaction = x => _fixture.Create<V>();

        // Act
        var result = this._testClass.EnsureGet(key, sureaction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EnsureGet method throws when the sureaction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEnsureGetWithLongAndFuncOfLongAndVWithNullSureaction()
    {
        FluentActions.Invoking(() => this._testClass.EnsureGet(_fixture.Create<long>(), default(Func<long, V>))).Should().Throw<ArgumentNullException>().WithParameterName("sureaction");
    }

    /// <summary>
    /// Checks that the EnsureGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEnsureGetWithIIdentifiableAndFuncOfLongAndV()
    {
        // Arrange
        var key = _fixture.Create<IIdentifiable>();
        Func<long, V> sureaction = x => _fixture.Create<V>();

        // Act
        var result = this._testClass.EnsureGet(key, sureaction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EnsureGet method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEnsureGetWithIIdentifiableAndFuncOfLongAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.EnsureGet(default(IIdentifiable), x => _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the EnsureGet method throws when the sureaction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEnsureGetWithIIdentifiableAndFuncOfLongAndVWithNullSureaction()
    {
        FluentActions.Invoking(() => this._testClass.EnsureGet(_fixture.Create<IIdentifiable>(), default(Func<long, V>))).Should().Throw<ArgumentNullException>().WithParameterName("sureaction");
    }

    /// <summary>
    /// Checks that the EnsureGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEnsureGetWithIUniqueOfVAndFuncOfLongAndV()
    {
        // Arrange
        var key = _fixture.Create<IUnique<V>>();
        Func<long, V> sureaction = x => _fixture.Create<V>();

        // Act
        var result = this._testClass.EnsureGet(key, sureaction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EnsureGet method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEnsureGetWithIUniqueOfVAndFuncOfLongAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.EnsureGet(default(IUnique<V>), x => _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the EnsureGet method throws when the sureaction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEnsureGetWithIUniqueOfVAndFuncOfLongAndVWithNullSureaction()
    {
        FluentActions.Invoking(() => this._testClass.EnsureGet(_fixture.Create<IUnique<V>>(), default(Func<long, V>))).Should().Throw<ArgumentNullException>().WithParameterName("sureaction");
    }

    /// <summary>
    /// Checks that the GetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetItemWithObject()
    {
        // Arrange
        var key = _fixture.Create<object>();

        // Act
        var result = this._testClass.GetItem(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetItem method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetItemWithObjectWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.GetItem(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the GetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetItemWithObjectAndLong()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.GetItem(key, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetItem method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetItemWithObjectAndLongWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.GetItem(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the PublicInnerPut method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerPutWithLongAndLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var seed = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerPut(key, seed, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerPut maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void InnerPutWithLongAndLongAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var seed = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerPut(key, seed, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the PublicInnerPut method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerPutWithVAndLong()
    {
        // Arrange
        var value = _fixture.Create<V>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerPut(value, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerPut maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void InnerPutWithVAndLongPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<V>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerPut(value, seed);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithLongAndObject()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<object>();

        // Act
        var result = this._testClass.Put(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithLongAndObjectWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Put(_fixture.Create<long>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Put maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void PutWithLongAndObjectPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<object>();

        // Act
        var result = this._testClass.Put(key, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Put(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void PutWithLongAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Put(key, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithObjectAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Put(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithObjectAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(object), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Put maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void PutWithObjectAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Put(key, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithObjectAndLongAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Put(key, seed, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithObjectAndLongAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(object), _fixture.Create<long>(), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Put maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void PutWithObjectAndLongAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Put(key, seed, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithObjectAndLongAndObject()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();
        var value = _fixture.Create<object>();

        // Act
        var result = this._testClass.Put(key, seed, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithObjectAndLongAndObjectWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(object), _fixture.Create<long>(), _fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Put method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithObjectAndLongAndObjectWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Put(_fixture.Create<object>(), _fixture.Create<long>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Put maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void PutWithObjectAndLongAndObjectPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();
        var value = _fixture.Create<object>();

        // Act
        var result = this._testClass.Put(key, seed, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithISeriesItemOfV()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.Put(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithISeriesItemOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithIListOfISeriesItemOfV()
    {
        // Arrange
        var items = _fixture.Create<IList<ISeriesItem<V>>>();

        // Act
        this._testClass.Put(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithIListOfISeriesItemOfVWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(IList<ISeriesItem<V>>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithIEnumerableOfISeriesItemOfV()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<ISeriesItem<V>>>();

        // Act
        this._testClass.Put(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithIEnumerableOfISeriesItemOfVWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(IEnumerable<ISeriesItem<V>>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithV()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Put(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void PutWithVPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Put(value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithIListOfV()
    {
        // Arrange
        var items = _fixture.Create<IList<V>>();

        // Act
        this._testClass.Put(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithIListOfVWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(IList<V>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithIEnumerableOfV()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<V>>();

        // Act
        this._testClass.Put(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithIEnumerableOfVWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithVAndLong()
    {
        // Arrange
        var value = _fixture.Create<V>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Put(value, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void PutWithVAndLongPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<V>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Put(value, seed);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithObjectAndLong()
    {
        // Arrange
        var value = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        this._testClass.Put(value, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithObjectAndLongWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithIListOfVAndLong()
    {
        // Arrange
        var items = _fixture.Create<IList<V>>();
        var seed = _fixture.Create<long>();

        // Act
        this._testClass.Put(items, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithIListOfVAndLongWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(IList<V>), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithIEnumerableOfVAndLong()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<V>>();
        var seed = _fixture.Create<long>();

        // Act
        this._testClass.Put(items, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithIEnumerableOfVAndLongWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(IEnumerable<V>), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithIUniqueOfV()
    {
        // Arrange
        var value = _fixture.Create<IUnique<V>>();

        // Act
        var result = this._testClass.Put(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithIUniqueOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(IUnique<V>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Put maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void PutWithIUniqueOfVPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<IUnique<V>>();

        // Act
        var result = this._testClass.Put(value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithIListOfIUniqueOfV()
    {
        // Arrange
        var value = _fixture.Create<IList<IUnique<V>>>();

        // Act
        this._testClass.Put(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithIListOfIUniqueOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(IList<IUnique<V>>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithIEnumerableOfIUniqueOfV()
    {
        // Arrange
        var value = _fixture.Create<IEnumerable<IUnique<V>>>();

        // Act
        this._testClass.Put(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithIEnumerableOfIUniqueOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(IEnumerable<IUnique<V>>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the PublicInnerAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerAddWithLongAndLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var seed = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerAdd(key, seed, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerAddWithVAndLong()
    {
        // Arrange
        var value = _fixture.Create<V>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerAdd(value, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithLongAndObject()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<object>();

        // Act
        var result = this._testClass.Add(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithLongAndObjectWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Add(_fixture.Create<long>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Add(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithObjectAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Add(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithObjectAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(object), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithObjectAndLongAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Add(key, seed, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithObjectAndLongAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(object), _fixture.Create<long>(), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithISeriesItemOfV()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        this._testClass.Add(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithISeriesItemOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithItemList()
    {
        // Arrange
        var itemList = _fixture.Create<IList<ISeriesItem<V>>>();

        // Act
        this._testClass.Add(itemList);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the itemList parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithItemListWithNullItemList()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IList<ISeriesItem<V>>))).Should().Throw<ArgumentNullException>().WithParameterName("itemList");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithItemTable()
    {
        // Arrange
        var itemTable = _fixture.Create<IEnumerable<ISeriesItem<V>>>();

        // Act
        this._testClass.Add(itemTable);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the itemTable parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithItemTableWithNullItemTable()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IEnumerable<ISeriesItem<V>>))).Should().Throw<ArgumentNullException>().WithParameterName("itemTable");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithV()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        this._testClass.Add(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIListOfV()
    {
        // Arrange
        var items = _fixture.Create<IList<V>>();

        // Act
        this._testClass.Add(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIListOfVWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IList<V>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIEnumerableOfV()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<V>>();

        // Act
        this._testClass.Add(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIEnumerableOfVWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithVAndLong()
    {
        // Arrange
        var value = _fixture.Create<V>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Add(value, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIListOfVAndLong()
    {
        // Arrange
        var items = _fixture.Create<IList<V>>();
        var seed = _fixture.Create<long>();

        // Act
        this._testClass.Add(items, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIListOfVAndLongWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IList<V>), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIEnumerableOfVAndLong()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<V>>();
        var seed = _fixture.Create<long>();

        // Act
        this._testClass.Add(items, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIEnumerableOfVAndLongWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IEnumerable<V>), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIUniqueOfV()
    {
        // Arrange
        var value = _fixture.Create<IUnique<V>>();

        // Act
        this._testClass.Add(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIUniqueOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IUnique<V>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIListOfIUniqueOfV()
    {
        // Arrange
        var value = _fixture.Create<IList<IUnique<V>>>();

        // Act
        this._testClass.Add(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIListOfIUniqueOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IList<IUnique<V>>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIEnumerableOfIUniqueOfV()
    {
        // Arrange
        var value = _fixture.Create<IEnumerable<IUnique<V>>>();

        // Act
        this._testClass.Add(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIEnumerableOfIUniqueOfVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IEnumerable<IUnique<V>>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the TryAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAddWithV()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.TryAdd(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAddWithVAndLong()
    {
        // Arrange
        var value = _fixture.Create<V>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.TryAdd(value, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithNoParameters()
    {
        // Act
        var result = this._testClass.New();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithLong()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.New(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithObject()
    {
        // Arrange
        var key = _fixture.Create<object>();

        // Act
        var result = this._testClass.New(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithObjectWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.New(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithObjectAndLong()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.New(key, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithObjectAndLongWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.New(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Insert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsertWithIntAndISeriesItemOfV()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        this._testClass.Insert(index, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Insert method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInsertWithIntAndISeriesItemOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Insert(_fixture.Create<int>(), default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Insert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsertWithIntAndV()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var item = _fixture.Create<V>();

        // Act
        this._testClass.Insert(index, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Enqueue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEnqueueWithV()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Enqueue(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Enqueue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEnqueueWithObjectAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Enqueue(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Enqueue method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEnqueueWithObjectAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Enqueue(default(object), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Enqueue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEnqueueWithVAndLong()
    {
        // Arrange
        var value = _fixture.Create<V>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Enqueue(value, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Enqueue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEnqueueWithObjectAndLongAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Enqueue(key, seed, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Enqueue method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEnqueueWithObjectAndLongAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Enqueue(default(object), _fixture.Create<long>(), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Enqueue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEnqueueWithISeriesItemOfV()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        this._testClass.Enqueue(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Enqueue method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEnqueueWithISeriesItemOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Enqueue(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the TryPick method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryPickWithIntAndV()
    {
        // Arrange
        var skip = _fixture.Create<int>();

        // Act
        var result = this._testClass.TryPick(skip, out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryPick method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryPickWithIntAndISeriesItemOfV()
    {
        // Arrange
        var skip = _fixture.Create<int>();

        // Act
        var result = this._testClass.TryPick(skip, out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Dequeue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDequeue()
    {
        // Act
        var result = this._testClass.Dequeue();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryDequeue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryDequeueWithV()
    {
        // Act
        var result = this._testClass.TryDequeue(out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryDequeue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryDequeueWithISeriesItemOfV()
    {
        // Act
        var result = this._testClass.TryDequeue(out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryTake method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryTake()
    {
        // Act
        var result = this._testClass.TryTake(out var output);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicrenewClear method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallrenewClear()
    {
        // Arrange
        var capacity = _fixture.Create<int>();

        // Act
        this._testClass.PublicrenewClear(capacity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Renew method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRenewWithIEnumerableOfV()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<V>>();

        // Act
        this._testClass.Renew(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Renew method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRenewWithIEnumerableOfVWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Renew(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Renew method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRenewWithIListOfV()
    {
        // Arrange
        var items = _fixture.Create<IList<V>>();

        // Act
        this._testClass.Renew(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Renew method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRenewWithIListOfVWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Renew(default(IList<V>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Renew method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRenewWithIListOfISeriesItemOfV()
    {
        // Arrange
        var items = _fixture.Create<IList<ISeriesItem<V>>>();

        // Act
        this._testClass.Renew(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Renew method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRenewWithIListOfISeriesItemOfVWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Renew(default(IList<ISeriesItem<V>>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Renew method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRenewWithIEnumerableOfISeriesItemOfV()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<ISeriesItem<V>>>();

        // Act
        this._testClass.Renew(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Renew method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRenewWithIEnumerableOfISeriesItemOfVWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Renew(default(IEnumerable<ISeriesItem<V>>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the PublicInnerContainsKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerContainsKey()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerContainsKey(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ContainsKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsKeyWithObject()
    {
        // Arrange
        var key = _fixture.Create<object>();

        // Act
        var result = this._testClass.ContainsKey(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ContainsKey method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsKeyWithObjectWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.ContainsKey(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the ContainsKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsKeyWithObjectAndLong()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.ContainsKey(key, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ContainsKey method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsKeyWithObjectAndLongWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.ContainsKey(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the ContainsKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsKeyWithLong()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.ContainsKey(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ContainsKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsKeyWithIIdentifiable()
    {
        // Arrange
        var key = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.ContainsKey(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ContainsKey method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsKeyWithIIdentifiableWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.ContainsKey(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsWithISeriesItemOfV()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.Contains(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsWithISeriesItemOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Contains(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsWithIUniqueOfV()
    {
        // Arrange
        var item = _fixture.Create<IUnique<V>>();

        // Act
        var result = this._testClass.Contains(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsWithIUniqueOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Contains(default(IUnique<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsWithV()
    {
        // Arrange
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.Contains(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsWithVAndLong()
    {
        // Arrange
        var item = _fixture.Create<V>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Contains(item, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.Contains(key, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicgetValueComparer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallgetValueComparer()
    {
        // Act
        var result = this._testClass.PublicgetValueComparer();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerRemove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerRemoveWithLong()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerRemove(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerRemove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerRemoveWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerRemove(key, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithV()
    {
        // Arrange
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.Remove(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithObject()
    {
        // Arrange
        var key = _fixture.Create<object>();

        // Act
        var result = this._testClass.Remove(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveWithObjectWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Remove(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithObjectAndLong()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Remove(key, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveWithObjectAndLongWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Remove(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithISeriesItemOfV()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.Remove(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveWithISeriesItemOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Remove(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithIUniqueOfV()
    {
        // Arrange
        var item = _fixture.Create<IUnique<V>>();

        // Act
        var result = this._testClass.Remove(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveWithIUniqueOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Remove(default(IUnique<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the TryRemove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryRemoveWithObject()
    {
        // Arrange
        var key = _fixture.Create<object>();

        // Act
        var result = this._testClass.TryRemove(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryRemove method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryRemoveWithObjectWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.TryRemove(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the TryRemove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryRemoveWithObjectAndLong()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.TryRemove(key, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryRemove method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryRemoveWithObjectAndLongWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.TryRemove(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the RemoveAt method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveAt()
    {
        // Arrange
        var index = _fixture.Create<int>();

        // Act
        this._testClass.RemoveAt(index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithObjectAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.Remove(key, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveWithObjectAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Remove(default(object), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Clear method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClear()
    {
        // Act
        this._testClass.Clear();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Flush method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFlush()
    {
        // Act
        this._testClass.Flush();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyToWithArrayOfISeriesItemOfVAndInt()
    {
        // Arrange
        var array = _fixture.Create<ISeriesItem<V>[]>();
        var index = _fixture.Create<int>();

        // Act
        this._testClass.CopyTo(array, index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyToWithArrayOfISeriesItemOfVAndIntWithNullArray()
    {
        FluentActions.Invoking(() => this._testClass.CopyTo(default(ISeriesItem<V>[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the CopyTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyToWithArrayAndInt()
    {
        // Arrange
        var array = _fixture.Create<Array>();
        var index = _fixture.Create<int>();

        // Act
        this._testClass.CopyTo(array, index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyToWithArrayAndIntWithNullArray()
    {
        FluentActions.Invoking(() => this._testClass.CopyTo(default(Array), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the CopyTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyToWithArrayOfVAndInt()
    {
        // Arrange
        var array = _fixture.Create<V[]>();
        var index = _fixture.Create<int>();

        // Act
        this._testClass.CopyTo(array, index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyToWithArrayOfVAndIntWithNullArray()
    {
        FluentActions.Invoking(() => this._testClass.CopyTo(default(V[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the ToArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToArray()
    {
        // Act
        var result = this._testClass.ToArray();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToObjectArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToObjectArray()
    {
        // Act
        var result = this._testClass.ToObjectArray();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Next method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNext()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.Next(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Next method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNextWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Next(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Resize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallResize()
    {
        // Arrange
        var size = _fixture.Create<int>();

        // Act
        this._testClass.Resize(size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithLongAndLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var seed = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(key, seed, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithLongAndLongAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var seed = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(key, seed, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithObjectAndLongAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(key, seed, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndLongAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(object), _fixture.Create<long>(), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithObjectAndLongAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var seed = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(key, seed, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithVAndLong()
    {
        // Arrange
        var item = _fixture.Create<V>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.NewItem(item, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIndexOfWithISeriesItemOfV()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.IndexOf(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIndexOfWithISeriesItemOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.IndexOf(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the IndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIndexOfWithV()
    {
        // Arrange
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.IndexOf(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicIndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIndexOfWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicIndexOf(key, value);

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
    /// Checks that the GetUniqueEnumerator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetUniqueEnumerator()
    {
        // Act
        var result = this._testClass.GetUniqueEnumerator();

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
    /// Checks that the GetKeyEnumerator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetKeyEnumerator()
    {
        // Act
        var result = this._testClass.GetKeyEnumerator();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicgetPosition method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallgetPositionWithLong()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicgetPosition(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicgetPosition method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallgetPositionWithKeyAndTableMaxId()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var tableMaxId = _fixture.Create<uint>();

        // Act
        var result = TestTypedSeriesBase.PublicgetPosition(key, tableMaxId);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRehash method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRehash()
    {
        // Arrange
        var newSize = _fixture.Create<int>();

        // Act
        this._testClass.PublicRehash(newSize);

        // Assert
        Assert.Fail("Create or modify test");
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
    public void CanCallEquals()
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
    public void CannotCallEqualsWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareTo()
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
    public void CannotCallCompareToWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the GetList method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetList()
    {
        // Act
        var result = this._testClass.GetList();

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
    /// Checks that the First property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetFirst()
    {
        // Assert
        this._testClass.First.Should().BeAssignableTo<ISeriesItem<V>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Last property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetLast()
    {
        // Assert
        this._testClass.Last.Should().BeAssignableTo<ISeriesItem<V>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Size property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSize()
    {
        // Assert
        this._testClass.Size.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Count property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetCount()
    {
        // Assert
        this._testClass.Count.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the MinCount property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMinCount()
    {
        this._testClass.CheckProperty(x => x.MinCount);
    }

    /// <summary>
    /// Checks that setting the IsReadOnly property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsReadOnly()
    {
        this._testClass.CheckProperty(x => x.IsReadOnly);
    }

    /// <summary>
    /// Checks that setting the IsSynchronized property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsSynchronized()
    {
        this._testClass.CheckProperty(x => x.IsSynchronized);
    }

    /// <summary>
    /// Checks that the IsRepeatable property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIsRepeatable()
    {
        // Assert
        this._testClass.IsRepeatable.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the SyncRoot property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSyncRoot()
    {
        this._testClass.CheckProperty(x => x.SyncRoot, _fixture.Create<object>(), _fixture.Create<object>());
    }

    /// <summary>
    /// Checks that the ValueEquals property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetValueEquals()
    {
        // Assert
        this._testClass.ValueEquals.Should().BeAssignableTo<Func<V, V, bool>>();

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
    /// Checks that setting the Created property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCreated()
    {
        this._testClass.CheckProperty(x => x.Created);
    }

    /// <summary>
    /// Checks that setting the Creator property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCreator()
    {
        this._testClass.CheckProperty(x => x.Creator);
    }

    /// <summary>
    /// Checks that setting the Modified property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetModified()
    {
        this._testClass.CheckProperty(x => x.Modified);
    }

    /// <summary>
    /// Checks that setting the Modifier property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetModifier()
    {
        this._testClass.CheckProperty(x => x.Modifier);
    }

    /// <summary>
    /// Checks that setting the OriginId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOriginId()
    {
        this._testClass.CheckProperty(x => x.OriginId);
    }

    /// <summary>
    /// Checks that the ElementType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetElementType()
    {
        // Assert
        this._testClass.ElementType.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ContainsListCollection property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetContainsListCollection()
    {
        // Assert
        this._testClass.ContainsListCollection.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForInt()
    {
        var testValue = _fixture.Create<V>();
        this._testClass[_fixture.Create<int>()].As<object>().Should().BeAssignableTo<V>();
        this._testClass[_fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>()].Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForLong()
    {
        var testValue = _fixture.Create<V>();
        this._testClass[_fixture.Create<long>()].As<object>().Should().BeAssignableTo<V>();
        this._testClass[_fixture.Create<long>()] = testValue;
        this._testClass[_fixture.Create<long>()].Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForObject()
    {
        var testValue = _fixture.Create<V>();
        this._testClass[_fixture.Create<object>()].As<object>().Should().BeAssignableTo<V>();
        this._testClass[_fixture.Create<object>()] = testValue;
        this._testClass[_fixture.Create<object>()].Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForIIdentifiable()
    {
        var testValue = _fixture.Create<V>();
        this._testClass[_fixture.Create<IIdentifiable>()].As<object>().Should().BeAssignableTo<V>();
        this._testClass[_fixture.Create<IIdentifiable>()] = testValue;
        this._testClass[_fixture.Create<IIdentifiable>()].Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForIUnique()
    {
        var testValue = _fixture.Create<V>();
        this._testClass[_fixture.Create<IUnique<V>>()].As<object>().Should().BeAssignableTo<V>();
        this._testClass[_fixture.Create<IUnique<V>>()] = testValue;
        this._testClass[_fixture.Create<IUnique<V>>()].Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForObjectAndLong()
    {
        var testValue = _fixture.Create<V>();
        this._testClass[_fixture.Create<object>(), _fixture.Create<long>()].As<object>().Should().BeAssignableTo<V>();
        this._testClass[_fixture.Create<object>(), _fixture.Create<long>()] = testValue;
        this._testClass[_fixture.Create<object>(), _fixture.Create<long>()].Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForIIdentifiableAndLong()
    {
        var testValue = _fixture.Create<V>();
        this._testClass[_fixture.Create<IIdentifiable>(), _fixture.Create<long>()].As<object>().Should().BeAssignableTo<V>();
        this._testClass[_fixture.Create<IIdentifiable>(), _fixture.Create<long>()] = testValue;
        this._testClass[_fixture.Create<IIdentifiable>(), _fixture.Create<long>()].Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForIUniqueAndLong()
    {
        var testValue = _fixture.Create<V>();
        this._testClass[_fixture.Create<IUnique<V>>(), _fixture.Create<long>()].As<object>().Should().BeAssignableTo<V>();
        this._testClass[_fixture.Create<IUnique<V>>(), _fixture.Create<long>()] = testValue;
        this._testClass[_fixture.Create<IUnique<V>>(), _fixture.Create<long>()].Should().Be(testValue);
    }
}