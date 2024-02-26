using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Operation.Command.Notification;
using Undersoft.SDK.Service.Operation.Invocation;
using TDto = Undersoft.SDK.Origin;
using TStore = System.String;
using TType = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command.Notification;

/// <summary>
/// Unit tests for the type <see cref="Invoked"/>.
/// </summary>
public class Invoked_3Tests
{
    private Invoked<TStore, TType, TDto> _testClass;
    private IFixture _fixture;
    private Action<TStore, TType, TDto> _command;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Invoked"/>.
    /// </summary>
    public Invoked_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._command = _fixture.Create<Action<TStore, TType, TDto>>();
        this._testClass = _fixture.Create<Invoked<TStore, TType, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Invoked<TStore, TType, TDto>(this._command);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new Invoked<TStore, TType, TDto>(default(Action<TStore, TType, TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }
}