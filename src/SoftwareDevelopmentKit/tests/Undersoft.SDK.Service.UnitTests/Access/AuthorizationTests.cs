using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Access;

namespace Undersoft.SDK.Service.UnitTests.Access;

/// <summary>
/// Unit tests for the type <see cref="Authorization"/>.
/// </summary>
public class AuthorizationTests
{
    private Authorization _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Authorization"/>.
    /// </summary>
    public AuthorizationTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Authorization>();
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMap()
    {
        // Arrange
        var user = _fixture.Create<object>();

        // Act
        this._testClass.Map(user);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method throws when the user parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithNullUser()
    {
        FluentActions.Invoking(() => this._testClass.Map(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("user");
    }

    /// <summary>
    /// Checks that setting the Credentials property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCredentials()
    {
        this._testClass.CheckProperty(x => x.Credentials, _fixture.Create<Credentials>(), _fixture.Create<Credentials>());
    }

    /// <summary>
    /// Checks that setting the Notes property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNotes()
    {
        this._testClass.CheckProperty(x => x.Notes, _fixture.Create<AuthorizationNotes>(), _fixture.Create<AuthorizationNotes>());
    }

    /// <summary>
    /// Checks that setting the IsAvailable property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsAvailable()
    {
        this._testClass.CheckProperty(x => x.IsAvailable);
    }

    /// <summary>
    /// Checks that setting the Authenticated property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAuthenticated()
    {
        this._testClass.CheckProperty(x => x.Authenticated);
    }
}