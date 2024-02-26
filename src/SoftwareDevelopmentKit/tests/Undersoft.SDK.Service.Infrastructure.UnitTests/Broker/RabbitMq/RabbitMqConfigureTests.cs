using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Data.Event.Provider.RabbitMq;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="RabbitMqConfigure"/>.
/// </summary>
[TestClass]
public class RabbitMqConfigureTests
{
    private RabbitMqConfigure _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RabbitMqConfigure"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RabbitMqConfigure>();
    }

    /// <summary>
    /// Checks that the ConfigureServices method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigureServices()
    {
        // Arrange
        var configuration = _fixture.Create<ServiceConfiguration>();

        // Act
        this._testClass.ConfigureServices(configuration);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ConfigureServices method throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureServicesWithNullConfiguration()
    {
        FluentActions.Invoking(() => this._testClass.ConfigureServices(default(ServiceConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }
}