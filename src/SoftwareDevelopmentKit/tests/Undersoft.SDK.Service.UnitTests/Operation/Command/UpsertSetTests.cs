using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Operation.Command;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command;

/// <summary>
/// Unit tests for the type <see cref="UpsertSet"/>.
/// </summary>
public class UpsertSet_3Tests
{
    private UpsertSet<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private EventPublishMode _publishPattern;
    private TDto _input;
    private object _key;
    private TDto[] _inputs;
    private Func<TEntity, Expression<Func<TEntity, bool>>> _predicate;
    private Func<TEntity, Expression<Func<TEntity, bool>>>[] _conditions;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="UpsertSet"/>.
    /// </summary>
    public UpsertSet_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._publishPattern = _fixture.Create<EventPublishMode>();
        this._input = _fixture.Create<TDto>();
        this._key = _fixture.Create<object>();
        this._inputs = _fixture.Create<TDto[]>();
        this._predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._conditions = _fixture.Create<Func<TEntity, Expression<Func<TEntity, bool>>>[]>();
        this._testClass = _fixture.Create<UpsertSet<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new UpsertSet<TStore, TEntity, TDto>(this._publishPattern, this._input, this._key);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new UpsertSet<TStore, TEntity, TDto>(this._publishPattern, this._inputs, this._predicate);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new UpsertSet<TStore, TEntity, TDto>(this._publishPattern, this._inputs, this._predicate, this._conditions);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInput()
    {
        FluentActions.Invoking(() => new UpsertSet<TStore, TEntity, TDto>(this._publishPattern, default(TDto), this._key)).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that instance construction throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKey()
    {
        FluentActions.Invoking(() => new UpsertSet<TStore, TEntity, TDto>(this._publishPattern, this._input, default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that instance construction throws when the inputs parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInputs()
    {
        FluentActions.Invoking(() => new UpsertSet<TStore, TEntity, TDto>(this._publishPattern, default(TDto[]), this._predicate)).Should().Throw<ArgumentNullException>().WithParameterName("inputs");
        FluentActions.Invoking(() => new UpsertSet<TStore, TEntity, TDto>(this._publishPattern, default(TDto[]), this._predicate, this._conditions)).Should().Throw<ArgumentNullException>().WithParameterName("inputs");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new UpsertSet<TStore, TEntity, TDto>(this._publishPattern, this._inputs, default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
        FluentActions.Invoking(() => new UpsertSet<TStore, TEntity, TDto>(this._publishPattern, this._inputs, default(Func<TEntity, Expression<Func<TEntity, bool>>>), this._conditions)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that instance construction throws when the conditions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConditions()
    {
        FluentActions.Invoking(() => new UpsertSet<TStore, TEntity, TDto>(this._publishPattern, this._inputs, this._predicate, default(Func<TEntity, Expression<Func<TEntity, bool>>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("conditions");
    }
}