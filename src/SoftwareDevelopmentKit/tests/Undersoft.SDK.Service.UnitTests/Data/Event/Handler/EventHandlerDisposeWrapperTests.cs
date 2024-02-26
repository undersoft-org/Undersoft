using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Event.Handler;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Handler;

/// <summary>
/// Unit tests for the type <see cref="EventHandlerDisposeWrapper"/>.
/// </summary>
public class EventHandlerDisposeWrapperTests
{
    private EventHandlerDisposeWrapper _testClass;
    private IFixture _fixture;
    private Mock<IEventHandler> _eventHandler;
    private Action _disposeAction;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventHandlerDisposeWrapper"/>.
    /// </summary>
    public EventHandlerDisposeWrapperTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._eventHandler = _fixture.Freeze<Mock<IEventHandler>>();
        this._disposeAction = () => { };
        this._testClass = _fixture.Create<EventHandlerDisposeWrapper>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EventHandlerDisposeWrapper(this._eventHandler.Object, this._disposeAction);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the eventHandler parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEventHandler()
    {
        FluentActions.Invoking(() => new EventHandlerDisposeWrapper(default(IEventHandler), this._disposeAction)).Should().Throw<ArgumentNullException>().WithParameterName("eventHandler");
    }

    /// <summary>
    /// Checks that the Dispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDispose()
    {
        // Act
        this._testClass.Dispose();

        // Assert
        Assert.Fail("Create or modify test");
    }
}