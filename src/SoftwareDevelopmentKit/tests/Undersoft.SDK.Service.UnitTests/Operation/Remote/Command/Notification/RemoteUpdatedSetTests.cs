using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Operation.Remote.Command;
using Undersoft.SDK.Service.Operation.Remote.Command.Notification;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TModel = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Command.Notification;

/// <summary>
/// Unit tests for the type <see cref="RemoteUpdatedSet"/>.
/// </summary>
public class RemoteUpdatedSet_3Tests
{
    private RemoteUpdatedSet<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private RemoteUpdateSet<TStore, TDto, TModel> _commands;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteUpdatedSet"/>.
    /// </summary>
    public RemoteUpdatedSet_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._commands = _fixture.Create<RemoteUpdateSet<TStore, TDto, TModel>>();
        this._testClass = _fixture.Create<RemoteUpdatedSet<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteUpdatedSet<TStore, TDto, TModel>(this._commands);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the commands parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommands()
    {
        FluentActions.Invoking(() => new RemoteUpdatedSet<TStore, TDto, TModel>(default(RemoteUpdateSet<TStore, TDto, TModel>))).Should().Throw<ArgumentNullException>().WithParameterName("commands");
    }

    /// <summary>
    /// Checks that the Conditions property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetConditions()
    {
        // Assert
        this._testClass.Conditions.Should().BeAssignableTo<Func<TModel, Expression<Func<TDto, bool>>>[]>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Predicate property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPredicate()
    {
        // Assert
        this._testClass.Predicate.Should().BeAssignableTo<Func<TModel, Expression<Func<TDto, bool>>>>();

        Assert.Fail("Create or modify test");
    }
}