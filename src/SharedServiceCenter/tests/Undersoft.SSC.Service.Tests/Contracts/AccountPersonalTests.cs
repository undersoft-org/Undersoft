using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Tests.Contracts;

/// <summary>
/// Unit tests for the type <see cref="AccountPersonal"/>.
/// </summary>
[TestClass]
public class AccountPersonalTests
{
    private AccountPersonal _testClass;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountPersonal"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        this._testClass = new AccountPersonal();
    }

    /// <summary>
    /// Checks that setting the FirstName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFirstName()
    {
        this._testClass.CheckProperty(x => x.FirstName);
    }

    /// <summary>
    /// Checks that setting the LastName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLastName()
    {
        this._testClass.CheckProperty(x => x.LastName);
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
    /// Checks that setting the Birthdate property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBirthdate()
    {
        this._testClass.CheckProperty(x => x.Birthdate);
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
    /// Checks that setting the AccountId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAccountId()
    {
        this._testClass.CheckProperty(x => x.AccountId, 888741711L, 1253043622L);
    }
}