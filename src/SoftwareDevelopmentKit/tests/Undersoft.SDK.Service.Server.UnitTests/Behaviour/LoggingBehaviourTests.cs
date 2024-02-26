using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Behaviour;
using TRequest = System.String;
using TResponse = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests.Behaviour;

/// <summary>
/// Unit tests for the type <see cref="LoggingBehaviour"/>.
/// </summary>
[TestClass]
public class LoggingBehaviour_2Tests
{
    private LoggingBehaviour<TRequest, TResponse> _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="LoggingBehaviour"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<LoggingBehaviour<TRequest, TResponse>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new LoggingBehaviour<TRequest, TResponse>();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Handle method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallHandleAsync()
    {
        // Arrange
        var request = _fixture.Create<TRequest>();
        RequestHandlerDelegate<TResponse> next = () => _fixture.Create<Task<TResponse>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Handle(request, next, cancellationToken
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Handle method throws when the next parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallHandleWithNullNextAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Handle(_fixture.Create<TRequest>(), default(RequestHandlerDelegate<TResponse>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("next");
    }
}