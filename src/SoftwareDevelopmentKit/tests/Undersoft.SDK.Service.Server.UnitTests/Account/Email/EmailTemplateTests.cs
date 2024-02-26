using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts.Email;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts.Email;

/// <summary>
/// Unit tests for the type <see cref="EmailTemplate"/>.
/// </summary>
[TestClass]
public class EmailTemplateTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetVerificationCodeMessage method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetVerificationCodeMessage()
    {
        // Arrange
        var token = _fixture.Create<string>();

        // Act
        var result = EmailTemplate.GetVerificationCodeMessage(token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetVerificationCodeMessage method throws when the token parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetVerificationCodeMessageWithInvalidToken(string value)
    {
        FluentActions.Invoking(() => EmailTemplate.GetVerificationCodeMessage(value)).Should().Throw<ArgumentNullException>().WithParameterName("token");
    }

    /// <summary>
    /// Checks that the GetResetPasswordMessage method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetResetPasswordMessage()
    {
        // Arrange
        var password = _fixture.Create<string>();

        // Act
        var result = EmailTemplate.GetResetPasswordMessage(password);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetResetPasswordMessage method throws when the password parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetResetPasswordMessageWithInvalidPassword(string value)
    {
        FluentActions.Invoking(() => EmailTemplate.GetResetPasswordMessage(value)).Should().Throw<ArgumentNullException>().WithParameterName("password");
    }
}