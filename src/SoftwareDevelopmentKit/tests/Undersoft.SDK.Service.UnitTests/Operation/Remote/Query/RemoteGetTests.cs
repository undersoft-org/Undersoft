using System;
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
/// Unit tests for the type <see cref="RemoteGet"/>.
/// </summary>
public class RemoteGet_3Tests
{
    private RemoteGet<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private int _offset;
    private int _limit;
    private Expression<Func<TDto, object>>[] _expanders;
    private SortExpression<TDto> _sortTerms;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteGet"/>.
    /// </summary>
    public RemoteGet_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._offset = _fixture.Create<int>();
        this._limit = _fixture.Create<int>();
        this._expanders = _fixture.Create<Expression<Func<TDto, object>>[]>();
        this._sortTerms = _fixture.Create<SortExpression<TDto>>();
        this._testClass = _fixture.Create<RemoteGet<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteGet<TStore, TDto, TModel>(this._offset, this._limit, this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteGet<TStore, TDto, TModel>(this._offset, this._limit, this._sortTerms, this._expanders);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpanders()
    {
        FluentActions.Invoking(() => new RemoteGet<TStore, TDto, TModel>(this._offset, this._limit, default(Expression<Func<TDto, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new RemoteGet<TStore, TDto, TModel>(this._offset, this._limit, this._sortTerms, default(Expression<Func<TDto, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that instance construction throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSortTerms()
    {
        FluentActions.Invoking(() => new RemoteGet<TStore, TDto, TModel>(this._offset, this._limit, default(SortExpression<TDto>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }
}