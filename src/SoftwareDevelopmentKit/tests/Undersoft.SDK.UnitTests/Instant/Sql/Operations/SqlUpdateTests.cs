using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Sql;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="SqlUpdate"/>.
/// </summary>
public class SqlUpdateTests
{
    private SqlUpdate _testClass;
    private IFixture _fixture;
    private SqlConnection _cn;
    private string _cnstring;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SqlUpdate"/>.
    /// </summary>
    public SqlUpdateTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._cn = _fixture.Create<SqlConnection>();
        this._cnstring = _fixture.Create<string>();
        this._testClass = _fixture.Create<SqlUpdate>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SqlUpdate(this._cn);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SqlUpdate(this._cnstring);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the cn parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCn()
    {
        FluentActions.Invoking(() => new SqlUpdate(default(SqlConnection))).Should().Throw<ArgumentNullException>().WithParameterName("cn");
    }

    /// <summary>
    /// Checks that the constructor throws when the cnstring parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidCnstring(string value)
    {
        FluentActions.Invoking(() => new SqlUpdate(value)).Should().Throw<ArgumentNullException>().WithParameterName("cnstring");
    }

    /// <summary>
    /// Checks that the BatchUpdate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBatchUpdate()
    {
        // Arrange
        var table = _fixture.Create<IInstantSeries>();
        var keysFromDeck = _fixture.Create<bool>();
        var buildMapping = _fixture.Create<bool>();
        var updateKeys = _fixture.Create<bool>();
        var updateExcept = _fixture.Create<string[]>();
        var batchSize = _fixture.Create<int>();

        // Act
        var result = this._testClass.BatchUpdate(table, keysFromDeck, buildMapping, updateKeys, updateExcept, batchSize);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BatchUpdate method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBatchUpdateWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.BatchUpdate(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<string[]>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that the BatchUpdateQuery method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBatchUpdateQuery()
    {
        // Arrange
        var card = _fixture.Create<IInstant>();
        var tableName = _fixture.Create<string>();
        var columns = _fixture.Create<MemberRubric[]>();
        var keys = _fixture.Create<MemberRubric[]>();
        var updateKeys = _fixture.Create<bool>();

        // Act
        var result = this._testClass.BatchUpdateQuery(card, tableName, columns, keys, updateKeys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BatchUpdateQuery method throws when the card parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBatchUpdateQueryWithNullCard()
    {
        FluentActions.Invoking(() => this._testClass.BatchUpdateQuery(default(IInstant), _fixture.Create<string>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("card");
    }

    /// <summary>
    /// Checks that the BatchUpdateQuery method throws when the columns parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBatchUpdateQueryWithNullColumns()
    {
        FluentActions.Invoking(() => this._testClass.BatchUpdateQuery(_fixture.Create<IInstant>(), _fixture.Create<string>(), default(MemberRubric[]), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("columns");
    }

    /// <summary>
    /// Checks that the BatchUpdateQuery method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBatchUpdateQueryWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.BatchUpdateQuery(_fixture.Create<IInstant>(), _fixture.Create<string>(), _fixture.Create<MemberRubric[]>(), default(MemberRubric[]), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the BatchUpdateQuery method throws when the tableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBatchUpdateQueryWithInvalidTableName(string value)
    {
        FluentActions.Invoking(() => this._testClass.BatchUpdateQuery(_fixture.Create<IInstant>(), value, _fixture.Create<MemberRubric[]>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("tableName");
    }

    /// <summary>
    /// Checks that the BulkUpdate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBulkUpdate()
    {
        // Arrange
        var table = _fixture.Create<IInstantSeries>();
        var keysFromDeck = _fixture.Create<bool>();
        var buildMapping = _fixture.Create<bool>();
        var updateKeys = _fixture.Create<bool>();
        var updateExcept = _fixture.Create<string[]>();
        var tempType = _fixture.Create<BulkPrepareType>();

        // Act
        var result = this._testClass.BulkUpdate(table, keysFromDeck, buildMapping, updateKeys, updateExcept, tempType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BulkUpdate method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBulkUpdateWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.BulkUpdate(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<string[]>(), _fixture.Create<BulkPrepareType>())).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that the BulkUpdateQuery method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBulkUpdateQuery()
    {
        // Arrange
        var DBName = _fixture.Create<string>();
        var buforName = _fixture.Create<string>();
        var tableName = _fixture.Create<string>();
        var columns = _fixture.Create<MemberRubric[]>();
        var keys = _fixture.Create<MemberRubric[]>();
        var updateKeys = _fixture.Create<bool>();

        // Act
        var result = this._testClass.BulkUpdateQuery(DBName, buforName, tableName, columns, keys, updateKeys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BulkUpdateQuery method throws when the columns parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBulkUpdateQueryWithNullColumns()
    {
        FluentActions.Invoking(() => this._testClass.BulkUpdateQuery(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), default(MemberRubric[]), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("columns");
    }

    /// <summary>
    /// Checks that the BulkUpdateQuery method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBulkUpdateQueryWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.BulkUpdateQuery(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<MemberRubric[]>(), default(MemberRubric[]), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the BulkUpdateQuery method throws when the DBName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBulkUpdateQueryWithInvalidDBName(string value)
    {
        FluentActions.Invoking(() => this._testClass.BulkUpdateQuery(value, _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("DBName");
    }

    /// <summary>
    /// Checks that the BulkUpdateQuery method throws when the buforName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBulkUpdateQueryWithInvalidBuforName(string value)
    {
        FluentActions.Invoking(() => this._testClass.BulkUpdateQuery(_fixture.Create<string>(), value, _fixture.Create<string>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("buforName");
    }

    /// <summary>
    /// Checks that the BulkUpdateQuery method throws when the tableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBulkUpdateQueryWithInvalidTableName(string value)
    {
        FluentActions.Invoking(() => this._testClass.BulkUpdateQuery(_fixture.Create<string>(), _fixture.Create<string>(), value, _fixture.Create<MemberRubric[]>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("tableName");
    }

    /// <summary>
    /// Checks that the SimpleUpdate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSimpleUpdate()
    {
        // Arrange
        var table = _fixture.Create<IInstantSeries>();
        var buildMapping = _fixture.Create<bool>();
        var updateKeys = _fixture.Create<bool>();
        var updateExcept = _fixture.Create<string[]>();
        var batchSize = _fixture.Create<int>();

        // Act
        var result = this._testClass.SimpleUpdate(table, buildMapping, updateKeys, updateExcept, batchSize);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SimpleUpdate method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSimpleUpdateWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.SimpleUpdate(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<string[]>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that the Update method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdate()
    {
        // Arrange
        var table = _fixture.Create<IInstantSeries>();
        var keysFromDeck = _fixture.Create<bool>();
        var buildMapping = _fixture.Create<bool>();
        var updateKeys = _fixture.Create<bool>();
        var updateExcept = _fixture.Create<string[]>();
        var tempType = _fixture.Create<BulkPrepareType>();

        // Act
        var result = this._testClass.Update(table, keysFromDeck, buildMapping, updateKeys, updateExcept, tempType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Update method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.Update(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<string[]>(), _fixture.Create<BulkPrepareType>())).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }
}