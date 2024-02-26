using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Series;
using T = System.String;
using V = Undersoft.SDK.Origin;

namespace Undersoft.SDK.UnitTests.Series;

/// <summary>
/// Unit tests for the type <see cref="TypedCache"/>.
/// </summary>
public class TypedCache_1Tests
{
    private class TestTypedCache : TypedCache<V>
    {
        public TestTypedCache(
        IEnumerable<V> collection,
        TimeSpan? lifeTime = null,
        IInvoker callback = null,
        int capacity = 17
    ) : base(collection, lifeTime, callback, capacity)
        {
        }

        public TestTypedCache(
        IList<V> collection,
        TimeSpan? lifeTime = null,
        IInvoker callback = null,
        int capacity = 17
    ) : base(collection, lifeTime, callback, capacity)
        {
        }

        public TestTypedCache(TimeSpan? lifeTime = null, IInvoker callback = null, int capacity = 17) : base(lifeTime, callback, capacity)
        {
        }

        public T PublicInnerMemorize<T>(T item)
        {
            return base.InnerMemorize<T>(item);
        }

        public T PublicInnerMemorize<T>(T item, string[] names)
        {
            return base.InnerMemorize<T>(item, names);
        }

        public ITypedSeries<IIdentifiable> Publiccache { get => base.cache; set => base.cache = value; }
    }

    private TestTypedCache _testClass;
    private IFixture _fixture;
    private IEnumerable<V> _collectionIEnumerableV;
    private TimeSpan? _lifeTime;
    private Mock<IInvoker> _callback;
    private int _capacity;
    private IList<V> _collectionIListV;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TypedCache"/>.
    /// </summary>
    public TypedCache_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._collectionIEnumerableV = _fixture.Create<IEnumerable<V>>();
        this._lifeTime = _fixture.Create<TimeSpan?>();
        this._callback = _fixture.Freeze<Mock<IInvoker>>();
        this._capacity = _fixture.Create<int>();
        this._collectionIListV = _fixture.Create<IList<V>>();
        this._testClass = _fixture.Create<TestTypedCache>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestTypedCache(this._collectionIEnumerableV, this._lifeTime, this._callback.Object, this._capacity);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedCache(this._collectionIListV, this._lifeTime, this._callback.Object, this._capacity);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTypedCache(this._lifeTime, this._callback.Object, this._capacity);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCollection()
    {
        FluentActions.Invoking(() => new TestTypedCache(default(IEnumerable<V>), this._lifeTime, this._callback.Object, this._capacity)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
        FluentActions.Invoking(() => new TestTypedCache(default(IList<V>), this._lifeTime, this._callback.Object, this._capacity)).Should().Throw<ArgumentNullException>().WithParameterName("collection");
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
        result.Value.Should().Be(value);
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
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithValue()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithValuePerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the PublicInnerMemorize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerMemorizeWithTAndT()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = this._testClass.PublicInnerMemorize<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerMemorize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerMemorizeWithTAndTAndArrayOfString()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var names = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.PublicInnerMemorize<T>(item, names);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerMemorize method throws when the names parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerMemorizeWithTAndTAndArrayOfStringWithNullNames()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerMemorize<T>(_fixture.Create<T>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("names");
    }

    /// <summary>
    /// Checks that the CacheSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCacheSet()
    {
        // Act
        var result = this._testClass.CacheSet<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLookupWithKeys()
    {
        // Arrange
        var keys = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Lookup<T>(keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithKeysWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.Lookup<T>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the Lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLookupWithValueNamePair()
    {
        // Arrange
        var valueNamePair = _fixture.Create<Tuple<string, object>>();

        // Act
        var result = this._testClass.Lookup<T>(valueNamePair);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the valueNamePair parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithValueNamePairWithNullValueNamePair()
    {
        FluentActions.Invoking(() => this._testClass.Lookup<T>(default(Tuple<string, object>))).Should().Throw<ArgumentNullException>().WithParameterName("valueNamePair");
    }

    /// <summary>
    /// Checks that the Lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLookupWithSelector()
    {
        // Arrange
        Func<ITypedSeries<IIdentifiable>, ISeries<IIdentifiable>> selector = x => _fixture.Create<ISeries<IIdentifiable>>();

        // Act
        var result = this._testClass.Lookup<T>(selector);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithSelectorWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.Lookup<T>(default(Func<ITypedSeries<IIdentifiable>, ISeries<IIdentifiable>>))).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLookupWithTAndT()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = this._testClass.Lookup<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLookupWithKeyAndValueNamePairs()
    {
        // Arrange
        var key = _fixture.Create<object[]>();
        var valueNamePairs = _fixture.Create<Tuple<string, object>[]>();

        // Act
        var result = this._testClass.Lookup<T>(key, valueNamePairs);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithKeyAndValueNamePairsWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Lookup<T>(default(object[]), _fixture.Create<Tuple<string, object>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the valueNamePairs parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithKeyAndValueNamePairsWithNullValueNamePairs()
    {
        FluentActions.Invoking(() => this._testClass.Lookup<T>(_fixture.Create<object[]>(), default(Tuple<string, object>[]))).Should().Throw<ArgumentNullException>().WithParameterName("valueNamePairs");
    }

    /// <summary>
    /// Checks that the Lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLookupWithKeyAndSelectors()
    {
        // Arrange
        Func<ISeries<IIdentifiable>, IIdentifiable> key = x => _fixture.Create<IIdentifiable>();
        var selectors = _fixture.Create<Func<ITypedSeries<IIdentifiable>, ISeries<IIdentifiable>>[]>();

        // Act
        var result = this._testClass.Lookup<T>(key, selectors);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithKeyAndSelectorsWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Lookup<T>(default(Func<ISeries<IIdentifiable>, IIdentifiable>), _fixture.Create<Func<ITypedSeries<IIdentifiable>, ISeries<IIdentifiable>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the selectors parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithKeyAndSelectorsWithNullSelectors()
    {
        FluentActions.Invoking(() => this._testClass.Lookup<T>(x => _fixture.Create<IIdentifiable>(), default(Func<ITypedSeries<IIdentifiable>, ISeries<IIdentifiable>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("selectors");
    }

    /// <summary>
    /// Checks that the Lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLookupWithKeyAndPropertyNames()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var propertyNames = _fixture.Create<string>();

        // Act
        var result = this._testClass.Lookup<T>(key, propertyNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithKeyAndPropertyNamesWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Lookup<T>(default(object), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the propertyNames parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallLookupWithKeyAndPropertyNamesWithInvalidPropertyNames(string value)
    {
        FluentActions.Invoking(() => this._testClass.Lookup<T>(_fixture.Create<object>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("propertyNames");
    }

    /// <summary>
    /// Checks that the Lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLookupWithItemAndPropertyNames()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var propertyNames = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.Lookup<T>(item, propertyNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the propertyNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithItemAndPropertyNamesWithNullPropertyNames()
    {
        FluentActions.Invoking(() => this._testClass.Lookup<T>(_fixture.Create<T>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("propertyNames");
    }

    /// <summary>
    /// Checks that the Memorize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMemorizeWithItems()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<T>>();

        // Act
        var result = this._testClass.Memorize<T>(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Memorize method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMemorizeWithItemsWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Memorize<T>(default(IEnumerable<T>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Memorize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMemorizeWithTAndT()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = this._testClass.Memorize<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Memorize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMemorizeWithTAndTAndArrayOfString()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var names = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.Memorize<T>(item, names);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Memorize method throws when the names parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMemorizeWithTAndTAndArrayOfStringWithNullNames()
    {
        FluentActions.Invoking(() => this._testClass.Memorize<T>(_fixture.Create<T>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("names");
    }

    /// <summary>
    /// Checks that the MemorizeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallMemorizeAsyncWithTAndTAsync()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = await this._testClass.MemorizeAsync<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MemorizeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallMemorizeAsyncWithTAndTAndArrayOfStringAsync()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var names = _fixture.Create<string[]>();

        // Act
        var result = await this._testClass.MemorizeAsync<T>(item, names);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MemorizeAsync method throws when the names parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallMemorizeAsyncWithTAndTAndArrayOfStringWithNullNamesAsync()
    {
        await FluentActions.Invoking(() => this._testClass.MemorizeAsync<T>(_fixture.Create<T>(), default(string[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("names");
    }

    /// <summary>
    /// Checks that the GetDataType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataTypeWithObject()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = this._testClass.GetDataType(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataType method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataTypeWithObjectWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.GetDataType(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetDataType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataTypeWithType()
    {
        // Arrange
        var obj = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetDataType(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataType method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataTypeWithTypeWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.GetDataType(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetDataTypeId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataTypeIdWithObject()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = this._testClass.GetDataTypeId(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataTypeId method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataTypeIdWithObjectWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.GetDataTypeId(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetDataTypeId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataTypeIdWithType()
    {
        // Arrange
        var obj = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetDataTypeId(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataTypeId method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataTypeIdWithTypeWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.GetDataTypeId(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that setting the Publiccache property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPubliccache()
    {
        this._testClass.CheckProperty(x => x.Publiccache, _fixture.Create<ITypedSeries<IIdentifiable>>(), _fixture.Create<ITypedSeries<IIdentifiable>>());
    }

    /// <summary>
    /// Checks that the Catalog property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetCatalog()
    {
        // Assert
        this._testClass.Catalog.Should().BeAssignableTo<ITypedSeries<IIdentifiable>>();

        Assert.Fail("Create or modify test");
    }
}