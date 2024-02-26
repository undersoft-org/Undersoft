using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Repository.Source;
using TContext = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository.Source;

/// <summary>
/// Unit tests for the type <see cref="RepositorySources"/>.
/// </summary>
public class RepositorySourcesTests
{
    private class TestRepositorySources : RepositorySources
    {
        public TestRepositorySources() : base()
        {
        }

        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

    private TestRepositorySources _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RepositorySources"/>.
    /// </summary>
    public RepositorySourcesTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestRepositorySources>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRepositorySources();

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
    public void CanCallTryGetWithTypeAndIRepositorySource()
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
    public void CannotCallTryGetWithTypeAndIRepositorySourceWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.TryGet(default(Type), out _)).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the TryGet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetWithIRepositorySourceOfTContext()
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
    public void CanCallTryAddWithTypeAndIRepositorySource()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();
        var repoSource = _fixture.Create<IRepositorySource>();

        // Act
        var result = this._testClass.TryAdd(contextType, repoSource);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAdd method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryAddWithTypeAndIRepositorySourceWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.TryAdd(default(Type), _fixture.Create<IRepositorySource>())).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the TryAdd method throws when the repoSource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryAddWithTypeAndIRepositorySourceWithNullRepoSource()
    {
        FluentActions.Invoking(() => this._testClass.TryAdd(_fixture.Create<Type>(), default(IRepositorySource))).Should().Throw<ArgumentNullException>().WithParameterName("repoSource");
    }

    /// <summary>
    /// Checks that the TryAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAddWithIRepositorySource()
    {
        // Arrange
        var repoSource = _fixture.Create<IRepositorySource>();

        // Act
        var result = this._testClass.TryAdd(repoSource);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAdd method throws when the repoSource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryAddWithIRepositorySourceWithNullRepoSource()
    {
        FluentActions.Invoking(() => this._testClass.TryAdd(default(IRepositorySource))).Should().Throw<ArgumentNullException>().WithParameterName("repoSource");
    }

    /// <summary>
    /// Checks that the TryAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAddWithTContextAndIRepositorySourceOfTContext()
    {
        // Arrange
        var repoSource = _fixture.Create<IRepositorySource<TContext>>();

        // Act
        var result = this._testClass.TryAdd<TContext>(repoSource);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAdd method throws when the repoSource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryAddWithTContextAndIRepositorySourceOfTContextWithNullRepoSource()
    {
        FluentActions.Invoking(() => this._testClass.TryAdd<TContext>(default(IRepositorySource<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("repoSource");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithTContextAndIRepositorySourceOfTContext()
    {
        // Arrange
        var repoSource = _fixture.Create<IRepositorySource<TContext>>();

        // Act
        var result = this._testClass.Add<TContext>(repoSource);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the repoSource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithTContextAndIRepositorySourceOfTContextWithNullRepoSource()
    {
        FluentActions.Invoking(() => this._testClass.Add<TContext>(default(IRepositorySource<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("repoSource");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIRepositorySource()
    {
        // Arrange
        var repoSource = _fixture.Create<IRepositorySource>();

        // Act
        this._testClass.Add(repoSource);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the repoSource parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIRepositorySourceWithNullRepoSource()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IRepositorySource))).Should().Throw<ArgumentNullException>().WithParameterName("repoSource");
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
        var repoSource = _fixture.Create<IRepositorySource<TContext>>();

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
        FluentActions.Invoking(() => this._testClass.Put<TContext>(default(IRepositorySource<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("repoSource");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithOptions()
    {
        // Arrange
        var options = _fixture.Create<DbContextOptions<TContext>>();

        // Act
        var result = this._testClass.New<TContext>(options);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithOptionsWithNullOptions()
    {
        FluentActions.Invoking(() => this._testClass.New<TContext>(default(DbContextOptions<TContext>))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the New maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewWithOptionsPerformsMapping()
    {
        // Arrange
        var options = _fixture.Create<DbContextOptions<TContext>>();

        // Act
        var result = this._testClass.New<TContext>(options);

        // Assert
        result.Options.Should().BeSameAs(options);
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithContextTypeAndOptions()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();
        var options = _fixture.Create<DbContextOptions>();

        // Act
        var result = this._testClass.New(contextType, options);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the contextType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithContextTypeAndOptionsWithNullContextType()
    {
        FluentActions.Invoking(() => this._testClass.New(default(Type), _fixture.Create<DbContextOptions>())).Should().Throw<ArgumentNullException>().WithParameterName("contextType");
    }

    /// <summary>
    /// Checks that the New method throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithContextTypeAndOptionsWithNullOptions()
    {
        FluentActions.Invoking(() => this._testClass.New(_fixture.Create<Type>(), default(DbContextOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the New maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewWithContextTypeAndOptionsPerformsMapping()
    {
        // Arrange
        var contextType = _fixture.Create<Type>();
        var options = _fixture.Create<DbContextOptions>();

        // Act
        var result = this._testClass.New(contextType, options);

        // Assert
        result.Options.Should().BeSameAs(options);
    }

    /// <summary>
    /// Checks that the GetKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetKey()
    {
        // Arrange
        var item = _fixture.Create<IRepositorySource>();

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
        FluentActions.Invoking(() => this._testClass.GetKey(default(IRepositorySource))).Should().Throw<ArgumentNullException>().WithParameterName("item");
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
        var testValue = _fixture.Create<IRepositorySource>();
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<IRepositorySource>();
        this._testClass[_fixture.Create<string>()] = testValue;
        this._testClass[_fixture.Create<string>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForDbContext()
    {
        var testValue = _fixture.Create<IRepositorySource>();
        this._testClass[_fixture.Create<DbContext>()].Should().BeAssignableTo<IRepositorySource>();
        this._testClass[_fixture.Create<DbContext>()] = testValue;
        this._testClass[_fixture.Create<DbContext>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForType()
    {
        var testValue = _fixture.Create<IRepositorySource>();
        this._testClass[_fixture.Create<Type>()].Should().BeAssignableTo<IRepositorySource>();
        this._testClass[_fixture.Create<Type>()] = testValue;
        this._testClass[_fixture.Create<Type>()].Should().BeSameAs(testValue);
    }
}