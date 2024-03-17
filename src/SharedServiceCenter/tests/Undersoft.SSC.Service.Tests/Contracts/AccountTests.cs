using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Tests.Contracts;

/// <summary>
/// Unit tests for the type <see cref="Account"/>.
/// </summary>
[TestClass]
public class AccountTests
{
    private Account _testClass;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Account"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        this._testClass = new Account();
    }

    /// <summary>
    /// Checks that setting the User property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUser()
    {
        this._testClass.CheckProperty(x => x.User, new AccountUser
        {
            UserName = "TestValue727433822",
            NormalizedUserName = "TestValue1834052215",
            Email = "TestValue1089438592",
            NormalizedEmail = "TestValue852857851",
            EmailConfirmed = true,
            PasswordHash = "TestValue1247954733",
            SecurityStamp = "TestValue1403991347",
            ConcurrencyStamp = "TestValue1514439653",
            PhoneNumber = "TestValue2001459811",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = DateTimeOffset.UtcNow,
            LockoutEnabled = true,
            AccessFailedCount = 798467010,
            RegistrationCompleted = false,
            IsLockedOut = false
        }, new AccountUser
        {
            UserName = "TestValue124713990",
            NormalizedUserName = "TestValue760079841",
            Email = "TestValue491352323",
            NormalizedEmail = "TestValue762169981",
            EmailConfirmed = false,
            PasswordHash = "TestValue115407214",
            SecurityStamp = "TestValue1796042806",
            ConcurrencyStamp = "TestValue1405406582",
            PhoneNumber = "TestValue1928516419",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = true,
            LockoutEnd = DateTimeOffset.UtcNow,
            LockoutEnabled = false,
            AccessFailedCount = 1487377269,
            RegistrationCompleted = true,
            IsLockedOut = true
        });
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
        this._testClass.CheckProperty(x => x.Claims, new Listing<Claim>(), new Listing<Claim>());
    }

    /// <summary>
    /// Checks that setting the Tokens property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTokens()
    {
        this._testClass.CheckProperty(x => x.Tokens, new Listing<Token>(), new Listing<Token>());
    }

    /// <summary>
    /// Checks that setting the PersonalId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPersonalId()
    {
        this._testClass.CheckProperty(x => x.PersonalId, 1933906323L, 1200133087L);
    }

    /// <summary>
    /// Checks that setting the Personal property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPersonal()
    {
        this._testClass.CheckProperty(x => x.Personal, new AccountPersonal
        {
            FirstName = "TestValue1034338825",
            LastName = "TestValue478047599",
            Email = "TestValue1774789709",
            PhoneNumber = "TestValue1967752863",
            Birthdate = DateTime.UtcNow,
            Image = "TestValue664509259",
            AccountId = 1736463161L
        }, new AccountPersonal
        {
            FirstName = "TestValue1362478515",
            LastName = "TestValue696965696",
            Email = "TestValue965851949",
            PhoneNumber = "TestValue1817220057",
            Birthdate = DateTime.UtcNow,
            Image = "TestValue1252932949",
            AccountId = 52450991L
        });
    }

    /// <summary>
    /// Checks that setting the AddressId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAddressId()
    {
        this._testClass.CheckProperty(x => x.AddressId, 340054313L, 1447192293L);
    }

    /// <summary>
    /// Checks that setting the Address property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAddress()
    {
        this._testClass.CheckProperty(x => x.Address, new AccountAddress
        {
            Country = "TestValue1456190806",
            State = "TestValue758120906",
            CityName = "TestValue2037660008",
            Postcode = "TestValue581420538",
            StreetName = "TestValue800804643",
            BuildingNumber = "TestValue884510843",
            ApartmentNumber = "TestValue167567906",
            AccountId = 1078874663L
        }, new AccountAddress
        {
            Country = "TestValue428645633",
            State = "TestValue1308405820",
            CityName = "TestValue585518740",
            Postcode = "TestValue836159865",
            StreetName = "TestValue21026083",
            BuildingNumber = "TestValue2064097725",
            ApartmentNumber = "TestValue1016688118",
            AccountId = 154653318L
        });
    }

    /// <summary>
    /// Checks that setting the ProfessionalId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProfessionalId()
    {
        this._testClass.CheckProperty(x => x.ProfessionalId, 202883965L, 1121522136L);
    }

    /// <summary>
    /// Checks that setting the Professional property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProfessional()
    {
        this._testClass.CheckProperty(x => x.Professional, new AccountProfessional
        {
            Industry = "TestValue1048285012",
            Profession = "TestValue320419411",
            Email = "TestValue1859234452",
            PhoneNumber = "TestValue1889217264",
            SocialMedia = "TestValue461630278",
            Websites = "TestValue95570582",
            Experience = 13768.6963F,
            AccountId = 1547175113L
        }, new AccountProfessional
        {
            Industry = "TestValue660849650",
            Profession = "TestValue1297038912",
            Email = "TestValue2126306396",
            PhoneNumber = "TestValue1934455217",
            SocialMedia = "TestValue675583470",
            Websites = "TestValue214888120",
            Experience = 18259.1484F,
            AccountId = 1927220004L
        });
    }

    /// <summary>
    /// Checks that setting the OrganizationId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOrganizationId()
    {
        this._testClass.CheckProperty(x => x.OrganizationId, 31186463L, 1887114276L);
    }

    /// <summary>
    /// Checks that setting the Organization property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOrganization()
    {
        this._testClass.CheckProperty(x => x.Organization, new AccountOrganization
        {
            Industry = "TestValue1956630132",
            Name = "TestValue1352485785",
            FullName = "TestValue399328444",
            Position = "TestValue149827982",
            Email = "TestValue310479693",
            PhoneNumber = "TestValue695915046",
            Image = "TestValue1539107230",
            AccountId = 502161539L
        }, new AccountOrganization
        {
            Industry = "TestValue78990519",
            Name = "TestValue900303296",
            FullName = "TestValue1341452432",
            Position = "TestValue780351618",
            Email = "TestValue2096647478",
            PhoneNumber = "TestValue1662566739",
            Image = "TestValue1415551047",
            AccountId = 131410813L
        });
    }

    /// <summary>
    /// Checks that setting the SubscriptionId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSubscriptionId()
    {
        this._testClass.CheckProperty(x => x.SubscriptionId, 1151649626L, 19634902L);
    }

    /// <summary>
    /// Checks that setting the Subscription property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSubscription()
    {
        this._testClass.CheckProperty(x => x.Subscription, new AccountSubscription
        {
            Name = "TestValue1735441488",
            Description = "TestValue1714457189",
            EndDate = DateTime.UtcNow,
            Quantity = 293525721.71999997,
            Value = 1922668531.74,
            Currency = "TestValue1826531376",
            AccountId = 1401113177L
        }, new AccountSubscription
        {
            Name = "TestValue223661193",
            Description = "TestValue1018012641",
            EndDate = DateTime.UtcNow,
            Quantity = 1089051394.86,
            Value = 635257322.37,
            Currency = "TestValue632822350",
            AccountId = 370630620L
        });
    }

    /// <summary>
    /// Checks that setting the PaymentId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPaymentId()
    {
        this._testClass.CheckProperty(x => x.PaymentId, 1786975494L, 241289726L);
    }

    /// <summary>
    /// Checks that setting the Payment property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPayment()
    {
        this._testClass.CheckProperty(x => x.Payment, new AccountPayment
        {
            Title = "TestValue2032911262",
            CardNumber = "TestValue1277057489",
            CardType = "TestValue345506833",
            Expiration = "TestValue997881827",
            CSV = "TestValue722193692",
            FirstName = "TestValue898457030",
            LastName = "TestValue9939718",
            TermsConsent = false,
            PaymentType = "TestValue350110034",
            PhoneNumber = "TestValue2106952386",
            Image = "TestValue16580063",
            Provider = "TestValue2069513",
            Websites = "TestValue205722681",
            AccountId = 2027981679L
        }, new AccountPayment
        {
            Title = "TestValue1347875081",
            CardNumber = "TestValue463739657",
            CardType = "TestValue518904170",
            Expiration = "TestValue544172657",
            CSV = "TestValue1210722141",
            FirstName = "TestValue1177033116",
            LastName = "TestValue191778516",
            TermsConsent = true,
            PaymentType = "TestValue1590623648",
            PhoneNumber = "TestValue14540705",
            Image = "TestValue1673438056",
            Provider = "TestValue1145698914",
            Websites = "TestValue2073650436",
            AccountId = 1439950699L
        });
    }

    /// <summary>
    /// Checks that setting the ConsentId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetConsentId()
    {
        this._testClass.CheckProperty(x => x.ConsentId, 1743346779L, 897433167L);
    }

    /// <summary>
    /// Checks that setting the Consent property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetConsent()
    {
        this._testClass.CheckProperty(x => x.Consent, new AccountConsent
        {
            TermsText = "TestValue2016822836",
            TermsConsent = false,
            PersonalDataText = "TestValue1260811449",
            PersonalDataConsent = false,
            MarketingText = "TestValue894924003",
            MarketingConsent = true,
            ThirdPartyText = "TestValue1317059906",
            ThirdPartyConsent = false,
            AccountId = 1556700768L
        }, new AccountConsent
        {
            TermsText = "TestValue253192596",
            TermsConsent = false,
            PersonalDataText = "TestValue572122082",
            PersonalDataConsent = true,
            MarketingText = "TestValue337021889",
            MarketingConsent = true,
            ThirdPartyText = "TestValue1824461863",
            ThirdPartyConsent = false,
            AccountId = 343163161L
        });
    }
}