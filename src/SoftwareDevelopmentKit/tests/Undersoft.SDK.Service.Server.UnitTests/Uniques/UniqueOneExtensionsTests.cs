using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Uniques;
using T = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="UniqueOneExtensions"/>.
/// </summary>
[TestClass]
public class UniqueOneExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the AsUniqueOne method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAsUniqueOneWithIQueryableOfT()
    {
        // Arrange
        var entity = _fixture.Create<IQueryable<T>>();

        // Act
        var result = entity.AsUniqueOne<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AsUniqueOne method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAsUniqueOneWithIQueryableOfTWithNullEntity()
    {
        FluentActions.Invoking(() => default(IQueryable<T>).AsUniqueOne<T>()).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the AsUniqueOne method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAsUniqueOneWithIEnumerableOfT()
    {
        // Arrange
        var entity = _fixture.Create<IEnumerable<T>>();

        // Act
        var result = entity.AsUniqueOne<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AsUniqueOne method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAsUniqueOneWithIEnumerableOfTWithNullEntity()
    {
        FluentActions.Invoking(() => default(IEnumerable<T>).AsUniqueOne<T>()).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the AsUniqueOne method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAsUniqueOneWithT()
    {
        // Arrange
        var entity = _fixture.Create<T>();

        // Act
        var result = entity.AsUniqueOne<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }
}