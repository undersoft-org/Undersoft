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
/// Unit tests for the type <see cref="RemoteSetupInvoked"/>.
/// </summary>
public class RemoteSetupInvoked_3Tests
{
    private RemoteSetupInvoked<TStore, TService, TModel> _testClass;
    private IFixture _fixture;
    private RemoteSetup<TStore, TService, TModel> _command;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteSetupInvoked"/>.
    /// </summary>
    public RemoteSetupInvoked_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._command = _fixture.Create<RemoteSetup<TStore, TService, TModel>>();
        this._testClass = _fixture.Create<RemoteSetupInvoked<TStore, TService, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteSetupInvoked<TStore, TService, TModel>(this._command);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new RemoteSetupInvoked<TStore, TService, TModel>(default(RemoteSetup<TStore, TService, TModel>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }
}