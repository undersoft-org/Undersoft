using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Estimating;

namespace Undersoft.SDK.UnitTests.Estimating;

/// <summary>
/// Unit tests for the type <see cref="EstimatorInstances"/>.
/// </summary>
public class EstimatorInstancesTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNew()
    {
        // Arrange
        var strFullyQualifiedName = _fixture.Create<string>();

        // Act
        var result = EstimatorInstances.New(strFullyQualifiedName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method throws when the strFullyQualifiedName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallNewWithInvalidStrFullyQualifiedName(string value)
    {
        FluentActions.Invoking(() => EstimatorInstances.New(value)).Should().Throw<ArgumentNullException>().WithParameterName("strFullyQualifiedName");
    }
}