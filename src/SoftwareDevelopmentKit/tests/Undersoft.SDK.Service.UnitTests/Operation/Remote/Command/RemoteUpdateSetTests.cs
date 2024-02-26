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
/// Unit tests for the type <see cref="RemoteUpdateSet"/>.
/// </summary>
public class RemoteUpdateSet_3Tests
{
    private RemoteUpdateSet<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private EventPublishMode _publishPattern;
    private TModel _input;
    private object _key;
    private TModel[] _inputs;
    private Func<TModel, Expression<Func<TDto, bool>>> _predicate;
    private Func<TModel, Expression<Func<TDto, bool>>>[] _conditions;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteUpdateSet"/>.
    /// </summary>
    public RemoteUpdateSet_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._publishPattern = _fixture.Create<EventPublishMode>();
        this._input = _fixture.Create<TModel>();
        this._key = _fixture.Create<object>();
        this._inputs = _fixture.Create<TModel[]>();
        this._predicate = x => _fixture.Create<Expression<Func<TDto, bool>>>();
        this._conditions = _fixture.Create<Func<TModel, Expression<Func<TDto, bool>>>[]>();
        this._testClass = _fixture.Create<RemoteUpdateSet<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteUpdateSet<TStore, TDto, TModel>(this._publishPattern, this._input, this._key);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteUpdateSet<TStore, TDto, TModel>(this._publishPattern, this._inputs);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteUpdateSet<TStore, TDto, TModel>(this._publishPattern, this._inputs, this._predicate);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteUpdateSet<TStore, TDto, TModel>(this._publishPattern, this._inputs, this._predicate, this._conditions);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInput()
    {
        FluentActions.Invoking(() => new RemoteUpdateSet<TStore, TDto, TModel>(this._publishPattern, default(TModel), this._key)).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that instance construction throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKey()
    {
        FluentActions.Invoking(() => new RemoteUpdateSet<TStore, TDto, TModel>(this._publishPattern, this._input, default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that instance construction throws when the inputs parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInputs()
    {
        FluentActions.Invoking(() => new RemoteUpdateSet<TStore, TDto, TModel>(this._publishPattern, default(TModel[]))).Should().Throw<ArgumentNullException>().WithParameterName("inputs");
        FluentActions.Invoking(() => new RemoteUpdateSet<TStore, TDto, TModel>(this._publishPattern, default(TModel[]), this._predicate)).Should().Throw<ArgumentNullException>().WithParameterName("inputs");
        FluentActions.Invoking(() => new RemoteUpdateSet<TStore, TDto, TModel>(this._publishPattern, default(TModel[]), this._predicate, this._conditions)).Should().Throw<ArgumentNullException>().WithParameterName("inputs");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new RemoteUpdateSet<TStore, TDto, TModel>(this._publishPattern, this._inputs, default(Func<TModel, Expression<Func<TDto, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
        FluentActions.Invoking(() => new RemoteUpdateSet<TStore, TDto, TModel>(this._publishPattern, this._inputs, default(Func<TModel, Expression<Func<TDto, bool>>>), this._conditions)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that instance construction throws when the conditions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConditions()
    {
        FluentActions.Invoking(() => new RemoteUpdateSet<TStore, TDto, TModel>(this._publishPattern, this._inputs, this._predicate, default(Func<TModel, Expression<Func<TDto, bool>>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("conditions");
    }
}