using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Data.Event.Bus;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Bus;

/// <summary>
/// Unit tests for the type <see cref="EventBusModule"/>.
/// </summary>
public class EventBusModuleTests
{
    private EventBusModule _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventBusModule"/>.
    /// </summary>
    public EventBusModuleTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<EventBusModule>();
    }

    /// <summary>
    /// Checks that the PreConfigureServices method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPreConfigureServices()
    {
        // Arrange
        var context = _fixture.Create<ServiceConfigurationContext>();

        // Act
        this._testClass.PreConfigureServices(context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PreConfigureServices method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPreConfigureServicesWithNullContext()
    {
        FluentActions.Invoking(() => this._testClass.PreConfigureServices(default(ServiceConfigurationContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }
}