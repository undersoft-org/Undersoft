using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server.Hosting;

namespace Undersoft.SDK.Service.Server.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="ServerHostJwtMiddleware"/>.
/// </summary>
[TestClass]
public class ServerHostJwtMiddlewareTests
{
    private ServerHostJwtMiddleware _testClass;
    private IFixture _fixture;
    private RequestDelegate _next;
    private Mock<IServicer> _servicer;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServerHostJwtMiddleware"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._next = x => _fixture.Create<Task>();
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._testClass = _fixture.Create<ServerHostJwtMiddleware>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ServerHostJwtMiddleware(this._next, this._servicer.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the next parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullNext()
    {
        FluentActions.Invoking(() => new ServerHostJwtMiddleware(default(RequestDelegate), this._servicer.Object)).Should().Throw<ArgumentNullException>().WithParameterName("next");
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new ServerHostJwtMiddleware(this._next, default(IServicer))).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that the Invoke method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsync()
    {
        // Arrange
        var context = _fixture.Create<HttpContext>();

        // Act
        await this._testClass.Invoke(context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the context parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeWithNullContextAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Invoke(default(HttpContext))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("context");
    }
}