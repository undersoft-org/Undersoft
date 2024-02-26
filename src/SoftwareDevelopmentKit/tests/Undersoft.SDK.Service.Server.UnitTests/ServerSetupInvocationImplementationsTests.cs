using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Server;

namespace Undersoft.SDK.Service.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ServerSetup"/>.
/// </summary>
[TestClass]
public partial class ServerSetupTests
{
    private ServerSetup _testClass;
    private IFixture _fixture;
    private Mock<IServiceCollection> _services;
    private Mock<IMvcBuilder> _mvcBuilder;
    private Mock<IConfiguration> _configuration;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServerSetup"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._services = _fixture.Freeze<Mock<IServiceCollection>>();
        this._mvcBuilder = _fixture.Freeze<Mock<IMvcBuilder>>();
        this._configuration = _fixture.Freeze<Mock<IConfiguration>>();
        this._testClass = _fixture.Create<ServerSetup>();
    }

    /// <summary>
    /// Checks that the AddServerSetupInvocationImplementations method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddServerSetupInvocationImplementations()
    {
        // Act
        var result = this._testClass.AddServerSetupInvocationImplementations();

        // Assert
        Assert.Fail("Create or modify test");
    }
}