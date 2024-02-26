using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Repository.Pagination;
using T = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository.Pagination;

/// <summary>
/// Unit tests for the type <see cref="PagedSetQueryableExtensions"/>.
/// </summary>
public class PagedSetQueryableExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ToPagedSetAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallToPagedSetAsync()
    {
        // Arrange
        var source = _fixture.Create<IQueryable<T>>();
        var pageIndex = _fixture.Create<int>();
        var pageSize = _fixture.Create<int>();
        var indexFrom = _fixture.Create<int>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await source.ToPagedSetAsync<T>(pageIndex, pageSize, indexFrom, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToPagedSetAsync method throws when the source parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallToPagedSetAsyncWithNullSourceAsync()
    {
        await FluentActions.Invoking(() => default(IQueryable<T>).ToPagedSetAsync<T>(_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the ToPagedSetAsync maps values from the input to the returned instance.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task ToPagedSetAsyncPerformsMappingAsync()
    {
        // Arrange
        var source = _fixture.Create<IQueryable<T>>();
        var pageIndex = _fixture.Create<int>();
        var pageSize = _fixture.Create<int>();
        var indexFrom = _fixture.Create<int>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = await source.ToPagedSetAsync<T>(pageIndex, pageSize, indexFrom, cancellationToken);

        // Assert
        result.PageIndex.Should().Be(pageIndex);
        result.PageSize.Should().Be(pageSize);
        result.IndexFrom.Should().Be(indexFrom);
    }
}