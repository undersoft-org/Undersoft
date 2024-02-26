using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Query;
using TEntity = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Query;

/// <summary>
/// Unit tests for the type <see cref="SortExpression"/>.
/// </summary>
public class SortExpression_1Tests
{
    private SortExpression<TEntity> _testClass;
    private IFixture _fixture;
    private Expression<Func<TEntity, object>> _expressionItem;
    private SortDirection _direction;
    private Sort<TEntity>[] _sortItemsUnknownType;
    private IEnumerable<Sort<TEntity>> _sortItemsIEnumerableSortTEntity;
    private IEnumerable<SortItem> _sortItemsIEnumerableSortItem;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SortExpression"/>.
    /// </summary>
    public SortExpression_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._expressionItem = _fixture.Create<Expression<Func<TEntity, object>>>();
        this._direction = _fixture.Create<SortDirection>();
        this._sortItemsUnknownType = _fixture.Create<Sort<TEntity>[]>();
        this._sortItemsIEnumerableSortTEntity = _fixture.Create<IEnumerable<Sort<TEntity>>>();
        this._sortItemsIEnumerableSortItem = _fixture.Create<IEnumerable<SortItem>>();
        this._testClass = _fixture.Create<SortExpression<TEntity>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SortExpression<TEntity>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SortExpression<TEntity>(this._expressionItem, this._direction);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SortExpression<TEntity>(this._sortItemsUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SortExpression<TEntity>(this._sortItemsIEnumerableSortTEntity);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SortExpression<TEntity>(this._sortItemsIEnumerableSortItem);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the expressionItem parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpressionItem()
    {
        FluentActions.Invoking(() => new SortExpression<TEntity>(default(Expression<Func<TEntity, object>>), this._direction)).Should().Throw<ArgumentNullException>().WithParameterName("expressionItem");
    }

    /// <summary>
    /// Checks that instance construction throws when the sortItems parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSortItems()
    {
        FluentActions.Invoking(() => new SortExpression<TEntity>(default(Sort<TEntity>[]))).Should().Throw<ArgumentNullException>().WithParameterName("sortItems");
        FluentActions.Invoking(() => new SortExpression<TEntity>(default(IEnumerable<Sort<TEntity>>))).Should().Throw<ArgumentNullException>().WithParameterName("sortItems");
        FluentActions.Invoking(() => new SortExpression<TEntity>(default(IEnumerable<SortItem>))).Should().Throw<ArgumentNullException>().WithParameterName("sortItems");
    }

    /// <summary>
    /// Checks that the Sort method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSortWithQuery()
    {
        // Arrange
        var query = _fixture.Create<IQueryable<TEntity>>();

        // Act
        var result = this._testClass.Sort(query);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Sort method throws when the query parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSortWithQueryWithNullQuery()
    {
        FluentActions.Invoking(() => this._testClass.Sort(default(IQueryable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that the Sort method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSortWithQueryAndSortItems()
    {
        // Arrange
        var query = _fixture.Create<IQueryable<TEntity>>();
        var sortItems = _fixture.Create<IEnumerable<Sort<TEntity>>>();

        // Act
        var result = this._testClass.Sort(query, sortItems);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Sort method throws when the query parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSortWithQueryAndSortItemsWithNullQuery()
    {
        FluentActions.Invoking(() => this._testClass.Sort(default(IQueryable<TEntity>), _fixture.Create<IEnumerable<Sort<TEntity>>>())).Should().Throw<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that the Sort method throws when the sortItems parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSortWithQueryAndSortItemsWithNullSortItems()
    {
        FluentActions.Invoking(() => this._testClass.Sort(_fixture.Create<IQueryable<TEntity>>(), default(IEnumerable<Sort<TEntity>>))).Should().Throw<ArgumentNullException>().WithParameterName("sortItems");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithItem()
    {
        // Arrange
        var item = _fixture.Create<Sort<TEntity>>();

        // Act
        var result = this._testClass.Add(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithItemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(Sort<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithSortItems()
    {
        // Arrange
        var sortItems = _fixture.Create<IEnumerable<Sort<TEntity>>>();

        // Act
        var result = this._testClass.Add(sortItems);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the sortItems parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithSortItemsWithNullSortItems()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IEnumerable<Sort<TEntity>>))).Should().Throw<ArgumentNullException>().WithParameterName("sortItems");
    }
}