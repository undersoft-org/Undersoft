using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Data.Client;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Data.Repository.Client;
using TEntity = System.String;
using TModel = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Remote.Repository;

/// <summary>
/// Unit tests for the type <see cref="RemoteRepository"/>.
/// </summary>
public partial class RemoteRepository_1Tests
{
    private RemoteRepository<TEntity> _testClass;
    private IFixture _fixture;
    private Mock<IRepositoryContextPool<OpenDataClient<TStore>>> _pool;
    private Mock<IEntityCache<TStore, TEntity>> _cache;
    private Mock<IAuthorization> _authorization;
    private Mock<IRepositoryClient> _repositorySource;
    private OpenDataContext _contextOpenDataContext;
    private Mock<IRepositoryContextPool> _contextIRepositoryContextPool;
    private Mock<IQueryProvider> _provider;
    private Expression _expression;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteRepository"/>.
    /// </summary>
    public RemoteRepository_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._pool = _fixture.Freeze<Mock<IRepositoryContextPool<OpenDataClient<TStore>>>>();
        this._cache = _fixture.Freeze<Mock<IEntityCache<TStore, TEntity>>>();
        this._authorization = _fixture.Freeze<Mock<IAuthorization>>();
        this._repositorySource = _fixture.Freeze<Mock<IRepositoryClient>>();
        this._contextOpenDataContext = _fixture.Create<OpenDataContext>();
        this._contextIRepositoryContextPool = _fixture.Freeze<Mock<IRepositoryContextPool>>();
        this._provider = _fixture.Freeze<Mock<IQueryProvider>>();
        this._expression = _fixture.Create<Expression>();
        this._testClass = _fixture.Create<RemoteRepository<TEntity>>();
    }

    /// <summary>
    /// Checks that the Setup method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetupAsync()
    {
        // Arrange
        var @method = _fixture.Create<string>();
        var arguments = _fixture.Create<TModel>();

        // Act
        var result = await this._testClass.Setup<TModel>(method, arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Setup method throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSetupWithInvalidMethodAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Setup<TModel>(value, _fixture.Create<TModel>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Access method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAccessAsync()
    {
        // Arrange
        var @method = _fixture.Create<string>();
        var arguments = _fixture.Create<TModel>();

        // Act
        var result = await this._testClass.Access<TModel>(method, arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Access method throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallAccessWithInvalidMethodAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Access<TModel>(value, _fixture.Create<TModel>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Action method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallActionAsync()
    {
        // Arrange
        var @method = _fixture.Create<string>();
        var arguments = _fixture.Create<TModel>();

        // Act
        var result = await this._testClass.Action<TModel>(method, arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Action method throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallActionWithInvalidMethodAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Action<TModel>(value, _fixture.Create<TModel>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("method");
    }
}