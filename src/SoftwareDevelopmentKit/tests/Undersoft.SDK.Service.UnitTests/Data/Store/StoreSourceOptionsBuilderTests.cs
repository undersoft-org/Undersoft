using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Store;
using TContext = System.String;
using TSourceProvider = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Store;

/// <summary>
/// Unit tests for the type <see cref="StoreSourceOptionsBuilder"/>.
/// </summary>
public class StoreSourceOptionsBuilderTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the AddRootEntityFrameworkSourceProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRootEntityFrameworkSourceProvider()
    {
        // Arrange
        var provider = _fixture.Create<StoreProvider>();

        // Act
        StoreSourceOptionsBuilder.AddRootEntityFrameworkSourceProvider<TSourceProvider>(provider);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddEntityFrameworkSourceProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddEntityFrameworkSourceProviderWithStoreProvider()
    {
        // Arrange
        var provider = _fixture.Create<StoreProvider>();

        // Act
        var result = StoreSourceOptionsBuilder.AddEntityFrameworkSourceProvider(provider);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddEntityFrameworkSourceProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddEntityFrameworkSourceProviderWithRegistryAndProvider()
    {
        // Arrange
        var registry = _fixture.Create<IServiceRegistry>();
        var provider = _fixture.Create<StoreProvider>();

        // Act
        var result = registry.AddEntityFrameworkSourceProvider(provider);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddEntityFrameworkSourceProvider method throws when the registry parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddEntityFrameworkSourceProviderWithRegistryAndProviderWithNullRegistry()
    {
        FluentActions.Invoking(() => default(IServiceRegistry).AddEntityFrameworkSourceProvider(_fixture.Create<StoreProvider>())).Should().Throw<ArgumentNullException>().WithParameterName("registry");
    }

    /// <summary>
    /// Checks that the BuildOptions method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuildOptionsWithTContextAndStoreProviderAndString()
    {
        // Arrange
        var provider = _fixture.Create<StoreProvider>();
        var connectionString = _fixture.Create<string>();

        // Act
        var result = StoreSourceOptionsBuilder.BuildOptions<TContext>(provider, connectionString);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BuildOptions method throws when the connectionString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBuildOptionsWithTContextAndStoreProviderAndStringWithInvalidConnectionString(string value)
    {
        FluentActions.Invoking(() => StoreSourceOptionsBuilder.BuildOptions<TContext>(_fixture.Create<StoreProvider>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionString");
    }

    /// <summary>
    /// Checks that the BuildOptions method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuildOptionsWithStoreProviderAndString()
    {
        // Arrange
        var provider = _fixture.Create<StoreProvider>();
        var connectionString = _fixture.Create<string>();

        // Act
        var result = StoreSourceOptionsBuilder.BuildOptions(provider, connectionString);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BuildOptions method throws when the connectionString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBuildOptionsWithStoreProviderAndStringWithInvalidConnectionString(string value)
    {
        FluentActions.Invoking(() => StoreSourceOptionsBuilder.BuildOptions(_fixture.Create<StoreProvider>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionString");
    }
}