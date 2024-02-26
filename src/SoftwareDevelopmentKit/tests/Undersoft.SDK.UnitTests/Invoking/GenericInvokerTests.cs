using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Invoking;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Invoking;

/// <summary>
/// Unit tests for the type <see cref="Invoker"/>.
/// </summary>
public class Invoker_1Tests
{
    private Invoker<T> _testClass;
    private IFixture _fixture;
    private T _targetObject;
    private Arguments _arguemnts;
    private object[] _constructorParams;
    private Mock<IInvokable> _invoke;
    private Func<T, Delegate> _method;
    private Type[] _parameterTypesUnknownType;
    private string _methodName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Invoker"/>.
    /// </summary>
    public Invoker_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._targetObject = _fixture.Create<T>();
        this._arguemnts = _fixture.Create<Arguments>();
        this._constructorParams = _fixture.Create<object[]>();
        this._invoke = _fixture.Freeze<Mock<IInvokable>>();
        this._method = x => _fixture.Create<Delegate>();
        this._parameterTypesUnknownType = _fixture.Create<Type[]>();
        this._methodName = _fixture.Create<string>();
        this._testClass = _fixture.Create<Invoker<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Invoker<T>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._targetObject);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._arguemnts);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._targetObject, this._arguemnts);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._constructorParams);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._invoke.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._method);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._method, this._constructorParams);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._method, this._parameterTypesUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._targetObject, this._method);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._parameterTypesUnknownType, this._constructorParams);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._methodName);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._methodName, this._parameterTypesUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._methodName, this._parameterTypesUnknownType, this._constructorParams);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invoker<T>(this._methodName, this._constructorParams);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the arguemnts parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullArguemnts()
    {
        FluentActions.Invoking(() => new Invoker<T>(default(Arguments))).Should().Throw<ArgumentNullException>().WithParameterName("arguemnts");
        FluentActions.Invoking(() => new Invoker<T>(this._targetObject, default(Arguments))).Should().Throw<ArgumentNullException>().WithParameterName("arguemnts");
    }

    /// <summary>
    /// Checks that instance construction throws when the constructorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConstructorParams()
    {
        FluentActions.Invoking(() => new Invoker<T>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
        FluentActions.Invoking(() => new Invoker<T>(this._method, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
        FluentActions.Invoking(() => new Invoker<T>(this._parameterTypesUnknownType, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
        FluentActions.Invoking(() => new Invoker<T>(this._methodName, this._parameterTypesUnknownType, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
        FluentActions.Invoking(() => new Invoker<T>(this._methodName, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
    }

    /// <summary>
    /// Checks that instance construction throws when the invoke parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInvoke()
    {
        FluentActions.Invoking(() => new Invoker<T>(default(IInvokable))).Should().Throw<ArgumentNullException>().WithParameterName("invoke");
    }

    /// <summary>
    /// Checks that instance construction throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMethod()
    {
        FluentActions.Invoking(() => new Invoker<T>(default(Func<T, Delegate>))).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Invoker<T>(default(Func<T, Delegate>), this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Invoker<T>(default(Func<T, Delegate>), this._parameterTypesUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Invoker<T>(this._targetObject, default(Func<T, Delegate>))).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that instance construction throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullParameterTypes()
    {
        FluentActions.Invoking(() => new Invoker<T>(this._method, default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
        FluentActions.Invoking(() => new Invoker<T>(default(Type[]), this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
        FluentActions.Invoking(() => new Invoker<T>(this._methodName, default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
        FluentActions.Invoking(() => new Invoker<T>(this._methodName, default(Type[]), this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
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
        FluentActions.Invoking(() => new Invoker<T>(value)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Invoker<T>(value, this._parameterTypesUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Invoker<T>(value, this._parameterTypesUnknownType, this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Invoker<T>(value, this._constructorParams)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }
}