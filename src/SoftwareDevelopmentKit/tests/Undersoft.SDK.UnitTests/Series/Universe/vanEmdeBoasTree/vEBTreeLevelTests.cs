using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series.Universe.vanEmdeBoasTree;

namespace Undersoft.SDK.UnitTests.Series.Universe.vanEmdeBoasTree;

/// <summary>
/// Unit tests for the type <see cref="vEBTreeLevel"/>.
/// </summary>
public class vEBTreeLevelTests
{
    private vEBTreeLevel _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="vEBTreeLevel"/>.
    /// </summary>
    public vEBTreeLevelTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<vEBTreeLevel>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new vEBTreeLevel();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the BaseOffset property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBaseOffset()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.BaseOffset = testValue;

        // Assert
        this._testClass.BaseOffset.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Count property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCount()
    {
        // Arrange
        var testValue = _fixture.Create<byte>();

        // Act
        this._testClass.Count = testValue;

        // Assert
        this._testClass.Count.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Level property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLevel()
    {
        // Arrange
        var testValue = _fixture.Create<byte>();

        // Act
        this._testClass.Level = testValue;

        // Assert
        this._testClass.Level.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Nodes property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNodes()
    {
        // Arrange
        var testValue = _fixture.Create<IList<vEBTreeNode>>();

        // Act
        this._testClass.Nodes = testValue;

        // Assert
        this._testClass.Nodes.Should().BeSameAs(testValue);
    }
}