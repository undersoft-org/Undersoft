using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Repository.Pagination;
using T = System.String;
using TResult = System.String;
using TSource = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository.Pagination;

/// <summary>
/// Unit tests for the type <see cref="PagedSet"/>.
/// </summary>
public class PagedSet_1Tests
{
    private PagedSet<T> _testClass;
    private IFixture _fixture;
    private IEnumerable<T> _sourceIEnumerableT;
    private int _pageIndex;
    private int _pageSize;
    private int _indexFrom;
    private IList<T> _sourceIListT;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="PagedSet"/>.
    /// </summary>
    public PagedSet_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._sourceIEnumerableT = _fixture.Create<IEnumerable<T>>();
        this._pageIndex = _fixture.Create<int>();
        this._pageSize = _fixture.Create<int>();
        this._indexFrom = _fixture.Create<int>();
        this._sourceIListT = _fixture.Create<IList<T>>();
        this._testClass = _fixture.Create<PagedSet<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new PagedSet<T>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new PagedSet<T>(this._sourceIEnumerableT, this._pageIndex, this._pageSize, this._indexFrom);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new PagedSet<T>(this._sourceIListT, this._pageIndex, this._pageSize, this._indexFrom);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSource()
    {
        FluentActions.Invoking(() => new PagedSet<T>(default(IEnumerable<T>), this._pageIndex, this._pageSize, this._indexFrom)).Should().Throw<ArgumentNullException>().WithParameterName("source");
        FluentActions.Invoking(() => new PagedSet<T>(default(IList<T>), this._pageIndex, this._pageSize, this._indexFrom)).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the HasNextPage property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetHasNextPage()
    {
        // Assert
        this._testClass.HasNextPage.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the HasPreviousPage property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetHasPreviousPage()
    {
        // Assert
        this._testClass.HasPreviousPage.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexFrom property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexFrom()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.IndexFrom = testValue;

        // Assert
        this._testClass.IndexFrom.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Items property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetItems()
    {
        // Arrange
        var testValue = _fixture.Create<IList<T>>();

        // Act
        this._testClass.Items = testValue;

        // Assert
        this._testClass.Items.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the PageIndex property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPageIndex()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.PageIndex = testValue;

        // Assert
        this._testClass.PageIndex.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the PageSize property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPageSize()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.PageSize = testValue;

        // Assert
        this._testClass.PageSize.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the TotalCount property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTotalCount()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.TotalCount = testValue;

        // Assert
        this._testClass.TotalCount.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the TotalPages property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTotalPages()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.TotalPages = testValue;

        // Assert
        this._testClass.TotalPages.Should().Be(testValue);
    }
}

/// <summary>
/// Unit tests for the type <see cref="PagedSet"/>.
/// </summary>
public class PagedSetTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Empty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmpty()
    {
        // Act
        var result = PagedSet.Empty<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the From method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFrom()
    {
        // Arrange
        var source = _fixture.Create<IPagedSet<TSource>>();
        Func<IEnumerable<TSource>, IEnumerable<TResult>> converter = x => _fixture.Create<IEnumerable<TResult>>();

        // Act
        var result = PagedSet.From<TResult, TSource>(source, converter);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the From method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromWithNullSource()
    {
        FluentActions.Invoking(() => PagedSet.From<TResult, TSource>(default(IPagedSet<TSource>), x => _fixture.Create<IEnumerable<TResult>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the From method throws when the converter parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromWithNullConverter()
    {
        FluentActions.Invoking(() => PagedSet.From<TResult, TSource>(_fixture.Create<IPagedSet<TSource>>(), default(Func<IEnumerable<TSource>, IEnumerable<TResult>>))).Should().Throw<ArgumentNullException>().WithParameterName("converter");
    }

    /// <summary>
    /// Checks that the From maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void FromPerformsMapping()
    {
        // Arrange
        var source = _fixture.Create<IPagedSet<TSource>>();
        Func<IEnumerable<TSource>, IEnumerable<TResult>> converter = x => _fixture.Create<IEnumerable<TResult>>();

        // Act
        var result = PagedSet.From<TResult, TSource>(source, converter);

        // Assert
        result.HasNextPage.Should().Be(source.HasNextPage);
        result.HasPreviousPage.Should().Be(source.HasPreviousPage);
        result.IndexFrom.Should().Be(source.IndexFrom);
        result.Items.Should().BeSameAs(source.Items);
        result.PageIndex.Should().Be(source.PageIndex);
        result.PageSize.Should().Be(source.PageSize);
        result.TotalCount.Should().Be(source.TotalCount);
        result.TotalPages.Should().Be(source.TotalPages);
    }
}