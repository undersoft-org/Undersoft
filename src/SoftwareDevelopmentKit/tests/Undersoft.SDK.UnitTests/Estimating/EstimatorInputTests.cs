using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Estimating;
using A = Undersoft.SDK.Estimating.EstimatorSeries;
using B = Undersoft.SDK.Estimating.EstimatorSeries;

namespace Undersoft.SDK.UnitTests.Estimating;

/// <summary>
/// Unit tests for the type <see cref="EstimatorInput"/>.
/// </summary>
public class EstimatorInput_2Tests
{
    private EstimatorInput<A, B> _testClass;
    private IFixture _fixture;
    private A _x;
    private B _y;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EstimatorInput"/>.
    /// </summary>
    public EstimatorInput_2Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._x = _fixture.Create<A>();
        this._y = _fixture.Create<B>();
        this._testClass = _fixture.Create<EstimatorInput<A, B>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EstimatorInput<A, B>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new EstimatorInput<A, B>(this._x, this._y);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the x parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullX()
    {
        FluentActions.Invoking(() => new EstimatorInput<A, B>(default(A), this._y)).Should().Throw<ArgumentNullException>().WithParameterName("x");
    }

    /// <summary>
    /// Checks that instance construction throws when the y parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullY()
    {
        FluentActions.Invoking(() => new EstimatorInput<A, B>(this._x, default(B))).Should().Throw<ArgumentNullException>().WithParameterName("y");
    }
}