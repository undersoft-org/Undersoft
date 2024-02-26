using System;
using System.Collections.Generic;
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
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Operation.Command;
using Undersoft.SDK.Service.Server.Controller.Stream;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TKey = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests.Controller.Stream;

/// <summary>
/// Unit tests for the type <see cref="StreamEventController"/>.
/// </summary>
[TestClass]
public class StreamEventController_4Tests
{
    private class TestStreamEventController : StreamEventController<TKey, TStore, TEntity, TDto>
    {
        public TestStreamEventController() : base()
        {
        }

        public TestStreamEventController(IServicer servicer,
        Func<TDto, Expression<Func<TEntity, bool>>> predicate,
        Func<TKey, Func<TDto, object>> keysetter,
        Func<TKey, Expression<Func<TEntity, bool>>> keymatcher,
        EventPublishMode publishMode = EventPublishMode.PropagateCommand
    ) : base(servicer, predicate, keysetter, keymatcher, publishMode)
        {
        }
    }

    private TestStreamEventController _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;
    private Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
    private Func<TKey, Func<TDto, object>> _keysetter;
    private Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher;
    private EventPublishMode _publishMode;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="StreamEventController"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._predicate = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._keysetter = x => x => _fixture.Create<object>();
        this._keymatcher = x => _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._publishMode = _fixture.Create<EventPublishMode>();
        this._testClass = _fixture.Create<TestStreamEventController>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestStreamEventController();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestStreamEventController(this._servicer.Object, this._predicate, this._keysetter, this._keymatcher, this._publishMode);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new TestStreamEventController(default(IServicer), this._predicate, this._keysetter, this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new TestStreamEventController(this._servicer.Object, default(Func<TDto, Expression<Func<TEntity, bool>>>), this._keysetter, this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that instance construction throws when the keysetter parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeysetter()
    {
        FluentActions.Invoking(() => new TestStreamEventController(this._servicer.Object, this._predicate, default(Func<TKey, Func<TDto, object>>), this._keymatcher, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("keysetter");
    }

    /// <summary>
    /// Checks that instance construction throws when the keymatcher parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeymatcher()
    {
        FluentActions.Invoking(() => new TestStreamEventController(this._servicer.Object, this._predicate, this._keysetter, default(Func<TKey, Expression<Func<TEntity, bool>>>), this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("keymatcher");
    }

    /// <summary>
    /// Checks that the All method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAll()
    {
        // Arrange
        _servicer.Setup(mock => mock.CreateStream<TDto>(It.IsAny<IStreamRequest<TDto>>(), It.IsAny<CancellationToken>())).Returns(_fixture.Create<IAsyncEnumerable<TDto>>());

        // Act
        var result = this._testClass.All();

        // Assert
        _servicer.Verify(mock => mock.CreateStream<TDto>(It.IsAny<IStreamRequest<TDto>>(), It.IsAny<CancellationToken>()));

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
    /// Checks that the Query method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallQuery()
    {
        // Arrange
        var query = _fixture.Create<QuerySet>();

        _servicer.Setup(mock => mock.CreateStream<TDto>(It.IsAny<IStreamRequest<TDto>>(), It.IsAny<CancellationToken>())).Returns(_fixture.Create<IAsyncEnumerable<TDto>>());

        // Act
        var result = this._testClass.Query(query);

        // Assert
        _servicer.Verify(mock => mock.CreateStream<TDto>(It.IsAny<IStreamRequest<TDto>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Query method throws when the query parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallQueryWithNullQuery()
    {
        FluentActions.Invoking(() => this._testClass.Query(default(QuerySet))).Should().Throw<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that the Creates method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreates()
    {
        // Arrange
        var dtos = _fixture.Create<TDto[]>();

        _servicer.Setup(mock => mock.CreateStream<Command<TDto>>(It.IsAny<IStreamRequest<Command<TDto>>>(), It.IsAny<CancellationToken>())).Returns(_fixture.Create<IAsyncEnumerable<Command<TDto>>>());

        // Act
        var result = this._testClass.Creates(dtos);

        // Assert
        _servicer.Verify(mock => mock.CreateStream<Command<TDto>>(It.IsAny<IStreamRequest<Command<TDto>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Creates method throws when the dtos parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreatesWithNullDtos()
    {
        FluentActions.Invoking(() => this._testClass.Creates(default(TDto[]))).Should().Throw<ArgumentNullException>().WithParameterName("dtos");
    }

    /// <summary>
    /// Checks that the Changes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallChanges()
    {
        // Arrange
        var dtos = _fixture.Create<TDto[]>();

        _servicer.Setup(mock => mock.CreateStream<Command<TDto>>(It.IsAny<IStreamRequest<Command<TDto>>>(), It.IsAny<CancellationToken>())).Returns(_fixture.Create<IAsyncEnumerable<Command<TDto>>>());

        // Act
        var result = this._testClass.Changes(dtos);

        // Assert
        _servicer.Verify(mock => mock.CreateStream<Command<TDto>>(It.IsAny<IStreamRequest<Command<TDto>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Changes method throws when the dtos parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallChangesWithNullDtos()
    {
        FluentActions.Invoking(() => this._testClass.Changes(default(TDto[]))).Should().Throw<ArgumentNullException>().WithParameterName("dtos");
    }

    /// <summary>
    /// Checks that the Updates method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdates()
    {
        // Arrange
        var dtos = _fixture.Create<TDto[]>();

        _servicer.Setup(mock => mock.CreateStream<Command<TDto>>(It.IsAny<IStreamRequest<Command<TDto>>>(), It.IsAny<CancellationToken>())).Returns(_fixture.Create<IAsyncEnumerable<Command<TDto>>>());

        // Act
        var result = this._testClass.Updates(dtos);

        // Assert
        _servicer.Verify(mock => mock.CreateStream<Command<TDto>>(It.IsAny<IStreamRequest<Command<TDto>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Updates method throws when the dtos parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdatesWithNullDtos()
    {
        FluentActions.Invoking(() => this._testClass.Updates(default(TDto[]))).Should().Throw<ArgumentNullException>().WithParameterName("dtos");
    }

    /// <summary>
    /// Checks that the Deletes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeletes()
    {
        // Arrange
        var dtos = _fixture.Create<TDto[]>();

        _servicer.Setup(mock => mock.CreateStream<Command<TDto>>(It.IsAny<IStreamRequest<Command<TDto>>>(), It.IsAny<CancellationToken>())).Returns(_fixture.Create<IAsyncEnumerable<Command<TDto>>>());

        // Act
        var result = this._testClass.Deletes(dtos);

        // Assert
        _servicer.Verify(mock => mock.CreateStream<Command<TDto>>(It.IsAny<IStreamRequest<Command<TDto>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Deletes method throws when the dtos parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeletesWithNullDtos()
    {
        FluentActions.Invoking(() => this._testClass.Deletes(default(TDto[]))).Should().Throw<ArgumentNullException>().WithParameterName("dtos");
    }
}