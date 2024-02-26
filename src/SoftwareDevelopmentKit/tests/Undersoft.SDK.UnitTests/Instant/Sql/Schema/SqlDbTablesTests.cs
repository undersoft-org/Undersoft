using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Sql;
using Undersoft.SDK.Rubrics;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="DbTable"/>.
/// </summary>
public class DbTableTests
{
    private DbTable _testClass;
    private IFixture _fixture;
    private string _tableName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DbTable"/>.
    /// </summary>
    public DbTableTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._tableName = _fixture.Create<string>();
        this._testClass = _fixture.Create<DbTable>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DbTable();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new DbTable(this._tableName);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the tableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidTableName(string value)
    {
        FluentActions.Invoking(() => new DbTable(value)).Should().Throw<ArgumentNullException>().WithParameterName("tableName");
    }

    /// <summary>
    /// Checks that the DataDbColumns property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDataDbColumns()
    {
        // Arrange
        var testValue = _fixture.Create<DbColumns>();

        // Act
        this._testClass.DataDbColumns = testValue;

        // Assert
        this._testClass.DataDbColumns.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the DbPrimaryKey property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDbPrimaryKey()
    {
        // Arrange
        var testValue = _fixture.Create<DbColumn[]>();

        // Act
        this._testClass.DbPrimaryKey = testValue;

        // Assert
        this._testClass.DbPrimaryKey.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the GetColumnsForDataTable property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetGetColumnsForDataTable()
    {
        // Assert
        this._testClass.GetColumnsForDataTable.Should().BeAssignableTo<List<MemberRubric>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetKeyForDataTable property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetGetKeyForDataTable()
    {
        // Assert
        this._testClass.GetKeyForDataTable.Should().BeAssignableTo<MemberRubric[]>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TableName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTableName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.TableName = testValue;

        // Assert
        this._testClass.TableName.Should().Be(testValue);
    }
}

/// <summary>
/// Unit tests for the type <see cref="DbTables"/>.
/// </summary>
public class DbTablesTests
{
    private DbTables _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DbTables"/>.
    /// </summary>
    public DbTablesTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<DbTables>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DbTables();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAdd()
    {
        // Arrange
        var table = _fixture.Create<DbTable>();

        // Act
        this._testClass.Add(table);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(DbTable))).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that the AddRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRange()
    {
        // Arrange
        var _tables = _fixture.Create<List<DbTable>>();

        // Act
        this._testClass.AddRange(_tables);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRange method throws when the _tables parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRangeWithNull_tables()
    {
        FluentActions.Invoking(() => this._testClass.AddRange(default(List<DbTable>))).Should().Throw<ArgumentNullException>().WithParameterName("_tables");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemove()
    {
        // Arrange
        var table = _fixture.Create<DbTable>();

        // Act
        this._testClass.Remove(table);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveWithNullTable()
    {
        FluentActions.Invoking(() => this._testClass.Remove(default(DbTable))).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that the RemoveAt method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveAt()
    {
        // Arrange
        var index = _fixture.Create<int>();

        // Act
        this._testClass.RemoveAt(index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Have method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallHave()
    {
        // Arrange
        var TableName = _fixture.Create<string>();

        // Act
        var result = this._testClass.Have(TableName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Have method throws when the TableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallHaveWithInvalidTableName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Have(value)).Should().Throw<ArgumentNullException>().WithParameterName("TableName");
    }

    /// <summary>
    /// Checks that the Clear method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClear()
    {
        // Act
        this._testClass.Clear();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDbTable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDbTable()
    {
        // Arrange
        var TableName = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetDbTable(TableName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDbTable method throws when the TableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetDbTableWithInvalidTableName(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetDbTable(value)).Should().Throw<ArgumentNullException>().WithParameterName("TableName");
    }

    /// <summary>
    /// Checks that the GetDbTable maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetDbTablePerformsMapping()
    {
        // Arrange
        var TableName = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetDbTable(TableName);

        // Assert
        result.TableName.Should().BeSameAs(TableName);
    }

    /// <summary>
    /// Checks that the GetDbTables method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDbTables()
    {
        // Arrange
        var TableNames = _fixture.Create<List<string>>();

        // Act
        var result = this._testClass.GetDbTables(TableNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDbTables method throws when the TableNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDbTablesWithNullTableNames()
    {
        FluentActions.Invoking(() => this._testClass.GetDbTables(default(List<string>))).Should().Throw<ArgumentNullException>().WithParameterName("TableNames");
    }

    /// <summary>
    /// Checks that the GetDbTables maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetDbTablesPerformsMapping()
    {
        // Arrange
        var TableNames = _fixture.Create<List<string>>();

        // Act
        var result = this._testClass.GetDbTables(TableNames);

        // Assert
        result.Capacity.Should().Be(TableNames.Capacity);
        result.Count.Should().Be(TableNames.Count);
    }

    /// <summary>
    /// Checks that the Holder property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetHolder()
    {
        // Assert
        this._testClass.Holder.Should().BeAssignableTo<object>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the List property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetList()
    {
        // Arrange
        var testValue = _fixture.Create<List<DbTable>>();

        // Act
        this._testClass.List = testValue;

        // Assert
        this._testClass.List.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForString()
    {
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<DbTable>();
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForInt()
    {
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<DbTable>();
        Assert.Fail("Create or modify test");
    }
}