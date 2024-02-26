using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math.Formulas;
using Undersoft.SDK.Instant.Math.Operation.Binary.Formulas;

namespace Undersoft.SDK.UnitTests.Instant.Math.Operation.Binary.Formulas;

/// <summary>
/// Unit tests for the type <see cref="BinaryFormula"/>.
/// </summary>
public class BinaryFormulaTests
{
    private class TestBinaryFormula : BinaryFormula
    {
        public TestBinaryFormula(Formula e1, Formula e2) : base(e1, e2)
        {
        }

        public override void Compile(ILGenerator g, InstantMathCompilerContext cc)
        {
        }
    }

    private TestBinaryFormula _testClass;
    private IFixture _fixture;
    private Formula _e1;
    private Formula _e2;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BinaryFormula"/>.
    /// </summary>
    public BinaryFormulaTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._e1 = _fixture.Create<Formula>();
        this._e2 = _fixture.Create<Formula>();
        this._testClass = _fixture.Create<TestBinaryFormula>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestBinaryFormula(this._e1, this._e2);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the e1 parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullE1()
    {
        FluentActions.Invoking(() => new TestBinaryFormula(default(Formula), this._e2)).Should().Throw<ArgumentNullException>().WithParameterName("e1");
    }

    /// <summary>
    /// Checks that instance construction throws when the e2 parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullE2()
    {
        FluentActions.Invoking(() => new TestBinaryFormula(this._e1, default(Formula))).Should().Throw<ArgumentNullException>().WithParameterName("e2");
    }
}