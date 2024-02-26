using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Operation.Remote.Invocation;
using Undersoft.SDK.Service.Operation.Remote.Invocation.Handler;
using Undersoft.SDK.Service.Operation.Remote.Invocation.Notification;
using TModel = Undersoft.SDK.Stocks.StockContext;
using TService = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Invocation.Handler;

/// <summary>
/// Unit tests for the type <see cref="RemoteActionHandler"/>.
/// </summary>
public class RemoteActionHandler_3Tests
{
    private RemoteActionHandler<TStore, TService, TModel> _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;
    private Mock<IRemoteRepository<TStore, TModel>> _repository;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteActionHandler"/>.
    /// </summary>
    public RemoteActionHandler_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._repository = _fixture.Freeze<Mock<IRemoteRepository<TStore, TModel>>>();
        this._testClass = _fixture.Create<RemoteActionHandler<TStore, TService, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteActionHandler<TStore, TService, TModel>(this._servicer.Object, this._repository.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new RemoteActionHandler<TStore, TService, TModel>(default(IServicer), this._repository.Object)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that instance construction throws when the repository parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepository()
    {
        FluentActions.Invoking(() => new RemoteActionHandler<TStore, TService, TModel>(this._servicer.Object, default(IRemoteRepository<TStore, TModel>))).Should().Throw<ArgumentNullException>().WithParameterName("repository");
    }

    /// <summary>
    /// Checks that the Handle method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHandleAsync()
    {
        // Arrange
        var request = _fixture.Create<RemoteAction<TStore, TService, TModel>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Handle(request, cancellationToken
        );

        // Assert
        _servicer.Verify(mock => mock.Publish<RemoteActionInvoked<TStore, TService, TModel>>(It.IsAny<RemoteActionInvoked<TStore, TService, TModel>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Handle method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallHandleWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Handle(default(RemoteAction<TStore, TService, TModel>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }
}