using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Data.Repository.Source;
using Undersoft.SDK.Service.Data.Store;
using TContext = System.String;
using TEntity = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository.Source;

/// <summary>
/// Unit tests for the type <see cref="RepositorySource"/>.
/// </summary>
public class RepositorySourceTests
{
    private class TestRepositorySource : RepositorySource
    {
        public TestRepositorySource() : base()
        {
        }

        public TestRepositorySource(DbContextOptions options) : base(options)
        {
        }

        public TestRepositorySource(IRepositoryContextPool pool) : base(pool)
        {
        }

        public TestRepositorySource(StoreProvider provider, string connectionString) : base(provider, connectionString)
        {
        }

        public TestRepositorySource(Type contextType, IServiceConfiguration config) : base(contextType, config)
        {
        }

        public TestRepositorySource(Type contextType, DbContextOptions options) : base(contextType, options)
        {
        }

        public TestRepositorySource(
                                              Type contextType,
                                              StoreProvider provider,
                                              string connectionString
                                          ) : base(contextType, provider, connectionString
                                      )
        {
        }

        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

    private TestRepositorySource _testClass;
    private IFixture _fixture;
    private DbContextOptions _options;
    private Mock<IRepositoryContextPool> _pool;
    private StoreProvider _provider;
    private string _connectionString;
    private Type _contextType;
    private Mock<IServiceConfiguration> _config;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RepositorySource"/>.
    /// </summary>
    public RepositorySourceTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._options = _fixture.Create<DbContextOptions>();
        this._pool = _fixture.Freeze<Mock<IRepositoryContextPool>>();
        this._provider = _fixture.Create<StoreProvider>();
        this._connectionString = _fixture.Create<string>();
        this._contextType = _fixture.Create<Type>();
        this._config = _fixture.Freeze<Mock<IServiceConfiguration>>();
        this._testClass = _fixture.Create<TestRepositorySource>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRepositorySource();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepositorySource(this._options);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepositorySource(this._pool.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepositorySource(this._provider, this._connectionString);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepositorySource(this._contextType, this._config.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepositorySource(this._contextType, this._options);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepositorySource(this._contextType, this._provider, this._connectionString);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new TestRepositorySource(default(DbContextOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
        FluentActions.Invoking(() => new TestRepositorySource(this._contextType, default(DbContextOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that instance construction throws when the pool parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPool()
    {
        FluentActions.Invoking(() => new TestRepositorySource(default(IRepositoryContextPool))).Should().Throw<ArgumentNullException>().WithParameterName("pool");
    }

    /// <summary>
    /// Checks that instance construction throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullContextType()
    {
        FluentActions.Invoking(() => new TestRepositorySource(default(Type), this._config.Object)).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
        FluentActions.Invoking(() => new TestRepositorySource(default(Type), this._options)).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
        FluentActions.Invoking(() => new TestRepositorySource(default(Type), this._provider, this._connectionString)).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that instance construction throws when the config parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfig()
    {
        FluentActions.Invoking(() => new TestRepositorySource(this._contextType, default(IServiceConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("config");
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
        FluentActions.Invoking(() => new TestRepositorySource(this._provider, value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionString");
        FluentActions.Invoking(() => new TestRepositorySource(this._contextType, this._provider, value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionString");
    }

    /// <summary>
    /// Checks that the AcquireAccess method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAcquireAccess()
    {
        // Act
        this._testClass.AcquireAccess();

        // Assert
        Assert.Fail("Create or modify test");
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
    public void CanCallCreateContextWithTContext()
    {
        // Act
        var result = this._testClass.CreateContext<TContext>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateContext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateContextWithDbContextOptions()
    {
        // Arrange
        var options = _fixture.Create<DbContextOptions>();

        // Act
        var result = this._testClass.CreateContext(options);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateContext method throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateContextWithDbContextOptionsWithNullOptions()
    {
        FluentActions.Invoking(() => this._testClass.CreateContext(default(DbContextOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the CreateContext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateContextWithTContextAndDbContextOptions()
    {
        // Arrange
        var options = _fixture.Create<DbContextOptions>();

        // Act
        var result = this._testClass.CreateContext<TContext>(options);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateContext method throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateContextWithTContextAndDbContextOptionsWithNullOptions()
    {
        FluentActions.Invoking(() => this._testClass.CreateContext<TContext>(default(DbContextOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the CreateContext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateContextWithContextTypeAndOptions()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();
        var options = _fixture.Create<DbContextOptions>();

        // Act
        var result = this._testClass.CreateContext(contextType, options);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateContext method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateContextWithContextTypeAndOptionsWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.CreateContext(default(Type), _fixture.Create<DbContextOptions>())).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the CreateContext method throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateContextWithContextTypeAndOptionsWithNullOptions()
    {
        FluentActions.Invoking(() => this._testClass.CreateContext(_fixture.Create<Type>(), default(DbContextOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the CreatePool method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreatePoolWithNoParameters()
    {
        // Act
        this._testClass.CreatePool();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreatePool method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreatePoolWithTContext()
    {
        // Act
        this._testClass.CreatePool<TContext>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DisposeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDisposeAsync()
    {
        // Act
        await this._testClass.DisposeAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetContext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetContext()
    {
        // Act
        var result = this._testClass.GetContext<TContext>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lease method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLease()
    {
        // Arrange
        var destContext = _fixture.Create<IRepositoryContext>();

        // Act
        this._testClass.Lease(destContext);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lease method throws when the destContext parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLeaseWithNullDestContext()
    {
        FluentActions.Invoking(() => this._testClass.Lease(default(IRepositoryContext))).Should().Throw<ArgumentNullException>().WithParameterName("destContext");
    }

    /// <summary>
    /// Checks that the LeaseAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallLeaseAsync()
    {
        // Arrange
        var lease = _fixture.Create<IRepositoryContext>();
        var token = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.LeaseAsync(lease, token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LeaseAsync method throws when the lease parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallLeaseAsyncWithNullLeaseAsync()
    {
        await FluentActions.Invoking(() => this._testClass.LeaseAsync(default(IRepositoryContext), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("lease");
    }

    /// <summary>
    /// Checks that the Release method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelease()
    {
        // Act
        var result = this._testClass.Release();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReleaseAccess method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReleaseAccess()
    {
        // Act
        this._testClass.ReleaseAccess();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReleaseAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallReleaseAsync()
    {
        // Arrange
        var token = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.ReleaseAsync(token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Rent method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRent()
    {
        // Act
        var result = this._testClass.Rent();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ResetState method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallResetState()
    {
        // Act
        this._testClass.ResetState();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ResetStateAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallResetStateAsync()
    {
        // Arrange
        var token = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.ResetStateAsync(token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Return method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReturn()
    {
        // Act
        this._testClass.Return();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReturnAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallReturnAsync()
    {
        // Arrange
        var token = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.ReturnAsync(token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Save method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSaveAsync()
    {
        // Arrange
        var asTransaction = _fixture.Create<bool>();
        var token = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Save(asTransaction, token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EntitySet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEntitySetWithTEntity()
    {
        // Act
        var result = this._testClass.EntitySet<TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EntitySet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEntitySetWithEntityType()
    {
        // Arrange
        var entityType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.EntitySet(entityType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EntitySet method throws when the entityType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEntitySetWithEntityTypeWithNullEntityType()
    {
        FluentActions.Invoking(() => this._testClass.EntitySet(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("entityType");
    }

    /// <summary>
    /// Checks that the SnapshotConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSnapshotConfiguration()
    {
        // Act
        this._testClass.SnapshotConfiguration();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDispose()
    {
        // Arrange
        var disposing = _fixture.Create<bool>();

        // Act
        this._testClass.PublicDispose(disposing);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Context property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetContext()
    {
        // Assert
        this._testClass.Context.Should().BeAssignableTo<IDataStoreContext>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the ContextLease property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetContextLease()
    {
        this._testClass.CheckProperty(x => x.ContextLease, _fixture.Create<IRepositoryContext>(), _fixture.Create<IRepositoryContext>());
    }

    /// <summary>
    /// Checks that setting the ContextPool property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetContextPool()
    {
        this._testClass.CheckProperty(x => x.ContextPool, _fixture.Create<IRepositoryContextPool>(), _fixture.Create<IRepositoryContextPool>());
    }

    /// <summary>
    /// Checks that setting the InnerContext property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInnerContext()
    {
        this._testClass.CheckProperty(x => x.InnerContext, _fixture.Create<object>(), _fixture.Create<object>());
    }

    /// <summary>
    /// Checks that the Leased property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetLeased()
    {
        // Assert
        this._testClass.Leased.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Options property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOptions()
    {
        this._testClass.CheckProperty(x => x.Options, _fixture.Create<DbContextOptions>(), _fixture.Create<DbContextOptions>());
    }

    /// <summary>
    /// Checks that the Pooled property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPooled()
    {
        // Assert
        this._testClass.Pooled.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the PoolSize property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPoolSize()
    {
        this._testClass.CheckProperty(x => x.PoolSize);
    }

    /// <summary>
    /// Checks that setting the Site property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSite()
    {
        this._testClass.CheckProperty(x => x.Site, _fixture.Create<DataSite>(), _fixture.Create<DataSite>());
    }

    /// <summary>
    /// Checks that setting the Id property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetId()
    {
        this._testClass.CheckProperty(x => x.Id);
    }

    /// <summary>
    /// Checks that setting the TypeId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeId()
    {
        this._testClass.CheckProperty(x => x.TypeId);
    }
}