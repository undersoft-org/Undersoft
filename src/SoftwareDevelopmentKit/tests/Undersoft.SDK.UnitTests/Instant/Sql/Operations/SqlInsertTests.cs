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
/// Unit tests for the type <see cref="SqlInsert"/>.
/// </summary>
public class SqlInsertTests
{
    private SqlInsert _testClass;
    private IFixture _fixture;
    private SqlConnection _cn;
    private string _cnstring;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SqlInsert"/>.
    /// </summary>
    public SqlInsertTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._cn = _fixture.Create<SqlConnection>();
        this._cnstring = _fixture.Create<string>();
        this._testClass = _fixture.Create<SqlInsert>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SqlInsert(this._cn);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SqlInsert(this._cnstring);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the cn parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCn()
    {
        FluentActions.Invoking(() => new SqlInsert(default(SqlConnection))).Should().Throw<ArgumentNullException>().WithParameterName("cn");
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
        FluentActions.Invoking(() => new SqlInsert(value)).Should().Throw<ArgumentNullException>().WithParameterName("cnstring");
    }

    /// <summary>
    /// Checks that the BatchInsert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBatchInsertWithIInstantSeriesAndBoolAndInt()
    {
        // Arrange
        var table = _fixture.Create<IInstantSeries>();
        var buildMapping = _fixture.Create<bool>();
        var batchSize = _fixture.Create<int>();

        // Act
        var result = this._testClass.BatchInsert(table, buildMapping, batchSize);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BatchInsert method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBatchInsertWithIInstantSeriesAndBoolAndIntWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.BatchInsert(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that the BatchInsert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBatchInsertWithIInstantSeriesAndInt()
    {
        // Arrange
        var table = _fixture.Create<IInstantSeries>();
        var batchSize = _fixture.Create<int>();

        // Act
        var result = this._testClass.BatchInsert(table, batchSize);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BatchInsert method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBatchInsertWithIInstantSeriesAndIntWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.BatchInsert(default(IInstantSeries), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that the BatchInsertQuery method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBatchInsertQuery()
    {
        // Arrange
        var card = _fixture.Create<IInstant>();
        var tableName = _fixture.Create<string>();
        var columns = _fixture.Create<MemberRubric[]>();
        var keys = _fixture.Create<MemberRubric[]>();
        var updateKeys = _fixture.Create<bool>();

        // Act
        var result = this._testClass.BatchInsertQuery(card, tableName, columns, keys, updateKeys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BatchInsertQuery method throws when the card parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBatchInsertQueryWithNullCard()
    {
        FluentActions.Invoking(() => this._testClass.BatchInsertQuery(default(IInstant), _fixture.Create<string>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("card");
    }

    /// <summary>
    /// Checks that the BatchInsertQuery method throws when the columns parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBatchInsertQueryWithNullColumns()
    {
        FluentActions.Invoking(() => this._testClass.BatchInsertQuery(_fixture.Create<IInstant>(), _fixture.Create<string>(), default(MemberRubric[]), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("columns");
    }

    /// <summary>
    /// Checks that the BatchInsertQuery method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBatchInsertQueryWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.BatchInsertQuery(_fixture.Create<IInstant>(), _fixture.Create<string>(), _fixture.Create<MemberRubric[]>(), default(MemberRubric[]), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the BatchInsertQuery method throws when the tableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBatchInsertQueryWithInvalidTableName(string value)
    {
        FluentActions.Invoking(() => this._testClass.BatchInsertQuery(_fixture.Create<IInstant>(), value, _fixture.Create<MemberRubric[]>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("tableName");
    }

    /// <summary>
    /// Checks that the BulkInsert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBulkInsert()
    {
        // Arrange
        var table = _fixture.Create<IInstantSeries>();
        var keysFromDeckis = _fixture.Create<bool>();
        var buildMapping = _fixture.Create<bool>();
        var updateKeys = _fixture.Create<bool>();
        var updateExcept = _fixture.Create<string[]>();
        var tempType = _fixture.Create<BulkPrepareType>();

        // Act
        var result = this._testClass.BulkInsert(table, keysFromDeckis, buildMapping, updateKeys, updateExcept, tempType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BulkInsert method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBulkInsertWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.BulkInsert(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<string[]>(), _fixture.Create<BulkPrepareType>())).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that the BulkInsertQuery method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBulkInsertQuery()
    {
        // Arrange
        var DBName = _fixture.Create<string>();
        var buforName = _fixture.Create<string>();
        var tableName = _fixture.Create<string>();
        var columns = _fixture.Create<MemberRubric[]>();
        var keys = _fixture.Create<MemberRubric[]>();
        var updateKeys = _fixture.Create<bool>();

        // Act
        var result = this._testClass.BulkInsertQuery(DBName, buforName, tableName, columns, keys, updateKeys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BulkInsertQuery method throws when the columns parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBulkInsertQueryWithNullColumns()
    {
        FluentActions.Invoking(() => this._testClass.BulkInsertQuery(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), default(MemberRubric[]), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("columns");
    }

    /// <summary>
    /// Checks that the BulkInsertQuery method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBulkInsertQueryWithNullKeys()
    {
        FluentActions.Invoking(() => this._testClass.BulkInsertQuery(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<MemberRubric[]>(), default(MemberRubric[]), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the BulkInsertQuery method throws when the DBName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBulkInsertQueryWithInvalidDBName(string value)
    {
        FluentActions.Invoking(() => this._testClass.BulkInsertQuery(value, _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("DBName");
    }

    /// <summary>
    /// Checks that the BulkInsertQuery method throws when the buforName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBulkInsertQueryWithInvalidBuforName(string value)
    {
        FluentActions.Invoking(() => this._testClass.BulkInsertQuery(_fixture.Create<string>(), value, _fixture.Create<string>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("buforName");
    }

    /// <summary>
    /// Checks that the BulkInsertQuery method throws when the tableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBulkInsertQueryWithInvalidTableName(string value)
    {
        FluentActions.Invoking(() => this._testClass.BulkInsertQuery(_fixture.Create<string>(), _fixture.Create<string>(), value, _fixture.Create<MemberRubric[]>(), _fixture.Create<MemberRubric[]>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("tableName");
    }

    /// <summary>
    /// Checks that the Insert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsert()
    {
        // Arrange
        var table = _fixture.Create<IInstantSeries>();
        var keysFromDeckis = _fixture.Create<bool>();
        var buildMapping = _fixture.Create<bool>();
        var updateKeys = _fixture.Create<bool>();
        var updateExcept = _fixture.Create<string[]>();
        var tempType = _fixture.Create<BulkPrepareType>();

        // Act
        var result = this._testClass.Insert(table, keysFromDeckis, buildMapping, updateKeys, updateExcept, tempType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Insert method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInsertWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.Insert(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<bool>(), _fixture.Create<string[]>(), _fixture.Create<BulkPrepareType>())).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that the SimpleInsert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSimpleInsertWithIInstantSeriesAndBoolAndInt()
    {
        // Arrange
        var table = _fixture.Create<IInstantSeries>();
        var buildMapping = _fixture.Create<bool>();
        var batchSize = _fixture.Create<int>();

        // Act
        var result = this._testClass.SimpleInsert(table, buildMapping, batchSize);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SimpleInsert method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSimpleInsertWithIInstantSeriesAndBoolAndIntWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.SimpleInsert(default(IInstantSeries), _fixture.Create<bool>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that the SimpleInsert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSimpleInsertWithIInstantSeriesAndInt()
    {
        // Arrange
        var table = _fixture.Create<IInstantSeries>();
        var batchSize = _fixture.Create<int>();

        // Act
        var result = this._testClass.SimpleInsert(table, batchSize);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SimpleInsert method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSimpleInsertWithIInstantSeriesAndIntWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.SimpleInsert(default(IInstantSeries), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }
}

/// <summary>
/// Unit tests for the type <see cref="SqlInsertException"/>.
/// </summary>
public class SqlInsertExceptionTests
{
    private SqlInsertException _testClass;
    private IFixture _fixture;
    private string _message;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SqlInsertException"/>.
    /// </summary>
    public SqlInsertExceptionTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._message = _fixture.Create<string>();
        this._testClass = _fixture.Create<SqlInsertException>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SqlInsertException(this._message);

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
        FluentActions.Invoking(() => new SqlInsertException(value)).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }
}