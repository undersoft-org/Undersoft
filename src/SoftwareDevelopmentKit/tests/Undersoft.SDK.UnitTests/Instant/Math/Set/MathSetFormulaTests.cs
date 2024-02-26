using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math.Formulas;
using Undersoft.SDK.Instant.Math.Set;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Uniques;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Instant.Math.Set;

/// <summary>
/// Unit tests for the type <see cref="MathSetFormula"/>.
/// </summary>
public class MathSetFormulaTests
{
    private MathSetFormula _testClass;
    private IFixture _fixture;
    private MathSetRoutine _routineSet;
    private MemberRubric _rubric;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MathSetFormula"/>.
    /// </summary>
    public MathSetFormulaTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._routineSet = _fixture.Create<MathSetRoutine>();
        this._rubric = _fixture.Create<MemberRubric>();
        this._testClass = _fixture.Create<MathSetFormula>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new MathSetFormula(this._routineSet, this._rubric);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the routineSet parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRoutineSet()
    {
        FluentActions.Invoking(() => new MathSetFormula(default(MathSetRoutine), this._rubric)).Should().Throw<ArgumentNullException>().WithParameterName("routineSet");
    }

    /// <summary>
    /// Checks that instance construction throws when the rubric parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRubric()
    {
        FluentActions.Invoking(() => new MathSetFormula(this._routineSet, default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("rubric");
    }

    /// <summary>
    /// Checks that the AssignRubric method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAssignRubricWithInt()
    {
        // Arrange
        var ordinal = _fixture.Create<int>();

        // Act
        var result = this._testClass.AssignRubric(ordinal);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AssignRubric method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAssignRubricWithString()
    {
        // Arrange
        var name = _fixture.Create<string>();

        // Act
        var result = this._testClass.AssignRubric(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AssignRubric method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallAssignRubricWithStringWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.AssignRubric(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the CloneMathset method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCloneMathset()
    {
        // Act
        var result = this._testClass.CloneMathset();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CombineEvaluator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCombineEvaluator()
    {
        // Act
        var result = this._testClass.CombineEvaluator();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCompiledMathSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCompiledMathSet()
    {
        // Act
        var result = this._testClass.GetCompiledMathSet();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareTo()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the Compute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompute()
    {
        // Act
        var result = this._testClass.Compute();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.Equals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytes()
    {
        // Act
        var result = this._testClass.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetMathset method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMathsetWithT()
    {
        // Act
        var result = this._testClass.GetMathset<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetMathset method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMathsetWithNoParameters()
    {
        // Act
        var result = this._testClass.GetMathset();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIdBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIdBytes()
    {
        // Act
        var result = this._testClass.GetIdBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewMathset method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewMathset()
    {
        // Act
        var result = this._testClass.NewMathset();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveRubric method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveRubricWithInt()
    {
        // Arrange
        var ordinal = _fixture.Create<int>();

        // Act
        var result = this._testClass.RemoveRubric(ordinal);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveRubric method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveRubricWithString()
    {
        // Arrange
        var name = _fixture.Create<string>();

        // Act
        var result = this._testClass.RemoveRubric(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveRubric method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRemoveRubricWithStringWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.RemoveRubric(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ComputeOrdinal property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetComputeOrdinal()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.ComputeOrdinal = testValue;

        // Assert
        this._testClass.ComputeOrdinal.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Empty property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetEmpty()
    {
        // Assert
        this._testClass.Empty.Should().BeAssignableTo<IUnique>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Evaluator property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEvaluator()
    {
        // Arrange
        var testValue = _fixture.Create<MathSetComputer>();

        // Act
        this._testClass.Evaluator = testValue;

        // Assert
        this._testClass.Evaluator.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the InstantCreatorFieldId property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetInstantCreatorFieldId()
    {
        // Assert
        this._testClass.InstantCreatorFieldId.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Formula property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFormula()
    {
        // Arrange
        var testValue = _fixture.Create<Formula>();

        // Act
        this._testClass.Formula = testValue;

        // Assert
        this._testClass.Formula.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the FormulaSet property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetFormulaSet()
    {
        // Assert
        this._testClass.FormulaSet.Should().BeAssignableTo<MathSetFormula>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Routine property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRoutine()
    {
        // Arrange
        var testValue = _fixture.Create<MathSetRoutine>();

        // Act
        this._testClass.Routine = testValue;

        // Assert
        this._testClass.Routine.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Set property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSet()
    {
        // Arrange
        var testValue = _fixture.Create<MathSet>();

        // Act
        this._testClass.Set = testValue;

        // Assert
        this._testClass.Set.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the RoutineSet property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRoutineSet()
    {
        // Arrange
        var testValue = _fixture.Create<MathSetRoutine>();

        // Act
        this._testClass.RoutineSet = testValue;

        // Assert
        this._testClass.RoutineSet.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the PartialMathset property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPartialMathset()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.PartialMathset = testValue;

        // Assert
        this._testClass.PartialMathset.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the RightFormula property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRightFormula()
    {
        // Arrange
        var testValue = _fixture.Create<Formula>();

        // Act
        this._testClass.RightFormula = testValue;

        // Assert
        this._testClass.RightFormula.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the RubricName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRubricName()
    {
        // Assert
        this._testClass.RubricName.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RubricType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRubricType()
    {
        // Assert
        this._testClass.RubricType.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SubSet property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSubSet()
    {
        // Arrange
        var testValue = _fixture.Create<SubMathSet>();

        // Act
        this._testClass.SubSet = testValue;

        // Assert
        this._testClass.SubSet.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Id property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.Id = testValue;

        // Assert
        this._testClass.Id.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the TypeId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.TypeId = testValue;

        // Assert
        this._testClass.TypeId.Should().Be(testValue);
    }
}