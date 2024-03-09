using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.Tests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountOrganization"/>.
/// </summary>
[TestClass]
public class AccountOrganizationTests
{
    private AccountOrganization _testClass;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountOrganization"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        this._testClass = new AccountOrganization();
    }

    /// <summary>
    /// Checks that setting the Name property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetName()
    {
        this._testClass.CheckProperty(x => x.Name);
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
    /// Checks that setting the FullName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFullName()
    {
        this._testClass.CheckProperty(x => x.FullName);
    }

    /// <summary>
    /// Checks that setting the Position property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPosition()
    {
        this._testClass.CheckProperty(x => x.Position);
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
    /// Checks that setting the Industry property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndustry()
    {
        this._testClass.CheckProperty(x => x.Industry);
    }

    /// <summary>
    /// Checks that setting the AccountId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccountId()
    {
        this._testClass.CheckProperty(x => x.AccountId, 2029217226L, 2022088221L);
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