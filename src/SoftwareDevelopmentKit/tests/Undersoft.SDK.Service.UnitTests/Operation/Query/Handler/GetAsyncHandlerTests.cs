using System;
using System.Threading;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Store.Repository;
using Undersoft.SDK.Service.Operation.Query;
using Undersoft.SDK.Service.Operation.Query.Handler;
using TDto = System.String;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Query.Handler;

/// <summary>
/// Unit tests for the type <see cref="GetAsyncHandler"/>.
/// </summary>
public class GetAsyncHandler_3Tests
{
    private GetAsyncHandler<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private Mock<IStoreRepository<TStore, TEntity>> _repository;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="GetAsyncHandler"/>.
    /// </summary>
    public GetAsyncHandler_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._repository = _fixture.Freeze<Mock<IStoreRepository<TStore, TEntity>>>();
        this._testClass = _fixture.Create<GetAsyncHandler<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new GetAsyncHandler<TStore, TEntity, TDto>(this._repository.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the repository parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepository()
    {
        FluentActions.Invoking(() => new GetAsyncHandler<TStore, TEntity, TDto>(default(IStoreRepository<TStore, TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("repository");
    }

    /// <summary>
    /// Checks that the Handle method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallHandle()
    {
        // Arrange
        var request = _fixture.Create<GetAsync<TStore, TEntity, TDto>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = this._testClass.Handle(request, cancellationToken
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Handle method throws when the request parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallHandleWithNullRequest()
    {
        FluentActions.Invoking(() => this._testClass.Handle(default(GetAsync<TStore, TEntity, TDto>), _fixture.Create<CancellationToken>())).Should().Throw<ArgumentNullException>().WithParameterName("request");
    }
}