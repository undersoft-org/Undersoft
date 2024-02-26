using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Operation.Command;
using Undersoft.SDK.Service.Operation.Command.Notification;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command.Notification;

/// <summary>
/// Unit tests for the type <see cref="DeletedSet"/>.
/// </summary>
public class DeletedSet_3Tests
{
    private DeletedSet<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private DeleteSet<TStore, TEntity, TDto> _commands;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DeletedSet"/>.
    /// </summary>
    public DeletedSet_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._commands = _fixture.Create<DeleteSet<TStore, TEntity, TDto>>();
        this._testClass = _fixture.Create<DeletedSet<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DeletedSet<TStore, TEntity, TDto>(this._commands);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the commands parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommands()
    {
        FluentActions.Invoking(() => new DeletedSet<TStore, TEntity, TDto>(default(DeleteSet<TStore, TEntity, TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("commands");
    }

    /// <summary>
    /// Checks that the Predicate property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPredicate()
    {
        // Assert
        this._testClass.Predicate.Should().BeAssignableTo<Func<TDto, Expression<Func<TEntity, bool>>>>();

        Assert.Fail("Create or modify test");
    }
}