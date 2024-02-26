using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;

namespace Undersoft.SDK.Service.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ServiceSetup"/>.
/// </summary>
public partial class ServiceSetupTests
{
    private ServiceSetup _testClass;
    private IFixture _fixture;
    private Mock<IServiceCollection> _services;
    private Mock<IConfiguration> _configuration;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServiceSetup"/>.
    /// </summary>
    public ServiceSetupTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._services = _fixture.Freeze<Mock<IServiceCollection>>();
        this._configuration = _fixture.Freeze<Mock<IConfiguration>>();
        this._testClass = _fixture.Create<ServiceSetup>();
    }

    /// <summary>
    /// Checks that the AddDomainImplementations method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddDomainImplementations()
    {
        // Act
        var result = this._testClass.AddDomainImplementations();

        // Assert
        Assert.Fail("Create or modify test");
    }
}