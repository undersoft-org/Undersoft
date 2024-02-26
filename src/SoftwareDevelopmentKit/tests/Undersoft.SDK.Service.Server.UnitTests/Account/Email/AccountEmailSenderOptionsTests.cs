using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts.Email;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts.Email;

/// <summary>
/// Unit tests for the type <see cref="AccountEmailSenderOptions"/>.
/// </summary>
[TestClass]
public class AccountEmailSenderOptionsTests
{
    private AccountEmailSenderOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountEmailSenderOptions"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountEmailSenderOptions>();
    }

    /// <summary>
    /// Checks that the SendGridKey property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSendGridKey()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.SendGridKey = testValue;

        // Assert
        this._testClass.SendGridKey.Should().Be(testValue);
    }
}