using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.Tests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountProfessional"/>.
/// </summary>
[TestClass]
public class AccountProfessionalTests
{
    private AccountProfessional _testClass;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountProfessional"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        this._testClass = new AccountProfessional();
    }

    /// <summary>
    /// Checks that setting the Email property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEmail()
    {
        this._testClass.CheckProperty(x => x.Email);
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
    /// Checks that setting the Profession property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProfession()
    {
        this._testClass.CheckProperty(x => x.Profession);
    }

    /// <summary>
    /// Checks that setting the Industry property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndustry()
    {
        this._testClass.CheckProperty(x => x.Industry);
    }

    /// <summary>
    /// Checks that setting the SocialMedia property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSocialMedia()
    {
        this._testClass.CheckProperty(x => x.SocialMedia);
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
    /// Checks that setting the Experience property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetExperience()
    {
        this._testClass.CheckProperty(x => x.Experience, 20266.707F, 3525.43042F);
    }

    /// <summary>
    /// Checks that setting the AccountId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccountId()
    {
        this._testClass.CheckProperty(x => x.AccountId, 1497003190L, 881892025L);
    }

    /// <summary>
    /// Checks that setting the Account property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccount()
    {
        this._testClass.CheckProperty(x => x.Account, new Account(), new Account());
    }
}