using System;
using System.Threading;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Store.Repository;
using Undersoft.SDK.Service.Operation.Command;
using Undersoft.SDK.Service.Operation.Command.Handler;
using Undersoft.SDK.Service.Operation.Command.Notification;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command.Handler;

/// <summary>
/// Unit tests for the type <see cref="ChangeSetAsyncHandler"/>.
/// </summary>
public class ChangeSetAsyncHandler_3Tests
{
    private ChangeSetAsyncHandler<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;
    private Mock<IStoreRepository<TStore, TEntity>> _repository;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ChangeSetAsyncHandler"/>.
    /// </summary>
    public ChangeSetAsyncHandler_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._repository = _fixture.Freeze<Mock<IStoreRepository<TStore, TEntity>>>();
        this._testClass = _fixture.Create<ChangeSetAsyncHandler<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ChangeSetAsyncHandler<TStore, TEntity, TDto>(this._servicer.Object, this._repository.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new ChangeSetAsyncHandler<TStore, TEntity, TDto>(default(IServicer), this._repository.Object)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that instance construction throws when the repository parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepository()
    {
        FluentActions.Invoking(() => new ChangeSetAsyncHandler<TStore, TEntity, TDto>(this._servicer.Object, default(IStoreRepository<TStore, TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("repository");
    }

    /// <summary>
    /// Checks that the Handle method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallHandle()
    {
        // Arrange
        var request = _fixture.Create<ChangeSetAsync<TStore, TEntity, TDto>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = this._testClass.Handle(request, cancellationToken
        );

        // Assert
        _servicer.Verify(mock => mock.Publish<ChangedSet<TStore, TEntity, TDto>>(It.IsAny<ChangedSet<TStore, TEntity, TDto>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Handle method throws when the request parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallHandleWithNullRequest()
    {
        FluentActions.Invoking(() => this._testClass.Handle(default(ChangeSetAsync<TStore, TEntity, TDto>), _fixture.Create<CancellationToken>())).Should().Throw<ArgumentNullException>().WithParameterName("request");
    }
}