using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math.Formulas;
using Undersoft.SDK.Instant.Math.Set;

namespace Undersoft.SDK.UnitTests.Instant.Math.Formulas;

/// <summary>
/// Unit tests for the type <see cref="Formula"/>.
/// </summary>
public class FormulaTests
{
    private class TestFormula : Formula
    {
        public override void Compile(ILGenerator g, InstantMathCompilerContext cc)
        {
        }
    }

    private TestFormula _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Formula"/>.
    /// </summary>
    public FormulaTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestFormula>();
    }

    /// <summary>
    /// Checks that the Cos method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCos()
    {
        // Arrange
        var e = _fixture.Create<Formula>();

        // Act
        var result = TestFormula.Cos(e);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Cos method throws when the e parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCosWithNullE()
    {
        FluentActions.Invoking(() => TestFormula.Cos(default(Formula))).Should().Throw<ArgumentNullException>().WithParameterName("e");
    }

    /// <summary>
    /// Checks that the Log method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLog()
    {
        // Arrange
        var e = _fixture.Create<Formula>();

        // Act
        var result = TestFormula.Log(e);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Log method throws when the e parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLogWithNullE()
    {
        FluentActions.Invoking(() => TestFormula.Log(default(Formula))).Should().Throw<ArgumentNullException>().WithParameterName("e");
    }

    /// <summary>
    /// Checks that the MemPow method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMemPow()
    {
        // Arrange
        var e1 = _fixture.Create<Formula>();
        var e2 = _fixture.Create<Formula>();

        // Act
        var result = TestFormula.MemPow(e1, e2);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MemPow method throws when the e1 parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMemPowWithNullE1()
    {
        FluentActions.Invoking(() => TestFormula.MemPow(default(Formula), _fixture.Create<Formula>())).Should().Throw<ArgumentNullException>().WithParameterName("e1");
    }

    /// <summary>
    /// Checks that the MemPow method throws when the e2 parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMemPowWithNullE2()
    {
        FluentActions.Invoking(() => TestFormula.MemPow(_fixture.Create<Formula>(), default(Formula))).Should().Throw<ArgumentNullException>().WithParameterName("e2");
    }

    /// <summary>
    /// Checks that the Sin method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSin()
    {
        // Arrange
        var e = _fixture.Create<Formula>();

        // Act
        var result = TestFormula.Sin(e);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Sin method throws when the e parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSinWithNullE()
    {
        FluentActions.Invoking(() => TestFormula.Sin(default(Formula))).Should().Throw<ArgumentNullException>().WithParameterName("e");
    }

    /// <summary>
    /// Checks that the CompileMathSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileMathSetWithCombinedFormula()
    {
        // Arrange
        var m = _fixture.Create<CombinedFormula>();

        // Act
        var result = this._testClass.CompileMathSet(m);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileMathSet method throws when the m parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileMathSetWithCombinedFormulaWithNullM()
    {
        FluentActions.Invoking(() => this._testClass.CompileMathSet(default(CombinedFormula))).Should().Throw<ArgumentNullException>().WithParameterName("m");
    }

    /// <summary>
    /// Checks that the CompileMathSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileMathSetWithFormulaAndLeftFormula()
    {
        // Arrange
        var f = _fixture.Create<Formula>();
        var m = _fixture.Create<LeftFormula>();

        // Act
        var result = this._testClass.CompileMathSet(f, m);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileMathSet method throws when the f parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileMathSetWithFormulaAndLeftFormulaWithNullF()
    {
        FluentActions.Invoking(() => this._testClass.CompileMathSet(default(Formula), _fixture.Create<LeftFormula>())).Should().Throw<ArgumentNullException>().WithParameterName("f");
    }

    /// <summary>
    /// Checks that the CompileMathSet method throws when the m parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileMathSetWithFormulaAndLeftFormulaWithNullM()
    {
        FluentActions.Invoking(() => this._testClass.CompileMathSet(_fixture.Create<Formula>(), default(LeftFormula))).Should().Throw<ArgumentNullException>().WithParameterName("m");
    }

    /// <summary>
    /// Checks that the Compute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompute()
    {
        // Arrange
        var cm = _fixture.Create<MathSetComputer>();

        // Act
        this._testClass.Compute(cm);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compute method throws when the cm parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeWithNullCm()
    {
        FluentActions.Invoking(() => this._testClass.Compute(default(MathSetComputer))).Should().Throw<ArgumentNullException>().WithParameterName("cm");
    }

    /// <summary>
    /// Checks that the CreateEvaluator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateEvaluatorWithCombinedFormula()
    {
        // Arrange
        var m = _fixture.Create<CombinedFormula>();

        // Act
        var result = this._testClass.CreateEvaluator(m);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateEvaluator method throws when the m parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateEvaluatorWithCombinedFormulaWithNullM()
    {
        FluentActions.Invoking(() => this._testClass.CreateEvaluator(default(CombinedFormula))).Should().Throw<ArgumentNullException>().WithParameterName("m");
    }

    /// <summary>
    /// Checks that the CreateEvaluator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateEvaluatorWithMathSetComputer()
    {
        // Arrange
        var e = _fixture.Create<MathSetComputer>();

        // Act
        var result = this._testClass.CreateEvaluator(e);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateEvaluator method throws when the e parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateEvaluatorWithMathSetComputerWithNullE()
    {
        FluentActions.Invoking(() => this._testClass.CreateEvaluator(default(MathSetComputer))).Should().Throw<ArgumentNullException>().WithParameterName("e");
    }

    /// <summary>
    /// Checks that the CreateEvaluator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateEvaluatorWithFormulaAndLeftFormula()
    {
        // Arrange
        var f = _fixture.Create<Formula>();
        var m = _fixture.Create<LeftFormula>();

        // Act
        var result = this._testClass.CreateEvaluator(f, m);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateEvaluator method throws when the f parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateEvaluatorWithFormulaAndLeftFormulaWithNullF()
    {
        FluentActions.Invoking(() => this._testClass.CreateEvaluator(default(Formula), _fixture.Create<LeftFormula>())).Should().Throw<ArgumentNullException>().WithParameterName("f");
    }

    /// <summary>
    /// Checks that the CreateEvaluator method throws when the m parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateEvaluatorWithFormulaAndLeftFormulaWithNullM()
    {
        FluentActions.Invoking(() => this._testClass.CreateEvaluator(_fixture.Create<Formula>(), default(LeftFormula))).Should().Throw<ArgumentNullException>().WithParameterName("m");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var o = _fixture.Create<object>();

        // Act
        var result = this._testClass.Equals(o);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the o parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullO()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("o");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCode()
    {
        // Act
        var result = this._testClass.GetHashCode();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Pow method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPow()
    {
        // Arrange
        var e2 = _fixture.Create<Formula>();

        // Act
        var result = this._testClass.Pow(e2);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Pow method throws when the e2 parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPowWithNullE2()
    {
        FluentActions.Invoking(() => this._testClass.Pow(default(Formula))).Should().Throw<ArgumentNullException>().WithParameterName("e2");
    }

    /// <summary>
    /// Checks that the Prepare method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPrepareWithFAndMAndPartial()
    {
        // Arrange
        var f = _fixture.Create<Formula>();
        var m = _fixture.Create<LeftFormula>();
        var @partial = _fixture.Create<bool>();

        // Act
        var result = this._testClass.Prepare(f, m, partial);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Prepare method throws when the f parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPrepareWithFAndMAndPartialWithNullF()
    {
        FluentActions.Invoking(() => this._testClass.Prepare(default(Formula), _fixture.Create<LeftFormula>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("f");
    }

    /// <summary>
    /// Checks that the Prepare method throws when the m parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPrepareWithFAndMAndPartialWithNullM()
    {
        FluentActions.Invoking(() => this._testClass.Prepare(_fixture.Create<Formula>(), default(LeftFormula), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("m");
    }

    /// <summary>
    /// Checks that the Prepare method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPrepareWithMAndPartial()
    {
        // Arrange
        var m = _fixture.Create<LeftFormula>();
        var @partial = _fixture.Create<bool>();

        // Act
        var result = this._testClass.Prepare(m, partial);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Prepare method throws when the m parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPrepareWithMAndPartialWithNullM()
    {
        FluentActions.Invoking(() => this._testClass.Prepare(default(LeftFormula), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("m");
    }

    /// <summary>
    /// Checks that the Transpose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTranspose()
    {
        // Act
        var result = this._testClass.Transpose();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Plus operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPlusOperator()
    {
        // Arrange
        var e1 = _fixture.Create<Formula>();
        var e2 = _fixture.Create<Formula>();

        // Act
        var result = e1 + e2;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Plus operator handles null values for the e1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallPlusOperatorWithNullE1()
    {
        FluentActions.Invoking(() => { var result = default(Formula) + _fixture.Create<Formula>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Plus operator handles null values for the e2 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallPlusOperatorWithNullE2()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<Formula>() + default(Formula); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Minus operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMinusOperator()
    {
        // Arrange
        var e1 = _fixture.Create<Formula>();
        var e2 = _fixture.Create<Formula>();

        // Act
        var result = e1 - e2;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Minus operator handles null values for the e1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallMinusOperatorWithNullE1()
    {
        FluentActions.Invoking(() => { var result = default(Formula) - _fixture.Create<Formula>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Minus operator handles null values for the e2 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallMinusOperatorWithNullE2()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<Formula>() - default(Formula); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Multiplication operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMultiplicationOperator()
    {
        // Arrange
        var e1 = _fixture.Create<Formula>();
        var e2 = _fixture.Create<Formula>();

        // Act
        var result = e1 * e2;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Multiplication operator handles null values for the e1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallMultiplicationOperatorWithNullE1()
    {
        FluentActions.Invoking(() => { var result = default(Formula) * _fixture.Create<Formula>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Multiplication operator handles null values for the e2 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallMultiplicationOperatorWithNullE2()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<Formula>() * default(Formula); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Division operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDivisionOperator()
    {
        // Arrange
        var e1 = _fixture.Create<Formula>();
        var e2 = _fixture.Create<Formula>();

        // Act
        var result = e1 / e2;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Division operator handles null values for the e1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallDivisionOperatorWithNullE1()
    {
        FluentActions.Invoking(() => { var result = default(Formula) / _fixture.Create<Formula>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Division operator handles null values for the e2 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallDivisionOperatorWithNullE2()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<Formula>() / default(Formula); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Equality operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualityWithFormulaAndFormulaOperator()
    {
        // Arrange
        var e1 = _fixture.Create<Formula>();
        var e2 = _fixture.Create<Formula>();

        // Act
        var result = e1 == e2;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equality operator handles null values for the e1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualityWithFormulaAndFormulaOperatorWithNullE1()
    {
        FluentActions.Invoking(() => { var result = default(Formula) == _fixture.Create<Formula>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Equality operator handles null values for the e2 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualityWithFormulaAndFormulaOperatorWithNullE2()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<Formula>() == default(Formula); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Inequality operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInequalityWithFormulaAndFormulaOperator()
    {
        // Arrange
        var e1 = _fixture.Create<Formula>();
        var e2 = _fixture.Create<Formula>();

        // Act
        var result = e1 != e2;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Inequality operator handles null values for the e1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallInequalityWithFormulaAndFormulaOperatorWithNullE1()
    {
        FluentActions.Invoking(() => { var result = default(Formula) != _fixture.Create<Formula>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Inequality operator handles null values for the e2 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallInequalityWithFormulaAndFormulaOperatorWithNullE2()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<Formula>() != default(Formula); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the LessThan operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLessThanOperator()
    {
        // Arrange
        var e1 = _fixture.Create<Formula>();
        var e2 = _fixture.Create<Formula>();

        // Act
        var result = e1 < e2;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LessThan operator handles null values for the e1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallLessThanOperatorWithNullE1()
    {
        FluentActions.Invoking(() => { var result = default(Formula) < _fixture.Create<Formula>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the LessThan operator handles null values for the e2 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallLessThanOperatorWithNullE2()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<Formula>() < default(Formula); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Or operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOrOperator()
    {
        // Arrange
        var e1 = _fixture.Create<Formula>();
        var e2 = _fixture.Create<Formula>();

        // Act
        var result = e1 | e2;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Or operator handles null values for the e1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallOrOperatorWithNullE1()
    {
        FluentActions.Invoking(() => { var result = default(Formula) | _fixture.Create<Formula>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Or operator handles null values for the e2 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallOrOperatorWithNullE2()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<Formula>() | default(Formula); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the GreaterThan operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGreaterThanOperator()
    {
        // Arrange
        var e1 = _fixture.Create<Formula>();
        var e2 = _fixture.Create<Formula>();

        // Act
        var result = e1 > e2;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GreaterThan operator handles null values for the e1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallGreaterThanOperatorWithNullE1()
    {
        FluentActions.Invoking(() => { var result = default(Formula) > _fixture.Create<Formula>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the GreaterThan operator handles null values for the e2 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallGreaterThanOperatorWithNullE2()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<Formula>() > default(Formula); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the And operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAndOperator()
    {
        // Arrange
        var e1 = _fixture.Create<Formula>();
        var e2 = _fixture.Create<Formula>();

        // Act
        var result = e1 & e2;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the And operator handles null values for the e1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallAndOperatorWithNullE1()
    {
        FluentActions.Invoking(() => { var result = default(Formula) & _fixture.Create<Formula>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the And operator handles null values for the e2 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallAndOperatorWithNullE2()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<Formula>() & default(Formula); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Inequality operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInequalityWithFormulaAndObjectOperator()
    {
        // Arrange
        var e1 = _fixture.Create<Formula>();
        var o = _fixture.Create<object>();

        // Act
        var result = e1 != o;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Inequality operator handles null values for the e1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallInequalityWithFormulaAndObjectOperatorWithNullE1()
    {
        FluentActions.Invoking(() => { var result = default(Formula) != _fixture.Create<object>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Inequality operator handles null values for the o parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallInequalityWithFormulaAndObjectOperatorWithNullO()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<Formula>() != default(object); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Equality operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualityWithFormulaAndObjectOperator()
    {
        // Arrange
        var e1 = _fixture.Create<Formula>();
        var o = _fixture.Create<object>();

        // Act
        var result = e1 == o;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equality operator handles null values for the e1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualityWithFormulaAndObjectOperatorWithNullE1()
    {
        FluentActions.Invoking(() => { var result = default(Formula) == _fixture.Create<object>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Equality operator handles null values for the o parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualityWithFormulaAndObjectOperatorWithNullO()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<Formula>() == default(object); }).Should().Throw<ArgumentNullException>();
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

/// <summary>
/// Unit tests for the type <see cref="NullCheck"/>.
/// </summary>
public class NullCheckTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the IsNotNull method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsNotNull()
    {
        // Arrange
        var o = _fixture.Create<object>();

        // Act
        var result = NullCheck.IsNotNull(o);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsNotNull method throws when the o parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsNotNullWithNullO()
    {
        FluentActions.Invoking(() => NullCheck.IsNotNull(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("o");
    }

    /// <summary>
    /// Checks that the IsNull method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsNull()
    {
        // Arrange
        var o = _fixture.Create<object>();

        // Act
        var result = NullCheck.IsNull(o);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsNull method throws when the o parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsNullWithNullO()
    {
        FluentActions.Invoking(() => NullCheck.IsNull(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("o");
    }
}

/// <summary>
/// Unit tests for the type <see cref="SizeMismatchException"/>.
/// </summary>
public class SizeMismatchExceptionTests
{
    private SizeMismatchException _testClass;
    private IFixture _fixture;
    private string _s;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SizeMismatchException"/>.
    /// </summary>
    public SizeMismatchExceptionTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._s = _fixture.Create<string>();
        this._testClass = _fixture.Create<SizeMismatchException>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SizeMismatchException(this._s);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the s parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidS(string value)
    {
        FluentActions.Invoking(() => new SizeMismatchException(value)).Should().Throw<ArgumentNullException>().WithParameterName("s");
    }
}