using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountOrganization"/>.
/// </summary>
[TestClass]
public class AccountOrganizationTests
{
    private AccountOrganization _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountOrganization"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountOrganization>();
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
    /// Checks that setting the Size property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSize()
    {
        this._testClass.CheckProperty(x => x.Size);
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
    /// Checks that setting the Postcode property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPostcode()
    {
        this._testClass.CheckProperty(x => x.Postcode);
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