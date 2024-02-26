using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Hosting;

namespace Undersoft.SDK.Service.Server.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="ServerHostExtensions"/>.
/// </summary>
[TestClass]
public class ServerHostExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the UseServerSetup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseServerSetupWithIApplicationBuilder()
    {
        // Arrange
        var app = _fixture.Create<IApplicationBuilder>();

        // Act
        var result = app.UseServerSetup();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseServerSetup method throws when the app parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseServerSetupWithIApplicationBuilderWithNullApp()
    {
        FluentActions.Invoking(() => default(IApplicationBuilder).UseServerSetup()).Should().Throw<ArgumentNullException>().WithParameterName("app");
    }

    /// <summary>
    /// Checks that the UseServerSetup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseServerSetupWithAppAndEnv()
    {
        // Arrange
        var app = _fixture.Create<IApplicationBuilder>();
        var env = _fixture.Create<IWebHostEnvironment>();

        // Act
        var result = app.UseServerSetup(env);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseServerSetup method throws when the app parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseServerSetupWithAppAndEnvWithNullApp()
    {
        FluentActions.Invoking(() => default(IApplicationBuilder).UseServerSetup(_fixture.Create<IWebHostEnvironment>())).Should().Throw<ArgumentNullException>().WithParameterName("app");
    }

    /// <summary>
    /// Checks that the UseServerSetup method throws when the env parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseServerSetupWithAppAndEnvWithNullEnv()
    {
        FluentActions.Invoking(() => _fixture.Create<IApplicationBuilder>().UseServerSetup(default(IWebHostEnvironment))).Should().Throw<ArgumentNullException>().WithParameterName("env");
    }

    /// <summary>
    /// Checks that the UseDefaultProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseDefaultProvider()
    {
        // Arrange
        var app = _fixture.Create<IApplicationBuilder>();

        // Act
        var result = app.UseDefaultProvider();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseDefaultProvider method throws when the app parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseDefaultProviderWithNullApp()
    {
        FluentActions.Invoking(() => default(IApplicationBuilder).UseDefaultProvider()).Should().Throw<ArgumentNullException>().WithParameterName("app");
    }

    /// <summary>
    /// Checks that the UseInternalProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseInternalProvider()
    {
        // Arrange
        var app = _fixture.Create<IApplicationBuilder>();

        // Act
        var result = app.UseInternalProvider();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseInternalProvider method throws when the app parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseInternalProviderWithNullApp()
    {
        FluentActions.Invoking(() => default(IApplicationBuilder).UseInternalProvider()).Should().Throw<ArgumentNullException>().WithParameterName("app");
    }

    /// <summary>
    /// Checks that the RebuildProviders method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRebuildProviders()
    {
        // Arrange
        var app = _fixture.Create<IApplicationBuilder>();

        // Act
        var result = app.RebuildProviders();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RebuildProviders method throws when the app parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRebuildProvidersWithNullApp()
    {
        FluentActions.Invoking(() => default(IApplicationBuilder).RebuildProviders()).Should().Throw<ArgumentNullException>().WithParameterName("app");
    }

    /// <summary>
    /// Checks that the LoadOpenDataEdms method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallLoadOpenDataEdmsAsync()
    {
        // Arrange
        var app = _fixture.Create<ServerHostSetup>();

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
        await FluentActions.Invoking(() => default(ServerHostSetup).LoadOpenDataEdms()).Should().ThrowAsync<ArgumentNullException>().WithParameterName("app");
    }
}