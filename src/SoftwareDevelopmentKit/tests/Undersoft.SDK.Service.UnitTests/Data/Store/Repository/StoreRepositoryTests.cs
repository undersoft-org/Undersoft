using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Data.Repository.Source;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Data.Store.Repository;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Store.Repository;

/// <summary>
/// Unit tests for the type <see cref="StoreRepository"/>.
/// </summary>
public partial class StoreRepository_1Tests
{
    private class TestStoreRepository : StoreRepository<TEntity>
    {
        public TestStoreRepository() : base()
        {
        }

        public TestStoreRepository(IRepositorySource repositorySource) : base(repositorySource)
        {
        }

        public TestStoreRepository(DataStoreContext context) : base(context)
        {
        }

        public TestStoreRepository(IRepositoryContextPool context) : base(context)
        {
        }

        public TestStoreRepository(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        public Task<int> PublicsaveAsTransaction(CancellationToken token)
        {
            return base.saveAsTransaction(token);
        }

        public Task<int> PublicsaveChanges(CancellationToken token)
        {
            return base.saveChanges(token);
        }

        public IDataStoreContext Publicstore => base.store;
    }

    private TestStoreRepository _testClass;
    private IFixture _fixture;
    private Mock<IRepositorySource> _repositorySource;
    private DataStoreContext _contextDataStoreContext;
    private Mock<IRepositoryContextPool> _contextIRepositoryContextPool;
    private Mock<IQueryProvider> _provider;
    private Expression _expression;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="StoreRepository"/>.
    /// </summary>
    public StoreRepository_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._repositorySource = _fixture.Freeze<Mock<IRepositorySource>>();
        this._contextDataStoreContext = _fixture.Create<DataStoreContext>();
        this._contextIRepositoryContextPool = _fixture.Freeze<Mock<IRepositoryContextPool>>();
        this._provider = _fixture.Freeze<Mock<IQueryProvider>>();
        this._expression = _fixture.Create<Expression>();
        this._testClass = _fixture.Create<TestStoreRepository>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestStoreRepository();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestStoreRepository(this._repositorySource.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestStoreRepository(this._contextDataStoreContext);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestStoreRepository(this._contextIRepositoryContextPool.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestStoreRepository(this._provider.Object, this._expression);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the repositorySource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepositorySource()
    {
        FluentActions.Invoking(() => new TestStoreRepository(default(IRepositorySource))).Should().Throw<ArgumentNullException>().WithParameterName("repositorySource");
    }

    /// <summary>
    /// Checks that instance construction throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullContext()
    {
        FluentActions.Invoking(() => new TestStoreRepository(default(DataStoreContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
        FluentActions.Invoking(() => new TestStoreRepository(default(IRepositoryContextPool))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that instance construction throws when the provider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullProvider()
    {
        FluentActions.Invoking(() => new TestStoreRepository(default(IQueryProvider), this._expression)).Should().Throw<ArgumentNullException>().WithParameterName("provider");
    }

    /// <summary>
    /// Checks that instance construction throws when the expression parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpression()
    {
        FluentActions.Invoking(() => new TestStoreRepository(this._provider.Object, default(Expression))).Should().Throw<ArgumentNullException>().WithParameterName("expression");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAdd()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Add(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Update method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdate()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Update(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Update method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Update(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the AddAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddAsync()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        var result = this._testClass.AddAsync(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddAsync method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddAsyncWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.AddAsync(default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the AutoTransaction method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAutoTransaction()
    {
        // Arrange
        var enable = _fixture.Create<bool>();

        // Act
        this._testClass.AutoTransaction(enable);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BeginTransaction method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBeginTransaction()
    {
        // Act
        var result = this._testClass.BeginTransaction();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BeginTransactionAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallBeginTransactionAsync()
    {
        // Act
        var result = await this._testClass.BeginTransactionAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ChangeDetecting method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallChangeDetecting()
    {
        // Arrange
        var enable = _fixture.Create<bool>();

        // Act
        this._testClass.ChangeDetecting(enable);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CommitTransaction method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallCommitTransactionWithTaskOfIDbContextTransactionAsync()
    {
        // Arrange
        var transaction = _fixture.Create<Task<IDbContextTransaction>>();

        // Act
        await this._testClass.CommitTransaction(transaction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CommitTransaction method throws when the transaction parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallCommitTransactionWithTaskOfIDbContextTransactionWithNullTransactionAsync()
    {
        await FluentActions.Invoking(() => this._testClass.CommitTransaction(default(Task<IDbContextTransaction>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("transaction");
    }

    /// <summary>
    /// Checks that the CommitTransaction method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCommitTransactionWithIDbContextTransaction()
    {
        // Arrange
        var transaction = _fixture.Create<IDbContextTransaction>();

        // Act
        this._testClass.CommitTransaction(transaction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CommitTransaction method throws when the transaction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCommitTransactionWithIDbContextTransactionWithNullTransaction()
    {
        FluentActions.Invoking(() => this._testClass.CommitTransaction(default(IDbContextTransaction))).Should().Throw<ArgumentNullException>().WithParameterName("transaction");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDelete()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Delete(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Delete method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Delete(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the LazyLoading method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLazyLoading()
    {
        // Arrange
        var enable = _fixture.Create<bool>();

        // Act
        this._testClass.LazyLoading(enable);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewEntry method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewEntry()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.NewEntry(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewEntry method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewEntryWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.NewEntry(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the QueryTracking method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQueryTracking()
    {
        // Arrange
        var enable = _fixture.Create<bool>();

        // Act
        this._testClass.QueryTracking(enable);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TrackingEvents method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTrackingEvents()
    {
        // Arrange
        var enable = _fixture.Create<bool>();

        // Act
        this._testClass.TrackingEvents(enable);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TracePatching method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTracePatching()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var propertyName = _fixture.Create<string>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.TracePatching(item, propertyName, type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TracePatching method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTracePatchingWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.TracePatching(default(object), _fixture.Create<string>(), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the TracePatching method throws when the propertyName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallTracePatchingWithInvalidPropertyName(string value)
    {
        FluentActions.Invoking(() => this._testClass.TracePatching(_fixture.Create<object>(), value, _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("propertyName");
    }

    /// <summary>
    /// Checks that the AsQueryable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAsQueryable()
    {
        // Act
        var result = this._testClass.AsQueryable();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicsaveAsTransaction method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallsaveAsTransactionAsync()
    {
        // Arrange
        var token = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.PublicsaveAsTransaction(token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicsaveChanges method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallsaveChangesAsync()
    {
        // Arrange
        var token = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.PublicsaveChanges(token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Publicstore property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicstore()
    {
        // Assert
        this._testClass.Publicstore.Should().BeAssignableTo<IDataStoreContext>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Query property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetQuery()
    {
        // Assert
        this._testClass.Query.Should().BeAssignableTo<IQueryable<TEntity>>();

        Assert.Fail("Create or modify test");
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
    public void CanSetAndGetIndexerForObject[]AndExpression[]()
    {
        var testValue = _fixture.Create<TEntity>();
        this._testClass[_fixture.Create<object[]>(), _fixture.Create<Expression<Func<TEntity, object>>[]>()].Should().BeAssignableTo<TEntity>();
        this._testClass[_fixture.Create<object[]>(), _fixture.Create<Expression<Func<TEntity, object>>[]>()] = testValue;
        this._testClass[_fixture.Create<object[]>(), _fixture.Create<Expression<Func<TEntity, object>>[]>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForExpressionAndObject[]AndExpression[]()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<Expression<Func<TEntity, object>>>(), _fixture.Create<object[]>(), _fixture.Create<Expression<Func<TEntity, object>>[]>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<Expression<Func<TEntity, object>>>(), _fixture.Create<object[]>(), _fixture.Create<Expression<Func<TEntity, object>>[]>()] = testValue;
        this._testClass[_fixture.Create<Expression<Func<TEntity, object>>>(), _fixture.Create<object[]>(), _fixture.Create<Expression<Func<TEntity, object>>[]>()].Should().BeSameAs(testValue);
    }
}

/// <summary>
/// Unit tests for the type <see cref="StoreRepository"/>.
/// </summary>
public class StoreRepository_2Tests
{
    private StoreRepository<TStore, TEntity> _testClass;
    private IFixture _fixture;
    private Mock<IRepositoryContextPool<DataStoreContext<TStore>>> _pool;
    private Mock<IEntityCache<TStore, TEntity>> _cache;
    private IEnumerable<IRemoteProperty<IDataStore, TEntity>> _remoteProps;
    private Mock<IRemoteSynchronizer> _synchronizer;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="StoreRepository"/>.
    /// </summary>
    public StoreRepository_2Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._pool = _fixture.Freeze<Mock<IRepositoryContextPool<DataStoreContext<TStore>>>>();
        this._cache = _fixture.Freeze<Mock<IEntityCache<TStore, TEntity>>>();
        this._remoteProps = _fixture.Create<IEnumerable<IRemoteProperty<IDataStore, TEntity>>>();
        this._synchronizer = _fixture.Freeze<Mock<IRemoteSynchronizer>>();
        this._testClass = _fixture.Create<StoreRepository<TStore, TEntity>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new StoreRepository<TStore, TEntity>(this._pool.Object, this._cache.Object, this._remoteProps, this._synchronizer.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the pool parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPool()
    {
        FluentActions.Invoking(() => new StoreRepository<TStore, TEntity>(default(IRepositoryContextPool<DataStoreContext<TStore>>), this._cache.Object, this._remoteProps, this._synchronizer.Object)).Should().Throw<ArgumentNullException>().WithParameterName("pool");
    }

    /// <summary>
    /// Checks that instance construction throws when the cache parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCache()
    {
        FluentActions.Invoking(() => new StoreRepository<TStore, TEntity>(this._pool.Object, default(IEntityCache<TStore, TEntity>), this._remoteProps, this._synchronizer.Object)).Should().Throw<ArgumentNullException>().WithParameterName("cache");
    }

    /// <summary>
    /// Checks that instance construction throws when the remoteProps parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRemoteProps()
    {
        FluentActions.Invoking(() => new StoreRepository<TStore, TEntity>(this._pool.Object, this._cache.Object, default(IEnumerable<IRemoteProperty<IDataStore, TEntity>>), this._synchronizer.Object)).Should().Throw<ArgumentNullException>().WithParameterName("remoteProps");
    }

    /// <summary>
    /// Checks that instance construction throws when the synchronizer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSynchronizer()
    {
        FluentActions.Invoking(() => new StoreRepository<TStore, TEntity>(this._pool.Object, this._cache.Object, this._remoteProps, default(IRemoteSynchronizer))).Should().Throw<ArgumentNullException>().WithParameterName("synchronizer");
    }

    /// <summary>
    /// Checks that the Save method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSaveAsync()
    {
        // Arrange
        var asTransaction = _fixture.Create<bool>();
        var token = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Save(asTransaction, token);

        // Assert
        Assert.Fail("Create or modify test");
    }
}