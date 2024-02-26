using System;
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
using Undersoft.SDK.Service.Server.Controller.Api;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TKey = System.String;
using TModel = Undersoft.SDK.Stocks.StockContext;
using TResult = System.String;
using TService = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests.Controller.Api;

/// <summary>
/// Unit tests for the type <see cref="ApiDataRemoteController"/>.
/// </summary>
[TestClass]
public class ApiDataRemoteController_5Tests
{
    private class TestApiDataRemoteController : ApiDataRemoteController<TKey, TStore, TDto, TModel, TService>
    {
        public TestApiDataRemoteController() : base()
        {
        }

        public TestApiDataRemoteController(
        IServicer servicer,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : base(servicer, publishMode)
        {
        }

        public TestApiDataRemoteController(
        IServicer servicer,
        Func<TModel, Expression<Func<TDto, bool>>> predicate
    ) : base(servicer, predicate
)
        {
        }

        public TestApiDataRemoteController(
        IServicer servicer,
        Func<TModel, Expression<Func<TDto, bool>>> predicate,
        Func<TKey, Func<TModel, object>> keysetter,
        Func<TKey, Expression<Func<TDto, bool>>> keymatcher,
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

    private TestApiDataRemoteController _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;
    private EventPublishMode _publishMode;
    private Func<TModel, Expression<Func<TDto, bool>>> _predicate;
    private Func<TKey, Func<TModel, object>> _keysetter;
    private Func<TKey, Expression<Func<TDto, bool>>> _keymatcher;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ApiDataRemoteController"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._publishMode = _fixture.Create<EventPublishMode>();
        this._predicate = x => _fixture.Create<Expression<Func<TDto, bool>>>();
        this._keysetter = x => x => _fixture.Create<object>();
        this._keymatcher = x => _fixture.Create<Expression<Func<TDto, bool>>>();
        this._testClass = _fixture.Create<TestApiDataRemoteController>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestApiDataRemoteController();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestApiDataRemoteController(this._servicer.Object, this._publishMode);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestApiDataRemoteController(this._servicer.Object, this._predicate);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestApiDataRemoteController(this._servicer.Object, this._predicate, this._keysetter, this._keymatcher, this._publishMode);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new TestApiDataRemoteController(default(IServicer), this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
        FluentActions.Invoking(() => new TestApiDataRemoteController(default(IServicer), this._predicate)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
        FluentActions.Invoking(() => new TestApiDataRemoteController(default(IServicer), this._predicate, this._keysetter, this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new TestApiDataRemoteController(this._servicer.Object, default(Func<TModel, Expression<Func<TDto, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
        FluentActions.Invoking(() => new TestApiDataRemoteController(this._servicer.Object, default(Func<TModel, Expression<Func<TDto, bool>>>), this._keysetter, this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that instance construction throws when the keysetter parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeysetter()
    {
        FluentActions.Invoking(() => new TestApiDataRemoteController(this._servicer.Object, this._predicate, default(Func<TKey, Func<TModel, object>>), this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("keysetter");
    }

    /// <summary>
    /// Checks that instance construction throws when the keymatcher parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeymatcher()
    {
        FluentActions.Invoking(() => new TestApiDataRemoteController(this._servicer.Object, this._predicate, this._keysetter, default(Func<TKey, Expression<Func<TDto, bool>>>), this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("keymatcher");
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
    public async Task CanCallPostWithArrayOfTModelAsync()
    {
        // Arrange
        var dtos = _fixture.Create<TModel[]>();

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
    public async Task CannotCallPostWithArrayOfTModelWithNullDtosAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Post(default(TModel[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dtos");
    }

    /// <summary>
    /// Checks that the Post method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPostWithTKeyAndTModelAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();
        var dto = _fixture.Create<TModel>();

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
    public async Task CannotCallPostWithTKeyAndTModelWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Post(_fixture.Create<TKey>(), default(TModel))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPatchWithArrayOfTModelAsync()
    {
        // Arrange
        var dtos = _fixture.Create<TModel[]>();

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
    public async Task CannotCallPatchWithArrayOfTModelWithNullDtosAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Patch(default(TModel[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dtos");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPatchWithTKeyAndTModelAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();
        var dto = _fixture.Create<TModel>();

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
    public async Task CannotCallPatchWithTKeyAndTModelWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Patch(_fixture.Create<TKey>(), default(TModel))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPutWithArrayOfTModelAsync()
    {
        // Arrange
        var dtos = _fixture.Create<TModel[]>();

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
    public async Task CannotCallPutWithArrayOfTModelWithNullDtosAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Put(default(TModel[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dtos");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPutWithTKeyAndTModelAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();
        var dto = _fixture.Create<TModel>();

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
    public async Task CannotCallPutWithTKeyAndTModelWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Put(_fixture.Create<TKey>(), default(TModel))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDeleteWithArrayOfTModelAsync()
    {
        // Arrange
        var dtos = _fixture.Create<TModel[]>();

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
    public async Task CannotCallDeleteWithArrayOfTModelWithNullDtosAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Delete(default(TModel[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dtos");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDeleteWithTKeyAndTModelAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();
        var dto = _fixture.Create<TModel>();

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
    public async Task CannotCallDeleteWithTKeyAndTModelWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Delete(_fixture.Create<TKey>(), default(TModel))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
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
}