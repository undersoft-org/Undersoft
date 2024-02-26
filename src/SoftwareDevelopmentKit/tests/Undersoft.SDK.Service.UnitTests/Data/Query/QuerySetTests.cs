using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Query;

namespace Undersoft.SDK.Service.UnitTests.Data.Query;

/// <summary>
/// Unit tests for the type <see cref="QuerySet"/>.
/// </summary>
public class QuerySetTests
{
    private QuerySet _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="QuerySet"/>.
    /// </summary>
    public QuerySetTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<QuerySet>();
    }

    /// <summary>
    /// Checks that the FilterItems property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFilterItems()
    {
        // Arrange
        var testValue = _fixture.Create<List<FilterItem>>();

        // Act
        this._testClass.FilterItems = testValue;

        // Assert
        this._testClass.FilterItems.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the SortItems property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSortItems()
    {
        // Arrange
        var testValue = _fixture.Create<List<SortItem>>();

        // Act
        this._testClass.SortItems = testValue;

        // Assert
        this._testClass.SortItems.Should().BeSameAs(testValue);
    }
}