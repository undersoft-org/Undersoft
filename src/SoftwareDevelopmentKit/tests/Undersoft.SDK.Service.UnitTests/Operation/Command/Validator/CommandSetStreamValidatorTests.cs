using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Operation.Command.Validator;
using TDto = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command.Validator;

/// <summary>
/// Unit tests for the type <see cref="CommandSetStreamValidator"/>.
/// </summary>
public class CommandSetStreamValidator_1Tests
{
    private CommandSetStreamValidator<TDto> _testClass;
    private IFixture _fixture;
    private Mock<IServicer> _servicer;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="CommandSetStreamValidator"/>.
    /// </summary>
    public CommandSetStreamValidator_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._servicer = _fixture.Freeze<Mock<IServicer>>();
        this._testClass = _fixture.Create<CommandSetStreamValidator<TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new CommandSetStreamValidator<TDto>(this._servicer.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServicer()
    {
        FluentActions.Invoking(() => new CommandSetStreamValidator<TDto>(default(IServicer))).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }
}