using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Operation.Invocation;
using Undersoft.SDK.Service.Operation.Invocation.Notification;
using TDto = Undersoft.SDK.Origin;
using TStore = System.String;
using TType = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Invocation.Notification;

/// <summary>
/// Unit tests for the type <see cref="ActionInvoked"/>.
/// </summary>
public class ActionInvoked_3Tests
{
    private ActionInvoked<TStore, TType, TDto> _testClass;
    private IFixture _fixture;
    private Action<TStore, TType, TDto> _command;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ActionInvoked"/>.
    /// </summary>
    public ActionInvoked_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._command = _fixture.Create<Action<TStore, TType, TDto>>();
        this._testClass = _fixture.Create<ActionInvoked<TStore, TType, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ActionInvoked<TStore, TType, TDto>(this._command);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new ActionInvoked<TStore, TType, TDto>(default(Action<TStore, TType, TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }
}