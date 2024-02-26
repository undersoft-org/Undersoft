using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
/// Unit tests for the type <see cref="SeriesBase"/>.
/// </summary>
public class SeriesBase_1Tests
{
    private class TestSeriesBase : SeriesBase<V>
    {
        public TestSeriesBase(int capacity = 17, HashBits bits = HashBits.bit64) : base(capacity, bits)
        {
        }

        public TestSeriesBase(IList<ISeriesItem<V>> collection, int capacity = 17, HashBits bits = HashBits.bit64) : base(collection, capacity, bits)
        {
        }

        public TestSeriesBase(IList<V> collection, int capacity = 17, HashBits bits = HashBits.bit64) : base(collection, capacity, bits)
        {
        }

        public TestSeriesBase(IEnumerable<ISeriesItem<V>> collection, int capacity = 17, HashBits bits = HashBits.bit64) : base(collection, capacity, bits)
        {
        }

        public TestSeriesBase(IEnumerable<V> collection, int capacity = 17, HashBits bits = HashBits.bit64) : base(collection, capacity, bits)
        {
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

        public ISeriesItem<V> PublicInnerSet(V value)
        {
            return base.InnerSet(value);
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

    private TestSeriesBase _testClass;
    private IFixture _fixture;
    private int _capacity;
    private HashBits _bits;
    private IList<ISeriesItem<V>> _collectionIListISeriesItemV;
    private IList<V> _collectionIListV;
    private IEnumerable<ISeriesItem<V>> _collectionIEnumerableISeriesItemV;
    private IEnumerable<V> _collectionIEnumerableV;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SeriesBase"/>.
    /// </summary>
    public SeriesBase_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._capacity = _fixture.Create<int>();
        this._bits = _fixture.Create<HashBits>();
        this._collectionIListISeriesItemV = _fixture.Create<IList<ISeriesItem<V>>>();
        this._collectionIListV = _fixture.Create<IList<V>>();
        this._collectionIEnumerableISeriesItemV = _fixture.Create<IEnumerable<ISeriesItem<V>>>();
        this._collectionIEnumerableV = _fixture.Create<IEnumerable<V>>();
        this._testClass = _fixture.Create<TestSeriesBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestSeriesBase(this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestSeriesBase(this._collectionIListISeriesItemV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestSeriesBase(this._collectionIListV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestSeriesBase(this._collectionIEnumerableISeriesItemV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestSeriesBase(this._collectionIEnumerableV, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCollection()
    {
        FluentActions.Invoking(() => new TestSeriesBase(default(IList<ISeriesItem<V>>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestSeriesBase(default(IList<V>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestSeriesBase(default(IEnumerable<ISeriesItem<V>>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestSeriesBase(default(IEnumerable<V>), this._capacity, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
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
    public void CanCallTryGetWithIIdentifiableAndV()
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
    public void CannotCallTryGetWithIIdentifiableAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.TryGet(default(IIdentifiable), out _)).Should().Throw<ArgumentNullException>().WithParameterName("key");
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
    /// Checks that the PublicInnerSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerSetWithV()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicInnerSet(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerSet maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void InnerSetWithVPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<V>();

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
    public void CanCallTryAddWithObjectAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.TryAdd(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAdd method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryAddWithObjectAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.TryAdd(default(object), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
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
    public void CanCallInsertWithIndexAndSeriesItem()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var seriesItem = _fixture.Create<ISeriesItem<V>>();

        // Act
        this._testClass.Insert(index, seriesItem);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Insert method throws when the seriesItem parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInsertWithIndexAndSeriesItemWithNullSeriesItem()
    {
        FluentActions.Invoking(() => this._testClass.Insert(_fixture.Create<int>(), default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("seriesItem");
    }

    /// <summary>
    /// Checks that the Insert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsertWithIndexAndValue()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var value = _fixture.Create<V>();

        // Act
        this._testClass.Insert(index, value);

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
    /// Checks that the SetMinCount method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetMinCount()
    {
        // Arrange
        var minCount = _fixture.Create<int>();

        // Act
        this._testClass.SetMinCount(minCount);

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
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.IndexOf(value);

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
    /// Checks that the GetAsyncEnumerator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetAsyncEnumerator()
    {
        // Arrange
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = this._testClass.GetAsyncEnumerator(cancellationToken);

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
        var result = TestSeriesBase.PublicgetPosition(key, tableMaxId);

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
    /// Checks that the DisposeAsyncCore method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDisposeAsyncCoreAsync()
    {
        // Act
        await this._testClass.DisposeAsyncCore();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DisposeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDisposeAsync()
    {
        // Act
        await this._testClass.DisposeAsync();

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
    /// Checks that the ExceptWith method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExceptWith()
    {
        // Arrange
        var other = _fixture.Create<IEnumerable<V>>();

        // Act
        this._testClass.ExceptWith(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExceptWith method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExceptWithWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.ExceptWith(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the IntersectWith method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIntersectWith()
    {
        // Arrange
        var other = _fixture.Create<IEnumerable<V>>();

        // Act
        this._testClass.IntersectWith(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IntersectWith method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIntersectWithWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.IntersectWith(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the IsProperSubsetOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsProperSubsetOf()
    {
        // Arrange
        var other = _fixture.Create<IEnumerable<V>>();

        // Act
        var result = this._testClass.IsProperSubsetOf(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsProperSubsetOf method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsProperSubsetOfWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.IsProperSubsetOf(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the IsProperSupersetOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsProperSupersetOf()
    {
        // Arrange
        var other = _fixture.Create<IEnumerable<V>>();

        // Act
        var result = this._testClass.IsProperSupersetOf(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsProperSupersetOf method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsProperSupersetOfWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.IsProperSupersetOf(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the IsSubsetOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsSubsetOf()
    {
        // Arrange
        var other = _fixture.Create<IEnumerable<V>>();

        // Act
        var result = this._testClass.IsSubsetOf(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsSubsetOf method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsSubsetOfWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.IsSubsetOf(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the IsSupersetOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsSupersetOf()
    {
        // Arrange
        var other = _fixture.Create<IEnumerable<V>>();

        // Act
        var result = this._testClass.IsSupersetOf(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsSupersetOf method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsSupersetOfWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.IsSupersetOf(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the Overlaps method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOverlaps()
    {
        // Arrange
        var other = _fixture.Create<IEnumerable<V>>();

        // Act
        var result = this._testClass.Overlaps(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Overlaps method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOverlapsWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.Overlaps(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the SetEquals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetEquals()
    {
        // Arrange
        var other = _fixture.Create<IEnumerable<V>>();

        // Act
        var result = this._testClass.SetEquals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetEquals method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetEqualsWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.SetEquals(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the SymmetricExceptWith method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSymmetricExceptWith()
    {
        // Arrange
        var other = _fixture.Create<IEnumerable<V>>();

        // Act
        this._testClass.SymmetricExceptWith(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SymmetricExceptWith method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSymmetricExceptWithWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.SymmetricExceptWith(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the UnionWith method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUnionWith()
    {
        // Arrange
        var other = _fixture.Create<IEnumerable<V>>();

        // Act
        this._testClass.UnionWith(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UnionWith method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUnionWithWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.UnionWith(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddForISet_V_WithV()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = ((ISet<V>)this._testClass).Add(value);

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
    /// Checks that the Equal property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetEqual()
    {
        // Assert
        this._testClass.Equal.Should().BeAssignableTo<Func<V, V, bool>>();

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
}