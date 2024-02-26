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
using Undersoft.SDK.Service.Data.Repository.Client;
using Undersoft.SDK.Service.Data.Repository.Source;
using R = System.String;
using T = System.String;
using TNotification = System.String;
using TRequest = System.String;
using TResponse = System.String;

namespace Undersoft.SDK.Service.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="Servicer"/>.
/// </summary>
public class ServicerTests
{
    private class TestServicer : Servicer
    {
        public TestServicer() : base()
        {
        }

        public TestServicer(IServiceManager serviceManager) : base(serviceManager)
        {
        }

        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public IMediator PublicMediator => base.Mediator;
    }

    private TestServicer _testClass;
    private IFixture _fixture;
    private Mock<IServiceManager> _serviceManager;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Servicer"/>.
    /// </summary>
    public ServicerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._serviceManager = _fixture.Freeze<Mock<IServiceManager>>();
        this._testClass = _fixture.Create<TestServicer>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestServicer();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestServicer(this._serviceManager.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceManager parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceManager()
    {
        FluentActions.Invoking(() => new TestServicer(default(IServiceManager))).Should().Throw<ArgumentNullException>().WithParameterName("serviceManager");
    }

    /// <summary>
    /// Checks that the CreateStream method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateStreamWithIStreamRequestOfTResponseAndCancellationToken()
    {
        // Arrange
        var request = _fixture.Create<IStreamRequest<TResponse>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = this._testClass.CreateStream<TResponse>(request, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateStream method throws when the request parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateStreamWithIStreamRequestOfTResponseAndCancellationTokenWithNullRequest()
    {
        FluentActions.Invoking(() => this._testClass.CreateStream<TResponse>(default(IStreamRequest<TResponse>), _fixture.Create<CancellationToken>())).Should().Throw<ArgumentNullException>().WithParameterName("request");
    }

    /// <summary>
    /// Checks that the CreateStream method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateStreamWithObjectAndCancellationToken()
    {
        // Arrange
        var request = _fixture.Create<object>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = this._testClass.CreateStream(request, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateStream method throws when the request parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateStreamWithObjectAndCancellationTokenWithNullRequest()
    {
        FluentActions.Invoking(() => this._testClass.CreateStream(default(object), _fixture.Create<CancellationToken>())).Should().Throw<ArgumentNullException>().WithParameterName("request");
    }

    /// <summary>
    /// Checks that the LazyServe method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLazyServe()
    {
        // Arrange
        Func<T, R> function = x => _fixture.Create<R>();

        // Act
        var result = this._testClass.LazyServe<T, R>(function);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LazyServe method throws when the function parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLazyServeWithNullFunction()
    {
        FluentActions.Invoking(() => this._testClass.LazyServe<T, R>(default(Func<T, R>))).Should().Throw<ArgumentNullException>().WithParameterName("function");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallRunWithTAndRAndFuncOfTAndTaskOfRAsync()
    {
        // Arrange
        Func<T, Task<R>> function = x => _fixture.Create<Task<R>>();

        // Act
        var result = await this._testClass.Run<T, R>(function);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the function parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallRunWithTAndRAndFuncOfTAndTaskOfRWithNullFunctionAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Run<T, R>(default(Func<T, Task<R>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("function");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallRunWithTAndFuncOfTAndTaskAsync()
    {
        // Arrange
        Func<T, Task> function = x => _fixture.Create<Task>();

        // Act
        await this._testClass.Run<T>(function);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the function parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallRunWithTAndFuncOfTAndTaskWithNullFunctionAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Run<T>(default(Func<T, Task>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("function");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallRunWithTAndStringAndArrayOfObjectAsync()
    {
        // Arrange
        var methodname = _fixture.Create<string>();
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.Run<T>(methodname, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallRunWithTAndStringAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Run<T>(_fixture.Create<string>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Run method throws when the methodname parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallRunWithTAndStringAndArrayOfObjectWithInvalidMethodnameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Run<T>(value, _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("methodname");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallRunWithTAndRAndStringAndArrayOfObjectAsync()
    {
        // Arrange
        var methodname = _fixture.Create<string>();
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.Run<T, R>(methodname, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallRunWithTAndRAndStringAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Run<T, R>(_fixture.Create<string>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Run method throws when the methodname parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallRunWithTAndRAndStringAndArrayOfObjectWithInvalidMethodnameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Run<T, R>(value, _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("methodname");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallRunWithTAndArgumentsAsync()
    {
        // Arrange
        var arguments = _fixture.Create<Arguments>();

        // Act
        var result = await this._testClass.Run<T>(arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the arguments parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallRunWithTAndArgumentsWithNullArgumentsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Run<T>(default(Arguments))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallRunWithTAndRAndArgumentsAsync()
    {
        // Arrange
        var arguments = _fixture.Create<Arguments>();

        // Act
        var result = await this._testClass.Run<T, R>(arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the arguments parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallRunWithTAndRAndArgumentsWithNullArgumentsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Run<T, R>(default(Arguments))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Send method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSendWithTResponseAndIRequestOfTResponseAndCancellationTokenAsync()
    {
        // Arrange
        var request = _fixture.Create<IRequest<TResponse>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Send<TResponse>(request, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Send method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSendWithTResponseAndIRequestOfTResponseAndCancellationTokenWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Send<TResponse>(default(IRequest<TResponse>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }

    /// <summary>
    /// Checks that the Send method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSendWithObjectAndCancellationTokenAsync()
    {
        // Arrange
        var request = _fixture.Create<object>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Send(request, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Send method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSendWithObjectAndCancellationTokenWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Send(default(object), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }

    /// <summary>
    /// Checks that the Send method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSendWithTRequestAndCancellationTokenAsync()
    {
        // Arrange
        var request = _fixture.Create<TRequest>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.Send<TRequest>(request, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Publish method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPublishWithObjectAndCancellationTokenAsync()
    {
        // Arrange
        var notification = _fixture.Create<object>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.Publish(notification, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Publish method throws when the notification parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPublishWithObjectAndCancellationTokenWithNullNotificationAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Publish(default(object), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("notification");
    }

    /// <summary>
    /// Checks that the Publish method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPublishWithTNotificationAndCancellationTokenAsync()
    {
        // Arrange
        var notification = _fixture.Create<TNotification>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        await this._testClass.Publish<TNotification>(notification, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Report method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallReportWithTResponseAndIRequestOfTResponseAndCancellationTokenAsync()
    {
        // Arrange
        var request = _fixture.Create<IRequest<TResponse>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Report<TResponse>(request, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Report method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallReportWithTResponseAndIRequestOfTResponseAndCancellationTokenWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Report<TResponse>(default(IRequest<TResponse>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }

    /// <summary>
    /// Checks that the Report method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallReportWithObjectAndCancellationTokenAsync()
    {
        // Arrange
        var request = _fixture.Create<object>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Report(request, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Report method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallReportWithObjectAndCancellationTokenWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Report(default(object), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }

    /// <summary>
    /// Checks that the Entry method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallEntryWithTResponseAndIRequestOfTResponseAndCancellationTokenAsync()
    {
        // Arrange
        var request = _fixture.Create<IRequest<TResponse>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Entry<TResponse>(request, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Entry method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallEntryWithTResponseAndIRequestOfTResponseAndCancellationTokenWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Entry<TResponse>(default(IRequest<TResponse>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }

    /// <summary>
    /// Checks that the Entry method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallEntryWithObjectAndCancellationTokenAsync()
    {
        // Arrange
        var request = _fixture.Create<object>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Entry(request, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Entry method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallEntryWithObjectAndCancellationTokenWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Entry(default(object), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }

    /// <summary>
    /// Checks that the Perform method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPerformWithTResponseAndIRequestOfTResponseAndCancellationTokenAsync()
    {
        // Arrange
        var request = _fixture.Create<IRequest<TResponse>>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Perform<TResponse>(request, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Perform method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPerformWithTResponseAndIRequestOfTResponseAndCancellationTokenWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Perform<TResponse>(default(IRequest<TResponse>), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }

    /// <summary>
    /// Checks that the Perform method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallPerformWithObjectAndCancellationTokenAsync()
    {
        // Arrange
        var request = _fixture.Create<object>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await this._testClass.Perform(request, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Perform method throws when the request parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallPerformWithObjectAndCancellationTokenWithNullRequestAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Perform(default(object), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("request");
    }

    /// <summary>
    /// Checks that the Serve method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallServeWithTAndRAndFuncOfTAndTaskOfRAsync()
    {
        // Arrange
        Func<T, Task<R>> function = x => _fixture.Create<Task<R>>();

        // Act
        var result = await this._testClass.Serve<T, R>(function);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Serve method throws when the function parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallServeWithTAndRAndFuncOfTAndTaskOfRWithNullFunctionAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Serve<T, R>(default(Func<T, Task<R>>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("function");
    }

    /// <summary>
    /// Checks that the Serve method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallServeWithTAndFuncOfTAndTaskAsync()
    {
        // Arrange
        Func<T, Task> function = x => _fixture.Create<Task>();

        // Act
        await this._testClass.Serve<T>(function);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Serve method throws when the function parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallServeWithTAndFuncOfTAndTaskWithNullFunctionAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Serve<T>(default(Func<T, Task>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("function");
    }

    /// <summary>
    /// Checks that the Serve method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallServeWithTAndStringAndArrayOfObjectAsync()
    {
        // Arrange
        var methodname = _fixture.Create<string>();
        var parameters = _fixture.Create<object[]>();

        // Act
        await this._testClass.Serve<T>(methodname, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Serve method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallServeWithTAndStringAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Serve<T>(_fixture.Create<string>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Serve method throws when the methodname parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallServeWithTAndStringAndArrayOfObjectWithInvalidMethodnameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Serve<T>(value, _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("methodname");
    }

    /// <summary>
    /// Checks that the Serve method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallServeWithTAndRAndStringAndArrayOfObjectAsync()
    {
        // Arrange
        var methodname = _fixture.Create<string>();
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.Serve<T, R>(methodname, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Serve method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallServeWithTAndRAndStringAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Serve<T, R>(_fixture.Create<string>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Serve method throws when the methodname parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallServeWithTAndRAndStringAndArrayOfObjectWithInvalidMethodnameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Serve<T, R>(value, _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("methodname");
    }

    /// <summary>
    /// Checks that the Serve method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallServeWithTAndStringAndArgumentsAsync()
    {
        // Arrange
        var methodname = _fixture.Create<string>();
        var arguments = _fixture.Create<Arguments>();

        // Act
        await this._testClass.Serve<T>(methodname, arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Serve method throws when the arguments parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallServeWithTAndStringAndArgumentsWithNullArgumentsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Serve<T>(_fixture.Create<string>(), default(Arguments))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Serve method throws when the methodname parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallServeWithTAndStringAndArgumentsWithInvalidMethodnameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Serve<T>(value, _fixture.Create<Arguments>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("methodname");
    }

    /// <summary>
    /// Checks that the Serve method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallServeWithTAndRAndStringAndArgumentsAsync()
    {
        // Arrange
        var methodname = _fixture.Create<string>();
        var arguments = _fixture.Create<Arguments>();

        // Act
        var result = await this._testClass.Serve<T, R>(methodname, arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Serve method throws when the arguments parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallServeWithTAndRAndStringAndArgumentsWithNullArgumentsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Serve<T, R>(_fixture.Create<string>(), default(Arguments))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the Serve method throws when the methodname parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallServeWithTAndRAndStringAndArgumentsWithInvalidMethodnameAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Serve<T, R>(value, _fixture.Create<Arguments>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("methodname");
    }

    /// <summary>
    /// Checks that the Save method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSaveAsync()
    {
        // Arrange
        var asTransaction = _fixture.Create<bool>();

        // Act
        await this._testClass.Save(asTransaction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SaveClient method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSaveClientAsync()
    {
        // Arrange
        var client = _fixture.Create<IRepositoryClient>();
        var asTransaction = _fixture.Create<bool>();

        // Act
        var result = await this._testClass.SaveClient(client, asTransaction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SaveClient method throws when the client parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSaveClientWithNullClientAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SaveClient(default(IRepositoryClient), _fixture.Create<bool>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("client");
    }

    /// <summary>
    /// Checks that the SaveClients method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSaveClientsAsync()
    {
        // Arrange
        var asTransaction = _fixture.Create<bool>();

        // Act
        var result = await this._testClass.SaveClients(asTransaction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SaveStore method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSaveStoreAsync()
    {
        // Arrange
        var source = _fixture.Create<IRepositorySource>();
        var asTransaction = _fixture.Create<bool>();

        // Act
        var result = await this._testClass.SaveStore(source, asTransaction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SaveStore method throws when the source parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallSaveStoreWithNullSourceAsync()
    {
        await FluentActions.Invoking(() => this._testClass.SaveStore(default(IRepositorySource), _fixture.Create<bool>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the SaveStores method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSaveStoresAsync()
    {
        // Arrange
        var asTransaction = _fixture.Create<bool>();

        // Act
        var result = await this._testClass.SaveStores(asTransaction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DisposeAsyncCore method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDisposeAsyncCoreAsync()
    {
        // Act
        await this._testClass.DisposeAsyncCore();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDispose()
    {
        // Arrange
        var disposing = _fixture.Create<bool>();

        // Act
        this._testClass.PublicDispose(disposing);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicMediator property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicMediator()
    {
        // Assert
        this._testClass.PublicMediator.Should().BeAssignableTo<IMediator>();

        Assert.Fail("Create or modify test");
    }
}