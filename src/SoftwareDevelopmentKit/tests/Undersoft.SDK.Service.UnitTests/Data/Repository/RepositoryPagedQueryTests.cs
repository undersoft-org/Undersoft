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
using TDto = System.String;
using TEntity = System.String;
using TResult = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository;

/// <summary>
/// Unit tests for the type <see cref="Repository"/>.
/// </summary>
public partial class Repository_1Tests
{
    private Repository<TEntity> _testClass;
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
        this._testClass = _fixture.Create<Repository<TEntity>>();
    }

    /// <summary>
    /// Checks that the AsPage method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAsPage()
    {
        // Arrange
        var pageIndex = _fixture.Create<int>();
        var pageSize = _fixture.Create<int>();
        var indexFrom = _fixture.Create<int>();

        // Act
        var result = this._testClass.AsPage(pageIndex, pageSize, indexFrom);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFilterWithIQueryableOfTEntity()
    {
        // Arrange
        var query = _fixture.Create<IQueryable<TEntity>>();

        // Act
        var result = this._testClass.Filter<TDto>(query);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the query parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithIQueryableOfTEntityWithNullQuery()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto>(default(IQueryable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFilterWithIQueryableOfTDto()
    {
        // Arrange
        var query = _fixture.Create<IQueryable<TDto>>();

        // Act
        var result = this._testClass.Filter<TDto>(query);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the query parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithIQueryableOfTDtoWithNullQuery()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto>(default(IQueryable<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithTResultAndExpressionOfFuncOfTEntityAndTResultAsync()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();

        // Act
        var result = await this._testClass.PagedFilter<TResult>(selector
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the selector parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTResultAndExpressionOfFuncOfTEntityAndTResultWithNullSelectorAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TResult>(default(Expression<Func<TEntity, TResult>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithSortExpressionOfTEntityAsync()
    {
        // Arrange
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();

        // Act
        var result = await this._testClass.PagedFilter(sortTerms);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithSortExpressionOfTEntityWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter(default(SortExpression<TEntity>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.PagedFilter(predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter(default(Expression<Func<TEntity, bool>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithTDtoAndSortExpressionOfTEntityAsync()
    {
        // Arrange
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();

        // Act
        var result = await this._testClass.PagedFilter<TDto>(sortTerms);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTDtoAndSortExpressionOfTEntityWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TDto>(default(SortExpression<TEntity>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithTDtoAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.PagedFilter<TDto>(predicate);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTDtoAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TDto>(default(Expression<Func<TEntity, bool>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPagedFilterWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResult()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();

        // Act
        var result = this._testClass.PagedFilter<TDto, TResult>(selector
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPagedFilterWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.PagedFilter<TDto, TResult>(default(Expression<Func<TEntity, TResult>>))).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolAsync()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = await this._testClass.PagedFilter<TResult>(selector, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the selector parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolWithNullSelectorAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TResult>(default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, bool>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithTResultAndExpressionOfFuncOfTEntityAndTResultAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.PagedFilter<TResult>(selector, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the selector parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTResultAndExpressionOfFuncOfTEntityAndTResultAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSelectorAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TResult>(default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTResultAndExpressionOfFuncOfTEntityAndTResultAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();

        // Act
        var result = await this._testClass.PagedFilter(predicate, sortTerms
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter(default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter(_fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.PagedFilter(predicate, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter(default(Expression<Func<TEntity, bool>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter(_fixture.Create<Expression<Func<TEntity, bool>>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.PagedFilter(sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter(default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter(_fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();

        // Act
        var result = await this._testClass.PagedFilter<TDto>(predicate, sortTerms
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TDto>(default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TDto>(_fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.PagedFilter<TDto>(predicate, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TDto>(default(Expression<Func<TEntity, bool>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TDto>(_fixture.Create<Expression<Func<TEntity, bool>>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithTDtoAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.PagedFilter<TDto>(sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTDtoAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TDto>(default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTDtoAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TDto>(_fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPagedFilterWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.PagedFilter<TDto, TResult>(selector, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPagedFilterWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.PagedFilter<TDto, TResult>(default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPagedFilterWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.PagedFilter<TDto, TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPagedFilterWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.PagedFilter<TDto, TResult>(selector, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPagedFilterWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.PagedFilter<TDto, TResult>(default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPagedFilterWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.PagedFilter<TDto, TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
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
        var result = await this._testClass.Filter<TDto>(skip, take, sortTerms
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
        await FluentActions.Invoking(() => this._testClass.Filter<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), default(SortExpression<TEntity>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
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
        var result = await this._testClass.Filter<TDto>(skip, take, predicate
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
        await FluentActions.Invoking(() => this._testClass.Filter<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, bool>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFilterWithSkipAndTakeAndSelector()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();

        // Act
        var result = this._testClass.Filter<TDto, TResult>(skip, take, selector
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithSkipAndTakeAndSelectorWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto, TResult>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, TResult>>))).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.PagedFilter(predicate, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter(default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter(_fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter(_fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.PagedFilter<TDto>(predicate, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TDto>(default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TDto>(_fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TDto>(_fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
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
        var result = await this._testClass.Filter<TDto>(skip, take, predicate, expanders
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
        await FluentActions.Invoking(() => this._testClass.Filter<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Filter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndExpandersWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
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
        var result = await this._testClass.Filter<TDto>(skip, take, predicate, sortTerms
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
        await FluentActions.Invoking(() => this._testClass.Filter<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Filter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithSkipAndTakeAndPredicateAndSortTermsWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFilterWithTDtoAndIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Filter<TDto>(skip, take, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithTDtoAndIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Filter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithTDtoAndIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the FilterAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFilterAsyncWithTDtoAndIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.FilterAsync<TDto>(skip, take, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FilterAsync method throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterAsyncWithTDtoAndIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTerms()
    {
        FluentActions.Invoking(() => this._testClass.FilterAsync<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the FilterAsync method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterAsyncWithTDtoAndIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.FilterAsync<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFilterWithSkipAndTakeAndSelectorAndPredicate()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.Filter<TDto, TResult>(skip, take, selector, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithSkipAndTakeAndSelectorAndPredicateWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto, TResult>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Filter method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithSkipAndTakeAndSelectorAndPredicateWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto, TResult>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFilterWithSkipAndTakeAndSelectorAndExpanders()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.Filter<TDto, TResult>(skip, take, selector, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithSkipAndTakeAndSelectorAndExpandersWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto, TResult>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Filter method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithSkipAndTakeAndSelectorAndExpandersWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto, TResult>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedFilterWithTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.PagedFilter<TResult>(selector, predicate, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the selector parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSelectorAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TResult>(default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedFilterWithTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedFilter<TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the PagedFilter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPagedFilterWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.PagedFilter<TDto, TResult>(selector, predicate, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPagedFilterWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.PagedFilter<TDto, TResult>(default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPagedFilterWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.PagedFilter<TDto, TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPagedFilterWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTerms()
    {
        FluentActions.Invoking(() => this._testClass.PagedFilter<TDto, TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the PagedFilter method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPagedFilterWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.PagedFilter<TDto, TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFilterWithTDtoAndIntAndIntAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Filter<TDto>(skip, take, predicate, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithTDtoAndIntAndIntAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Filter method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithTDtoAndIntAndIntAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Filter method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFilterWithTDtoAndIntAndIntAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Filter<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the FilterAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFilterAsyncWithTDtoAndIntAndIntAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.FilterAsync<TDto>(skip, take, predicate, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FilterAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterAsyncWithTDtoAndIntAndIntAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.FilterAsync<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the FilterAsync method throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterAsyncWithTDtoAndIntAndIntAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTerms()
    {
        FluentActions.Invoking(() => this._testClass.FilterAsync<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the FilterAsync method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterAsyncWithTDtoAndIntAndIntAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.FilterAsync<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFilterWithSkipAndTakeAndSelectorAndSortTermsAndPredicate()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.Filter<TDto, TResult>(skip, take, selector, sortTerms, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithSkipAndTakeAndSelectorAndSortTermsAndPredicateWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto, TResult>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, TResult>>), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Filter method throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithSkipAndTakeAndSelectorAndSortTermsAndPredicateWithNullSortTerms()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto, TResult>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, TResult>>>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Filter method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithSkipAndTakeAndSelectorAndSortTermsAndPredicateWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto, TResult>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, TResult>>>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Filter method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFilterWithSkipAndTakeAndSelectorAndPredicateAndSortTermsAndExpanders()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.Filter<TDto, TResult>(skip, take, selector, predicate, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Filter method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithSkipAndTakeAndSelectorAndPredicateAndSortTermsAndExpandersWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto, TResult>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Filter method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithSkipAndTakeAndSelectorAndPredicateAndSortTermsAndExpandersWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto, TResult>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Filter method throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithSkipAndTakeAndSelectorAndPredicateAndSortTermsAndExpandersWithNullSortTerms()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto, TResult>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, TResult>>>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Filter method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFilterWithSkipAndTakeAndSelectorAndPredicateAndSortTermsAndExpandersWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.Filter<TDto, TResult>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Expression<Func<TEntity, TResult>>>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindWithKeys()
    {
        // Arrange
        var keys = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Find<TDto>(keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithKeysWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindWithTDtoAndArrayOfObjectAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var keys = _fixture.Create<object[]>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.Find<TDto>(keys, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithTDtoAndArrayOfObjectAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto>(default(object[]), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the Find method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithTDtoAndArrayOfObjectAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto>(_fixture.Create<object[]>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindWithPredicateAndReverse()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var reverse = _fixture.Create<bool>();

        // Act
        var result = this._testClass.Find<TDto>(predicate, reverse
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithPredicateAndReverseWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto>(default(Expression<Func<TEntity, bool>>), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBool()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.Find<TDto, TResult>(selector, predicate
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto, TResult>(default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Find method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultAndExpressionOfFuncOfTEntityAndBoolWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto, TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindWithSelectorAndKeysAndExpanders()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var keys = _fixture.Create<object[]>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.Find<TDto, TResult>(selector, keys, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithSelectorAndKeysAndExpandersWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto, TResult>(default(Expression<Func<TEntity, TResult>>), _fixture.Create<object[]>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Find method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithSelectorAndKeysAndExpandersWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto, TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), default(object[]), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the Find method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithSelectorAndKeysAndExpandersWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto, TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), _fixture.Create<object[]>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindWithPredicateAndReverseAndExpanders()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var reverse = _fixture.Create<bool>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.Find<TDto>(predicate, reverse, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithPredicateAndReverseAndExpandersWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto>(default(Expression<Func<TEntity, bool>>), _fixture.Create<bool>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Find method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithPredicateAndReverseAndExpandersWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto>(_fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<bool>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Find method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindWithSelectorAndPredicateAndExpanders()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.Find<TDto, TResult>(selector, predicate, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Find method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithSelectorAndPredicateAndExpandersWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto, TResult>(default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Find method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithSelectorAndPredicateAndExpandersWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto, TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, bool>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the Find method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindWithSelectorAndPredicateAndExpandersWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.Find<TDto, TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), _fixture.Create<Expression<Func<TEntity, bool>>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the FindOneAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindOneAsyncWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.FindOneAsync<TDto>(predicate, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FindOneAsync method throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindOneAsyncWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullPredicate()
    {
        FluentActions.Invoking(() => this._testClass.FindOneAsync<TDto>(default(Expression<Func<TEntity, bool>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the FindOneAsync method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindOneAsyncWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.FindOneAsync<TDto>(_fixture.Create<Expression<Func<TEntity, bool>>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the FindOneAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindOneAsyncWithTDtoAndArrayOfObjectAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var keys = _fixture.Create<object[]>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.FindOneAsync<TDto>(keys, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FindOneAsync method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindOneAsyncWithTDtoAndArrayOfObjectAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.FindOneAsync<TDto>(default(object[]), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the FindOneAsync method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindOneAsyncWithTDtoAndArrayOfObjectAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.FindOneAsync<TDto>(_fixture.Create<object[]>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResult()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();

        // Act
        var result = this._testClass.Get<TDto, TResult>(selector
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithTDtoAndTResultAndExpressionOfFuncOfTEntityAndTResultWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.Get<TDto, TResult>(default(Expression<Func<TEntity, TResult>>))).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the PagedGet method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedGetWithArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.PagedGet(expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedGet method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedGetWithArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedGet(default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the PagedGet method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPagedGetWithTDtoAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.PagedGet<TDto>(expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PagedGet method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPagedGetWithTDtoAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PagedGet<TDto>(default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithExpressionOfFuncOfTEntityAndTResultAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var selector = _fixture.Create<Expression<Func<TEntity, TResult>>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.Get<TDto, TResult>(selector, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the selector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithExpressionOfFuncOfTEntityAndTResultAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSelector()
    {
        FluentActions.Invoking(() => this._testClass.Get<TDto, TResult>(default(Expression<Func<TEntity, TResult>>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("selector");
    }

    /// <summary>
    /// Checks that the Get method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithExpressionOfFuncOfTEntityAndTResultAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.Get<TDto, TResult>(_fixture.Create<Expression<Func<TEntity, TResult>>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetWithTDtoAndIntAndIntAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Get<TDto>(skip, take, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetWithTDtoAndIntAndIntAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Get<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetWithTDtoAndIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.Get<TDto>(skip, take, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetWithTDtoAndIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Get<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Get method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetWithTDtoAndIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Get<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the GetYield method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetYield()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.GetYield<TDto>(skip, take, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetYield method throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetYieldWithNullSortTerms()
    {
        FluentActions.Invoking(() => this._testClass.GetYield<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the GetYield method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetYieldWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.GetYield<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the GetQuery method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetQueryWithTDtoAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.GetQuery<TDto>(expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetQuery method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetQueryWithTDtoAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.GetQuery<TDto>(default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the GetQuery method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetQueryWithTDtoAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.GetQuery<TDto>(sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetQuery method throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetQueryWithTDtoAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTerms()
    {
        FluentActions.Invoking(() => this._testClass.GetQuery<TDto>(default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the GetQuery method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetQueryWithTDtoAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.GetQuery<TDto>(_fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the GetQueryAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetQueryAsyncWithTDtoAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.GetQueryAsync<TDto>(expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetQueryAsync method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetQueryAsyncWithTDtoAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.GetQueryAsync<TDto>(default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the GetQueryAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetQueryAsyncWithTDtoAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.GetQueryAsync<TDto>(sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetQueryAsync method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetQueryAsyncWithTDtoAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.GetQueryAsync<TDto>(default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the GetQueryAsync method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetQueryAsyncWithTDtoAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.GetQueryAsync<TDto>(_fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the GetQueryAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetQueryAsyncWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectAsync()
    {
        // Arrange
        var predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = await this._testClass.GetQueryAsync<TDto>(predicate, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetQueryAsync method throws when the predicate parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetQueryAsyncWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullPredicateAsync()
    {
        await FluentActions.Invoking(() => this._testClass.GetQueryAsync<TDto>(default(Expression<Func<TEntity, bool>>), _fixture.Create<SortExpression<TEntity>>(), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that the GetQueryAsync method throws when the sortTerms parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetQueryAsyncWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTermsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.GetQueryAsync<TDto>(_fixture.Create<Expression<Func<TEntity, bool>>>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the GetQueryAsync method throws when the expanders parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallGetQueryAsyncWithTDtoAndExpressionOfFuncOfTEntityAndBoolAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpandersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.GetQueryAsync<TDto>(_fixture.Create<Expression<Func<TEntity, bool>>>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the GetAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetAsyncWithTDtoAndIntAndIntAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.GetAsync<TDto>(skip, take, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetAsync method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetAsyncWithTDtoAndIntAndIntAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.GetAsync<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that the GetAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetAsyncWithTDtoAndIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObject()
    {
        // Arrange
        var skip = _fixture.Create<int>();
        var take = _fixture.Create<int>();
        var sortTerms = _fixture.Create<SortExpression<TEntity>>();
        var expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();

        // Act
        var result = this._testClass.GetAsync<TDto>(skip, take, sortTerms, expanders
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetAsync method throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetAsyncWithTDtoAndIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullSortTerms()
    {
        FluentActions.Invoking(() => this._testClass.GetAsync<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), default(SortExpression<TEntity>), _fixture.Create<Expression<Func<TEntity, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the GetAsync method throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetAsyncWithTDtoAndIntAndIntAndSortExpressionOfTEntityAndArrayOfExpressionOfFuncOfTEntityAndObjectWithNullExpanders()
    {
        FluentActions.Invoking(() => this._testClass.GetAsync<TDto>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<SortExpression<TEntity>>(), default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }
}