using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Application.Server;

namespace Undersoft.SDK.Service.Application.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ApplicationServerSetup"/>.
/// </summary>
[TestClass]
public partial class ApplicationServerSetupTests
{
    private ApplicationServerSetup _testClass;
    private IFixture _fixture;
    private Mock<IServiceCollection> _services;
    private Mock<IMvcBuilder> _mvcBuilder;
    private Mock<IConfiguration> _configuration;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ApplicationServerSetup"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._services = _fixture.Freeze<Mock<IServiceCollection>>();
        this._mvcBuilder = _fixture.Freeze<Mock<IMvcBuilder>>();
        this._configuration = _fixture.Freeze<Mock<IConfiguration>>();
        this._testClass = _fixture.Create<ApplicationServerSetup>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ApplicationServerSetup(this._services.Object, this._mvcBuilder.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ApplicationServerSetup(this._services.Object, this._configuration.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServices()
    {
        FluentActions.Invoking(() => new ApplicationServerSetup(default(IServiceCollection), this._mvcBuilder.Object)).Should().Throw<ArgumentNullException>().WithParameterName("services");
        FluentActions.Invoking(() => new ApplicationServerSetup(default(IServiceCollection), this._configuration.Object)).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that instance construction throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfiguration()
    {
        FluentActions.Invoking(() => new ApplicationServerSetup(this._services.Object, default(IConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }

    /// <summary>
    /// Checks that the ConfigureApplicationServer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigureApplicationServer()
    {
        // Arrange
        var includeSwagger = _fixture.Create<bool>();
        var sourceTypes = _fixture.Create<Type[]>();
        var clientTypes = _fixture.Create<Type[]>();

        // Act
        var result = this._testClass.ConfigureApplicationServer(includeSwagger, sourceTypes, clientTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }
}