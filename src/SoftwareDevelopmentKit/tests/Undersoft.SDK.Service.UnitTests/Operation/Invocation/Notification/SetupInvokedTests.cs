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
/// Unit tests for the type <see cref="SetupInvoked"/>.
/// </summary>
public class SetupInvoked_3Tests
{
    private SetupInvoked<TStore, TType, TDto> _testClass;
    private IFixture _fixture;
    private Setup<TStore, TType, TDto> _command;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SetupInvoked"/>.
    /// </summary>
    public SetupInvoked_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._command = _fixture.Create<Setup<TStore, TType, TDto>>();
        this._testClass = _fixture.Create<SetupInvoked<TStore, TType, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SetupInvoked<TStore, TType, TDto>(this._command);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new SetupInvoked<TStore, TType, TDto>(default(Setup<TStore, TType, TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }
}