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
/// Unit tests for the type <see cref="CreateSet"/>.
/// </summary>
public class CreateSet_3Tests
{
    private CreateSet<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private EventPublishMode _publishPattern;
    private TDto _input;
    private object _key;
    private TDto[] _inputs;
    private Func<TEntity, Expression<Func<TEntity, bool>>> _predicate;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="CreateSet"/>.
    /// </summary>
    public CreateSet_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._publishPattern = _fixture.Create<EventPublishMode>();
        this._input = _fixture.Create<TDto>();
        this._key = _fixture.Create<object>();
        this._inputs = _fixture.Create<TDto[]>();
        this._predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._testClass = _fixture.Create<CreateSet<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new CreateSet<TStore, TEntity, TDto>(this._publishPattern, this._input, this._key);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new CreateSet<TStore, TEntity, TDto>(this._publishPattern, this._inputs);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new CreateSet<TStore, TEntity, TDto>(this._publishPattern, this._inputs, this._predicate);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInput()
    {
        FluentActions.Invoking(() => new CreateSet<TStore, TEntity, TDto>(this._publishPattern, default(TDto), this._key)).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that instance construction throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKey()
    {
        FluentActions.Invoking(() => new CreateSet<TStore, TEntity, TDto>(this._publishPattern, this._input, default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that instance construction throws when the inputs parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInputs()
    {
        FluentActions.Invoking(() => new CreateSet<TStore, TEntity, TDto>(this._publishPattern, default(TDto[]))).Should().Throw<ArgumentNullException>().WithParameterName("inputs");
        FluentActions.Invoking(() => new CreateSet<TStore, TEntity, TDto>(this._publishPattern, default(TDto[]), this._predicate)).Should().Throw<ArgumentNullException>().WithParameterName("inputs");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new CreateSet<TStore, TEntity, TDto>(this._publishPattern, this._inputs, default(Func<TEntity, Expression<Func<TEntity, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }
}