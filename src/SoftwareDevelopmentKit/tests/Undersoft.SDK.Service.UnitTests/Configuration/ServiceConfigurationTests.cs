using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Data.Repository;
using TOptions = System.String;

namespace Undersoft.SDK.Service.UnitTests.Configuration;

/// <summary>
/// Unit tests for the type <see cref="ServiceConfiguration"/>.
/// </summary>
public class ServiceConfigurationTests
{
    private ServiceConfiguration _testClass;
    private IFixture _fixture;
    private Mock<IConfiguration> _config;
    private Mock<IServiceCollection> _services;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServiceConfiguration"/>.
    /// </summary>
    public ServiceConfigurationTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._config = _fixture.Freeze<Mock<IConfiguration>>();
        this._services = _fixture.Freeze<Mock<IServiceCollection>>();
        this._testClass = _fixture.Create<ServiceConfiguration>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ServiceConfiguration();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ServiceConfiguration(this._config.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ServiceConfiguration(this._services.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ServiceConfiguration(this._config.Object, this._services.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the config parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfig()
    {
        FluentActions.Invoking(() => new ServiceConfiguration(default(IConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("config");
        FluentActions.Invoking(() => new ServiceConfiguration(default(IConfiguration), this._services.Object)).Should().Throw<ArgumentNullException>().WithParameterName("config");
    }

    /// <summary>
    /// Checks that instance construction throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServices()
    {
        FluentActions.Invoking(() => new ServiceConfiguration(default(IServiceCollection))).Should().Throw<ArgumentNullException>().WithParameterName("services");
        FluentActions.Invoking(() => new ServiceConfiguration(this._config.Object, default(IServiceCollection))).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigureWithSectionName()
    {
        // Arrange
        var sectionName = _fixture.Create<string>();

        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.Configure<TOptions>(sectionName);

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the sectionName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallConfigureWithSectionNameWithInvalidSectionName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Configure<TOptions>(value)).Should().Throw<ArgumentNullException>().WithParameterName("sectionName");
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigureWithSectionNameAndConfigureOptions()
    {
        // Arrange
        var sectionName = _fixture.Create<string>();
        Action<BinderOptions> configureOptions = x => { };

        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.Configure<TOptions>(sectionName, configureOptions
        );

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the configureOptions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithSectionNameAndConfigureOptionsWithNullConfigureOptions()
    {
        FluentActions.Invoking(() => this._testClass.Configure<TOptions>(_fixture.Create<string>(), default(Action<BinderOptions>))).Should().Throw<ArgumentNullException>().WithParameterName("configureOptions");
    }

    /// <summary>
    /// Checks that the Configure method throws when the sectionName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallConfigureWithSectionNameAndConfigureOptionsWithInvalidSectionName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Configure<TOptions>(value, x => { })).Should().Throw<ArgumentNullException>().WithParameterName("sectionName");
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigureWithConfigureOptions()
    {
        // Arrange
        Action<TOptions> configureOptions = x => { };

        // Act
        var result = this._testClass.Configure<TOptions>(configureOptions);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the configureOptions parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithConfigureOptionsWithNullConfigureOptions()
    {
        FluentActions.Invoking(() => this._testClass.Configure<TOptions>(default(Action<TOptions>))).Should().Throw<ArgumentNullException>().WithParameterName("configureOptions");
    }

    /// <summary>
    /// Checks that the StoreRoutes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStoreRoutes()
    {
        // Arrange
        var name = _fixture.Create<string>();

        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.StoreRoutes(name);

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StoreRoutes method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallStoreRoutesWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.StoreRoutes(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the Repository method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRepository()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.Repository();

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DataCacheLifeTime method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDataCacheLifeTime()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.DataCacheLifeTime();

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Sources method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSources()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.Sources();

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Clients method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClients()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.Clients();

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Source method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSource()
    {
        // Arrange
        var name = _fixture.Create<string>();

        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.Source(name);

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Source method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSourceWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Source(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the SourceConnectionString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSourceConnectionStringWithString()
    {
        // Arrange
        var name = _fixture.Create<string>();

        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.SourceConnectionString(name);

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SourceConnectionString method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSourceConnectionStringWithStringWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.SourceConnectionString(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ClientConnectionString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClientConnectionStringWithString()
    {
        // Arrange
        var name = _fixture.Create<string>();

        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.ClientConnectionString(name);

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ClientConnectionString method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallClientConnectionStringWithStringWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.ClientConnectionString(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the SourceConnectionString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSourceConnectionStringWithIConfigurationSection()
    {
        // Arrange
        var endpoint = _fixture.Create<IConfigurationSection>();

        // Act
        var result = this._testClass.SourceConnectionString(endpoint);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SourceConnectionString method throws when the endpoint parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSourceConnectionStringWithIConfigurationSectionWithNullEndpoint()
    {
        FluentActions.Invoking(() => this._testClass.SourceConnectionString(default(IConfigurationSection))).Should().Throw<ArgumentNullException>().WithParameterName("endpoint");
    }

    /// <summary>
    /// Checks that the ClientConnectionString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClientConnectionStringWithIConfigurationSection()
    {
        // Arrange
        var client = _fixture.Create<IConfigurationSection>();

        // Act
        var result = this._testClass.ClientConnectionString(client);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ClientConnectionString method throws when the client parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallClientConnectionStringWithIConfigurationSectionWithNullClient()
    {
        FluentActions.Invoking(() => this._testClass.ClientConnectionString(default(IConfigurationSection))).Should().Throw<ArgumentNullException>().WithParameterName("client");
    }

    /// <summary>
    /// Checks that the Client method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClient()
    {
        // Arrange
        var name = _fixture.Create<string>();

        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.Client(name);

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Client method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallClientWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Client(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the SourceProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSourceProviderWithString()
    {
        // Arrange
        var name = _fixture.Create<string>();

        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.SourceProvider(name);

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SourceProvider method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSourceProviderWithStringWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.SourceProvider(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ClientProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClientProviderWithString()
    {
        // Arrange
        var name = _fixture.Create<string>();

        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.ClientProvider(name);

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ClientProvider method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallClientProviderWithStringWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.ClientProvider(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the SourceProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSourceProviderWithSource()
    {
        // Arrange
        var source = _fixture.Create<IConfigurationSection>();

        // Act
        var result = this._testClass.SourceProvider(source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SourceProvider method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSourceProviderWithSourceWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.SourceProvider(default(IConfigurationSection))).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the ClientProvider method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClientProviderWithIConfigurationSection()
    {
        // Arrange
        var client = _fixture.Create<IConfigurationSection>();

        // Act
        var result = this._testClass.ClientProvider(client);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ClientProvider method throws when the client parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallClientProviderWithIConfigurationSectionWithNullClient()
    {
        FluentActions.Invoking(() => this._testClass.ClientProvider(default(IConfigurationSection))).Should().Throw<ArgumentNullException>().WithParameterName("client");
    }

    /// <summary>
    /// Checks that the SourcePoolSize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSourcePoolSize()
    {
        // Arrange
        var endpoint = _fixture.Create<IConfigurationSection>();

        // Act
        var result = this._testClass.SourcePoolSize(endpoint);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SourcePoolSize method throws when the endpoint parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSourcePoolSizeWithNullEndpoint()
    {
        FluentActions.Invoking(() => this._testClass.SourcePoolSize(default(IConfigurationSection))).Should().Throw<ArgumentNullException>().WithParameterName("endpoint");
    }

    /// <summary>
    /// Checks that the ClientPoolSize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClientPoolSize()
    {
        // Arrange
        var client = _fixture.Create<IConfigurationSection>();

        // Act
        var result = this._testClass.ClientPoolSize(client);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ClientPoolSize method throws when the client parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallClientPoolSizeWithNullClient()
    {
        FluentActions.Invoking(() => this._testClass.ClientPoolSize(default(IConfigurationSection))).Should().Throw<ArgumentNullException>().WithParameterName("client");
    }

    /// <summary>
    /// Checks that the GetChildren method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetChildren()
    {
        // Arrange
        var expectedReturnValue = _fixture.Create<IEnumerable<IConfigurationSection>>();
        _config.Setup(mock => mock.GetChildren()).Returns(expectedReturnValue);

        // Act
        var result = this._testClass.GetChildren();

        // Assert
        _config.Verify(mock => mock.GetChildren());
        result.Should().BeSameAs(expectedReturnValue);
    }

    /// <summary>
    /// Checks that the GetReloadToken method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetReloadToken()
    {
        // Arrange
        var expectedReturnValue = _fixture.Create<IChangeToken>();
        _config.Setup(mock => mock.GetReloadToken()).Returns(expectedReturnValue);

        // Act
        var result = this._testClass.GetReloadToken();

        // Assert
        _config.Verify(mock => mock.GetReloadToken());
        result.Should().BeSameAs(expectedReturnValue);
    }

    /// <summary>
    /// Checks that the GetSection method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSection()
    {
        // Arrange
        var key = _fixture.Create<string>();

        var expectedReturnValue = _fixture.Create<IConfigurationSection>();
        _config.Setup(mock => mock.GetSection(key)).Returns(expectedReturnValue);

        // Act
        var result = this._testClass.GetSection(key);

        // Assert
        _config.Verify(mock => mock.GetSection(key));
        result.Should().BeSameAs(expectedReturnValue);
    }

    /// <summary>
    /// Checks that the GetSection method throws when the key parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetSectionWithInvalidKey(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetSection(value)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the GetSection maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetSectionPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetSection(key);

        // Assert
        result.Key.Should().BeSameAs(key);
    }

    /// <summary>
    /// Checks that the AccessServer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAccessServer()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.AccessServer();

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IdentityServerBaseUrl method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIdentityServerBaseUrl()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.IdentityServerBaseUrl();

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IdentityServiceName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIdentityServiceName()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.IdentityServiceName();

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IdentityServerScopes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIdentityServerScopes()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.IdentityServerScopes();

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IdentityServerClaims method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIdentityServerClaims()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.IdentityServerClaims();

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IdentityServerRoles method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIdentityServerRoles()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Act
        var result = this._testClass.IdentityServerRoles();

        // Assert
        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetAccessServerConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetAccessServerConfiguration()
    {
        // Act
        var result = this._testClass.GetAccessServerConfiguration();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetOpenApiConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetOpenApiConfiguration()
    {
        // Act
        var result = this._testClass.GetOpenApiConfiguration();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRepositoryConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRepositoryConfiguration()
    {
        // Act
        var result = this._testClass.GetRepositoryConfiguration();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AccessOptions property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetAccessOptions()
    {
        // Assert
        this._testClass.AccessOptions.Should().BeAssignableTo<AccessServerOptions>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Repositories property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRepositories()
    {
        // Assert
        this._testClass.Repositories.Should().BeAssignableTo<RepositoryOptions>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Version property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetVersion()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Assert
        this._testClass.Version.Should().BeAssignableTo<string>();

        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Name property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetName()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Assert
        this._testClass.Name.Should().BeAssignableTo<string>();

        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TypeName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetTypeName()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Assert
        this._testClass.TypeName.Should().BeAssignableTo<string>();

        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UserSecretsId property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetUserSecretsId()
    {
        // Arrange
        _config.Setup(mock => mock.GetSection(It.IsAny<string>())).Returns(_fixture.Create<IConfigurationSection>());

        // Assert
        this._testClass.UserSecretsId.Should().BeAssignableTo<string>();

        _config.Verify(mock => mock.GetSection(It.IsAny<string>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexer()
    {
        var testValue = _fixture.Create<string>();
        this._testClass[_fixture.Create<string>()].As<object>().Should().BeAssignableTo<string>();
        this._testClass[_fixture.Create<string>()] = testValue;
        this._testClass[_fixture.Create<string>()].Should().Be(testValue);
    }
}