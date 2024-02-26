using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="Assemblies"/>.
/// </summary>
public partial class AssembliesTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ForceFindType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForceFindType()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var nameSpace = _fixture.Create<string>();

        // Act
        var result = Assemblies.ForceFindType(name, nameSpace);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForceFindType method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallForceFindTypeWithInvalidName(string value)
    {
        FluentActions.Invoking(() => Assemblies.ForceFindType(value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ForceFindType method throws when the nameSpace parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallForceFindTypeWithInvalidNameSpace(string value)
    {
        FluentActions.Invoking(() => Assemblies.ForceFindType(_fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("nameSpace");
    }

    /// <summary>
    /// Checks that the ForceFindType maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void ForceFindTypePerformsMapping()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var nameSpace = _fixture.Create<string>();

        // Act
        var result = Assemblies.ForceFindType(name, nameSpace);

        // Assert
        result.Namespace.Should().BeSameAs(nameSpace);
    }

    /// <summary>
    /// Checks that the FindTypeByFullName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindTypeByFullName()
    {
        // Arrange
        var fullname = _fixture.Create<string>();

        // Act
        var result = Assemblies.FindTypeByFullName(fullname);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FindTypeByFullName method throws when the fullname parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFindTypeByFullNameWithInvalidFullname(string value)
    {
        FluentActions.Invoking(() => Assemblies.FindTypeByFullName(value)).Should().Throw<ArgumentNullException>().WithParameterName("fullname");
    }

    /// <summary>
    /// Checks that the FindTypeByFullName maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void FindTypeByFullNamePerformsMapping()
    {
        // Arrange
        var fullname = _fixture.Create<string>();

        // Act
        var result = Assemblies.FindTypeByFullName(fullname);

        // Assert
        result.FullName.Should().BeSameAs(fullname);
    }

    /// <summary>
    /// Checks that the FindType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindType()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var nameSpace = _fixture.Create<string>();

        // Act
        var result = Assemblies.FindType(name, nameSpace);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FindType method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFindTypeWithInvalidName(string value)
    {
        FluentActions.Invoking(() => Assemblies.FindType(value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the FindType method throws when the nameSpace parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFindTypeWithInvalidNameSpace(string value)
    {
        FluentActions.Invoking(() => Assemblies.FindType(_fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("nameSpace");
    }

    /// <summary>
    /// Checks that the FindType maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void FindTypePerformsMapping()
    {
        // Arrange
        var name = _fixture.Create<string>();
        var nameSpace = _fixture.Create<string>();

        // Act
        var result = Assemblies.FindType(name, nameSpace);

        // Assert
        result.Namespace.Should().BeSameAs(nameSpace);
    }

    /// <summary>
    /// Checks that the FindTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindTypesWithAssignableTypesAndNameSpace()
    {
        // Arrange
        var assignableTypes = _fixture.Create<IList<Type>>();
        var nameSpace = _fixture.Create<string>();

        // Act
        var result = Assemblies.FindTypes(assignableTypes, nameSpace);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FindTypes method throws when the assignableTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindTypesWithAssignableTypesAndNameSpaceWithNullAssignableTypes()
    {
        FluentActions.Invoking(() => Assemblies.FindTypes(default(IList<Type>), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("assignableTypes");
    }

    /// <summary>
    /// Checks that the FindTypes method throws when the nameSpace parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFindTypesWithAssignableTypesAndNameSpaceWithInvalidNameSpace(string value)
    {
        FluentActions.Invoking(() => Assemblies.FindTypes(_fixture.Create<IList<Type>>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("nameSpace");
    }

    /// <summary>
    /// Checks that the FindTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindTypesWithGenericTypeAndGenericArgumentTypes()
    {
        // Arrange
        var genericType = _fixture.Create<Type>();
        var genericArgumentTypes = _fixture.Create<Type[]>();

        // Act
        var result = Assemblies.FindTypes(genericType, genericArgumentTypes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FindTypes method throws when the genericType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindTypesWithGenericTypeAndGenericArgumentTypesWithNullGenericType()
    {
        FluentActions.Invoking(() => Assemblies.FindTypes(default(Type), _fixture.Create<Type[]>())).Should().Throw<ArgumentNullException>().WithParameterName("genericType");
    }

    /// <summary>
    /// Checks that the FindTypes method throws when the genericArgumentTypes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindTypesWithGenericTypeAndGenericArgumentTypesWithNullGenericArgumentTypes()
    {
        FluentActions.Invoking(() => Assemblies.FindTypes(_fixture.Create<Type>(), default(Type[]))).Should().Throw<ArgumentNullException>().WithParameterName("genericArgumentTypes");
    }

    /// <summary>
    /// Checks that the FindTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFindTypesWithAttributeArgumentTypeAndAttributeArgumentValueAndAttributeTypeAndNameSpace()
    {
        // Arrange
        var attributeArgumentType = _fixture.Create<Type>();
        var attributeArgumentValue = _fixture.Create<object>();
        var attributeType = _fixture.Create<Type>();
        var nameSpace = _fixture.Create<string>();

        // Act
        var result = Assemblies.FindTypes(attributeArgumentType, attributeArgumentValue, attributeType, nameSpace);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FindTypes method throws when the attributeArgumentType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindTypesWithAttributeArgumentTypeAndAttributeArgumentValueAndAttributeTypeAndNameSpaceWithNullAttributeArgumentType()
    {
        FluentActions.Invoking(() => Assemblies.FindTypes(default(Type), _fixture.Create<object>(), _fixture.Create<Type>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("attributeArgumentType");
    }

    /// <summary>
    /// Checks that the FindTypes method throws when the attributeArgumentValue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFindTypesWithAttributeArgumentTypeAndAttributeArgumentValueAndAttributeTypeAndNameSpaceWithNullAttributeArgumentValue()
    {
        FluentActions.Invoking(() => Assemblies.FindTypes(_fixture.Create<Type>(), default(object), _fixture.Create<Type>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("attributeArgumentValue");
    }

    /// <summary>
    /// Checks that the FindTypes method throws when the nameSpace parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFindTypesWithAttributeArgumentTypeAndAttributeArgumentValueAndAttributeTypeAndNameSpaceWithInvalidNameSpace(string value)
    {
        FluentActions.Invoking(() => Assemblies.FindTypes(_fixture.Create<Type>(), _fixture.Create<object>(), _fixture.Create<Type>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("nameSpace");
    }

    /// <summary>
    /// Checks that the AssemblyCode property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetAssemblyCode()
    {
        // Assert
        Assemblies.AssemblyCode.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }
}