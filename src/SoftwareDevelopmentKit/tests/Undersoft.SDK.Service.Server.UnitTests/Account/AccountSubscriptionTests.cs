using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountSubscription"/>.
/// </summary>
[TestClass]
public class AccountSubscriptionTests
{
    private AccountSubscription _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountSubscription"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountSubscription>();
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
        this._testClass.CheckProperty(x => x.Quantity, _fixture.Create<double>(), _fixture.Create<double>());
    }

    /// <summary>
    /// Checks that setting the Value property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetValue()
    {
        this._testClass.CheckProperty(x => x.Value, _fixture.Create<double>(), _fixture.Create<double>());
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
    /// Checks that setting the SharedServiceCenter property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSharedServiceCenter()
    {
        this._testClass.CheckProperty(x => x.SharedServiceCenter);
    }

    /// <summary>
    /// Checks that setting the ApplicationServer property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetApplicationServer()
    {
        this._testClass.CheckProperty(x => x.ApplicationServer);
    }

    /// <summary>
    /// Checks that setting the ServiceApplication property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetServiceApplication()
    {
        this._testClass.CheckProperty(x => x.ServiceApplication);
    }

    /// <summary>
    /// Checks that setting the ServiceServer property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetServiceServer()
    {
        this._testClass.CheckProperty(x => x.ServiceServer);
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