using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Data.Cache;
using Undersoft.SDK.Service.Data.Mapper;
using Undersoft.SDK.Service.Data.Store;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Store;

/// <summary>
/// Unit tests for the type <see cref="StoreCache"/>.
/// </summary>
public class StoreCache_1Tests
{
    private class TestStoreCache : StoreCache<TStore>
    {
        public TestStoreCache(IDataCache cache) : base(cache)
        {
        }

        public TestStoreCache(TimeSpan? lifeTime = null, Invoker callback = null, int capacity = 257) : base(lifeTime, callback, capacity)
        {
        }

        public ITypedSeries<IIdentifiable> Publiccache { get => base.cache; set => base.cache = value; }
    }

    private TestStoreCache _testClass;
    private IFixture _fixture;
    private Mock<IDataCache> _cache;
    private TimeSpan? _lifeTime;
    private Invoker _callback;
    private int _capacity;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="StoreCache"/>.
    /// </summary>
    public StoreCache_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._cache = _fixture.Freeze<Mock<IDataCache>>();
        this._lifeTime = _fixture.Create<TimeSpan?>();
        this._callback = _fixture.Create<Invoker>();
        this._capacity = _fixture.Create<int>();
        this._testClass = _fixture.Create<TestStoreCache>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestStoreCache(this._cache.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestStoreCache(this._lifeTime, this._callback, this._capacity);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the cache parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCache()
    {
        FluentActions.Invoking(() => new TestStoreCache(default(IDataCache))).Should().Throw<ArgumentNullException>().WithParameterName("cache");
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
    /// Checks that setting the Mapper property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMapper()
    {
        this._testClass.CheckProperty(x => x.Mapper, _fixture.Create<IDataMapper>(), _fixture.Create<IDataMapper>());
    }
}