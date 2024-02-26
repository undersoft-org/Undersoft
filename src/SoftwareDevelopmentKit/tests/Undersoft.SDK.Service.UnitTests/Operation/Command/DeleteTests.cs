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
/// Unit tests for the type <see cref="Delete"/>.
/// </summary>
public class Delete_3Tests
{
    private Delete<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private EventPublishMode _publishPattern;
    private TDto _input;
    private Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
    private object[] _keys;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Delete"/>.
    /// </summary>
    public Delete_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._publishPattern = _fixture.Create<EventPublishMode>();
        this._input = _fixture.Create<TDto>();
        this._predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._keys = _fixture.Create<object[]>();
        this._testClass = _fixture.Create<Delete<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Delete<TStore, TEntity, TDto>(this._publishPattern, this._input);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Delete<TStore, TEntity, TDto>(this._publishPattern, this._input, this._predicate);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Delete<TStore, TEntity, TDto>(this._publishPattern, this._predicate);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Delete<TStore, TEntity, TDto>(this._publishPattern, this._keys);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInput()
    {
        FluentActions.Invoking(() => new Delete<TStore, TEntity, TDto>(this._publishPattern, default(TDto))).Should().Throw<ArgumentNullException>().WithParameterName("input");
        FluentActions.Invoking(() => new Delete<TStore, TEntity, TDto>(this._publishPattern, default(TDto), this._predicate)).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new Delete<TStore, TEntity, TDto>(this._publishPattern, this._input, default(Func<TDto, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
        FluentActions.Invoking(() => new Delete<TStore, TEntity, TDto>(this._publishPattern, default(Func<TDto, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that instance construction throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeys()
    {
        FluentActions.Invoking(() => new Delete<TStore, TEntity, TDto>(this._publishPattern, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }
}