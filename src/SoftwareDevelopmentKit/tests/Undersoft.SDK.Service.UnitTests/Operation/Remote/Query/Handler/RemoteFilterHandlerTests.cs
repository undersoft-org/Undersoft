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
/// Unit tests for the type <see cref="RemoteFilterHandler"/>.
/// </summary>
public class RemoteFilterHandler_3Tests
{
    private RemoteFilterHandler<TStore, TDto, TModel> _testClass;
    private IFixture _fixture;
    private Mock<IRemoteRepository<TStore, TDto>> _repository;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteFilterHandler"/>.
    /// </summary>
    public RemoteFilterHandler_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._repository = _fixture.Freeze<Mock<IRemoteRepository<TStore, TDto>>>();
        this._testClass = _fixture.Create<RemoteFilterHandler<TStore, TDto, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteFilterHandler<TStore, TDto, TModel>(this._repository.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the repository parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRepository()
    {
        FluentActions.Invoking(() => new RemoteFilterHandler<TStore, TDto, TModel>(default(IRemoteRepository<TStore, TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("repository");
    }

    /// <summary>
    /// Checks that the Handle method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHandleAsync()
    {
        // Arrange
        var request = _fixture.Create<RemoteFilter<TStore, TDto, TModel>>();
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
        await FluentActions.Invoking(() => this._testClass.Handle(default(RemoteFilter<TStore, TDto, TModel>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }
}