using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series.Universe.vanEmdeBoasTree;

namespace Undersoft.SDK.UnitTests.Series.Universe.vanEmdeBoasTree;

/// <summary>
/// Unit tests for the type <see cref="vEBTreeNode"/>.
/// </summary>
public class vEBTreeNodeTests
{
    private vEBTreeNode _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="vEBTreeNode"/>.
    /// </summary>
    public vEBTreeNodeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<vEBTreeNode>();
    }

    /// <summary>
    /// Checks that the IndexOffset property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexOffset()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.IndexOffset = testValue;

        // Assert
        this._testClass.IndexOffset.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the NodeCounter property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNodeCounter()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.NodeCounter = testValue;

        // Assert
        this._testClass.NodeCounter.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the NodeSize property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNodeSize()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.NodeSize = testValue;

        // Assert
        this._testClass.NodeSize.Should().Be(testValue);
    }
}