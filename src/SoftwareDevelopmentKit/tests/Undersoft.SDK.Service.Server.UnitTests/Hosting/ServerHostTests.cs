using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Hosting;
using Undersoft.SDK.Service.Server.Hosting;

namespace Undersoft.SDK.Service.Server.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="ServerHost"/>.
/// </summary>
[TestClass]
public class ServerHostTests
{
    private ServerHost _testClass;
    private IFixture _fixture;
    private Action<IWebHostBuilder> _builder;
    private string[] _args;
    private Mock<IConfiguration> _configuration;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServerHost"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._builder = x => { };
        this._args = _fixture.Create<string[]>();
        this._configuration = _fixture.Freeze<Mock<IConfiguration>>();
        this._testClass = _fixture.Create<ServerHost>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ServerHost(this._builder);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ServerHost(this._args);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ServerHost(this._configuration.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullBuilder()
    {
        FluentActions.Invoking(() => new ServerHost(default(Action<IWebHostBuilder>))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that instance construction throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfiguration()
    {
        FluentActions.Invoking(() => new ServerHost(default(IConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Arrange
        Action<IWebHostBuilder> builder = x => { };

        // Act
        var result = this._testClass.Configure(builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.Configure(default(Action<IWebHostBuilder>))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRun()
    {
        // Act
        this._testClass.Run();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the ServiceHosts property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetServiceHosts()
    {
        this._testClass.CheckProperty(x => x.ServiceHosts, _fixture.Create<Registry<ServiceHost>>(), _fixture.Create<Registry<ServiceHost>>());
    }

    /// <summary>
    /// Checks that the HostedServices property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetHostedServices()
    {
        // Assert
        this._testClass.HostedServices.Should().BeAssignableTo<Registry<IServiceProvider>>();

        Assert.Fail("Create or modify test");
    }
}