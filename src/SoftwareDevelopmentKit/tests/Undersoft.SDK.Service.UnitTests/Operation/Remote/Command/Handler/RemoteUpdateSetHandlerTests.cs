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
using Undersoft.SDK.Service.Operation.Remote.Command;
using Undersoft.SDK.Service.Operation.Remote.Command.Handler;
using Undersoft.SDK.Service.Operation.Remote.Command.Notification;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TModel = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Command.Handler;

/// <summary>
/// Unit tests for the type <see cref="RemoteUpdateSetHandler"/>.
/// </summary>
public class RemoteUpdateSetHandler_3Tests
{
    private RemoteUpdateSetHandler<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;
    private Mock<IRemoteRepository<TStore, TDto>> _repository;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteUpdateSetHandler"/>.
    /// </summary>
    public RemoteUpdateSetHandler_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._repository = _fixture.Freeze<Mock<IRemoteRepository<TStore, TDto>>>();
        this._testClass = _fixture.Create<RemoteUpdateSetHandler<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteUpdateSetHandler<TStore, TDto, TModel>(this._servicer.Object, this._repository.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new RemoteUpdateSetHandler<TStore, TDto, TModel>(default(IServicer), this._repository.Object)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that instance construction throws when the repository parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepository()
    {
        FluentActions.Invoking(() => new RemoteUpdateSetHandler<TStore, TDto, TModel>(this._servicer.Object, default(IRemoteRepository<TStore, TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("repository");
    }

    /// <summary>
    /// Checks that the Handle method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHandleAsync()
    {
        // Arrange
        var request = _fixture.Create<RemoteUpdateSet<TStore, TDto, TModel>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Handle(request, cancellationToken
        );

        // Assert
        _servicer.Verify(mock => mock.Publish<RemoteUpdatedSet<TStore, TDto, TModel>>(It.IsAny<RemoteUpdatedSet<TStore, TDto, TModel>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Handle method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallHandleWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Handle(default(RemoteUpdateSet<TStore, TDto, TModel>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }
}