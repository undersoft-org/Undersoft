using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Mapper;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Data.Repository.Client;
using Undersoft.SDK.Service.Data.Repository.Source;
using TContext = System.String;
using TDto = System.String;
using TEntity = System.String;
using TProfile = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository;

/// <summary>
/// Unit tests for the type <see cref="RepositoryManager"/>.
/// </summary>
public class RepositoryManagerTests
{
    private class TestRepositoryManager : RepositoryManager
    {
        public TestRepositoryManager() : base()
        {
        }

        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public IRepositorySources PublicSources => base.Sources;

        public IRepositoryClients PublicClients => base.Clients;

        public IServiceManager PublicManager => base.Manager;
    }

    private TestRepositoryManager _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RepositoryManager"/>.
    /// </summary>
    public RepositoryManagerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestRepositoryManager>();
    }

    /// <summary>
    /// Checks that the use method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCalluseWithTStoreAndTEntity()
    {
        // Act
        var result = this._testClass.use<TStore, TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the use method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCalluseWithTEntity()
    {
        // Act
        var result = this._testClass.use<TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Use method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUseWithTEntityAndType()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.Use<TEntity>(contextType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Use method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUseWithTEntityAndTypeWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.Use<TEntity>(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the open method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallopenWithTStoreAndTDto()
    {
        // Act
        var result = this._testClass.open<TStore, TDto>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the open method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallopenWithTDto()
    {
        // Act
        var result = this._testClass.open<TDto>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Open method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOpenWithTDtoAndType()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.Open<TDto>(contextType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Open method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOpenWithTDtoAndTypeWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.Open<TDto>(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the Open maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void OpenWithTDtoAndTypePerformsMapping()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.Open<TDto>(contextType);

        // Assert
        result.FullName.Should().BeSameAs(contextType.FullName);
    }

    /// <summary>
    /// Checks that the GetSource method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSource()
    {
        // Act
        var result = this._testClass.GetSource<TStore, TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetClient method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetClient()
    {
        // Act
        var result = this._testClass.GetClient<TStore, TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddClientPool method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddClientPool()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();
        var poolSize = _fixture.Create<int>();
        var minSize = _fixture.Create<int>();

        // Act
        this._testClass.AddClientPool(contextType, poolSize, minSize);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddClientPool method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddClientPoolWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.AddClientPool(default(Type), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the AddClientPools method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAddClientPoolsAsync()
    {
        // Act
        await this._testClass.AddClientPools();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateClient method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateClientWithIRepositoryClient()
    {
        // Arrange
        var client = _fixture.Create<IRepositoryClient>();

        // Act
        var result = TestRepositoryManager.CreateClient(client);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateClient method throws when the client parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateClientWithIRepositoryClientWithNullClient()
    {
        FluentActions.Invoking(() => TestRepositoryManager.CreateClient(default(IRepositoryClient))).Should().Throw<ArgumentNullException>().WithParameterName("client");
    }

    /// <summary>
    /// Checks that the CreateClient method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateClientWithIRepositoryClientOfTContext()
    {
        // Arrange
        var client = _fixture.Create<IRepositoryClient<TContext>>();

        // Act
        var result = TestRepositoryManager.CreateClient<TContext>(client);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateClient method throws when the client parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateClientWithIRepositoryClientOfTContextWithNullClient()
    {
        FluentActions.Invoking(() => TestRepositoryManager.CreateClient<TContext>(default(IRepositoryClient<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("client");
    }

    /// <summary>
    /// Checks that the CreateClient method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateClientWithServiceRoot()
    {
        // Arrange
        var serviceRoot = _fixture.Create<Uri>();

        // Act
        var result = TestRepositoryManager.CreateClient<TContext>(serviceRoot);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateClient method throws when the serviceRoot parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateClientWithServiceRootWithNullServiceRoot()
    {
        FluentActions.Invoking(() => TestRepositoryManager.CreateClient<TContext>(default(Uri))).Should().Throw<ArgumentNullException>().WithParameterName("serviceRoot");
    }

    /// <summary>
    /// Checks that the CreateClient method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateClientWithContextTypeAndServiceRoot()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();
        var serviceRoot = _fixture.Create<Uri>();

        // Act
        var result = TestRepositoryManager.CreateClient(contextType, serviceRoot);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateClient method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateClientWithContextTypeAndServiceRootWithNullContextType()
    {
        FluentActions.Invoking(() => TestRepositoryManager.CreateClient(default(Type), _fixture.Create<Uri>())).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the CreateClient method throws when the serviceRoot parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateClientWithContextTypeAndServiceRootWithNullServiceRoot()
    {
        FluentActions.Invoking(() => TestRepositoryManager.CreateClient(_fixture.Create<Type>(), default(Uri))).Should().Throw<ArgumentNullException>().WithParameterName("serviceRoot");
    }

    /// <summary>
    /// Checks that the AddClient method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddClient()
    {
        // Arrange
        var client = _fixture.Create<IRepositoryClient>();

        // Act
        var result = this._testClass.AddClient(client);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddClient method throws when the client parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddClientWithNullClient()
    {
        FluentActions.Invoking(() => this._testClass.AddClient(default(IRepositoryClient))).Should().Throw<ArgumentNullException>().WithParameterName("client");
    }

    /// <summary>
    /// Checks that the TryGetClient method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetClientWithIRepositoryClientOfTContext()
    {
        // Act
        var result = this._testClass.TryGetClient<TContext>(out var source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGetClient method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetClientWithTypeAndIRepositoryClient()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.TryGetClient(contextType, out var source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGetClient method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryGetClientWithTypeAndIRepositoryClientWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.TryGetClient(default(Type), out _)).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the AddEndpointPools method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAddEndpointPoolsAsync()
    {
        // Act
        await this._testClass.AddEndpointPools();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddSourcePool method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddSourcePool()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();
        var poolSize = _fixture.Create<int>();
        var minSize = _fixture.Create<int>();

        // Act
        this._testClass.AddSourcePool(contextType, poolSize, minSize);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddSourcePool method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddSourcePoolWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.AddSourcePool(default(Type), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the CreateSource method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateSourceWithDbContextOptionsOfTContext()
    {
        // Arrange
        var options = _fixture.Create<DbContextOptions<TContext>>();

        // Act
        var result = TestRepositoryManager.CreateSource<TContext>(options);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateSource method throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateSourceWithDbContextOptionsOfTContextWithNullOptions()
    {
        FluentActions.Invoking(() => TestRepositoryManager.CreateSource<TContext>(default(DbContextOptions<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the CreateSource maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void CreateSourceWithDbContextOptionsOfTContextPerformsMapping()
    {
        // Arrange
        var options = _fixture.Create<DbContextOptions<TContext>>();

        // Act
        var result = TestRepositoryManager.CreateSource<TContext>(options);

        // Assert
        result.Options.Should().BeSameAs(options);
    }

    /// <summary>
    /// Checks that the CreateSource method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateSourceWithIRepositorySource()
    {
        // Arrange
        var source = _fixture.Create<IRepositorySource>();

        // Act
        var result = TestRepositoryManager.CreateSource(source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateSource method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateSourceWithIRepositorySourceWithNullSource()
    {
        FluentActions.Invoking(() => TestRepositoryManager.CreateSource(default(IRepositorySource))).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the CreateSource method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateSourceWithIRepositorySourceOfTContext()
    {
        // Arrange
        var source = _fixture.Create<IRepositorySource<TContext>>();

        // Act
        var result = TestRepositoryManager.CreateSource<TContext>(source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateSource method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateSourceWithIRepositorySourceOfTContextWithNullSource()
    {
        FluentActions.Invoking(() => TestRepositoryManager.CreateSource<TContext>(default(IRepositorySource<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the CreateSource method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateSourceWithDbContextOptions()
    {
        // Arrange
        var options = _fixture.Create<DbContextOptions>();

        // Act
        var result = TestRepositoryManager.CreateSource(options);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateSource method throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateSourceWithDbContextOptionsWithNullOptions()
    {
        FluentActions.Invoking(() => TestRepositoryManager.CreateSource(default(DbContextOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the CreateSource maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void CreateSourceWithDbContextOptionsPerformsMapping()
    {
        // Arrange
        var options = _fixture.Create<DbContextOptions>();

        // Act
        var result = TestRepositoryManager.CreateSource(options);

        // Assert
        result.Options.Should().BeSameAs(options);
    }

    /// <summary>
    /// Checks that the AddSource method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddSource()
    {
        // Arrange
        var source = _fixture.Create<IRepositorySource>();

        // Act
        var result = this._testClass.AddSource(source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddSource method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddSourceWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.AddSource(default(IRepositorySource))).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the TryGetSource method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetSourceWithIRepositorySourceOfTContext()
    {
        // Act
        var result = this._testClass.TryGetSource<TContext>(out var source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGetSource method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetSourceWithTypeAndIRepositorySource()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.TryGetSource(contextType, out var source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGetSource method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryGetSourceWithTypeAndIRepositorySourceWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.TryGetSource(default(Type), out _)).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the GetSources method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSources()
    {
        // Act
        var result = this._testClass.GetSources();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetClients method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetClients()
    {
        // Act
        var result = this._testClass.GetClients();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateMapper method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateMapperWithProfiles()
    {
        // Arrange
        var profiles = _fixture.Create<MapperProfile[]>();

        // Act
        var result = this._testClass.CreateMapper(profiles);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateMapper method throws when the profiles parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateMapperWithProfilesWithNullProfiles()
    {
        FluentActions.Invoking(() => this._testClass.CreateMapper(default(MapperProfile[]))).Should().Throw<ArgumentNullException>().WithParameterName("profiles");
    }

    /// <summary>
    /// Checks that the CreateMapper method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateMapperWithTProfile()
    {
        // Act
        var result = this._testClass.CreateMapper<TProfile>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetMapper method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMapper()
    {
        // Act
        var result = this._testClass.GetMapper();

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
    /// Checks that the DisposeAsyncCore method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDisposeAsyncCoreAsync()
    {
        // Act
        await this._testClass.DisposeAsyncCore();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicSources property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicSources()
    {
        // Assert
        this._testClass.PublicSources.Should().BeAssignableTo<IRepositorySources>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicClients property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicClients()
    {
        // Assert
        this._testClass.PublicClients.Should().BeAssignableTo<IRepositoryClients>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicManager property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicManager()
    {
        // Assert
        this._testClass.PublicManager.Should().BeAssignableTo<IServiceManager>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Mapper property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetMapper()
    {
        // Assert
        this._testClass.Mapper.Should().BeAssignableTo<IDataMapper>();

        Assert.Fail("Create or modify test");
    }
}