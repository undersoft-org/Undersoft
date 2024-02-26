using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Rubrics.Attributes;

namespace Undersoft.SDK.UnitTests.Rubrics.Attributes;

/// <summary>
/// Unit tests for the type <see cref="RubricAggregateAttribute"/>.
/// </summary>
public class RubricAggregateAttributeTests
{
    private RubricAggregateAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RubricAggregateAttribute"/>.
    /// </summary>
    public RubricAggregateAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RubricAggregateAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RubricAggregateAttribute();

        // Assert
        instance.Should().NotBeNull();
    }
}