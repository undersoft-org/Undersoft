using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Server.Controller.Api;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TKey = System.String;
using TModel = Undersoft.SDK.Stocks.StockContext;
using TResult = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests.Controller.Api;

/// <summary>
/// Unit tests for the type <see cref="ApiEventRemoteController"/>.
/// </summary>
[TestClass]
public class ApiEventRemoteController_4Tests
{
    private class TestApiEventRemoteController : ApiEventRemoteController<TKey, TStore, TDto, TModel>
    {
        public TestApiEventRemoteController(IServicer servicer) : base(servicer)
        {
        }

        public TestApiEventRemoteController(
                                                                        IServicer servicer,
                                                                        Func<TKey, Expression<Func<TDto, bool>>> keymatcher
                                                                    ) : base(servicer, keymatcher
                                                                )
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

    private TestApiEventRemoteController _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;
    private Func<TKey, Expression<Func<TDto, bool>>> _keymatcher;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ApiEventRemoteController"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._keymatcher = x => _fixture.Create<Expression<Func<TDto, bool>>>();
        this._testClass = _fixture.Create<TestApiEventRemoteController>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestApiEventRemoteController(this._servicer.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestApiEventRemoteController(this._servicer.Object, this._keymatcher);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new TestApiEventRemoteController(default(IServicer))).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
        FluentActions.Invoking(() => new TestApiEventRemoteController(default(IServicer), this._keymatcher)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that instance construction throws when the keymatcher parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeymatcher()
    {
        FluentActions.Invoking(() => new TestApiEventRemoteController(this._servicer.Object, default(Func<TKey, Expression<Func<TDto, bool>>>))).Should().Throw<ArgumentNullException>().WithParameterName("keymatcher");
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

        _servicer.Setup(mock => mock.Entry<ISeries<TModel>>(It.IsAny<IRequest<ISeries<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<ISeries<TModel>>());

        // Act
        var result = await this._testClass.Get(page, limit);

        // Assert
        _servicer.Verify(mock => mock.Entry<ISeries<TModel>>(It.IsAny<IRequest<ISeries<TModel>>>(), It.IsAny<CancellationToken>()));

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

        _servicer.Setup(mock => mock.Entry<TModel>(It.IsAny<IRequest<TModel>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<TModel>());

        // Act
        var result = await this._testClass.Get(key);

        // Assert
        _servicer.Verify(mock => mock.Entry<TModel>(It.IsAny<IRequest<TModel>>(), It.IsAny<CancellationToken>()));

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

        _servicer.Setup(mock => mock.Entry<ISeries<TModel>>(It.IsAny<IRequest<ISeries<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<ISeries<TModel>>());

        // Act
        var result = await this._testClass.Post(query);

        // Assert
        _servicer.Verify(mock => mock.Entry<ISeries<TModel>>(It.IsAny<IRequest<ISeries<TModel>>>(), It.IsAny<CancellationToken>()));

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

        _servicer.Setup(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<TResult>());

        // Act
        var result = await this._testClass.Post(dtos);

        // Assert
        _servicer.Verify(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>()));

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

        _servicer.Setup(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<TResult>());

        // Act
        var result = await this._testClass.Post(key, dto);

        // Assert
        _servicer.Verify(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>()));

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

        _servicer.Setup(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<TResult>());

        // Act
        var result = await this._testClass.Patch(dtos);

        // Assert
        _servicer.Verify(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>()));

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

        _servicer.Setup(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<TResult>());

        // Act
        var result = await this._testClass.Patch(key, dto);

        // Assert
        _servicer.Verify(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>()));

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

        _servicer.Setup(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<TResult>());

        // Act
        var result = await this._testClass.Put(dtos);

        // Assert
        _servicer.Verify(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>()));

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

        _servicer.Setup(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<TResult>());

        // Act
        var result = await this._testClass.Put(key, dto);

        // Assert
        _servicer.Verify(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>()));

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

        _servicer.Setup(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<TResult>());

        // Act
        var result = await this._testClass.Delete(dtos);

        // Assert
        _servicer.Verify(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>()));

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

        _servicer.Setup(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<TResult>());

        // Act
        var result = await this._testClass.Delete(key, dto);

        // Assert
        _servicer.Verify(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>()));

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

        _servicer.Setup(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<TResult>());

        // Act
        var result = await this._testClass.PublicExecuteSet<TResult>(request);

        // Assert
        _servicer.Verify(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>()));

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

        _servicer.Setup(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<TResult>());

        // Act
        var result = await this._testClass.PublicExecute<TResult>(request);

        // Assert
        _servicer.Verify(mock => mock.Send<TResult>(It.IsAny<IRequest<TResult>>(), It.IsAny<CancellationToken>()));

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