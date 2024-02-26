using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Series;
using Undersoft.SDK.Workflows;
using TClass = System.String;

namespace Undersoft.SDK.UnitTests.Workflows;

/// <summary>
/// Unit tests for the type <see cref="Workout"/>.
/// </summary>
public class WorkoutTests
{
    private Workout _testClass;
    private IFixture _fixture;
    private bool _safeClose;
    private string _className;
    private string _methodName;
    private object _result;
    private object[] _input;
    private Mock<IInvoker> _method;
    private bool _safe;
    private int _workersCount;
    private Mock<ISeries<IInvoker>> __methods;
    private object _classObject;
    private int _evokerCount;
    private Mock<IInvoker> _evoker;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Workout"/>.
    /// </summary>
    public WorkoutTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._safeClose = _fixture.Create<bool>();
        this._className = _fixture.Create<string>();
        this._methodName = _fixture.Create<string>();
        this._result = _fixture.Create<object>();
        this._input = _fixture.Create<object[]>();
        this._method = _fixture.Freeze<Mock<IInvoker>>();
        this._safe = _fixture.Create<bool>();
        this._workersCount = _fixture.Create<int>();
        this.__methods = _fixture.Freeze<Mock<ISeries<IInvoker>>>();
        this._classObject = _fixture.Create<object>();
        this._evokerCount = _fixture.Create<int>();
        this._evoker = _fixture.Freeze<Mock<IInvoker>>();
        this._testClass = _fixture.Create<Workout>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Workout(this._safeClose, this._className, this._methodName, this._result, this._input);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Workout(this._method.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Workout(this._method.Object, this._safe, this._input);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Workout(this._method.Object, this._input);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Workout(this._workersCount, this._safeClose, this.__methods.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Workout(this._workersCount, this._safeClose, this._method.Object, this._input);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Workout(this._workersCount, this._safeClose, this._classObject, this._methodName, this._input);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Workout(this._workersCount, this._evokerCount, this._safeClose, this._method.Object, this._evoker.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Workout(this._classObject, this._methodName, this._result, this._input);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Workout(this._className, this._methodName, this._input);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the result parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullResult()
    {
        FluentActions.Invoking(() => new Workout(this._safeClose, this._className, this._methodName, default(object), this._input)).Should().Throw<ArgumentNullException>().WithParameterName("result");
        FluentActions.Invoking(() => new Workout(this._classObject, this._methodName, default(object), this._input)).Should().Throw<ArgumentNullException>().WithParameterName("result");
    }

    /// <summary>
    /// Checks that instance construction throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInput()
    {
        FluentActions.Invoking(() => new Workout(this._safeClose, this._className, this._methodName, this._result, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
        FluentActions.Invoking(() => new Workout(this._method.Object, this._safe, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
        FluentActions.Invoking(() => new Workout(this._method.Object, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
        FluentActions.Invoking(() => new Workout(this._workersCount, this._safeClose, this._method.Object, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
        FluentActions.Invoking(() => new Workout(this._workersCount, this._safeClose, this._classObject, this._methodName, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
        FluentActions.Invoking(() => new Workout(this._classObject, this._methodName, this._result, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
        FluentActions.Invoking(() => new Workout(this._className, this._methodName, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that instance construction throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMethod()
    {
        FluentActions.Invoking(() => new Workout(default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Workout(default(IInvoker), this._safe, this._input)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Workout(default(IInvoker), this._input)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Workout(this._workersCount, this._safeClose, default(IInvoker), this._input)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Workout(this._workersCount, this._evokerCount, this._safeClose, default(IInvoker), this._evoker.Object)).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that instance construction throws when the _methods parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNull_methods()
    {
        FluentActions.Invoking(() => new Workout(this._workersCount, this._safeClose, default(ISeries<IInvoker>))).Should().Throw<ArgumentNullException>().WithParameterName("_methods");
    }

    /// <summary>
    /// Checks that instance construction throws when the classObject parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullClassObject()
    {
        FluentActions.Invoking(() => new Workout(this._workersCount, this._safeClose, default(object), this._methodName, this._input)).Should().Throw<ArgumentNullException>().WithParameterName("classObject");
        FluentActions.Invoking(() => new Workout(default(object), this._methodName, this._result, this._input)).Should().Throw<ArgumentNullException>().WithParameterName("classObject");
    }

    /// <summary>
    /// Checks that instance construction throws when the evoker parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEvoker()
    {
        FluentActions.Invoking(() => new Workout(this._workersCount, this._evokerCount, this._safeClose, this._method.Object, default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("evoker");
    }

    /// <summary>
    /// Checks that the constructor throws when the className parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidClassName(string value)
    {
        FluentActions.Invoking(() => new Workout(this._safeClose, value, this._methodName, this._result, this._input)).Should().Throw<ArgumentNullException>().WithParameterName("className");
        FluentActions.Invoking(() => new Workout(value, this._methodName, this._input)).Should().Throw<ArgumentNullException>().WithParameterName("className");
    }

    /// <summary>
    /// Checks that the constructor throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => new Workout(this._safeClose, this._className, value, this._result, this._input)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Workout(this._workersCount, this._safeClose, this._classObject, value, this._input)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Workout(this._classObject, value, this._result, this._input)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Workout(this._className, value, this._input)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRunWithTClass()
    {
        // Act
        var result = Workout.Run<TClass>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRunWithSafeThreadAndInput()
    {
        // Arrange
        var safeThread = _fixture.Create<bool>();
        var input = _fixture.Create<object[]>();

        // Act
        var result = Workout.Run<TClass>(safeThread, input);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithSafeThreadAndInputWithNullInput()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(_fixture.Create<bool>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRunWithConstructorParamsAndInput()
    {
        // Arrange
        var constructorParams = _fixture.Create<object[]>();
        var input = _fixture.Create<object[]>();

        // Act
        var result = Workout.Run<TClass>(constructorParams, input);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the constructorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithConstructorParamsAndInputWithNullConstructorParams()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(default(object[]), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
    }

    /// <summary>
    /// Checks that the Run method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithConstructorParamsAndInputWithNullInput()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(_fixture.Create<object[]>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRunWithMethodNameAndConstructorParamsAndInput()
    {
        // Arrange
        var methodName = _fixture.Create<string>();
        var constructorParams = _fixture.Create<object[]>();
        var input = _fixture.Create<object[]>();

        // Act
        var result = Workout.Run<TClass>(methodName, constructorParams, input
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the constructorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithMethodNameAndConstructorParamsAndInputWithNullConstructorParams()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(_fixture.Create<string>(), default(object[]), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
    }

    /// <summary>
    /// Checks that the Run method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithMethodNameAndConstructorParamsAndInputWithNullInput()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(_fixture.Create<string>(), _fixture.Create<object[]>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the Run method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRunWithMethodNameAndConstructorParamsAndInputWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(value, _fixture.Create<object[]>(), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRunWithMethodNameAndInput()
    {
        // Arrange
        var methodName = _fixture.Create<string>();
        var input = _fixture.Create<object[]>();

        // Act
        var result = Workout.Run<TClass>(methodName, input);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithMethodNameAndInputWithNullInput()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(_fixture.Create<string>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the Run method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRunWithMethodNameAndInputWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(value, _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRunWithMethodNameAndParameterTypesAndConstructorParamsAndInput()
    {
        // Arrange
        var methodName = _fixture.Create<string>();
        var parameterTypes = _fixture.Create<Type[]>();
        var constructorParams = _fixture.Create<object[]>();
        var input = _fixture.Create<object[]>();

        // Act
        var result = Workout.Run<TClass>(methodName, parameterTypes, constructorParams, input
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithMethodNameAndParameterTypesAndConstructorParamsAndInputWithNullParameterTypes()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(_fixture.Create<string>(), default(Type[]), _fixture.Create<object[]>(), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that the Run method throws when the constructorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithMethodNameAndParameterTypesAndConstructorParamsAndInputWithNullConstructorParams()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(_fixture.Create<string>(), _fixture.Create<Type[]>(), default(object[]), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
    }

    /// <summary>
    /// Checks that the Run method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithMethodNameAndParameterTypesAndConstructorParamsAndInputWithNullInput()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(_fixture.Create<string>(), _fixture.Create<Type[]>(), _fixture.Create<object[]>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the Run method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRunWithMethodNameAndParameterTypesAndConstructorParamsAndInputWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(value, _fixture.Create<Type[]>(), _fixture.Create<object[]>(), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRunWithMethodNameAndParameterTypesAndInput()
    {
        // Arrange
        var methodName = _fixture.Create<string>();
        var parameterTypes = _fixture.Create<Type[]>();
        var input = _fixture.Create<object[]>();

        // Act
        var result = Workout.Run<TClass>(methodName, parameterTypes, input
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithMethodNameAndParameterTypesAndInputWithNullParameterTypes()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(_fixture.Create<string>(), default(Type[]), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that the Run method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithMethodNameAndParameterTypesAndInputWithNullInput()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(_fixture.Create<string>(), _fixture.Create<Type[]>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the Run method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRunWithMethodNameAndParameterTypesAndInputWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(value, _fixture.Create<Type[]>(), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRunWithParameterTypesAndConstructorParamsAndInput()
    {
        // Arrange
        var parameterTypes = _fixture.Create<Type[]>();
        var constructorParams = _fixture.Create<object[]>();
        var input = _fixture.Create<object[]>();

        // Act
        var result = Workout.Run<TClass>(parameterTypes, constructorParams, input
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithParameterTypesAndConstructorParamsAndInputWithNullParameterTypes()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(default(Type[]), _fixture.Create<object[]>(), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that the Run method throws when the constructorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithParameterTypesAndConstructorParamsAndInputWithNullConstructorParams()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(_fixture.Create<Type[]>(), default(object[]), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
    }

    /// <summary>
    /// Checks that the Run method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithParameterTypesAndConstructorParamsAndInputWithNullInput()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(_fixture.Create<Type[]>(), _fixture.Create<object[]>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRunWithParameterTypesAndInput()
    {
        // Arrange
        var parameterTypes = _fixture.Create<Type[]>();
        var input = _fixture.Create<object[]>();

        // Act
        var result = Workout.Run<TClass>(parameterTypes, input);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithParameterTypesAndInputWithNullParameterTypes()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(default(Type[]), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that the Run method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithParameterTypesAndInputWithNullInput()
    {
        FluentActions.Invoking(() => Workout.Run<TClass>(_fixture.Create<Type[]>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }

    /// <summary>
    /// Checks that the Close method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClose()
    {
        // Arrange
        var safeClose = _fixture.Create<bool>();

        // Act
        this._testClass.Close(safeClose);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRunWithNoParameters()
    {
        // Act
        this._testClass.Run();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRunWithInput()
    {
        // Arrange
        var input = _fixture.Create<object[]>();

        // Act
        this._testClass.Run(input);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Run method throws when the input parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRunWithInputWithNullInput()
    {
        FluentActions.Invoking(() => this._testClass.Run(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("input");
    }
}