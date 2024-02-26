using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountMappings"/>.
/// </summary>
[TestClass]
public class AccountMappingsTests
{
    private AccountMappings _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountMappings"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountMappings>();
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Arrange
        var builder = _fixture.Create<EntityTypeBuilder<Account>>();

        // Act
        this._testClass.Configure(builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.Configure(default(EntityTypeBuilder<Account>))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }
}

/// <summary>
/// Unit tests for the type <see cref="RolemMappings"/>.
/// </summary>
[TestClass]
public class RolemMappingsTests
{
    private RolemMappings _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RolemMappings"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RolemMappings>();
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Arrange
        var builder = _fixture.Create<EntityTypeBuilder<Role>>();

        // Act
        this._testClass.Configure(builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.Configure(default(EntityTypeBuilder<Role>))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }
}

/// <summary>
/// Unit tests for the type <see cref="AccountPersonalMappings"/>.
/// </summary>
[TestClass]
public class AccountPersonalMappingsTests
{
    private AccountPersonalMappings _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountPersonalMappings"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountPersonalMappings>();
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Arrange
        var builder = _fixture.Create<EntityTypeBuilder<AccountPersonal>>();

        // Act
        this._testClass.Configure(builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.Configure(default(EntityTypeBuilder<AccountPersonal>))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }
}

/// <summary>
/// Unit tests for the type <see cref="AccountTokenMappings"/>.
/// </summary>
[TestClass]
public class AccountTokenMappingsTests
{
    private AccountTokenMappings _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountTokenMappings"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountTokenMappings>();
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Arrange
        var builder = _fixture.Create<EntityTypeBuilder<AccountToken>>();

        // Act
        this._testClass.Configure(builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.Configure(default(EntityTypeBuilder<AccountToken>))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }
}

/// <summary>
/// Unit tests for the type <see cref="AccountProffesionalMappings"/>.
/// </summary>
[TestClass]
public class AccountProffesionalMappingsTests
{
    private AccountProffesionalMappings _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountProffesionalMappings"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountProffesionalMappings>();
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Arrange
        var builder = _fixture.Create<EntityTypeBuilder<AccountProffesional>>();

        // Act
        this._testClass.Configure(builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.Configure(default(EntityTypeBuilder<AccountProffesional>))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }
}

/// <summary>
/// Unit tests for the type <see cref="AccountOrganizationsMappings"/>.
/// </summary>
[TestClass]
public class AccountOrganizationsMappingsTests
{
    private AccountOrganizationsMappings _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountOrganizationsMappings"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountOrganizationsMappings>();
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Arrange
        var builder = _fixture.Create<EntityTypeBuilder<AccountOrganization>>();

        // Act
        this._testClass.Configure(builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.Configure(default(EntityTypeBuilder<AccountOrganization>))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }
}

/// <summary>
/// Unit tests for the type <see cref="AccountSubscriptionsMappings"/>.
/// </summary>
[TestClass]
public class AccountSubscriptionsMappingsTests
{
    private AccountSubscriptionsMappings _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountSubscriptionsMappings"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountSubscriptionsMappings>();
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Arrange
        var builder = _fixture.Create<EntityTypeBuilder<AccountSubscription>>();

        // Act
        this._testClass.Configure(builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.Configure(default(EntityTypeBuilder<AccountSubscription>))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }
}

/// <summary>
/// Unit tests for the type <see cref="AccountConsentsMappings"/>.
/// </summary>
[TestClass]
public class AccountConsentsMappingsTests
{
    private AccountConsentsMappings _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountConsentsMappings"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountConsentsMappings>();
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Arrange
        var builder = _fixture.Create<EntityTypeBuilder<AccountConsent>>();

        // Act
        this._testClass.Configure(builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.Configure(default(EntityTypeBuilder<AccountConsent>))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }
}

/// <summary>
/// Unit tests for the type <see cref="AccountPaymentsMappings"/>.
/// </summary>
[TestClass]
public class AccountPaymentsMappingsTests
{
    private AccountPaymentsMappings _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AccountPaymentsMappings"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AccountPaymentsMappings>();
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Arrange
        var builder = _fixture.Create<EntityTypeBuilder<AccountPayment>>();

        // Act
        this._testClass.Configure(builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.Configure(default(EntityTypeBuilder<AccountPayment>))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }
}