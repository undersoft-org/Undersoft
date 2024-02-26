using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Operation.Invocation;
using Undersoft.SDK.Service.Server.Controller.Api;
using TModel = Undersoft.SDK.Origin;
using TService = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests.Controller.Api;

/// <summary>
/// Unit tests for the type <see cref="ApiServiceRemoteController"/>.
/// </summary>
[TestClass]
public class ApiServiceRemoteController_3Tests
{
    private class TestApiServiceRemoteController : ApiServiceRemoteController<TStore, TService, TModel>
    {
        public TestApiServiceRemoteController() : base()
        {
        }

        public TestApiServiceRemoteController(IServicer servicer) : base(servicer)
        {
        }
    }

    private TestApiServiceRemoteController _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ApiServiceRemoteController"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._testClass = _fixture.Create<TestApiServiceRemoteController>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestApiServiceRemoteController();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestApiServiceRemoteController(this._servicer.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new TestApiServiceRemoteController(default(IServicer))).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that the Action method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallActionAsync()
    {
        // Arrange
        var @method = _fixture.Create<string>();
        var arguments = _fixture.Create<Arguments>();

        _servicer.Setup(mock => mock.Entry<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<Invocation<TModel>>());

        // Act
        var result = await this._testClass.Action(method, arguments
        );

        // Assert
        _servicer.Verify(mock => mock.Entry<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Action method throws when the arguments parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallActionWithNullArgumentsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Action(_fixture.Create<string>(), default(Arguments))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Action method throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallActionWithInvalidMethodAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Action(value, _fixture.Create<Arguments>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Access method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAccessAsync()
    {
        // Arrange
        var @method = _fixture.Create<string>();
        var arguments = _fixture.Create<Arguments>();

        _servicer.Setup(mock => mock.Entry<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<Invocation<TModel>>());

        // Act
        var result = await this._testClass.Access(method, arguments
        );

        // Assert
        _servicer.Verify(mock => mock.Entry<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Access method throws when the arguments parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallAccessWithNullArgumentsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Access(_fixture.Create<string>(), default(Arguments))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Access method throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallAccessWithInvalidMethodAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Access(value, _fixture.Create<Arguments>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Setup method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSetupAsync()
    {
        // Arrange
        var @method = _fixture.Create<string>();
        var arguments = _fixture.Create<Arguments>();

        _servicer.Setup(mock => mock.Entry<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<Invocation<TModel>>());

        // Act
        var result = await this._testClass.Setup(method, arguments
        );

        // Assert
        _servicer.Verify(mock => mock.Entry<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Setup method throws when the arguments parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSetupWithNullArgumentsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Setup(_fixture.Create<string>(), default(Arguments))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Setup method throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSetupWithInvalidMethodAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Setup(value, _fixture.Create<Arguments>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("method");
    }
}