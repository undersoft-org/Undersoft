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
/// Unit tests for the type <see cref="Change"/>.
/// </summary>
public class Change_3Tests
{
    private Change<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private EventPublishMode _publishMode;
    private TDto _input;
    private object[] _keys;
    private Func<TDto, Expression<Func<TEntity, bool>>> _predicate;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Change"/>.
    /// </summary>
    public Change_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._publishMode = _fixture.Create<EventPublishMode>();
        this._input = _fixture.Create<TDto>();
        this._keys = _fixture.Create<object[]>();
        this._predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._testClass = _fixture.Create<Change<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Change<TStore, TEntity, TDto>(this._publishMode, this._input, this._keys);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Change<TStore, TEntity, TDto>(this._publishMode, this._input, this._predicate);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInput()
    {
        FluentActions.Invoking(() => new Change<TStore, TEntity, TDto>(this._publishMode, default(TDto), this._keys)).Should().Throw<ArgumentNullException>().WithParameterName("input");
        FluentActions.Invoking(() => new Change<TStore, TEntity, TDto>(this._publishMode, default(TDto), this._predicate)).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that instance construction throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeys()
    {
        FluentActions.Invoking(() => new Change<TStore, TEntity, TDto>(this._publishMode, this._input, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new Change<TStore, TEntity, TDto>(this._publishMode, this._input, default(Func<TDto, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }
}