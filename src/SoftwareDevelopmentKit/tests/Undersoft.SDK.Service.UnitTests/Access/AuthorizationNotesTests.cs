using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Access;

namespace Undersoft.SDK.Service.UnitTests.Access;

/// <summary>
/// Unit tests for the type <see cref="AuthorizationNotes"/>.
/// </summary>
public class AuthorizationNotesTests
{
    private AuthorizationNotes _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AuthorizationNotes"/>.
    /// </summary>
    public AuthorizationNotesTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AuthorizationNotes>();
    }

    /// <summary>
    /// Checks that setting the Errors property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetErrors()
    {
        this._testClass.CheckProperty(x => x.Errors);
    }

    /// <summary>
    /// Checks that setting the Success property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSuccess()
    {
        this._testClass.CheckProperty(x => x.Success);
    }

    /// <summary>
    /// Checks that setting the Info property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInfo()
    {
        this._testClass.CheckProperty(x => x.Info);
    }

    /// <summary>
    /// Checks that setting the Status property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetStatus()
    {
        this._testClass.CheckProperty(x => x.Status, _fixture.Create<SigningStatus>(), _fixture.Create<SigningStatus>());
    }

    /// <summary>
    /// Checks that the IsSuccess property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIsSuccess()
    {
        // Assert
        this._testClass.IsSuccess.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }
}