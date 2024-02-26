using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Operation.Command.Notification;
using TCommand = Undersoft.SDK.Service.Operation.Command.Delete;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command.Notification;

/// <summary>
/// Unit tests for the type <see cref="Notification"/>.
/// </summary>
public class Notification_1Tests
{
    private class TestNotification : Notification<TCommand>
    {
        public TestNotification() : base()
        {
        }

        public TestNotification(TCommand command) : base(command)
        {
        }
    }

    private TestNotification _testClass;
    private IFixture _fixture;
    private TCommand _command;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Notification"/>.
    /// </summary>
    public Notification_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._command = _fixture.Create<TCommand>();
        this._testClass = _fixture.Create<TestNotification>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestNotification();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestNotification(this._command);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new TestNotification(default(TCommand))).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }

    /// <summary>
    /// Checks that the GetEvent method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEvent()
    {
        // Act
        var result = this._testClass.GetEvent();

        // Assert
        Assert.Fail("Create or modify test");
    }
}