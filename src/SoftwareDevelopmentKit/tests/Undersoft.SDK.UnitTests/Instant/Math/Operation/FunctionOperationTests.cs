using System;
using System.Reflection.Emit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math;
using Undersoft.SDK.Instant.Math.Formulas;
using Undersoft.SDK.Instant.Math.Operation;
using Undersoft.SDK.Instant.Math.Set;

namespace Undersoft.SDK.UnitTests.Instant.Math.Operation;

/// <summary>
/// Unit tests for the type <see cref="FunctionOperation"/>.
/// </summary>
public class FunctionOperationTests
{
    private FunctionOperation _testClass;
    private IFixture _fixture;
    private Formula _ee;
    private FunctionOperation.FunctionType _fx;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="FunctionOperation"/>.
    /// </summary>
    public FunctionOperationTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._ee = _fixture.Create<Formula>();
        this._fx = _fixture.Create<FunctionOperation.FunctionType>();
        this._testClass = _fixture.Create<FunctionOperation>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new FunctionOperation(this._ee, this._fx);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the ee parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEe()
    {
        FluentActions.Invoking(() => new FunctionOperation(default(Formula), this._fx)).Should().Throw<ArgumentNullException>().WithParameterName("ee");
    }

    /// <summary>
    /// Checks that the Compile method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompile()
    {
        // Arrange
        var g = _fixture.Create<ILGenerator>();
        var cc = _fixture.Create<InstantMathCompilerContext>();

        // Act
        this._testClass.Compile(g, cc);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compile method throws when the g parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileWithNullG()
    {
        FluentActions.Invoking(() => this._testClass.Compile(default(ILGenerator), _fixture.Create<InstantMathCompilerContext>())).Should().Throw<ArgumentNullException>().WithParameterName("g");
    }

    /// <summary>
    /// Checks that the Compile method throws when the cc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileWithNullCc()
    {
        FluentActions.Invoking(() => this._testClass.Compile(_fixture.Create<ILGenerator>(), default(InstantMathCompilerContext))).Should().Throw<ArgumentNullException>().WithParameterName("cc");
    }

    /// <summary>
    /// Checks that the Size property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSize()
    {
        // Assert
        this._testClass.Size.Should().BeAssignableTo<MathSetSize>();

        Assert.Fail("Create or modify test");
    }
}