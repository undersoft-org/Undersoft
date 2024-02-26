using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Operation.Command.Notification;
using TCommand = Undersoft.SDK.Service.Operation.Command.Delete;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command.Notification;

/// <summary>
/// Unit tests for the type <see cref="NotificationSet"/>.
/// </summary>
public class NotificationSet_1Tests
{
    private class TestNotificationSet : NotificationSet<TCommand>
    {
        public TestNotificationSet() : base()
        {
        }

        public TestNotificationSet(EventPublishMode publishPattern, Notification<TCommand>[] commands) : base(publishPattern, commands)
        {
        }
    }

    private TestNotificationSet _testClass;
    private IFixture _fixture;
    private EventPublishMode _publishPattern;
    private Notification<TCommand>[] _commands;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="NotificationSet"/>.
    /// </summary>
    public NotificationSet_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._publishPattern = _fixture.Create<EventPublishMode>();
        this._commands = _fixture.Create<Notification<TCommand>[]>();
        this._testClass = _fixture.Create<TestNotificationSet>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestNotificationSet();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestNotificationSet(this._publishPattern, this._commands);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the commands parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommands()
    {
        FluentActions.Invoking(() => new TestNotificationSet(this._publishPattern, default(Notification<TCommand>[]))).Should().Throw<ArgumentNullException>().WithParameterName("commands");
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