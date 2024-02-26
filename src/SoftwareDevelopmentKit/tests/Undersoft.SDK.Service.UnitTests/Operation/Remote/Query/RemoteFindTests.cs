using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Operation.Remote.Query;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TModel = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Query;

/// <summary>
/// Unit tests for the type <see cref="RemoteFind"/>.
/// </summary>
public class RemoteFind_3Tests
{
    private RemoteFind<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private object[] _keysUnknownType;
    private Expression<Func<TDto, object>>[] _expanders;
    private Expression<Func<TDto, bool>> _predicate;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteFind"/>.
    /// </summary>
    public RemoteFind_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._keysUnknownType = _fixture.Create<object[]>();
        this._expanders = _fixture.Create<Expression<Func<TDto, object>>[]>();
        this._predicate = _fixture.Create<Expression<Func<TDto, bool>>>();
        this._testClass = _fixture.Create<RemoteFind<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteFind<TStore, TDto, TModel>(this._keysUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteFind<TStore, TDto, TModel>(this._keysUnknownType, this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteFind<TStore, TDto, TModel>(this._predicate);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteFind<TStore, TDto, TModel>(this._predicate, this._expanders);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeys()
    {
        FluentActions.Invoking(() => new RemoteFind<TStore, TDto, TModel>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
        FluentActions.Invoking(() => new RemoteFind<TStore, TDto, TModel>(default(object[]), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that instance construction throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpanders()
    {
        FluentActions.Invoking(() => new RemoteFind<TStore, TDto, TModel>(this._keysUnknownType, default(Expression<Func<TDto, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new RemoteFind<TStore, TDto, TModel>(this._predicate, default(Expression<Func<TDto, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new RemoteFind<TStore, TDto, TModel>(default(Expression<Func<TDto, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
        FluentActions.Invoking(() => new RemoteFind<TStore, TDto, TModel>(default(Expression<Func<TDto, bool>>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }
}