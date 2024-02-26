using System;
using System.Security.Claims;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Application.Access;

namespace Undersoft.SDK.Service.Application.UnitTests.Access;

/// <summary>
/// Unit tests for the type <see cref="AccessState"/>.
/// </summary>
[TestClass]
public class AccessStateTests
{
    private AccessState _testClass;
    private IFixture _fixture;
    private ClaimsPrincipal _user;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccessState"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._user = _fixture.Create<ClaimsPrincipal>();
        this._testClass = _fixture.Create<AccessState>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccessState(this._user);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the user parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullUser()
    {
        FluentActions.Invoking(() => new AccessState(default(ClaimsPrincipal))).Should().Throw<ArgumentNullException>().WithParameterName("user");
    }
}