using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Sql;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="InstantSqlContext"/>.
/// </summary>
public class InstantSqlContextTests
{
    private InstantSqlContext _testClass;
    private IFixture _fixture;
    private InstantSqlOptions _identity;
    private string _connectionString;
    private Mock<IConfiguration> _configuration;
    private string _connectionName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSqlContext"/>.
    /// </summary>
    public InstantSqlContextTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._identity = _fixture.Create<InstantSqlOptions>();
        this._connectionString = _fixture.Create<string>();
        this._configuration = _fixture.Freeze<Mock<IConfiguration>>();
        this._connectionName = _fixture.Create<string>();
        this._testClass = _fixture.Create<InstantSqlContext>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSqlContext(this._identity);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSqlContext(this._connectionString);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSqlContext(this._configuration.Object, this._connectionName);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSqlContext(this._configuration.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the identity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullIdentity()
    {
        FluentActions.Invoking(() => new InstantSqlContext(default(InstantSqlOptions))).Should().Throw<ArgumentNullException>().WithParameterName("identity");
    }

    /// <summary>
    /// Checks that instance construction throws when the configuration parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullConfiguration()
    {
        FluentActions.Invoking(() => new InstantSqlContext(default(IConfiguration), this._connectionName)).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
        FluentActions.Invoking(() => new InstantSqlContext(default(IConfiguration))).Should().Throw<ArgumentNullException>().WithParameterName("configuration");
    }

    /// <summary>
    /// Checks that the constructor throws when the connectionString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidConnectionString(string value)
    {
        FluentActions.Invoking(() => new InstantSqlContext(value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionString");
    }

    /// <summary>
    /// Checks that the constructor throws when the connectionName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidConnectionName(string value)
    {
        FluentActions.Invoking(() => new InstantSqlContext(this._configuration.Object, value)).Should().Throw<ArgumentNullException>().WithParameterName("connectionName");
    }
}