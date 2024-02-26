using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Operation.Remote.Invocation;
using Undersoft.SDK.Service.Operation.Remote.Invocation.Notification;
using TModel = Undersoft.SDK.Origin;
using TService = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Invocation.Notification;

/// <summary>
/// Unit tests for the type <see cref="RemoteActionInvoked"/>.
/// </summary>
public class RemoteActionInvoked_3Tests
{
    private RemoteActionInvoked<TStore, TService, TModel> _testClass;
    private IFixture _fixture;
    private RemoteAction<TStore, TService, TModel> _command;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteActionInvoked"/>.
    /// </summary>
    public RemoteActionInvoked_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._command = _fixture.Create<RemoteAction<TStore, TService, TModel>>();
        this._testClass = _fixture.Create<RemoteActionInvoked<TStore, TService, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteActionInvoked<TStore, TService, TModel>(this._command);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new RemoteActionInvoked<TStore, TService, TModel>(default(RemoteAction<TStore, TService, TModel>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }
}