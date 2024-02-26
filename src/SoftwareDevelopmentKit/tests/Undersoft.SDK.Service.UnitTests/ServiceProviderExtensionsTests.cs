using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service;

namespace Undersoft.SDK.Service.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ServiceProviderExtensions"/>.
/// </summary>
public class ServiceProviderExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the AddPropertyInjection method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddPropertyInjection()
    {
        // Arrange
        var provider = _fixture.Create<IServiceProvider>();

        // Act
        var result = provider.AddPropertyInjection();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddPropertyInjection method throws when the provider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddPropertyInjectionWithNullProvider()
    {
        FluentActions.Invoking(() => default(IServiceProvider).AddPropertyInjection()).Should().Throw<ArgumentNullException>().WithParameterName("provider");
    }

    /// <summary>
    /// Checks that the LoadDataServiceModelsAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallLoadDataServiceModelsAsync()
    {
        // Arrange
        var provider = _fixture.Create<IServiceProvider>();

        // Act
        await provider.LoadDataServiceModelsAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadDataServiceModelsAsync method throws when the provider parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallLoadDataServiceModelsAsyncWithNullProviderAsync()
    {
        await FluentActions.Invoking(() => default(IServiceProvider).LoadDataServiceModelsAsync()).Should().ThrowAsync<ArgumentNullException>().WithParameterName("provider");
    }

    /// <summary>
    /// Checks that the LoadDataServiceModels method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLoadDataServiceModels()
    {
        // Arrange
        var provider = _fixture.Create<IServiceProvider>();

        // Act
        provider.LoadDataServiceModels();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LoadDataServiceModels method throws when the provider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLoadDataServiceModelsWithNullProvider()
    {
        FluentActions.Invoking(() => default(IServiceProvider).LoadDataServiceModels()).Should().Throw<ArgumentNullException>().WithParameterName("provider");
    }

    /// <summary>
    /// Checks that the UseServiceClientsAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallUseServiceClientsAsync()
    {
        // Arrange
        var provider = _fixture.Create<IServiceProvider>();

        // Act
        var result = await provider.UseServiceClientsAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseServiceClientsAsync method throws when the provider parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallUseServiceClientsAsyncWithNullProviderAsync()
    {
        await FluentActions.Invoking(() => default(IServiceProvider).UseServiceClientsAsync()).Should().ThrowAsync<ArgumentNullException>().WithParameterName("provider");
    }

    /// <summary>
    /// Checks that the UseServiceClients method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseServiceClients()
    {
        // Arrange
        var provider = _fixture.Create<IServiceProvider>();

        // Act
        var result = provider.UseServiceClients();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UseServiceClients method throws when the provider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseServiceClientsWithNullProvider()
    {
        FluentActions.Invoking(() => default(IServiceProvider).UseServiceClients()).Should().Throw<ArgumentNullException>().WithParameterName("provider");
    }
}

/// <summary>
/// Unit tests for the type <see cref="InjectPropertyAttribute"/>.
/// </summary>
public class InjectPropertyAttributeTests
{
    private InjectPropertyAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InjectPropertyAttribute"/>.
    /// </summary>
    public InjectPropertyAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<InjectPropertyAttribute>();
    }
}