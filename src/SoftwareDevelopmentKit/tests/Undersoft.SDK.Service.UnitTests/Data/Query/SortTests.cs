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
/// Unit tests for the type <see cref="Sort"/>.
/// </summary>
public class Sort_1Tests
{
    private Sort<TEntity> _testClass;
    private IFixture _fixture;
    private Expression<Func<TEntity, object>> _expressionItem;
    private SortDirection _directionSortDirection;
    private MemberRubric _sortedRubric;
    private string _rubricName;
    private string _directionString;
    private SortItem _item;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Sort"/>.
    /// </summary>
    public Sort_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._expressionItem = _fixture.Create<Expression<Func<TEntity, object>>>();
        this._directionSortDirection = _fixture.Create<SortDirection>();
        this._sortedRubric = _fixture.Create<MemberRubric>();
        this._rubricName = _fixture.Create<string>();
        this._directionString = _fixture.Create<string>();
        this._item = _fixture.Create<SortItem>();
        this._testClass = _fixture.Create<Sort<TEntity>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Sort<TEntity>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Sort<TEntity>(this._expressionItem, this._directionSortDirection);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Sort<TEntity>(this._sortedRubric, this._directionSortDirection);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Sort<TEntity>(this._rubricName, this._directionString);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Sort<TEntity>(this._item);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the expressionItem parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpressionItem()
    {
        FluentActions.Invoking(() => new Sort<TEntity>(default(Expression<Func<TEntity, object>>), this._directionSortDirection)).Should().Throw<ArgumentNullException>().WithParameterName("expressionItem");
    }

    /// <summary>
    /// Checks that instance construction throws when the sortedRubric parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSortedRubric()
    {
        FluentActions.Invoking(() => new Sort<TEntity>(default(MemberRubric), this._directionSortDirection)).Should().Throw<ArgumentNullException>().WithParameterName("sortedRubric");
    }

    /// <summary>
    /// Checks that instance construction throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullItem()
    {
        FluentActions.Invoking(() => new Sort<TEntity>(default(SortItem))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the constructor throws when the rubricName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidRubricName(string value)
    {
        FluentActions.Invoking(() => new Sort<TEntity>(value, this._directionString)).Should().Throw<ArgumentNullException>().WithParameterName("rubricName");
    }

    /// <summary>
    /// Checks that the constructor throws when the direction parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidDirection(string value)
    {
        FluentActions.Invoking(() => new Sort<TEntity>(this._expressionItem, value)).Should().Throw<ArgumentNullException>().WithParameterName("direction");
        FluentActions.Invoking(() => new Sort<TEntity>(this._sortedRubric, value)).Should().Throw<ArgumentNullException>().WithParameterName("direction");
        FluentActions.Invoking(() => new Sort<TEntity>(this._rubricName, value)).Should().Throw<ArgumentNullException>().WithParameterName("direction");
    }

    /// <summary>
    /// Checks that the Assign method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAssign()
    {
        // Arrange
        var sortExpression = _fixture.Create<SortExpression<TEntity>>();

        // Act
        this._testClass.Assign(sortExpression);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Assign method throws when the sortExpression parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAssignWithNullSortExpression()
    {
        FluentActions.Invoking(() => this._testClass.Assign(default(SortExpression<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("sortExpression");
    }

    /// <summary>
    /// Checks that the Compare method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompare()
    {
        // Arrange
        var term = _fixture.Create<Sort<TEntity>>();

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
        FluentActions.Invoking(() => this._testClass.Compare(default(Sort<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("term");
    }

    /// <summary>
    /// Checks that the ExpressionItem property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetExpressionItem()
    {
        // Arrange
        var testValue = _fixture.Create<Expression<Func<TEntity, object>>>();

        // Act
        this._testClass.ExpressionItem = testValue;

        // Assert
        this._testClass.ExpressionItem.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Direction property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDirection()
    {
        // Arrange
        var testValue = _fixture.Create<SortDirection>();

        // Act
        this._testClass.Direction = testValue;

        // Assert
        this._testClass.Direction.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Position property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPosition()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.Position = testValue;

        // Assert
        this._testClass.Position.Should().Be(testValue);
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
}