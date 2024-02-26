using System;
using System.Globalization;
using System.Reflection;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Rubrics;

namespace Undersoft.SDK.UnitTests.Rubrics;

/// <summary>
/// Unit tests for the type <see cref="MethodRubric"/>.
/// </summary>
public class MethodRubricTests
{
    private MethodRubric _testClass;
    private IFixture _fixture;
    private MethodInfo _method;
    private int _propertyId;
    private Type _declaringType;
    private string _propertyName;
    private Type _returnType;
    private ParameterInfo[] _parameterTypes;
    private Module _module;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MethodRubric"/>.
    /// </summary>
    public MethodRubricTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._method = _fixture.Create<MethodInfo>();
        this._propertyId = _fixture.Create<int>();
        this._declaringType = _fixture.Create<Type>();
        this._propertyName = _fixture.Create<string>();
        this._returnType = _fixture.Create<Type>();
        this._parameterTypes = _fixture.Create<ParameterInfo[]>();
        this._module = _fixture.Create<Module>();
        this._testClass = _fixture.Create<MethodRubric>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new MethodRubric();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MethodRubric(this._method, this._propertyId);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MethodRubric(this._declaringType, this._propertyName, this._returnType, this._parameterTypes, this._module, this._propertyId);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMethod()
    {
        FluentActions.Invoking(() => new MethodRubric(default(MethodInfo), this._propertyId)).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that instance construction throws when the declaringType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullDeclaringType()
    {
        FluentActions.Invoking(() => new MethodRubric(default(Type), this._propertyName, this._returnType, this._parameterTypes, this._module, this._propertyId)).Should().Throw<ArgumentNullException>().WithParameterName("declaringType");
    }

    /// <summary>
    /// Checks that instance construction throws when the returnType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullReturnType()
    {
        FluentActions.Invoking(() => new MethodRubric(this._declaringType, this._propertyName, default(Type), this._parameterTypes, this._module, this._propertyId)).Should().Throw<ArgumentNullException>().WithParameterName("returnType");
    }

    /// <summary>
    /// Checks that instance construction throws when the parameterTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullParameterTypes()
    {
        FluentActions.Invoking(() => new MethodRubric(this._declaringType, this._propertyName, this._returnType, default(ParameterInfo[]), this._module, this._propertyId)).Should().Throw<ArgumentNullException>().WithParameterName("parameterTypes");
    }

    /// <summary>
    /// Checks that instance construction throws when the module parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullModule()
    {
        FluentActions.Invoking(() => new MethodRubric(this._declaringType, this._propertyName, this._returnType, this._parameterTypes, default(Module), this._propertyId)).Should().Throw<ArgumentNullException>().WithParameterName("module");
    }

    /// <summary>
    /// Checks that the constructor throws when the propertyName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidPropertyName(string value)
    {
        FluentActions.Invoking(() => new MethodRubric(this._declaringType, value, this._returnType, this._parameterTypes, this._module, this._propertyId)).Should().Throw<ArgumentNullException>().WithParameterName("propertyName");
    }

    /// <summary>
    /// Checks that the GetBaseDefinition method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBaseDefinition()
    {
        // Act
        var result = this._testClass.GetBaseDefinition();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCustomAttributes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCustomAttributesWithInherit()
    {
        // Arrange
        var inherit = _fixture.Create<bool>();

        // Act
        var result = this._testClass.GetCustomAttributes(inherit);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCustomAttributes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCustomAttributesWithTypeAndBool()
    {
        // Arrange
        var attributeType = _fixture.Create<Type>();
        var inherit = _fixture.Create<bool>();

        // Act
        var result = this._testClass.GetCustomAttributes(attributeType, inherit);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCustomAttributes method throws when the attributeType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetCustomAttributesWithTypeAndBoolWithNullAttributeType()
    {
        FluentActions.Invoking(() => this._testClass.GetCustomAttributes(default(Type), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("attributeType");
    }

    /// <summary>
    /// Checks that the GetMethodImplementationFlags method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMethodImplementationFlags()
    {
        // Act
        var result = this._testClass.GetMethodImplementationFlags();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetParameters method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetParameters()
    {
        // Act
        var result = this._testClass.GetParameters();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Invoke method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInvoke()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var invokeAttr = _fixture.Create<BindingFlags>();
        var binder = _fixture.Create<Binder>();
        var parameters = _fixture.Create<object[]>();
        var culture = _fixture.Create<CultureInfo>();

        // Act
        var result = this._testClass.Invoke(obj, invokeAttr, binder, parameters, culture
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Invoke(default(object), _fixture.Create<BindingFlags>(), _fixture.Create<Binder>(), _fixture.Create<object[]>(), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the binder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithNullBinder()
    {
        FluentActions.Invoking(() => this._testClass.Invoke(_fixture.Create<object>(), _fixture.Create<BindingFlags>(), default(Binder), _fixture.Create<object[]>(), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("binder");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.Invoke(_fixture.Create<object>(), _fixture.Create<BindingFlags>(), _fixture.Create<Binder>(), default(object[]), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the culture parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInvokeWithNullCulture()
    {
        FluentActions.Invoking(() => this._testClass.Invoke(_fixture.Create<object>(), _fixture.Create<BindingFlags>(), _fixture.Create<Binder>(), _fixture.Create<object[]>(), default(CultureInfo))).Should().Throw<ArgumentNullException>().WithParameterName("culture");
    }

    /// <summary>
    /// Checks that the IsDefined method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsDefined()
    {
        // Arrange
        var attributeType = _fixture.Create<Type>();
        var inherit = _fixture.Create<bool>();

        // Act
        var result = this._testClass.IsDefined(attributeType, inherit);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsDefined method throws when the attributeType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsDefinedWithNullAttributeType()
    {
        FluentActions.Invoking(() => this._testClass.IsDefined(default(Type), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("attributeType");
    }

    /// <summary>
    /// Checks that the Attributes property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetAttributes()
    {
        // Assert
        this._testClass.Attributes.As<object>().Should().BeAssignableTo<MethodAttributes>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Editable property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEditable()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.Editable = testValue;

        // Assert
        this._testClass.Editable.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the MethodHandle property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetMethodHandle()
    {
        // Assert
        this._testClass.MethodHandle.As<object>().Should().BeAssignableTo<RuntimeMethodHandle>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Name property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetName()
    {
        // Assert
        this._testClass.Name.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReflectedType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetReflectedType()
    {
        // Assert
        this._testClass.ReflectedType.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReturnTypeCustomAttributes property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetReturnTypeCustomAttributes()
    {
        // Assert
        this._testClass.ReturnTypeCustomAttributes.Should().BeAssignableTo<ICustomAttributeProvider>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RubricAttributes property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricAttributes()
    {
        // Arrange
        var testValue = _fixture.Create<object[]>();

        // Act
        this._testClass.RubricAttributes = testValue;

        // Assert
        this._testClass.RubricAttributes.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the RubricId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricId()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.RubricId = testValue;

        // Assert
        this._testClass.RubricId.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the MemberInfo property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetMemberInfo()
    {
        // Assert
        this._testClass.MemberInfo.Should().BeAssignableTo<MemberInfo>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RubricInfo property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricInfo()
    {
        // Arrange
        var testValue = _fixture.Create<MethodInfo>();

        // Act
        this._testClass.RubricInfo = testValue;

        // Assert
        this._testClass.RubricInfo.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the RubricModule property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricModule()
    {
        // Arrange
        var testValue = _fixture.Create<Module>();

        // Act
        this._testClass.RubricModule = testValue;

        // Assert
        this._testClass.RubricModule.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the RubricName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.RubricName = testValue;

        // Assert
        this._testClass.RubricName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the RubricOffset property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricOffset()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.RubricOffset = testValue;

        // Assert
        this._testClass.RubricOffset.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the RubricParameterInfo property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricParameterInfo()
    {
        // Arrange
        var testValue = _fixture.Create<ParameterInfo[]>();

        // Act
        this._testClass.RubricParameterInfo = testValue;

        // Assert
        this._testClass.RubricParameterInfo.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the RubricReturnType property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricReturnType()
    {
        // Arrange
        var testValue = _fixture.Create<Type>();

        // Act
        this._testClass.RubricReturnType = testValue;

        // Assert
        this._testClass.RubricReturnType.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the RubricSize property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricSize()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.RubricSize = testValue;

        // Assert
        this._testClass.RubricSize.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the RubricType property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricType()
    {
        // Arrange
        var testValue = _fixture.Create<Type>();

        // Act
        this._testClass.RubricType = testValue;

        // Assert
        this._testClass.RubricType.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Visible property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetVisible()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.Visible = testValue;

        // Assert
        this._testClass.Visible.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the DisplayName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDisplayName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.DisplayName = testValue;

        // Assert
        this._testClass.DisplayName.Should().Be(testValue);
    }
}