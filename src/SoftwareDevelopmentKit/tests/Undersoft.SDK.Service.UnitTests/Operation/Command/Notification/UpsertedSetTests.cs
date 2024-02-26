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
/// Unit tests for the type <see cref="UpsertedSet"/>.
/// </summary>
public class UpsertedSet_3Tests
{
    private UpsertedSet<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private UpsertSet<TStore, TEntity, TDto> _commands;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="UpsertedSet"/>.
    /// </summary>
    public UpsertedSet_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._commands = _fixture.Create<UpsertSet<TStore, TEntity, TDto>>();
        this._testClass = _fixture.Create<UpsertedSet<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new UpsertedSet<TStore, TEntity, TDto>(this._commands);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the commands parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommands()
    {
        FluentActions.Invoking(() => new UpsertedSet<TStore, TEntity, TDto>(default(UpsertSet<TStore, TEntity, TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("commands");
    }

    /// <summary>
    /// Checks that the Predicate property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPredicate()
    {
        // Assert
        this._testClass.Predicate.Should().BeAssignableTo<Func<TEntity, Expression<Func<TEntity, bool>>>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Conditions property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetConditions()
    {
        // Assert
        this._testClass.Conditions.Should().BeAssignableTo<Func<TEntity, Expression<Func<TEntity, bool>>>[]>();

        Assert.Fail("Create or modify test");
    }
}