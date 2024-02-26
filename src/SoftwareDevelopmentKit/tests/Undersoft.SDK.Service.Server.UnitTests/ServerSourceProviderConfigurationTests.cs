using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Server;

namespace Undersoft.SDK.Service.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ServerSourceProviderConfiguration"/>.
/// </summary>
[TestClass]
public class ServerSourceProviderConfigurationTests
{
    private ServerSourceProviderConfiguration _testClass;
    private IFixture _fixture;
    private Mock<IServiceRegistry> _registry;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServerSourceProviderConfiguration"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._registry = _fixture.Freeze<Mock<IServiceRegistry>>();
        this._testClass = _fixture.Create<ServerSourceProviderConfiguration>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ServerSourceProviderConfiguration(this._registry.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the registry parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRegistry()
    {
        FluentActions.Invoking(() => new ServerSourceProviderConfiguration(default(IServiceRegistry))).Should().Throw<ArgumentNullException>().WithParameterName("registry");
    }

    /// <summary>
    /// Checks that the AddSourceProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddSourceProvider()
    {
        // Arrange
        var provider = _fixture.Create<StoreProvider>();

        // Act
        var result = this._testClass.AddSourceProvider(provider);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BuildOptions method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuildOptions()
    {
        // Arrange
        var builder = _fixture.Create<DbContextOptionsBuilder>();
        var provider = _fixture.Create<StoreProvider>();
        var connectionString = _fixture.Create<string>();

        // Act
        var result = this._testClass.BuildOptions(builder, provider, connectionString);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BuildOptions method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBuildOptionsWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.BuildOptions(default(DbContextOptionsBuilder), _fixture.Create<StoreProvider>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the BuildOptions method throws when the connectionString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBuildOptionsWithInvalidConnectionString(string value)
    {
        FluentActions.Invoking(() => this._testClass.BuildOptions(_fixture.Create<DbContextOptionsBuilder>(), _fixture.Create<StoreProvider>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionString");
    }
}