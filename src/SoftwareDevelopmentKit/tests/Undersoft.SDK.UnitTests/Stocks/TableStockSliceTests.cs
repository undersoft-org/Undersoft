using System;
using System.Collections;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Stocks;

namespace Undersoft.SDK.UnitTests.Stocks;

/// <summary>
/// Unit tests for the type <see cref="TableStockSlice"/>.
/// </summary>
public class TableStockSliceTests
{
    private TableStockSlice _testClass;
    private IFixture _fixture;
    private Mock<IList> _list;
    private int _offset;
    private int _count;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TableStockSlice"/>.
    /// </summary>
    public TableStockSliceTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._list = _fixture.Freeze<Mock<IList>>();
        this._offset = _fixture.Create<int>();
        this._count = _fixture.Create<int>();
        this._testClass = _fixture.Create<TableStockSlice>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TableStockSlice(this._list.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TableStockSlice(this._list.Object, this._offset, this._count);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the list parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullList()
    {
        FluentActions.Invoking(() => new TableStockSlice(default(IList))).Should().Throw<ArgumentNullException>().WithParameterName("list");
        FluentActions.Invoking(() => new TableStockSlice(default(IList), this._offset, this._count)).Should().Throw<ArgumentNullException>().WithParameterName("list");
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
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithObject()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = this._testClass.Equals(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithObjectWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithTableStockSlice()
    {
        // Arrange
        var obj = _fixture.Create<TableStockSlice>();

        // Act
        var result = this._testClass.Equals(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIndexOf()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = this._testClass.IndexOf(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIndexOfWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.IndexOf(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAdd()
    {
        // Arrange
        var value = _fixture.Create<object>();

        // Act
        var result = ((IList)this._testClass).Add(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithNullValue()
    {
        FluentActions.Invoking(() => ((IList)this._testClass).Add(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemove()
    {
        // Arrange
        var value = _fixture.Create<object>();

        // Act
        ((IList)this._testClass).Remove(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveWithNullValue()
    {
        FluentActions.Invoking(() => ((IList)this._testClass).Remove(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Insert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsert()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var item = _fixture.Create<object>();

        // Act
        ((IList)this._testClass).Insert(index, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Insert method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInsertWithNullItem()
    {
        FluentActions.Invoking(() => ((IList)this._testClass).Insert(_fixture.Create<int>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the RemoveAt method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveAt()
    {
        // Arrange
        var index = _fixture.Create<int>();

        // Act
        ((IList)this._testClass).RemoveAt(index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContains()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = ((IList)this._testClass).Contains(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsWithNullItem()
    {
        FluentActions.Invoking(() => ((IList)this._testClass).Contains(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Clear method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClear()
    {
        // Act
        ((IList)this._testClass).Clear();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyTo()
    {
        // Arrange
        var array = _fixture.Create<Array>();
        var index = _fixture.Create<int>();

        // Act
        ((ICollection)this._testClass).CopyTo(array, index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyToWithNullArray()
    {
        FluentActions.Invoking(() => ((ICollection)this._testClass).CopyTo(default(Array), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the GetEnumerator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEnumerator()
    {
        // Act
        var result = ((IEnumerable)this._testClass).GetEnumerator();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equality operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualityOperator()
    {
        // Arrange
        var a = _fixture.Create<TableStockSlice>();
        var b = _fixture.Create<TableStockSlice>();

        // Act
        var result = a == b;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Inequality operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInequalityOperator()
    {
        // Arrange
        var a = _fixture.Create<TableStockSlice>();
        var b = _fixture.Create<TableStockSlice>();

        // Act
        var result = a != b;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexer()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>()].Should().BeSameAs(testValue);
    }
}