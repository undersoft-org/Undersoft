using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="Account"/>.
/// </summary>
[TestClass]
public class AccountTests
{
    private Account _testClass;
    private IFixture _fixture;
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
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._email = _fixture.Create<string>();
        this._role = _fixture.Create<string>();
        this._userName = _fixture.Create<string>();
        this._roles = _fixture.Create<IEnumerable<string>>();
        this._testClass = _fixture.Create<Account>();
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
        instance.Should().NotBeNull();

        // Act
        instance = new Account(this._email);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Account(this._email, this._role);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Account(this._userName, this._email, this._roles);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the roles parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRoles()
    {
        FluentActions.Invoking(() => new Account(this._userName, this._email, default(IEnumerable<string>))).Should().Throw<ArgumentNullException>().WithParameterName("roles");
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
        FluentActions.Invoking(() => new Account(value)).Should().Throw<ArgumentNullException>().WithParameterName("email");
        FluentActions.Invoking(() => new Account(value, this._role)).Should().Throw<ArgumentNullException>().WithParameterName("email");
        FluentActions.Invoking(() => new Account(this._userName, value, this._roles)).Should().Throw<ArgumentNullException>().WithParameterName("email");
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
        FluentActions.Invoking(() => new Account(this._email, value)).Should().Throw<ArgumentNullException>().WithParameterName("role");
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
        FluentActions.Invoking(() => new Account(value, this._email, this._roles)).Should().Throw<ArgumentNullException>().WithParameterName("userName");
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
        this._testClass.CheckProperty(x => x.User, _fixture.Create<AccountUser>(), _fixture.Create<AccountUser>());
    }

    /// <summary>
    /// Checks that setting the Roles property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRoles()
    {
        this._testClass.CheckProperty(x => x.Roles, _fixture.Create<Listing<Role>>(), _fixture.Create<Listing<Role>>());
    }

    /// <summary>
    /// Checks that setting the Claims property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClaims()
    {
        this._testClass.CheckProperty(x => x.Claims, _fixture.Create<Listing<AccountClaim>>(), _fixture.Create<Listing<AccountClaim>>());
    }

    /// <summary>
    /// Checks that setting the Tokens property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTokens()
    {
        this._testClass.CheckProperty(x => x.Tokens, _fixture.Create<Listing<AccountToken>>(), _fixture.Create<Listing<AccountToken>>());
    }

    /// <summary>
    /// Checks that setting the PersonalId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPersonalId()
    {
        this._testClass.CheckProperty(x => x.PersonalId, _fixture.Create<long?>(), _fixture.Create<long?>());
    }

    /// <summary>
    /// Checks that setting the Personal property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPersonal()
    {
        this._testClass.CheckProperty(x => x.Personal, _fixture.Create<AccountPersonal>(), _fixture.Create<AccountPersonal>());
    }

    /// <summary>
    /// Checks that setting the Proffesionals property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProffesionals()
    {
        this._testClass.CheckProperty(x => x.Proffesionals, _fixture.Create<Listing<AccountProffesional>>(), _fixture.Create<Listing<AccountProffesional>>());
    }

    /// <summary>
    /// Checks that setting the Organizations property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOrganizations()
    {
        this._testClass.CheckProperty(x => x.Organizations, _fixture.Create<Listing<AccountOrganization>>(), _fixture.Create<Listing<AccountOrganization>>());
    }

    /// <summary>
    /// Checks that setting the Consents property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetConsents()
    {
        this._testClass.CheckProperty(x => x.Consents, _fixture.Create<Listing<AccountConsent>>(), _fixture.Create<Listing<AccountConsent>>());
    }

    /// <summary>
    /// Checks that setting the Subscriptions property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSubscriptions()
    {
        this._testClass.CheckProperty(x => x.Subscriptions, _fixture.Create<Listing<AccountSubscription>>(), _fixture.Create<Listing<AccountSubscription>>());
    }

    /// <summary>
    /// Checks that setting the Payments property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPayments()
    {
        this._testClass.CheckProperty(x => x.Payments, _fixture.Create<Listing<AccountPayment>>(), _fixture.Create<Listing<AccountPayment>>());
    }
}