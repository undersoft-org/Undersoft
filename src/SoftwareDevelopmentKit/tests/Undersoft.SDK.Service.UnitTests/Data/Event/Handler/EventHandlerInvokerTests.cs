using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event.Handler;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Handler;

/// <summary>
/// Unit tests for the type <see cref="EventHandlerInvoker"/>.
/// </summary>
public class EventHandlerInvokerTests
{
    private EventHandlerInvoker _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventHandlerInvoker"/>.
    /// </summary>
    public EventHandlerInvokerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<EventHandlerInvoker>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EventHandlerInvoker();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsync()
    {
        // Arrange
        var eventHandler = _fixture.Create<IEventHandler>();
        var eventData = _fixture.Create<object>();
        var eventType = _fixture.Create<Type>();

        // Act
        await this._testClass.InvokeAsync(eventHandler, eventData, eventType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the eventHandler parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithNullEventHandlerAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(default(IEventHandler), _fixture.Create<object>(), _fixture.Create<Type>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventHandler");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the eventData parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithNullEventDataAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(_fixture.Create<IEventHandler>(), default(object), _fixture.Create<Type>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventData");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the eventType parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithNullEventTypeAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(_fixture.Create<IEventHandler>(), _fixture.Create<object>(), default(Type))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("eventType");
    }
}