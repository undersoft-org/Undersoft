using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Application.Hosting;
using Undersoft.SDK.Service.Application.Server.Hosting;

namespace Undersoft.SDK.Service.Application.Server.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="ApplicationServerHost"/>.
/// </summary>
[TestClass]
public class ApplicationServerHostTests
{
    private ApplicationServerHost _testClass;
    private IFixture _fixture;
    private Action<IWebHostBuilder> _builder;
    private string[] _args;
    private Mock<IConfiguration> _configuration;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ApplicationServerHost"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._builder = x => { };
        this._args = _fixture.Create<string[]>();
        this._configuration = _fixture.Freeze<Mock<IConfiguration>>();
        this._testClass = _fixture.Create<ApplicationServerHost>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ApplicationServerHost(this._builder);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ApplicationServerHost(this._args);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ApplicationServerHost(this._configuration.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullBuilder()
    {
        FluentActions.Invoking(() => new ApplicationServerHost(default(Action<IWebHostBuilder>))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that instance construction throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfiguration()
    {
        FluentActions.Invoking(() => new ApplicationServerHost(default(IConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
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
    /// Checks that setting the ApplicationHosts property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetApplicationHosts()
    {
        this._testClass.CheckProperty(x => x.ApplicationHosts, _fixture.Create<Registry<ApplicationHost>>(), _fixture.Create<Registry<ApplicationHost>>());
    }

    /// <summary>
    /// Checks that the HostedApplications property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetHostedApplications()
    {
        // Assert
        this._testClass.HostedApplications.Should().BeAssignableTo<Registry<IServiceProvider>>();

        Assert.Fail("Create or modify test");
    }
}