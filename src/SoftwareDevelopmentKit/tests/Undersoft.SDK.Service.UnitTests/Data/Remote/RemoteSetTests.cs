using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.OData.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Remote;
using Undersoft.SDK.Service.Data.Remote.Repository;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TOrigin = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Remote;

/// <summary>
/// Unit tests for the type <see cref="RemoteSet"/>.
/// </summary>
public class RemoteSet_2Tests
{
    private RemoteSet<TStore, TEntity> _testClass;
    private IFixture _fixture;
    private Mock<IRemoteRepository<TStore, TEntity>> _repository;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteSet"/>.
    /// </summary>
    public RemoteSet_2Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._repository = _fixture.Freeze<Mock<IRemoteRepository<TStore, TEntity>>>();
        this._testClass = _fixture.Create<RemoteSet<TStore, TEntity>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteSet<TStore, TEntity>(this._repository.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the repository parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepository()
    {
        FluentActions.Invoking(() => new RemoteSet<TStore, TEntity>(default(IRemoteRepository<TStore, TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("repository");
    }
}

/// <summary>
/// Unit tests for the type <see cref="RemoteSet"/>.
/// </summary>
public class RemoteSet_1Tests
{
    private class TestRemoteSet : RemoteSet<TEntity>
    {
        public TestRemoteSet() : base()
        {
        }

        public TestRemoteSet(DataServiceQuery<TEntity> query) : base(query)
        {
        }

        public TestRemoteSet(DataServiceContext context, IQueryable<TEntity> query) : base(context, query)
        {
        }

        public TestRemoteSet(DataServiceQuerySingle<TEntity> item) : base(item)
        {
        }

        public TestRemoteSet(IEnumerable<TEntity> items) : base(items)
        {
        }

        public TestRemoteSet(TrackingMode trackingMode, DataServiceQuerySingle<TEntity> item) : base(trackingMode, item)
        {
        }

        public TestRemoteSet(IEnumerable<TEntity> items, TrackingMode trackingMode) : base(items, trackingMode)
        {
        }

        public TestRemoteSet(DataServiceContext context) : base(context)
        {
        }

        public TestRemoteSet(
                                                                                                DataServiceContext context,
                                                                                                string entitySetName,
                                                                                                Func<EntityChangedParams, bool> entityChangedCallback,
                                                                                                Func<EntityCollectionChangedParams, bool> collectionChangedCallback
                                                                                            ) : base(context, entitySetName, entityChangedCallback, collectionChangedCallback
                                                                                    )
        {
        }

        public TestRemoteSet(
                                                                                                IEnumerable<TEntity> items,
                                                                                                TrackingMode trackingMode,
                                                                                                string entitySetName,
                                                                                                Func<EntityChangedParams, bool> entityChangedCallback,
                                                                                                Func<EntityCollectionChangedParams, bool> collectionChangedCallback
                                                                                            ) : base(items, trackingMode, entitySetName, entityChangedCallback, collectionChangedCallback
                                                                                    )
        {
        }

        public TestRemoteSet(
                                                                                                DataServiceContext context,
                                                                                                IEnumerable<TEntity> items,
                                                                                                TrackingMode trackingMode,
                                                                                                string entitySetName,
                                                                                                Func<EntityChangedParams, bool> entityChangedCallback,
                                                                                                Func<EntityCollectionChangedParams, bool> collectionChangedCallback
                                                                                            ) : base(context, items, trackingMode, entitySetName, entityChangedCallback, collectionChangedCallback
                                                                                    )
        {
        }

        public void PublicInsertItem(int index, TEntity item)
        {
            base.InsertItem(index, item);
        }

        public void PublicRemoveItem(int index)
        {
            base.RemoveItem(index);
        }

        public void PublicSetItem(int index, TEntity item)
        {
            base.SetItem(index, item);
        }

        public void PublicClearItems()
        {
            base.ClearItems();
        }

        public void PublicMoveItem(int oldIndex, int newIndex)
        {
            base.MoveItem(oldIndex, newIndex);
        }
    }

    private TestRemoteSet _testClass;
    private IFixture _fixture;
    private DataServiceQuery<TEntity> _queryDataServiceQueryTEntity;
    private DataServiceContext _context;
    private Mock<IQueryable<TEntity>> _queryIQueryableTEntity;
    private DataServiceQuerySingle<TEntity> _item;
    private IEnumerable<TEntity> _items;
    private TrackingMode _trackingMode;
    private string _entitySetName;
    private Func<EntityChangedParams, bool> _entityChangedCallback;
    private Func<EntityCollectionChangedParams, bool> _collectionChangedCallback;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteSet"/>.
    /// </summary>
    public RemoteSet_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._queryDataServiceQueryTEntity = _fixture.Create<DataServiceQuery<TEntity>>();
        this._context = _fixture.Create<DataServiceContext>();
        this._queryIQueryableTEntity = _fixture.Freeze<Mock<IQueryable<TEntity>>>();
        this._item = _fixture.Create<DataServiceQuerySingle<TEntity>>();
        this._items = _fixture.Create<IEnumerable<TEntity>>();
        this._trackingMode = _fixture.Create<TrackingMode>();
        this._entitySetName = _fixture.Create<string>();
        this._entityChangedCallback = x => _fixture.Create<bool>();
        this._collectionChangedCallback = x => _fixture.Create<bool>();
        this._testClass = _fixture.Create<TestRemoteSet>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRemoteSet();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteSet(this._queryDataServiceQueryTEntity);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteSet(this._context, this._queryIQueryableTEntity.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteSet(this._item);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteSet(this._items);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteSet(this._trackingMode, this._item);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteSet(this._items, this._trackingMode);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteSet(this._context);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteSet(this._context, this._entitySetName, this._entityChangedCallback, this._collectionChangedCallback);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteSet(this._items, this._trackingMode, this._entitySetName, this._entityChangedCallback, this._collectionChangedCallback);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteSet(this._context, this._items, this._trackingMode, this._entitySetName, this._entityChangedCallback, this._collectionChangedCallback);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the query parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullQuery()
    {
        FluentActions.Invoking(() => new TestRemoteSet(default(DataServiceQuery<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("query");
        FluentActions.Invoking(() => new TestRemoteSet(this._context, default(IQueryable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that instance construction throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullContext()
    {
        FluentActions.Invoking(() => new TestRemoteSet(default(DataServiceContext), this._queryIQueryableTEntity.Object)).Should().Throw<ArgumentNullException>().WithParameterName("context");
        FluentActions.Invoking(() => new TestRemoteSet(default(DataServiceContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
        FluentActions.Invoking(() => new TestRemoteSet(default(DataServiceContext), this._entitySetName, this._entityChangedCallback, this._collectionChangedCallback)).Should().Throw<ArgumentNullException>().WithParameterName("context");
        FluentActions.Invoking(() => new TestRemoteSet(default(DataServiceContext), this._items, this._trackingMode, this._entitySetName, this._entityChangedCallback, this._collectionChangedCallback)).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that instance construction throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullItem()
    {
        FluentActions.Invoking(() => new TestRemoteSet(default(DataServiceQuerySingle<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
        FluentActions.Invoking(() => new TestRemoteSet(this._trackingMode, default(DataServiceQuerySingle<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that instance construction throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullItems()
    {
        FluentActions.Invoking(() => new TestRemoteSet(default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
        FluentActions.Invoking(() => new TestRemoteSet(default(IEnumerable<TEntity>), this._trackingMode)).Should().Throw<ArgumentNullException>().WithParameterName("items");
        FluentActions.Invoking(() => new TestRemoteSet(default(IEnumerable<TEntity>), this._trackingMode, this._entitySetName, this._entityChangedCallback, this._collectionChangedCallback)).Should().Throw<ArgumentNullException>().WithParameterName("items");
        FluentActions.Invoking(() => new TestRemoteSet(this._context, default(IEnumerable<TEntity>), this._trackingMode, this._entitySetName, this._entityChangedCallback, this._collectionChangedCallback)).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that instance construction throws when the entityChangedCallback parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEntityChangedCallback()
    {
        FluentActions.Invoking(() => new TestRemoteSet(this._context, this._entitySetName, default(Func<EntityChangedParams, bool>), this._collectionChangedCallback)).Should().Throw<ArgumentNullException>().WithParameterName("entityChangedCallback");
        FluentActions.Invoking(() => new TestRemoteSet(this._items, this._trackingMode, this._entitySetName, default(Func<EntityChangedParams, bool>), this._collectionChangedCallback)).Should().Throw<ArgumentNullException>().WithParameterName("entityChangedCallback");
        FluentActions.Invoking(() => new TestRemoteSet(this._context, this._items, this._trackingMode, this._entitySetName, default(Func<EntityChangedParams, bool>), this._collectionChangedCallback)).Should().Throw<ArgumentNullException>().WithParameterName("entityChangedCallback");
    }

    /// <summary>
    /// Checks that instance construction throws when the collectionChangedCallback parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCollectionChangedCallback()
    {
        FluentActions.Invoking(() => new TestRemoteSet(this._context, this._entitySetName, this._entityChangedCallback, default(Func<EntityCollectionChangedParams, bool>))).Should().Throw<ArgumentNullException>().WithParameterName("collectionChangedCallback");
        FluentActions.Invoking(() => new TestRemoteSet(this._items, this._trackingMode, this._entitySetName, this._entityChangedCallback, default(Func<EntityCollectionChangedParams, bool>))).Should().Throw<ArgumentNullException>().WithParameterName("collectionChangedCallback");
        FluentActions.Invoking(() => new TestRemoteSet(this._context, this._items, this._trackingMode, this._entitySetName, this._entityChangedCallback, default(Func<EntityCollectionChangedParams, bool>))).Should().Throw<ArgumentNullException>().WithParameterName("collectionChangedCallback");
    }

    /// <summary>
    /// Checks that the constructor throws when the entitySetName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidEntitySetName(string value)
    {
        FluentActions.Invoking(() => new TestRemoteSet(this._context, value, this._entityChangedCallback, this._collectionChangedCallback)).Should().Throw<ArgumentNullException>().WithParameterName("entitySetName");
        FluentActions.Invoking(() => new TestRemoteSet(this._items, this._trackingMode, value, this._entityChangedCallback, this._collectionChangedCallback)).Should().Throw<ArgumentNullException>().WithParameterName("entitySetName");
        FluentActions.Invoking(() => new TestRemoteSet(this._context, this._items, this._trackingMode, value, this._entityChangedCallback, this._collectionChangedCallback)).Should().Throw<ArgumentNullException>().WithParameterName("entitySetName");
    }

    /// <summary>
    /// Checks that the Load method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadWithNoParameters()
    {
        // Act
        var result = this._testClass.Load();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Load method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadWithIntAndInt()
    {
        // Arrange
        var offset = _fixture.Create<int>();
        var limit = _fixture.Create<int>();

        // Act
        this._testClass.Load(offset, limit);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadAsyncWithIntAndInt()
    {
        // Arrange
        var offset = _fixture.Create<int>();
        var limit = _fixture.Create<int>();

        // Act
        this._testClass.LoadAsync(offset, limit);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Load method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadWithFuncOfIQueryableOfTEntityAndIQueryableOfTEntity()
    {
        // Arrange
        Func<IQueryable<TEntity>, IQueryable<TEntity>> query = x => _fixture.Create<IQueryable<TEntity>>();

        // Act
        var result = this._testClass.Load(query);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Load method throws when the query parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadWithFuncOfIQueryableOfTEntityAndIQueryableOfTEntityWithNullQuery()
    {
        FluentActions.Invoking(() => this._testClass.Load(default(Func<IQueryable<TEntity>, IQueryable<TEntity>>))).Should().Throw<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that the Load method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadWithExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.Load(predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Load method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadWithExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Load(default(Expression<Func<TEntity, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Load method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadWithTOriginAndTOriginAndFuncOfTOriginAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var origin = _fixture.Create<TOrigin>();
        Func<TOrigin, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        this._testClass.Load<TOrigin>(origin, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Load method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadWithTOriginAndTOriginAndFuncOfTOriginAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Load<TOrigin>(_fixture.Create<TOrigin>(), default(Func<TOrigin, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the LoadAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadAsyncWithFuncOfIQueryableOfTEntityAndIQueryableOfTEntity()
    {
        // Arrange
        Func<IQueryable<TEntity>, IQueryable<TEntity>> query = x => _fixture.Create<IQueryable<TEntity>>();

        // Act
        this._testClass.LoadAsync(query);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadAsync method throws when the query parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadAsyncWithFuncOfIQueryableOfTEntityAndIQueryableOfTEntityWithNullQuery()
    {
        FluentActions.Invoking(() => this._testClass.LoadAsync(default(Func<IQueryable<TEntity>, IQueryable<TEntity>>))).Should().Throw<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that the LoadAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadAsyncWithExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        this._testClass.LoadAsync(predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadAsyncWithExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.LoadAsync(default(Expression<Func<TEntity, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the LoadAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadAsyncWithTOriginAndTOriginAndFuncOfTOriginAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var origin = _fixture.Create<TOrigin>();
        Func<TOrigin, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        this._testClass.LoadAsync<TOrigin>(origin, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadAsyncWithTOriginAndTOriginAndFuncOfTOriginAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.LoadAsync<TOrigin>(_fixture.Create<TOrigin>(), default(Func<TOrigin, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Save method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSave()
    {
        // Act
        this._testClass.Save();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SaveAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSaveAsync()
    {
        // Act
        await this._testClass.SaveAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRange()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        this._testClass.AddRange(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRange method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRangeWithNullItems()
    {
        FluentActions.Invoking(() => this._testClass.AddRange(default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the PublicInsertItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsertItem()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var item = _fixture.Create<TEntity>();

        // Act
        this._testClass.PublicInsertItem(index, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInsertItem method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInsertItemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicInsertItem(_fixture.Create<int>(), default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicRemoveItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveItem()
    {
        // Arrange
        var index = _fixture.Create<int>();

        // Act
        this._testClass.PublicRemoveItem(index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicSetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetItem()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var item = _fixture.Create<TEntity>();

        // Act
        this._testClass.PublicSetItem(index, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicSetItem method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetItemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicSetItem(_fixture.Create<int>(), default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicClearItems method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClearItems()
    {
        // Act
        this._testClass.PublicClearItems();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicMoveItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMoveItem()
    {
        // Arrange
        var oldIndex = _fixture.Create<int>();
        var newIndex = _fixture.Create<int>();

        // Act
        this._testClass.PublicMoveItem(oldIndex, newIndex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ContainsKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsKey()
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
    public void CannotCallContainsKeyWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.ContainsKey(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the KeyString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyString()
    {
        // Arrange
        var keys = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.KeyString(keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the KeyString method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyStringWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.KeyString(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the KeyStringOnly method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyStringOnly()
    {
        // Arrange
        var keys = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.KeyStringOnly(keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the KeyStringOnly method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyStringOnlyWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.KeyStringOnly(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForObject()
    {
        var testValue = _fixture.Create<TEntity>();
        this._testClass[_fixture.Create<object>()].Should().BeAssignableTo<TEntity>();
        this._testClass[_fixture.Create<object>()] = testValue;
        this._testClass[_fixture.Create<object>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForObject[]()
    {
        var testValue = _fixture.Create<TEntity>();
        this._testClass[_fixture.Create<object[]>()].Should().BeAssignableTo<TEntity>();
        this._testClass[_fixture.Create<object[]>()] = testValue;
        this._testClass[_fixture.Create<object[]>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForFunc()
    {
        var testValue = _fixture.Create<IQueryable<TEntity>>();
        this._testClass[x => _fixture.Create<IQueryable<TEntity>>()].Should().BeAssignableTo<IQueryable<TEntity>>();
        this._testClass[x => _fixture.Create<IQueryable<TEntity>>()] = testValue;
        this._testClass[x => _fixture.Create<IQueryable<TEntity>>()].Should().BeSameAs(testValue);
    }
}