using System;
using System.Linq.Expressions;
using System.Reflection.Emit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math;
using Undersoft.SDK.Instant.Math.Formulas;
using Undersoft.SDK.Instant.Math.Set;
using Undersoft.SDK.Instant.Series;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Instant.Math.Set;

/// <summary>
/// Unit tests for the type <see cref="MathSet"/>.
/// </summary>
public class MathSet_1Tests
{
    private MathSet<T> _testClass;
    private IFixture _fixture;
    private MathSetFormula _rubric;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MathSet"/>.
    /// </summary>
    public MathSet_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._rubric = _fixture.Create<MathSetFormula>();
        this._testClass = _fixture.Create<MathSet<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new MathSet<T>(this._rubric);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the rubric parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRubric()
    {
        FluentActions.Invoking(() => new MathSet<T>(default(MathSetFormula))).Should().Throw<ArgumentNullException>().WithParameterName("rubric");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexer()
    {
        this._testClass[_fixture.Create<Expression<Func<T, object>>>()].Should().BeAssignableTo<SubMathSet>();
        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="MathSet"/>.
/// </summary>
public class MathSetTests
{
    private MathSet _testClass;
    private IFixture _fixture;
    private MathSetFormula _rubric;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MathSet"/>.
    /// </summary>
    public MathSetTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._rubric = _fixture.Create<MathSetFormula>();
        this._testClass = _fixture.Create<MathSet>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new MathSet(this._rubric);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the rubric parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRubric()
    {
        FluentActions.Invoking(() => new MathSet(default(MathSetFormula))).Should().Throw<ArgumentNullException>().WithParameterName("rubric");
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
    /// Checks that the AssignRubric method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAssignRubricWithOrdinal()
    {
        // Arrange
        var ordinal = _fixture.Create<int>();

        // Act
        var result = this._testClass.AssignRubric(ordinal);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveRubric method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveRubric()
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
    public void CannotCallRemoveRubricWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.RemoveRubric(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the AssignContext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAssignContext()
    {
        // Arrange
        var Context = _fixture.Create<InstantMathCompilerContext>();

        // Act
        this._testClass.AssignContext(Context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AssignContext method throws when the Context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAssignContextWithNullContext()
    {
        FluentActions.Invoking(() => this._testClass.AssignContext(default(InstantMathCompilerContext))).Should().Throw<ArgumentNullException>().WithParameterName("Context");
    }

    /// <summary>
    /// Checks that the Clone method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClone()
    {
        // Act
        var result = this._testClass.Clone();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Range method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRange()
    {
        // Arrange
        var i1 = _fixture.Create<int>();
        var i2 = _fixture.Create<int>();

        // Act
        var result = MathSet.Range(i1, i2);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileAssign method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileAssign()
    {
        // Arrange
        var g = _fixture.Create<ILGenerator>();
        var cc = _fixture.Create<InstantMathCompilerContext>();
        var post = _fixture.Create<bool>();
        var @partial = _fixture.Create<bool>();

        // Act
        this._testClass.CompileAssign(g, cc, post, partial
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileAssign method throws when the g parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileAssignWithNullG()
    {
        FluentActions.Invoking(() => this._testClass.CompileAssign(default(ILGenerator), _fixture.Create<InstantMathCompilerContext>(), _fixture.Create<bool>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("g");
    }

    /// <summary>
    /// Checks that the CompileAssign method throws when the cc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileAssignWithNullCc()
    {
        FluentActions.Invoking(() => this._testClass.CompileAssign(_fixture.Create<ILGenerator>(), default(InstantMathCompilerContext), _fixture.Create<bool>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("cc");
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
    /// Checks that the SetDimensions method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetDimensions()
    {
        // Arrange
        var sm = _fixture.Create<SubMathSet>();
        var mx = _fixture.Create<MathSet>();
        var offset = _fixture.Create<int>();

        // Act
        this._testClass.SetDimensions(sm, mx, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetDimensions method throws when the sm parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetDimensionsWithNullSm()
    {
        FluentActions.Invoking(() => this._testClass.SetDimensions(default(SubMathSet), _fixture.Create<MathSet>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("sm");
    }

    /// <summary>
    /// Checks that the GetAll method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetAll()
    {
        // Arrange
        var rubric = _fixture.Create<MathSetFormula>();

        // Act
        var result = this._testClass.GetAll(rubric);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetAll method throws when the rubric parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetAllWithNullRubric()
    {
        FluentActions.Invoking(() => this._testClass.GetAll(default(MathSetFormula))).Should().Throw<ArgumentNullException>().WithParameterName("rubric");
    }

    /// <summary>
    /// Checks that the GetAll maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetAllPerformsMapping()
    {
        // Arrange
        var rubric = _fixture.Create<MathSetFormula>();

        // Act
        var result = this._testClass.GetAll(rubric);

        // Assert
        result.Rubric.Should().BeSameAs(rubric);
    }

    /// <summary>
    /// Checks that the GetRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRange()
    {
        // Arrange
        var startRowId = _fixture.Create<int>();
        var endRowId = _fixture.Create<int>();
        var rubric = _fixture.Create<MathSetFormula>();

        // Act
        var result = this._testClass.GetRange(startRowId, endRowId, rubric);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRange method throws when the rubric parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeWithNullRubric()
    {
        FluentActions.Invoking(() => this._testClass.GetRange(_fixture.Create<int>(), _fixture.Create<int>(), default(MathSetFormula))).Should().Throw<ArgumentNullException>().WithParameterName("rubric");
    }

    /// <summary>
    /// Checks that the GetRange maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetRangePerformsMapping()
    {
        // Arrange
        var startRowId = _fixture.Create<int>();
        var endRowId = _fixture.Create<int>();
        var rubric = _fixture.Create<MathSetFormula>();

        // Act
        var result = this._testClass.GetRange(startRowId, endRowId, rubric);

        // Assert
        result.Rubric.Should().BeSameAs(rubric);
    }

    /// <summary>
    /// Checks that the GetColumn method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetColumn()
    {
        // Arrange
        var j = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetColumn(j);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetColumnCount method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetColumnCount()
    {
        // Arrange
        var j1 = _fixture.Create<int>();
        var j2 = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetColumnCount(j1, j2);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRow method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRow()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetRow(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRowCount method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRowCount()
    {
        // Arrange
        var i1 = _fixture.Create<int>();
        var i2 = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetRowCount(i1, i2);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetItems method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetItems()
    {
        // Arrange
        var e1 = _fixture.Create<int>();
        var e2 = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetItems(e1, e2);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Formuler property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFormuler()
    {
        // Arrange
        var testValue = _fixture.Create<MathSet>();

        // Act
        this._testClass.Formuler = testValue;

        // Assert
        this._testClass.Formuler.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the SubFormuler property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSubFormuler()
    {
        // Arrange
        var testValue = _fixture.Create<SubMathSet>();

        // Act
        this._testClass.SubFormuler = testValue;

        // Assert
        this._testClass.SubFormuler.Should().BeSameAs(testValue);
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
    /// Checks that the Data property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetData()
    {
        // Assert
        this._testClass.Data.Should().BeAssignableTo<IInstantSeries>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Rubrics property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubrics()
    {
        // Arrange
        var testValue = _fixture.Create<MathSetRoutine>();

        // Act
        this._testClass.Rubrics = testValue;

        // Assert
        this._testClass.Rubrics.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Rubric property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubric()
    {
        // Arrange
        var testValue = _fixture.Create<MathSetFormula>();

        // Act
        this._testClass.Rubric = testValue;

        // Assert
        this._testClass.Rubric.Should().BeSameAs(testValue);
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
    /// Checks that the FieldId property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetFieldId()
    {
        // Assert
        this._testClass.FieldId.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the rowCount property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetrowCount()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.rowCount = testValue;

        // Assert
        this._testClass.rowCount.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the colCount property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetcolCount()
    {
        // Assert
        this._testClass.colCount.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
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

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForLong()
    {
        var testValue = _fixture.Create<double>();
        this._testClass[_fixture.Create<long>()].As<object>().Should().BeAssignableTo<double>();
        this._testClass[_fixture.Create<long>()] = testValue;
        this._testClass[_fixture.Create<long>()].Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForLongAndLong()
    {
        var testValue = _fixture.Create<double>();
        this._testClass[_fixture.Create<long>(), _fixture.Create<long>()].As<object>().Should().BeAssignableTo<double>();
        this._testClass[_fixture.Create<long>(), _fixture.Create<long>()] = testValue;
        this._testClass[_fixture.Create<long>(), _fixture.Create<long>()].Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForString()
    {
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<SubMathSet>();
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForIntAndString()
    {
        this._testClass[_fixture.Create<int>(), _fixture.Create<string>()].Should().BeAssignableTo<SubMathSet>();
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForInt()
    {
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<MathSet.Mathstage>();
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForIndexRange()
    {
        this._testClass[_fixture.Create<MathSet.IndexRange>()].Should().BeAssignableTo<MathSet.Mathstage>();
        Assert.Fail("Create or modify test");
    }
}