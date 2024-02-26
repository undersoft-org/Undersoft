using System;
using System.Threading;
using System.Threading.Tasks;
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
/// Unit tests for the type <see cref="GetHandler"/>.
/// </summary>
public class GetHandler_3Tests
{
    private GetHandler<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private Mock<IStoreRepository<TStore, TEntity>> _repository;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="GetHandler"/>.
    /// </summary>
    public GetHandler_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._repository = _fixture.Freeze<Mock<IStoreRepository<TStore, TEntity>>>();
        this._testClass = _fixture.Create<GetHandler<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new GetHandler<TStore, TEntity, TDto>(this._repository.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the repository parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepository()
    {
        FluentActions.Invoking(() => new GetHandler<TStore, TEntity, TDto>(default(IStoreRepository<TStore, TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("repository");
    }

    /// <summary>
    /// Checks that the Handle method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHandleAsync()
    {
        // Arrange
        var request = _fixture.Create<Get<TStore, TEntity, TDto>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Handle(request, cancellationToken
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
        await FluentActions.Invoking(() => this._testClass.Handle(default(Get<TStore, TEntity, TDto>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }
}