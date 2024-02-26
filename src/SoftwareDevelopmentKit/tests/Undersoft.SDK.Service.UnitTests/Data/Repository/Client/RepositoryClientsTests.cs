using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Client;
using Undersoft.SDK.Service.Data.Repository.Client;
using TContext = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository.Client;

/// <summary>
/// Unit tests for the type <see cref="RepositoryClients"/>.
/// </summary>
public class RepositoryClientsTests
{
    private class TestRepositoryClients : RepositoryClients
    {
        public TestRepositoryClients() : base()
        {
        }

        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

    private TestRepositoryClients _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RepositoryClients"/>.
    /// </summary>
    public RepositoryClientsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestRepositoryClients>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRepositoryClients();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithType()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.Get(contextType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithTypeWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.Get(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithTContext()
    {
        // Act
        var result = this._testClass.Get<TContext>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetWithTypeAndIRepositoryClient()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.TryGet(contextType, out var repoSource);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGet method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryGetWithTypeAndIRepositoryClientWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.TryGet(default(Type), out _)).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the TryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetWithIRepositoryClientOfTContext()
    {
        // Act
        var result = this._testClass.TryGet<TContext>(out var repoSource);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAddWithTypeAndIRepositoryClient()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();
        var repoSource = _fixture.Create<IRepositoryClient>();

        // Act
        var result = this._testClass.TryAdd(contextType, repoSource);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAdd method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryAddWithTypeAndIRepositoryClientWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.TryAdd(default(Type), _fixture.Create<IRepositoryClient>())).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the TryAdd method throws when the repoSource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryAddWithTypeAndIRepositoryClientWithNullRepoSource()
    {
        FluentActions.Invoking(() => this._testClass.TryAdd(_fixture.Create<Type>(), default(IRepositoryClient))).Should().Throw<ArgumentNullException>().WithParameterName("repoSource");
    }

    /// <summary>
    /// Checks that the TryAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAddWithIRepositoryClient()
    {
        // Arrange
        var repoSource = _fixture.Create<IRepositoryClient>();

        // Act
        var result = this._testClass.TryAdd(repoSource);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAdd method throws when the repoSource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryAddWithIRepositoryClientWithNullRepoSource()
    {
        FluentActions.Invoking(() => this._testClass.TryAdd(default(IRepositoryClient))).Should().Throw<ArgumentNullException>().WithParameterName("repoSource");
    }

    /// <summary>
    /// Checks that the TryAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAddWithTContextAndIRepositoryClientOfTContext()
    {
        // Arrange
        var repoSource = _fixture.Create<IRepositoryClient<TContext>>();

        // Act
        var result = this._testClass.TryAdd<TContext>(repoSource);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAdd method throws when the repoSource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryAddWithTContextAndIRepositoryClientOfTContextWithNullRepoSource()
    {
        FluentActions.Invoking(() => this._testClass.TryAdd<TContext>(default(IRepositoryClient<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("repoSource");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithTContextAndIRepositoryClientOfTContext()
    {
        // Arrange
        var repoSource = _fixture.Create<IRepositoryClient<TContext>>();

        // Act
        var result = this._testClass.Add<TContext>(repoSource);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the repoSource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithTContextAndIRepositoryClientOfTContextWithNullRepoSource()
    {
        FluentActions.Invoking(() => this._testClass.Add<TContext>(default(IRepositoryClient<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("repoSource");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIRepositoryClient()
    {
        // Arrange
        var repoSource = _fixture.Create<IRepositoryClient>();

        // Act
        this._testClass.Add(repoSource);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the repoSource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIRepositoryClientWithNullRepoSource()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IRepositoryClient))).Should().Throw<ArgumentNullException>().WithParameterName("repoSource");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemove()
    {
        // Act
        var result = this._testClass.Remove<TContext>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PoolCount method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPoolCountWithType()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.PoolCount(contextType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PoolCount method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPoolCountWithTypeWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.PoolCount(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the PoolCount method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPoolCountWithTContext()
    {
        // Act
        var result = this._testClass.PoolCount<TContext>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPut()
    {
        // Arrange
        var repoSource = _fixture.Create<IRepositoryClient<TContext>>();

        // Act
        var result = this._testClass.Put<TContext>(repoSource);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the repoSource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithNullRepoSource()
    {
        FluentActions.Invoking(() => this._testClass.Put<TContext>(default(IRepositoryClient<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("repoSource");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithRoute()
    {
        // Arrange
        var route = _fixture.Create<Uri>();

        // Act
        var result = this._testClass.New<TContext>(route);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the route parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithRouteWithNullRoute()
    {
        FluentActions.Invoking(() => this._testClass.New<TContext>(default(Uri))).Should().Throw<ArgumentNullException>().WithParameterName("route");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithContextTypeAndRoute()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();
        var route = _fixture.Create<Uri>();

        // Act
        var result = this._testClass.New(contextType, route);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithContextTypeAndRouteWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.New(default(Type), _fixture.Create<Uri>())).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the New method throws when the route parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithContextTypeAndRouteWithNullRoute()
    {
        FluentActions.Invoking(() => this._testClass.New(_fixture.Create<Type>(), default(Uri))).Should().Throw<ArgumentNullException>().WithParameterName("route");
    }

    /// <summary>
    /// Checks that the New maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewWithContextTypeAndRoutePerformsMapping()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();
        var route = _fixture.Create<Uri>();

        // Act
        var result = this._testClass.New(contextType, route);

        // Assert
        result.Route.Should().BeSameAs(route);
    }

    /// <summary>
    /// Checks that the GetKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetKey()
    {
        // Arrange
        var item = _fixture.Create<IRepositoryClient>();

        // Act
        var result = this._testClass.GetKey(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetKey method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetKeyWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.GetKey(default(IRepositoryClient))).Should().Throw<ArgumentNullException>().WithParameterName("item");
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
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForString()
    {
        var testValue = _fixture.Create<IRepositoryClient>();
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<IRepositoryClient>();
        this._testClass[_fixture.Create<string>()] = testValue;
        this._testClass[_fixture.Create<string>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForOpenDataContext()
    {
        var testValue = _fixture.Create<IRepositoryClient>();
        this._testClass[_fixture.Create<OpenDataContext>()].Should().BeAssignableTo<IRepositoryClient>();
        this._testClass[_fixture.Create<OpenDataContext>()] = testValue;
        this._testClass[_fixture.Create<OpenDataContext>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForType()
    {
        var testValue = _fixture.Create<IRepositoryClient>();
        this._testClass[_fixture.Create<Type>()].Should().BeAssignableTo<IRepositoryClient>();
        this._testClass[_fixture.Create<Type>()] = testValue;
        this._testClass[_fixture.Create<Type>()].Should().BeSameAs(testValue);
    }
}