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
/// Unit tests for the type <see cref="RemoteUpsert"/>.
/// </summary>
public class RemoteUpsert_3Tests
{
    private RemoteUpsert<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private EventPublishMode _publishPattern;
    private TModel _input;
    private Func<TDto, Expression<Func<TDto, bool>>> _predicate;
    private Func<TDto, Expression<Func<TDto, bool>>>[] _conditions;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteUpsert"/>.
    /// </summary>
    public RemoteUpsert_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._publishPattern = _fixture.Create<EventPublishMode>();
        this._input = _fixture.Create<TModel>();
        this._predicate = x => _fixture.Create<Expression<Func<TDto, bool>>>();
        this._conditions = _fixture.Create<Func<TDto, Expression<Func<TDto, bool>>>[]>();
        this._testClass = _fixture.Create<RemoteUpsert<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteUpsert<TStore, TDto, TModel>(this._publishPattern, this._input, this._predicate);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteUpsert<TStore, TDto, TModel>(this._publishPattern, this._input, this._predicate, this._conditions);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInput()
    {
        FluentActions.Invoking(() => new RemoteUpsert<TStore, TDto, TModel>(this._publishPattern, default(TModel), this._predicate)).Should().Throw<ArgumentNullException>().WithParameterName("input");
        FluentActions.Invoking(() => new RemoteUpsert<TStore, TDto, TModel>(this._publishPattern, default(TModel), this._predicate, this._conditions)).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new RemoteUpsert<TStore, TDto, TModel>(this._publishPattern, this._input, default(Func<TDto, Expression<Func<TDto, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
        FluentActions.Invoking(() => new RemoteUpsert<TStore, TDto, TModel>(this._publishPattern, this._input, default(Func<TDto, Expression<Func<TDto, bool>>>), this._conditions)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that instance construction throws when the conditions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConditions()
    {
        FluentActions.Invoking(() => new RemoteUpsert<TStore, TDto, TModel>(this._publishPattern, this._input, this._predicate, default(Func<TDto, Expression<Func<TDto, bool>>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("conditions");
    }
}