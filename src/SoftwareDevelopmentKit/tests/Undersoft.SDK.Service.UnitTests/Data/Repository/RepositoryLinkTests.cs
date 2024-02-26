using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Client;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Remote;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Data.Repository;
using T = System.String;
using TOrigin = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;
using TTarget = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository;

/// <summary>
/// Unit tests for the type <see cref="RepositoryLink"/>.
/// </summary>
public class RepositoryLink_3Tests
{
    private RepositoryLink<TStore, TOrigin, TTarget> _testClass;
    private IFixture _fixture;
    private Mock<IRepositoryContextPool<OpenDataClient<TStore>>> _pool;
    private Mock<IEntityCache<TStore, TTarget>> _cache;
    private Mock<IRemoteRelation<TOrigin, TTarget>> _relation;
    private Mock<IRemoteSynchronizer> _synchronizer;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RepositoryLink"/>.
    /// </summary>
    public RepositoryLink_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._pool = _fixture.Freeze<Mock<IRepositoryContextPool<OpenDataClient<TStore>>>>();
        this._cache = _fixture.Freeze<Mock<IEntityCache<TStore, TTarget>>>();
        this._relation = _fixture.Freeze<Mock<IRemoteRelation<TOrigin, TTarget>>>();
        this._synchronizer = _fixture.Freeze<Mock<IRemoteSynchronizer>>();
        this._testClass = _fixture.Create<RepositoryLink<TStore, TOrigin, TTarget>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RepositoryLink<TStore, TOrigin, TTarget>(this._pool.Object, this._cache.Object, this._relation.Object, this._synchronizer.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the pool parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPool()
    {
        FluentActions.Invoking(() => new RepositoryLink<TStore, TOrigin, TTarget>(default(IRepositoryContextPool<OpenDataClient<TStore>>), this._cache.Object, this._relation.Object, this._synchronizer.Object)).Should().Throw<ArgumentNullException>().WithParameterName("pool");
    }

    /// <summary>
    /// Checks that instance construction throws when the cache parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCache()
    {
        FluentActions.Invoking(() => new RepositoryLink<TStore, TOrigin, TTarget>(this._pool.Object, default(IEntityCache<TStore, TTarget>), this._relation.Object, this._synchronizer.Object)).Should().Throw<ArgumentNullException>().WithParameterName("cache");
    }

    /// <summary>
    /// Checks that instance construction throws when the relation parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRelation()
    {
        FluentActions.Invoking(() => new RepositoryLink<TStore, TOrigin, TTarget>(this._pool.Object, this._cache.Object, default(IRemoteRelation<TOrigin, TTarget>), this._synchronizer.Object)).Should().Throw<ArgumentNullException>().WithParameterName("relation");
    }

    /// <summary>
    /// Checks that instance construction throws when the synchronizer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSynchronizer()
    {
        FluentActions.Invoking(() => new RepositoryLink<TStore, TOrigin, TTarget>(this._pool.Object, this._cache.Object, this._relation.Object, default(IRemoteSynchronizer))).Should().Throw<ArgumentNullException>().WithParameterName("synchronizer");
    }

    /// <summary>
    /// Checks that the CreatePredicate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreatePredicate()
    {
        // Arrange
        var entity = _fixture.Create<object>();

        // Act
        var result = this._testClass.CreatePredicate(entity);
    }

    /// <summary>
    /// Checks that the CreatePredicate method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreatePredicateWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.CreatePredicate(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Load method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadWithObject()
    {
        // Arrange
        var origin = _fixture.Create<object>();

        // Act
        this._testClass.Load(origin);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Load method throws when the origin parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadWithObjectWithNullOrigin()
    {
        FluentActions.Invoking(() => this._testClass.Load(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("origin");
    }

    /// <summary>
    /// Checks that the Load method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadWithOriginsAndContext()
    {
        // Arrange
        var origins = _fixture.Create<IEnumerable<T>>();
        var context = _fixture.Create<OpenDataContext>();

        // Act
        this._testClass.Load<T>(origins, context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Load method throws when the origins parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadWithOriginsAndContextWithNullOrigins()
    {
        FluentActions.Invoking(() => this._testClass.Load<T>(default(IEnumerable<T>), _fixture.Create<OpenDataContext>())).Should().Throw<ArgumentNullException>().WithParameterName("origins");
    }

    /// <summary>
    /// Checks that the Load method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadWithOriginsAndContextWithNullContext()
    {
        FluentActions.Invoking(() => this._testClass.Load<T>(_fixture.Create<IEnumerable<T>>(), default(OpenDataContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the Load method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadWithOriginAndContext()
    {
        // Arrange
        var origin = _fixture.Create<object>();
        var context = _fixture.Create<OpenDataContext>();

        // Act
        this._testClass.Load(origin, context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Load method throws when the origin parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadWithOriginAndContextWithNullOrigin()
    {
        FluentActions.Invoking(() => this._testClass.Load(default(object), _fixture.Create<OpenDataContext>())).Should().Throw<ArgumentNullException>().WithParameterName("origin");
    }

    /// <summary>
    /// Checks that the Load method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadWithOriginAndContextWithNullContext()
    {
        FluentActions.Invoking(() => this._testClass.Load(_fixture.Create<object>(), default(OpenDataContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the LoadAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallLoadAsyncWithObjectAsync()
    {
        // Arrange
        var origin = _fixture.Create<object>();

        // Act
        await this._testClass.LoadAsync(origin);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadAsync method throws when the origin parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallLoadAsyncWithObjectWithNullOriginAsync()
    {
        await FluentActions.Invoking(() => this._testClass.LoadAsync(default(object))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("origin");
    }

    /// <summary>
    /// Checks that the LoadAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallLoadAsyncWithOriginAndContextAndTokenAsync()
    {
        // Arrange
        var origin = _fixture.Create<object>();
        var context = _fixture.Create<OpenDataContext>();
        var token = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.LoadAsync(origin, context, token
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadAsync method throws when the origin parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallLoadAsyncWithOriginAndContextAndTokenWithNullOriginAsync()
    {
        await FluentActions.Invoking(() => this._testClass.LoadAsync(default(object), _fixture.Create<OpenDataContext>(), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("origin");
    }

    /// <summary>
    /// Checks that the LoadAsync method throws when the context parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallLoadAsyncWithOriginAndContextAndTokenWithNullContextAsync()
    {
        await FluentActions.Invoking(() => this._testClass.LoadAsync(_fixture.Create<object>(), default(OpenDataContext), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("context");
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

    /// <summary>
    /// Checks that the Host property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetHost()
    {
        // Arrange
        var testValue = _fixture.Create<IRepository>();

        // Act
        this._testClass.Host = testValue;

        // Assert
        this._testClass.Host.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the IsLinked property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsLinked()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.IsLinked = testValue;

        // Assert
        this._testClass.IsLinked.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the RemotesCount property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRemotesCount()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.RemotesCount = testValue;

        // Assert
        this._testClass.RemotesCount.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the RemoteRubric property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRemoteRubric()
    {
    }

    /// <summary>
    /// Checks that the SourceKey property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSourceKey()
    {
        // Arrange
        var testValue = _fixture.Create<Expression<Func<TOrigin, object>>>();

        // Act
        this._testClass.SourceKey = testValue;

        // Assert
        this._testClass.SourceKey.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Predicate property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPredicate()
    {
        // Arrange
        Func<TOrigin, Expression<Func<TTarget, bool>>> testValue = x => _fixture.Create<Expression<Func<TTarget, bool>>>();

        // Act
        this._testClass.Predicate = testValue;

        // Assert
        this._testClass.Predicate.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the TargetKey property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTargetKey()
    {
        // Arrange
        var testValue = _fixture.Create<Expression<Func<TTarget, object>>>();

        // Act
        this._testClass.TargetKey = testValue;

        // Assert
        this._testClass.TargetKey.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Towards property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetTowards()
    {
    }

    /// <summary>
    /// Checks that the JoinKey property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetJoinKey()
    {
        // Arrange
        var testValue = _fixture.Create<Expression<Func<IRemoteLink<TOrigin, TTarget>, object>>>();

        // Act
        this._testClass.JoinKey = testValue;

        // Assert
        this._testClass.JoinKey.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the MiddleSet property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMiddleSet()
    {
        // Arrange
        var testValue = _fixture.Create<Expression<Func<TOrigin, IEnumerable<IRemoteLink<TOrigin, TTarget>>>>>();

        // Act
        this._testClass.MiddleSet = testValue;

        // Assert
        this._testClass.MiddleSet.Should().BeSameAs(testValue);
    }
}