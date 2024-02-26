using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SDK.Service.UnitTests.Data.Object;

/// <summary>
/// Unit tests for the type <see cref="DataObjectExtensions"/>.
/// </summary>
public class DataObjectExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetDataType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataTypeWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = type.GetDataType();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataType method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataTypeWithTypeWithNullType()
    {
        FluentActions.Invoking(() => default(Type).GetDataType()).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetDataType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataTypeWithObject()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = obj.GetDataType();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataType method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataTypeWithObjectWithNullObj()
    {
        FluentActions.Invoking(() => default(object).GetDataType()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetDataName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataNameWithObject()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = obj.GetDataName();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataName method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataNameWithObjectWithNullObj()
    {
        FluentActions.Invoking(() => default(object).GetDataName()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetDataFullName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataFullNameWithObject()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = obj.GetDataFullName();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataFullName method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataFullNameWithObjectWithNullObj()
    {
        FluentActions.Invoking(() => default(object).GetDataFullName()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetDataName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataNameWithType()
    {
        // Arrange
        var obj = _fixture.Create<Type>();

        // Act
        var result = obj.GetDataName();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataName method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataNameWithTypeWithNullObj()
    {
        FluentActions.Invoking(() => default(Type).GetDataName()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetDataFullName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataFullNameWithType()
    {
        // Arrange
        var obj = _fixture.Create<Type>();

        // Act
        var result = obj.GetDataFullName();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataFullName method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataFullNameWithTypeWithNullObj()
    {
        FluentActions.Invoking(() => default(Type).GetDataFullName()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetDataTypeId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataTypeIdWithObject()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = obj.GetDataTypeId();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataTypeId method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataTypeIdWithObjectWithNullObj()
    {
        FluentActions.Invoking(() => default(object).GetDataTypeId()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetDataTypeId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataTypeIdWithType()
    {
        // Arrange
        var obj = _fixture.Create<Type>();

        // Act
        var result = obj.GetDataTypeId();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataTypeId method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDataTypeIdWithTypeWithNullObj()
    {
        FluentActions.Invoking(() => default(Type).GetDataTypeId()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the IsEventType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsEventType()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = obj.IsEventType();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsEventType method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsEventTypeWithNullObj()
    {
        FluentActions.Invoking(() => default(object).IsEventType()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the IsDataProxy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsDataProxy()
    {
        // Arrange
        var t = _fixture.Create<Type>();

        // Act
        var result = t.IsDataProxy();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsDataProxy method throws when the t parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsDataProxyWithNullT()
    {
        FluentActions.Invoking(() => default(Type).IsDataProxy()).Should().Throw<ArgumentNullException>().WithParameterName("t");
    }
}