using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="HashCode32Comparer"/>.
/// </summary>
public class HashCode32ComparerTests
{
    private HashCode32Comparer _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="HashCode32Comparer"/>.
    /// </summary>
    public HashCode32ComparerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<HashCode32Comparer>();
    }

    /// <summary>
    /// Checks that the Compare method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompare()
    {
        // Arrange
        var x = _fixture.Create<int>();
        var y = _fixture.Create<int>();

        // Act
        var result = this._testClass.Compare(x, y);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCode()
    {
        // Arrange
        var obj = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetHashCode(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="HashCode32Equality"/>.
/// </summary>
public class HashCode32EqualityTests
{
    private HashCode32Equality _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="HashCode32Equality"/>.
    /// </summary>
    public HashCode32EqualityTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<HashCode32Equality>();
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var x = _fixture.Create<int>();
        var y = _fixture.Create<int>();

        // Act
        var result = this._testClass.Equals(x, y);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCode()
    {
        // Arrange
        var obj = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetHashCode(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="HashCode64Equality"/>.
/// </summary>
public class HashCode64EqualityTests
{
    private HashCode64Equality _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="HashCode64Equality"/>.
    /// </summary>
    public HashCode64EqualityTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<HashCode64Equality>();
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var x = _fixture.Create<long>();
        var y = _fixture.Create<long>();

        // Act
        var result = this._testClass.Equals(x, y);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCode()
    {
        // Arrange
        var obj = _fixture.Create<long>();

        // Act
        var result = this._testClass.GetHashCode(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="IntArrayEquality"/>.
/// </summary>
public class IntArrayEqualityTests
{
    private IntArrayEquality _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="IntArrayEquality"/>.
    /// </summary>
    public IntArrayEqualityTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<IntArrayEquality>();
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var x = _fixture.Create<int[]>();
        var y = _fixture.Create<int[]>();

        // Act
        var result = this._testClass.Equals(x, y);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the x parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullX()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(int[]), _fixture.Create<int[]>())).Should().Throw<ArgumentNullException>().WithParameterName("x");
    }

    /// <summary>
    /// Checks that the Equals method throws when the y parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullY()
    {
        FluentActions.Invoking(() => this._testClass.Equals(_fixture.Create<int[]>(), default(int[]))).Should().Throw<ArgumentNullException>().WithParameterName("y");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCode()
    {
        // Arrange
        var obj = _fixture.Create<int[]>();

        // Act
        var result = this._testClass.GetHashCode(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetHashCodeWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.GetHashCode(default(int[]))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }
}

/// <summary>
/// Unit tests for the type <see cref="ParellelHashCode32Equality"/>.
/// </summary>
public class ParellelHashCode32EqualityTests
{
    private ParellelHashCode32Equality _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ParellelHashCode32Equality"/>.
    /// </summary>
    public ParellelHashCode32EqualityTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<ParellelHashCode32Equality>();
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var x = _fixture.Create<ParallelQuery<IEnumerable<int>>>();
        var y = _fixture.Create<ParallelQuery<IEnumerable<int>>>();

        // Act
        var result = this._testClass.Equals(x, y);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the x parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullX()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(ParallelQuery<IEnumerable<int>>), _fixture.Create<ParallelQuery<IEnumerable<int>>>())).Should().Throw<ArgumentNullException>().WithParameterName("x");
    }

    /// <summary>
    /// Checks that the Equals method throws when the y parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullY()
    {
        FluentActions.Invoking(() => this._testClass.Equals(_fixture.Create<ParallelQuery<IEnumerable<int>>>(), default(ParallelQuery<IEnumerable<int>>))).Should().Throw<ArgumentNullException>().WithParameterName("y");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCode()
    {
        // Arrange
        var obj = _fixture.Create<ParallelQuery<IEnumerable<int>>>();

        // Act
        var result = this._testClass.GetHashCode(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetHashCodeWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.GetHashCode(default(ParallelQuery<IEnumerable<int>>))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }
}

/// <summary>
/// Unit tests for the type <see cref="ParellelHashCode64Equality"/>.
/// </summary>
public class ParellelHashCode64EqualityTests
{
    private ParellelHashCode64Equality _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ParellelHashCode64Equality"/>.
    /// </summary>
    public ParellelHashCode64EqualityTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<ParellelHashCode64Equality>();
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var x = _fixture.Create<ParallelQuery<IEnumerable<long>>>();
        var y = _fixture.Create<ParallelQuery<IEnumerable<long>>>();

        // Act
        var result = this._testClass.Equals(x, y);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the x parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullX()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(ParallelQuery<IEnumerable<long>>), _fixture.Create<ParallelQuery<IEnumerable<long>>>())).Should().Throw<ArgumentNullException>().WithParameterName("x");
    }

    /// <summary>
    /// Checks that the Equals method throws when the y parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullY()
    {
        FluentActions.Invoking(() => this._testClass.Equals(_fixture.Create<ParallelQuery<IEnumerable<long>>>(), default(ParallelQuery<IEnumerable<long>>))).Should().Throw<ArgumentNullException>().WithParameterName("y");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCode()
    {
        // Arrange
        var obj = _fixture.Create<ParallelQuery<IEnumerable<long>>>();

        // Act
        var result = this._testClass.GetHashCode(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetHashCodeWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.GetHashCode(default(ParallelQuery<IEnumerable<long>>))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }
}