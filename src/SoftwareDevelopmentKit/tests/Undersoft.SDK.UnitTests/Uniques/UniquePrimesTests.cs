using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.UnitTests.Uniques;

/// <summary>
/// Unit tests for the type <see cref="UniquePrimes"/>.
/// </summary>
public class UniquePrimesTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var id = _fixture.Create<int>();

        // Act
        var result = UniquePrimes.Get(id);

        // Assert
        Assert.Fail("Create or modify test");
    }
}