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
/// Unit tests for the type <see cref="SqlAdapter"/>.
/// </summary>
public class SqlAdapterTests
{
    private SqlAdapter _testClass;
    private IFixture _fixture;
    private SqlConnection _cn;
    private string _cnstring;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SqlAdapter"/>.
    /// </summary>
    public SqlAdapterTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._cn = _fixture.Create<SqlConnection>();
        this._cnstring = _fixture.Create<string>();
        this._testClass = _fixture.Create<SqlAdapter>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SqlAdapter(this._cn);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new SqlAdapter(this._cnstring);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the cn parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCn()
    {
        FluentActions.Invoking(() => new SqlAdapter(default(SqlConnection))).Should().Throw<ArgumentNullException>().WithParameterName("cn");
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
        FluentActions.Invoking(() => new SqlAdapter(value)).Should().Throw<ArgumentNullException>().WithParameterName("cnstring");
    }

    /// <summary>
    /// Checks that the DataBulk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDataBulkWithCardsAndBuforTableAndPrepareTypeAndDbType()
    {
        // Arrange
        var cards = _fixture.Create<InstantSeriesItem[]>();
        var buforTable = _fixture.Create<string>();
        var prepareType = _fixture.Create<BulkPrepareType>();
        var dbType = _fixture.Create<BulkDbType>();

        // Act
        var result = this._testClass.DataBulk(cards, buforTable, prepareType, dbType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DataBulk method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDataBulkWithCardsAndBuforTableAndPrepareTypeAndDbTypeWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.DataBulk(default(InstantSeriesItem[]), _fixture.Create<string>(), _fixture.Create<BulkPrepareType>(), _fixture.Create<BulkDbType>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the DataBulk method throws when the buforTable parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallDataBulkWithCardsAndBuforTableAndPrepareTypeAndDbTypeWithInvalidBuforTable(string value)
    {
        FluentActions.Invoking(() => this._testClass.DataBulk(_fixture.Create<InstantSeriesItem[]>(), value, _fixture.Create<BulkPrepareType>(), _fixture.Create<BulkDbType>())).Should().Throw<ArgumentNullException>().WithParameterName("buforTable");
    }

    /// <summary>
    /// Checks that the DataBulk method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDataBulkWithDeckAndBuforTableAndPrepareTypeAndDbType()
    {
        // Arrange
        var deck = _fixture.Create<IInstantSeries>();
        var buforTable = _fixture.Create<string>();
        var prepareType = _fixture.Create<BulkPrepareType>();
        var dbType = _fixture.Create<BulkDbType>();

        // Act
        var result = this._testClass.DataBulk(deck, buforTable, prepareType, dbType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DataBulk method throws when the deck parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDataBulkWithDeckAndBuforTableAndPrepareTypeAndDbTypeWithNullDeck()
    {
        FluentActions.Invoking(() => this._testClass.DataBulk(default(IInstantSeries), _fixture.Create<string>(), _fixture.Create<BulkPrepareType>(), _fixture.Create<BulkDbType>())).Should().Throw<ArgumentNullException>().WithParameterName("deck");
    }

    /// <summary>
    /// Checks that the DataBulk method throws when the buforTable parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallDataBulkWithDeckAndBuforTableAndPrepareTypeAndDbTypeWithInvalidBuforTable(string value)
    {
        FluentActions.Invoking(() => this._testClass.DataBulk(_fixture.Create<IInstantSeries>(), value, _fixture.Create<BulkPrepareType>(), _fixture.Create<BulkDbType>())).Should().Throw<ArgumentNullException>().WithParameterName("buforTable");
    }

    /// <summary>
    /// Checks that the ExecuteDelete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExecuteDeleteWithStringAndBool()
    {
        // Arrange
        var sqlqry = _fixture.Create<string>();
        var disposeCmd = _fixture.Create<bool>();

        // Act
        var result = this._testClass.ExecuteDelete(sqlqry, disposeCmd);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExecuteDelete method throws when the sqlqry parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallExecuteDeleteWithStringAndBoolWithInvalidSqlqry(string value)
    {
        FluentActions.Invoking(() => this._testClass.ExecuteDelete(value, _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("sqlqry");
    }

    /// <summary>
    /// Checks that the ExecuteDelete method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExecuteDeleteWithStringAndIInstantSeriesAndBool()
    {
        // Arrange
        var sqlqry = _fixture.Create<string>();
        var cards = _fixture.Create<IInstantSeries>();
        var disposeCmd = _fixture.Create<bool>();

        // Act
        var result = this._testClass.ExecuteDelete(sqlqry, cards, disposeCmd);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExecuteDelete method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExecuteDeleteWithStringAndIInstantSeriesAndBoolWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.ExecuteDelete(_fixture.Create<string>(), default(IInstantSeries), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the ExecuteDelete method throws when the sqlqry parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallExecuteDeleteWithStringAndIInstantSeriesAndBoolWithInvalidSqlqry(string value)
    {
        FluentActions.Invoking(() => this._testClass.ExecuteDelete(value, _fixture.Create<IInstantSeries>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("sqlqry");
    }

    /// <summary>
    /// Checks that the ExecuteLoad method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExecuteLoadWithSqlqryAndTableName()
    {
        // Arrange
        var sqlqry = _fixture.Create<string>();
        var tableName = _fixture.Create<string>();

        // Act
        var result = this._testClass.ExecuteLoad(sqlqry, tableName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExecuteLoad method throws when the sqlqry parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallExecuteLoadWithSqlqryAndTableNameWithInvalidSqlqry(string value)
    {
        FluentActions.Invoking(() => this._testClass.ExecuteLoad(value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("sqlqry");
    }

    /// <summary>
    /// Checks that the ExecuteLoad method throws when the tableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallExecuteLoadWithSqlqryAndTableNameWithInvalidTableName(string value)
    {
        FluentActions.Invoking(() => this._testClass.ExecuteLoad(_fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("tableName");
    }

    /// <summary>
    /// Checks that the ExecuteLoad method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExecuteLoadWithSqlqryAndTableNameAndKeyNames()
    {
        // Arrange
        var sqlqry = _fixture.Create<string>();
        var tableName = _fixture.Create<string>();
        var keyNames = _fixture.Create<ISeries<string>>();

        // Act
        var result = this._testClass.ExecuteLoad(sqlqry, tableName, keyNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExecuteLoad method throws when the sqlqry parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallExecuteLoadWithSqlqryAndTableNameAndKeyNamesWithInvalidSqlqry(string value)
    {
        FluentActions.Invoking(() => this._testClass.ExecuteLoad(value, _fixture.Create<string>(), _fixture.Create<ISeries<string>>())).Should().Throw<ArgumentNullException>().WithParameterName("sqlqry");
    }

    /// <summary>
    /// Checks that the ExecuteLoad method throws when the tableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallExecuteLoadWithSqlqryAndTableNameAndKeyNamesWithInvalidTableName(string value)
    {
        FluentActions.Invoking(() => this._testClass.ExecuteLoad(_fixture.Create<string>(), value, _fixture.Create<ISeries<string>>())).Should().Throw<ArgumentNullException>().WithParameterName("tableName");
    }

    /// <summary>
    /// Checks that the ExecuteInsert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExecuteInsertWithStringAndBool()
    {
        // Arrange
        var sqlqry = _fixture.Create<string>();
        var disposeCmd = _fixture.Create<bool>();

        // Act
        var result = this._testClass.ExecuteInsert(sqlqry, disposeCmd);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExecuteInsert method throws when the sqlqry parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallExecuteInsertWithStringAndBoolWithInvalidSqlqry(string value)
    {
        FluentActions.Invoking(() => this._testClass.ExecuteInsert(value, _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("sqlqry");
    }

    /// <summary>
    /// Checks that the ExecuteInsert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExecuteInsertWithStringAndIInstantSeriesAndBool()
    {
        // Arrange
        var sqlqry = _fixture.Create<string>();
        var cards = _fixture.Create<IInstantSeries>();
        var disposeCmd = _fixture.Create<bool>();

        // Act
        var result = this._testClass.ExecuteInsert(sqlqry, cards, disposeCmd);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExecuteInsert method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExecuteInsertWithStringAndIInstantSeriesAndBoolWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.ExecuteInsert(_fixture.Create<string>(), default(IInstantSeries), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the ExecuteInsert method throws when the sqlqry parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallExecuteInsertWithStringAndIInstantSeriesAndBoolWithInvalidSqlqry(string value)
    {
        FluentActions.Invoking(() => this._testClass.ExecuteInsert(value, _fixture.Create<IInstantSeries>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("sqlqry");
    }

    /// <summary>
    /// Checks that the ExecuteUpdate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExecuteUpdateWithStringAndBool()
    {
        // Arrange
        var sqlqry = _fixture.Create<string>();
        var disposeCmd = _fixture.Create<bool>();

        // Act
        var result = this._testClass.ExecuteUpdate(sqlqry, disposeCmd);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExecuteUpdate method throws when the sqlqry parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallExecuteUpdateWithStringAndBoolWithInvalidSqlqry(string value)
    {
        FluentActions.Invoking(() => this._testClass.ExecuteUpdate(value, _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("sqlqry");
    }

    /// <summary>
    /// Checks that the ExecuteUpdate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExecuteUpdateWithStringAndIInstantSeriesAndBool()
    {
        // Arrange
        var sqlqry = _fixture.Create<string>();
        var cards = _fixture.Create<IInstantSeries>();
        var disposeCmd = _fixture.Create<bool>();

        // Act
        var result = this._testClass.ExecuteUpdate(sqlqry, cards, disposeCmd);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExecuteUpdate method throws when the cards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExecuteUpdateWithStringAndIInstantSeriesAndBoolWithNullCards()
    {
        FluentActions.Invoking(() => this._testClass.ExecuteUpdate(_fixture.Create<string>(), default(IInstantSeries), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("cards");
    }

    /// <summary>
    /// Checks that the ExecuteUpdate method throws when the sqlqry parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallExecuteUpdateWithStringAndIInstantSeriesAndBoolWithInvalidSqlqry(string value)
    {
        FluentActions.Invoking(() => this._testClass.ExecuteUpdate(value, _fixture.Create<IInstantSeries>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("sqlqry");
    }
}