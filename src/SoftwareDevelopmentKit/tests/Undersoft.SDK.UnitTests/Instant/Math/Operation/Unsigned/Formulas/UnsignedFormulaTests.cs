using System;
using System.Reflection.Emit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math;
using Undersoft.SDK.Instant.Math.Operation.Unsigned.Formulas;
using Undersoft.SDK.Instant.Math.Set;

namespace Undersoft.SDK.UnitTests.Instant.Math.Operation.Unsigned.Formulas;

/// <summary>
/// Unit tests for the type <see cref="UnsignedFormula"/>.
/// </summary>
public class UnsignedFormulaTests
{
    private UnsignedFormula _testClass;
    private IFixture _fixture;
    private double _vv;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="UnsignedFormula"/>.
    /// </summary>
    public UnsignedFormulaTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._vv = _fixture.Create<double>();
        this._testClass = _fixture.Create<UnsignedFormula>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new UnsignedFormula(this._vv);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Compile method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompile()
    {
        // Arrange
        var g = _fixture.Create<ILGenerator>();
        var cc = _fixture.Create<InstantMathCompilerContext>();

        // Act
        this._testClass.Compile(g, cc);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compile method throws when the g parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileWithNullG()
    {
        FluentActions.Invoking(() => this._testClass.Compile(default(ILGenerator), _fixture.Create<InstantMathCompilerContext>())).Should().Throw<ArgumentNullException>().WithParameterName("g");
    }

    /// <summary>
    /// Checks that the Compile method throws when the cc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileWithNullCc()
    {
        FluentActions.Invoking(() => this._testClass.Compile(_fixture.Create<ILGenerator>(), default(InstantMathCompilerContext))).Should().Throw<ArgumentNullException>().WithParameterName("cc");
    }

    /// <summary>
    /// Checks that the Size property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSize()
    {
        // Assert
        this._testClass.Size.Should().BeAssignableTo<MathSetSize>();

        Assert.Fail("Create or modify test");
    }
}