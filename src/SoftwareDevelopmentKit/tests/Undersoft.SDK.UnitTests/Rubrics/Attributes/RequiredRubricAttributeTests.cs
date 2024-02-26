using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Rubrics.Attributes;

namespace Undersoft.SDK.UnitTests.Rubrics.Attributes;

/// <summary>
/// Unit tests for the type <see cref="RequiredRubricAttribute"/>.
/// </summary>
public class RequiredRubricAttributeTests
{
    private RequiredRubricAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RequiredRubricAttribute"/>.
    /// </summary>
    public RequiredRubricAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RequiredRubricAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RequiredRubricAttribute();

        // Assert
        instance.Should().NotBeNull();
    }
}

/// <summary>
/// Unit tests for the type <see cref="VisibleRubricAttribute"/>.
/// </summary>
public class VisibleRubricAttributeTests
{
    private VisibleRubricAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="VisibleRubricAttribute"/>.
    /// </summary>
    public VisibleRubricAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<VisibleRubricAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new VisibleRubricAttribute();

        // Assert
        instance.Should().NotBeNull();
    }
}