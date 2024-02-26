using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Data.Repository.Client;
using Undersoft.SDK.Service.Data.Repository.Source;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TException = System.String;
using TResult = System.String;

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
    /// Checks that the Filter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFilterWithSkipAndTakeAndSelectorAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();

        // Act
        var result = await this._testClass.Filter<TResult>(skip, take, selector
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the selector parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndSelectorWithNullSelectorAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TResult>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, TResult>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFilterWithSkipAndTakeAndSelectorAndExpandersAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Filter<TResult>(skip, take, selector, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the selector parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndSelectorAndExpandersWithNullSelectorAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TResult>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Filter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndSelectorAndExpandersWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TResult>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFilterWithSkipAndTakeAndPredicateAndSelectorAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();

        // Act
        var result = await this._testClass.Filter<TResult>(skip, take, predicate, selector
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndSelectorWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TResult>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<Expression<Func<TEntity, TResult>>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Filter method throws when the selector parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndSelectorWithNullSelectorAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TResult>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Expression<Func<TEntity, TResult>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFilterWithSkipAndTakeAndPredicateAndSortTermsAndSelectorAndExpandersAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Filter<TResult>(skip, take, predicate, sortTerms, selector, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndSortTermsAndSelectorAndExpandersWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TResult>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, TResult>>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Filter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndSortTermsAndSelectorAndExpandersWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TResult>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, TResult>>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Filter method throws when the selector parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndSortTermsAndSelectorAndExpandersWithNullSelectorAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TResult>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Filter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndSortTermsAndSelectorAndExpandersWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TResult>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFilterWithSkipAndTakeAndSortTermsAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();

        // Act
        var result = await this._testClass.Filter(skip, take, sortTerms
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndSortTermsWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter(_fixture.Create<int>(), _fixture.Create<int>(), default(SortExpression<TEntity>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFilterWithIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Filter(skip, take, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter(_fixture.Create<int>(), _fixture.Create<int>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Filter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFilterWithSkipAndTakeAndPredicateAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.Filter(skip, take, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, bool>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFilterWithSkipAndTakeAndPredicateAndSortTermsAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();

        // Act
        var result = await this._testClass.Filter(skip, take, predicate, sortTerms
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndSortTermsWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Filter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndSortTermsWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFilterWithSkipAndTakeAndPredicateAndExpandersAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Filter(skip, take, predicate, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndExpandersWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Filter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndExpandersWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFilterWithSkipAndTakeAndPredicateAndSortTermsAndExpandersAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Filter(skip, take, predicate, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndSortTermsAndExpandersWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Filter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndSortTermsAndExpandersWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Filter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndSortTermsAndExpandersWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFilterWithQueryAsync()
    {
        // Arrange
        var query = _fixture.Create<IQueryable<TEntity>>();

        // Act
        var result = await this._testClass.Filter(query);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the query parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithQueryWithNullQueryAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter(default(IQueryable<TEntity>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetWithExpandersAsync()
    {
        // Arrange
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Get(expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetWithExpandersWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Get(default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetWithSelectorAndExpandersAsync()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Get<TResult>(selector, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the selector parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetWithSelectorAndExpandersWithNullSelectorAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Get<TResult>(default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Get method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetWithSelectorAndExpandersWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Get<TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetWithSelectorAsync()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();

        // Act
        var result = await this._testClass.Get<TResult>(selector
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the selector parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetWithSelectorWithNullSelectorAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Get<TResult>(default(Expression<Func<TEntity, TResult>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetWithSkipAndTakeAndExpandersAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Get(skip, take, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetWithSkipAndTakeAndExpandersWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Get(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetWithSortTermsAndExpandersAsync()
    {
        // Arrange
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Get(sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetWithSortTermsAndExpandersWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Get(default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Get method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetWithSortTermsAndExpandersWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Get(_fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetWithIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Get(skip, take, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetWithIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Get(_fixture.Create<int>(), _fixture.Create<int>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Get method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetWithIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Get(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFindWithKeysAsync()
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
    public async Task CannotCallFindWithKeysWithNullKeysAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find(default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFindWithKeysAndExpandersAsync()
    {
        // Arrange
        var keys = _fixture.Create<object[]>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Find(keys, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the keys parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithKeysAndExpandersWithNullKeysAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find(default(object[]), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the Find method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithKeysAndExpandersWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find(_fixture.Create<object[]>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFindWithKeysAndSelectorAndExpandersAsync()
    {
        // Arrange
        var keys = _fixture.Create<object[]>();
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Find<TResult>(keys, selector, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the keys parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithKeysAndSelectorAndExpandersWithNullKeysAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find<TResult>(default(object[]), _fixture.Create<Expression<Func<TEntity, TResult>>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the Find method throws when the selector parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithKeysAndSelectorAndExpandersWithNullSelectorAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find<TResult>(_fixture.Create<object[]>(), default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Find method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithKeysAndSelectorAndExpandersWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find<TResult>(_fixture.Create<object[]>(), _fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFindWithPredicateAndReverseAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var reverse = _fixture.Create<bool>();

        // Act
        var result = await this._testClass.Find(predicate, reverse);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithPredicateAndReverseWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find(default(Expression<Func<TEntity, bool>>), _fixture.Create<bool>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFindWithPredicateAndReverseAndExpandersAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var reverse = _fixture.Create<bool>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Find(predicate, reverse, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithPredicateAndReverseAndExpandersWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find(default(Expression<Func<TEntity, bool>>), _fixture.Create<bool>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Find method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithPredicateAndReverseAndExpandersWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find(_fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<bool>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFindWithPredicateAndSelectorAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();

        // Act
        var result = await this._testClass.Find<TResult>(predicate, selector
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithPredicateAndSelectorWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find<TResult>(default(Expression<Func<TEntity, bool>>), _fixture.Create<Expression<Func<TEntity, TResult>>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Find method throws when the selector parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithPredicateAndSelectorWithNullSelectorAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find<TResult>(_fixture.Create<Expression<Func<TEntity, bool>>>(), default(Expression<Func<TEntity, TResult>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFindWithPredicateAndSelectorAndExpandersAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Find<TResult>(predicate, selector, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithPredicateAndSelectorAndExpandersWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find<TResult>(default(Expression<Func<TEntity, bool>>), _fixture.Create<Expression<Func<TEntity, TResult>>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Find method throws when the selector parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithPredicateAndSelectorAndExpandersWithNullSelectorAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find<TResult>(_fixture.Create<Expression<Func<TEntity, bool>>>(), default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Find method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFindWithPredicateAndSelectorAndExpandersWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Find<TResult>(_fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Exist method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExistWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.Exist(entity, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Exist method throws when the entity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExistWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullEntityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Exist(default(TEntity), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Exist method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExistWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Exist(_fixture.Create<TEntity>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Exist method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExistWithExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.Exist(predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Exist method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExistWithExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Exist(default(Expression<Func<TEntity, bool>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Exist method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExistWithTExceptionAndExpressionOfFuncOfTEntityAndBoolAndStringAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var message = _fixture.Create<string>();

        // Act
        var result = await this._testClass.Exist<TException>(predicate, message
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Exist method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExistWithTExceptionAndExpressionOfFuncOfTEntityAndBoolAndStringWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Exist<TException>(default(Expression<Func<TEntity, bool>>), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Exist method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallExistWithTExceptionAndExpressionOfFuncOfTEntityAndBoolAndStringWithInvalidMessageAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Exist<TException>(_fixture.Create<Expression<Func<TEntity, bool>>>(), value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Exist method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExistWithTExceptionAndObjectAndStringAsync()
    {
        // Arrange
        var instance = _fixture.Create<object>();
        var message = _fixture.Create<string>();

        // Act
        var result = await this._testClass.Exist<TException>(instance, message);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Exist method throws when the instance parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExistWithTExceptionAndObjectAndStringWithNullInstanceAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Exist<TException>(default(object), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("instance");
    }

    /// <summary>
    /// Checks that the Exist method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallExistWithTExceptionAndObjectAndStringWithInvalidMessageAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Exist<TException>(_fixture.Create<object>(), value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Exist method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExistWithTypeAndExpressionOfFuncOfTEntityAndBoolAndStringAsync()
    {
        // Arrange
        var exceptionType = _fixture.Create<Type>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var message = _fixture.Create<string>();

        // Act
        var result = await this._testClass.Exist(exceptionType, predicate, message
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Exist method throws when the exceptionType parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExistWithTypeAndExpressionOfFuncOfTEntityAndBoolAndStringWithNullExceptionTypeAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Exist(default(Type), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("exceptionType");
    }

    /// <summary>
    /// Checks that the Exist method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExistWithTypeAndExpressionOfFuncOfTEntityAndBoolAndStringWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Exist(_fixture.Create<Type>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Exist method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallExistWithTypeAndExpressionOfFuncOfTEntityAndBoolAndStringWithInvalidMessageAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Exist(_fixture.Create<Type>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Exist method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExistWithTypeAndObjectAndStringAsync()
    {
        // Arrange
        var exceptionType = _fixture.Create<Type>();
        var instance = _fixture.Create<object>();
        var message = _fixture.Create<string>();

        // Act
        var result = await this._testClass.Exist(exceptionType, instance, message);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Exist method throws when the exceptionType parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExistWithTypeAndObjectAndStringWithNullExceptionTypeAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Exist(default(Type), _fixture.Create<object>(), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("exceptionType");
    }

    /// <summary>
    /// Checks that the Exist method throws when the instance parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExistWithTypeAndObjectAndStringWithNullInstanceAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Exist(_fixture.Create<Type>(), default(object), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("instance");
    }

    /// <summary>
    /// Checks that the Exist method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallExistWithTypeAndObjectAndStringWithInvalidMessageAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Exist(_fixture.Create<Type>(), _fixture.Create<object>(), value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the NotExist method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallNotExistWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();
        Func<TEntity, Expression<Func<TEntity, bool>>> predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.NotExist(entity, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NotExist method throws when the entity parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallNotExistWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullEntityAsync()
    {
        await FluentActions.Invoking(() => this._testClass.NotExist(default(TEntity), x => _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the NotExist method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallNotExistWithTEntityAndFuncOfTEntityAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.NotExist(_fixture.Create<TEntity>(), default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the NotExist method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallNotExistWithExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.NotExist(predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NotExist method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallNotExistWithExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.NotExist(default(Expression<Func<TEntity, bool>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the NotExist method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallNotExistWithTypeAndExpressionOfFuncOfTEntityAndBoolAndStringAsync()
    {
        // Arrange
        var exceptionType = _fixture.Create<Type>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var message = _fixture.Create<string>();

        // Act
        var result = await this._testClass.NotExist(exceptionType, predicate, message
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NotExist method throws when the exceptionType parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallNotExistWithTypeAndExpressionOfFuncOfTEntityAndBoolAndStringWithNullExceptionTypeAsync()
    {
        await FluentActions.Invoking(() => this._testClass.NotExist(default(Type), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("exceptionType");
    }

    /// <summary>
    /// Checks that the NotExist method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallNotExistWithTypeAndExpressionOfFuncOfTEntityAndBoolAndStringWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.NotExist(_fixture.Create<Type>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the NotExist method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallNotExistWithTypeAndExpressionOfFuncOfTEntityAndBoolAndStringWithInvalidMessageAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.NotExist(_fixture.Create<Type>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the NotExist method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallNotExistWithTypeAndObjectAndStringAsync()
    {
        // Arrange
        var exceptionType = _fixture.Create<Type>();
        var instance = _fixture.Create<object>();
        var message = _fixture.Create<string>();

        // Act
        var result = await this._testClass.NotExist(exceptionType, instance, message
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NotExist method throws when the exceptionType parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallNotExistWithTypeAndObjectAndStringWithNullExceptionTypeAsync()
    {
        await FluentActions.Invoking(() => this._testClass.NotExist(default(Type), _fixture.Create<object>(), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("exceptionType");
    }

    /// <summary>
    /// Checks that the NotExist method throws when the instance parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallNotExistWithTypeAndObjectAndStringWithNullInstanceAsync()
    {
        await FluentActions.Invoking(() => this._testClass.NotExist(_fixture.Create<Type>(), default(object), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("instance");
    }

    /// <summary>
    /// Checks that the NotExist method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallNotExistWithTypeAndObjectAndStringWithInvalidMessageAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.NotExist(_fixture.Create<Type>(), _fixture.Create<object>(), value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the NotExist method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallNotExistWithTExceptionAndExpressionOfFuncOfTEntityAndBoolAndStringAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var message = _fixture.Create<string>();

        // Act
        var result = await this._testClass.NotExist<TException>(predicate, message
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NotExist method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallNotExistWithTExceptionAndExpressionOfFuncOfTEntityAndBoolAndStringWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.NotExist<TException>(default(Expression<Func<TEntity, bool>>), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the NotExist method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallNotExistWithTExceptionAndExpressionOfFuncOfTEntityAndBoolAndStringWithInvalidMessageAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.NotExist<TException>(_fixture.Create<Expression<Func<TEntity, bool>>>(), value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the NotExist method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallNotExistWithTExceptionAndObjectAndStringAsync()
    {
        // Arrange
        var instance = _fixture.Create<object>();
        var message = _fixture.Create<string>();

        // Act
        var result = await this._testClass.NotExist<TException>(instance, message);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NotExist method throws when the instance parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallNotExistWithTExceptionAndObjectAndStringWithNullInstanceAsync()
    {
        await FluentActions.Invoking(() => this._testClass.NotExist<TException>(default(object), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("instance");
    }

    /// <summary>
    /// Checks that the NotExist method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallNotExistWithTExceptionAndObjectAndStringWithInvalidMessageAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.NotExist<TException>(_fixture.Create<object>(), value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Sort method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSort()
    {
        // Arrange
        var query = _fixture.Create<IQueryable<TEntity>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();

        // Act
        var result = this._testClass.Sort(query, sortTerms
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Sort method throws when the query parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSortWithNullQuery()
    {
        FluentActions.Invoking(() => this._testClass.Sort(default(IQueryable<TEntity>), _fixture.Create<SortExpression<TEntity>>())).Should().Throw<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that the Sort method throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSortWithNullSortTerms()
    {
        FluentActions.Invoking(() => this._testClass.Sort(_fixture.Create<IQueryable<TEntity>>(), default(SortExpression<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }
}