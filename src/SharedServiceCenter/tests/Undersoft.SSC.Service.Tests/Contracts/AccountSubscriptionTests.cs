using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Tests.Contracts;

/// <summary>
/// Unit tests for the type <see cref="AccountSubscription"/>.
/// </summary>
[TestClass]
public class AccountSubscriptionTests
{
    private AccountSubscription _testClass;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountSubscription"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        this._testClass = new AccountSubscription();
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
    /// Checks that setting the Description property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDescription()
    {
        this._testClass.CheckProperty(x => x.Description);
    }

    /// <summary>
    /// Checks that setting the EndDate property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEndDate()
    {
        this._testClass.CheckProperty(x => x.EndDate);
    }

    /// <summary>
    /// Checks that setting the Quantity property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetQuantity()
    {
        this._testClass.CheckProperty(x => x.Quantity, 234149840.1, 1976495241.6);
    }

    /// <summary>
    /// Checks that setting the Value property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetValue()
    {
        this._testClass.CheckProperty(x => x.Value, 2076814144.35, 1713182402.25);
    }

    /// <summary>
    /// Checks that setting the Currency property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCurrency()
    {
        this._testClass.CheckProperty(x => x.Currency);
    }

    /// <summary>
    /// Checks that setting the AccountId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccountId()
    {
        this._testClass.CheckProperty(x => x.AccountId, 1769813139L, 1107034522L);
    }
}