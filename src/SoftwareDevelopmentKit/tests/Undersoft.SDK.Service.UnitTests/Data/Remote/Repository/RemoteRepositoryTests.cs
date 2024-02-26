using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.OData.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Data.Client;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Data.Repository.Client;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TModel = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Remote.Repository;

/// <summary>
/// Unit tests for the type <see cref="RemoteRepository"/>.
/// </summary>
public class RemoteRepository_2Tests
{
    private RemoteRepository<TStore, TEntity> _testClass;
    private IFixture _fixture;
    private Mock<IRepositoryContextPool<OpenDataClient<TStore>>> _pool;
    private Mock<IEntityCache<TStore, TEntity>> _cache;
    private Mock<IAuthorization> _authorization;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteRepository"/>.
    /// </summary>
    public RemoteRepository_2Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._pool = _fixture.Freeze<Mock<IRepositoryContextPool<OpenDataClient<TStore>>>>();
        this._cache = _fixture.Freeze<Mock<IEntityCache<TStore, TEntity>>>();
        this._authorization = _fixture.Freeze<Mock<IAuthorization>>();
        this._testClass = _fixture.Create<RemoteRepository<TStore, TEntity>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteRepository<TStore, TEntity>(this._pool.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteRepository<TStore, TEntity>(this._pool.Object, this._cache.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteRepository<TStore, TEntity>(this._pool.Object, this._cache.Object, this._authorization.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the pool parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPool()
    {
        FluentActions.Invoking(() => new RemoteRepository<TStore, TEntity>(default(IRepositoryContextPool<OpenDataClient<TStore>>))).Should().Throw<ArgumentNullException>().WithParameterName("pool");
        FluentActions.Invoking(() => new RemoteRepository<TStore, TEntity>(default(IRepositoryContextPool<OpenDataClient<TStore>>), this._cache.Object)).Should().Throw<ArgumentNullException>().WithParameterName("pool");
        FluentActions.Invoking(() => new RemoteRepository<TStore, TEntity>(default(IRepositoryContextPool<OpenDataClient<TStore>>), this._cache.Object, this._authorization.Object)).Should().Throw<ArgumentNullException>().WithParameterName("pool");
    }

    /// <summary>
    /// Checks that instance construction throws when the cache parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCache()
    {
        FluentActions.Invoking(() => new RemoteRepository<TStore, TEntity>(this._pool.Object, default(IEntityCache<TStore, TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("cache");
        FluentActions.Invoking(() => new RemoteRepository<TStore, TEntity>(this._pool.Object, default(IEntityCache<TStore, TEntity>), this._authorization.Object)).Should().Throw<ArgumentNullException>().WithParameterName("cache");
    }

    /// <summary>
    /// Checks that instance construction throws when the authorization parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullAuthorization()
    {
        FluentActions.Invoking(() => new RemoteRepository<TStore, TEntity>(this._pool.Object, this._cache.Object, default(IAuthorization))).Should().Throw<ArgumentNullException>().WithParameterName("authorization");
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

/// <summary>
/// Unit tests for the type <see cref="RemoteRepository"/>.
/// </summary>
public partial class RemoteRepository_1Tests
{
    private class TestRemoteRepository : RemoteRepository<TEntity>
    {
        public TestRemoteRepository() : base()
        {
        }

        public TestRemoteRepository(IRepositoryClient repositorySource) : base(repositorySource)
        {
        }

        public TestRemoteRepository(OpenDataContext context) : base(context)
        {
        }

        public TestRemoteRepository(IRepositoryContextPool context) : base(context)
        {
        }

        public TestRemoteRepository(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        public TEntity PublicInnerSet(TEntity entity)
        {
            return base.InnerSet(entity);
        }

        public Task<int> PublicsaveAsTransaction(CancellationToken token)
        {
            return base.saveAsTransaction(token);
        }

        public Task<int> PublicsaveChanges(CancellationToken token)
        {
            return base.saveChanges(token);
        }

        public OpenDataContext PublicremoteContext => base.remoteContext;
    }

    private TestRemoteRepository _testClass;
    private IFixture _fixture;
    private Mock<IRepositoryClient> _repositorySource;
    private OpenDataContext _contextOpenDataContext;
    private Mock<IRepositoryContextPool> _contextIRepositoryContextPool;
    private Mock<IQueryProvider> _provider;
    private Expression _expression;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteRepository"/>.
    /// </summary>
    public RemoteRepository_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._repositorySource = _fixture.Freeze<Mock<IRepositoryClient>>();
        this._contextOpenDataContext = _fixture.Create<OpenDataContext>();
        this._contextIRepositoryContextPool = _fixture.Freeze<Mock<IRepositoryContextPool>>();
        this._provider = _fixture.Freeze<Mock<IQueryProvider>>();
        this._expression = _fixture.Create<Expression>();
        this._testClass = _fixture.Create<TestRemoteRepository>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRemoteRepository();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteRepository(this._repositorySource.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteRepository(this._contextOpenDataContext);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteRepository(this._contextIRepositoryContextPool.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteRepository(this._provider.Object, this._expression);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the repositorySource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepositorySource()
    {
        FluentActions.Invoking(() => new TestRemoteRepository(default(IRepositoryClient))).Should().Throw<ArgumentNullException>().WithParameterName("repositorySource");
    }

    /// <summary>
    /// Checks that instance construction throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullContext()
    {
        FluentActions.Invoking(() => new TestRemoteRepository(default(OpenDataContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
        FluentActions.Invoking(() => new TestRemoteRepository(default(IRepositoryContextPool))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that instance construction throws when the provider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullProvider()
    {
        FluentActions.Invoking(() => new TestRemoteRepository(default(IQueryProvider), this._expression)).Should().Throw<ArgumentNullException>().WithParameterName("provider");
    }

    /// <summary>
    /// Checks that instance construction throws when the expression parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpression()
    {
        FluentActions.Invoking(() => new TestRemoteRepository(this._provider.Object, default(Expression))).Should().Throw<ArgumentNullException>().WithParameterName("expression");
    }

    /// <summary>
    /// Checks that the lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCalllookupWithEntities()
    {
        // Arrange
        var entities = _fixture.Create<IEnumerable<TModel>>();

        // Act
        var result = this._testClass.lookup<TModel>(entities);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the lookup method throws when the entities parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCalllookupWithEntitiesWithNullEntities()
    {
        FluentActions.Invoking(() => this._testClass.lookup<TModel>(default(IEnumerable<TModel>))).Should().Throw<ArgumentNullException>().WithParameterName("entities");
    }

    /// <summary>
    /// Checks that the lookup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCalllookupWithTModel()
    {
        // Arrange
        var entity = _fixture.Create<TModel>();

        // Act
        var result = this._testClass.lookup<TModel>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the lookup method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCalllookupWithTModelWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.lookup<TModel>(default(TModel))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the PublicInnerSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInnerSet()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.PublicInnerSet(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInnerSet method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInnerSetWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.PublicInnerSet(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
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
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithTEntity()
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
    public void CannotCallAddWithTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIEnumerableOfTEntity()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<TEntity>>();

        // Act
        var result = this._testClass.Add(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIEnumerableOfTEntityWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
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
    /// Checks that the Find method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFindAsync()
    {
        // Arrange
        var keys = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.Find(keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the keys parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithNullKeysAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find(default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the FindMany method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFindManyAsync()
    {
        // Arrange
        var keys = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.FindMany(keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FindMany method throws when the keys parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindManyWithNullKeysAsync()
    {
        await FluentActions.Invoking(() => this._testClass.FindMany(default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("keys");
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
    /// Checks that the FindQuerySingle method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindQuerySingle()
    {
        // Arrange
        var keys = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.FindQuerySingle(keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FindQuerySingle method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindQuerySingleWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.FindQuerySingle(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the FindQuery method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindQuery()
    {
        // Arrange
        var keys = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.FindQuery(keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FindQuery method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindQueryWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.FindQuery(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
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
    /// Checks that the SetAuthorizationToken method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetAuthorizationToken()
    {
        // Arrange
        var token = _fixture.Create<string>();

        // Act
        this._testClass.SetAuthorizationToken(token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetAuthorizationToken method throws when the token parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetAuthorizationTokenWithInvalidToken(string value)
    {
        FluentActions.Invoking(() => this._testClass.SetAuthorizationToken(value)).Should().Throw<ArgumentNullException>().WithParameterName("token");
    }

    /// <summary>
    /// Checks that the PublicremoteContext property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicremoteContext()
    {
        // Assert
        this._testClass.PublicremoteContext.Should().BeAssignableTo<OpenDataContext>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Name property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetName()
    {
        // Assert
        this._testClass.Name.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FullName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetFullName()
    {
        // Assert
        this._testClass.FullName.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Query property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetQuery()
    {
        // Assert
        this._testClass.Query.Should().BeAssignableTo<DataServiceQuery<TEntity>>();

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