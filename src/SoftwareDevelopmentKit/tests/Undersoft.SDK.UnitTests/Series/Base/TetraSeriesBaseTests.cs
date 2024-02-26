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
using V = System.String;

namespace Undersoft.SDK.UnitTests.Series.Base;

/// <summary>
/// Unit tests for the type <see cref="TetraSeriesBase"/>.
/// </summary>
public class TetraSeriesBase_1Tests
{
    private class TestTetraSeriesBase : TetraSeriesBase<V>
    {
        public TestTetraSeriesBase(int capacity = 16, HashBits bits = HashBits.bit64) : base(capacity, bits)
        {
        }

        public TestTetraSeriesBase(
                                                                                                  IList<ISeriesItem<V>> collection,
                                                                                                  int capacity = 16,
                                                                                                  HashBits bits = HashBits.bit64
                                                                                              ) : base(collection, capacity, bits)
        {
        }

        public TestTetraSeriesBase(
                                                                                                  IEnumerable<ISeriesItem<V>> collection,
                                                                                                  int capacity = 16,
                                                                                                  HashBits bits = HashBits.bit64
                                                                                              ) : base(collection, capacity, bits)
        {
        }

        public void PubliccountIncrement(uint tid)
        {
            base.countIncrement(tid);
        }

        public void PublicconflictIncrement(uint tid)
        {
            base.conflictIncrement(tid);
        }

        public void PublicremovedIncrement(uint tid)
        {
            base.removedIncrement(tid);
        }

        public void PublicremovedDecrement()
        {
            base.removedDecrement();
        }

        public Func<V, V, bool> PublicgetValueComparer()
        {
            return base.getValueComparer();
        }

        public bool PublicInnerContainsKey(long key)
        {
            return base.InnerContainsKey(key);
        }

        public V PublicInnerRemove(long key, V item)
        {
            return base.InnerRemove(key, item);
        }

        public static uint PublicgetTetraId(long key)
        {
            return getTetraId(key);
        }

        public long PublicgetPosition(long key)
        {
            return base.getPosition(key);
        }

        public static long PublicgetPosition(long key, int newsize)
        {
            return getPosition(key, newsize);
        }

        public void PublicRehash(int newsize, uint tid)
        {
            base.Rehash(newsize, tid);
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

        public override ISeriesItem<V>[] EmptyItemTable(int size)
        {
            return default(ISeriesItem<V>[]);
        }
    }

    private TestTetraSeriesBase _testClass;
    private IFixture _fixture;
    private int _capacity;
    private HashBits _bits;
    private IList<ISeriesItem<V>> _collectionIListISeriesItemV;
    private IEnumerable<ISeriesItem<V>> _collectionIEnumerableISeriesItemV;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TetraSeriesBase"/>.
    /// </summary>
    public TetraSeriesBase_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._capacity = _fixture.Create<int>();
        this._bits = _fixture.Create<HashBits>();
        this._collectionIListISeriesItemV = _fixture.Create<IList<ISeriesItem<V>>>();
        this._collectionIEnumerableISeriesItemV = _fixture.Create<IEnumerable<ISeriesItem<V>>>();
        this._testClass = _fixture.Create<TestTetraSeriesBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestTetraSeriesBase(this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTetraSeriesBase(this._collectionIListISeriesItemV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTetraSeriesBase(this._collectionIEnumerableISeriesItemV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCollection()
    {
        FluentActions.Invoking(() => new TestTetraSeriesBase(default(IList<ISeriesItem<V>>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTetraSeriesBase(default(IEnumerable<ISeriesItem<V>>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the PubliccountIncrement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallcountIncrement()
    {
        // Arrange
        var tid = _fixture.Create<uint>();

        // Act
        this._testClass.PubliccountIncrement(tid);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicconflictIncrement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallconflictIncrement()
    {
        // Arrange
        var tid = _fixture.Create<uint>();

        // Act
        this._testClass.PublicconflictIncrement(tid);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicremovedIncrement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallremovedIncrement()
    {
        // Arrange
        var tid = _fixture.Create<uint>();

        // Act
        this._testClass.PublicremovedIncrement(tid);

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
    /// Checks that the InnerGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerGet()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.InnerGet(key);

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
    /// Checks that the InnerTryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerTryGet()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.InnerTryGet(key, out var output);

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
    /// Checks that the InnerGetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerGetItem()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.InnerGetItem(key);

        // Assert
        Assert.Fail("Create or modify test");
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
    public void CanCallPutWithObjectAndObject()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<object>();

        // Act
        var result = this._testClass.Put(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithObjectAndObjectWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(object), _fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Put method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithObjectAndObjectWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Put(_fixture.Create<object>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Put maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void PutWithObjectAndObjectPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
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
    public void CanCallPutWith_item()
    {
        // Arrange
        var _item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.Put(_item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the _item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWith_itemWithNull_item()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("_item");
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
    public void CanCallPutWithObject()
    {
        // Arrange
        var value = _fixture.Create<object>();

        // Act
        this._testClass.Put(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithObjectWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
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
    /// Checks that the TryAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAdd()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.TryAdd(value);

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
    /// Checks that the TryPick method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryPick()
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
    /// Checks that the InnerRemove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerRemoveWithLong()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.InnerRemove(key);

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
    /// Checks that the TryRemove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryRemove()
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
    public void CannotCallTryRemoveWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.TryRemove(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
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
    /// Checks that the Resize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallResizeWithInt()
    {
        // Arrange
        var size = _fixture.Create<int>();

        // Act
        this._testClass.Resize(size);

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
    public void CanCallResizeWithSizeAndTid()
    {
        // Arrange
        var size = _fixture.Create<int>();
        var tid = _fixture.Create<uint>();

        // Act
        this._testClass.Resize(size, tid);

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
    /// Checks that the PublicgetTetraId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallgetTetraId()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = TestTetraSeriesBase.PublicgetTetraId(key);

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
    public void CanCallgetPositionWithKeyAndNewsize()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var newsize = _fixture.Create<int>();

        // Act
        var result = TestTetraSeriesBase.PublicgetPosition(key, newsize);

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
        var newsize = _fixture.Create<int>();
        var tid = _fixture.Create<uint>();

        // Act
        this._testClass.PublicRehash(newsize, tid);

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
    /// Checks that the ItemType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetItemType()
    {
        // Assert
        this._testClass.ItemType.Should().BeAssignableTo<Type>();

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
}