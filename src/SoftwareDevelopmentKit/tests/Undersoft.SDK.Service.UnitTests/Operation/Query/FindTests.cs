using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Operation.Query;
using TDto = System.String;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Query;

/// <summary>
/// Unit tests for the type <see cref="Find"/>.
/// </summary>
public class Find_3Tests
{
    private Find<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private object[] _keysUnknownType;
    private Expression<Func<TEntity, object>>[] _expanders;
    private Expression<Func<TEntity, bool>> _predicate;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Find"/>.
    /// </summary>
    public Find_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._keysUnknownType = _fixture.Create<object[]>();
        this._expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();
        this._predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._testClass = _fixture.Create<Find<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Find<TStore, TEntity, TDto>(this._keysUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Find<TStore, TEntity, TDto>(this._keysUnknownType, this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Find<TStore, TEntity, TDto>(this._predicate);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Find<TStore, TEntity, TDto>(this._predicate, this._expanders);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeys()
    {
        FluentActions.Invoking(() => new Find<TStore, TEntity, TDto>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
        FluentActions.Invoking(() => new Find<TStore, TEntity, TDto>(default(object[]), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that instance construction throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpanders()
    {
        FluentActions.Invoking(() => new Find<TStore, TEntity, TDto>(this._keysUnknownType, default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new Find<TStore, TEntity, TDto>(this._predicate, default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new Find<TStore, TEntity, TDto>(default(Expression<Func<TEntity, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
        FluentActions.Invoking(() => new Find<TStore, TEntity, TDto>(default(Expression<Func<TEntity, bool>>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }
}