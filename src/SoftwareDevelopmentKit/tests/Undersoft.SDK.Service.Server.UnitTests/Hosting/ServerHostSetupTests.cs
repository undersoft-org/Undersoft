using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server.Hosting;

namespace Undersoft.SDK.Service.Server.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="ServerHostSetup"/>.
/// </summary>
[TestClass]
public class ServerHostSetupTests
{
    private class TestServerHostSetup : ServerHostSetup
    {
        public TestServerHostSetup(IApplicationBuilder application) : base(application)
        {
        }

        public TestServerHostSetup(IApplicationBuilder application, IWebHostEnvironment environment) : base(application, environment)
        {
        }

        public IApplicationBuilder PublicApplication => base.Application;

        public IWebHostEnvironment PublicLocalEnvironment => base.LocalEnvironment;
    }

    private TestServerHostSetup _testClass;
    private IFixture _fixture;
    private Mock<IApplicationBuilder> _application;
    private Mock<IWebHostEnvironment> _environment;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServerHostSetup"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._application = _fixture.Freeze<Mock<IApplicationBuilder>>();
        this._environment = _fixture.Freeze<Mock<IWebHostEnvironment>>();
        this._testClass = _fixture.Create<TestServerHostSetup>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestServerHostSetup(this._application.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestServerHostSetup(this._application.Object, this._environment.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the application parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullApplication()
    {
        FluentActions.Invoking(() => new TestServerHostSetup(default(IApplicationBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("application");
        FluentActions.Invoking(() => new TestServerHostSetup(default(IApplicationBuilder), this._environment.Object)).Should().Throw<ArgumentNullException>().WithParameterName("application");
    }

    /// <summary>
    /// Checks that instance construction throws when the environment parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEnvironment()
    {
        FluentActions.Invoking(() => new TestServerHostSetup(this._application.Object, default(IWebHostEnvironment))).Should().Throw<ArgumentNullException>().WithParameterName("environment");
    }

    /// <summary>
    /// Checks that the RebuildProviders method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRebuildProviders()
    {
        // Act
        var result = this._testClass.RebuildProviders();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseEndpoints method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseEndpoints()
    {
        // Arrange
        var useRazorPages = _fixture.Create<bool>();

        // Act
        var result = this._testClass.UseEndpoints(useRazorPages);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapFallbackToFile method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapFallbackToFile()
    {
        // Arrange
        var filePath = _fixture.Create<string>();

        // Act
        var result = this._testClass.MapFallbackToFile(filePath);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapFallbackToFile method throws when the filePath parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallMapFallbackToFileWithInvalidFilePath(string value)
    {
        FluentActions.Invoking(() => this._testClass.MapFallbackToFile(value)).Should().Throw<ArgumentNullException>().WithParameterName("filePath");
    }

    /// <summary>
    /// Checks that the UseServiceClients method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseServiceClients()
    {
        // Act
        var result = this._testClass.UseServiceClients();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseDataMigrations method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseDataMigrations()
    {
        // Act
        var result = this._testClass.UseDataMigrations();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseDefaultProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseDefaultProvider()
    {
        // Arrange
        _application.Setup(mock => mock.ApplicationServices).Returns(_fixture.Create<IServiceProvider>());

        // Act
        var result = this._testClass.UseDefaultProvider();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseInternalProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseInternalProvider()
    {
        // Act
        var result = this._testClass.UseInternalProvider();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseServiceServer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseServiceServer()
    {
        // Arrange
        var apiVersions = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.UseServiceServer(apiVersions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseCustomSetup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseCustomSetup()
    {
        // Arrange
        Action<IServerHostSetup> action = x => { };

        // Act
        var result = this._testClass.UseCustomSetup(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseCustomSetup method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseCustomSetupWithNullAction()
    {
        FluentActions.Invoking(() => this._testClass.UseCustomSetup(default(Action<IServerHostSetup>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the UseSwaggerSetup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseSwaggerSetup()
    {
        // Arrange
        var apiVersions = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.UseSwaggerSetup(apiVersions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseSwaggerSetup method throws when the apiVersions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseSwaggerSetupWithNullApiVersions()
    {
        FluentActions.Invoking(() => this._testClass.UseSwaggerSetup(default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("apiVersions");
    }

    /// <summary>
    /// Checks that the UseHeaderForwarding method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseHeaderForwarding()
    {
        // Act
        var result = this._testClass.UseHeaderForwarding();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseJwtMiddleware method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseJwtMiddleware()
    {
        // Act
        var result = this._testClass.UseJwtMiddleware();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Manager property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetManager()
    {
        // Assert
        this._testClass.Manager.Should().BeAssignableTo<IServiceManager>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicApplication property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicApplication()
    {
        // Assert
        this._testClass.PublicApplication.Should().BeAssignableTo<IApplicationBuilder>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicLocalEnvironment property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicLocalEnvironment()
    {
        // Assert
        this._testClass.PublicLocalEnvironment.Should().BeAssignableTo<IWebHostEnvironment>();

        Assert.Fail("Create or modify test");
    }
}