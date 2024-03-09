using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.Tests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="Account"/>.
/// </summary>
[TestClass]
public class AccountTests
{
    private Account _testClass;
    private string _email;
    private string _role;
    private string _userName;
    private IEnumerable<string> _roles;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Account"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        this._email = "TestValue668760711";
        this._role = "TestValue897327618";
        this._userName = "TestValue226635568";
        this._roles = new[] { "TestValue610836287", "TestValue1099052881", "TestValue735686622" };
        this._testClass = new Account(this._userName, this._email, this._roles);
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Account();

        // Assert
        instance.ShouldNotBeNull();

        // Act
        instance = new Account(this._email);

        // Assert
        instance.ShouldNotBeNull();

        // Act
        instance = new Account(this._email, this._role);

        // Assert
        instance.ShouldNotBeNull();

        // Act
        instance = new Account(this._userName, this._email, this._roles);

        // Assert
        instance.ShouldNotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the roles parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRoles()
    {
        Should.Throw<ArgumentNullException>(() => new Account(this._userName, this._email, default(IEnumerable<string>)));
    }

    /// <summary>
    /// Checks that the constructor throws when the email parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidEmail(string value)
    {
        Should.Throw<ArgumentNullException>(() => new Account(value));
        Should.Throw<ArgumentNullException>(() => new Account(value, this._role));
        Should.Throw<ArgumentNullException>(() => new Account(this._userName, value, this._roles));
    }

    /// <summary>
    /// Checks that the constructor throws when the role parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidRole(string value)
    {
        Should.Throw<ArgumentNullException>(() => new Account(this._email, value));
    }

    /// <summary>
    /// Checks that the constructor throws when the userName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidUserName(string value)
    {
        Should.Throw<ArgumentNullException>(() => new Account(value, this._email, this._roles));
    }

    /// <summary>
    /// Checks that the GetClaims method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetClaims()
    {
        // Act
        var result = this._testClass.GetClaims();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the UserId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUserId()
    {
        this._testClass.CheckProperty(x => x.UserId);
    }

    /// <summary>
    /// Checks that setting the User property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUser()
    {
        this._testClass.CheckProperty(x => x.User, new AccountUser
        {
            RegistrationCompleted = false,
            IsLockedOut = false,
            TypeId = 1485814706L,
            Account = new Account()
        }, new AccountUser
        {
            RegistrationCompleted = false,
            IsLockedOut = true,
            TypeId = 1952629924L,
            Account = new Account()
        });
    }

    /// <summary>
    /// Checks that the Roles property is initialized correctly by the constructor.
    /// </summary>
    [TestMethod]
    public void RolesIsInitializedCorrectly()
    {
        this._testClass.Roles.ShouldBeSameAs(this._roles);
    }

    /// <summary>
    /// Checks that setting the Roles property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRoles()
    {
        this._testClass.CheckProperty(x => x.Roles, new Listing<Role>(), new Listing<Role>());
    }

    /// <summary>
    /// Checks that setting the Claims property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClaims()
    {
        this._testClass.CheckProperty(x => x.Claims, new Listing<AccountClaim>(), new Listing<AccountClaim>());
    }

    /// <summary>
    /// Checks that setting the Tokens property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTokens()
    {
        this._testClass.CheckProperty(x => x.Tokens, new Listing<AccountToken>(), new Listing<AccountToken>());
    }

    /// <summary>
    /// Checks that setting the PersonalId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPersonalId()
    {
        this._testClass.CheckProperty(x => x.PersonalId, 1318819149L, 2017824442L);
    }

    /// <summary>
    /// Checks that setting the Personal property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPersonal()
    {
        this._testClass.CheckProperty(x => x.Personal, new AccountPersonal
        {
            Title = "TestValue1069188703",
            Email = "TestValue1879055775",
            PhoneNumber = "TestValue2131974520",
            FirstName = "TestValue1170964020",
            SecondName = "TestValue653994283",
            LastName = "TestValue1565967699",
            Birthdate = DateTime.UtcNow,
            Gender = "TestValue1231171419",
            Image = "TestValue65592050",
            AccountId = 1896923728L,
            Account = new Account()
        }, new AccountPersonal
        {
            Title = "TestValue1326992444",
            Email = "TestValue1970857589",
            PhoneNumber = "TestValue1188739433",
            FirstName = "TestValue1614979132",
            SecondName = "TestValue1224636709",
            LastName = "TestValue1436453637",
            Birthdate = DateTime.UtcNow,
            Gender = "TestValue1598003904",
            Image = "TestValue1841844630",
            AccountId = 1758462636L,
            Account = new Account()
        });
    }

    /// <summary>
    /// Checks that setting the AddressId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAddressId()
    {
        this._testClass.CheckProperty(x => x.AddressId, 1494427991L, 1972188785L);
    }

    /// <summary>
    /// Checks that setting the Address property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAddress()
    {
        this._testClass.CheckProperty(x => x.Address, new AccountAddress
        {
            Country = "TestValue1479906631",
            State = "TestValue118160855",
            CityName = "TestValue808040260",
            StreetName = "TestValue266112657",
            BuildingNumber = "TestValue1459122929",
            ApartmentNumber = "TestValue1611076783",
            Postcode = "TestValue871228391",
            SocialMedia = "TestValue74497487",
            Websites = "TestValue236145562",
            AccountId = 557941539L,
            Account = new Account()
        }, new AccountAddress
        {
            Country = "TestValue330463033",
            State = "TestValue676796957",
            CityName = "TestValue1407885227",
            StreetName = "TestValue1972044228",
            BuildingNumber = "TestValue1701669245",
            ApartmentNumber = "TestValue1117468111",
            Postcode = "TestValue1624868582",
            SocialMedia = "TestValue978492220",
            Websites = "TestValue815120070",
            AccountId = 1621930355L,
            Account = new Account()
        });
    }

    /// <summary>
    /// Checks that setting the ProfessionalId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProfessionalId()
    {
        this._testClass.CheckProperty(x => x.ProfessionalId, 1262739300L, 603168661L);
    }

    /// <summary>
    /// Checks that setting the Professional property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProfessional()
    {
        this._testClass.CheckProperty(x => x.Professional, new AccountProfessional
        {
            Email = "TestValue1147887537",
            PhoneNumber = "TestValue1047126771",
            Profession = "TestValue787462345",
            Industry = "TestValue2057797095",
            SocialMedia = "TestValue1268191137",
            Websites = "TestValue506838069",
            Experience = 4209.054F,
            AccountId = 2035294449L,
            Account = new Account()
        }, new AccountProfessional
        {
            Email = "TestValue1609202357",
            PhoneNumber = "TestValue799393780",
            Profession = "TestValue458201933",
            Industry = "TestValue1494114011",
            SocialMedia = "TestValue537917811",
            Websites = "TestValue951027848",
            Experience = 16341.9014F,
            AccountId = 1865861863L,
            Account = new Account()
        });
    }

    /// <summary>
    /// Checks that setting the OrganizationId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOrganizationId()
    {
        this._testClass.CheckProperty(x => x.OrganizationId, 1859324738L, 1190401147L);
    }

    /// <summary>
    /// Checks that setting the Organization property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOrganization()
    {
        this._testClass.CheckProperty(x => x.Organization, new AccountOrganization
        {
            Name = "TestValue694739308",
            Email = "TestValue1156673931",
            PhoneNumber = "TestValue1976930135",
            FullName = "TestValue1338982189",
            Position = "TestValue996529411",
            Image = "TestValue1294060632",
            Industry = "TestValue1928337853",
            AccountId = 1790418551L,
            Account = new Account()
        }, new AccountOrganization
        {
            Name = "TestValue1670451111",
            Email = "TestValue318985526",
            PhoneNumber = "TestValue2120618969",
            FullName = "TestValue863352410",
            Position = "TestValue943342566",
            Image = "TestValue2019981283",
            Industry = "TestValue709449485",
            AccountId = 876737970L,
            Account = new Account()
        });
    }

    /// <summary>
    /// Checks that setting the ConsentId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetConsentId()
    {
        this._testClass.CheckProperty(x => x.ConsentId, 1117756965L, 1908397136L);
    }

    /// <summary>
    /// Checks that setting the Consent property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetConsent()
    {
        this._testClass.CheckProperty(x => x.Consent, new AccountConsent
        {
            TermsText = "TestValue1626133959",
            TermsConsent = true,
            PersonalDataText = "TestValue342885646",
            PersonalDataConsent = false,
            MarketingText = "TestValue1946128148",
            MarketingConsent = false,
            ThirdPartyText = "TestValue1096222829",
            ThirdPartyConsent = false,
            AccountId = 218595024L,
            Account = new Account()
        }, new AccountConsent
        {
            TermsText = "TestValue2061254863",
            TermsConsent = true,
            PersonalDataText = "TestValue750641397",
            PersonalDataConsent = false,
            MarketingText = "TestValue1906490366",
            MarketingConsent = true,
            ThirdPartyText = "TestValue1772202570",
            ThirdPartyConsent = true,
            AccountId = 106065369L,
            Account = new Account()
        });
    }

    /// <summary>
    /// Checks that setting the SubscriptionId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSubscriptionId()
    {
        this._testClass.CheckProperty(x => x.SubscriptionId, 773722173L, 1956388995L);
    }

    /// <summary>
    /// Checks that setting the Subscription property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSubscription()
    {
        this._testClass.CheckProperty(x => x.Subscription, new AccountSubscription
        {
            Name = "TestValue50597360",
            Description = "TestValue1640885360",
            EndDate = DateTime.UtcNow,
            Quantity = 128164649.58,
            Value = 1609003670.67,
            Currency = "TestValue983870605",
            AccountId = 2104351108L,
            Account = new Account()
        }, new AccountSubscription
        {
            Name = "TestValue2062159127",
            Description = "TestValue745849947",
            EndDate = DateTime.UtcNow,
            Quantity = 1983499512.3899999,
            Value = 579847254.03,
            Currency = "TestValue784664526",
            AccountId = 1808663488L,
            Account = new Account()
        });
    }

    /// <summary>
    /// Checks that setting the PaymentId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPaymentId()
    {
        this._testClass.CheckProperty(x => x.PaymentId, 1980754530L, 1310102026L);
    }

    /// <summary>
    /// Checks that setting the Payment property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPayment()
    {
        this._testClass.CheckProperty(x => x.Payment, new AccountPayment
        {
            Title = "TestValue239727903",
            CardNumber = "TestValue310515257",
            CardType = "TestValue847515501",
            Expiration = "TestValue330348986",
            CSV = "TestValue1358029430",
            FirstName = "TestValue1628595375",
            LastName = "TestValue242759360",
            TermsConsent = false,
            PaymentType = "TestValue1075465608",
            PhoneNumber = "TestValue2014566637",
            Image = "TestValue356292134",
            Provider = "TestValue919809714",
            Websites = "TestValue272532930",
            AccountId = 214128603L,
            Account = new Account()
        }, new AccountPayment
        {
            Title = "TestValue1744184928",
            CardNumber = "TestValue1318623643",
            CardType = "TestValue1092790236",
            Expiration = "TestValue603384116",
            CSV = "TestValue103015797",
            FirstName = "TestValue1308851617",
            LastName = "TestValue1857799776",
            TermsConsent = false,
            PaymentType = "TestValue1419350239",
            PhoneNumber = "TestValue865113060",
            Image = "TestValue1528003364",
            Provider = "TestValue1989260687",
            Websites = "TestValue433659280",
            AccountId = 350372882L,
            Account = new Account()
        });
    }
}