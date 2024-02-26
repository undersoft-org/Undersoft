using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server;

namespace Undersoft.SDK.Service.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ServerSetupExtensions"/>.
/// </summary>
[TestClass]
public class ServerSetupExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the AddServerSetup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddServerSetup()
    {
        // Arrange
        var services = _fixture.Create<IServiceCollection>();
        var mvcBuilder = _fixture.Create<IMvcBuilder>();

        // Act
        var result = services.AddServerSetup(mvcBuilder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddServerSetup method throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddServerSetupWithNullServices()
    {
        FluentActions.Invoking(() => default(IServiceCollection).AddServerSetup(_fixture.Create<IMvcBuilder>())).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that the LoadOpenDataEdms method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallLoadOpenDataEdmsAsync()
    {
        // Arrange
        var app = _fixture.Create<ServerSetup>();

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
        await FluentActions.Invoking(() => default(ServerSetup).LoadOpenDataEdms()).Should().ThrowAsync<ArgumentNullException>().WithParameterName("app");
    }
}