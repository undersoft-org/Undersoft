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
/// Unit tests for the type <see cref="AccessInvoked"/>.
/// </summary>
public class AccessInvoked_3Tests
{
    private AccessInvoked<TStore, TType, TDto> _testClass;
    private IFixture _fixture;
    private Access<TStore, TType, TDto> _command;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccessInvoked"/>.
    /// </summary>
    public AccessInvoked_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._command = _fixture.Create<Access<TStore, TType, TDto>>();
        this._testClass = _fixture.Create<AccessInvoked<TStore, TType, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccessInvoked<TStore, TType, TDto>(this._command);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new AccessInvoked<TStore, TType, TDto>(default(Access<TStore, TType, TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }
}