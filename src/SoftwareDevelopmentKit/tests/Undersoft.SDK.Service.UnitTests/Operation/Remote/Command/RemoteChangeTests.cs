using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Operation.Remote.Command;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TModel = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Command;

/// <summary>
/// Unit tests for the type <see cref="RemoteChange"/>.
/// </summary>
public class RemoteChange_3Tests
{
    private RemoteChange<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private EventPublishMode _publishMode;
    private TModel _input;
    private object[] _keys;
    private Func<TModel, Expression<Func<TDto, bool>>> _predicate;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteChange"/>.
    /// </summary>
    public RemoteChange_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._publishMode = _fixture.Create<EventPublishMode>();
        this._input = _fixture.Create<TModel>();
        this._keys = _fixture.Create<object[]>();
        this._predicate = x => _fixture.Create<Expression<Func<TDto, bool>>>();
        this._testClass = _fixture.Create<RemoteChange<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteChange<TStore, TDto, TModel>(this._publishMode, this._input, this._keys);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteChange<TStore, TDto, TModel>(this._publishMode, this._input, this._predicate);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInput()
    {
        FluentActions.Invoking(() => new RemoteChange<TStore, TDto, TModel>(this._publishMode, default(TModel), this._keys)).Should().Throw<ArgumentNullException>().WithParameterName("input");
        FluentActions.Invoking(() => new RemoteChange<TStore, TDto, TModel>(this._publishMode, default(TModel), this._predicate)).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that instance construction throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeys()
    {
        FluentActions.Invoking(() => new RemoteChange<TStore, TDto, TModel>(this._publishMode, this._input, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new RemoteChange<TStore, TDto, TModel>(this._publishMode, this._input, default(Func<TModel, Expression<Func<TDto, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }
}