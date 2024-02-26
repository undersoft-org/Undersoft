using System;
using System.Collections.Generic;
using System.Threading;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Operation.Invocation;
using Undersoft.SDK.Service.Server.Controller.Open;
using TModel = Undersoft.SDK.Stocks.StockContext;
using TService = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests.Controller.Open;

/// <summary>
/// Unit tests for the type <see cref="OpenServiceController"/>.
/// </summary>
[TestClass]
public class OpenServiceController_3Tests
{
    private class TestOpenServiceController : OpenServiceController<TStore, TService, TModel>
    {
        public TestOpenServiceController() : base()
        {
        }

        public TestOpenServiceController(IServicer servicer) : base(servicer)
        {
        }
    }

    private TestOpenServiceController _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="OpenServiceController"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._testClass = _fixture.Create<TestOpenServiceController>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestOpenServiceController();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestOpenServiceController(this._servicer.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new TestOpenServiceController(default(IServicer))).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }

    /// <summary>
    /// Checks that the Access method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAccess()
    {
        // Arrange
        var args = _fixture.Create<IDictionary<string, Arguments>>();

        _servicer.Setup(mock => mock.Perform<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<Invocation<TModel>>());

        // Act
        var result = this._testClass.Access(args);

        // Assert
        _servicer.Verify(mock => mock.Perform<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Access method throws when the args parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAccessWithNullArgs()
    {
        FluentActions.Invoking(() => this._testClass.Access(default(IDictionary<string, Arguments>))).Should().Throw<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that the Action method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAction()
    {
        // Arrange
        var args = _fixture.Create<IDictionary<string, Arguments>>();

        _servicer.Setup(mock => mock.Perform<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<Invocation<TModel>>());

        // Act
        var result = this._testClass.Action(args);

        // Assert
        _servicer.Verify(mock => mock.Perform<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Action method throws when the args parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallActionWithNullArgs()
    {
        FluentActions.Invoking(() => this._testClass.Action(default(IDictionary<string, Arguments>))).Should().Throw<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that the Setup method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetup()
    {
        // Arrange
        var args = _fixture.Create<IDictionary<string, Arguments>>();

        _servicer.Setup(mock => mock.Perform<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<Invocation<TModel>>());

        // Act
        var result = this._testClass.Setup(args);

        // Assert
        _servicer.Verify(mock => mock.Perform<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Setup method throws when the args parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetupWithNullArgs()
    {
        FluentActions.Invoking(() => this._testClass.Setup(default(IDictionary<string, Arguments>))).Should().Throw<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that the Invoke method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInvoke()
    {
        // Arrange
        var args = _fixture.Create<IDictionary<string, Arguments>>();
        Func<KeyValuePair<string, Arguments>, Invocation<TModel>> invocation = x => _fixture.Create<Invocation<TModel>>();

        _servicer.Setup(mock => mock.Perform<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<Invocation<TModel>>());

        // Act
        var result = this._testClass.Invoke(args, invocation
        );

        // Assert
        _servicer.Verify(mock => mock.Perform<Invocation<TModel>>(It.IsAny<IRequest<Invocation<TModel>>>(), It.IsAny<CancellationToken>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the args parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithNullArgs()
    {
        FluentActions.Invoking(() => this._testClass.Invoke(default(IDictionary<string, Arguments>), x => _fixture.Create<Invocation<TModel>>())).Should().Throw<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the invocation parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithNullInvocation()
    {
        FluentActions.Invoking(() => this._testClass.Invoke(_fixture.Create<IDictionary<string, Arguments>>(), default(Func<KeyValuePair<string, Arguments>, Invocation<TModel>>))).Should().Throw<ArgumentNullException>().WithParameterName("invocation");
    }
}