using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event.Bus;
using Undersoft.SDK.Service.Data.Event.Handler;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Bus;

/// <summary>
/// Unit tests for the type <see cref="EventBusOptions"/>.
/// </summary>
public class EventBusOptionsTests
{
    private EventBusOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventBusOptions"/>.
    /// </summary>
    public EventBusOptionsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<EventBusOptions>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EventBusOptions();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Handlers property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetHandlers()
    {
        // Assert
        this._testClass.Handlers.Should().BeAssignableTo<IList<IEventHandler>>();

        Assert.Fail("Create or modify test");
    }
}