using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountConsent"/>.
/// </summary>
[TestClass]
public class AccountConsentTests
{
    private AccountConsent _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountConsent"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountConsent>();
    }

    /// <summary>
    /// Checks that setting the TermsText property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTermsText()
    {
        this._testClass.CheckProperty(x => x.TermsText);
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
    /// Checks that setting the PersonalDataText property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPersonalDataText()
    {
        this._testClass.CheckProperty(x => x.PersonalDataText);
    }

    /// <summary>
    /// Checks that setting the PersonalDataConsent property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPersonalDataConsent()
    {
        this._testClass.CheckProperty(x => x.PersonalDataConsent);
    }

    /// <summary>
    /// Checks that setting the MarketingText property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMarketingText()
    {
        this._testClass.CheckProperty(x => x.MarketingText);
    }

    /// <summary>
    /// Checks that setting the MarketingConsent property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMarketingConsent()
    {
        this._testClass.CheckProperty(x => x.MarketingConsent);
    }

    /// <summary>
    /// Checks that setting the ThirdPartyText property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetThirdPartyText()
    {
        this._testClass.CheckProperty(x => x.ThirdPartyText);
    }

    /// <summary>
    /// Checks that setting the ThirdPartyConsent property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetThirdPartyConsent()
    {
        this._testClass.CheckProperty(x => x.ThirdPartyConsent);
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