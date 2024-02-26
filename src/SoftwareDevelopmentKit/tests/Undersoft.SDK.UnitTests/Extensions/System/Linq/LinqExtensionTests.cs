using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T = System.String;
using TInner = System.String;
using TItem = System.String;
using TItem0 = System.String;
using TItem1 = System.String;
using TKey = System.String;
using TOuter = System.String;
using TResult = System.String;
using TSource = System.String;
using TValue = System.String;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="LinqExtension"/>.
/// </summary>
public class LinqExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the And method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAnd()
    {
        // Arrange
        var _leftside = _fixture.Create<Expression<Func<T, bool>>>();
        var _rightside = _fixture.Create<Expression<Func<T, bool>>>();

        // Act
        var result = _leftside.And<T>(_rightside
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the And method throws when the _leftside parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAndWithNull_leftside()
    {
        FluentActions.Invoking(() => default(Expression<Func<T, bool>>).And<T>(_fixture.Create<Expression<Func<T, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("_leftside");
    }

    /// <summary>
    /// Checks that the And method throws when the _rightside parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAndWithNull_rightside()
    {
        FluentActions.Invoking(() => _fixture.Create<Expression<Func<T, bool>>>().And<T>(default(Expression<Func<T, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("_rightside");
    }

    /// <summary>
    /// Checks that the ToQueryable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToQueryable()
    {
        // Arrange
        var entity = _fixture.Create<T>();

        // Act
        var result = entity.ToQueryable<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Concentrate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConcentrate()
    {
        // Arrange
        var List = _fixture.Create<IEnumerable<T>[]>();

        // Act
        var result = LinqExtension.Concentrate<T>(List);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Concentrate method throws when the List parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConcentrateWithNullList()
    {
        FluentActions.Invoking(() => LinqExtension.Concentrate<T>(default(IEnumerable<T>[]))).Should().Throw<ArgumentNullException>().WithParameterName("List");
    }

    /// <summary>
    /// Checks that the Collect method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCollectWithIEnumerableOfTItemAndExpressionOfFuncOfTItemAndTValue()
    {
        // Arrange
        var source = _fixture.Create<IEnumerable<TItem>>();
        var valueSelector = _fixture.Create<Expression<Func<TItem, TValue>>>();

        // Act
        var result = source.Collect<TItem, TValue>(valueSelector
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Collect method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCollectWithIEnumerableOfTItemAndExpressionOfFuncOfTItemAndTValueWithNullSource()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).Collect<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Collect method throws when the valueSelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCollectWithIEnumerableOfTItemAndExpressionOfFuncOfTItemAndTValueWithNullValueSelector()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().Collect<TItem, TValue>(default(Expression<Func<TItem, TValue>>))).Should().Throw<ArgumentNullException>().WithParameterName("valueSelector");
    }

    /// <summary>
    /// Checks that the Collect method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCollectWithIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValue()
    {
        // Arrange
        var source = _fixture.Create<IQueryable<TItem>>();
        var valueSelector = _fixture.Create<Expression<Func<TItem, TValue>>>();

        // Act
        var result = source.Collect<TItem, TValue>(valueSelector
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Collect method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCollectWithIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueWithNullSource()
    {
        FluentActions.Invoking(() => default(IQueryable<TItem>).Collect<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Collect method throws when the valueSelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCollectWithIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueWithNullValueSelector()
    {
        FluentActions.Invoking(() => _fixture.Create<IQueryable<TItem>>().Collect<TItem, TValue>(default(Expression<Func<TItem, TValue>>))).Should().Throw<ArgumentNullException>().WithParameterName("valueSelector");
    }

    /// <summary>
    /// Checks that the ContainsIn method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsIn()
    {
        // Arrange
        var source = _fixture.Create<IEnumerable<TItem>>();
        var valueSelector = _fixture.Create<Expression<Func<TItem, TValue>>>();
        var values = _fixture.Create<IEnumerable<TValue>>();

        // Act
        var result = source.ContainsIn<TItem, TValue>(valueSelector, values
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ContainsIn method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsInWithNullSource()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ContainsIn<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>(), _fixture.Create<IEnumerable<TValue>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the ContainsIn method throws when the valueSelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsInWithNullValueSelector()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ContainsIn<TItem, TValue>(default(Expression<Func<TItem, TValue>>), _fixture.Create<IEnumerable<TValue>>())).Should().Throw<ArgumentNullException>().WithParameterName("valueSelector");
    }

    /// <summary>
    /// Checks that the ContainsIn method throws when the values parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsInWithNullValues()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ContainsIn<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>(), default(IEnumerable<TValue>))).Should().Throw<ArgumentNullException>().WithParameterName("values");
    }

    /// <summary>
    /// Checks that the ForKeys method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForKeys()
    {
        // Arrange
        var source = _fixture.Create<IEnumerable<TSource>>();
        Action<TKey> applyBehavior = x => { };
        Func<TSource, TKey> keySelector = x => _fixture.Create<TKey>();

        // Act
        source.ForKeys<TSource, TKey>(applyBehavior, keySelector
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForKeys method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForKeysWithNullSource()
    {
        FluentActions.Invoking(() => default(IEnumerable<TSource>).ForKeys<TSource, TKey>(x => { }, x => _fixture.Create<TKey>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the ForKeys method throws when the applyBehavior parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForKeysWithNullApplyBehavior()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TSource>>().ForKeys<TSource, TKey>(default(Action<TKey>), x => _fixture.Create<TKey>())).Should().Throw<ArgumentNullException>().WithParameterName("applyBehavior");
    }

    /// <summary>
    /// Checks that the ForKeys method throws when the keySelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForKeysWithNullKeySelector()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TSource>>().ForKeys<TSource, TKey>(x => { }, default(Func<TSource, TKey>))).Should().Throw<ArgumentNullException>().WithParameterName("keySelector");
    }

    /// <summary>
    /// Checks that the Greater method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGreater()
    {
        // Arrange
        var _leftside = _fixture.Create<Expression<Func<T, bool>>>();
        var _rightside = _fixture.Create<Expression<Func<T, bool>>>();

        // Act
        var result = _leftside.Greater<T>(_rightside
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Greater method throws when the _leftside parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGreaterWithNull_leftside()
    {
        FluentActions.Invoking(() => default(Expression<Func<T, bool>>).Greater<T>(_fixture.Create<Expression<Func<T, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("_leftside");
    }

    /// <summary>
    /// Checks that the Greater method throws when the _rightside parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGreaterWithNull_rightside()
    {
        FluentActions.Invoking(() => _fixture.Create<Expression<Func<T, bool>>>().Greater<T>(default(Expression<Func<T, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("_rightside");
    }

    /// <summary>
    /// Checks that the GreaterOrEqual method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGreaterOrEqual()
    {
        // Arrange
        var _leftside = _fixture.Create<Expression<Func<T, bool>>>();
        var _rightside = _fixture.Create<Expression<Func<T, bool>>>();

        // Act
        var result = _leftside.GreaterOrEqual<T>(_rightside
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GreaterOrEqual method throws when the _leftside parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGreaterOrEqualWithNull_leftside()
    {
        FluentActions.Invoking(() => default(Expression<Func<T, bool>>).GreaterOrEqual<T>(_fixture.Create<Expression<Func<T, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("_leftside");
    }

    /// <summary>
    /// Checks that the GreaterOrEqual method throws when the _rightside parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGreaterOrEqualWithNull_rightside()
    {
        FluentActions.Invoking(() => _fixture.Create<Expression<Func<T, bool>>>().GreaterOrEqual<T>(default(Expression<Func<T, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("_rightside");
    }

    /// <summary>
    /// Checks that the Join method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallJoin()
    {
        // Arrange
        var outer = _fixture.Create<IEnumerable<TOuter>>();
        var inner = _fixture.Create<LinqExtension.JoinComparerProvider<TInner, TKey>>();
        Func<TOuter, TKey> outerKeySelector = x => _fixture.Create<TKey>();
        Func<TInner, TKey> innerKeySelector = x => _fixture.Create<TKey>();
        Func<TOuter, TInner, TResult> resultSelector = (x, y) => _fixture.Create<TResult>();

        // Act
        var result = outer.Join<TOuter, TInner, TKey, TResult>(inner, outerKeySelector, innerKeySelector, resultSelector
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Join method throws when the outer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallJoinWithNullOuter()
    {
        FluentActions.Invoking(() => default(IEnumerable<TOuter>).Join<TOuter, TInner, TKey, TResult>(_fixture.Create<LinqExtension.JoinComparerProvider<TInner, TKey>>(), x => _fixture.Create<TKey>(), x => _fixture.Create<TKey>(), (x, y) => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("outer");
    }

    /// <summary>
    /// Checks that the Join method throws when the inner parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallJoinWithNullInner()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TOuter>>().Join<TOuter, TInner, TKey, TResult>(default(LinqExtension.JoinComparerProvider<TInner, TKey>), x => _fixture.Create<TKey>(), x => _fixture.Create<TKey>(), (x, y) => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("inner");
    }

    /// <summary>
    /// Checks that the Join method throws when the outerKeySelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallJoinWithNullOuterKeySelector()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TOuter>>().Join<TOuter, TInner, TKey, TResult>(_fixture.Create<LinqExtension.JoinComparerProvider<TInner, TKey>>(), default(Func<TOuter, TKey>), x => _fixture.Create<TKey>(), (x, y) => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("outerKeySelector");
    }

    /// <summary>
    /// Checks that the Join method throws when the innerKeySelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallJoinWithNullInnerKeySelector()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TOuter>>().Join<TOuter, TInner, TKey, TResult>(_fixture.Create<LinqExtension.JoinComparerProvider<TInner, TKey>>(), x => _fixture.Create<TKey>(), default(Func<TInner, TKey>), (x, y) => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("innerKeySelector");
    }

    /// <summary>
    /// Checks that the Join method throws when the resultSelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallJoinWithNullResultSelector()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TOuter>>().Join<TOuter, TInner, TKey, TResult>(_fixture.Create<LinqExtension.JoinComparerProvider<TInner, TKey>>(), x => _fixture.Create<TKey>(), x => _fixture.Create<TKey>(), default(Func<TOuter, TInner, TResult>))).Should().Throw<ArgumentNullException>().WithParameterName("resultSelector");
    }

    /// <summary>
    /// Checks that the Less method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLess()
    {
        // Arrange
        var _leftside = _fixture.Create<Expression<Func<T, bool>>>();
        var _rightside = _fixture.Create<Expression<Func<T, bool>>>();

        // Act
        var result = _leftside.Less<T>(_rightside
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Less method throws when the _leftside parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLessWithNull_leftside()
    {
        FluentActions.Invoking(() => default(Expression<Func<T, bool>>).Less<T>(_fixture.Create<Expression<Func<T, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("_leftside");
    }

    /// <summary>
    /// Checks that the Less method throws when the _rightside parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLessWithNull_rightside()
    {
        FluentActions.Invoking(() => _fixture.Create<Expression<Func<T, bool>>>().Less<T>(default(Expression<Func<T, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("_rightside");
    }

    /// <summary>
    /// Checks that the LessOrEqual method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallLessOrEqual()
    {
        // Arrange
        var _leftside = _fixture.Create<Expression<Func<T, bool>>>();
        var _rightside = _fixture.Create<Expression<Func<T, bool>>>();

        // Act
        var result = _leftside.LessOrEqual<T>(_rightside
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the LessOrEqual method throws when the _leftside parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLessOrEqualWithNull_leftside()
    {
        FluentActions.Invoking(() => default(Expression<Func<T, bool>>).LessOrEqual<T>(_fixture.Create<Expression<Func<T, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("_leftside");
    }

    /// <summary>
    /// Checks that the LessOrEqual method throws when the _rightside parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallLessOrEqualWithNull_rightside()
    {
        FluentActions.Invoking(() => _fixture.Create<Expression<Func<T, bool>>>().LessOrEqual<T>(default(Expression<Func<T, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("_rightside");
    }

    /// <summary>
    /// Checks that the Or method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOr()
    {
        // Arrange
        var _leftside = _fixture.Create<Expression<Func<T, bool>>>();
        var _rightside = _fixture.Create<Expression<Func<T, bool>>>();

        // Act
        var result = _leftside.Or<T>(_rightside
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Or method throws when the _leftside parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOrWithNull_leftside()
    {
        FluentActions.Invoking(() => default(Expression<Func<T, bool>>).Or<T>(_fixture.Create<Expression<Func<T, bool>>>())).Should().Throw<ArgumentNullException>().WithParameterName("_leftside");
    }

    /// <summary>
    /// Checks that the Or method throws when the _rightside parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOrWithNull_rightside()
    {
        FluentActions.Invoking(() => _fixture.Create<Expression<Func<T, bool>>>().Or<T>(default(Expression<Func<T, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("_rightside");
    }

    /// <summary>
    /// Checks that the OrderBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOrderBy()
    {
        // Arrange
        var source = _fixture.Create<IQueryable<TSource>>();
        var keySelector = _fixture.Create<Expression<Func<TSource, TKey>>>();
        var sortOrder = _fixture.Create<SortDirection>();
        var comparer = _fixture.Create<IComparer<TKey>>();

        // Act
        var result = source.OrderBy<TSource, TKey>(keySelector, sortOrder, comparer
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the OrderBy method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOrderByWithNullSource()
    {
        FluentActions.Invoking(() => default(IQueryable<TSource>).OrderBy<TSource, TKey>(_fixture.Create<Expression<Func<TSource, TKey>>>(), _fixture.Create<SortDirection>(), _fixture.Create<IComparer<TKey>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the OrderBy method throws when the keySelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOrderByWithNullKeySelector()
    {
        FluentActions.Invoking(() => _fixture.Create<IQueryable<TSource>>().OrderBy<TSource, TKey>(default(Expression<Func<TSource, TKey>>), _fixture.Create<SortDirection>(), _fixture.Create<IComparer<TKey>>())).Should().Throw<ArgumentNullException>().WithParameterName("keySelector");
    }

    /// <summary>
    /// Checks that the OrderBy method throws when the comparer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallOrderByWithNullComparer()
    {
        FluentActions.Invoking(() => _fixture.Create<IQueryable<TSource>>().OrderBy<TSource, TKey>(_fixture.Create<Expression<Func<TSource, TKey>>>(), _fixture.Create<SortDirection>(), default(IComparer<TKey>))).Should().Throw<ArgumentNullException>().WithParameterName("comparer");
    }

    /// <summary>
    /// Checks that the ThenBy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallThenBy()
    {
        // Arrange
        var source = _fixture.Create<IOrderedQueryable<TSource>>();
        var keySelector = _fixture.Create<Expression<Func<TSource, TKey>>>();
        var sortOrder = _fixture.Create<SortDirection>();
        var comparer = _fixture.Create<IComparer<TKey>>();

        // Act
        var result = source.ThenBy<TSource, TKey>(keySelector, sortOrder, comparer
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ThenBy method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallThenByWithNullSource()
    {
        FluentActions.Invoking(() => default(IOrderedQueryable<TSource>).ThenBy<TSource, TKey>(_fixture.Create<Expression<Func<TSource, TKey>>>(), _fixture.Create<SortDirection>(), _fixture.Create<IComparer<TKey>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the ThenBy method throws when the keySelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallThenByWithNullKeySelector()
    {
        FluentActions.Invoking(() => _fixture.Create<IOrderedQueryable<TSource>>().ThenBy<TSource, TKey>(default(Expression<Func<TSource, TKey>>), _fixture.Create<SortDirection>(), _fixture.Create<IComparer<TKey>>())).Should().Throw<ArgumentNullException>().WithParameterName("keySelector");
    }

    /// <summary>
    /// Checks that the ThenBy method throws when the comparer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallThenByWithNullComparer()
    {
        FluentActions.Invoking(() => _fixture.Create<IOrderedQueryable<TSource>>().ThenBy<TSource, TKey>(_fixture.Create<Expression<Func<TSource, TKey>>>(), _fixture.Create<SortDirection>(), default(IComparer<TKey>))).Should().Throw<ArgumentNullException>().WithParameterName("comparer");
    }

    /// <summary>
    /// Checks that the WhereIn method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWhereInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndIEnumerableOfTValue()
    {
        // Arrange
        var source = _fixture.Create<IQueryable<TItem>>();
        var propertySelector = _fixture.Create<Expression<Func<TItem, TValue>>>();
        var values = _fixture.Create<IEnumerable<TValue>>();

        // Act
        var result = source.WhereIn<TItem, TValue>(propertySelector, values
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the WhereIn method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWhereInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndIEnumerableOfTValueWithNullSource()
    {
        FluentActions.Invoking(() => default(IQueryable<TItem>).WhereIn<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>(), _fixture.Create<IEnumerable<TValue>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the WhereIn method throws when the propertySelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWhereInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndIEnumerableOfTValueWithNullPropertySelector()
    {
        FluentActions.Invoking(() => _fixture.Create<IQueryable<TItem>>().WhereIn<TItem, TValue>(default(Expression<Func<TItem, TValue>>), _fixture.Create<IEnumerable<TValue>>())).Should().Throw<ArgumentNullException>().WithParameterName("propertySelector");
    }

    /// <summary>
    /// Checks that the WhereIn method throws when the values parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWhereInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndIEnumerableOfTValueWithNullValues()
    {
        FluentActions.Invoking(() => _fixture.Create<IQueryable<TItem>>().WhereIn<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>(), default(IEnumerable<TValue>))).Should().Throw<ArgumentNullException>().WithParameterName("values");
    }

    /// <summary>
    /// Checks that the WhereIn method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWhereInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndArrayOfTValue()
    {
        // Arrange
        var source = _fixture.Create<IQueryable<TItem>>();
        var propertySelector = _fixture.Create<Expression<Func<TItem, TValue>>>();
        var values = _fixture.Create<TValue[]>();

        // Act
        var result = source.WhereIn<TItem, TValue>(propertySelector, values
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the WhereIn method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWhereInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndArrayOfTValueWithNullSource()
    {
        FluentActions.Invoking(() => default(IQueryable<TItem>).WhereIn<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>(), _fixture.Create<TValue[]>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the WhereIn method throws when the propertySelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWhereInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndArrayOfTValueWithNullPropertySelector()
    {
        FluentActions.Invoking(() => _fixture.Create<IQueryable<TItem>>().WhereIn<TItem, TValue>(default(Expression<Func<TItem, TValue>>), _fixture.Create<TValue[]>())).Should().Throw<ArgumentNullException>().WithParameterName("propertySelector");
    }

    /// <summary>
    /// Checks that the WhereIn method throws when the values parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWhereInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndArrayOfTValueWithNullValues()
    {
        FluentActions.Invoking(() => _fixture.Create<IQueryable<TItem>>().WhereIn<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>(), default(TValue[]))).Should().Throw<ArgumentNullException>().WithParameterName("values");
    }

    /// <summary>
    /// Checks that the ExceptIn method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExceptInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndIEnumerableOfTValue()
    {
        // Arrange
        var source = _fixture.Create<IQueryable<TItem>>();
        var propertySelector = _fixture.Create<Expression<Func<TItem, TValue>>>();
        var values = _fixture.Create<IEnumerable<TValue>>();

        // Act
        var result = source.ExceptIn<TItem, TValue>(propertySelector, values
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExceptIn method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExceptInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndIEnumerableOfTValueWithNullSource()
    {
        FluentActions.Invoking(() => default(IQueryable<TItem>).ExceptIn<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>(), _fixture.Create<IEnumerable<TValue>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the ExceptIn method throws when the propertySelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExceptInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndIEnumerableOfTValueWithNullPropertySelector()
    {
        FluentActions.Invoking(() => _fixture.Create<IQueryable<TItem>>().ExceptIn<TItem, TValue>(default(Expression<Func<TItem, TValue>>), _fixture.Create<IEnumerable<TValue>>())).Should().Throw<ArgumentNullException>().WithParameterName("propertySelector");
    }

    /// <summary>
    /// Checks that the ExceptIn method throws when the values parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExceptInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndIEnumerableOfTValueWithNullValues()
    {
        FluentActions.Invoking(() => _fixture.Create<IQueryable<TItem>>().ExceptIn<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>(), default(IEnumerable<TValue>))).Should().Throw<ArgumentNullException>().WithParameterName("values");
    }

    /// <summary>
    /// Checks that the ExceptIn method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExceptInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndArrayOfTValue()
    {
        // Arrange
        var source = _fixture.Create<IQueryable<TItem>>();
        var propertySelector = _fixture.Create<Expression<Func<TItem, TValue>>>();
        var values = _fixture.Create<TValue[]>();

        // Act
        var result = source.ExceptIn<TItem, TValue>(propertySelector, values
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExceptIn method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExceptInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndArrayOfTValueWithNullSource()
    {
        FluentActions.Invoking(() => default(IQueryable<TItem>).ExceptIn<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>(), _fixture.Create<TValue[]>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the ExceptIn method throws when the propertySelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExceptInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndArrayOfTValueWithNullPropertySelector()
    {
        FluentActions.Invoking(() => _fixture.Create<IQueryable<TItem>>().ExceptIn<TItem, TValue>(default(Expression<Func<TItem, TValue>>), _fixture.Create<TValue[]>())).Should().Throw<ArgumentNullException>().WithParameterName("propertySelector");
    }

    /// <summary>
    /// Checks that the ExceptIn method throws when the values parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExceptInWithTItemAndTValueAndIQueryableOfTItemAndExpressionOfFuncOfTItemAndTValueAndArrayOfTValueWithNullValues()
    {
        FluentActions.Invoking(() => _fixture.Create<IQueryable<TItem>>().ExceptIn<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>(), default(TValue[]))).Should().Throw<ArgumentNullException>().WithParameterName("values");
    }

    /// <summary>
    /// Checks that the WithComparer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWithComparer()
    {
        // Arrange
        var inner = _fixture.Create<IEnumerable<T>>();
        var comparer = _fixture.Create<IEqualityComparer<TKey>>();

        // Act
        var result = inner.WithComparer<T, TKey>(comparer
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the WithComparer method throws when the inner parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWithComparerWithNullInner()
    {
        FluentActions.Invoking(() => default(IEnumerable<T>).WithComparer<T, TKey>(_fixture.Create<IEqualityComparer<TKey>>())).Should().Throw<ArgumentNullException>().WithParameterName("inner");
    }

    /// <summary>
    /// Checks that the WithComparer method throws when the comparer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWithComparerWithNullComparer()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<T>>().WithComparer<T, TKey>(default(IEqualityComparer<TKey>))).Should().Throw<ArgumentNullException>().WithParameterName("comparer");
    }

    /// <summary>
    /// Checks that the WithComparer maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void WithComparerPerformsMapping()
    {
        // Arrange
        var inner = _fixture.Create<IEnumerable<T>>();
        var comparer = _fixture.Create<IEqualityComparer<TKey>>();

        // Act
        var result = inner.WithComparer<T, TKey>(comparer);

        // Assert
        result.Inner.Should().BeSameAs(inner);
        result.Comparer.Should().BeSameAs(comparer);
    }

    /// <summary>
    /// Checks that the GetWhereInExpression method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWhereInExpression()
    {
        // Arrange
        var propertySelector = _fixture.Create<Expression<Func<TItem, TValue>>>();
        var values = _fixture.Create<IEnumerable<TValue>>();

        // Act
        var result = LinqExtension.GetWhereInExpression<TItem, TValue>(propertySelector, values
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetWhereInExpression method throws when the propertySelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWhereInExpressionWithNullPropertySelector()
    {
        FluentActions.Invoking(() => LinqExtension.GetWhereInExpression<TItem, TValue>(default(Expression<Func<TItem, TValue>>), _fixture.Create<IEnumerable<TValue>>())).Should().Throw<ArgumentNullException>().WithParameterName("propertySelector");
    }

    /// <summary>
    /// Checks that the GetWhereInExpression method throws when the values parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWhereInExpressionWithNullValues()
    {
        FluentActions.Invoking(() => LinqExtension.GetWhereInExpression<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>(), default(IEnumerable<TValue>))).Should().Throw<ArgumentNullException>().WithParameterName("values");
    }

    /// <summary>
    /// Checks that the GetExceptInExpression method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetExceptInExpression()
    {
        // Arrange
        var propertySelector = _fixture.Create<Expression<Func<TItem, TValue>>>();
        var values = _fixture.Create<IEnumerable<TValue>>();

        // Act
        var result = LinqExtension.GetExceptInExpression<TItem, TValue>(propertySelector, values
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetExceptInExpression method throws when the propertySelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetExceptInExpressionWithNullPropertySelector()
    {
        FluentActions.Invoking(() => LinqExtension.GetExceptInExpression<TItem, TValue>(default(Expression<Func<TItem, TValue>>), _fixture.Create<IEnumerable<TValue>>())).Should().Throw<ArgumentNullException>().WithParameterName("propertySelector");
    }

    /// <summary>
    /// Checks that the GetExceptInExpression method throws when the values parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetExceptInExpressionWithNullValues()
    {
        FluentActions.Invoking(() => LinqExtension.GetExceptInExpression<TItem, TValue>(_fixture.Create<Expression<Func<TItem, TValue>>>(), default(IEnumerable<TValue>))).Should().Throw<ArgumentNullException>().WithParameterName("values");
    }

    /// <summary>
    /// Checks that the GetEqualityExpression method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEqualityExpression()
    {
        // Arrange
        var propertySelector = _fixture.Create<Expression<Func<TItem1, TValue>>>();
        Func<TItem0, TValue> valueSelector = x => _fixture.Create<TValue>();
        var origin = _fixture.Create<TItem0>();

        // Act
        var result = LinqExtension.GetEqualityExpression<TItem0, TItem1, TValue>(propertySelector, valueSelector, origin
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEqualityExpression method throws when the propertySelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEqualityExpressionWithNullPropertySelector()
    {
        FluentActions.Invoking(() => LinqExtension.GetEqualityExpression<TItem0, TItem1, TValue>(default(Expression<Func<TItem1, TValue>>), x => _fixture.Create<TValue>(), _fixture.Create<TItem0>())).Should().Throw<ArgumentNullException>().WithParameterName("propertySelector");
    }

    /// <summary>
    /// Checks that the GetEqualityExpression method throws when the valueSelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEqualityExpressionWithNullValueSelector()
    {
        FluentActions.Invoking(() => LinqExtension.GetEqualityExpression<TItem0, TItem1, TValue>(_fixture.Create<Expression<Func<TItem1, TValue>>>(), default(Func<TItem0, TValue>), _fixture.Create<TItem0>())).Should().Throw<ArgumentNullException>().WithParameterName("valueSelector");
    }

    /// <summary>
    /// Checks that the GetMemberName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMemberName()
    {
        // Arrange
        var memberSelector = _fixture.Create<LambdaExpression>();

        // Act
        var result = memberSelector.GetMemberName();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetMemberName method throws when the memberSelector parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetMemberNameWithNullMemberSelector()
    {
        FluentActions.Invoking(() => default(LambdaExpression).GetMemberName()).Should().Throw<ArgumentNullException>().WithParameterName("memberSelector");
    }

    /// <summary>
    /// Checks that the GetPropertyInfo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPropertyInfo()
    {
        // Arrange
        var propertyLambda = _fixture.Create<LambdaExpression>();

        // Act
        var result = propertyLambda.GetPropertyInfo();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetPropertyInfo method throws when the propertyLambda parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetPropertyInfoWithNullPropertyLambda()
    {
        FluentActions.Invoking(() => default(LambdaExpression).GetPropertyInfo()).Should().Throw<ArgumentNullException>().WithParameterName("propertyLambda");
    }
}