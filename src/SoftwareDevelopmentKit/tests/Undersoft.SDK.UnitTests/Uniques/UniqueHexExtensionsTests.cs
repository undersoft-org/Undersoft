using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="UniqueHexExtensions"/>.
/// </summary>
public class UniqueHexExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the FromHex method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromHex()
    {
        // Arrange
        var hex = _fixture.Create<string>();

        // Act
        var result = hex.FromHex();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromHex method throws when the hex parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFromHexWithInvalidHex(string value)
    {
        FluentActions.Invoking(() => value.FromHex()).Should().Throw<ArgumentNullException>().WithParameterName("hex");
    }

    /// <summary>
    /// Checks that the ToHex method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToHex()
    {
        // Arrange
        var ba = _fixture.Create<byte[]>();
        var trim = _fixture.Create<bool>();

        // Act
        var result = ba.ToHex(trim);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToHex method throws when the ba parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToHexWithNullBa()
    {
        FluentActions.Invoking(() => default(byte[]).ToHex(_fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("ba");
    }
}