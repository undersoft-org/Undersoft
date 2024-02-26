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
/// Unit tests for the type <see cref="DeleteSetAsync"/>.
/// </summary>
public class DeleteSetAsync_3Tests
{
    private DeleteSetAsync<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private EventPublishMode _publishPattern;
    private object _key;
    private TDto _input;
    private TDto[] _inputs;
    private Func<TDto, Expression<Func<TEntity, bool>>> _predicate;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DeleteSetAsync"/>.
    /// </summary>
    public DeleteSetAsync_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._publishPattern = _fixture.Create<EventPublishMode>();
        this._key = _fixture.Create<object>();
        this._input = _fixture.Create<TDto>();
        this._inputs = _fixture.Create<TDto[]>();
        this._predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._testClass = _fixture.Create<DeleteSetAsync<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DeleteSetAsync<TStore, TEntity, TDto>(this._publishPattern, this._key);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new DeleteSetAsync<TStore, TEntity, TDto>(this._publishPattern, this._input, this._key);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new DeleteSetAsync<TStore, TEntity, TDto>(this._publishPattern, this._inputs);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new DeleteSetAsync<TStore, TEntity, TDto>(this._publishPattern, this._inputs, this._predicate);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKey()
    {
        FluentActions.Invoking(() => new DeleteSetAsync<TStore, TEntity, TDto>(this._publishPattern, default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
        FluentActions.Invoking(() => new DeleteSetAsync<TStore, TEntity, TDto>(this._publishPattern, this._input, default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that instance construction throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInput()
    {
        FluentActions.Invoking(() => new DeleteSetAsync<TStore, TEntity, TDto>(this._publishPattern, default(TDto), this._key)).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that instance construction throws when the inputs parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInputs()
    {
        FluentActions.Invoking(() => new DeleteSetAsync<TStore, TEntity, TDto>(this._publishPattern, default(TDto[]))).Should().Throw<ArgumentNullException>().WithParameterName("inputs");
        FluentActions.Invoking(() => new DeleteSetAsync<TStore, TEntity, TDto>(this._publishPattern, default(TDto[]), this._predicate)).Should().Throw<ArgumentNullException>().WithParameterName("inputs");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new DeleteSetAsync<TStore, TEntity, TDto>(this._publishPattern, this._inputs, default(Func<TDto, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }
}