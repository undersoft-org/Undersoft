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
/// Unit tests for the type <see cref="Command"/>.
/// </summary>
public class Command_1Tests
{
    private Command<TDto> _testClass;
    private IFixture _fixture;
    private OperationType _commandMode;
    private TDto _dataObject;
    private EventPublishMode _publishMode;
    private object[] _keys;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Command"/>.
    /// </summary>
    public Command_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._commandMode = _fixture.Create<OperationType>();
        this._dataObject = _fixture.Create<TDto>();
        this._publishMode = _fixture.Create<EventPublishMode>();
        this._keys = _fixture.Create<object[]>();
        this._testClass = _fixture.Create<Command<TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Command<TDto>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Command<TDto>(this._commandMode, this._dataObject);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Command<TDto>(this._commandMode, this._publishMode, this._dataObject);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Command<TDto>(this._commandMode, this._publishMode, this._dataObject, this._keys);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Command<TDto>(this._commandMode, this._publishMode, this._keys);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the dataObject parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullDataObject()
    {
        FluentActions.Invoking(() => new Command<TDto>(this._commandMode, default(TDto))).Should().Throw<ArgumentNullException>().WithParameterName("dataObject");
        FluentActions.Invoking(() => new Command<TDto>(this._commandMode, this._publishMode, default(TDto))).Should().Throw<ArgumentNullException>().WithParameterName("dataObject");
        FluentActions.Invoking(() => new Command<TDto>(this._commandMode, this._publishMode, default(TDto), this._keys)).Should().Throw<ArgumentNullException>().WithParameterName("dataObject");
    }

    /// <summary>
    /// Checks that instance construction throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeys()
    {
        FluentActions.Invoking(() => new Command<TDto>(this._commandMode, this._publishMode, this._dataObject, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
        FluentActions.Invoking(() => new Command<TDto>(this._commandMode, this._publishMode, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the Contract property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetContract()
    {
        // Assert
        this._testClass.Contract.Should().BeAssignableTo<TDto>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Id property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.Id = testValue;

        // Assert
        this._testClass.Id.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the TypeId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.TypeId = testValue;

        // Assert
        this._testClass.TypeId.Should().Be(testValue);
    }
}