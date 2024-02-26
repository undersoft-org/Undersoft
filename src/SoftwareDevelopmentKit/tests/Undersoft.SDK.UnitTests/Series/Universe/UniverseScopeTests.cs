using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Series;
using Undersoft.SDK.Series.Universe;
using Undersoft.SDK.Series.Universe.Base;
using Undersoft.SDK.Series.Universe.vanEmdeBoasTree;

namespace Undersoft.SDK.UnitTests.Series.Universe;

/// <summary>
/// Unit tests for the type <see cref="UniverseScope"/>.
/// </summary>
public class UniverseScopeTests
{
    private UniverseScope _testClass;
    private IFixture _fixture;
    private int _size;
    private Mock<ISeries<Universe>> _scopes;
    private Mock<ISeries<Universe>> _sigmaScopes;
    private IList<vEBTreeLevel> _levels;
    private byte _level;
    private byte _nodeIndex;
    private int _deckIndex;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="UniverseScope"/>.
    /// </summary>
    public UniverseScopeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._size = _fixture.Create<int>();
        this._scopes = _fixture.Freeze<Mock<ISeries<Universe>>>();
        this._sigmaScopes = _fixture.Freeze<Mock<ISeries<Universe>>>();
        this._levels = _fixture.Create<IList<vEBTreeLevel>>();
        this._level = _fixture.Create<byte>();
        this._nodeIndex = _fixture.Create<byte>();
        this._deckIndex = _fixture.Create<int>();
        this._testClass = _fixture.Create<UniverseScope>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new UniverseScope(this._size, this._scopes.Object, this._sigmaScopes.Object, this._levels, this._level, this._nodeIndex, this._deckIndex);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the Scopes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullScopes()
    {
        FluentActions.Invoking(() => new UniverseScope(this._size, default(ISeries<Universe>), this._sigmaScopes.Object, this._levels, this._level, this._nodeIndex, this._deckIndex)).Should().Throw<ArgumentNullException>().WithParameterName("Scopes");
    }

    /// <summary>
    /// Checks that instance construction throws when the SigmaScopes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSigmaScopes()
    {
        FluentActions.Invoking(() => new UniverseScope(this._size, this._scopes.Object, default(ISeries<Universe>), this._levels, this._level, this._nodeIndex, this._deckIndex)).Should().Throw<ArgumentNullException>().WithParameterName("SigmaScopes");
    }

    /// <summary>
    /// Checks that instance construction throws when the Levels parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullLevels()
    {
        FluentActions.Invoking(() => new UniverseScope(this._size, this._scopes.Object, this._sigmaScopes.Object, default(IList<vEBTreeLevel>), this._level, this._nodeIndex, this._deckIndex)).Should().Throw<ArgumentNullException>().WithParameterName("Levels");
    }

    /// <summary>
    /// Checks that the ChildSqrt method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallChildSqrt()
    {
        // Arrange
        var number = _fixture.Create<int>();

        // Act
        var result = UniverseScope.ChildSqrt(number);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ParentSqrt method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallParentSqrt()
    {
        // Arrange
        var number = _fixture.Create<int>();

        // Act
        var result = UniverseScope.ParentSqrt(number);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIntAndIntAndIntAndInt()
    {
        // Arrange
        var offsetBase = _fixture.Create<int>();
        var offsetFactor = _fixture.Create<int>();
        var indexOffset = _fixture.Create<int>();
        var x = _fixture.Create<int>();

        // Act
        this._testClass.Add(offsetBase, offsetFactor, indexOffset, x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithInt()
    {
        // Arrange
        var x = _fixture.Create<int>();

        // Act
        this._testClass.Add(x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsWithIntAndIntAndIntAndInt()
    {
        // Arrange
        var offsetBase = _fixture.Create<int>();
        var offsetFactor = _fixture.Create<int>();
        var indexOffset = _fixture.Create<int>();
        var x = _fixture.Create<int>();

        // Act
        var result = this._testClass.Contains(offsetBase, offsetFactor, indexOffset, x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContainsWithInt()
    {
        // Arrange
        var x = _fixture.Create<int>();

        // Act
        var result = this._testClass.Contains(x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FirstAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFirstAddWithIntAndIntAndIntAndInt()
    {
        // Arrange
        var offsetBase = _fixture.Create<int>();
        var offsetFactor = _fixture.Create<int>();
        var indexOffset = _fixture.Create<int>();
        var x = _fixture.Create<int>();

        // Act
        this._testClass.FirstAdd(offsetBase, offsetFactor, indexOffset, x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FirstAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFirstAddWithInt()
    {
        // Arrange
        var x = _fixture.Create<int>();

        // Act
        this._testClass.FirstAdd(x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Next method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNextWithIntAndIntAndIntAndInt()
    {
        // Arrange
        var offsetBase = _fixture.Create<int>();
        var offsetFactor = _fixture.Create<int>();
        var indexOffset = _fixture.Create<int>();
        var x = _fixture.Create<int>();

        // Act
        var result = this._testClass.Next(offsetBase, offsetFactor, indexOffset, x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Next method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNextWithInt()
    {
        // Arrange
        var x = _fixture.Create<int>();

        // Act
        var result = this._testClass.Next(x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Previous method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPreviousWithIntAndIntAndIntAndInt()
    {
        // Arrange
        var offsetBase = _fixture.Create<int>();
        var offsetFactor = _fixture.Create<int>();
        var indexOffset = _fixture.Create<int>();
        var x = _fixture.Create<int>();

        // Act
        var result = this._testClass.Previous(offsetBase, offsetFactor, indexOffset, x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Previous method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPreviousWithInt()
    {
        // Arrange
        var x = _fixture.Create<int>();

        // Act
        var result = this._testClass.Previous(x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithIntAndIntAndIntAndInt()
    {
        // Arrange
        var offsetBase = _fixture.Create<int>();
        var offsetFactor = _fixture.Create<int>();
        var indexOffset = _fixture.Create<int>();
        var x = _fixture.Create<int>();

        // Act
        var result = this._testClass.Remove(offsetBase, offsetFactor, indexOffset, x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithInt()
    {
        // Arrange
        var x = _fixture.Create<int>();

        // Act
        var result = this._testClass.Remove(x);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexMax property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIndexMax()
    {
        // Assert
        this._testClass.IndexMax.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexMin property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIndexMin()
    {
        // Assert
        this._testClass.IndexMin.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }
}