using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Operation.Remote.Query;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TModel = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Query;

/// <summary>
/// Unit tests for the type <see cref="RemoteFilter"/>.
/// </summary>
public class RemoteFilter_3Tests
{
    private RemoteFilter<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private int _offset;
    private int _limit;
    private Expression<Func<TDto, bool>> _predicate;
    private Expression<Func<TDto, object>>[] _expanders;
    private SortExpression<TDto> _sortTerms;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteFilter"/>.
    /// </summary>
    public RemoteFilter_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._offset = _fixture.Create<int>();
        this._limit = _fixture.Create<int>();
        this._predicate = _fixture.Create<Expression<Func<TDto, bool>>>();
        this._expanders = _fixture.Create<Expression<Func<TDto, object>>[]>();
        this._sortTerms = _fixture.Create<SortExpression<TDto>>();
        this._testClass = _fixture.Create<RemoteFilter<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteFilter<TStore, TDto, TModel>(this._offset, this._limit, this._predicate);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteFilter<TStore, TDto, TModel>(this._offset, this._limit, this._predicate, this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteFilter<TStore, TDto, TModel>(this._offset, this._limit, this._predicate, this._sortTerms, this._expanders);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new RemoteFilter<TStore, TDto, TModel>(this._offset, this._limit, default(Expression<Func<TDto, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
        FluentActions.Invoking(() => new RemoteFilter<TStore, TDto, TModel>(this._offset, this._limit, default(Expression<Func<TDto, bool>>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
        FluentActions.Invoking(() => new RemoteFilter<TStore, TDto, TModel>(this._offset, this._limit, default(Expression<Func<TDto, bool>>), this._sortTerms, this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that instance construction throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpanders()
    {
        FluentActions.Invoking(() => new RemoteFilter<TStore, TDto, TModel>(this._offset, this._limit, this._predicate, default(Expression<Func<TDto, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new RemoteFilter<TStore, TDto, TModel>(this._offset, this._limit, this._predicate, this._sortTerms, default(Expression<Func<TDto, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that instance construction throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSortTerms()
    {
        FluentActions.Invoking(() => new RemoteFilter<TStore, TDto, TModel>(this._offset, this._limit, this._predicate, default(SortExpression<TDto>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }
}