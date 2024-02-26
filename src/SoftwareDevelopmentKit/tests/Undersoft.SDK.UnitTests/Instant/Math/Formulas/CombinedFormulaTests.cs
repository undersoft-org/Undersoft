using System;
using System.Reflection.Emit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math;
using Undersoft.SDK.Instant.Math.Formulas;
using Undersoft.SDK.Instant.Math.Set;

namespace Undersoft.SDK.UnitTests.Instant.Math.Formulas;

/// <summary>
/// Unit tests for the type <see cref="CombinedFormula"/>.
/// </summary>
public class CombinedFormulaTests
{
    private CombinedFormula _testClass;
    private IFixture _fixture;
    private LeftFormula _m;
    private Formula _e;
    private bool _partial;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="CombinedFormula"/>.
    /// </summary>
    public CombinedFormulaTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._m = _fixture.Create<LeftFormula>();
        this._e = _fixture.Create<Formula>();
        this._partial = _fixture.Create<bool>();
        this._testClass = _fixture.Create<CombinedFormula>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new CombinedFormula(this._m, this._e, this._partial);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the m parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullM()
    {
        FluentActions.Invoking(() => new CombinedFormula(default(LeftFormula), this._e, this._partial)).Should().Throw<ArgumentNullException>().WithParameterName("m");
    }

    /// <summary>
    /// Checks that instance construction throws when the e parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullE()
    {
        FluentActions.Invoking(() => new CombinedFormula(this._m, default(Formula), this._partial)).Should().Throw<ArgumentNullException>().WithParameterName("e");
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
    /// Checks that the size property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetsize()
    {
        // Assert
        this._testClass.size.Should().BeAssignableTo<MathSetSize>();

        Assert.Fail("Create or modify test");
    }
}