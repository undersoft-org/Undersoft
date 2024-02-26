using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Sql;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="SqlMutator"/>.
/// </summary>
public class SqlMutatorTests
{
    private SqlMutator _testClass;
    private IFixture _fixture;
    private InstantSqlDb _sqldb;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SqlMutator"/>.
    /// </summary>
    public SqlMutatorTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._sqldb = _fixture.Create<InstantSqlDb>();
        this._testClass = _fixture.Create<SqlMutator>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SqlMutator();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SqlMutator(this._sqldb);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the sqldb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSqldb()
    {
        FluentActions.Invoking(() => new SqlMutator(default(InstantSqlDb))).Should().Throw<ArgumentNullException>().WithParameterName("sqldb");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDelete()
    {
        // Arrange
        var SqlConnectString = _fixture.Create<string>();
        var series = _fixture.Create<IInstantSeries>();

        // Act
        var result = this._testClass.Delete(SqlConnectString, series);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Delete method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteWithNullSeries()
    {
        FluentActions.Invoking(() => this._testClass.Delete(_fixture.Create<string>(), default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the Delete method throws when the SqlConnectString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallDeleteWithInvalidSqlConnectString(string value)
    {
        FluentActions.Invoking(() => this._testClass.Delete(value, _fixture.Create<IInstantSeries>())).Should().Throw<ArgumentNullException>().WithParameterName("SqlConnectString");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSet()
    {
        // Arrange
        var SqlConnectString = _fixture.Create<string>();
        var series = _fixture.Create<IInstantSeries>();
        var renew = _fixture.Create<bool>();

        // Act
        var result = this._testClass.Set(SqlConnectString, series, renew);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the series parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithNullSeries()
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<string>(), default(IInstantSeries), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("series");
    }

    /// <summary>
    /// Checks that the Set method throws when the SqlConnectString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetWithInvalidSqlConnectString(string value)
    {
        FluentActions.Invoking(() => this._testClass.Set(value, _fixture.Create<IInstantSeries>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("SqlConnectString");
    }
}