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
using Undersoft.SDK.Service.Operation.Remote.Invocation.Notification;
using Undersoft.SDK.Service.Operation.Remote.Invocation.Notification.Handler;
using TModel = Undersoft.SDK.Origin;
using TService = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Invocation.Notification.Handler;

/// <summary>
/// Unit tests for the type <see cref="RemoteActionInvokedHandler"/>.
/// </summary>
public class RemoteActionInvokedHandler_3Tests
{
    private RemoteActionInvokedHandler<TStore, TService, TModel> _testClass;
    private IFixture _fixture;
    private Mock<IStoreRepository<IEventStore, Event>> _eventStore;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteActionInvokedHandler"/>.
    /// </summary>
    public RemoteActionInvokedHandler_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._eventStore = _fixture.Freeze<Mock<IStoreRepository<IEventStore, Event>>>();
        this._testClass = _fixture.Create<RemoteActionInvokedHandler<TStore, TService, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteActionInvokedHandler<TStore, TService, TModel>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteActionInvokedHandler<TStore, TService, TModel>(this._eventStore.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the eventStore parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEventStore()
    {
        FluentActions.Invoking(() => new RemoteActionInvokedHandler<TStore, TService, TModel>(default(IStoreRepository<IEventStore, Event>))).Should().Throw<ArgumentNullException>().WithParameterName("eventStore");
    }

    /// <summary>
    /// Checks that the Handle method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHandleAsync()
    {
        // Arrange
        var request = _fixture.Create<RemoteActionInvoked<TStore, TService, TModel>>();
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
        await FluentActions.Invoking(() => this._testClass.Handle(default(RemoteActionInvoked<TStore, TService, TModel>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }
}