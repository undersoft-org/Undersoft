using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Application.Server;

namespace Undersoft.SDK.Service.Application.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ServerSetupExtensions"/>.
/// </summary>
[TestClass]
public class ServerSetupExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the AddApplicationServerSetup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddApplicationServerSetup()
    {
        // Arrange
        var services = _fixture.Create<IServiceCollection>();
        var mvcBuilder = _fixture.Create<IMvcBuilder>();

        // Act
        var result = services.AddApplicationServerSetup(mvcBuilder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddApplicationServerSetup method throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddApplicationServerSetupWithNullServices()
    {
        FluentActions.Invoking(() => default(IServiceCollection).AddApplicationServerSetup(_fixture.Create<IMvcBuilder>())).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }
}