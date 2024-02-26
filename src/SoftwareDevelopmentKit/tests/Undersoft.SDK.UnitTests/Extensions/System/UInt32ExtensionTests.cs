using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="UInt32Extension"/>.
/// </summary>
public class UInt32ExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the IsEven method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsEven()
    {
        // Arrange
        var i = _fixture.Create<uint>();

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
        var i = _fixture.Create<uint>();

        // Act
        var result = i.IsOdd();

        // Assert
        Assert.Fail("Create or modify test");
    }
}