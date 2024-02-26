using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Math.Set;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.UnitTests.Instant.Math.Set;

/// <summary>
/// Unit tests for the type <see cref="MathSetRoutine"/>.
/// </summary>
public class MathSetRoutineTests
{
    private MathSetRoutine _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _data;
    private Mock<IRubrics> _rubricsIRubrics;
    private MathSetRoutine _rubricsMathSetRoutine;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MathSetRoutine"/>.
    /// </summary>
    public MathSetRoutineTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._data = _fixture.Freeze<Mock<IInstantSeries>>();
        this._rubricsIRubrics = _fixture.Freeze<Mock<IRubrics>>();
        this._rubricsMathSetRoutine = _fixture.Create<MathSetRoutine>();
        this._testClass = _fixture.Create<MathSetRoutine>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new MathSetRoutine(this._data.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MathSetRoutine(this._rubricsIRubrics.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MathSetRoutine(this._rubricsMathSetRoutine);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullData()
    {
        FluentActions.Invoking(() => new MathSetRoutine(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that instance construction throws when the rubrics parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRubrics()
    {
        FluentActions.Invoking(() => new MathSetRoutine(default(IRubrics))).Should().Throw<ArgumentNullException>().WithParameterName("rubrics");
        FluentActions.Invoking(() => new MathSetRoutine(default(MathSetRoutine))).Should().Throw<ArgumentNullException>().WithParameterName("rubrics");
    }

    /// <summary>
    /// Checks that the Combine method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCombineWithIntAndInt()
    {
        // Arrange
        var offset = _fixture.Create<int>();
        var batch = _fixture.Create<int>();

        // Act
        var result = this._testClass.Combine(offset, batch);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Combine method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCombineWithIInstantSeriesAndIntAndInt()
    {
        // Arrange
        var table = _fixture.Create<IInstantSeries>();
        var offset = _fixture.Create<int>();
        var batch = _fixture.Create<int>();

        // Act
        var result = this._testClass.Combine(table, offset, batch);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Combine method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCombineWithIInstantSeriesAndIntAndIntWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.Combine(default(IInstantSeries), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that the Compile method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileWithIntAndInt()
    {
        // Arrange
        var offset = _fixture.Create<int>();
        var batch = _fixture.Create<int>();

        // Act
        var result = this._testClass.Compile(offset, batch);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compile method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileWithIInstantSeriesAndIntAndInt()
    {
        // Arrange
        var table = _fixture.Create<IInstantSeries>();
        var offset = _fixture.Create<int>();
        var batch = _fixture.Create<int>();

        // Act
        var result = this._testClass.Compile(table, offset, batch);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compile method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileWithIInstantSeriesAndIntAndIntWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.Compile(default(IInstantSeries), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that the CombineEvaluators method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCombineEvaluators()
    {
        // Act
        var result = this._testClass.CombineEvaluators();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileEvaluators method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileEvaluators()
    {
        // Act
        var result = this._testClass.CompileEvaluators();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EmptyVector method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyVector()
    {
        // Arrange
        var size = _fixture.Create<int>();

        // Act
        var result = this._testClass.EmptyVector(size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EmptyItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyItem()
    {
        // Act
        var result = this._testClass.EmptyItem();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EmptyTable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyTable()
    {
        // Arrange
        var size = _fixture.Create<int>();

        // Act
        var result = this._testClass.EmptyTable(size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithISeriesItemOfMathSetFormula()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<MathSetFormula>>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithISeriesItemOfMathSetFormulaWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(ISeriesItem<MathSetFormula>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithISeriesItemOfMathSetFormulaPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<MathSetFormula>>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithMathSetFormula()
    {
        // Arrange
        var value = _fixture.Create<MathSetFormula>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithMathSetFormulaWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(MathSetFormula))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithMathSetFormulaPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<MathSetFormula>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithObjectAndMathSetFormula()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<MathSetFormula>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndMathSetFormulaWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(object), _fixture.Create<MathSetFormula>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndMathSetFormulaWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(_fixture.Create<object>(), default(MathSetFormula))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithObjectAndMathSetFormulaPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<MathSetFormula>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithLongAndMathSetFormula()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<MathSetFormula>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithLongAndMathSetFormulaWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(_fixture.Create<long>(), default(MathSetFormula))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithLongAndMathSetFormulaPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<MathSetFormula>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that setting the Data property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetData()
    {
        this._testClass.CheckProperty(x => x.Data, _fixture.Create<IInstantSeries>(), _fixture.Create<IInstantSeries>());
    }

    /// <summary>
    /// Checks that setting the FormulaSet property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFormulaSet()
    {
        this._testClass.CheckProperty(x => x.FormulaSet, _fixture.Create<MathSetRoutine>(), _fixture.Create<MathSetRoutine>());
    }

    /// <summary>
    /// Checks that setting the RoutineSet property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRoutineSet()
    {
        this._testClass.CheckProperty(x => x.RoutineSet, _fixture.Create<MathSetRoutine>(), _fixture.Create<MathSetRoutine>());
    }

    /// <summary>
    /// Checks that the RowsCount property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRowsCount()
    {
        // Assert
        this._testClass.RowsCount.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Rubrics property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubrics()
    {
        this._testClass.CheckProperty(x => x.Rubrics, _fixture.Create<IRubrics>(), _fixture.Create<IRubrics>());
    }

    /// <summary>
    /// Checks that the RubricsCount property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRubricsCount()
    {
        // Assert
        this._testClass.RubricsCount.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }
}