using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math.Set;
using Undersoft.SDK.Instant.Series;

namespace Undersoft.SDK.UnitTests.Instant.Math.Set;

/// <summary>
/// Unit tests for the type <see cref="MathSetComputer"/>.
/// </summary>
public class MathSetComputerTests
{
    private class TestMathSetComputer : MathSetComputer
    {
        public override void Compute()
        {
        }
    }

    private TestMathSetComputer _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MathSetComputer"/>.
    /// </summary>
    public MathSetComputerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestMathSetComputer>();
    }

    /// <summary>
    /// Checks that the GetColumnCount method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetColumnCount()
    {
        // Arrange
        var paramid = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetColumnCount(paramid);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIndexOf()
    {
        // Arrange
        var v = _fixture.Create<IInstantSeries>();

        // Act
        var result = this._testClass.GetIndexOf(v);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIndexOf method throws when the v parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetIndexOfWithNullV()
    {
        FluentActions.Invoking(() => this._testClass.GetIndexOf(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("v");
    }

    /// <summary>
    /// Checks that the GetRowCount method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRowCount()
    {
        // Arrange
        var paramid = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetRowCount(paramid);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRowOffset method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRowOffset()
    {
        // Act
        var result = this._testClass.GetRowOffset();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPut()
    {
        // Arrange
        var v = _fixture.Create<IInstantSeries>();

        // Act
        var result = this._testClass.Put(v);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the v parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithNullV()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("v");
    }

    /// <summary>
    /// Checks that the SetParams method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetParamsWithPAndOffsetAndChunk()
    {
        // Arrange
        var p = _fixture.Create<IInstantSeries>();
        var offset = _fixture.Create<int>();
        var chunk = _fixture.Create<int>();

        // Act
        this._testClass.SetParams(p, offset, chunk);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetParams method throws when the p parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetParamsWithPAndOffsetAndChunkWithNullP()
    {
        FluentActions.Invoking(() => this._testClass.SetParams(default(IInstantSeries), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("p");
    }

    /// <summary>
    /// Checks that the SetParams method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetParamsWithPAndIndexAndOffsetAndChunk()
    {
        // Arrange
        var p = _fixture.Create<IInstantSeries>();
        var index = _fixture.Create<int>();
        var offset = _fixture.Create<int>();
        var chunk = _fixture.Create<int>();

        // Act
        this._testClass.SetParams(p, index, offset, chunk);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetParams method throws when the p parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetParamsWithPAndIndexAndOffsetAndChunkWithNullP()
    {
        FluentActions.Invoking(() => this._testClass.SetParams(default(IInstantSeries), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("p");
    }

    /// <summary>
    /// Checks that the SetParams method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetParamsWithPAndParamCount()
    {
        // Arrange
        var p = _fixture.Create<IInstantSeries[]>();
        var paramCount = _fixture.Create<int>();

        // Act
        this._testClass.SetParams(p, paramCount);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetParams method throws when the p parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetParamsWithPAndParamCountWithNullP()
    {
        FluentActions.Invoking(() => this._testClass.SetParams(default(IInstantSeries[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("p");
    }
}