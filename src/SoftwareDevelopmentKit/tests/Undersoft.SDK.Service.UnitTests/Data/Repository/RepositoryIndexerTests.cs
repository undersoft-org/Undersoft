using System;
using System.Linq;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Data.Repository.Client;
using Undersoft.SDK.Service.Data.Repository.Source;
using TEntity = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository;

/// <summary>
/// Unit tests for the type <see cref="Repository"/>.
/// </summary>
public partial class Repository_1Tests
{
    private class TestRepository : Repository<TEntity>
    {
        public TestRepository() : base()
        {
        }

        public TestRepository(IRepositoryClient repositorySource) : base(repositorySource)
        {
        }

        public TestRepository(IRepositorySource repositorySource) : base(repositorySource)
        {
        }

        public TestRepository(object context) : base(context)
        {
        }

        public TestRepository(IRepositoryContext context) : base(context)
        {
        }

        public TestRepository(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        protected override Task<int> saveAsTransaction(CancellationToken token)
        {
            return default(Task<int>);
        }

        protected override Task<int> saveChanges(CancellationToken token)
        {
            return default(Task<int>);
        }

        public override TEntity NewEntry(object[] parameters)
        {
            return default(TEntity);
        }

        public override TEntity Add(TEntity entity)
        {
            return default(TEntity);
        }

        public override TEntity Delete(TEntity entity)
        {
            return default(TEntity);
        }

        public override IQueryable<TEntity> AsQueryable()
        {
            return default(IQueryable<TEntity>);
        }

        public override TEntity this[] { get; set; }
        public override TEntity this[] { get; set; }
        public override object this[] { get; set; }
        public override IQueryable<TEntity> Query { get; }
    }

    private TestRepository _testClass;
    private IFixture _fixture;
    private Mock<IRepositoryClient> _repositorySourceIRepositoryClient;
    private Mock<IRepositorySource> _repositorySourceIRepositorySource;
    private object _contextObject;
    private Mock<IRepositoryContext> _contextIRepositoryContext;
    private Mock<IQueryProvider> _provider;
    private Expression _expression;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Repository"/>.
    /// </summary>
    public Repository_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._repositorySourceIRepositoryClient = _fixture.Freeze<Mock<IRepositoryClient>>();
        this._repositorySourceIRepositorySource = _fixture.Freeze<Mock<IRepositorySource>>();
        this._contextObject = _fixture.Create<object>();
        this._contextIRepositoryContext = _fixture.Freeze<Mock<IRepositoryContext>>();
        this._provider = _fixture.Freeze<Mock<IQueryProvider>>();
        this._expression = _fixture.Create<Expression>();
        this._testClass = _fixture.Create<TestRepository>();
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

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForIQueryableAndExpression[]()
    {
        this._testClass[_fixture.Create<IQueryable<TEntity>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>()].Should().BeAssignableTo<IQueryable<TEntity>>();
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForExpression[]()
    {
        this._testClass[_fixture.Create<Expression<Func<TEntity, object>>[]>()].Should().BeAssignableTo<IQueryable<TEntity>>();
        Assert.Fail("Create or modify test");
    }
}