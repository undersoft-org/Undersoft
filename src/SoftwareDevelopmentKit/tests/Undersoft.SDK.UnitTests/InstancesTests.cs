using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T = System.String;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="Instances"/>.
/// </summary>
public class InstancesTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithFullyQualifiedName()
    {
        // Arrange
        var fullyQualifiedName = _fixture.Create<string>();

        // Act
        var result = Instances.New(fullyQualifiedName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the fullyQualifiedName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNewWithFullyQualifiedNameWithInvalidFullyQualifiedName(string value)
    {
        FluentActions.Invoking(() => Instances.New(value)).Should().Throw<ArgumentNullException>().WithParameterName("fullyQualifiedName");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithFullyQualifiedNameAndConstructorParams()
    {
        // Arrange
        var fullyQualifiedName = _fixture.Create<string>();
        var constructorParams = _fixture.Create<object[]>();

        // Act
        var result = Instances.New(fullyQualifiedName, constructorParams);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the constructorParams parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithFullyQualifiedNameAndConstructorParamsWithNullConstructorParams()
    {
        FluentActions.Invoking(() => Instances.New(_fixture.Create<string>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("constructorParams");
    }

    /// <summary>
    /// Checks that the New method throws when the fullyQualifiedName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNewWithFullyQualifiedNameAndConstructorParamsWithInvalidFullyQualifiedName(string value)
    {
        FluentActions.Invoking(() => Instances.New(value, _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("fullyQualifiedName");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = Instances.New(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithTypeWithNullType()
    {
        FluentActions.Invoking(() => Instances.New(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithTypeAndCtorArguments()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var ctorArguments = _fixture.Create<object[]>();

        // Act
        var result = Instances.New(type, ctorArguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithTypeAndCtorArgumentsWithNullType()
    {
        FluentActions.Invoking(() => Instances.New(default(Type), _fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the New method throws when the ctorArguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithTypeAndCtorArgumentsWithNullCtorArguments()
    {
        FluentActions.Invoking(() => Instances.New(_fixture.Create<Type>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("ctorArguments");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithNoParameters()
    {
        // Act
        var result = Instances.New<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithCtorArguments()
    {
        // Arrange
        var ctorArguments = _fixture.Create<object[]>();

        // Act
        var result = Instances.New<T>(ctorArguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the ctorArguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithCtorArgumentsWithNullCtorArguments()
    {
        FluentActions.Invoking(() => Instances.New<T>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("ctorArguments");
    }
}

/// <summary>
/// Unit tests for the type <see cref="InstanceExtensions"/>.
/// </summary>
public class InstanceExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithTypeAndArrayOfObject()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var ctorArguments = _fixture.Create<object[]>();

        // Act
        var result = type.New(ctorArguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithTypeAndArrayOfObjectWithNullType()
    {
        FluentActions.Invoking(() => default(Type).New(_fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the New method throws when the ctorArguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithTypeAndArrayOfObjectWithNullCtorArguments()
    {
        FluentActions.Invoking(() => _fixture.Create<Type>().New(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("ctorArguments");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = type.New();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithTypeWithNullType()
    {
        FluentActions.Invoking(() => default(Type).New()).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithTAndTypeAndArrayOfObject()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var ctorArguments = _fixture.Create<object[]>();

        // Act
        var result = type.New<T>(ctorArguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithTAndTypeAndArrayOfObjectWithNullType()
    {
        FluentActions.Invoking(() => default(Type).New<T>(_fixture.Create<object[]>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the New method throws when the ctorArguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithTAndTypeAndArrayOfObjectWithNullCtorArguments()
    {
        FluentActions.Invoking(() => _fixture.Create<Type>().New<T>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("ctorArguments");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithTAndType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = type.New<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithTAndTypeWithNullType()
    {
        FluentActions.Invoking(() => default(Type).New<T>()).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithObjectTypeAndCtorArguments()
    {
        // Arrange
        var objectType = _fixture.Create<T>();
        var ctorArguments = _fixture.Create<object[]>();

        // Act
        var result = objectType.New<T>(ctorArguments);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the ctorArguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewWithObjectTypeAndCtorArgumentsWithNullCtorArguments()
    {
        FluentActions.Invoking(() => _fixture.Create<T>().New<T>(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("ctorArguments");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewWithObjectType()
    {
        // Arrange
        var objectType = _fixture.Create<T>();

        // Act
        var result = objectType.New<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }
}