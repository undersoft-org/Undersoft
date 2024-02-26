using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Server.Accounts.Email;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts.Email;

/// <summary>
/// Unit tests for the type <see cref="AccountEmailSender"/>.
/// </summary>
[TestClass]
public class AccountEmailSenderTests
{
    private AccountEmailSender _testClass;
    private IFixture _fixture;
    private Mock<IOptions<AccountEmailSenderOptions>> _optionsAccessor;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountEmailSender"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._optionsAccessor = _fixture.Freeze<Mock<IOptions<AccountEmailSenderOptions>>>();
        this._testClass = _fixture.Create<AccountEmailSender>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccountEmailSender(this._optionsAccessor.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the optionsAccessor parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptionsAccessor()
    {
        FluentActions.Invoking(() => new AccountEmailSender(default(IOptions<AccountEmailSenderOptions>))).Should().Throw<ArgumentNullException>().WithParameterName("optionsAccessor");
    }

    /// <summary>
    /// Checks that the SendEmailAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallSendEmailAsync()
    {
        // Arrange
        var toEmail = _fixture.Create<string>();
        var subject = _fixture.Create<string>();
        var message = _fixture.Create<string>();

        // Act
        await this._testClass.SendEmailAsync(toEmail, subject, message);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SendEmailAsync method throws when the toEmail parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSendEmailAsyncWithInvalidToEmailAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.SendEmailAsync(value, _fixture.Create<string>(), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("toEmail");
    }

    /// <summary>
    /// Checks that the SendEmailAsync method throws when the subject parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSendEmailAsyncWithInvalidSubjectAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.SendEmailAsync(_fixture.Create<string>(), value, _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("subject");
    }

    /// <summary>
    /// Checks that the SendEmailAsync method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallSendEmailAsyncWithInvalidMessageAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.SendEmailAsync(_fixture.Create<string>(), _fixture.Create<string>(), value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Execute method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallExecuteAsync()
    {
        // Arrange
        var apiKey = _fixture.Create<string>();
        var subject = _fixture.Create<string>();
        var message = _fixture.Create<string>();
        var toEmail = _fixture.Create<string>();

        // Act
        await this._testClass.Execute(apiKey, subject, message, toEmail);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Execute method throws when the apiKey parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallExecuteWithInvalidApiKeyAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Execute(value, _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("apiKey");
    }

    /// <summary>
    /// Checks that the Execute method throws when the subject parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallExecuteWithInvalidSubjectAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Execute(_fixture.Create<string>(), value, _fixture.Create<string>(), _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("subject");
    }

    /// <summary>
    /// Checks that the Execute method throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallExecuteWithInvalidMessageAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Execute(_fixture.Create<string>(), _fixture.Create<string>(), value, _fixture.Create<string>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("message");
    }

    /// <summary>
    /// Checks that the Execute method throws when the toEmail parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallExecuteWithInvalidToEmailAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Execute(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("toEmail");
    }

    /// <summary>
    /// Checks that the Options property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetOptions()
    {
        // Assert
        this._testClass.Options.Should().BeAssignableTo<AccountEmailSenderOptions>();

        Assert.Fail("Create or modify test");
    }
}