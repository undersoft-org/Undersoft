using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Operation.Command;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command;

/// <summary>
/// Unit tests for the type <see cref="CommandBase"/>.
/// </summary>
public class CommandBaseTests
{
    private class TestCommandBase : CommandBase
    {
        public TestCommandBase() : base()
        {
        }

        public TestCommandBase(OperationType commandMode, EventPublishMode publishMode) : base(commandMode, publishMode)
        {
        }

        public TestCommandBase(object entryData, OperationType commandMode, EventPublishMode publishMode) : base(entryData, commandMode, publishMode)
        {
        }

        public TestCommandBase(
                                                                                                                  object entryData,
                                                                                                                  OperationType commandMode,
                                                                                                                  EventPublishMode publishMode,
                                                                                                                  params object[] keys
                                                                                                              ) : base(entryData, commandMode, publishMode, keys
                                                                                                          )
        {
        }

        public TestCommandBase(
                                                                                                                  OperationType commandMode,
                                                                                                                  EventPublishMode publishMode,
                                                                                                                  params object[] keys
                                                                                                              ) : base(commandMode, publishMode, keys
                                                                                                          )
        {
        }
    }

    private TestCommandBase _testClass;
    private IFixture _fixture;
    private OperationType _commandMode;
    private EventPublishMode _publishMode;
    private object _entryData;
    private object[] _keys;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="CommandBase"/>.
    /// </summary>
    public CommandBaseTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._commandMode = _fixture.Create<OperationType>();
        this._publishMode = _fixture.Create<EventPublishMode>();
        this._entryData = _fixture.Create<object>();
        this._keys = _fixture.Create<object[]>();
        this._testClass = _fixture.Create<TestCommandBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestCommandBase();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestCommandBase(this._commandMode, this._publishMode);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestCommandBase(this._entryData, this._commandMode, this._publishMode);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestCommandBase(this._entryData, this._commandMode, this._publishMode, this._keys);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestCommandBase(this._commandMode, this._publishMode, this._keys);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the entryData parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEntryData()
    {
        FluentActions.Invoking(() => new TestCommandBase(default(object), this._commandMode, this._publishMode)).Should().Throw<ArgumentNullException>().WithParameterName("entryData");
        FluentActions.Invoking(() => new TestCommandBase(default(object), this._commandMode, this._publishMode, this._keys)).Should().Throw<ArgumentNullException>().WithParameterName("entryData");
    }

    /// <summary>
    /// Checks that instance construction throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeys()
    {
        FluentActions.Invoking(() => new TestCommandBase(this._entryData, this._commandMode, this._publishMode, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
        FluentActions.Invoking(() => new TestCommandBase(this._commandMode, this._publishMode, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
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
    /// Checks that the Keys property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetKeys()
    {
        // Arrange
        var testValue = _fixture.Create<object[]>();

        // Act
        this._testClass.Keys = testValue;

        // Assert
        this._testClass.Keys.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Processings property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProcessings()
    {
        // Arrange
        var testValue = _fixture.Create<Delegate>();

        // Act
        this._testClass.Processings = testValue;

        // Assert
        this._testClass.Processings.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Entity property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEntity()
    {
        // Arrange
        var testValue = _fixture.Create<IOrigin>();

        // Act
        this._testClass.Entity = testValue;

        // Assert
        this._testClass.Entity.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Contract property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetContract()
    {
        // Arrange
        var testValue = _fixture.Create<object>();

        // Act
        this._testClass.Contract = testValue;

        // Assert
        this._testClass.Contract.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Result property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetResult()
    {
        // Arrange
        var testValue = _fixture.Create<ValidationResult>();

        // Act
        this._testClass.Result = testValue;

        // Assert
        this._testClass.Result.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the ErrorMessages property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetErrorMessages()
    {
        // Assert
        this._testClass.ErrorMessages.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CommandMode property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCommandMode()
    {
        // Arrange
        var testValue = _fixture.Create<OperationType>();

        // Act
        this._testClass.CommandMode = testValue;

        // Assert
        this._testClass.CommandMode.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the PublishMode property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPublishMode()
    {
        // Arrange
        var testValue = _fixture.Create<EventPublishMode>();

        // Act
        this._testClass.PublishMode = testValue;

        // Assert
        this._testClass.PublishMode.Should().Be(testValue);
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
    /// Checks that the IsValid property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIsValid()
    {
        // Assert
        this._testClass.IsValid.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }
}