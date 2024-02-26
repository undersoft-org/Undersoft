using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Series;
using Undersoft.SDK.Series.Base;
using Undersoft.SDK.Uniques;
using Undersoft.SDK.Updating;
using V = Undersoft.SDK.Series.Base.TracedListingBase;

namespace Undersoft.SDK.UnitTests.Series.Base;

/// <summary>
/// Unit tests for the type <see cref="TracedListingBase"/>.
/// </summary>
public class TracedListingBase_1Tests
{
    private class TestTracedListingBase : TracedListingBase<V>
    {
        public TestTracedListingBase() : base()
        {
        }

        public TestTracedListingBase(int capacity = 17, HashBits bits = HashBits.bit64) : base(capacity, bits)
        {
        }

        public TestTracedListingBase(bool repeatable, int capacity = 17, HashBits bits = HashBits.bit64) : base(repeatable, capacity, bits)
        {
        }

        public TestTracedListingBase(
                                                                                                                     IEnumerable<V> collection,
                                                                                                                     int capacity = 17,
                                                                                                                     bool repeatable = false,
                                                                                                                     HashBits bits = HashBits.bit64
                                                                                                                 ) : base(collection, capacity, repeatable, bits)
        {
        }

        public void PublicAddNotifier(V itemAdded)
        {
            base.AddNotifier(itemAdded);
        }

        public void PublicAddNotifier(IEnumerable<V> itemsAdded)
        {
            base.AddNotifier(itemsAdded);
        }

        public void PublicChangeNotiifer(V newItem, V oldItem)
        {
            base.ChangeNotiifer(newItem, oldItem);
        }

        public ISeriesItem<V> PublicGetItem(long key, V item)
        {
            return base.GetItem(key, item);
        }

        public int PublicIndexOf(long key, V item)
        {
            return base.IndexOf(key, item);
        }

        public V PublicInnerGet(long key)
        {
            return base.InnerGet(key);
        }

        public ISeriesItem<V> PublicInnerGetItem(long key)
        {
            return base.InnerGetItem(key);
        }

        public ISeriesItem<V> PublicInnerPut(ISeriesItem<V> value)
        {
            return base.InnerPut(value);
        }

        public ISeriesItem<V> PublicInnerPut(V value)
        {
            return base.InnerPut(value);
        }

        public ISeriesItem<V> PublicInnerPut(long key, V value)
        {
            return base.InnerPut(key, value);
        }

        public V PublicInnerRemove(long key)
        {
            return base.InnerRemove(key);
        }

        public ISeriesItem<V> PublicInnerSet(ISeriesItem<V> value)
        {
            return base.InnerSet(value);
        }

        public ISeriesItem<V> PublicInnerSet(V value)
        {
            return base.InnerSet(value);
        }

        public ISeriesItem<V> PublicInnerSet(long key, V value)
        {
            return base.InnerSet(key, value);
        }

        public bool PublicInnerTryGet(long key, out ISeriesItem<V> output)
        {
            return base.InnerTryGet(key, out output);
        }

        public void PublicOnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
        }

        public void PublicOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(sender, e);
        }

        public void PublicOnPropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            base.OnPropertyChanging(sender, e);
        }

        public void PublicRehash(int newsize)
        {
            base.Rehash(newsize);
        }

        public void PublicReindex()
        {
            base.Reindex();
        }

        public void PublicRemoveNotifier(V itemRemoved)
        {
            base.RemoveNotifier(itemRemoved);
        }

        public void PublicReplaceNotifier(V itemsMoved)
        {
            base.ReplaceNotifier(itemsMoved);
        }

        public void PublicResetNotifier(IEnumerable<V> itemsReset)
        {
            base.ResetNotifier(itemsReset);
        }

        public bool PublicInnerAdd(ISeriesItem<V> value)
        {
            return base.InnerAdd(value);
        }

        public bool PublicInnerAdd(V value)
        {
            return base.InnerAdd(value);
        }

        public bool PublicInnerAdd(long key, V value)
        {
            return base.InnerAdd(key, value);
        }
    }

    private TestTracedListingBase _testClass;
    private IFixture _fixture;
    private int _capacity;
    private HashBits _bits;
    private bool _repeatable;
    private IEnumerable<V> _collection;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TracedListingBase"/>.
    /// </summary>
    public TracedListingBase_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._capacity = _fixture.Create<int>();
        this._bits = _fixture.Create<HashBits>();
        this._repeatable = _fixture.Create<bool>();
        this._collection = _fixture.Create<IEnumerable<V>>();
        this._testClass = _fixture.Create<TestTracedListingBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestTracedListingBase();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTracedListingBase(this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTracedListingBase(this._repeatable, this._capacity, this._bits);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTracedListingBase(this._collection, this._capacity, this._repeatable, this._bits);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCollection()
    {
        FluentActions.Invoking(() => new TestTracedListingBase(default(IEnumerable<V>), this._capacity, this._repeatable, this._bits)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the PublicAddNotifier method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddNotifierWithItemAdded()
    {
        // Arrange
        var itemAdded = _fixture.Create<V>();

        // Act
        this._testClass.PublicAddNotifier(itemAdded);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicAddNotifier method throws when the itemAdded parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddNotifierWithItemAddedWithNullItemAdded()
    {
        FluentActions.Invoking(() => this._testClass.PublicAddNotifier(default(V))).Should().Throw<ArgumentNullException>().WithParameterName("itemAdded");
    }

    /// <summary>
    /// Checks that the PublicAddNotifier method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddNotifierWithItemsAdded()
    {
        // Arrange
        var itemsAdded = _fixture.Create<IEnumerable<V>>();

        // Act
        this._testClass.PublicAddNotifier(itemsAdded);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicAddNotifier method throws when the itemsAdded parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddNotifierWithItemsAddedWithNullItemsAdded()
    {
        FluentActions.Invoking(() => this._testClass.PublicAddNotifier(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("itemsAdded");
    }

    /// <summary>
    /// Checks that the PublicChangeNotiifer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallChangeNotiifer()
    {
        // Arrange
        var newItem = _fixture.Create<V>();
        var oldItem = _fixture.Create<V>();

        // Act
        this._testClass.PublicChangeNotiifer(newItem, oldItem);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicChangeNotiifer method throws when the newItem parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallChangeNotiiferWithNullNewItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicChangeNotiifer(default(V), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("newItem");
    }

    /// <summary>
    /// Checks that the PublicChangeNotiifer method throws when the oldItem parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallChangeNotiiferWithNullOldItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicChangeNotiifer(_fixture.Create<V>(), default(V))).Should().Throw<ArgumentNullException>().WithParameterName("oldItem");
    }

    /// <summary>
    /// Checks that the PublicGetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetItemWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicGetItem(key, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicGetItem method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetItemWithLongAndVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicGetItem(_fixture.Create<long>(), default(V))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicIndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIndexOfWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var item = _fixture.Create<V>();

        // Act
        var result = this._testClass.PublicIndexOf(key, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicIndexOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIndexOfWithLongAndVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicIndexOf(_fixture.Create<long>(), default(V))).Should().Throw<ArgumentNullException>().WithParameterName("item");
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
        result.Value.Should().BeSameAs(value);
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
    /// Checks that the PublicInnerPut method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerPutWithVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerPut(default(V))).Should().Throw<ArgumentNullException>().WithParameterName("value");
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
        result.Value.Should().BeSameAs(value);
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
    /// Checks that the PublicInnerPut method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerPutWithLongAndVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerPut(_fixture.Create<long>(), default(V))).Should().Throw<ArgumentNullException>().WithParameterName("value");
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
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the PublicInnerRemove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerRemove()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicInnerRemove(key);

        // Assert
        Assert.Fail("Create or modify test");
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
        result.Value.Should().BeSameAs(value);
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
    /// Checks that the PublicInnerSet method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerSetWithVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerSet(default(V))).Should().Throw<ArgumentNullException>().WithParameterName("value");
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
        result.Value.Should().BeSameAs(value);
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
    /// Checks that the PublicInnerSet method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerSetWithLongAndVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerSet(_fixture.Create<long>(), default(V))).Should().Throw<ArgumentNullException>().WithParameterName("value");
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
        result.Value.Should().BeSameAs(value);
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
    /// Checks that the PublicOnCollectionChanged method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOnCollectionChanged()
    {
        // Arrange
        var e = _fixture.Create<NotifyCollectionChangedEventArgs>();

        // Act
        this._testClass.PublicOnCollectionChanged(e);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicOnCollectionChanged method throws when the e parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnCollectionChangedWithNullE()
    {
        FluentActions.Invoking(() => this._testClass.PublicOnCollectionChanged(default(NotifyCollectionChangedEventArgs))).Should().Throw<ArgumentNullException>().WithParameterName("e");
    }

    /// <summary>
    /// Checks that the PublicOnPropertyChanged method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOnPropertyChanged()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var e = _fixture.Create<PropertyChangedEventArgs>();

        // Act
        this._testClass.PublicOnPropertyChanged(sender, e);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicOnPropertyChanged method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnPropertyChangedWithNullSender()
    {
        FluentActions.Invoking(() => this._testClass.PublicOnPropertyChanged(default(object), _fixture.Create<PropertyChangedEventArgs>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the PublicOnPropertyChanged method throws when the e parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnPropertyChangedWithNullE()
    {
        FluentActions.Invoking(() => this._testClass.PublicOnPropertyChanged(_fixture.Create<object>(), default(PropertyChangedEventArgs))).Should().Throw<ArgumentNullException>().WithParameterName("e");
    }

    /// <summary>
    /// Checks that the PublicOnPropertyChanging method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOnPropertyChanging()
    {
        // Arrange
        var sender = _fixture.Create<object>();
        var e = _fixture.Create<PropertyChangingEventArgs>();

        // Act
        this._testClass.PublicOnPropertyChanging(sender, e);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicOnPropertyChanging method throws when the sender parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnPropertyChangingWithNullSender()
    {
        FluentActions.Invoking(() => this._testClass.PublicOnPropertyChanging(default(object), _fixture.Create<PropertyChangingEventArgs>())).Should().Throw<ArgumentNullException>().WithParameterName("sender");
    }

    /// <summary>
    /// Checks that the PublicOnPropertyChanging method throws when the e parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnPropertyChangingWithNullE()
    {
        FluentActions.Invoking(() => this._testClass.PublicOnPropertyChanging(_fixture.Create<object>(), default(PropertyChangingEventArgs))).Should().Throw<ArgumentNullException>().WithParameterName("e");
    }

    /// <summary>
    /// Checks that the PublicRehash method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRehash()
    {
        // Arrange
        var newsize = _fixture.Create<int>();

        // Act
        this._testClass.PublicRehash(newsize);

        // Assert
        Assert.Fail("Create or modify test");
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

    /// <summary>
    /// Checks that the PublicRemoveNotifier method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveNotifier()
    {
        // Arrange
        var itemRemoved = _fixture.Create<V>();

        // Act
        this._testClass.PublicRemoveNotifier(itemRemoved);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRemoveNotifier method throws when the itemRemoved parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveNotifierWithNullItemRemoved()
    {
        FluentActions.Invoking(() => this._testClass.PublicRemoveNotifier(default(V))).Should().Throw<ArgumentNullException>().WithParameterName("itemRemoved");
    }

    /// <summary>
    /// Checks that the PublicReplaceNotifier method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReplaceNotifier()
    {
        // Arrange
        var itemsMoved = _fixture.Create<V>();

        // Act
        this._testClass.PublicReplaceNotifier(itemsMoved);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicReplaceNotifier method throws when the itemsMoved parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReplaceNotifierWithNullItemsMoved()
    {
        FluentActions.Invoking(() => this._testClass.PublicReplaceNotifier(default(V))).Should().Throw<ArgumentNullException>().WithParameterName("itemsMoved");
    }

    /// <summary>
    /// Checks that the PublicResetNotifier method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallResetNotifier()
    {
        // Arrange
        var itemsReset = _fixture.Create<IEnumerable<V>>();

        // Act
        this._testClass.PublicResetNotifier(itemsReset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicResetNotifier method throws when the itemsReset parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallResetNotifierWithNullItemsReset()
    {
        FluentActions.Invoking(() => this._testClass.PublicResetNotifier(default(IEnumerable<V>))).Should().Throw<ArgumentNullException>().WithParameterName("itemsReset");
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
    /// Checks that the PublicInnerAdd method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerAddWithVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerAdd(default(V))).Should().Throw<ArgumentNullException>().WithParameterName("value");
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
    /// Checks that the PublicInnerAdd method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerAddWithLongAndVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerAdd(_fixture.Create<long>(), default(V))).Should().Throw<ArgumentNullException>().WithParameterName("value");
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
    /// Checks that the EmptyItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyItem()
    {
        // Act
        var result = this._testClass.EmptyItem();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EmptyTable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyTable()
    {
        // Arrange
        var size = _fixture.Create<int>();

        // Act
        var result = this._testClass.EmptyTable(size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EmptyVector method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyVector()
    {
        // Arrange
        var size = _fixture.Create<int>();

        // Act
        var result = this._testClass.EmptyVector(size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetItemWithIndex()
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
    public void GetItemWithIndexPerformsMapping()
    {
        // Arrange
        var index = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetItem(index);

        // Assert
        result.Index.Should().Be(index);
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
    /// Checks that the Initialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInitialize()
    {
        // Act
        this._testClass.Initialize();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Insert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsert()
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
    public void CannotCallInsertWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Insert(_fixture.Create<int>(), default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithISeriesItemOfV()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.NewItem(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithISeriesItemOfVWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithV()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(V))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithVPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithObjectAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(object), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(_fixture.Create<object>(), default(V))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithObjectAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithLongAndVWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(_fixture.Create<long>(), default(V))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithLongAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().BeSameAs(value);
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
    /// Checks that setting the NoticeChange property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNoticeChange()
    {
        this._testClass.CheckProperty(x => x.NoticeChange, _fixture.Create<IInvoker>(), _fixture.Create<IInvoker>());
    }

    /// <summary>
    /// Checks that setting the NoticeChanging property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNoticeChanging()
    {
        this._testClass.CheckProperty(x => x.NoticeChanging, _fixture.Create<IInvoker>(), _fixture.Create<IInvoker>());
    }

    /// <summary>
    /// Checks that setting the Updater property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUpdater()
    {
        this._testClass.CheckProperty(x => x.Updater, _fixture.Create<IUpdater>(), _fixture.Create<IUpdater>());
    }
}