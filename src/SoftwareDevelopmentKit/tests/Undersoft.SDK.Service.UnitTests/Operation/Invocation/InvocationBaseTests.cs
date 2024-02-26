using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Service.Operation.Invocation;

namespace Undersoft.SDK.Service.UnitTests.Operation.Invocation;

/// <summary>
/// Unit tests for the type <see cref="InvocationBase"/>.
/// </summary>
public class InvocationBaseTests
{
    private class TestInvocationBase : InvocationBase
    {
        public TestInvocationBase() : base()
        {
        }

        public TestInvocationBase(OperationType commandMode) : base(commandMode)
        {
        }

        public TestInvocationBase(OperationType commandMode, Type serviceType, string method, object argument) : base(commandMode, serviceType, method, argument)
        {
        }

        public TestInvocationBase(OperationType commandMode, Type serviceType, string method, Arguments arguments) : base(commandMode, serviceType, method, arguments)
        {
        }

        public TestInvocationBase(OperationType commandMode, Type serviceType, string method, object[] arguments) : base(commandMode, serviceType, method, arguments)
        {
        }

        public TestInvocationBase(OperationType commandMode, Type serviceType, string method, byte[] binaries) : base(commandMode, serviceType, method, binaries)
        {
        }
    }

    private TestInvocationBase _testClass;
    private IFixture _fixture;
    private OperationType _commandMode;
    private Type _serviceType;
    private string _method;
    private object _argument;
    private Arguments _argumentsArguments;
    private object[] _argumentsUnknownType;
    private byte[] _binaries;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InvocationBase"/>.
    /// </summary>
    public InvocationBaseTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._commandMode = _fixture.Create<OperationType>();
        this._serviceType = _fixture.Create<Type>();
        this._method = _fixture.Create<string>();
        this._argument = _fixture.Create<object>();
        this._argumentsArguments = _fixture.Create<Arguments>();
        this._argumentsUnknownType = _fixture.Create<object[]>();
        this._binaries = _fixture.Create<byte[]>();
        this._testClass = _fixture.Create<TestInvocationBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestInvocationBase();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestInvocationBase(this._commandMode);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestInvocationBase(this._commandMode, this._serviceType, this._method, this._argument);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestInvocationBase(this._commandMode, this._serviceType, this._method, this._argumentsArguments);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestInvocationBase(this._commandMode, this._serviceType, this._method, this._argumentsUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestInvocationBase(this._commandMode, this._serviceType, this._method, this._binaries);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceType()
    {
        FluentActions.Invoking(() => new TestInvocationBase(this._commandMode, default(Type), this._method, this._argument)).Should().Throw<ArgumentNullException>().WithParameterName("serviceType");
        FluentActions.Invoking(() => new TestInvocationBase(this._commandMode, default(Type), this._method, this._argumentsArguments)).Should().Throw<ArgumentNullException>().WithParameterName("serviceType");
        FluentActions.Invoking(() => new TestInvocationBase(this._commandMode, default(Type), this._method, this._argumentsUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("serviceType");
        FluentActions.Invoking(() => new TestInvocationBase(this._commandMode, default(Type), this._method, this._binaries)).Should().Throw<ArgumentNullException>().WithParameterName("serviceType");
    }

    /// <summary>
    /// Checks that instance construction throws when the argument parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullArgument()
    {
        FluentActions.Invoking(() => new TestInvocationBase(this._commandMode, this._serviceType, this._method, default(object))).Should().Throw<ArgumentNullException>().WithParameterName("argument");
    }

    /// <summary>
    /// Checks that instance construction throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullArguments()
    {
        FluentActions.Invoking(() => new TestInvocationBase(this._commandMode, this._serviceType, this._method, default(Arguments))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
        FluentActions.Invoking(() => new TestInvocationBase(this._commandMode, this._serviceType, this._method, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that instance construction throws when the binaries parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullBinaries()
    {
        FluentActions.Invoking(() => new TestInvocationBase(this._commandMode, this._serviceType, this._method, default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("binaries");
    }

    /// <summary>
    /// Checks that the constructor throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidMethod(string value)
    {
        FluentActions.Invoking(() => new TestInvocationBase(this._commandMode, this._serviceType, value, this._argument)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new TestInvocationBase(this._commandMode, this._serviceType, value, this._argumentsArguments)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new TestInvocationBase(this._commandMode, this._serviceType, value, this._argumentsUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new TestInvocationBase(this._commandMode, this._serviceType, value, this._binaries)).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the SetArguments method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetArguments()
    {
        // Arrange
        var arguments = _fixture.Create<Arguments>();

        // Act
        this._testClass.SetArguments(arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetArguments method throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetArgumentsWithNullArguments()
    {
        FluentActions.Invoking(() => this._testClass.SetArguments(default(Arguments))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
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
    /// Checks that the Arguments property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetArguments()
    {
        // Arrange
        var testValue = _fixture.Create<Arguments>();

        // Act
        this._testClass.Arguments = testValue;

        // Assert
        this._testClass.Arguments.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Return property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetReturn()
    {
        // Arrange
        var testValue = _fixture.Create<object>();

        // Act
        this._testClass.Return = testValue;

        // Assert
        this._testClass.Return.Should().BeSameAs(testValue);
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
    /// Checks that the Response property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetResponse()
    {
        // Arrange
        var testValue = _fixture.Create<object>();

        // Act
        this._testClass.Response = testValue;

        // Assert
        this._testClass.Response.Should().BeSameAs(testValue);
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