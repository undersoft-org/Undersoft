using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Hosting;

namespace Undersoft.SDK.Service.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="ServiceHostSetupExtensions"/>.
/// </summary>
public class ServiceHostSetupExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the UseAppSetup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseAppSetup()
    {
        // Arrange
        var app = _fixture.Create<IHostBuilder>();
        var sm = _fixture.Create<IServiceManager>();
        var env = _fixture.Create<IHostEnvironment>();

        // Act
        var result = app.UseAppSetup(sm, env);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseAppSetup method throws when the app parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseAppSetupWithNullApp()
    {
        FluentActions.Invoking(() => default(IHostBuilder).UseAppSetup(_fixture.Create<IServiceManager>(), _fixture.Create<IHostEnvironment>())).Should().Throw<ArgumentNullException>().WithParameterName("app");
    }

    /// <summary>
    /// Checks that the UseAppSetup method throws when the sm parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseAppSetupWithNullSm()
    {
        FluentActions.Invoking(() => _fixture.Create<IHostBuilder>().UseAppSetup(default(IServiceManager), _fixture.Create<IHostEnvironment>())).Should().Throw<ArgumentNullException>().WithParameterName("sm");
    }

    /// <summary>
    /// Checks that the UseAppSetup method throws when the env parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseAppSetupWithNullEnv()
    {
        FluentActions.Invoking(() => _fixture.Create<IHostBuilder>().UseAppSetup(_fixture.Create<IServiceManager>(), default(IHostEnvironment))).Should().Throw<ArgumentNullException>().WithParameterName("env");
    }

    /// <summary>
    /// Checks that the UseInternalProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseInternalProvider()
    {
        // Arrange
        var app = _fixture.Create<IHostBuilder>();
        var sm = _fixture.Create<IServiceManager>();

        // Act
        var result = app.UseInternalProvider(sm);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseInternalProvider method throws when the app parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseInternalProviderWithNullApp()
    {
        FluentActions.Invoking(() => default(IHostBuilder).UseInternalProvider(_fixture.Create<IServiceManager>())).Should().Throw<ArgumentNullException>().WithParameterName("app");
    }

    /// <summary>
    /// Checks that the UseInternalProvider method throws when the sm parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseInternalProviderWithNullSm()
    {
        FluentActions.Invoking(() => _fixture.Create<IHostBuilder>().UseInternalProvider(default(IServiceManager))).Should().Throw<ArgumentNullException>().WithParameterName("sm");
    }

    /// <summary>
    /// Checks that the RebuildProviders method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRebuildProviders()
    {
        // Arrange
        var app = _fixture.Create<IHostBuilder>();
        var sm = _fixture.Create<IServiceManager>();

        // Act
        var result = app.RebuildProviders(sm);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RebuildProviders method throws when the app parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRebuildProvidersWithNullApp()
    {
        FluentActions.Invoking(() => default(IHostBuilder).RebuildProviders(_fixture.Create<IServiceManager>())).Should().Throw<ArgumentNullException>().WithParameterName("app");
    }

    /// <summary>
    /// Checks that the RebuildProviders method throws when the sm parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRebuildProvidersWithNullSm()
    {
        FluentActions.Invoking(() => _fixture.Create<IHostBuilder>().RebuildProviders(default(IServiceManager))).Should().Throw<ArgumentNullException>().WithParameterName("sm");
    }

    /// <summary>
    /// Checks that the LoadOpenDataEdms method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallLoadOpenDataEdmsAsync()
    {
        // Arrange
        var app = _fixture.Create<IServiceHostSetup>();

        // Act
        await app.LoadOpenDataEdms();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadOpenDataEdms method throws when the app parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallLoadOpenDataEdmsWithNullAppAsync()
    {
        await FluentActions.Invoking(() => default(IServiceHostSetup).LoadOpenDataEdms()).Should().ThrowAsync<ArgumentNullException>().WithParameterName("app");
    }
}