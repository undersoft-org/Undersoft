using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Schedule;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="SchedulerService"/>.
/// </summary>
[TestClass]
public class SchedulerServiceTests
{
    private SchedulerService _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SchedulerService"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<SchedulerService>();
    }

    /// <summary>
    /// Checks that the ConfigureServices method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigureServices()
    {
        // Arrange
        var context = _fixture.Create<ServiceConfigurationContext>();

        // Act
        this._testClass.ConfigureServices(context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ConfigureServices method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureServicesWithNullContext()
    {
        FluentActions.Invoking(() => this._testClass.ConfigureServices(default(ServiceConfigurationContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the OnApplicationInitializationAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallOnApplicationInitializationAsync()
    {
        // Arrange
        var context = _fixture.Create<IServiceRegistry>();

        // Act
        await this._testClass.OnApplicationInitializationAsync(context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the OnApplicationInitializationAsync method throws when the context parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallOnApplicationInitializationAsyncWithNullContextAsync()
    {
        await FluentActions.Invoking(() => this._testClass.OnApplicationInitializationAsync(default(IServiceRegistry))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the OnApplicationShutdownAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallOnApplicationShutdownAsync()
    {
        // Arrange
        var context = _fixture.Create<IServiceRegistry>();

        // Act
        await this._testClass.OnApplicationShutdownAsync(context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the OnApplicationShutdownAsync method throws when the context parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallOnApplicationShutdownAsyncWithNullContextAsync()
    {
        await FluentActions.Invoking(() => this._testClass.OnApplicationShutdownAsync(default(IServiceRegistry))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the OnApplicationInitialization method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOnApplicationInitialization()
    {
        // Arrange
        var context = _fixture.Create<IServiceRegistry>();

        // Act
        this._testClass.OnApplicationInitialization(context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the OnApplicationInitialization method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnApplicationInitializationWithNullContext()
    {
        FluentActions.Invoking(() => this._testClass.OnApplicationInitialization(default(IServiceRegistry))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the OnApplicationShutdown method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOnApplicationShutdown()
    {
        // Arrange
        var context = _fixture.Create<IServiceRegistry>();

        // Act
        this._testClass.OnApplicationShutdown(context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the OnApplicationShutdown method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOnApplicationShutdownWithNullContext()
    {
        FluentActions.Invoking(() => this._testClass.OnApplicationShutdown(default(IServiceRegistry))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }
}