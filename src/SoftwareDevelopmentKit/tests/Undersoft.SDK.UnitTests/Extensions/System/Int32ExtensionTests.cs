using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="Int32Extension"/>.
/// </summary>
public class Int32ExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the IsEven method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsEven()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = i.IsEven();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsOdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsOdd()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = i.IsOdd();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveSign method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveSign()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = i.RemoveSign();

        // Assert
        Assert.Fail("Create or modify test");
    }
}