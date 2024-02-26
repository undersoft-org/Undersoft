using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math.Operation.Binary.Operator;

namespace Undersoft.SDK.UnitTests.Instant.Math.Operation.Binary.Operator;

/// <summary>
/// Unit tests for the type <see cref="BinaryOperator"/>.
/// </summary>
public class BinaryOperatorTests
{
    private class TestBinaryOperator : BinaryOperator
    {
        public override double Apply(double a, double b)
        {
            return default(double);
        }

        public override void Compile(ILGenerator g)
        {
        }
    }

    private TestBinaryOperator _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="BinaryOperator"/>.
    /// </summary>
    public BinaryOperatorTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestBinaryOperator>();
    }
}