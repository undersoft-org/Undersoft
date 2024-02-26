using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math.Set;

namespace Undersoft.SDK.UnitTests.Instant.Math.Set;

/// <summary>
/// Unit tests for the type <see cref="MathSetSize"/>.
/// </summary>
public class MathSetSizeTests
{
    private MathSetSize _testClass;
    private IFixture _fixture;
    private int _i;
    private int _j;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MathSetSize"/>.
    /// </summary>
    public MathSetSizeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._i = _fixture.Create<int>();
        this._j = _fixture.Create<int>();
        this._testClass = _fixture.Create<MathSetSize>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new MathSetSize(this._i, this._j);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var o = _fixture.Create<object>();

        // Act
        var result = this._testClass.Equals(o);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the o parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullO()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("o");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCode()
    {
        // Act
        var result = this._testClass.GetHashCode();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToString()
    {
        // Act
        var result = this._testClass.ToString();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Inequality operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInequalityOperator()
    {
        // Arrange
        var o1 = _fixture.Create<MathSetSize>();
        var o2 = _fixture.Create<MathSetSize>();

        // Act
        var result = o1 != o2;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Inequality operator handles null values for the o1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallInequalityOperatorWithNullO1()
    {
        FluentActions.Invoking(() => { var result = default(MathSetSize) != _fixture.Create<MathSetSize>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Inequality operator handles null values for the o2 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallInequalityOperatorWithNullO2()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<MathSetSize>() != default(MathSetSize); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Equality operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualityOperator()
    {
        // Arrange
        var o1 = _fixture.Create<MathSetSize>();
        var o2 = _fixture.Create<MathSetSize>();

        // Act
        var result = o1 == o2;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equality operator handles null values for the o1 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualityOperatorWithNullO1()
    {
        FluentActions.Invoking(() => { var result = default(MathSetSize) == _fixture.Create<MathSetSize>(); }).Should().Throw<ArgumentNullException>();
    }

    /// <summary>
    /// Checks that the Equality operator handles null values for the o2 parameter.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualityOperatorWithNullO2()
    {
        FluentActions.Invoking(() => { var result = _fixture.Create<MathSetSize>() == default(MathSetSize); }).Should().Throw<ArgumentNullException>();
    }
}