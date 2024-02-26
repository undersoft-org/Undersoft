using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Rubrics.Attributes;

namespace Undersoft.SDK.UnitTests.Rubrics.Attributes;

/// <summary>
/// Unit tests for the type <see cref="RubricSizeAttribute"/>.
/// </summary>
public class RubricSizeAttributeTests
{
    private RubricSizeAttribute _testClass;
    private IFixture _fixture;
    private int _size;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RubricSizeAttribute"/>.
    /// </summary>
    public RubricSizeAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._size = _fixture.Create<int>();
        this._testClass = _fixture.Create<RubricSizeAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RubricSizeAttribute(this._size);

        // Assert
        instance.Should().NotBeNull();
    }
}