using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Query;
using TEntity = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Query;

/// <summary>
/// Unit tests for the type <see cref="FilterExpression"/>.
/// </summary>
public class FilterExpression_1Tests
{
    private FilterExpression<TEntity> _testClass;
    private IFixture _fixture;
    private Filter<TEntity>[] _filterItemsUnknownType;
    private IEnumerable<Filter<TEntity>> _filterItemsIEnumerableFilterTEntity;
    private IEnumerable<FilterItem> _filterItemsIEnumerableFilterItem;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="FilterExpression"/>.
    /// </summary>
    public FilterExpression_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._filterItemsUnknownType = _fixture.Create<Filter<TEntity>[]>();
        this._filterItemsIEnumerableFilterTEntity = _fixture.Create<IEnumerable<Filter<TEntity>>>();
        this._filterItemsIEnumerableFilterItem = _fixture.Create<IEnumerable<FilterItem>>();
        this._testClass = _fixture.Create<FilterExpression<TEntity>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new FilterExpression<TEntity>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new FilterExpression<TEntity>(this._filterItemsUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new FilterExpression<TEntity>(this._filterItemsIEnumerableFilterTEntity);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new FilterExpression<TEntity>(this._filterItemsIEnumerableFilterItem);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the filterItems parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullFilterItems()
    {
        FluentActions.Invoking(() => new FilterExpression<TEntity>(default(Filter<TEntity>[]))).Should().Throw<ArgumentNullException>().WithParameterName("filterItems");
        FluentActions.Invoking(() => new FilterExpression<TEntity>(default(IEnumerable<Filter<TEntity>>))).Should().Throw<ArgumentNullException>().WithParameterName("filterItems");
        FluentActions.Invoking(() => new FilterExpression<TEntity>(default(IEnumerable<FilterItem>))).Should().Throw<ArgumentNullException>().WithParameterName("filterItems");
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateWithNoParameters()
    {
        // Act
        var result = this._testClass.Create();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateWithIEnumerableOfFilterOfTEntity()
    {
        // Arrange
        var filterItems = _fixture.Create<IEnumerable<Filter<TEntity>>>();

        // Act
        var result = this._testClass.Create(filterItems);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method throws when the filterItems parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateWithIEnumerableOfFilterOfTEntityWithNullFilterItems()
    {
        FluentActions.Invoking(() => this._testClass.Create(default(IEnumerable<Filter<TEntity>>))).Should().Throw<ArgumentNullException>().WithParameterName("filterItems");
    }

    /// <summary>
    /// Checks that the ConvertItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConvertItem()
    {
        // Arrange
        var filterItem = _fixture.Create<Filter<TEntity>>();
        var expression = _fixture.Create<Expression<Func<TEntity, bool>>>();

        // Act
        var result = this._testClass.ConvertItem(filterItem, expression);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ConvertItem method throws when the filterItem parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConvertItemWithNullFilterItem()
    {
        FluentActions.Invoking(() => this._testClass.ConvertItem(default(Filter<TEntity>), _fixture.Create<Expression<Func<TEntity, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("filterItem");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithItem()
    {
        // Arrange
        var item = _fixture.Create<Filter<TEntity>>();

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
        FluentActions.Invoking(() => this._testClass.Add(default(Filter<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIEnumerableOfFilterOfTEntity()
    {
        // Arrange
        var filterItems = _fixture.Create<IEnumerable<Filter<TEntity>>>();

        // Act
        var result = this._testClass.Add(filterItems);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the filterItems parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIEnumerableOfFilterOfTEntityWithNullFilterItems()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IEnumerable<Filter<TEntity>>))).Should().Throw<ArgumentNullException>().WithParameterName("filterItems");
    }
}