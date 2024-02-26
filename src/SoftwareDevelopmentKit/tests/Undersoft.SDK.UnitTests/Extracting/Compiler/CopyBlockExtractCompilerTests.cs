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
    /// Checks that the CompileCopyByteArrayBlockUInt32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileCopyByteArrayBlockUInt32()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        ExtractCompiler.CompileCopyByteArrayBlockUInt32(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileCopyByteArrayBlockUInt32 method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileCopyByteArrayBlockUInt32WithNullTb()
    {
        FluentActions.Invoking(() => ExtractCompiler.CompileCopyByteArrayBlockUInt32(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CompileCopyByteArrayBlockUInt64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileCopyByteArrayBlockUInt64()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        ExtractCompiler.CompileCopyByteArrayBlockUInt64(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileCopyByteArrayBlockUInt64 method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileCopyByteArrayBlockUInt64WithNullTb()
    {
        FluentActions.Invoking(() => ExtractCompiler.CompileCopyByteArrayBlockUInt64(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CompileCopyPointerBlockUInt32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileCopyPointerBlockUInt32()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        ExtractCompiler.CompileCopyPointerBlockUInt32(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileCopyPointerBlockUInt32 method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileCopyPointerBlockUInt32WithNullTb()
    {
        FluentActions.Invoking(() => ExtractCompiler.CompileCopyPointerBlockUInt32(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CompileCopyPointerBlockUInt64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileCopyPointerBlockUInt64()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        ExtractCompiler.CompileCopyPointerBlockUInt64(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileCopyPointerBlockUInt64 method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileCopyPointerBlockUInt64WithNullTb()
    {
        FluentActions.Invoking(() => ExtractCompiler.CompileCopyPointerBlockUInt64(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }
}