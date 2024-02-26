using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Server.Controller.Api;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TKey = System.String;
using TResult = System.String;
using TService = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests.Controller.Api;

/// <summary>
/// Unit tests for the type <see cref="ApiDataController"/>.
/// </summary>
[TestClass]
public class ApiDataController_5Tests
{
    private class TestApiDataController : ApiDataController<TKey, TStore, TEntity, TDto, TService>
    {
        public TestApiDataController() : base()
        {
        }

        public TestApiDataController(IServicer servicer) : base(servicer)
        {
        }

        public TestApiDataController(
        IServicer servicer,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : base(servicer, publishMode)
        {
        }

        public TestApiDataController(
        IServicer servicer,
        Func<TDto, Expression<Func<TEntity, bool>>> predicate,
        Func<TKey, Func<TDto, object>> keysetter,
        Func<TKey, Expression<Func<TEntity, bool>>> keymatcher,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : base(servicer, predicate, keysetter, keymatcher, publishMode)
        {
        }

        public Task<IActionResult> PublicExecuteSet<TResult>(IRequest<TResult> request)
        {
            return base.ExecuteSet<TResult>(request);
        }

        public Task<IActionResult> PublicExecute<TResult>(IRequest<TResult> request)
        {
            return base.Execute<TResult>(request);
        }
    }

    private TestApiDataController _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;
    private EventPublishMode _publishMode;
    private Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
    private Func<TKey, Func<TDto, object>> _keysetter;
    private Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ApiDataController"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._publishMode = _fixture.Create<EventPublishMode>();
        this._predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._keysetter = x => x => _fixture.Create<object>();
        this._keymatcher = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._testClass = _fixture.Create<TestApiDataController>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestApiDataController();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestApiDataController(this._servicer.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestApiDataController(this._servicer.Object, this._publishMode);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestApiDataController(this._servicer.Object, this._predicate, this._keysetter, this._keymatcher, this._publishMode);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new TestApiDataController(default(IServicer))).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
        FluentActions.Invoking(() => new TestApiDataController(default(IServicer), this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
        FluentActions.Invoking(() => new TestApiDataController(default(IServicer), this._predicate, this._keysetter, this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new TestApiDataController(this._servicer.Object, default(Func<TDto, Expression<Func<TEntity, bool>>>), this._keysetter, this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that instance construction throws when the keysetter parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeysetter()
    {
        FluentActions.Invoking(() => new TestApiDataController(this._servicer.Object, this._predicate, default(Func<TKey, Func<TDto, object>>), this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("keysetter");
    }

    /// <summary>
    /// Checks that instance construction throws when the keymatcher parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeymatcher()
    {
        FluentActions.Invoking(() => new TestApiDataController(this._servicer.Object, this._predicate, this._keysetter, default(Func<TKey, Expression<Func<TEntity, bool>>>), this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("keymatcher");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetWithPageAndLimitAsync()
    {
        // Arrange
        var page = _fixture.Create<int>();
        var limit = _fixture.Create<int>();

        // Act
        var result = await this._testClass.Get(page, limit);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Count method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallCountAsync()
    {
        // Act
        var result = await this._testClass.Count();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetWithKeyAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();

        // Act
        var result = await this._testClass.Get(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Post method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPostWithQueryAsync()
    {
        // Arrange
        var query = _fixture.Create<QuerySet>();

        // Act
        var result = await this._testClass.Post(query);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Post method throws when the query parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPostWithQueryWithNullQueryAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Post(default(QuerySet))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that the Post method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPostWithArrayOfTDtoAsync()
    {
        // Arrange
        var dtos = _fixture.Create<TDto[]>();

        // Act
        var result = await this._testClass.Post(dtos);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Post method throws when the dtos parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPostWithArrayOfTDtoWithNullDtosAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Post(default(TDto[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dtos");
    }

    /// <summary>
    /// Checks that the Post method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPostWithTKeyAndTDtoAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();
        var dto = _fixture.Create<TDto>();

        // Act
        var result = await this._testClass.Post(key, dto);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Post method throws when the dto parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPostWithTKeyAndTDtoWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Post(_fixture.Create<TKey>(), default(TDto))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPatchWithArrayOfTDtoAsync()
    {
        // Arrange
        var dtos = _fixture.Create<TDto[]>();

        // Act
        var result = await this._testClass.Patch(dtos);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Patch method throws when the dtos parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchWithArrayOfTDtoWithNullDtosAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Patch(default(TDto[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dtos");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPatchWithTKeyAndTDtoAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();
        var dto = _fixture.Create<TDto>();

        // Act
        var result = await this._testClass.Patch(key, dto);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Patch method throws when the dto parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchWithTKeyAndTDtoWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Patch(_fixture.Create<TKey>(), default(TDto))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPutWithArrayOfTDtoAsync()
    {
        // Arrange
        var dtos = _fixture.Create<TDto[]>();

        // Act
        var result = await this._testClass.Put(dtos);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the dtos parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPutWithArrayOfTDtoWithNullDtosAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Put(default(TDto[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dtos");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPutWithTKeyAndTDtoAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();
        var dto = _fixture.Create<TDto>();

        // Act
        var result = await this._testClass.Put(key, dto);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the dto parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPutWithTKeyAndTDtoWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Put(_fixture.Create<TKey>(), default(TDto))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDeleteWithArrayOfTDtoAsync()
    {
        // Arrange
        var dtos = _fixture.Create<TDto[]>();

        // Act
        var result = await this._testClass.Delete(dtos);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Delete method throws when the dtos parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallDeleteWithArrayOfTDtoWithNullDtosAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Delete(default(TDto[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dtos");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDeleteWithTKeyAndTDtoAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();
        var dto = _fixture.Create<TDto>();

        // Act
        var result = await this._testClass.Delete(key, dto);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Delete method throws when the dto parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallDeleteWithTKeyAndTDtoWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Delete(_fixture.Create<TKey>(), default(TDto))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
    }

    /// <summary>
    /// Checks that the PublicExecuteSet method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExecuteSetAsync()
    {
        // Arrange
        var request = _fixture.Create<IRequest<TResult>>();

        // Act
        var result = await this._testClass.PublicExecuteSet<TResult>(request);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicExecuteSet method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExecuteSetWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicExecuteSet<TResult>(default(IRequest<TResult>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }

    /// <summary>
    /// Checks that the PublicExecute method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExecuteAsync()
    {
        // Arrange
        var request = _fixture.Create<IRequest<TResult>>();

        // Act
        var result = await this._testClass.PublicExecute<TResult>(request);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicExecute method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallExecuteWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.PublicExecute<TResult>(default(IRequest<TResult>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }

    /// <summary>
    /// Checks that the Transformations property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTransformations()
    {
        // Arrange
        Func<IRepository<TEntity>, IQueryable<TEntity>> testValue = x => _fixture.Create<IQueryable<TEntity>>();

        // Act
        this._testClass.Transformations = testValue;

        // Assert
        this._testClass.Transformations.Should().BeSameAs(testValue);
    }
}