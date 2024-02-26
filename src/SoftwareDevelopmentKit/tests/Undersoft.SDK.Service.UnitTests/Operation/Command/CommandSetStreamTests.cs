using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Operation.Command;
using TDto = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command;

/// <summary>
/// Unit tests for the type <see cref="CommandSetStream"/>.
/// </summary>
public class CommandSetStream_1Tests
{
    private CommandSetStream<TDto> _testClass;
    private IFixture _fixture;
    private OperationType _commandMode;
    private EventPublishMode _publishPattern;
    private Command<TDto>[] _dtoCommands;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="CommandSetStream"/>.
    /// </summary>
    public CommandSetStream_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._commandMode = _fixture.Create<OperationType>();
        this._publishPattern = _fixture.Create<EventPublishMode>();
        this._dtoCommands = _fixture.Create<Command<TDto>[]>();
        this._testClass = _fixture.Create<CommandSetStream<TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new CommandSetStream<TDto>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new CommandSetStream<TDto>(this._commandMode);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new CommandSetStream<TDto>(this._commandMode, this._publishPattern, this._dtoCommands);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the DtoCommands parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullDtoCommands()
    {
        FluentActions.Invoking(() => new CommandSetStream<TDto>(this._commandMode, this._publishPattern, default(Command<TDto>[]))).Should().Throw<ArgumentNullException>().WithParameterName("DtoCommands");
    }
}