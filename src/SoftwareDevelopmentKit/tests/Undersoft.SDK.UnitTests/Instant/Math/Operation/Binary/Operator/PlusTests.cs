using System;
using System.Reflection.Emit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math.Operation.Binary.Operator;

namespace Undersoft.SDK.UnitTests.Instant.Math.Operation.Binary.Operator;

/// <summary>
/// Unit tests for the type <see cref="Plus"/>.
/// </summary>
public class PlusTests
{
    private Plus _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Plus"/>.
    /// </summary>
    public PlusTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Plus>();
    }

    /// <summary>
    /// Checks that the Apply method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallApply()
    {
        // Arrange
        var a = _fixture.Create<double>();
        var b = _fixture.Create<double>();

        // Act
        var result = this._testClass.Apply(a, b);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compile method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompile()
    {
        // Arrange
        var g = _fixture.Create<ILGenerator>();

        // Act
        this._testClass.Compile(g);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compile method throws when the g parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileWithNullG()
    {
        FluentActions.Invoking(() => this._testClass.Compile(default(ILGenerator))).Should().Throw<ArgumentNullException>().WithParameterName("g");
    }
}