using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Operation.Remote.Command.Notification;
using TCommand = Undersoft.SDK.Service.Operation.Remote.Command.RemoteCommand;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Command.Notification;

/// <summary>
/// Unit tests for the type <see cref="RemoteNotification"/>.
/// </summary>
public class RemoteNotification_1Tests
{
    private class TestRemoteNotification : RemoteNotification<TCommand>
    {
        public TestRemoteNotification(TCommand command) : base(command)
        {
        }
    }

    private TestRemoteNotification _testClass;
    private IFixture _fixture;
    private TCommand _command;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteNotification"/>.
    /// </summary>
    public RemoteNotification_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._command = _fixture.Create<TCommand>();
        this._testClass = _fixture.Create<TestRemoteNotification>();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new TestRemoteNotification(default(TCommand))).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }
}