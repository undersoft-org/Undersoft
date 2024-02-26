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
/// Unit tests for the type <see cref="RemoteChangedSet"/>.
/// </summary>
public class RemoteChangedSet_3Tests
{
    private RemoteChangedSet<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private RemoteChangeSet<TStore, TDto, TModel> _commands;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteChangedSet"/>.
    /// </summary>
    public RemoteChangedSet_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._commands = _fixture.Create<RemoteChangeSet<TStore, TDto, TModel>>();
        this._testClass = _fixture.Create<RemoteChangedSet<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteChangedSet<TStore, TDto, TModel>(this._commands);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the commands parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommands()
    {
        FluentActions.Invoking(() => new RemoteChangedSet<TStore, TDto, TModel>(default(RemoteChangeSet<TStore, TDto, TModel>))).Should().Throw<ArgumentNullException>().WithParameterName("commands");
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