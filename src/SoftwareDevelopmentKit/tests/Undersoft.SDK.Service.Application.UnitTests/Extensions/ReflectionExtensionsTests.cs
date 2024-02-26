using System;
using System.Collections.Generic;
using System.Reflection;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Application.Extensions;

namespace Undersoft.SDK.Service.Application.UnitTests.Extensions;

/// <summary>
/// Unit tests for the type <see cref="ReflectionExtensions"/>.
/// </summary>
[TestClass]
public class ReflectionExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the CreateKnownTypeNamesDictionary method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateKnownTypeNamesDictionary()
    {
        // Act
        var result = ReflectionExtensions.CreateKnownTypeNamesDictionary();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsNullable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsNullable()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = type.IsNullable();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsNullable method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsNullableWithNullType()
    {
        FluentActions.Invoking(() => default(Type).IsNullable()).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the ToNameString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToNameStringWithTypeAndTypeNameConverter()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        Func<Type, string> typeNameConverter = x => _fixture.Create<string>();

        // Act
        var result = type.ToNameString(typeNameConverter);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToNameString method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToNameStringWithTypeAndTypeNameConverterWithNullType()
    {
        FluentActions.Invoking(() => default(Type).ToNameString(x => _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the ToNameString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToNameStringWithTypeAndTypeNameConverterAndInvokeTypeNameConverterForGenericType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        Func<Type, Queue<string>, string> typeNameConverter = (x, y) => _fixture.Create<string>();
        var invokeTypeNameConverterForGenericType = _fixture.Create<bool>();

        // Act
        var result = type.ToNameString(typeNameConverter, invokeTypeNameConverterForGenericType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToNameString method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToNameStringWithTypeAndTypeNameConverterAndInvokeTypeNameConverterForGenericTypeWithNullType()
    {
        FluentActions.Invoking(() => default(Type).ToNameString((x, y) => _fixture.Create<string>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the ToNameString method throws when the typeNameConverter parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToNameStringWithTypeAndTypeNameConverterAndInvokeTypeNameConverterForGenericTypeWithNullTypeNameConverter()
    {
        FluentActions.Invoking(() => _fixture.Create<Type>().ToNameString(default(Func<Type, Queue<string>, string>), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("typeNameConverter");
    }

    /// <summary>
    /// Checks that the ToParametersString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToParametersString()
    {
        // Arrange
        var methodInfo = _fixture.Create<MethodBase>();
        Func<Type, Queue<string>, string> typeNameConverter = (x, y) => _fixture.Create<string>();
        var invokeTypeNameConverterForGenericType = _fixture.Create<bool>();

        // Act
        var result = methodInfo.ToParametersString(typeNameConverter, invokeTypeNameConverterForGenericType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToParametersString method throws when the methodInfo parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToParametersStringWithNullMethodInfo()
    {
        FluentActions.Invoking(() => default(MethodBase).ToParametersString((x, y) => _fixture.Create<string>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("methodInfo");
    }

    /// <summary>
    /// Checks that the ToTypeNameString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToTypeNameStringWithParameterInfoAndTypeNameConverterAndInvokeTypeNameConverterForGenericType()
    {
        // Arrange
        var parameterInfo = _fixture.Create<ParameterInfo>();
        Func<Type, Queue<string>, string> typeNameConverter = (x, y) => _fixture.Create<string>();
        var invokeTypeNameConverterForGenericType = _fixture.Create<bool>();

        // Act
        var result = parameterInfo.ToTypeNameString(typeNameConverter, invokeTypeNameConverterForGenericType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToTypeNameString method throws when the parameterInfo parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToTypeNameStringWithParameterInfoAndTypeNameConverterAndInvokeTypeNameConverterForGenericTypeWithNullParameterInfo()
    {
        FluentActions.Invoking(() => default(ParameterInfo).ToTypeNameString((x, y) => _fixture.Create<string>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("parameterInfo");
    }

    /// <summary>
    /// Checks that the ToTypeNameString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToTypeNameStringWithMethodInfoAndFuncOfTypeAndQueueOfStringAndStringAndBool()
    {
        // Arrange
        var methodInfo = _fixture.Create<MethodInfo>();
        Func<Type, Queue<string>, string> typeNameConverter = (x, y) => _fixture.Create<string>();
        var invokeTypeNameConverterForGenericType = _fixture.Create<bool>();

        // Act
        var result = methodInfo.ToTypeNameString(typeNameConverter, invokeTypeNameConverterForGenericType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToTypeNameString method throws when the methodInfo parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToTypeNameStringWithMethodInfoAndFuncOfTypeAndQueueOfStringAndStringAndBoolWithNullMethodInfo()
    {
        FluentActions.Invoking(() => default(MethodInfo).ToTypeNameString((x, y) => _fixture.Create<string>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("methodInfo");
    }

    /// <summary>
    /// Checks that the ToTypeNameString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToTypeNameStringWithPropertyInfoAndTypeNameConverterAndInvokeTypeNameConverterForGenericType()
    {
        // Arrange
        var propertyInfo = _fixture.Create<PropertyInfo>();
        Func<Type, Queue<string>, string> typeNameConverter = (x, y) => _fixture.Create<string>();
        var invokeTypeNameConverterForGenericType = _fixture.Create<bool>();

        // Act
        var result = propertyInfo.ToTypeNameString(typeNameConverter, invokeTypeNameConverterForGenericType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToTypeNameString method throws when the propertyInfo parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToTypeNameStringWithPropertyInfoAndTypeNameConverterAndInvokeTypeNameConverterForGenericTypeWithNullPropertyInfo()
    {
        FluentActions.Invoking(() => default(PropertyInfo).ToTypeNameString((x, y) => _fixture.Create<string>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("propertyInfo");
    }

    /// <summary>
    /// Checks that the ToTypeNameString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToTypeNameStringWithFieldInfoAndTypeNameConverterAndInvokeTypeNameConverterForGenericType()
    {
        // Arrange
        var fieldInfo = _fixture.Create<FieldInfo>();
        Func<Type, Queue<string>, string> typeNameConverter = (x, y) => _fixture.Create<string>();
        var invokeTypeNameConverterForGenericType = _fixture.Create<bool>();

        // Act
        var result = fieldInfo.ToTypeNameString(typeNameConverter, invokeTypeNameConverterForGenericType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToTypeNameString method throws when the fieldInfo parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToTypeNameStringWithFieldInfoAndTypeNameConverterAndInvokeTypeNameConverterForGenericTypeWithNullFieldInfo()
    {
        FluentActions.Invoking(() => default(FieldInfo).ToTypeNameString((x, y) => _fixture.Create<string>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("fieldInfo");
    }

    /// <summary>
    /// Checks that the ToNameStringWithValueTupleNames method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToNameStringWithValueTupleNames()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var tupleNames = _fixture.Create<IList<string>>();
        Func<Type, Queue<string>, string> typeNameConverter = (x, y) => _fixture.Create<string>();
        var invokeTypeNameConverterForGenericType = _fixture.Create<bool>();

        // Act
        var result = type.ToNameStringWithValueTupleNames(tupleNames, typeNameConverter, invokeTypeNameConverterForGenericType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToNameStringWithValueTupleNames method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToNameStringWithValueTupleNamesWithNullType()
    {
        FluentActions.Invoking(() => default(Type).ToNameStringWithValueTupleNames(_fixture.Create<IList<string>>(), (x, y) => _fixture.Create<string>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the ToNameStringWithValueTupleNames method throws when the tupleNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToNameStringWithValueTupleNamesWithNullTupleNames()
    {
        FluentActions.Invoking(() => _fixture.Create<Type>().ToNameStringWithValueTupleNames(default(IList<string>), (x, y) => _fixture.Create<string>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("tupleNames");
    }

    /// <summary>
    /// Checks that the ToNameString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToNameStringWithTypeAndTupleFieldNamesAndTypeNameConverterAndInvokeTypeNameConverterForGenericType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var tupleFieldNames = _fixture.Create<Queue<string>>();
        Func<Type, Queue<string>, string> typeNameConverter = (x, y) => _fixture.Create<string>();
        var invokeTypeNameConverterForGenericType = _fixture.Create<bool>();

        // Act
        var result = type.ToNameString(tupleFieldNames, typeNameConverter, invokeTypeNameConverterForGenericType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToNameString method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToNameStringWithTypeAndTupleFieldNamesAndTypeNameConverterAndInvokeTypeNameConverterForGenericTypeWithNullType()
    {
        FluentActions.Invoking(() => default(Type).ToNameString(_fixture.Create<Queue<string>>(), (x, y) => _fixture.Create<string>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the ToNameString method throws when the tupleFieldNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToNameStringWithTypeAndTupleFieldNamesAndTypeNameConverterAndInvokeTypeNameConverterForGenericTypeWithNullTupleFieldNames()
    {
        FluentActions.Invoking(() => _fixture.Create<Type>().ToNameString(default(Queue<string>), (x, y) => _fixture.Create<string>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("tupleFieldNames");
    }

    /// <summary>
    /// Checks that the CleanGenericTypeName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCleanGenericTypeName()
    {
        // Arrange
        var genericTypeName = _fixture.Create<string>();

        // Act
        var result = genericTypeName.CleanGenericTypeName();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CleanGenericTypeName method throws when the genericTypeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCleanGenericTypeNameWithInvalidGenericTypeName(string value)
    {
        FluentActions.Invoking(() => value.CleanGenericTypeName()).Should().Throw<ArgumentNullException>().WithParameterName("genericTypeName");
    }

    /// <summary>
    /// Checks that the KnownTypeNames property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetKnownTypeNames()
    {
        // Assert
        ReflectionExtensions.KnownTypeNames.Should().BeAssignableTo<Dictionary<Type, string>>();

        Assert.Fail("Create or modify test");
    }
}