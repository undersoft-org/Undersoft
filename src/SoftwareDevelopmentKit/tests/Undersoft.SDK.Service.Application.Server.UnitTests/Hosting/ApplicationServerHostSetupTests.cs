using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Application.Server.Hosting;

namespace Undersoft.SDK.Service.Application.Server.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="ApplicationServerHostSetup"/>.
/// </summary>
[TestClass]
public class ApplicationServerHostSetupTests
{
    private ApplicationServerHostSetup _testClass;
    private IFixture _fixture;
    private Mock<IApplicationBuilder> _application;
    private Mock<IWebHostEnvironment> _environment;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ApplicationServerHostSetup"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._application = _fixture.Freeze<Mock<IApplicationBuilder>>();
        this._environment = _fixture.Freeze<Mock<IWebHostEnvironment>>();
        this._testClass = _fixture.Create<ApplicationServerHostSetup>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ApplicationServerHostSetup(this._application.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ApplicationServerHostSetup(this._application.Object, this._environment.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the application parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullApplication()
    {
        FluentActions.Invoking(() => new ApplicationServerHostSetup(default(IApplicationBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("application");
        FluentActions.Invoking(() => new ApplicationServerHostSetup(default(IApplicationBuilder), this._environment.Object)).Should().Throw<ArgumentNullException>().WithParameterName("application");
    }

    /// <summary>
    /// Checks that instance construction throws when the environment parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEnvironment()
    {
        FluentActions.Invoking(() => new ApplicationServerHostSetup(this._application.Object, default(IWebHostEnvironment))).Should().Throw<ArgumentNullException>().WithParameterName("environment");
    }

    /// <summary>
    /// Checks that the UseServiceApplication method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseServiceApplication()
    {
        // Act
        var result = this._testClass.UseServiceApplication();

        // Assert
        Assert.Fail("Create or modify test");
    }
}