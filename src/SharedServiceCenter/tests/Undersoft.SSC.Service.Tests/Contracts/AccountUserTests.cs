using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Tests.Contracts;

/// <summary>
/// Unit tests for the type <see cref="AccountUser"/>.
/// </summary>
[TestClass]
public class AccountUserTests
{
    private AccountUser _testClass;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountUser"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        this._testClass = new AccountUser();
    }

    /// <summary>
    /// Checks that setting the UserName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUserName()
    {
        this._testClass.CheckProperty(x => x.UserName);
    }

    /// <summary>
    /// Checks that setting the NormalizedUserName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNormalizedUserName()
    {
        this._testClass.CheckProperty(x => x.NormalizedUserName);
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
    /// Checks that setting the NormalizedEmail property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNormalizedEmail()
    {
        this._testClass.CheckProperty(x => x.NormalizedEmail);
    }

    /// <summary>
    /// Checks that setting the EmailConfirmed property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEmailConfirmed()
    {
        this._testClass.CheckProperty(x => x.EmailConfirmed);
    }

    /// <summary>
    /// Checks that setting the PasswordHash property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPasswordHash()
    {
        this._testClass.CheckProperty(x => x.PasswordHash);
    }

    /// <summary>
    /// Checks that setting the SecurityStamp property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSecurityStamp()
    {
        this._testClass.CheckProperty(x => x.SecurityStamp);
    }

    /// <summary>
    /// Checks that setting the ConcurrencyStamp property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetConcurrencyStamp()
    {
        this._testClass.CheckProperty(x => x.ConcurrencyStamp);
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
    /// Checks that setting the PhoneNumberConfirmed property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPhoneNumberConfirmed()
    {
        this._testClass.CheckProperty(x => x.PhoneNumberConfirmed);
    }

    /// <summary>
    /// Checks that setting the TwoFactorEnabled property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTwoFactorEnabled()
    {
        this._testClass.CheckProperty(x => x.TwoFactorEnabled);
    }

    /// <summary>
    /// Checks that setting the LockoutEnd property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLockoutEnd()
    {
        this._testClass.CheckProperty(x => x.LockoutEnd, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow);
    }

    /// <summary>
    /// Checks that setting the LockoutEnabled property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLockoutEnabled()
    {
        this._testClass.CheckProperty(x => x.LockoutEnabled);
    }

    /// <summary>
    /// Checks that setting the AccessFailedCount property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccessFailedCount()
    {
        this._testClass.CheckProperty(x => x.AccessFailedCount);
    }

    /// <summary>
    /// Checks that setting the RegistrationCompleted property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRegistrationCompleted()
    {
        this._testClass.CheckProperty(x => x.RegistrationCompleted);
    }

    /// <summary>
    /// Checks that setting the IsLockedOut property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsLockedOut()
    {
        this._testClass.CheckProperty(x => x.IsLockedOut);
    }
}