using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event.Handler;
using TEvent = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Handler;

/// <summary>
/// Unit tests for the type <see cref="ActionEventHandler"/>.
/// </summary>
public class ActionEventHandler_1Tests
{
    private ActionEventHandler<TEvent> _testClass;
    private IFixture _fixture;
    private Func<TEvent, Task> _handler;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ActionEventHandler"/>.
    /// </summary>
    public ActionEventHandler_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._handler = x => _fixture.Create<Task>();
        this._testClass = _fixture.Create<ActionEventHandler<TEvent>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ActionEventHandler<TEvent>(this._handler);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the handler parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullHandler()
    {
        FluentActions.Invoking(() => new ActionEventHandler<TEvent>(default(Func<TEvent, Task>))).Should().Throw<ArgumentNullException>().WithParameterName("handler");
    }

    /// <summary>
    /// Checks that the HandleEventAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHandleEventAsync()
    {
        // Arrange
        var eventData = _fixture.Create<TEvent>();

        // Act
        await this._testClass.HandleEventAsync(eventData);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Action property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetAction()
    {
        // Assert
        this._testClass.Action.Should().BeAssignableTo<Func<TEvent, Task>>();

        Assert.Fail("Create or modify test");
    }
}