using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Operation.Remote.Command;
using Undersoft.SDK.Service.Server.Controller.Open;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TKey = System.String;
using TModel = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests.Controller.Open;

/// <summary>
/// Unit tests for the type <see cref="OpenEventRemoteController"/>.
/// </summary>
[TestClass]
public class OpenEventRemoteController_4Tests
{
    private class TestOpenEventRemoteController : OpenEventRemoteController<TKey, TStore, TDto, TModel>
    {
        public TestOpenEventRemoteController() : base()
        {
        }

        public TestOpenEventRemoteController(
        IServicer servicer,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : base(servicer, publishMode)
        {
        }

        public TestOpenEventRemoteController(
        IServicer servicer,
        Func<TModel, Expression<Func<TDto, bool>>> predicate,
        Func<TKey, Func<TModel, object>> keysetter,
        Func<TKey, Expression<Func<TDto, bool>>> keymatcher,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : base(servicer, predicate, keysetter, keymatcher, publishMode)
        {
        }
    }

    private TestOpenEventRemoteController _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;
    private EventPublishMode _publishMode;
    private Func<TModel, Expression<Func<TDto, bool>>> _predicate;
    private Func<TKey, Func<TModel, object>> _keysetter;
    private Func<TKey, Expression<Func<TDto, bool>>> _keymatcher;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="OpenEventRemoteController"/>.
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
        this._testClass = _fixture.Create<TestOpenEventRemoteController>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestOpenEventRemoteController();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestOpenEventRemoteController(this._servicer.Object, this._publishMode);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestOpenEventRemoteController(this._servicer.Object, this._predicate, this._keysetter, this._keymatcher, this._publishMode);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new TestOpenEventRemoteController(default(IServicer), this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
        FluentActions.Invoking(() => new TestOpenEventRemoteController(default(IServicer), this._predicate, this._keysetter, this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new TestOpenEventRemoteController(this._servicer.Object, default(Func<TModel, Expression<Func<TDto, bool>>>), this._keysetter, this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that instance construction throws when the keysetter parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeysetter()
    {
        FluentActions.Invoking(() => new TestOpenEventRemoteController(this._servicer.Object, this._predicate, default(Func<TKey, Func<TModel, object>>), this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("keysetter");
    }

    /// <summary>
    /// Checks that instance construction throws when the keymatcher parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeymatcher()
    {
        FluentActions.Invoking(() => new TestOpenEventRemoteController(this._servicer.Object, this._predicate, this._keysetter, default(Func<TKey, Expression<Func<TDto, bool>>>), this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("keymatcher");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithNoParameters()
    {
        // Arrange
        _servicer.Setup(mock => mock.Report<IQueryable<TModel>>(It.IsAny<IRequest<IQueryable<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<IQueryable<TModel>>());

        // Act
        var result = this._testClass.Get();

        // Assert
        _servicer.Verify(mock => mock.Report<IQueryable<TModel>>(It.IsAny<IRequest<IQueryable<TModel>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallGetWithTKeyAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();

        _servicer.Setup(mock => mock.Report<IQueryable<TModel>>(It.IsAny<IRequest<IQueryable<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<IQueryable<TModel>>());

        // Act
        var result = await this._testClass.Get(key);

        // Assert
        _servicer.Verify(mock => mock.Report<IQueryable<TModel>>(It.IsAny<IRequest<IQueryable<TModel>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Post method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPostAsync()
    {
        // Arrange
        var dto = _fixture.Create<TModel>();

        _servicer.Setup(mock => mock.Send<RemoteCommand<TModel>>(It.IsAny<IRequest<RemoteCommand<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<RemoteCommand<TModel>>());

        // Act
        var result = await this._testClass.Post(dto);

        // Assert
        _servicer.Verify(mock => mock.Send<RemoteCommand<TModel>>(It.IsAny<IRequest<RemoteCommand<TModel>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Post method throws when the dto parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPostWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Post(default(TModel))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPatchAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();
        var dto = _fixture.Create<TModel>();

        _servicer.Setup(mock => mock.Send<RemoteCommand<TModel>>(It.IsAny<IRequest<RemoteCommand<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<RemoteCommand<TModel>>());

        // Act
        var result = await this._testClass.Patch(key, dto);

        // Assert
        _servicer.Verify(mock => mock.Send<RemoteCommand<TModel>>(It.IsAny<IRequest<RemoteCommand<TModel>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Patch method throws when the dto parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPatchWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Patch(_fixture.Create<TKey>(), default(TModel))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPutAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();
        var dto = _fixture.Create<TModel>();

        _servicer.Setup(mock => mock.Send<RemoteCommand<TModel>>(It.IsAny<IRequest<RemoteCommand<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<RemoteCommand<TModel>>());

        // Act
        var result = await this._testClass.Put(key, dto);

        // Assert
        _servicer.Verify(mock => mock.Send<RemoteCommand<TModel>>(It.IsAny<IRequest<RemoteCommand<TModel>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the dto parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPutWithNullDtoAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Put(_fixture.Create<TKey>(), default(TModel))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("dto");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDeleteAsync()
    {
        // Arrange
        var key = _fixture.Create<TKey>();

        _servicer.Setup(mock => mock.Send<RemoteCommand<TModel>>(It.IsAny<IRequest<RemoteCommand<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<RemoteCommand<TModel>>());

        // Act
        var result = await this._testClass.Delete(key);

        // Assert
        _servicer.Verify(mock => mock.Send<RemoteCommand<TModel>>(It.IsAny<IRequest<RemoteCommand<TModel>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }
}