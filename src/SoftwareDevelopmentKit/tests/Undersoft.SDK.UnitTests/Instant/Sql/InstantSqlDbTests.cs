using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Sql;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="InstantSqlDb"/>.
/// </summary>
public class InstantSqlDbTests
{
    private InstantSqlDb _testClass;
    private IFixture _fixture;
    private SqlConnection _sqlDbConnection;
    private InstantSqlOptions _sqlIdentity;
    private string _sqlConnectionString;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSqlDb"/>.
    /// </summary>
    public InstantSqlDbTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._sqlDbConnection = _fixture.Create<SqlConnection>();
        this._sqlIdentity = _fixture.Create<InstantSqlOptions>();
        this._sqlConnectionString = _fixture.Create<string>();
        this._testClass = _fixture.Create<InstantSqlDb>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSqlDb(this._sqlDbConnection);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSqlDb(this._sqlIdentity);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSqlDb(this._sqlConnectionString);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the SqlDbConnection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSqlDbConnection()
    {
        FluentActions.Invoking(() => new InstantSqlDb(default(SqlConnection))).Should().Throw<ArgumentNullException>().WithParameterName("SqlDbConnection");
    }

    /// <summary>
    /// Checks that instance construction throws when the sqlIdentity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSqlIdentity()
    {
        FluentActions.Invoking(() => new InstantSqlDb(default(InstantSqlOptions))).Should().Throw<ArgumentNullException>().WithParameterName("sqlIdentity");
    }

    /// <summary>
    /// Checks that the constructor throws when the SqlConnectionString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidSqlConnectionString(string value)
    {
        FluentActions.Invoking(() => new InstantSqlDb(value)).Should().Throw<ArgumentNullException>().WithParameterName("SqlConnectionString");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var sqlQry = _fixture.Create<string>();
        var tableName = _fixture.Create<string>();
        var keyNames = _fixture.Create<ISeries<string>>();

        // Act
        var result = this._testClass.Get(sqlQry, tableName, keyNames);

        // Assert
        Assert.Fail("Create or modify test");
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
        FluentActions.Invoking(() => this._testClass.Get(value, _fixture.Create<string>(), _fixture.Create<ISeries<string>>())).Should().Throw<ArgumentNullException>().WithParameterName("sqlQry");
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
        FluentActions.Invoking(() => this._testClass.Get(_fixture.Create<string>(), value, _fixture.Create<ISeries<string>>())).Should().Throw<ArgumentNullException>().WithParameterName("tableName");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAdd()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();

        // Act
        var result = this._testClass.Add(cards);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the BatchDelete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBatchDelete()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();
        var buildMapping = _fixture.Create<bool>();

        // Act
        var result = this._testClass.BatchDelete(cards, buildMapping);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BatchDelete method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBatchDeleteWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.BatchDelete(default(IInstantSeries), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the BatchInsert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBatchInsert()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();
        var buildMapping = _fixture.Create<bool>();

        // Act
        var result = this._testClass.BatchInsert(cards, buildMapping);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BatchInsert method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBatchInsertWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.BatchInsert(default(IInstantSeries), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the BatchUpdate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBatchUpdate()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();
        var keysFromDeck = _fixture.Create<bool>();
        var buildMapping = _fixture.Create<bool>();
        var updateKeys = _fixture.Create<bool>();
        var updateExcept = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.BatchUpdate(cards, keysFromDeck, buildMapping, updateKeys, updateExcept);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BatchUpdate method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBatchUpdateWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.BatchUpdate(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<string[]>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the BulkDelete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBulkDelete()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();
        var keysFromDeck = _fixture.Create<bool>();
        var buildMapping = _fixture.Create<bool>();
        var tempType = _fixture.Create<BulkPrepareType>();

        // Act
        var result = this._testClass.BulkDelete(cards, keysFromDeck, buildMapping, tempType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BulkDelete method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBulkDeleteWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.BulkDelete(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<BulkPrepareType>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the BulkInsert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBulkInsert()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();
        var keysFromDeck = _fixture.Create<bool>();
        var buildMapping = _fixture.Create<bool>();
        var tempType = _fixture.Create<BulkPrepareType>();

        // Act
        var result = this._testClass.BulkInsert(cards, keysFromDeck, buildMapping, tempType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BulkInsert method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBulkInsertWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.BulkInsert(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<BulkPrepareType>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the BulkUpdate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBulkUpdate()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();
        var keysFromDeck = _fixture.Create<bool>();
        var buildMapping = _fixture.Create<bool>();
        var updateKeys = _fixture.Create<bool>();
        var updateExcept = _fixture.Create<string[]>();
        var tempType = _fixture.Create<BulkPrepareType>();

        // Act
        var result = this._testClass.BulkUpdate(cards, keysFromDeck, buildMapping, updateKeys, updateExcept, tempType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BulkUpdate method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBulkUpdateWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.BulkUpdate(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<string[]>(), _fixture.Create<BulkPrepareType>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteWithIInstantSeries()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();

        // Act
        var result = this._testClass.Delete(cards);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Delete method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteWithIInstantSeriesWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.Delete(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the Delete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteWithIInstantSeriesAndBoolAndBoolAndBulkPrepareType()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();
        var keysFromDeck = _fixture.Create<bool>();
        var buildMapping = _fixture.Create<bool>();
        var tempType = _fixture.Create<BulkPrepareType>();

        // Act
        var result = this._testClass.Delete(cards, keysFromDeck, buildMapping, tempType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Delete method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteWithIInstantSeriesAndBoolAndBoolAndBulkPrepareTypeWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.Delete(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<BulkPrepareType>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the Execute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExecute()
    {
        // Arrange
        var query = _fixture.Create<string>();

        // Act
        var result = this._testClass.Execute(query);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Execute method throws when the query parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallExecuteWithInvalidQuery(string value)
    {
        FluentActions.Invoking(() => this._testClass.Execute(value)).Should().Throw<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that the Insert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsert()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();
        var keysFromDeck = _fixture.Create<bool>();
        var buildMapping = _fixture.Create<bool>();
        var tempType = _fixture.Create<BulkPrepareType>();

        // Act
        var result = this._testClass.Insert(cards, keysFromDeck, buildMapping, tempType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Insert method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInsertWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.Insert(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<BulkPrepareType>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the Mapper method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapper()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();
        var keysFromDeck = _fixture.Create<bool>();
        var dbTableNames = _fixture.Create<string[]>();
        var tablePrefix = _fixture.Create<string>();

        // Act
        var result = this._testClass.Mapper(cards, keysFromDeck, dbTableNames, tablePrefix);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Mapper method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapperWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.Mapper(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<string[]>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the Mapper method throws when the tablePrefix parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallMapperWithInvalidTablePrefix(string value)
    {
        FluentActions.Invoking(() => this._testClass.Mapper(_fixture.Create<IInstantSeries>(), _fixture.Create<bool>(), _fixture.Create<string[]>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("tablePrefix");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPut()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();

        // Act
        var result = this._testClass.Put(cards);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the SimpleDelete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSimpleDeleteWithIInstantSeries()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();

        // Act
        var result = this._testClass.SimpleDelete(cards);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SimpleDelete method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSimpleDeleteWithIInstantSeriesWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.SimpleDelete(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the SimpleDelete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSimpleDeleteWithIInstantSeriesAndBool()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();
        var buildMapping = _fixture.Create<bool>();

        // Act
        var result = this._testClass.SimpleDelete(cards, buildMapping);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SimpleDelete method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSimpleDeleteWithIInstantSeriesAndBoolWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.SimpleDelete(default(IInstantSeries), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the SimpleInsert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSimpleInsertWithIInstantSeries()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();

        // Act
        var result = this._testClass.SimpleInsert(cards);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SimpleInsert method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSimpleInsertWithIInstantSeriesWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.SimpleInsert(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the SimpleInsert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSimpleInsertWithIInstantSeriesAndBool()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();
        var buildMapping = _fixture.Create<bool>();

        // Act
        var result = this._testClass.SimpleInsert(cards, buildMapping);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SimpleInsert method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSimpleInsertWithIInstantSeriesAndBoolWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.SimpleInsert(default(IInstantSeries), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the SimpleUpdate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSimpleUpdate()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();
        var buildMapping = _fixture.Create<bool>();
        var updateKeys = _fixture.Create<bool>();
        var updateExcept = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.SimpleUpdate(cards, buildMapping, updateKeys, updateExcept);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SimpleUpdate method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSimpleUpdateWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.SimpleUpdate(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<string[]>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the Update method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdate()
    {
        // Arrange
        var cards = _fixture.Create<IInstantSeries>();
        var keysFromDeck = _fixture.Create<bool>();
        var buildMapping = _fixture.Create<bool>();
        var updateKeys = _fixture.Create<bool>();
        var updateExcept = _fixture.Create<string[]>();
        var tempType = _fixture.Create<BulkPrepareType>();

        // Act
        var result = this._testClass.Update(cards, keysFromDeck, buildMapping, updateKeys, updateExcept, tempType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Update method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.Update(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<string[]>(), _fixture.Create<BulkPrepareType>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }
}

/// <summary>
/// Unit tests for the type <see cref="SqlException"/>.
/// </summary>
public class SqlExceptionTests
{
    private SqlException _testClass;
    private IFixture _fixture;
    private string _message;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SqlException"/>.
    /// </summary>
    public SqlExceptionTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._message = _fixture.Create<string>();
        this._testClass = _fixture.Create<SqlException>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SqlException(this._message);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => new SqlException(value)).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }
}