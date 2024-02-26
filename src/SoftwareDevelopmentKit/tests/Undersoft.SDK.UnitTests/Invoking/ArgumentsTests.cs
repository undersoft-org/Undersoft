using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Invoking;

namespace Undersoft.SDK.UnitTests.Invoking;

/// <summary>
/// Unit tests for the type <see cref="Arguments"/>.
/// </summary>
public class ArgumentsTests
{
    private Arguments _testClass;
    private IFixture _fixture;
    private Type _targetType;
    private string _targetName;
    private string _methodName;
    private object _argValue;
    private string _argName;
    private Argument _argument;
    private IEnumerable<object> _values;
    private IEnumerable<Argument> _arguments;
    private ParameterInfo[] _parameters;
    private Dictionary<string, object> _dictionary;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Arguments"/>.
    /// </summary>
    public ArgumentsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._targetType = _fixture.Create<Type>();
        this._targetName = _fixture.Create<string>();
        this._methodName = _fixture.Create<string>();
        this._argValue = _fixture.Create<object>();
        this._argName = _fixture.Create<string>();
        this._argument = _fixture.Create<Argument>();
        this._values = _fixture.Create<IEnumerable<object>>();
        this._arguments = _fixture.Create<IEnumerable<Argument>>();
        this._parameters = _fixture.Create<ParameterInfo[]>();
        this._dictionary = _fixture.Create<Dictionary<string, object>>();
        this._testClass = _fixture.Create<Arguments>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Arguments();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Arguments(this._targetType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Arguments(this._targetName);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Arguments(this._methodName, this._argValue, this._targetName, this._targetType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Arguments(this._methodName, this._argName, this._argValue, this._targetName, this._targetType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Arguments(this._methodName, this._argument, this._targetName, this._targetType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Arguments(this._methodName, this._values, this._targetName, this._targetType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Arguments(this._methodName, this._arguments, this._targetName, this._targetType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Arguments(this._methodName, this._parameters, this._targetName, this._targetType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Arguments(this._methodName, this._dictionary, this._targetName);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the targetType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTargetType()
    {
        FluentActions.Invoking(() => new Arguments(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("targetType");
    }

    /// <summary>
    /// Checks that instance construction throws when the argValue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullArgValue()
    {
        FluentActions.Invoking(() => new Arguments(this._methodName, default(object), this._targetName, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("argValue");
        FluentActions.Invoking(() => new Arguments(this._methodName, this._argName, default(object), this._targetName, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("argValue");
    }

    /// <summary>
    /// Checks that instance construction throws when the argument parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullArgument()
    {
        FluentActions.Invoking(() => new Arguments(this._methodName, default(Argument), this._targetName, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("argument");
    }

    /// <summary>
    /// Checks that instance construction throws when the values parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullValues()
    {
        FluentActions.Invoking(() => new Arguments(this._methodName, default(IEnumerable<object>), this._targetName, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("values");
    }

    /// <summary>
    /// Checks that instance construction throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullArguments()
    {
        FluentActions.Invoking(() => new Arguments(this._methodName, default(IEnumerable<Argument>), this._targetName, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that instance construction throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullParameters()
    {
        FluentActions.Invoking(() => new Arguments(this._methodName, default(ParameterInfo[]), this._targetName, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that instance construction throws when the dictionary parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullDictionary()
    {
        FluentActions.Invoking(() => new Arguments(this._methodName, default(Dictionary<string, object>), this._targetName)).Should().Throw<ArgumentNullException>().WithParameterName("dictionary");
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
        FluentActions.Invoking(() => new Arguments(value)).Should().Throw<ArgumentNullException>().WithParameterName("targetName");
        FluentActions.Invoking(() => new Arguments(this._methodName, this._argValue, value, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("targetName");
        FluentActions.Invoking(() => new Arguments(this._methodName, this._argName, this._argValue, value, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("targetName");
        FluentActions.Invoking(() => new Arguments(this._methodName, this._argument, value, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("targetName");
        FluentActions.Invoking(() => new Arguments(this._methodName, this._values, value, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("targetName");
        FluentActions.Invoking(() => new Arguments(this._methodName, this._arguments, value, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("targetName");
        FluentActions.Invoking(() => new Arguments(this._methodName, this._parameters, value, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("targetName");
        FluentActions.Invoking(() => new Arguments(this._methodName, this._dictionary, value)).Should().Throw<ArgumentNullException>().WithParameterName("targetName");
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
        FluentActions.Invoking(() => new Arguments(value, this._argValue, this._targetName, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Arguments(value, this._argName, this._argValue, this._targetName, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Arguments(value, this._argument, this._targetName, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Arguments(value, this._values, this._targetName, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Arguments(value, this._arguments, this._targetName, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Arguments(value, this._parameters, this._targetName, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
        FluentActions.Invoking(() => new Arguments(value, this._dictionary, this._targetName)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the constructor throws when the argName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidArgName(string value)
    {
        FluentActions.Invoking(() => new Arguments(this._methodName, value, this._argValue, this._targetName, this._targetType)).Should().Throw<ArgumentNullException>().WithParameterName("argName");
    }

    /// <summary>
    /// Checks that the ResolveArgumentTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallResolveArgumentTypes()
    {
        // Act
        var result = this._testClass.ResolveArgumentTypes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithNameAndValueAndMethodAndTarget()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var value = _fixture.Create<object>();
        var @method = _fixture.Create<string>();
        var target = _fixture.Create<string>();

        // Act
        var result = this._testClass.New(name, value, method, target);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithNameAndValueAndMethodAndTargetWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.New(_fixture.Create<string>(), default(object), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the New method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNewWithNameAndValueAndMethodAndTargetWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.New(value, _fixture.Create<object>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the New method throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNewWithNameAndValueAndMethodAndTargetWithInvalidMethod(string value)
    {
        FluentActions.Invoking(() => this._testClass.New(_fixture.Create<string>(), _fixture.Create<object>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the New method throws when the target parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNewWithNameAndValueAndMethodAndTargetWithInvalidTarget(string value)
    {
        FluentActions.Invoking(() => this._testClass.New(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the New maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewWithNameAndValueAndMethodAndTargetPerformsMapping()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var value = _fixture.Create<object>();
        var @method = _fixture.Create<string>();
        var target = _fixture.Create<string>();

        // Act
        var result = this._testClass.New(name, value, method, target);

        // Assert
        result.Name.Should().BeSameAs(name);
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithValueAndMethodAndTarget()
    {
        // Arrange
        var value = _fixture.Create<object>();
        var @method = _fixture.Create<string>();
        var target = _fixture.Create<string>();

        // Act
        var result = this._testClass.New(value, method, target);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithValueAndMethodAndTargetWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.New(default(object), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the New method throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNewWithValueAndMethodAndTargetWithInvalidMethod(string value)
    {
        FluentActions.Invoking(() => this._testClass.New(_fixture.Create<object>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the New method throws when the target parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNewWithValueAndMethodAndTargetWithInvalidTarget(string value)
    {
        FluentActions.Invoking(() => this._testClass.New(_fixture.Create<object>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the New maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewWithValueAndMethodAndTargetPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<object>();
        var @method = _fixture.Create<string>();
        var target = _fixture.Create<string>();

        // Act
        var result = this._testClass.New(value, method, target);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the ValueArray property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetValueArray()
    {
        // Assert
        this._testClass.ValueArray.Should().BeAssignableTo<object[]>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TypeArray property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetTypeArray()
    {
        // Assert
        this._testClass.TypeArray.Should().BeAssignableTo<Type[]>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the TargetType property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTargetType()
    {
        this._testClass.CheckProperty(x => x.TargetType, _fixture.Create<Type>(), _fixture.Create<Type>());
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