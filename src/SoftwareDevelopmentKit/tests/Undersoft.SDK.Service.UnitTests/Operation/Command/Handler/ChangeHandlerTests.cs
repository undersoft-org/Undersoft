using System;
using System.Threading;
using System.Threading.Tasks;
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
/// Unit tests for the type <see cref="ChangeHandler"/>.
/// </summary>
public class ChangeHandler_3Tests
{
    private ChangeHandler<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;
    private Mock<IStoreRepository<TStore, TEntity>> _repository;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ChangeHandler"/>.
    /// </summary>
    public ChangeHandler_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._repository = _fixture.Freeze<Mock<IStoreRepository<TStore, TEntity>>>();
        this._testClass = _fixture.Create<ChangeHandler<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ChangeHandler<TStore, TEntity, TDto>(this._servicer.Object, this._repository.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new ChangeHandler<TStore, TEntity, TDto>(default(IServicer), this._repository.Object)).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that instance construction throws when the repository parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepository()
    {
        FluentActions.Invoking(() => new ChangeHandler<TStore, TEntity, TDto>(this._servicer.Object, default(IStoreRepository<TStore, TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("repository");
    }

    /// <summary>
    /// Checks that the Handle method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHandleAsync()
    {
        // Arrange
        var request = _fixture.Create<Change<TStore, TEntity, TDto>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Handle(request, cancellationToken
        );

        // Assert
        _servicer.Verify(mock => mock.Publish<Changed<TStore, TEntity, TDto>>(It.IsAny<Changed<TStore, TEntity, TDto>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Handle method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallHandleWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Handle(default(Change<TStore, TEntity, TDto>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }
}