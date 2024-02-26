using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Series.Querying;
using Undersoft.SDK.Rubrics;

namespace Undersoft.SDK.UnitTests.Instant.Series.Querying;

/// <summary>
/// Unit tests for the type <see cref="InstantSeriesFilterTerm"/>.
/// </summary>
public class InstantSeriesFilterTermTests
{
    private InstantSeriesFilterTerm _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _series;
    private string _filterColumnString;
    private string _operandString;
    private object _value;
    private string _logicString;
    private int _stageInt32;
    private MemberRubric _filterColumnMemberRubric;
    private OperandType _operandOperandType;
    private LogicType _logicLogicType;
    private FilterStage _stageFilterStage;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSeriesFilterTerm"/>.
    /// </summary>
    public InstantSeriesFilterTermTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._series = _fixture.Freeze<Mock<IInstantSeries>>();
        this._filterColumnString = _fixture.Create<string>();
        this._operandString = _fixture.Create<string>();
        this._value = _fixture.Create<object>();
        this._logicString = _fixture.Create<string>();
        this._stageInt32 = _fixture.Create<int>();
        this._filterColumnMemberRubric = _fixture.Create<MemberRubric>();
        this._operandOperandType = _fixture.Create<OperandType>();
        this._logicLogicType = _fixture.Create<LogicType>();
        this._stageFilterStage = _fixture.Create<FilterStage>();
        this._testClass = _fixture.Create<InstantSeriesFilterTerm>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSeriesFilterTerm();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesFilterTerm(this._series.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesFilterTerm(this._series.Object, this._filterColumnString, this._operandString, this._value, this._logicString, this._stageInt32);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesFilterTerm(this._filterColumnMemberRubric, this._operandOperandType, this._value, this._logicLogicType, this._stageFilterStage);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesFilterTerm(this._filterColumnString, this._operandOperandType, this._value, this._logicLogicType, this._stageFilterStage);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesFilterTerm(this._filterColumnString, this._operandString, this._value, this._logicString, this._stageInt32);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSeries()
    {
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("series");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(default(IInstantSeries), this._filterColumnString, this._operandString, this._value, this._logicString, this._stageInt32)).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that instance construction throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullValue()
    {
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._series.Object, this._filterColumnString, this._operandString, default(object), this._logicString, this._stageInt32)).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._filterColumnMemberRubric, this._operandOperandType, default(object), this._logicLogicType, this._stageFilterStage)).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._filterColumnString, this._operandOperandType, default(object), this._logicLogicType, this._stageFilterStage)).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._filterColumnString, this._operandString, default(object), this._logicString, this._stageInt32)).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that instance construction throws when the filterColumn parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullFilterColumn()
    {
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._series.Object, default(string), this._operandString, this._value, this._logicString, this._stageInt32)).Should().Throw<ArgumentNullException>().WithParameterName("filterColumn");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(default(MemberRubric), this._operandOperandType, this._value, this._logicLogicType, this._stageFilterStage)).Should().Throw<ArgumentNullException>().WithParameterName("filterColumn");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(default(string), this._operandOperandType, this._value, this._logicLogicType, this._stageFilterStage)).Should().Throw<ArgumentNullException>().WithParameterName("filterColumn");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(default(string), this._operandString, this._value, this._logicString, this._stageInt32)).Should().Throw<ArgumentNullException>().WithParameterName("filterColumn");
    }

    /// <summary>
    /// Checks that the constructor throws when the filterColumn parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidFilterColumn(string value)
    {
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._series.Object, value, this._operandString, this._value, this._logicString, this._stageInt32)).Should().Throw<ArgumentNullException>().WithParameterName("filterColumn");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(value, this._operandOperandType, this._value, this._logicLogicType, this._stageFilterStage)).Should().Throw<ArgumentNullException>().WithParameterName("filterColumn");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(value, this._operandOperandType, this._value, this._logicLogicType, this._stageFilterStage)).Should().Throw<ArgumentNullException>().WithParameterName("filterColumn");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(value, this._operandString, this._value, this._logicString, this._stageInt32)).Should().Throw<ArgumentNullException>().WithParameterName("filterColumn");
    }

    /// <summary>
    /// Checks that the constructor throws when the operand parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidOperand(string value)
    {
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._series.Object, this._filterColumnString, value, this._value, this._logicString, this._stageInt32)).Should().Throw<ArgumentNullException>().WithParameterName("operand");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._filterColumnMemberRubric, value, this._value, this._logicLogicType, this._stageFilterStage)).Should().Throw<ArgumentNullException>().WithParameterName("operand");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._filterColumnString, value, this._value, this._logicLogicType, this._stageFilterStage)).Should().Throw<ArgumentNullException>().WithParameterName("operand");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._filterColumnString, value, this._value, this._logicString, this._stageInt32)).Should().Throw<ArgumentNullException>().WithParameterName("operand");
    }

    /// <summary>
    /// Checks that the constructor throws when the logic parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidLogic(string value)
    {
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._series.Object, this._filterColumnString, this._operandString, this._value, value, this._stageInt32)).Should().Throw<ArgumentNullException>().WithParameterName("logic");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._filterColumnMemberRubric, this._operandOperandType, this._value, value, this._stageFilterStage)).Should().Throw<ArgumentNullException>().WithParameterName("logic");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._filterColumnString, this._operandOperandType, this._value, value, this._stageFilterStage)).Should().Throw<ArgumentNullException>().WithParameterName("logic");
        FluentActions.Invoking(() => new InstantSeriesFilterTerm(this._filterColumnString, this._operandString, this._value, value, this._stageInt32)).Should().Throw<ArgumentNullException>().WithParameterName("logic");
    }

    /// <summary>
    /// Checks that the Clone method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCloneWithNoParameters()
    {
        // Act
        var result = this._testClass.Clone();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Clone method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCloneWithValue()
    {
        // Arrange
        var value = _fixture.Create<object>();

        // Act
        var result = this._testClass.Clone(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Clone method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCloneWithValueWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Clone(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Clone maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void CloneWithValuePerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<object>();

        // Act
        var result = this._testClass.Clone(value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the Compare method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompare()
    {
        // Arrange
        var term = _fixture.Create<InstantSeriesFilterTerm>();

        // Act
        var result = this._testClass.Compare(term);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compare method throws when the term parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareWithNullTerm()
    {
        FluentActions.Invoking(() => this._testClass.Compare(default(InstantSeriesFilterTerm))).Should().Throw<ArgumentNullException>().WithParameterName("term");
    }

    /// <summary>
    /// Checks that the InstantSeriesCreator property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInstantSeriesCreator()
    {
        // Arrange
        _series.Setup(mock => mock.Rubrics).Returns(_fixture.Create<IRubrics>());

        var testValue = _fixture.Create<IInstantSeries>();

        // Act
        this._testClass.InstantSeriesCreator = testValue;

        // Assert
        this._testClass.InstantSeriesCreator.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the FilterRubric property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFilterRubric()
    {
        // Arrange
        var testValue = _fixture.Create<MemberRubric>();

        // Act
        this._testClass.FilterRubric = testValue;

        // Assert
        this._testClass.FilterRubric.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Index property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndex()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.Index = testValue;

        // Assert
        this._testClass.Index.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Logic property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLogic()
    {
        // Arrange
        var testValue = _fixture.Create<LogicType>();

        // Act
        this._testClass.Logic = testValue;

        // Assert
        this._testClass.Logic.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Operand property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOperand()
    {
        // Arrange
        var testValue = _fixture.Create<OperandType>();

        // Act
        this._testClass.Operand = testValue;

        // Assert
        this._testClass.Operand.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the RubricName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.RubricName = testValue;

        // Assert
        this._testClass.RubricName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Stage property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetStage()
    {
        // Arrange
        var testValue = _fixture.Create<FilterStage>();

        // Act
        this._testClass.Stage = testValue;

        // Assert
        this._testClass.Stage.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Value property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetValue()
    {
        // Arrange
        var testValue = _fixture.Create<object>();

        // Act
        this._testClass.Value = testValue;

        // Assert
        this._testClass.Value.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the ValueType property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetValueType()
    {
        // Arrange
        var testValue = _fixture.Create<Type>();

        // Act
        this._testClass.ValueType = testValue;

        // Assert
        this._testClass.ValueType.Should().BeSameAs(testValue);
    }
}