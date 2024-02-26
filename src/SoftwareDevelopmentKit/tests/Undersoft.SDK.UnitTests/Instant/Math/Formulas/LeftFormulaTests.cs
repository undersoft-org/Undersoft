using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math.Formulas;

namespace Undersoft.SDK.UnitTests.Instant.Math.Formulas;

/// <summary>
/// Unit tests for the type <see cref="LeftFormula"/>.
/// </summary>
public class LeftFormulaTests
{
    private class TestLeftFormula : LeftFormula
    {
        public override void Compile(ILGenerator g, InstantMathCompilerContext cc)
        {
        }

        public override void CompileAssign(ILGenerator g, InstantMathCompilerContext cc, bool post, bool @partial)
        {
        }
    }

    private TestLeftFormula _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="LeftFormula"/>.
    /// </summary>
    public LeftFormulaTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestLeftFormula>();
    }
}