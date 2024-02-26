using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountPayment"/>.
/// </summary>
[TestClass]
public class AccountPaymentTests
{
    private AccountPayment _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountPayment"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountPayment>();
    }

    /// <summary>
    /// Checks that setting the Title property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTitle()
    {
        this._testClass.CheckProperty(x => x.Title);
    }

    /// <summary>
    /// Checks that setting the CardNumber property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCardNumber()
    {
        this._testClass.CheckProperty(x => x.CardNumber);
    }

    /// <summary>
    /// Checks that setting the CardType property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCardType()
    {
        this._testClass.CheckProperty(x => x.CardType);
    }

    /// <summary>
    /// Checks that setting the Expiration property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetExpiration()
    {
        this._testClass.CheckProperty(x => x.Expiration);
    }

    /// <summary>
    /// Checks that setting the CSV property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCSV()
    {
        this._testClass.CheckProperty(x => x.CSV);
    }

    /// <summary>
    /// Checks that setting the FirstName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFirstName()
    {
        this._testClass.CheckProperty(x => x.FirstName);
    }

    /// <summary>
    /// Checks that setting the LastName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLastName()
    {
        this._testClass.CheckProperty(x => x.LastName);
    }

    /// <summary>
    /// Checks that setting the TermsConsent property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTermsConsent()
    {
        this._testClass.CheckProperty(x => x.TermsConsent);
    }

    /// <summary>
    /// Checks that setting the PaymentType property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPaymentType()
    {
        this._testClass.CheckProperty(x => x.PaymentType);
    }

    /// <summary>
    /// Checks that setting the PhoneNumber property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPhoneNumber()
    {
        this._testClass.CheckProperty(x => x.PhoneNumber);
    }

    /// <summary>
    /// Checks that setting the Image property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetImage()
    {
        this._testClass.CheckProperty(x => x.Image);
    }

    /// <summary>
    /// Checks that setting the Provider property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProvider()
    {
        this._testClass.CheckProperty(x => x.Provider);
    }

    /// <summary>
    /// Checks that setting the Websites property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetWebsites()
    {
        this._testClass.CheckProperty(x => x.Websites);
    }

    /// <summary>
    /// Checks that setting the AccountId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccountId()
    {
        this._testClass.CheckProperty(x => x.AccountId, _fixture.Create<long?>(), _fixture.Create<long?>());
    }

    /// <summary>
    /// Checks that setting the Account property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccount()
    {
        this._testClass.CheckProperty(x => x.Account, _fixture.Create<Account>(), _fixture.Create<Account>());
    }
}