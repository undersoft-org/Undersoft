using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Cryptography;

namespace Undersoft.SDK.UnitTests.Cryptography;

/// <summary>
/// Unit tests for the type <see cref="CryptoHasher"/>.
/// </summary>
public class CryptoHasherTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Encrypt method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEncrypt()
    {
        // Arrange
        var pass = _fixture.Create<string>();
        var salt = _fixture.Create<string>();

        // Act
        var result = CryptoHasher.Encrypt(pass, salt);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Encrypt method throws when the pass parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallEncryptWithInvalidPass(string value)
    {
        FluentActions.Invoking(() => CryptoHasher.Encrypt(value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("pass");
    }

    /// <summary>
    /// Checks that the Encrypt method throws when the salt parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallEncryptWithInvalidSalt(string value)
    {
        FluentActions.Invoking(() => CryptoHasher.Encrypt(_fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("salt");
    }

    /// <summary>
    /// Checks that the Salt method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSalt()
    {
        // Act
        var result = CryptoHasher.Salt();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Verify method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallVerify()
    {
        // Arrange
        var hashedPassword = _fixture.Create<string>();
        var hashedSalt = _fixture.Create<string>();
        var providedPassword = _fixture.Create<string>();

        // Act
        var result = CryptoHasher.Verify(hashedPassword, hashedSalt, providedPassword);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Verify method throws when the hashedPassword parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallVerifyWithInvalidHashedPassword(string value)
    {
        FluentActions.Invoking(() => CryptoHasher.Verify(value, _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("hashedPassword");
    }

    /// <summary>
    /// Checks that the Verify method throws when the hashedSalt parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallVerifyWithInvalidHashedSalt(string value)
    {
        FluentActions.Invoking(() => CryptoHasher.Verify(_fixture.Create<string>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("hashedSalt");
    }

    /// <summary>
    /// Checks that the Verify method throws when the providedPassword parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallVerifyWithInvalidProvidedPassword(string value)
    {
        FluentActions.Invoking(() => CryptoHasher.Verify(_fixture.Create<string>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("providedPassword");
    }
}