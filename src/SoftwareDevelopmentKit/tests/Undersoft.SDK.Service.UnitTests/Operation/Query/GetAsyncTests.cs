using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Operation.Query;
using TDto = System.String;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Query;

/// <summary>
/// Unit tests for the type <see cref="GetAsync"/>.
/// </summary>
public class GetAsync_3Tests
{
    private GetAsync<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private int _offset;
    private int _limit;
    private Expression<Func<TEntity, object>>[] _expanders;
    private SortExpression<TEntity> _sortTerms;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="GetAsync"/>.
    /// </summary>
    public GetAsync_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._offset = _fixture.Create<int>();
        this._limit = _fixture.Create<int>();
        this._expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();
        this._sortTerms = _fixture.Create<SortExpression<TEntity>>();
        this._testClass = _fixture.Create<GetAsync<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new GetAsync<TStore, TEntity, TDto>(this._offset, this._limit, this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new GetAsync<TStore, TEntity, TDto>(this._offset, this._limit, this._sortTerms, this._expanders);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpanders()
    {
        FluentActions.Invoking(() => new GetAsync<TStore, TEntity, TDto>(this._offset, this._limit, default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new GetAsync<TStore, TEntity, TDto>(this._offset, this._limit, this._sortTerms, default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that instance construction throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSortTerms()
    {
        FluentActions.Invoking(() => new GetAsync<TStore, TEntity, TDto>(this._offset, this._limit, default(SortExpression<TEntity>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }
}