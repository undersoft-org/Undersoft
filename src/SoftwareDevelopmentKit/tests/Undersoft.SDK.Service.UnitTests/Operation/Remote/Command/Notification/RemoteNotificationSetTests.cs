using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Operation.Remote.Command.Notification;
using TCommand = Undersoft.SDK.Service.Operation.Remote.Command.RemoteCommand;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Command.Notification;

/// <summary>
/// Unit tests for the type <see cref="RemoteNotificationSet"/>.
/// </summary>
public class RemoteNotificationSet_1Tests
{
    private class TestRemoteNotificationSet : RemoteNotificationSet<TCommand>
    {
        public TestRemoteNotificationSet(EventPublishMode publishPattern, RemoteNotification<TCommand>[] commands) : base(publishPattern, commands)
        {
        }
    }

    private TestRemoteNotificationSet _testClass;
    private IFixture _fixture;
    private EventPublishMode _publishPattern;
    private RemoteNotification<TCommand>[] _commands;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteNotificationSet"/>.
    /// </summary>
    public RemoteNotificationSet_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._publishPattern = _fixture.Create<EventPublishMode>();
        this._commands = _fixture.Create<RemoteNotification<TCommand>[]>();
        this._testClass = _fixture.Create<TestRemoteNotificationSet>();
    }

    /// <summary>
    /// Checks that instance construction throws when the commands parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommands()
    {
        FluentActions.Invoking(() => new TestRemoteNotificationSet(this._publishPattern, default(RemoteNotification<TCommand>[]))).Should().Throw<ArgumentNullException>().WithParameterName("commands");
    }

    /// <summary>
    /// Checks that setting the PublishMode property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPublishMode()
    {
        this._testClass.CheckProperty(x => x.PublishMode, _fixture.Create<EventPublishMode>(), _fixture.Create<EventPublishMode>());
    }
}