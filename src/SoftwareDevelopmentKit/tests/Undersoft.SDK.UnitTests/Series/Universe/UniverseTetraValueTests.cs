using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series.Universe;

namespace Undersoft.SDK.UnitTests.Series.Universe;

/// <summary>
/// Unit tests for the type <see cref="UniverseTetraValue"/>.
/// </summary>
public class UniverseTetraValueTests
{
    private class TestUniverseTetraValue : UniverseTetraValue
    {
        public TestUniverseTetraValue(int null_key) : base(null_key)
        {
        }

        public void PublicDispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

    private TestUniverseTetraValue _testClass;
    private IFixture _fixture;
    private int _null_key;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="UniverseTetraValue"/>.
    /// </summary>
    public UniverseTetraValueTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._null_key = _fixture.Create<int>();
        this._testClass = _fixture.Create<TestUniverseTetraValue>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestUniverseTetraValue(this._null_key);

        // Assert
        instance.Should().NotBeNull();
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
    /// Checks that the Dispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDisposeWithNoParameters()
    {
        // Act
        this._testClass.Dispose();

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
    /// Checks that the PublicDispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDisposeWithDisposing()
    {
        // Arrange
        var disposing = _fixture.Create<bool>();

        // Act
        this._testClass.PublicDispose(disposing);

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

    /// <summary>
    /// Checks that the Size property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSize()
    {
        // Assert
        this._testClass.Size.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }
}