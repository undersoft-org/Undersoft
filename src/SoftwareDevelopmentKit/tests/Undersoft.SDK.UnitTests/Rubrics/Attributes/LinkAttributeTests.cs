using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Rubrics.Attributes;

namespace Undersoft.SDK.UnitTests.Rubrics.Attributes;

/// <summary>
/// Unit tests for the type <see cref="LinkAttribute"/>.
/// </summary>
public class LinkAttributeTests
{
    private LinkAttribute _testClass;
    private IFixture _fixture;
    private string _link;
    private OperationType _operation;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="LinkAttribute"/>.
    /// </summary>
    public LinkAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._link = _fixture.Create<string>();
        this._operation = _fixture.Create<OperationType>();
        this._testClass = _fixture.Create<LinkAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new LinkAttribute();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new LinkAttribute(this._link);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new LinkAttribute(this._operation, this._link);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the link parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidLink(string value)
    {
        FluentActions.Invoking(() => new LinkAttribute(value)).Should().Throw<ArgumentNullException>().WithParameterName("link");
        FluentActions.Invoking(() => new LinkAttribute(this._operation, value)).Should().Throw<ArgumentNullException>().WithParameterName("link");
    }
}