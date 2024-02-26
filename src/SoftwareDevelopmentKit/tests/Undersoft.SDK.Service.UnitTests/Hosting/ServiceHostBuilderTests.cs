using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Hosting;
using TStartup = System.String;

namespace Undersoft.SDK.Service.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="ServiceHostBuilder"/>.
/// </summary>
public class ServiceHostBuilderTests
{
    private ServiceHostBuilder _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServiceHostBuilder"/>.
    /// </summary>
    public ServiceHostBuilderTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._testClass = _fixture.Create<ServiceHostBuilder>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ServiceHostBuilder();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ServiceHostBuilder(this._servicer.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new ServiceHostBuilder(default(IServicer))).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that the Build method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuild()
    {
        // Arrange
        var serviceClients = _fixture.Create<Type[]>();
        var args = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.Build<TStartup>(serviceClients, args);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Build method throws when the serviceClients parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBuildWithNullServiceClients()
    {
        FluentActions.Invoking(() => this._testClass.Build<TStartup>(default(Type[]), _fixture.Create<string[]>())).Should().Throw<ArgumentNullException>().WithParameterName("serviceClients");
    }

    /// <summary>
    /// Checks that the Build method throws when the args parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBuildWithNullArgs()
    {
        FluentActions.Invoking(() => this._testClass.Build<TStartup>(_fixture.Create<Type[]>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallRunAsync()
    {
        // Arrange
        var serviceClients = _fixture.Create<Type[]>();
        var args = _fixture.Create<string[]>();

        // Act
        await this._testClass.Run<TStartup>(serviceClients, args);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the serviceClients parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallRunWithNullServiceClientsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Run<TStartup>(default(Type[]), _fixture.Create<string[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("serviceClients");
    }

    /// <summary>
    /// Checks that the Run method throws when the args parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallRunWithNullArgsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Run<TStartup>(_fixture.Create<Type[]>(), default(string[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("args");
    }
}