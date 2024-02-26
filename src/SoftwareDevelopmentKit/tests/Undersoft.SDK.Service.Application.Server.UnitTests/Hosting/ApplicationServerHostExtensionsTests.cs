using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Application.Server.Hosting;

namespace Undersoft.SDK.Service.Application.Server.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="ApplicationServerHostExtensions"/>.
/// </summary>
[TestClass]
public class ApplicationServerHostExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the UseApplicationServerSetup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseApplicationServerSetupWithIApplicationBuilder()
    {
        // Arrange
        var app = _fixture.Create<IApplicationBuilder>();

        // Act
        var result = app.UseApplicationServerSetup();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseApplicationServerSetup method throws when the app parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseApplicationServerSetupWithIApplicationBuilderWithNullApp()
    {
        FluentActions.Invoking(() => default(IApplicationBuilder).UseApplicationServerSetup()).Should().Throw<ArgumentNullException>().WithParameterName("app");
    }

    /// <summary>
    /// Checks that the UseApplicationServerSetup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseApplicationServerSetupWithAppAndEnv()
    {
        // Arrange
        var app = _fixture.Create<IApplicationBuilder>();
        var env = _fixture.Create<IWebHostEnvironment>();

        // Act
        var result = app.UseApplicationServerSetup(env);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseApplicationServerSetup method throws when the app parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseApplicationServerSetupWithAppAndEnvWithNullApp()
    {
        FluentActions.Invoking(() => default(IApplicationBuilder).UseApplicationServerSetup(_fixture.Create<IWebHostEnvironment>())).Should().Throw<ArgumentNullException>().WithParameterName("app");
    }

    /// <summary>
    /// Checks that the UseApplicationServerSetup method throws when the env parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseApplicationServerSetupWithAppAndEnvWithNullEnv()
    {
        FluentActions.Invoking(() => _fixture.Create<IApplicationBuilder>().UseApplicationServerSetup(default(IWebHostEnvironment))).Should().Throw<ArgumentNullException>().WithParameterName("env");
    }

    /// <summary>
    /// Checks that the UseApplicationTracking method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseApplicationTracking()
    {
        // Arrange
        var app = _fixture.Create<IApplicationBuilder>();

        // Act
        var result = app.UseApplicationTracking();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseApplicationTracking method throws when the app parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseApplicationTrackingWithNullApp()
    {
        FluentActions.Invoking(() => default(IApplicationBuilder).UseApplicationTracking()).Should().Throw<ArgumentNullException>().WithParameterName("app");
    }
}