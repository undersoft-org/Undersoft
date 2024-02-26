using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Behaviour;
using TRequest = System.String;
using TResponse = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests.Behaviour;

/// <summary>
/// Unit tests for the type <see cref="CommandSetValidationBehaviour"/>.
/// </summary>
[TestClass]
public class CommandSetValidationBehaviour_2Tests
{
    private CommandSetValidationBehaviour<TRequest, TResponse> _testClass;
    private IFixture _fixture;
    private IEnumerable<IValidator<TResponse>> _validators;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="CommandSetValidationBehaviour"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._validators = _fixture.Create<IEnumerable<IValidator<TResponse>>>();
        this._testClass = _fixture.Create<CommandSetValidationBehaviour<TRequest, TResponse>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new CommandSetValidationBehaviour<TRequest, TResponse>(this._validators);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the validators parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullValidators()
    {
        FluentActions.Invoking(() => new CommandSetValidationBehaviour<TRequest, TResponse>(default(IEnumerable<IValidator<TResponse>>))).Should().Throw<ArgumentNullException>().WithParameterName("validators");
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
        var result = await this._testClass.Handle(request, next, cancellationToken);

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