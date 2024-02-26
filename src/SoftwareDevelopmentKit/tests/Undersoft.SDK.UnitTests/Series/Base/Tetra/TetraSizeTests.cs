using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series.Base.Tetra;

namespace Undersoft.SDK.UnitTests.Series.Base.Tetra;

/// <summary>
/// Unit tests for the type <see cref="TetraSize"/>.
/// </summary>
public class TetraSizeTests
{
    private TetraSize _testClass;
    private IFixture _fixture;
    private int _size;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TetraSize"/>.
    /// </summary>
    public TetraSizeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._size = _fixture.Create<int>();
        this._testClass = _fixture.Create<TetraSize>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TetraSize(this._size);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the NextSize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNextSize()
    {
        // Arrange
        var id = _fixture.Create<uint>();

        // Act
        var result = this._testClass.NextSize(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PreviousSize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPreviousSize()
    {
        // Arrange
        var id = _fixture.Create<uint>();

        // Act
        var result = this._testClass.PreviousSize(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetPrimesId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPrimesId()
    {
        // Arrange
        var id = _fixture.Create<uint>();

        // Act
        var result = this._testClass.GetPrimesId(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetPrimesId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetPrimesId()
    {
        // Arrange
        var id = _fixture.Create<uint>();
        var value = _fixture.Create<int>();

        // Act
        this._testClass.SetPrimesId(id, value);

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