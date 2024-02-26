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
/// Unit tests for the type <see cref="RemoteDeleted"/>.
/// </summary>
public class RemoteDeleted_3Tests
{
    private RemoteDeleted<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private RemoteDelete<TStore, TDto, TModel> _command;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteDeleted"/>.
    /// </summary>
    public RemoteDeleted_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._command = _fixture.Create<RemoteDelete<TStore, TDto, TModel>>();
        this._testClass = _fixture.Create<RemoteDeleted<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteDeleted<TStore, TDto, TModel>(this._command);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new RemoteDeleted<TStore, TDto, TModel>(default(RemoteDelete<TStore, TDto, TModel>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
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