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
/// Unit tests for the type <see cref="PropertyRubric"/>.
/// </summary>
public class PropertyRubricTests
{
    private PropertyRubric _testClass;
    private IFixture _fixture;
    private PropertyInfo _property;
    private int _size;
    private int _propertyId;
    private Type _propertyType;
    private string _propertyName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="PropertyRubric"/>.
    /// </summary>
    public PropertyRubricTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._property = _fixture.Create<PropertyInfo>();
        this._size = _fixture.Create<int>();
        this._propertyId = _fixture.Create<int>();
        this._propertyType = _fixture.Create<Type>();
        this._propertyName = _fixture.Create<string>();
        this._testClass = _fixture.Create<PropertyRubric>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new PropertyRubric();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new PropertyRubric(this._property, this._size, this._propertyId);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new PropertyRubric(this._propertyType, this._propertyName, this._size, this._propertyId);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the property parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullProperty()
    {
        FluentActions.Invoking(() => new PropertyRubric(default(PropertyInfo), this._size, this._propertyId)).Should().Throw<ArgumentNullException>().WithParameterName("property");
    }

    /// <summary>
    /// Checks that instance construction throws when the propertyType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPropertyType()
    {
        FluentActions.Invoking(() => new PropertyRubric(default(Type), this._propertyName, this._size, this._propertyId)).Should().Throw<ArgumentNullException>().WithParameterName("propertyType");
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
        FluentActions.Invoking(() => new PropertyRubric(this._propertyType, value, this._size, this._propertyId)).Should().Throw<ArgumentNullException>().WithParameterName("propertyName");
    }

    /// <summary>
    /// Checks that the GetAccessors method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetAccessors()
    {
        // Arrange
        var nonPublic = _fixture.Create<bool>();

        // Act
        var result = this._testClass.GetAccessors(nonPublic);

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
    /// Checks that the GetGetMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetGetMethod()
    {
        // Arrange
        var nonPublic = _fixture.Create<bool>();

        // Act
        var result = this._testClass.GetGetMethod(nonPublic);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIndexParameters method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIndexParameters()
    {
        // Act
        var result = this._testClass.GetIndexParameters();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSetMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSetMethod()
    {
        // Arrange
        var nonPublic = _fixture.Create<bool>();

        // Act
        var result = this._testClass.GetSetMethod(nonPublic);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetValue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetValue()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var invokeAttr = _fixture.Create<BindingFlags>();
        var binder = _fixture.Create<Binder>();
        var index = _fixture.Create<object[]>();
        var culture = _fixture.Create<CultureInfo>();

        // Act
        var result = this._testClass.GetValue(obj, invokeAttr, binder, index, culture
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetValue method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetValueWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.GetValue(default(object), _fixture.Create<BindingFlags>(), _fixture.Create<Binder>(), _fixture.Create<object[]>(), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetValue method throws when the binder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetValueWithNullBinder()
    {
        FluentActions.Invoking(() => this._testClass.GetValue(_fixture.Create<object>(), _fixture.Create<BindingFlags>(), default(Binder), _fixture.Create<object[]>(), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("binder");
    }

    /// <summary>
    /// Checks that the GetValue method throws when the index parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetValueWithNullIndex()
    {
        FluentActions.Invoking(() => this._testClass.GetValue(_fixture.Create<object>(), _fixture.Create<BindingFlags>(), _fixture.Create<Binder>(), default(object[]), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("index");
    }

    /// <summary>
    /// Checks that the GetValue method throws when the culture parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetValueWithNullCulture()
    {
        FluentActions.Invoking(() => this._testClass.GetValue(_fixture.Create<object>(), _fixture.Create<BindingFlags>(), _fixture.Create<Binder>(), _fixture.Create<object[]>(), default(CultureInfo))).Should().Throw<ArgumentNullException>().WithParameterName("culture");
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
        var index = _fixture.Create<object[]>();
        var culture = _fixture.Create<CultureInfo>();

        // Act
        this._testClass.SetValue(obj, value, invokeAttr, binder, index, culture
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
        FluentActions.Invoking(() => this._testClass.SetValue(default(object), _fixture.Create<object>(), _fixture.Create<BindingFlags>(), _fixture.Create<Binder>(), _fixture.Create<object[]>(), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the SetValue method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetValueWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.SetValue(_fixture.Create<object>(), default(object), _fixture.Create<BindingFlags>(), _fixture.Create<Binder>(), _fixture.Create<object[]>(), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the SetValue method throws when the binder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetValueWithNullBinder()
    {
        FluentActions.Invoking(() => this._testClass.SetValue(_fixture.Create<object>(), _fixture.Create<object>(), _fixture.Create<BindingFlags>(), default(Binder), _fixture.Create<object[]>(), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("binder");
    }

    /// <summary>
    /// Checks that the SetValue method throws when the index parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetValueWithNullIndex()
    {
        FluentActions.Invoking(() => this._testClass.SetValue(_fixture.Create<object>(), _fixture.Create<object>(), _fixture.Create<BindingFlags>(), _fixture.Create<Binder>(), default(object[]), _fixture.Create<CultureInfo>())).Should().Throw<ArgumentNullException>().WithParameterName("index");
    }

    /// <summary>
    /// Checks that the SetValue method throws when the culture parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetValueWithNullCulture()
    {
        FluentActions.Invoking(() => this._testClass.SetValue(_fixture.Create<object>(), _fixture.Create<object>(), _fixture.Create<BindingFlags>(), _fixture.Create<Binder>(), _fixture.Create<object[]>(), default(CultureInfo))).Should().Throw<ArgumentNullException>().WithParameterName("culture");
    }

    /// <summary>
    /// Checks that the Attributes property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetAttributes()
    {
        // Assert
        this._testClass.Attributes.As<object>().Should().BeAssignableTo<PropertyAttributes>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CanRead property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetCanRead()
    {
        // Assert
        this._testClass.CanRead.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CanWrite property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetCanWrite()
    {
        // Assert
        this._testClass.CanWrite.As<object>().Should().BeAssignableTo<bool>();

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
        var testValue = _fixture.Create<PropertyInfo>();

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