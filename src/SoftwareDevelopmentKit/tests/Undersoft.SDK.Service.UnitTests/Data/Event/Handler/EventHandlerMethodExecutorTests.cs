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
/// Unit tests for the type <see cref="EventHandlerMethodExecutor"/>.
/// </summary>
public class EventHandlerMethodExecutor_1Tests
{
    private EventHandlerMethodExecutor<TEvent> _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventHandlerMethodExecutor"/>.
    /// </summary>
    public EventHandlerMethodExecutor_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<EventHandlerMethodExecutor<TEvent>>();
    }

    /// <summary>
    /// Checks that the ExecuteAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExecuteAsync()
    {
        // Arrange
        var target = _fixture.Create<IEventHandler>();
        var parameters = _fixture.Create<TEvent>();

        // Act
        await this._testClass.ExecuteAsync(target, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExecuteAsync method throws when the target parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExecuteAsyncWithNullTargetAsync()
    {
        await FluentActions.Invoking(() => this._testClass.ExecuteAsync(default(IEventHandler), _fixture.Create<TEvent>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the ExecuteAsync method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExecuteAsyncWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.ExecuteAsync(_fixture.Create<IEventHandler>(), default(TEvent))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the ExecutorAsync property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetExecutorAsync()
    {
        // Assert
        this._testClass.ExecutorAsync.Should().BeAssignableTo<EventHandlerMethodExecutorAsync>();

        Assert.Fail("Create or modify test");
    }
}