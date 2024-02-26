using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Rubrics.Attributes;

namespace Undersoft.SDK.UnitTests.Rubrics.Attributes;

/// <summary>
/// Unit tests for the type <see cref="IdentityRubricAttribute"/>.
/// </summary>
public class IdentityRubricAttributeTests
{
    private IdentityRubricAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="IdentityRubricAttribute"/>.
    /// </summary>
    public IdentityRubricAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<IdentityRubricAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new IdentityRubricAttribute();

        // Assert
        instance.Should().NotBeNull();
    }
}