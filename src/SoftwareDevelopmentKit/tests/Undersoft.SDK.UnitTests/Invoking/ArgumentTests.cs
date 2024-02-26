using System;
using System.Reflection;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Invoking;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Invoking;

/// <summary>
/// Unit tests for the type <see cref="Argument"/>.
/// </summary>
public class ArgumentTests
{
    private Argument _testClass;
    private IFixture _fixture;
    private Mock<IArgument> _valueIArgument;
    private string _method;
    private string _target;
    private object _valueObject;
    private string _name;
    private Type _type;
    private string _argTypeName;
    private ParameterInfo _info;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Argument"/>.
    /// </summary>
    public ArgumentTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._valueIArgument = _fixture.Freeze<Mock<IArgument>>();
        this._method = _fixture.Create<string>();
        this._target = _fixture.Create<string>();
        this._valueObject = _fixture.Create<object>();
        this._name = _fixture.Create<string>();
        this._type = _fixture.Create<Type>();
        this._argTypeName = _fixture.Create<string>();
        this._info = _fixture.Create<ParameterInfo>();
        this._testClass = _fixture.Create<Argument>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Argument();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Argument(this._valueIArgument.Object, this._method, this._target);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Argument(this._valueObject, this._method, this._target);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Argument(this._name, this._valueObject, this._method, this._target);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Argument(this._name, this._type, this._method, this._target);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Argument(this._name, this._argTypeName, this._method, this._target);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Argument(this._info, this._method, this._target);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullValue()
    {
        FluentActions.Invoking(() => new Argument(default(IArgument), this._method, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new Argument(default(object), this._method, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new Argument(this._name, default(object), this._method, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that instance construction throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullType()
    {
        FluentActions.Invoking(() => new Argument(this._name, default(Type), this._method, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that instance construction throws when the info parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInfo()
    {
        FluentActions.Invoking(() => new Argument(default(ParameterInfo), this._method, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("info");
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
        FluentActions.Invoking(() => new Argument(this._valueIArgument.Object, value, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Argument(this._valueObject, value, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Argument(this._name, this._valueObject, value, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Argument(this._name, this._type, value, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Argument(this._name, this._argTypeName, value, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Argument(this._info, value, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the constructor throws when the target parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidTarget(string value)
    {
        FluentActions.Invoking(() => new Argument(this._valueIArgument.Object, this._method, value)).Should().Throw<ArgumentNullException>().WithParameterName("target");
        FluentActions.Invoking(() => new Argument(this._valueObject, this._method, value)).Should().Throw<ArgumentNullException>().WithParameterName("target");
        FluentActions.Invoking(() => new Argument(this._name, this._valueObject, this._method, value)).Should().Throw<ArgumentNullException>().WithParameterName("target");
        FluentActions.Invoking(() => new Argument(this._name, this._type, this._method, value)).Should().Throw<ArgumentNullException>().WithParameterName("target");
        FluentActions.Invoking(() => new Argument(this._name, this._argTypeName, this._method, value)).Should().Throw<ArgumentNullException>().WithParameterName("target");
        FluentActions.Invoking(() => new Argument(this._info, this._method, value)).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the constructor throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidName(string value)
    {
        FluentActions.Invoking(() => new Argument(value, this._valueObject, this._method, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("name");
        FluentActions.Invoking(() => new Argument(value, this._type, this._method, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("name");
        FluentActions.Invoking(() => new Argument(value, this._argTypeName, this._method, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the constructor throws when the argTypeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidArgTypeName(string value)
    {
        FluentActions.Invoking(() => new Argument(this._name, value, this._method, this._target)).Should().Throw<ArgumentNullException>().WithParameterName("argTypeName");
    }

    /// <summary>
    /// Checks that the ResolveType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallResolveType()
    {
        // Act
        var result = this._testClass.ResolveType();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Serialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSerialize()
    {
        // Arrange
        var value = _fixture.Create<object>();

        // Act
        this._testClass.Serialize(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Serialize method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSerializeWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Serialize(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Deserialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeserializeWithNoParameters()
    {
        // Act
        var result = this._testClass.Deserialize();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Deserialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeserializeWithT()
    {
        // Act
        var result = this._testClass.Deserialize<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithParameterInfoAndStringAndString()
    {
        // Arrange
        var item = _fixture.Create<ParameterInfo>();
        var @method = _fixture.Create<string>();
        var target = _fixture.Create<string>();

        // Act
        this._testClass.Set(item, method, target);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithParameterInfoAndStringAndStringWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(ParameterInfo), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Set method throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetWithParameterInfoAndStringAndStringWithInvalidMethod(string value)
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<ParameterInfo>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Set method throws when the target parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetWithParameterInfoAndStringAndStringWithInvalidTarget(string value)
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<ParameterInfo>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithIArgumentAndStringAndString()
    {
        // Arrange
        var item = _fixture.Create<IArgument>();
        var @method = _fixture.Create<string>();
        var target = _fixture.Create<string>();

        // Act
        this._testClass.Set(item, method, target);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithIArgumentAndStringAndStringWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(IArgument), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Set method throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetWithIArgumentAndStringAndStringWithInvalidMethod(string value)
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<IArgument>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Set method throws when the target parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetWithIArgumentAndStringAndStringWithInvalidTarget(string value)
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<IArgument>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithNameAndValueAndMethodAndTargetAndPosition()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var value = _fixture.Create<object>();
        var @method = _fixture.Create<string>();
        var target = _fixture.Create<string>();
        var position = _fixture.Create<int>();

        // Act
        this._testClass.Set(name, value, method, target, position);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithNameAndValueAndMethodAndTargetAndPositionWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<string>(), default(object), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Set method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetWithNameAndValueAndMethodAndTargetAndPositionWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Set(value, _fixture.Create<object>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the Set method throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetWithNameAndValueAndMethodAndTargetAndPositionWithInvalidMethod(string value)
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<string>(), _fixture.Create<object>(), value, _fixture.Create<string>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Set method throws when the target parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetWithNameAndValueAndMethodAndTargetAndPositionWithInvalidTarget(string value)
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<string>(), _fixture.Create<object>(), _fixture.Create<string>(), value, _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithNameAndTypeAndMethodAndTargetAndPosition()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var @type = _fixture.Create<Type>();
        var @method = _fixture.Create<string>();
        var target = _fixture.Create<string>();
        var position = _fixture.Create<int>();

        // Act
        this._testClass.Set(name, type, method, target, position);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithNameAndTypeAndMethodAndTargetAndPositionWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<string>(), default(Type), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the Set method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetWithNameAndTypeAndMethodAndTargetAndPositionWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Set(value, _fixture.Create<Type>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the Set method throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetWithNameAndTypeAndMethodAndTargetAndPositionWithInvalidMethod(string value)
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<string>(), _fixture.Create<Type>(), value, _fixture.Create<string>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the Set method throws when the target parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetWithNameAndTypeAndMethodAndTargetAndPositionWithInvalidTarget(string value)
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<string>(), _fixture.Create<Type>(), _fixture.Create<string>(), value, _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that setting the TargetName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTargetName()
    {
        this._testClass.CheckProperty(x => x.TargetName);
    }

    /// <summary>
    /// Checks that setting the MethodName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMethodName()
    {
        this._testClass.CheckProperty(x => x.MethodName);
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
    /// Checks that setting the Data property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetData()
    {
        this._testClass.CheckProperty(x => x.Data, _fixture.Create<byte[]>(), _fixture.Create<byte[]>());
    }

    /// <summary>
    /// Checks that setting the IsValid property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsValid()
    {
        this._testClass.CheckProperty(x => x.IsValid);
    }

    /// <summary>
    /// Checks that setting the Position property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPosition()
    {
        this._testClass.CheckProperty(x => x.Position);
    }

    /// <summary>
    /// Checks that setting the ArgumentTypeName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetArgumentTypeName()
    {
        this._testClass.CheckProperty(x => x.ArgumentTypeName);
    }
}