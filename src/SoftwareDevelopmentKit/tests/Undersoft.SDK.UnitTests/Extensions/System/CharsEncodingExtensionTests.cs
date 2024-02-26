using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="CharsEncodingExtension"/>.
/// </summary>
public class CharsEncodingExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ToBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToBytesWithCharAndCharEncoding()
    {
        // Arrange
        var ca = _fixture.Create<char>();
        var tf = _fixture.Create<CharEncoding>();

        // Act
        var result = ca.ToBytes(tf);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToBytesWithArrayOfCharAndCharEncoding()
    {
        // Arrange
        var ca = _fixture.Create<char[]>();
        var tf = _fixture.Create<CharEncoding>();

        // Act
        var result = ca.ToBytes(tf);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToBytes method throws when the ca parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToBytesWithArrayOfCharAndCharEncodingWithNullCa()
    {
        FluentActions.Invoking(() => default(char[]).ToBytes(_fixture.Create<CharEncoding>())).Should().Throw<ArgumentNullException>().WithParameterName("ca");
    }

    /// <summary>
    /// Checks that the ToBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToBytesWithStringAndCharEncoding()
    {
        // Arrange
        var ca = _fixture.Create<string>();
        var tf = _fixture.Create<CharEncoding>();

        // Act
        var result = ca.ToBytes(tf);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToBytes method throws when the ca parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallToBytesWithStringAndCharEncodingWithInvalidCa(string value)
    {
        FluentActions.Invoking(() => value.ToBytes(_fixture.Create<CharEncoding>())).Should().Throw<ArgumentNullException>().WithParameterName("ca");
    }

    /// <summary>
    /// Checks that the ToChars method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToCharsWithByteAndCharEncoding()
    {
        // Arrange
        var ba = _fixture.Create<byte>();
        var tf = _fixture.Create<CharEncoding>();

        // Act
        var result = ba.ToChars(tf);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToChars method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToCharsWithArrayOfByteAndCharEncoding()
    {
        // Arrange
        var ba = _fixture.Create<byte[]>();
        var tf = _fixture.Create<CharEncoding>();

        // Act
        var result = ba.ToChars(tf);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToChars method throws when the ba parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToCharsWithArrayOfByteAndCharEncodingWithNullBa()
    {
        FluentActions.Invoking(() => default(byte[]).ToChars(_fixture.Create<CharEncoding>())).Should().Throw<ArgumentNullException>().WithParameterName("ba");
    }
}