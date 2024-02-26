using System;
using System.Reflection.Emit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math;
using Undersoft.SDK.Instant.Math.Formulas;
using Undersoft.SDK.Instant.Math.Operation;
using Undersoft.SDK.Instant.Math.Operation.Binary.Operator;
using Undersoft.SDK.Instant.Math.Set;

namespace Undersoft.SDK.UnitTests.Instant.Math.Operation;

/// <summary>
/// Unit tests for the type <see cref="CompareOperation"/>.
/// </summary>
public class CompareOperationTests
{
    private CompareOperation _testClass;
    private IFixture _fixture;
    private Formula _e1;
    private Formula _e2;
    private BinaryOperator _op;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="CompareOperation"/>.
    /// </summary>
    public CompareOperationTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._e1 = _fixture.Create<Formula>();
        this._e2 = _fixture.Create<Formula>();
        this._op = _fixture.Create<BinaryOperator>();
        this._testClass = _fixture.Create<CompareOperation>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new CompareOperation(this._e1, this._e2, this._op);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the e1 parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullE1()
    {
        FluentActions.Invoking(() => new CompareOperation(default(Formula), this._e2, this._op)).Should().Throw<ArgumentNullException>().WithParameterName("e1");
    }

    /// <summary>
    /// Checks that instance construction throws when the e2 parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullE2()
    {
        FluentActions.Invoking(() => new CompareOperation(this._e1, default(Formula), this._op)).Should().Throw<ArgumentNullException>().WithParameterName("e2");
    }

    /// <summary>
    /// Checks that instance construction throws when the op parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOp()
    {
        FluentActions.Invoking(() => new CompareOperation(this._e1, this._e2, default(BinaryOperator))).Should().Throw<ArgumentNullException>().WithParameterName("op");
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