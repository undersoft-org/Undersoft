using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Operation.Invocation;
using Undersoft.SDK.Service.Operation.Invocation.Handler;
using Undersoft.SDK.Service.Operation.Invocation.Notification;
using TDto = Undersoft.SDK.Origin;
using TService = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Invocation.Handler;

/// <summary>
/// Unit tests for the type <see cref="AccessHandler"/>.
/// </summary>
public class AccessHandler_3Tests
{
    private AccessHandler<TStore, TService, TDto> _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccessHandler"/>.
    /// </summary>
    public AccessHandler_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._testClass = _fixture.Create<AccessHandler<TStore, TService, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccessHandler<TStore, TService, TDto>(this._servicer.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new AccessHandler<TStore, TService, TDto>(default(IServicer))).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that the Handle method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHandleAsync()
    {
        // Arrange
        var request = _fixture.Create<Action<TStore, TService, TDto>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        _servicer.Setup(mock => mock.Run<TService, TDto>(It.IsAny<Arguments>())).ReturnsAsync(_fixture.Create<TDto>());

        // Act
        var result = await this._testClass.Handle(request, cancellationToken
        );

        // Assert
        _servicer.Verify(mock => mock.Run<TService, TDto>(It.IsAny<Arguments>()));
        _servicer.Verify(mock => mock.Publish<ActionInvoked<TStore, TService, TDto>>(It.IsAny<ActionInvoked<TStore, TService, TDto>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Handle method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallHandleWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Handle(default(Action<TStore, TService, TDto>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }
}