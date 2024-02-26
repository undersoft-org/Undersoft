using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Rubrics.Attributes;

namespace Undersoft.SDK.UnitTests.Rubrics.Attributes;

/// <summary>
/// Unit tests for the type <see cref="DisplayRubricAttribute"/>.
/// </summary>
public class DisplayRubricAttributeTests
{
    private DisplayRubricAttribute _testClass;
    private IFixture _fixture;
    private string _name;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DisplayRubricAttribute"/>.
    /// </summary>
    public DisplayRubricAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._name = _fixture.Create<string>();
        this._testClass = _fixture.Create<DisplayRubricAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DisplayRubricAttribute(this._name);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidName(string value)
    {
        FluentActions.Invoking(() => new DisplayRubricAttribute(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }
}