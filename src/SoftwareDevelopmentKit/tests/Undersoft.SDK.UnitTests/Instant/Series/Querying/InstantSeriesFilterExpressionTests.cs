using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Instant.Series.Querying;

namespace Undersoft.SDK.UnitTests.Instant.Series.Querying;

/// <summary>
/// Unit tests for the type <see cref="InstantSeriesFilterExpression"/>.
/// </summary>
public class InstantSeriesFilterExpressionTests
{
    private InstantSeriesFilterExpression _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSeriesFilterExpression"/>.
    /// </summary>
    public InstantSeriesFilterExpressionTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<InstantSeriesFilterExpression>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSeriesFilterExpression();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the CreateExpression method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateExpression()
    {
        // Arrange
        var stage = _fixture.Create<int>();

        // Act
        var result = this._testClass.CreateExpression(stage);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Query property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetQuery()
    {
        // Assert
        this._testClass.Query.Should().BeAssignableTo<Expression<Func<IInstant, bool>>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Stage property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetStage()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.Stage = testValue;

        // Assert
        this._testClass.Stage.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexer()
    {
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<Expression<Func<IInstant, bool>>>();
        Assert.Fail("Create or modify test");
    }
}