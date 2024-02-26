using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Store;
using TEntity = Undersoft.SDK.Origin;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Entity;

/// <summary>
/// Unit tests for the type <see cref="EntityCache"/>.
/// </summary>
public class EntityCache_2Tests
{
    private class TestEntityCache : EntityCache<TStore, TEntity>
    {
        public TestEntityCache(IStoreCache<TStore> datacache) : base(datacache)
        {
        }

        public ITypedSeries<IIdentifiable> Publiccache { get => base.cache; set => base.cache = value; }
    }

    private TestEntityCache _testClass;
    private IFixture _fixture;
    private Mock<IStoreCache<TStore>> _datacache;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EntityCache"/>.
    /// </summary>
    public EntityCache_2Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._datacache = _fixture.Freeze<Mock<IStoreCache<TStore>>>();
        this._testClass = _fixture.Create<TestEntityCache>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestEntityCache(this._datacache.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the datacache parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullDatacache()
    {
        FluentActions.Invoking(() => new TestEntityCache(default(IStoreCache<TStore>))).Should().Throw<ArgumentNullException>().WithParameterName("datacache");
    }

    /// <summary>
    /// Checks that the CacheSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCacheSet()
    {
        // Act
        var result = this._testClass.CacheSet();

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
        var keys = _fixture.Create<object>();

        // Act
        var result = this._testClass.Lookup(keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithKeysWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.Lookup(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
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
        var result = this._testClass.Lookup(valueNamePair);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the valueNamePair parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithValueNamePairWithNullValueNamePair()
    {
        FluentActions.Invoking(() => this._testClass.Lookup(default(Tuple<string, object>))).Should().Throw<ArgumentNullException>().WithParameterName("valueNamePair");
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
        var result = this._testClass.Lookup(selector);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithSelectorWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.Lookup(default(Func<ITypedSeries<IIdentifiable>, ISeries<IIdentifiable>>))).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLookupWithTEntity()
    {
        // Arrange
        var item = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Lookup(item);

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
        var result = this._testClass.Lookup(key, valueNamePairs);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithKeyAndValueNamePairsWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Lookup(default(object[]), _fixture.Create<Tuple<string, object>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the valueNamePairs parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithKeyAndValueNamePairsWithNullValueNamePairs()
    {
        FluentActions.Invoking(() => this._testClass.Lookup(_fixture.Create<object[]>(), default(Tuple<string, object>[]))).Should().Throw<ArgumentNullException>().WithParameterName("valueNamePairs");
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
        var result = this._testClass.Lookup(key, selectors
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithKeyAndSelectorsWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Lookup(default(Func<ISeries<IIdentifiable>, IIdentifiable>), _fixture.Create<Func<ITypedSeries<IIdentifiable>, ISeries<IIdentifiable>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the selectors parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithKeyAndSelectorsWithNullSelectors()
    {
        FluentActions.Invoking(() => this._testClass.Lookup(x => _fixture.Create<IIdentifiable>(), default(Func<ITypedSeries<IIdentifiable>, ISeries<IIdentifiable>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("selectors");
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
        var result = this._testClass.Lookup(key, propertyNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithKeyAndPropertyNamesWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Lookup(default(object), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
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
        FluentActions.Invoking(() => this._testClass.Lookup(_fixture.Create<object>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("propertyNames");
    }

    /// <summary>
    /// Checks that the Lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLookupWithItemAndPropertyNames()
    {
        // Arrange
        var item = _fixture.Create<TEntity>();
        var propertyNames = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.Lookup(item, propertyNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the propertyNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLookupWithItemAndPropertyNamesWithNullPropertyNames()
    {
        FluentActions.Invoking(() => this._testClass.Lookup(_fixture.Create<TEntity>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("propertyNames");
    }

    /// <summary>
    /// Checks that the Memorize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMemorizeWithItems()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        var result = this._testClass.Memorize(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Memorize method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMemorizeWithItemsWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.Memorize(default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Memorize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMemorizeWithTEntity()
    {
        // Arrange
        var item = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Memorize(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Memorize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMemorizeWithTEntityAndArrayOfString()
    {
        // Arrange
        var item = _fixture.Create<TEntity>();
        var names = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.Memorize(item, names);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Memorize method throws when the names parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMemorizeWithTEntityAndArrayOfStringWithNullNames()
    {
        FluentActions.Invoking(() => this._testClass.Memorize(_fixture.Create<TEntity>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("names");
    }

    /// <summary>
    /// Checks that the MemorizeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallMemorizeAsyncWithTEntityAsync()
    {
        // Arrange
        var item = _fixture.Create<TEntity>();

        // Act
        var result = await this._testClass.MemorizeAsync(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MemorizeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallMemorizeAsyncWithTEntityAndArrayOfStringAsync()
    {
        // Arrange
        var item = _fixture.Create<TEntity>();
        var names = _fixture.Create<string[]>();

        // Act
        var result = await this._testClass.MemorizeAsync(item, names);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MemorizeAsync method throws when the names parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallMemorizeAsyncWithTEntityAndArrayOfStringWithNullNamesAsync()
    {
        await FluentActions.Invoking(() => this._testClass.MemorizeAsync(_fixture.Create<TEntity>(), default(string[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("names");
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

    /// <summary>
    /// Checks that setting the TypeId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeId()
    {
        this._testClass.CheckProperty(x => x.TypeId);
    }
}