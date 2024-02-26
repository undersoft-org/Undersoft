using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Operation.Command;
using TDto = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command;

/// <summary>
/// Unit tests for the type <see cref="CommandSet"/>.
/// </summary>
public class CommandSet_1Tests
{
    private CommandSet<TDto> _testClass;
    private IFixture _fixture;
    private OperationType _commandMode;
    private EventPublishMode _publishPattern;
    private Command<TDto>[] _dtoCommands;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="CommandSet"/>.
    /// </summary>
    public CommandSet_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._commandMode = _fixture.Create<OperationType>();
        this._publishPattern = _fixture.Create<EventPublishMode>();
        this._dtoCommands = _fixture.Create<Command<TDto>[]>();
        this._testClass = _fixture.Create<CommandSet<TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new CommandSet<TDto>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new CommandSet<TDto>(this._commandMode);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new CommandSet<TDto>(this._commandMode, this._publishPattern, this._dtoCommands);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the DtoCommands parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullDtoCommands()
    {
        FluentActions.Invoking(() => new CommandSet<TDto>(this._commandMode, this._publishPattern, default(Command<TDto>[]))).Should().Throw<ArgumentNullException>().WithParameterName("DtoCommands");
    }

    /// <summary>
    /// Checks that setting the CommandMode property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCommandMode()
    {
        this._testClass.CheckProperty(x => x.CommandMode, _fixture.Create<OperationType>(), _fixture.Create<OperationType>());
    }

    /// <summary>
    /// Checks that setting the PublishMode property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPublishMode()
    {
        this._testClass.CheckProperty(x => x.PublishMode, _fixture.Create<EventPublishMode>(), _fixture.Create<EventPublishMode>());
    }

    /// <summary>
    /// Checks that the Commands property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetCommands()
    {
        // Assert
        this._testClass.Commands.Should().BeAssignableTo<IEnumerable<Command<TDto>>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Result property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetResult()
    {
        this._testClass.CheckProperty(x => x.Result, _fixture.Create<ValidationResult>(), _fixture.Create<ValidationResult>());
    }

    /// <summary>
    /// Checks that the Input property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetInput()
    {
        // Assert
        this._testClass.Input.Should().BeAssignableTo<object>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Output property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetOutput()
    {
        // Assert
        this._testClass.Output.Should().BeAssignableTo<object>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Processings property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProcessings()
    {
        this._testClass.CheckProperty(x => x.Processings, _fixture.Create<Delegate>(), _fixture.Create<Delegate>());
    }
}