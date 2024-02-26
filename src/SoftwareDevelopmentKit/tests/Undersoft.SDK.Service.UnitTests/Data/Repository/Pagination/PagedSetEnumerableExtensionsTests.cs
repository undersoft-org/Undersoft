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
/// Unit tests for the type <see cref="PagedSetEnumerableExtensions"/>.
/// </summary>
public class PagedSetEnumerableExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ToPagedSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToPagedSetWithSourceAndPageIndexAndPageSizeAndIndexFrom()
    {
        // Arrange
        var source = _fixture.Create<IEnumerable<T>>();
        var pageIndex = _fixture.Create<int>();
        var pageSize = _fixture.Create<int>();
        var indexFrom = _fixture.Create<int>();

        // Act
        var result = source.ToPagedSet<T>(pageIndex, pageSize, indexFrom);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToPagedSet method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToPagedSetWithSourceAndPageIndexAndPageSizeAndIndexFromWithNullSource()
    {
        FluentActions.Invoking(() => default(IEnumerable<T>).ToPagedSet<T>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the ToPagedSet maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void ToPagedSetWithSourceAndPageIndexAndPageSizeAndIndexFromPerformsMapping()
    {
        // Arrange
        var source = _fixture.Create<IEnumerable<T>>();
        var pageIndex = _fixture.Create<int>();
        var pageSize = _fixture.Create<int>();
        var indexFrom = _fixture.Create<int>();

        // Act
        var result = source.ToPagedSet<T>(pageIndex, pageSize, indexFrom);

        // Assert
        result.PageIndex.Should().Be(pageIndex);
        result.PageSize.Should().Be(pageSize);
        result.IndexFrom.Should().Be(indexFrom);
    }

    /// <summary>
    /// Checks that the ToPagedSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToPagedSetWithSourceAndConverterAndPageIndexAndPageSizeAndIndexFrom()
    {
        // Arrange
        var source = _fixture.Create<IEnumerable<TSource>>();
        Func<IEnumerable<TSource>, IEnumerable<TResult>> converter = x => _fixture.Create<IEnumerable<TResult>>();
        var pageIndex = _fixture.Create<int>();
        var pageSize = _fixture.Create<int>();
        var indexFrom = _fixture.Create<int>();

        // Act
        var result = source.ToPagedSet<TSource, TResult>(converter, pageIndex, pageSize, indexFrom);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToPagedSet method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToPagedSetWithSourceAndConverterAndPageIndexAndPageSizeAndIndexFromWithNullSource()
    {
        FluentActions.Invoking(() => default(IEnumerable<TSource>).ToPagedSet<TSource, TResult>(x => _fixture.Create<IEnumerable<TResult>>(), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the ToPagedSet method throws when the converter parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToPagedSetWithSourceAndConverterAndPageIndexAndPageSizeAndIndexFromWithNullConverter()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TSource>>().ToPagedSet<TSource, TResult>(default(Func<IEnumerable<TSource>, IEnumerable<TResult>>), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("converter");
    }

    /// <summary>
    /// Checks that the ToPagedSet maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void ToPagedSetWithSourceAndConverterAndPageIndexAndPageSizeAndIndexFromPerformsMapping()
    {
        // Arrange
        var source = _fixture.Create<IEnumerable<TSource>>();
        Func<IEnumerable<TSource>, IEnumerable<TResult>> converter = x => _fixture.Create<IEnumerable<TResult>>();
        var pageIndex = _fixture.Create<int>();
        var pageSize = _fixture.Create<int>();
        var indexFrom = _fixture.Create<int>();

        // Act
        var result = source.ToPagedSet<TSource, TResult>(converter, pageIndex, pageSize, indexFrom);

        // Assert
        result.PageIndex.Should().Be(pageIndex);
        result.PageSize.Should().Be(pageSize);
        result.IndexFrom.Should().Be(indexFrom);
    }
}