using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Data.Repository.Source;
using Undersoft.SDK.Service.Data.Store;
using TContext = Undersoft.SDK.Service.Data.Store.DataStoreContext;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository.Source;

/// <summary>
/// Unit tests for the type <see cref="RepositorySource"/>.
/// </summary>
public class RepositorySource_1Tests
{
    private RepositorySource<TContext> _testClass;
    private IFixture _fixture;
    private Mock<IServiceConfiguration> _config;
    private DbContextOptions<TContext> _options;
    private Mock<IRepositorySource> _pool;
    private StoreProvider _provider;
    private string _connectionString;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RepositorySource"/>.
    /// </summary>
    public RepositorySource_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._config = _fixture.Freeze<Mock<IServiceConfiguration>>();
        this._options = _fixture.Create<DbContextOptions<TContext>>();
        this._pool = _fixture.Freeze<Mock<IRepositorySource>>();
        this._provider = _fixture.Create<StoreProvider>();
        this._connectionString = _fixture.Create<string>();
        this._testClass = _fixture.Create<RepositorySource<TContext>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RepositorySource<TContext>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RepositorySource<TContext>(this._config.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RepositorySource<TContext>(this._options);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RepositorySource<TContext>(this._pool.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RepositorySource<TContext>(this._provider, this._connectionString);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the config parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfig()
    {
        FluentActions.Invoking(() => new RepositorySource<TContext>(default(IServiceConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("config");
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new RepositorySource<TContext>(default(DbContextOptions<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that instance construction throws when the pool parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPool()
    {
        FluentActions.Invoking(() => new RepositorySource<TContext>(default(IRepositorySource))).Should().Throw<ArgumentNullException>().WithParameterName("pool");
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
        FluentActions.Invoking(() => new RepositorySource<TContext>(this._provider, value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionString");
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
    public void CanCallCreateContextWithOptions()
    {
        // Arrange
        var options = _fixture.Create<DbContextOptions<TContext>>();

        // Act
        var result = this._testClass.CreateContext(options);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateContext method throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateContextWithOptionsWithNullOptions()
    {
        FluentActions.Invoking(() => this._testClass.CreateContext(default(DbContextOptions<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the CreateDbContext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateDbContextWithNoParameters()
    {
        // Act
        var result = this._testClass.CreateDbContext();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateDbContext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateDbContextWithArgs()
    {
        // Arrange
        var args = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.CreateDbContext(args);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateDbContext method throws when the args parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateDbContextWithArgsWithNullArgs()
    {
        FluentActions.Invoking(() => this._testClass.CreateDbContext(default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("args");
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