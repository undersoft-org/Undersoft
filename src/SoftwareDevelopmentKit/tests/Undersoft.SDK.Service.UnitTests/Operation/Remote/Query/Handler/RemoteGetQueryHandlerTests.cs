using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Operation.Remote.Query;
using Undersoft.SDK.Service.Operation.Remote.Query.Handler;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TModel = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Query.Handler;

/// <summary>
/// Unit tests for the type <see cref="RemoteGetQueryHandler"/>.
/// </summary>
public class RemoteGetQueryHandler_3Tests
{
    private RemoteGetQueryHandler<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private Mock<IRemoteRepository<TStore, TDto>> _repository;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteGetQueryHandler"/>.
    /// </summary>
    public RemoteGetQueryHandler_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._repository = _fixture.Freeze<Mock<IRemoteRepository<TStore, TDto>>>();
        this._testClass = _fixture.Create<RemoteGetQueryHandler<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteGetQueryHandler<TStore, TDto, TModel>(this._repository.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the repository parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepository()
    {
        FluentActions.Invoking(() => new RemoteGetQueryHandler<TStore, TDto, TModel>(default(IRemoteRepository<TStore, TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("repository");
    }

    /// <summary>
    /// Checks that the Handle method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHandleAsync()
    {
        // Arrange
        var request = _fixture.Create<RemoteGetQuery<TStore, TDto, TModel>>();
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
        await FluentActions.Invoking(() => this._testClass.Handle(default(RemoteGetQuery<TStore, TDto, TModel>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }
}