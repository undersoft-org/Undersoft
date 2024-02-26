using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event;

namespace Undersoft.SDK.Service.UnitTests.Data.Event;

/// <summary>
/// Unit tests for the type <see cref="Event"/>.
/// </summary>
public class EventTests
{
    private Event _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Event"/>.
    /// </summary>
    public EventTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Event>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Event();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that setting the Version property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetVersion()
    {
        this._testClass.CheckProperty(x => x.Version, _fixture.Create<uint>(), _fixture.Create<uint>());
    }

    /// <summary>
    /// Checks that setting the EventType property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEventType()
    {
        this._testClass.CheckProperty(x => x.EventType);
    }

    /// <summary>
    /// Checks that setting the EntityId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEntityId()
    {
        this._testClass.CheckProperty(x => x.EntityId);
    }

    /// <summary>
    /// Checks that setting the EntityTypeName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEntityTypeName()
    {
        this._testClass.CheckProperty(x => x.EntityTypeName);
    }

    /// <summary>
    /// Checks that setting the Data property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetData()
    {
        this._testClass.CheckProperty(x => x.Data, _fixture.Create<byte[]>(), _fixture.Create<byte[]>());
    }

    /// <summary>
    /// Checks that setting the PublishTime property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPublishTime()
    {
        this._testClass.CheckProperty(x => x.PublishTime);
    }

    /// <summary>
    /// Checks that setting the PublishStatus property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPublishStatus()
    {
        this._testClass.CheckProperty(x => x.PublishStatus, _fixture.Create<EventPublishStatus>(), _fixture.Create<EventPublishStatus>());
    }
}