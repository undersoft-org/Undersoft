using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Service.Data.Query;
using TEntity = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Query;

/// <summary>
/// Unit tests for the type <see cref="Filter"/>.
/// </summary>
public class Filter_1Tests
{
    private Filter<TEntity> _testClass;
    private IFixture _fixture;
    private Expression<Func<TEntity, bool>> _expressionItem;
    private LogicOperand _linkOperand;
    private MemberRubric _rubric;
    private MathOperand _compareOperandMathOperand;
    private object _compareValue;
    private string _propertyName;
    private string _compareOperandString;
    private string _linkLogic;
    private FilterItem _item;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Filter"/>.
    /// </summary>
    public Filter_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._expressionItem = _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._linkOperand = _fixture.Create<LogicOperand>();
        this._rubric = _fixture.Create<MemberRubric>();
        this._compareOperandMathOperand = _fixture.Create<MathOperand>();
        this._compareValue = _fixture.Create<object>();
        this._propertyName = _fixture.Create<string>();
        this._compareOperandString = _fixture.Create<string>();
        this._linkLogic = _fixture.Create<string>();
        this._item = _fixture.Create<FilterItem>();
        this._testClass = _fixture.Create<Filter<TEntity>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Filter<TEntity>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Filter<TEntity>(this._expressionItem, this._linkOperand);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Filter<TEntity>(this._rubric, this._compareOperandMathOperand, this._compareValue, this._linkOperand);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Filter<TEntity>(this._propertyName, this._compareOperandMathOperand, this._compareValue, this._linkOperand);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Filter<TEntity>(this._propertyName, this._compareOperandString, this._compareValue, this._linkLogic);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Filter<TEntity>(this._item);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the expressionItem parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpressionItem()
    {
        FluentActions.Invoking(() => new Filter<TEntity>(default(Expression<Func<TEntity, bool>>), this._linkOperand)).Should().Throw<ArgumentNullException>().WithParameterName("expressionItem");
    }

    /// <summary>
    /// Checks that instance construction throws when the rubric parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRubric()
    {
        FluentActions.Invoking(() => new Filter<TEntity>(default(MemberRubric), this._compareOperandMathOperand, this._compareValue, this._linkOperand)).Should().Throw<ArgumentNullException>().WithParameterName("rubric");
    }

    /// <summary>
    /// Checks that instance construction throws when the compareValue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCompareValue()
    {
        FluentActions.Invoking(() => new Filter<TEntity>(this._rubric, this._compareOperandMathOperand, default(object), this._linkOperand)).Should().Throw<ArgumentNullException>().WithParameterName("compareValue");
        FluentActions.Invoking(() => new Filter<TEntity>(this._propertyName, this._compareOperandMathOperand, default(object), this._linkOperand)).Should().Throw<ArgumentNullException>().WithParameterName("compareValue");
        FluentActions.Invoking(() => new Filter<TEntity>(this._propertyName, this._compareOperandString, default(object), this._linkLogic)).Should().Throw<ArgumentNullException>().WithParameterName("compareValue");
    }

    /// <summary>
    /// Checks that instance construction throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullItem()
    {
        FluentActions.Invoking(() => new Filter<TEntity>(default(FilterItem))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the constructor throws when the propertyName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidPropertyName(string value)
    {
        FluentActions.Invoking(() => new Filter<TEntity>(value, this._compareOperandMathOperand, this._compareValue, this._linkOperand)).Should().Throw<ArgumentNullException>().WithParameterName("propertyName");
        FluentActions.Invoking(() => new Filter<TEntity>(value, this._compareOperandString, this._compareValue, this._linkLogic)).Should().Throw<ArgumentNullException>().WithParameterName("propertyName");
    }

    /// <summary>
    /// Checks that the constructor throws when the compareOperand parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidCompareOperand(string value)
    {
        FluentActions.Invoking(() => new Filter<TEntity>(this._rubric, value, this._compareValue, this._linkOperand)).Should().Throw<ArgumentNullException>().WithParameterName("compareOperand");
        FluentActions.Invoking(() => new Filter<TEntity>(this._propertyName, value, this._compareValue, this._linkOperand)).Should().Throw<ArgumentNullException>().WithParameterName("compareOperand");
        FluentActions.Invoking(() => new Filter<TEntity>(this._propertyName, value, this._compareValue, this._linkLogic)).Should().Throw<ArgumentNullException>().WithParameterName("compareOperand");
    }

    /// <summary>
    /// Checks that the constructor throws when the linkLogic parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidLinkLogic(string value)
    {
        FluentActions.Invoking(() => new Filter<TEntity>(this._propertyName, this._compareOperandString, this._compareValue, value)).Should().Throw<ArgumentNullException>().WithParameterName("linkLogic");
    }

    /// <summary>
    /// Checks that the Assign method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAssign()
    {
        // Arrange
        var filterExpression = _fixture.Create<FilterExpression<TEntity>>();

        // Act
        this._testClass.Assign(filterExpression);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Assign method throws when the filterExpression parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAssignWithNullFilterExpression()
    {
        FluentActions.Invoking(() => this._testClass.Assign(default(FilterExpression<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("filterExpression");
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
        var term = _fixture.Create<Filter<TEntity>>();

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
        FluentActions.Invoking(() => this._testClass.Compare(default(Filter<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("term");
    }

    /// <summary>
    /// Checks that the ExpressionItem property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetExpressionItem()
    {
        // Arrange
        var testValue = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        this._testClass.ExpressionItem = testValue;

        // Assert
        this._testClass.ExpressionItem.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Rubric property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubric()
    {
        // Arrange
        var testValue = _fixture.Create<MemberRubric>();

        // Act
        this._testClass.Rubric = testValue;

        // Assert
        this._testClass.Rubric.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Property property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProperty()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Property = testValue;

        // Assert
        this._testClass.Property.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the PropertyType property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPropertyType()
    {
        // Arrange
        var testValue = _fixture.Create<Type>();

        // Act
        this._testClass.PropertyType = testValue;

        // Assert
        this._testClass.PropertyType.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Operand property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOperand()
    {
        // Arrange
        var testValue = _fixture.Create<MathOperand>();

        // Act
        this._testClass.Operand = testValue;

        // Assert
        this._testClass.Operand.Should().Be(testValue);
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
    /// Checks that the Logic property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLogic()
    {
        // Arrange
        var testValue = _fixture.Create<LogicOperand>();

        // Act
        this._testClass.Logic = testValue;

        // Assert
        this._testClass.Logic.Should().Be(testValue);
    }
}