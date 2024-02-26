using System;
using System.Reflection;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Uniques;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Invoking;

/// <summary>
/// Unit tests for the type <see cref="Invoker"/>.
/// </summary>
public class InvokerTests
{
    private Invoker _testClass;
    private IFixture _fixture;
    private Arguments _args;
    private object _targetObject;
    private MethodInfo _methodInvokeInfo;
    private Delegate _targetMethod;
    private string _methodName;
    private Type[] _parameterTypesUnknownType;
    private Type _targetType;
    private object[] _constructorParameters;
    private object[] _constructorParams;
    private string _targetName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Invoker"/>.
    /// </summary>
    public InvokerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._args = _fixture.Create<Arguments>();
        this._targetObject = _fixture.Create<object>();
        this._methodInvokeInfo = _fixture.Create<MethodInfo>();
        this._targetMethod = _fixture.Create<Delegate>();
        this._methodName = _fixture.Create<string>();
        this._parameterTypesUnknownType = _fixture.Create<Type[]>();
        this._targetType = _fixture.Create<Type>();
        this._constructorParameters = _fixture.Create<object[]>();
        this._constructorParams = _fixture.Create<object[]>();
        this._targetName = _fixture.Create<string>();
        this._testClass = _fixture.Create<Invoker>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Invoker();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._args);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetObject, this._args);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetObject, this._methodInvokeInfo);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetMethod);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetObject, this._methodName, this._parameterTypesUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetType, this._parameterTypesUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetType, this._parameterTypesUnknownType, this._constructorParameters);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetType, this._constructorParameters);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetObject, this._methodName);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetObject, this._methodName, this._constructorParameters);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetType, this._methodName);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetType, this._methodName, this._parameterTypesUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetType, this._methodName, this._constructorParams);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetType, this._methodName, this._parameterTypesUnknownType, this._constructorParams);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetName, this._methodName);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetName, this._methodName, this._parameterTypesUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._targetName, this._methodName, this._parameterTypesUnknownType, this._constructorParams);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._methodInvokeInfo);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker(this._methodInvokeInfo, this._constructorParams);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the args parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullArgs()
    {
        FluentActions.Invoking(() => new Invoker(default(Arguments))).Should().Throw<ArgumentNullException>().WithParameterName("args");
        FluentActions.Invoking(() => new Invoker(this._targetObject, default(Arguments))).Should().Throw<ArgumentNullException>().WithParameterName("args");
    }

    /// <summary>
    /// Checks that instance construction throws when the targetObject parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTargetObject()
    {
        FluentActions.Invoking(() => new Invoker(default(object), this._args)).Should().Throw<ArgumentNullException>().WithParameterName("targetObject");
        FluentActions.Invoking(() => new Invoker(default(object), this._methodInvokeInfo)).Should().Throw<ArgumentNullException>().WithParameterName("targetObject");
        FluentActions.Invoking(() => new Invoker(default(object), this._methodName, this._parameterTypesUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("targetObject");
        FluentActions.Invoking(() => new Invoker(default(object), this._methodName)).Should().Throw<ArgumentNullException>().WithParameterName("targetObject");
        FluentActions.Invoking(() => new Invoker(default(object), this._methodName, this._constructorParameters)).Should().Throw<ArgumentNullException>().WithParameterName("targetObject");
    }

    /// <summary>
    /// Checks that instance construction throws when the methodInvokeInfo parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMethodInvokeInfo()
    {
        FluentActions.Invoking(() => new Invoker(this._targetObject, default(MethodInfo))).Should().Throw<ArgumentNullException>().WithParameterName("methodInvokeInfo");
        FluentActions.Invoking(() => new Invoker(default(MethodInfo))).Should().Throw<ArgumentNullException>().WithParameterName("methodInvokeInfo");
        FluentActions.Invoking(() => new Invoker(default(MethodInfo), this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("methodInvokeInfo");
    }

    /// <summary>
    /// Checks that instance construction throws when the targetMethod parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTargetMethod()
    {
        FluentActions.Invoking(() => new Invoker(default(Delegate))).Should().Throw<ArgumentNullException>().WithParameterName("targetMethod");
    }

    /// <summary>
    /// Checks that instance construction throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullParameterTypes()
    {
        FluentActions.Invoking(() => new Invoker(this._targetObject, this._methodName, default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
        FluentActions.Invoking(() => new Invoker(this._targetType, default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
        FluentActions.Invoking(() => new Invoker(this._targetType, default(Type[]), this._constructorParameters)).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
        FluentActions.Invoking(() => new Invoker(this._targetType, this._methodName, default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
        FluentActions.Invoking(() => new Invoker(this._targetType, this._methodName, default(Type[]), this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
        FluentActions.Invoking(() => new Invoker(this._targetName, this._methodName, default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
        FluentActions.Invoking(() => new Invoker(this._targetName, this._methodName, default(Type[]), this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that instance construction throws when the targetType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTargetType()
    {
        FluentActions.Invoking(() => new Invoker(default(Type), this._parameterTypesUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("targetType");
        FluentActions.Invoking(() => new Invoker(default(Type), this._parameterTypesUnknownType, this._constructorParameters)).Should().Throw<ArgumentNullException>().WithParameterName("targetType");
        FluentActions.Invoking(() => new Invoker(default(Type), this._constructorParameters)).Should().Throw<ArgumentNullException>().WithParameterName("targetType");
        FluentActions.Invoking(() => new Invoker(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("targetType");
        FluentActions.Invoking(() => new Invoker(default(Type), this._methodName)).Should().Throw<ArgumentNullException>().WithParameterName("targetType");
        FluentActions.Invoking(() => new Invoker(default(Type), this._methodName, this._parameterTypesUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("targetType");
        FluentActions.Invoking(() => new Invoker(default(Type), this._methodName, this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("targetType");
        FluentActions.Invoking(() => new Invoker(default(Type), this._methodName, this._parameterTypesUnknownType, this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("targetType");
    }

    /// <summary>
    /// Checks that instance construction throws when the constructorParameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConstructorParameters()
    {
        FluentActions.Invoking(() => new Invoker(this._targetType, this._parameterTypesUnknownType, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParameters");
        FluentActions.Invoking(() => new Invoker(this._targetType, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParameters");
        FluentActions.Invoking(() => new Invoker(this._targetObject, this._methodName, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParameters");
    }

    /// <summary>
    /// Checks that instance construction throws when the constructorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConstructorParams()
    {
        FluentActions.Invoking(() => new Invoker(this._targetType, this._methodName, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
        FluentActions.Invoking(() => new Invoker(this._targetType, this._methodName, this._parameterTypesUnknownType, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
        FluentActions.Invoking(() => new Invoker(this._targetName, this._methodName, this._parameterTypesUnknownType, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
        FluentActions.Invoking(() => new Invoker(this._methodInvokeInfo, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
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
        FluentActions.Invoking(() => new Invoker(this._targetObject, value, this._parameterTypesUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Invoker(this._targetObject, value)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Invoker(this._targetObject, value, this._constructorParameters)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Invoker(this._targetType, value)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Invoker(this._targetType, value, this._parameterTypesUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Invoker(this._targetType, value, this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Invoker(this._targetType, value, this._parameterTypesUnknownType, this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Invoker(this._targetName, value)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Invoker(this._targetName, value, this._parameterTypesUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Invoker(this._targetName, value, this._parameterTypesUnknownType, this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the constructor throws when the targetName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidTargetName(string value)
    {
        FluentActions.Invoking(() => new Invoker(value, this._methodName)).Should().Throw<ArgumentNullException>().WithParameterName("targetName");
        FluentActions.Invoking(() => new Invoker(value, this._methodName, this._parameterTypesUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("targetName");
        FluentActions.Invoking(() => new Invoker(value, this._methodName, this._parameterTypesUnknownType, this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("targetName");
    }

    /// <summary>
    /// Checks that the Fire method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFireWithArrayOfObjectAsync()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        await this._testClass.Fire(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Fire method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFireWithArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Fire(default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Fire method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFireWithBoolAndObjectAndArrayOfObjectAsync()
    {
        // Arrange
        var withTarget = _fixture.Create<bool>();
        var target = _fixture.Create<object>();
        var parameters = _fixture.Create<object[]>();

        // Act
        await this._testClass.Fire(withTarget, target, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Fire method throws when the target parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFireWithBoolAndObjectAndArrayOfObjectWithNullTargetAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Fire(_fixture.Create<bool>(), default(object), _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the Fire method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFireWithBoolAndObjectAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Fire(_fixture.Create<bool>(), _fixture.Create<object>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Invoke method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInvokeWithArrayOfObject()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Invoke(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithArrayOfObjectWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.Invoke(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Invoke method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInvokeWithBoolAndObjectAndArrayOfObject()
    {
        // Arrange
        var withTarget = _fixture.Create<bool>();
        var target = _fixture.Create<object>();
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Invoke(withTarget, target, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithBoolAndObjectAndArrayOfObjectWithNullTarget()
    {
        FluentActions.Invoking(() => this._testClass.Invoke(_fixture.Create<bool>(), default(object), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithBoolAndObjectAndArrayOfObjectWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.Invoke(_fixture.Create<bool>(), _fixture.Create<object>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Invoke method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInvokeWithTAndArrayOfObject()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Invoke<T>(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithTAndArrayOfObjectWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.Invoke<T>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Invoke method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInvokeWithTAndBoolAndObjectAndArrayOfObject()
    {
        // Arrange
        var withTarget = _fixture.Create<bool>();
        var target = _fixture.Create<object>();
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.Invoke<T>(withTarget, target, parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithTAndBoolAndObjectAndArrayOfObjectWithNullTarget()
    {
        FluentActions.Invoking(() => this._testClass.Invoke<T>(_fixture.Create<bool>(), default(object), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithTAndBoolAndObjectAndArrayOfObjectWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.Invoke<T>(_fixture.Create<bool>(), _fixture.Create<object>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithArrayOfObjectAsync()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.InvokeAsync(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithBoolAndObjectAndArrayOfObjectAsync()
    {
        // Arrange
        var withTarget = _fixture.Create<bool>();
        var target = _fixture.Create<object>();
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.InvokeAsync(withTarget, target, parameters
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the target parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithBoolAndObjectAndArrayOfObjectWithNullTargetAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(_fixture.Create<bool>(), default(object), _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithBoolAndObjectAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(_fixture.Create<bool>(), _fixture.Create<object>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithTAndArrayOfObjectAsync()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.InvokeAsync<T>(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithTAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync<T>(default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithTAndBoolAndObjectAndArrayOfObjectAsync()
    {
        // Arrange
        var withTarget = _fixture.Create<bool>();
        var target = _fixture.Create<object>();
        var parameters = _fixture.Create<object[]>();

        // Act
        var result = await this._testClass.InvokeAsync<T>(withTarget, target, parameters
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the target parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithTAndBoolAndObjectAndArrayOfObjectWithNullTargetAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync<T>(_fixture.Create<bool>(), default(object), _fixture.Create<object[]>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithTAndBoolAndObjectAndArrayOfObjectWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync<T>(_fixture.Create<bool>(), _fixture.Create<object>(), default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithArgumentsAsync()
    {
        // Arrange
        var arguments = _fixture.Create<Arguments>();

        // Act
        var result = await this._testClass.InvokeAsync(arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the arguments parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithArgumentsWithNullArgumentsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(default(Arguments))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithBoolAndObjectAndArgumentsAsync()
    {
        // Arrange
        var withTarget = _fixture.Create<bool>();
        var target = _fixture.Create<object>();
        var arguments = _fixture.Create<Arguments>();

        // Act
        var result = await this._testClass.InvokeAsync(withTarget, target, arguments
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the target parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithBoolAndObjectAndArgumentsWithNullTargetAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(_fixture.Create<bool>(), default(object), _fixture.Create<Arguments>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the arguments parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithBoolAndObjectAndArgumentsWithNullArgumentsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync(_fixture.Create<bool>(), _fixture.Create<object>(), default(Arguments))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithTAndArgumentsAsync()
    {
        // Arrange
        var arguments = _fixture.Create<Arguments>();

        // Act
        var result = await this._testClass.InvokeAsync<T>(arguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the arguments parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithTAndArgumentsWithNullArgumentsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync<T>(default(Arguments))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the InvokeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsyncWithTAndBoolAndObjectAndArgumentsAsync()
    {
        // Arrange
        var withTarget = _fixture.Create<bool>();
        var target = _fixture.Create<object>();
        var arguments = _fixture.Create<Arguments>();

        // Act
        var result = await this._testClass.InvokeAsync<T>(withTarget, target, arguments
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the target parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithTAndBoolAndObjectAndArgumentsWithNullTargetAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync<T>(_fixture.Create<bool>(), default(object), _fixture.Create<Arguments>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the InvokeAsync method throws when the arguments parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeAsyncWithTAndBoolAndObjectAndArgumentsWithNullArgumentsAsync()
    {
        await FluentActions.Invoking(() => this._testClass.InvokeAsync<T>(_fixture.Create<bool>(), _fixture.Create<object>(), default(Arguments))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that the ConvertType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConvertType()
    {
        // Arrange
        var source = _fixture.Create<object>();
        var destination = _fixture.Create<Type>();

        // Act
        var result = this._testClass.ConvertType(source, destination);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ConvertType method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConvertTypeWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.ConvertType(default(object), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the ConvertType method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConvertTypeWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.ConvertType(_fixture.Create<object>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the GetName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetNameWithTypeAndStringAndArrayOfType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var methodName = _fixture.Create<string>();
        var parameterTypes = _fixture.Create<Type[]>();

        // Act
        var result = Invoker.GetName(type, methodName, parameterTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetName method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetNameWithTypeAndStringAndArrayOfTypeWithNullType()
    {
        FluentActions.Invoking(() => Invoker.GetName(default(Type), _fixture.Create<string>(), _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetName method throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetNameWithTypeAndStringAndArrayOfTypeWithNullParameterTypes()
    {
        FluentActions.Invoking(() => Invoker.GetName(_fixture.Create<Type>(), _fixture.Create<string>(), default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that the GetName method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetNameWithTypeAndStringAndArrayOfTypeWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => Invoker.GetName(_fixture.Create<Type>(), value, _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the GetName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetNameWithTypeAndArrayOfType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var parameterTypes = _fixture.Create<Type[]>();

        // Act
        var result = Invoker.GetName(type, parameterTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetName method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetNameWithTypeAndArrayOfTypeWithNullType()
    {
        FluentActions.Invoking(() => Invoker.GetName(default(Type), _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetName method throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetNameWithTypeAndArrayOfTypeWithNullParameterTypes()
    {
        FluentActions.Invoking(() => Invoker.GetName(_fixture.Create<Type>(), default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that the GetName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetNameWithTAndStringAndArrayOfType()
    {
        // Arrange
        var methodName = _fixture.Create<string>();
        var parameterTypes = _fixture.Create<Type[]>();

        // Act
        var result = Invoker.GetName<T>(methodName, parameterTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetName method throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetNameWithTAndStringAndArrayOfTypeWithNullParameterTypes()
    {
        FluentActions.Invoking(() => Invoker.GetName<T>(_fixture.Create<string>(), default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that the GetName method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetNameWithTAndStringAndArrayOfTypeWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => Invoker.GetName<T>(value, _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the GetName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetNameWithTAndArrayOfType()
    {
        // Arrange
        var parameterTypes = _fixture.Create<Type[]>();

        // Act
        var result = Invoker.GetName<T>(parameterTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetName method throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetNameWithTAndArrayOfTypeWithNullParameterTypes()
    {
        FluentActions.Invoking(() => Invoker.GetName<T>(default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that the GetQualifiedName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetQualifiedNameWithTypeAndStringAndArrayOfType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var methodName = _fixture.Create<string>();
        var parameterTypes = _fixture.Create<Type[]>();

        // Act
        var result = Invoker.GetQualifiedName(type, methodName, parameterTypes
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetQualifiedName method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetQualifiedNameWithTypeAndStringAndArrayOfTypeWithNullType()
    {
        FluentActions.Invoking(() => Invoker.GetQualifiedName(default(Type), _fixture.Create<string>(), _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetQualifiedName method throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetQualifiedNameWithTypeAndStringAndArrayOfTypeWithNullParameterTypes()
    {
        FluentActions.Invoking(() => Invoker.GetQualifiedName(_fixture.Create<Type>(), _fixture.Create<string>(), default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that the GetQualifiedName method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetQualifiedNameWithTypeAndStringAndArrayOfTypeWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => Invoker.GetQualifiedName(_fixture.Create<Type>(), value, _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the GetQualifiedName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetQualifiedNameWithTypeAndArrayOfType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var parameterTypes = _fixture.Create<Type[]>();

        // Act
        var result = Invoker.GetQualifiedName(type, parameterTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetQualifiedName method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetQualifiedNameWithTypeAndArrayOfTypeWithNullType()
    {
        FluentActions.Invoking(() => Invoker.GetQualifiedName(default(Type), _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetQualifiedName method throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetQualifiedNameWithTypeAndArrayOfTypeWithNullParameterTypes()
    {
        FluentActions.Invoking(() => Invoker.GetQualifiedName(_fixture.Create<Type>(), default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that the GetQualifiedName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetQualifiedNameWithTAndArrayOfType()
    {
        // Arrange
        var parameterTypes = _fixture.Create<Type[]>();

        // Act
        var result = Invoker.GetQualifiedName<T>(parameterTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetQualifiedName method throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetQualifiedNameWithTAndArrayOfTypeWithNullParameterTypes()
    {
        FluentActions.Invoking(() => Invoker.GetQualifiedName<T>(default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that the GetQualifiedName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetQualifiedNameWithTAndStringAndArrayOfType()
    {
        // Arrange
        var methodName = _fixture.Create<string>();
        var parameterTypes = _fixture.Create<Type[]>();

        // Act
        var result = Invoker.GetQualifiedName<T>(methodName, parameterTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetQualifiedName method throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetQualifiedNameWithTAndStringAndArrayOfTypeWithNullParameterTypes()
    {
        FluentActions.Invoking(() => Invoker.GetQualifiedName<T>(_fixture.Create<string>(), default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that the GetQualifiedName method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetQualifiedNameWithTAndStringAndArrayOfTypeWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => Invoker.GetQualifiedName<T>(value, _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that setting the Code property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCode()
    {
        this._testClass.CheckProperty(x => x.Code, _fixture.Create<Uscn>(), _fixture.Create<Uscn>());
    }

    /// <summary>
    /// Checks that setting the Name property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetName()
    {
        this._testClass.CheckProperty(x => x.Name);
    }

    /// <summary>
    /// Checks that the TypeName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetTypeName()
    {
        // Assert
        this._testClass.TypeName.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the QualifiedName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetQualifiedName()
    {
        this._testClass.CheckProperty(x => x.QualifiedName);
    }

    /// <summary>
    /// Checks that the MethodInvoker property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetMethodInvoker()
    {
        // Assert
        this._testClass.MethodInvoker.Should().BeAssignableTo<InvokerDelegate>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the TargetObject property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTargetObject()
    {
        this._testClass.CheckProperty(x => x.TargetObject, _fixture.Create<object>(), _fixture.Create<object>());
    }

    /// <summary>
    /// Checks that setting the Method property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMethod()
    {
        this._testClass.CheckProperty(x => x.Method, _fixture.Create<Delegate>(), _fixture.Create<Delegate>());
    }

    /// <summary>
    /// Checks that setting the Info property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInfo()
    {
        this._testClass.CheckProperty(x => x.Info, _fixture.Create<MethodInfo>(), _fixture.Create<MethodInfo>());
    }

    /// <summary>
    /// Checks that setting the Parameters property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetParameters()
    {
        this._testClass.CheckProperty(x => x.Parameters, _fixture.Create<ParameterInfo[]>(), _fixture.Create<ParameterInfo[]>());
    }

    /// <summary>
    /// Checks that setting the Arguments property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetArguments()
    {
        this._testClass.CheckProperty(x => x.Arguments, _fixture.Create<Arguments>(), _fixture.Create<Arguments>());
    }

    /// <summary>
    /// Checks that the ReturnType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetReturnType()
    {
        // Assert
        this._testClass.ReturnType.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the NumberOfArguments property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNumberOfArguments()
    {
        this._testClass.CheckProperty(x => x.NumberOfArguments);
    }

    /// <summary>
    /// Checks that setting the StateOn property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetStateOn()
    {
        this._testClass.CheckProperty(x => x.StateOn, _fixture.Create<StateOn>(), _fixture.Create<StateOn>());
    }

    /// <summary>
    /// Checks that the Empty property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetEmpty()
    {
        // Assert
        this._testClass.Empty.Should().BeAssignableTo<IUnique>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the ValueArray property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetValueArray()
    {
        this._testClass.CheckProperty(x => x.ValueArray, _fixture.Create<object[]>(), _fixture.Create<object[]>());
    }

    /// <summary>
    /// Checks that the Type property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetType()
    {
        // Assert
        this._testClass.Type.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AssemblyName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetAssemblyName()
    {
        // Assert
        this._testClass.AssemblyName.Should().BeAssignableTo<AssemblyName>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForInt()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForString()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<string>()] = testValue;
        this._testClass[_fixture.Create<string>()].Should().BeSameAs(testValue);
    }
}