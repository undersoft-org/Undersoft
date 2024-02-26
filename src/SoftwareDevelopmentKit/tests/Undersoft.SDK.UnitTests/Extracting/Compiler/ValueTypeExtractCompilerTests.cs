using System;
using System.Reflection.Emit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Extracting.Compiler;

namespace Undersoft.SDK.UnitTests.Extracting.Compiler;

/// <summary>
/// Unit tests for the type <see cref="ExtractCompiler"/>.
/// </summary>
public partial class ExtractCompilerTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the CompileByteArrayToValueObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileByteArrayToValueObject()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        ExtractCompiler.CompileByteArrayToValueObject(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileByteArrayToValueObject method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileByteArrayToValueObjectWithNullTb()
    {
        FluentActions.Invoking(() => ExtractCompiler.CompileByteArrayToValueObject(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CompileByteArrayToValueType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileByteArrayToValueType()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        ExtractCompiler.CompileByteArrayToValueType(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileByteArrayToValueType method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileByteArrayToValueTypeWithNullTb()
    {
        FluentActions.Invoking(() => ExtractCompiler.CompileByteArrayToValueType(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CompilePointerToValueObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompilePointerToValueObject()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        ExtractCompiler.CompilePointerToValueObject(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompilePointerToValueObject method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompilePointerToValueObjectWithNullTb()
    {
        FluentActions.Invoking(() => ExtractCompiler.CompilePointerToValueObject(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CompilePointerToValueType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompilePointerToValueType()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        ExtractCompiler.CompilePointerToValueType(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompilePointerToValueType method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompilePointerToValueTypeWithNullTb()
    {
        FluentActions.Invoking(() => ExtractCompiler.CompilePointerToValueType(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CompileValueObjectToByteArrayRef method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileValueObjectToByteArrayRef()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        ExtractCompiler.CompileValueObjectToByteArrayRef(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileValueObjectToByteArrayRef method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileValueObjectToByteArrayRefWithNullTb()
    {
        FluentActions.Invoking(() => ExtractCompiler.CompileValueObjectToByteArrayRef(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CompileValueObjectToNewByteArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileValueObjectToNewByteArray()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        ExtractCompiler.CompileValueObjectToNewByteArray(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileValueObjectToNewByteArray method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileValueObjectToNewByteArrayWithNullTb()
    {
        FluentActions.Invoking(() => ExtractCompiler.CompileValueObjectToNewByteArray(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CompileValueObjectToNewPointer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileValueObjectToNewPointer()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        ExtractCompiler.CompileValueObjectToNewPointer(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileValueObjectToNewPointer method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileValueObjectToNewPointerWithNullTb()
    {
        FluentActions.Invoking(() => ExtractCompiler.CompileValueObjectToNewPointer(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CompileValueObjectToPointer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileValueObjectToPointer()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        ExtractCompiler.CompileValueObjectToPointer(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileValueObjectToPointer method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileValueObjectToPointerWithNullTb()
    {
        FluentActions.Invoking(() => ExtractCompiler.CompileValueObjectToPointer(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CompileValueTypeToNewByteArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileValueTypeToNewByteArray()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        ExtractCompiler.CompileValueTypeToNewByteArray(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileValueTypeToNewByteArray method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileValueTypeToNewByteArrayWithNullTb()
    {
        FluentActions.Invoking(() => ExtractCompiler.CompileValueTypeToNewByteArray(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }
}