using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Operation.Invocation.Notification;
using TCommand = Undersoft.SDK.Service.Operation.Remote.Invocation.RemoteAction;

namespace Undersoft.SDK.Service.UnitTests.Operation.Invocation.Notification;

/// <summary>
/// Unit tests for the type <see cref="InvokeNotification"/>.
/// </summary>
public class InvokeNotification_1Tests
{
    private class TestInvokeNotification : InvokeNotification<TCommand>
    {
        public TestInvokeNotification(TCommand command) : base(command)
        {
        }
    }

    private TestInvokeNotification _testClass;
    private IFixture _fixture;
    private TCommand _command;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InvokeNotification"/>.
    /// </summary>
    public InvokeNotification_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._command = _fixture.Create<TCommand>();
        this._testClass = _fixture.Create<TestInvokeNotification>();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new TestInvokeNotification(default(TCommand))).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }
}