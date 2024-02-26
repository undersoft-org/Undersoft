using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Data.Store.Repository;
using Undersoft.SDK.Service.Operation.Command.Notification;
using Undersoft.SDK.Service.Operation.Command.Notification.Handler;
using TCommand = Undersoft.SDK.Stocks.StockContext;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command.Notification.Handler;

/// <summary>
/// Unit tests for the type <see cref="ChangedHandler"/>.
/// </summary>
public class ChangedHandler_3Tests
{
    private ChangedHandler<TStore, TEntity, TCommand> _testClass;
    private IFixture _fixture;
    private Mock<IStoreRepository<IReportStore, TEntity>> _repository;
    private Mock<IStoreRepository<IEventStore, Event>> _eventStore;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ChangedHandler"/>.
    /// </summary>
    public ChangedHandler_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._repository = _fixture.Freeze<Mock<IStoreRepository<IReportStore, TEntity>>>();
        this._eventStore = _fixture.Freeze<Mock<IStoreRepository<IEventStore, Event>>>();
        this._testClass = _fixture.Create<ChangedHandler<TStore, TEntity, TCommand>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ChangedHandler<TStore, TEntity, TCommand>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ChangedHandler<TStore, TEntity, TCommand>(this._repository.Object, this._eventStore.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the repository parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepository()
    {
        FluentActions.Invoking(() => new ChangedHandler<TStore, TEntity, TCommand>(default(IStoreRepository<IReportStore, TEntity>), this._eventStore.Object)).Should().Throw<ArgumentNullException>().WithParameterName("repository");
    }

    /// <summary>
    /// Checks that instance construction throws when the eventStore parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEventStore()
    {
        FluentActions.Invoking(() => new ChangedHandler<TStore, TEntity, TCommand>(this._repository.Object, default(IStoreRepository<IEventStore, Event>))).Should().Throw<ArgumentNullException>().WithParameterName("eventStore");
    }

    /// <summary>
    /// Checks that the Handle method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHandleAsync()
    {
        // Arrange
        var request = _fixture.Create<Changed<TStore, TEntity, TCommand>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.Handle(request, cancellationToken
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Handle method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallHandleWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Handle(default(Changed<TStore, TEntity, TCommand>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }
}