using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Operation.Remote.Invocation.Notification;
using TCommand = Undersoft.SDK.Service.Operation.Remote.Invocation.RemoteAction;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Invocation.Notification;

/// <summary>
/// Unit tests for the type <see cref="RemoteInvokeNotification"/>.
/// </summary>
public class RemoteInvokeNotification_1Tests
{
    private class TestRemoteInvokeNotification : RemoteInvokeNotification<TCommand>
    {
        public TestRemoteInvokeNotification(TCommand command) : base(command)
        {
        }
    }

    private TestRemoteInvokeNotification _testClass;
    private IFixture _fixture;
    private TCommand _command;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteInvokeNotification"/>.
    /// </summary>
    public RemoteInvokeNotification_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._command = _fixture.Create<TCommand>();
        this._testClass = _fixture.Create<TestRemoteInvokeNotification>();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new TestRemoteInvokeNotification(default(TCommand))).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }
}