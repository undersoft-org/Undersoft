using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Cache;
using T = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Cache;

/// <summary>
/// Unit tests for the type <see cref="RootCache"/>.
/// </summary>
public class RootCacheTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Lookup method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallLookupAsync()
    {
        // Arrange
        var keys = _fixture.Create<object>();

        // Act
        var result = await RootCache.Lookup<T>(keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Lookup method throws when the keys parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallLookupWithNullKeysAsync()
    {
        await FluentActions.Invoking(() => RootCache.Lookup<T>(default(object))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the ToCache method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToCacheWithTAndT()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = item.ToCache<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToCache method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToCacheWithTAndTAndArrayOfString()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var names = _fixture.Create<string[]>();

        // Act
        var result = item.ToCache<T>(names);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToCache method throws when the names parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToCacheWithTAndTAndArrayOfStringWithNullNames()
    {
        FluentActions.Invoking(() => _fixture.Create<T>().ToCache<T>(default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("names");
    }

    /// <summary>
    /// Checks that the ToCacheAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallToCacheAsyncWithTAndTAsync()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = await item.ToCacheAsync<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToCacheAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallToCacheAsyncWithTAndTAndArrayOfStringAsync()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var names = _fixture.Create<string[]>();

        // Act
        var result = await item.ToCacheAsync<T>(names);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToCacheAsync method throws when the names parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallToCacheAsyncWithTAndTAndArrayOfStringWithNullNamesAsync()
    {
        await FluentActions.Invoking(() => _fixture.Create<T>().ToCacheAsync<T>(default(string[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("names");
    }

    /// <summary>
    /// Checks that the Catalog property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetCatalog()
    {
        // Assert
        RootCache.Catalog.Should().BeAssignableTo<IDataCache>();

        Assert.Fail("Create or modify test");
    }
}