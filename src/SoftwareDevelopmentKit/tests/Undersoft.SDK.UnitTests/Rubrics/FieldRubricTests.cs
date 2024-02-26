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
/// Unit tests for the type <see cref="FieldRubric"/>.
/// </summary>
public class FieldRubricTests
{
    private FieldRubric _testClass;
    private IFixture _fixture;
    private FieldInfo _field;
    private int _size;
    private int _fieldId;
    private Type _fieldType;
    private string _fieldName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="FieldRubric"/>.
    /// </summary>
    public FieldRubricTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._field = _fixture.Create<FieldInfo>();
        this._size = _fixture.Create<int>();
        this._fieldId = _fixture.Create<int>();
        this._fieldType = _fixture.Create<Type>();
        this._fieldName = _fixture.Create<string>();
        this._testClass = _fixture.Create<FieldRubric>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new FieldRubric();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new FieldRubric(this._field, this._size, this._fieldId);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new FieldRubric(this._fieldType, this._fieldName, this._size, this._fieldId);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullField()
    {
        FluentActions.Invoking(() => new FieldRubric(default(FieldInfo), this._size, this._fieldId)).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that instance construction throws when the fieldType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullFieldType()
    {
        FluentActions.Invoking(() => new FieldRubric(default(Type), this._fieldName, this._size, this._fieldId)).Should().Throw<ArgumentNullException>().WithParameterName("fieldType");
    }

    /// <summary>
    /// Checks that the constructor throws when the fieldName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidFieldName(string value)
    {
        FluentActions.Invoking(() => new FieldRubric(this._fieldType, value, this._size, this._fieldId)).Should().Throw<ArgumentNullException>().WithParameterName("fieldName");
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
    /// Checks that the GetValue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetValue()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = this._testClass.GetValue(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetValue method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetValueWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.GetValue(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
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
    /// Checks that the SetValue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetValue()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var value = _fixture.Create<object>();
        var invokeAttr = _fixture.Create<BindingFlags>();
        var binder = _fixture.Create<Binder>();
        var culture = _fixture.Create<CultureInfo>();

        // Act
        this._testClass.SetValue(obj, value, invokeAttr, binder, culture
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetValue method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetValueWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.SetValue(default(object), _fixture.Create<object>(), _fixture.Create<BindingFlags>(), _fixture.Create<Binder>(), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the SetValue method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetValueWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.SetValue(_fixture.Create<object>(), default(object), _fixture.Create<BindingFlags>(), _fixture.Create<Binder>(), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the SetValue method throws when the binder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetValueWithNullBinder()
    {
        FluentActions.Invoking(() => this._testClass.SetValue(_fixture.Create<object>(), _fixture.Create<object>(), _fixture.Create<BindingFlags>(), default(Binder), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("binder");
    }

    /// <summary>
    /// Checks that the SetValue method throws when the culture parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetValueWithNullCulture()
    {
        FluentActions.Invoking(() => this._testClass.SetValue(_fixture.Create<object>(), _fixture.Create<object>(), _fixture.Create<BindingFlags>(), _fixture.Create<Binder>(), default(CultureInfo))).Should().Throw<ArgumentNullException>().WithParameterName("culture");
    }

    /// <summary>
    /// Checks that the Attributes property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetAttributes()
    {
        // Assert
        this._testClass.Attributes.As<object>().Should().BeAssignableTo<FieldAttributes>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeclaringType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetDeclaringType()
    {
        // Assert
        this._testClass.DeclaringType.Should().BeAssignableTo<Type>();

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
    /// Checks that the FieldHandle property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetFieldHandle()
    {
        // Assert
        this._testClass.FieldHandle.As<object>().Should().BeAssignableTo<RuntimeFieldHandle>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FieldName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFieldName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.FieldName = testValue;

        // Assert
        this._testClass.FieldName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the IsBackingField property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsBackingField()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.IsBackingField = testValue;

        // Assert
        this._testClass.IsBackingField.Should().Be(testValue);
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
        var testValue = _fixture.Create<FieldInfo>();

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
        var testValue = _fixture.Create<PropertyInfo[]>();

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