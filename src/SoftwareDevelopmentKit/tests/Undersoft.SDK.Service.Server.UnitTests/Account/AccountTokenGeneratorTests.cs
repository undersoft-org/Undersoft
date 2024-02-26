using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountTokenGenerator"/>.
/// </summary>
[TestClass]
public class AccountTokenGeneratorTests
{
    private AccountTokenGenerator _testClass;
    private IFixture _fixture;
    private Action<AccountTokenOptions> _builder;
    private int _minutesToExpire;
    private AccountTokenOptions _jwtOptions;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountTokenGenerator"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._builder = x => { };
        this._minutesToExpire = _fixture.Create<int>();
        this._jwtOptions = _fixture.Create<AccountTokenOptions>();
        this._testClass = _fixture.Create<AccountTokenGenerator>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AccountTokenGenerator(this._builder);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new AccountTokenGenerator(this._minutesToExpire, this._jwtOptions);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Generate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGenerateWithClaims()
    {
        // Arrange
        var claims = _fixture.Create<IEnumerable<Claim>>();

        // Act
        var result = this._testClass.Generate(claims);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Generate method throws when the claims parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGenerateWithClaimsWithNullClaims()
    {
        FluentActions.Invoking(() => this._testClass.Generate(default(IEnumerable<Claim>))).Should().Throw<ArgumentNullException>().WithParameterName("claims");
    }

    /// <summary>
    /// Checks that the Generate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGenerateWithDictionaryOfStringAndString()
    {
        // Arrange
        var claimsIdentity = _fixture.Create<Dictionary<string, string>>();

        // Act
        var result = this._testClass.Generate(claimsIdentity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Generate method throws when the claimsIdentity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGenerateWithDictionaryOfStringAndStringWithNullClaimsIdentity()
    {
        FluentActions.Invoking(() => this._testClass.Generate(default(Dictionary<string, string>))).Should().Throw<ArgumentNullException>().WithParameterName("claimsIdentity");
    }

    /// <summary>
    /// Checks that the Generate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGenerateWithClaimsIdentity()
    {
        // Arrange
        var claimsIdentity = _fixture.Create<ClaimsIdentity>();

        // Act
        var result = this._testClass.Generate(claimsIdentity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Generate method throws when the claimsIdentity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGenerateWithClaimsIdentityWithNullClaimsIdentity()
    {
        FluentActions.Invoking(() => this._testClass.Generate(default(ClaimsIdentity))).Should().Throw<ArgumentNullException>().WithParameterName("claimsIdentity");
    }

    /// <summary>
    /// Checks that the Validate method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallValidateAsync()
    {
        // Arrange
        var token = _fixture.Create<string>();

        // Act
        var result = await this._testClass.Validate(token);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Validate method throws when the token parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    /// <returns>A task that represents the running test.</returns>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public async Task CannotCallValidateWithInvalidTokenAsync(string value)
    {
        await FluentActions.Invoking(() => this._testClass.Validate(value)).Should().ThrowAsync<ArgumentNullException>().WithParameterName("token");
    }
}