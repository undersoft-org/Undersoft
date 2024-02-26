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
using Undersoft.SDK.Service.Operation.Remote.Command.Notification;
using Undersoft.SDK.Service.Operation.Remote.Command.Notification.Handler;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TModel = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Command.Notification.Handler;

/// <summary>
/// Unit tests for the type <see cref="RemoteChangedSetHandler"/>.
/// </summary>
public class RemoteChangedSetHandler_3Tests
{
    private RemoteChangedSetHandler<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private Mock<IStoreRepository<IEventStore, Event>> _eventStore;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteChangedSetHandler"/>.
    /// </summary>
    public RemoteChangedSetHandler_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._eventStore = _fixture.Freeze<Mock<IStoreRepository<IEventStore, Event>>>();
        this._testClass = _fixture.Create<RemoteChangedSetHandler<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteChangedSetHandler<TStore, TDto, TModel>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteChangedSetHandler<TStore, TDto, TModel>(this._eventStore.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the eventStore parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEventStore()
    {
        FluentActions.Invoking(() => new RemoteChangedSetHandler<TStore, TDto, TModel>(default(IStoreRepository<IEventStore, Event>))).Should().Throw<ArgumentNullException>().WithParameterName("eventStore");
    }

    /// <summary>
    /// Checks that the Handle method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHandleAsync()
    {
        // Arrange
        var request = _fixture.Create<RemoteChangedSet<TStore, TDto, TModel>>();
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
        await FluentActions.Invoking(() => this._testClass.Handle(default(RemoteChangedSet<TStore, TDto, TModel>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }
}