using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series.Base.Tetra;

namespace Undersoft.SDK.UnitTests.Series.Base.Tetra;

/// <summary>
/// Unit tests for the type <see cref="TetraCount"/>.
/// </summary>
public class TetraCountTests
{
    private TetraCount _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TetraCount"/>.
    /// </summary>
    public TetraCountTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TetraCount>();
    }

    /// <summary>
    /// Checks that the Increment method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIncrement()
    {
        // Arrange
        var id = _fixture.Create<uint>();

        // Act
        var result = this._testClass.Increment(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Decrement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDecrement()
    {
        // Arrange
        var id = _fixture.Create<uint>();

        // Act
        var result = this._testClass.Decrement(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Reset method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReset()
    {
        // Arrange
        var id = _fixture.Create<uint>();

        // Act
        this._testClass.Reset(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ResetAll method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallResetAll()
    {
        // Act
        this._testClass.ResetAll();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexer()
    {
        var testValue = _fixture.Create<int>();
        this._testClass[_fixture.Create<uint>()].As<object>().Should().BeAssignableTo<int>();
        this._testClass[_fixture.Create<uint>()] = testValue;
        this._testClass[_fixture.Create<uint>()].Should().Be(testValue);
    }
}