using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Query;

namespace Undersoft.SDK.Service.UnitTests.Data.Query;

/// <summary>
/// Unit tests for the type <see cref="FilterOperand"/>.
/// </summary>
public class FilterOperandTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ParseMathOperand method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallParseMathOperand()
    {
        // Arrange
        var operandString = _fixture.Create<string>();

        // Act
        var result = FilterOperand.ParseMathOperand(operandString);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ParseMathOperand method throws when the operandString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallParseMathOperandWithInvalidOperandString(string value)
    {
        FluentActions.Invoking(() => FilterOperand.ParseMathOperand(value)).Should().Throw<ArgumentNullException>().WithParameterName("operandString");
    }

    /// <summary>
    /// Checks that the ConvertMathOperand method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConvertMathOperand()
    {
        // Arrange
        var operand = _fixture.Create<MathOperand>();

        // Act
        var result = FilterOperand.ConvertMathOperand(operand);

        // Assert
        Assert.Fail("Create or modify test");
    }
}