using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Data.Client;
using Undersoft.SDK.Service.Data.Repository.Client;
using TContext = Undersoft.SDK.Service.Data.Client.OpenDataContext;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository.Client;

/// <summary>
/// Unit tests for the type <see cref="RepositoryClient"/>.
/// </summary>
public class RepositoryClient_1Tests
{
    private RepositoryClient<TContext> _testClass;
    private IFixture _fixture;
    private Mock<IServiceConfiguration> _config;
    private ClientProvider _provider;
    private string _connectionString;
    private Uri _serviceRoot;
    private Mock<IRepositoryClient> _client;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RepositoryClient"/>.
    /// </summary>
    public RepositoryClient_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._config = _fixture.Freeze<Mock<IServiceConfiguration>>();
        this._provider = _fixture.Create<ClientProvider>();
        this._connectionString = _fixture.Create<string>();
        this._serviceRoot = _fixture.Create<Uri>();
        this._client = _fixture.Freeze<Mock<IRepositoryClient>>();
        this._testClass = _fixture.Create<RepositoryClient<TContext>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RepositoryClient<TContext>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RepositoryClient<TContext>(this._config.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RepositoryClient<TContext>(this._provider, this._connectionString);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RepositoryClient<TContext>(this._serviceRoot);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RepositoryClient<TContext>(this._client.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the config parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfig()
    {
        FluentActions.Invoking(() => new RepositoryClient<TContext>(default(IServiceConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("config");
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceRoot parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceRoot()
    {
        FluentActions.Invoking(() => new RepositoryClient<TContext>(default(Uri))).Should().Throw<ArgumentNullException>().WithParameterName("serviceRoot");
    }

    /// <summary>
    /// Checks that instance construction throws when the client parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullClient()
    {
        FluentActions.Invoking(() => new RepositoryClient<TContext>(default(IRepositoryClient))).Should().Throw<ArgumentNullException>().WithParameterName("client");
    }

    /// <summary>
    /// Checks that the constructor throws when the connectionString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidConnectionString(string value)
    {
        FluentActions.Invoking(() => new RepositoryClient<TContext>(this._provider, value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionString");
    }

    /// <summary>
    /// Checks that the CreateContext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateContextWithNoParameters()
    {
        // Act
        var result = this._testClass.CreateContext();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateContext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateContextWithServiceRoot()
    {
        // Arrange
        var serviceRoot = _fixture.Create<Uri>();

        // Act
        var result = this._testClass.CreateContext(serviceRoot);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateContext method throws when the serviceRoot parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateContextWithServiceRootWithNullServiceRoot()
    {
        FluentActions.Invoking(() => this._testClass.CreateContext(default(Uri))).Should().Throw<ArgumentNullException>().WithParameterName("serviceRoot");
    }

    /// <summary>
    /// Checks that the Context property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetContext()
    {
        // Assert
        this._testClass.Context.Should().BeAssignableTo<TContext>();

        Assert.Fail("Create or modify test");
    }
}