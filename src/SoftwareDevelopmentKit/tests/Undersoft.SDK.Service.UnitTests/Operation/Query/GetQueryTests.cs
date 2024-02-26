using System;
using System.Linq;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Operation.Query;
using TDto = System.String;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Query;

/// <summary>
/// Unit tests for the type <see cref="GetQuery"/>.
/// </summary>
public class GetQuery_3Tests
{
    private GetQuery<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private Func<IRepository<TEntity>, IQueryable<TEntity>> _transformations;
    private Expression<Func<TEntity, object>>[] _expanders;
    private SortExpression<TEntity> _sortTerms;
    private Expression<Func<TEntity, bool>> _predicate;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="GetQuery"/>.
    /// </summary>
    public GetQuery_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._transformations = x => _fixture.Create<IQueryable<TEntity>>();
        this._expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();
        this._sortTerms = _fixture.Create<SortExpression<TEntity>>();
        this._predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._testClass = _fixture.Create<GetQuery<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new GetQuery<TStore, TEntity, TDto>(this._transformations);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new GetQuery<TStore, TEntity, TDto>(this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new GetQuery<TStore, TEntity, TDto>(this._sortTerms, this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new GetQuery<TStore, TEntity, TDto>(this._predicate, this._sortTerms, this._expanders);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the transformations parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTransformations()
    {
        FluentActions.Invoking(() => new GetQuery<TStore, TEntity, TDto>(default(Func<IRepository<TEntity>, IQueryable<TEntity>>))).Should().Throw<ArgumentNullException>().WithParameterName("transformations");
    }

    /// <summary>
    /// Checks that instance construction throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpanders()
    {
        FluentActions.Invoking(() => new GetQuery<TStore, TEntity, TDto>(default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new GetQuery<TStore, TEntity, TDto>(this._sortTerms, default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new GetQuery<TStore, TEntity, TDto>(this._predicate, this._sortTerms, default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that instance construction throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSortTerms()
    {
        FluentActions.Invoking(() => new GetQuery<TStore, TEntity, TDto>(default(SortExpression<TEntity>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
        FluentActions.Invoking(() => new GetQuery<TStore, TEntity, TDto>(this._predicate, default(SortExpression<TEntity>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new GetQuery<TStore, TEntity, TDto>(default(Expression<Func<TEntity, bool>>), this._sortTerms, this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }
}