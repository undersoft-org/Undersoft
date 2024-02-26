using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event.Bus;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Bus;

/// <summary>
/// Unit tests for the type <see cref="EventMessage"/>.
/// </summary>
public class EventMessageTests
{
    private EventMessage _testClass;
    private IFixture _fixture;
    private object _eventData;
    private Type _eventType;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventMessage"/>.
    /// </summary>
    public EventMessageTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._eventData = _fixture.Create<object>();
        this._eventType = _fixture.Create<Type>();
        this._testClass = _fixture.Create<EventMessage>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EventMessage(this._eventData, this._eventType);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the eventData parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEventData()
    {
        FluentActions.Invoking(() => new EventMessage(default(object), this._eventType)).Should().Throw<ArgumentNullException>().WithParameterName("eventData");
    }

    /// <summary>
    /// Checks that instance construction throws when the eventType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEventType()
    {
        FluentActions.Invoking(() => new EventMessage(this._eventData, default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }
}