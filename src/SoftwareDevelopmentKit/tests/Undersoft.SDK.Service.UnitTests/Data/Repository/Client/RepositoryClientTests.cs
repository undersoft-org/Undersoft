using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Data.Client;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Data.Repository.Client;
using TContext = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository.Client;

/// <summary>
/// Unit tests for the type <see cref="RepositoryClient"/>.
/// </summary>
public class RepositoryClientTests
{
    private class TestRepositoryClient : RepositoryClient
    {
        public TestRepositoryClient() : base()
        {
        }

        public TestRepositoryClient(Type contextType, IServiceConfiguration config) : base(contextType, config)
        {
        }

        public TestRepositoryClient(Type contextType, Uri serviceRoot) : base(contextType, serviceRoot)
        {
        }

        public TestRepositoryClient(Type contextType, ClientProvider provider, string connectionString) : base(contextType, provider, connectionString)
        {
        }

        public TestRepositoryClient(IRepositoryClient pool) : base(pool)
        {
        }

        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

    private TestRepositoryClient _testClass;
    private IFixture _fixture;
    private Type _contextType;
    private Mock<IServiceConfiguration> _config;
    private Uri _serviceRoot;
    private ClientProvider _provider;
    private string _connectionString;
    private Mock<IRepositoryClient> _pool;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RepositoryClient"/>.
    /// </summary>
    public RepositoryClientTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._contextType = _fixture.Create<Type>();
        this._config = _fixture.Freeze<Mock<IServiceConfiguration>>();
        this._serviceRoot = _fixture.Create<Uri>();
        this._provider = _fixture.Create<ClientProvider>();
        this._connectionString = _fixture.Create<string>();
        this._pool = _fixture.Freeze<Mock<IRepositoryClient>>();
        this._testClass = _fixture.Create<TestRepositoryClient>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRepositoryClient();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepositoryClient(this._contextType, this._config.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepositoryClient(this._contextType, this._serviceRoot);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepositoryClient(this._contextType, this._provider, this._connectionString);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRepositoryClient(this._pool.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullContextType()
    {
        FluentActions.Invoking(() => new TestRepositoryClient(default(Type), this._config.Object)).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
        FluentActions.Invoking(() => new TestRepositoryClient(default(Type), this._serviceRoot)).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
        FluentActions.Invoking(() => new TestRepositoryClient(default(Type), this._provider, this._connectionString)).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that instance construction throws when the config parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfig()
    {
        FluentActions.Invoking(() => new TestRepositoryClient(this._contextType, default(IServiceConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("config");
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceRoot parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceRoot()
    {
        FluentActions.Invoking(() => new TestRepositoryClient(this._contextType, default(Uri))).Should().Throw<ArgumentNullException>().WithParameterName("serviceRoot");
    }

    /// <summary>
    /// Checks that instance construction throws when the pool parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPool()
    {
        FluentActions.Invoking(() => new TestRepositoryClient(default(IRepositoryClient))).Should().Throw<ArgumentNullException>().WithParameterName("pool");
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
        FluentActions.Invoking(() => new TestRepositoryClient(this._contextType, this._provider, value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionString");
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
    public void CanCallCreateContextWithContextTypeAndServiceRoot()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();
        var serviceRoot = _fixture.Create<Uri>();

        // Act
        var result = this._testClass.CreateContext(contextType, serviceRoot);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateContext method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateContextWithContextTypeAndServiceRootWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.CreateContext(default(Type), _fixture.Create<Uri>())).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the CreateContext method throws when the serviceRoot parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateContextWithContextTypeAndServiceRootWithNullServiceRoot()
    {
        FluentActions.Invoking(() => this._testClass.CreateContext(_fixture.Create<Type>(), default(Uri))).Should().Throw<ArgumentNullException>().WithParameterName("serviceRoot");
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
    public void CanCallCreateContextWithServiceRoot()
    {
        // Arrange
        var serviceRoot = _fixture.Create<Uri>();

        // Act
        var result = this._testClass.CreateContext<TContext>(serviceRoot);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateContext method throws when the serviceRoot parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateContextWithServiceRootWithNullServiceRoot()
    {
        FluentActions.Invoking(() => this._testClass.CreateContext<TContext>(default(Uri))).Should().Throw<ArgumentNullException>().WithParameterName("serviceRoot");
    }

    /// <summary>
    /// Checks that the BuildMetadataAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallBuildMetadataAsync()
    {
        // Act
        var result = await this._testClass.BuildMetadataAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BuildMetadata method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuildMetadata()
    {
        // Act
        var result = this._testClass.BuildMetadata();

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
        var destContext = _fixture.Create<IRepositoryContext>();
        var token = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.LeaseAsync(destContext, token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LeaseAsync method throws when the destContext parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallLeaseAsyncWithNullDestContextAsync()
    {
        await FluentActions.Invoking(() => this._testClass.LeaseAsync(default(IRepositoryContext), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("destContext");
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
    /// Checks that setting the InnerContext property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInnerContext()
    {
        this._testClass.CheckProperty(x => x.InnerContext, _fixture.Create<object>(), _fixture.Create<object>());
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
    /// Checks that setting the PoolSize property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPoolSize()
    {
        this._testClass.CheckProperty(x => x.PoolSize);
    }

    /// <summary>
    /// Checks that the Route property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRoute()
    {
        // Assert
        this._testClass.Route.Should().BeAssignableTo<Uri>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Context property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetContext()
    {
        // Assert
        this._testClass.Context.Should().BeAssignableTo<OpenDataContext>();

        Assert.Fail("Create or modify test");
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
    /// Checks that the Leased property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetLeased()
    {
        // Assert
        this._testClass.Leased.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }
}