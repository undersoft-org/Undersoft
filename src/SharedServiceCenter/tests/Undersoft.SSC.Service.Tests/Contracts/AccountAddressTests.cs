using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Tests.Contracts;

/// <summary>
/// Unit tests for the type <see cref="AccountAddress"/>.
/// </summary>
[TestClass]
public class AccountAddressTests
{
    private AccountAddress _testClass;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountAddress"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        this._testClass = new AccountAddress();
    }

    /// <summary>
    /// Checks that setting the Country property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCountry()
    {
        this._testClass.CheckProperty(x => x.Country);
    }

    /// <summary>
    /// Checks that setting the State property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetState()
    {
        this._testClass.CheckProperty(x => x.State);
    }

    /// <summary>
    /// Checks that setting the CityName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCityName()
    {
        this._testClass.CheckProperty(x => x.CityName);
    }

    /// <summary>
    /// Checks that setting the Postcode property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPostcode()
    {
        this._testClass.CheckProperty(x => x.Postcode);
    }

    /// <summary>
    /// Checks that setting the StreetName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetStreetName()
    {
        this._testClass.CheckProperty(x => x.StreetName);
    }

    /// <summary>
    /// Checks that setting the BuildingNumber property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBuildingNumber()
    {
        this._testClass.CheckProperty(x => x.BuildingNumber);
    }

    /// <summary>
    /// Checks that setting the ApartmentNumber property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetApartmentNumber()
    {
        this._testClass.CheckProperty(x => x.ApartmentNumber);
    }

    /// <summary>
    /// Checks that setting the AccountId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccountId()
    {
        this._testClass.CheckProperty(x => x.AccountId, 122769893L, 88649693L);
    }
}