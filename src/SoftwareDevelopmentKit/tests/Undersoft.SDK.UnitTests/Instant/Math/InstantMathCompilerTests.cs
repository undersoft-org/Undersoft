using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math;
using Undersoft.SDK.Instant.Math.Formulas;

namespace Undersoft.SDK.UnitTests.Instant.Math;

/// <summary>
/// Unit tests for the type <see cref="InstantMathCompiler"/>.
/// </summary>
public class InstantMathCompilerTests
{
    private InstantMathCompiler _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantMathCompiler"/>.
    /// </summary>
    public InstantMathCompilerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<InstantMathCompiler>();
    }

    /// <summary>
    /// Checks that the Compile method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompile()
    {
        // Arrange
        var formula = _fixture.Create<Formula>();

        // Act
        var result = InstantMathCompiler.Compile(formula);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compile method throws when the formula parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileWithNullFormula()
    {
        FluentActions.Invoking(() => InstantMathCompiler.Compile(default(Formula))).Should().Throw<ArgumentNullException>().WithParameterName("formula");
    }

    /// <summary>
    /// Checks that the CollectMode property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCollectMode()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        InstantMathCompiler.CollectMode = testValue;

        // Assert
        InstantMathCompiler.CollectMode.Should().Be(testValue);
    }
}