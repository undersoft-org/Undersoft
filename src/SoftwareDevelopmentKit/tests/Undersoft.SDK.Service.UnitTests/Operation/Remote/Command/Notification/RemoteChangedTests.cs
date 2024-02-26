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
/// Unit tests for the type <see cref="RemoteChanged"/>.
/// </summary>
public class RemoteChanged_3Tests
{
    private RemoteChanged<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private RemoteCommand<TModel> _commandRemoteCommandTModel;
    private RemoteChange<TStore, TDto, TModel> _commandRemoteChangeTStoreTDtoTModel;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteChanged"/>.
    /// </summary>
    public RemoteChanged_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._commandRemoteCommandTModel = _fixture.Create<RemoteCommand<TModel>>();
        this._commandRemoteChangeTStoreTDtoTModel = _fixture.Create<RemoteChange<TStore, TDto, TModel>>();
        this._testClass = _fixture.Create<RemoteChanged<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteChanged<TStore, TDto, TModel>(this._commandRemoteCommandTModel);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteChanged<TStore, TDto, TModel>(this._commandRemoteChangeTStoreTDtoTModel);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new RemoteChanged<TStore, TDto, TModel>(default(RemoteCommand<TModel>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
        FluentActions.Invoking(() => new RemoteChanged<TStore, TDto, TModel>(default(RemoteChange<TStore, TDto, TModel>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
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