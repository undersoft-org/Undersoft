using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Sql;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="SqlAccessor"/>.
/// </summary>
public class SqlAccessorTests
{
    private SqlAccessor _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SqlAccessor"/>.
    /// </summary>
    public SqlAccessorTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<SqlAccessor>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SqlAccessor();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var sqlConnectString = _fixture.Create<string>();
        var sqlQry = _fixture.Create<string>();
        var tableName = _fixture.Create<string>();
        var keyNames = _fixture.Create<ISeries<string>>();

        // Act
        var result = this._testClass.Get(sqlConnectString, sqlQry, tableName, keyNames
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the keyNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithNullKeyNames()
    {
        FluentActions.Invoking(() => this._testClass.Get(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), default(ISeries<string>))).Should().Throw<ArgumentNullException>().WithParameterName("keyNames");
    }

    /// <summary>
    /// Checks that the Get method throws when the sqlConnectString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetWithInvalidSqlConnectString(string value)
    {
        FluentActions.Invoking(() => this._testClass.Get(value, _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ISeries<string>>())).Should().Throw<ArgumentNullException>().WithParameterName("sqlConnectString");
    }

    /// <summary>
    /// Checks that the Get method throws when the sqlQry parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetWithInvalidSqlQry(string value)
    {
        FluentActions.Invoking(() => this._testClass.Get(_fixture.Create<string>(), value, _fixture.Create<string>(), _fixture.Create<ISeries<string>>())).Should().Throw<ArgumentNullException>().WithParameterName("sqlQry");
    }

    /// <summary>
    /// Checks that the Get method throws when the tableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetWithInvalidTableName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Get(_fixture.Create<string>(), _fixture.Create<string>(), value, _fixture.Create<ISeries<string>>())).Should().Throw<ArgumentNullException>().WithParameterName("tableName");
    }

    /// <summary>
    /// Checks that the GetSqlDataTable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSqlDataTableWithParameters()
    {
        // Arrange
        var parameters = _fixture.Create<object>();

        // Act
        var result = this._testClass.GetSqlDataTable(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSqlDataTable method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetSqlDataTableWithParametersWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.GetSqlDataTable(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the GetSqlDataTable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSqlDataTableWithCmd()
    {
        // Arrange
        var cmd = _fixture.Create<SqlCommand>();

        // Act
        var result = this._testClass.GetSqlDataTable(cmd);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSqlDataTable method throws when the cmd parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetSqlDataTableWithCmdWithNullCmd()
    {
        FluentActions.Invoking(() => this._testClass.GetSqlDataTable(default(SqlCommand))).Should().Throw<ArgumentNullException>().WithParameterName("cmd");
    }

    /// <summary>
    /// Checks that the GetSqlDataTable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSqlDataTableWithQryAndCn()
    {
        // Arrange
        var qry = _fixture.Create<string>();
        var cn = _fixture.Create<SqlConnection>();

        // Act
        var result = this._testClass.GetSqlDataTable(qry, cn);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSqlDataTable method throws when the cn parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetSqlDataTableWithQryAndCnWithNullCn()
    {
        FluentActions.Invoking(() => this._testClass.GetSqlDataTable(_fixture.Create<string>(), default(SqlConnection))).Should().Throw<ArgumentNullException>().WithParameterName("cn");
    }

    /// <summary>
    /// Checks that the GetSqlDataTable method throws when the qry parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetSqlDataTableWithQryAndCnWithInvalidQry(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetSqlDataTable(value, _fixture.Create<SqlConnection>())).Should().Throw<ArgumentNullException>().WithParameterName("qry");
    }
}