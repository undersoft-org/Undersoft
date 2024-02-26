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
/// Unit tests for the type <see cref="DbColumn"/>.
/// </summary>
public class DbColumnTests
{
    private DbColumn _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DbColumn"/>.
    /// </summary>
    public DbColumnTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<DbColumn>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DbColumn();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the ColumnName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetColumnName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.ColumnName = testValue;

        // Assert
        this._testClass.ColumnName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the DbColumnSize property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDbColumnSize()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.DbColumnSize = testValue;

        // Assert
        this._testClass.DbColumnSize.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the DbOrdinal property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDbOrdinal()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.DbOrdinal = testValue;

        // Assert
        this._testClass.DbOrdinal.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the isAutoincrement property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetisAutoincrement()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.isAutoincrement = testValue;

        // Assert
        this._testClass.isAutoincrement.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the isDBNull property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetisDBNull()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.isDBNull = testValue;

        // Assert
        this._testClass.isDBNull.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the isIdentity property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetisIdentity()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.isIdentity = testValue;

        // Assert
        this._testClass.isIdentity.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the isKey property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetisKey()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.isKey = testValue;

        // Assert
        this._testClass.isKey.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the MaxLength property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMaxLength()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.MaxLength = testValue;

        // Assert
        this._testClass.MaxLength.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Rubrics property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubrics()
    {
        // Arrange
        var testValue = _fixture.Create<List<MemberRubric>>();

        // Act
        this._testClass.Rubrics = testValue;

        // Assert
        this._testClass.Rubrics.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the RubricType property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricType()
    {
        // Arrange
        var testValue = _fixture.Create<Type>();

        // Act
        this._testClass.RubricType = testValue;

        // Assert
        this._testClass.RubricType.Should().BeSameAs(testValue);
    }
}

/// <summary>
/// Unit tests for the type <see cref="DbColumns"/>.
/// </summary>
public class DbColumnsTests
{
    private DbColumns _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DbColumns"/>.
    /// </summary>
    public DbColumnsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<DbColumns>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DbColumns();

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
        var column = _fixture.Create<DbColumn>();

        // Act
        this._testClass.Add(column);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the column parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithNullColumn()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(DbColumn))).Should().Throw<ArgumentNullException>().WithParameterName("column");
    }

    /// <summary>
    /// Checks that the AddRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRange()
    {
        // Arrange
        var _columns = _fixture.Create<List<DbColumn>>();

        // Act
        this._testClass.AddRange(_columns);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRange method throws when the _columns parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRangeWithNull_columns()
    {
        FluentActions.Invoking(() => this._testClass.AddRange(default(List<DbColumn>))).Should().Throw<ArgumentNullException>().WithParameterName("_columns");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemove()
    {
        // Arrange
        var column = _fixture.Create<DbColumn>();

        // Act
        this._testClass.Remove(column);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method throws when the column parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveWithNullColumn()
    {
        FluentActions.Invoking(() => this._testClass.Remove(default(DbColumn))).Should().Throw<ArgumentNullException>().WithParameterName("column");
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
    /// Checks that the Have method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallHave()
    {
        // Arrange
        var ColumnName = _fixture.Create<string>();

        // Act
        var result = this._testClass.Have(ColumnName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Have method throws when the ColumnName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallHaveWithInvalidColumnName(string value)
    {
        FluentActions.Invoking(() => this._testClass.Have(value)).Should().Throw<ArgumentNullException>().WithParameterName("ColumnName");
    }

    /// <summary>
    /// Checks that the GetDbColumn method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDbColumn()
    {
        // Arrange
        var ColumnName = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetDbColumn(ColumnName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDbColumn method throws when the ColumnName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetDbColumnWithInvalidColumnName(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetDbColumn(value)).Should().Throw<ArgumentNullException>().WithParameterName("ColumnName");
    }

    /// <summary>
    /// Checks that the GetDbColumn maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetDbColumnPerformsMapping()
    {
        // Arrange
        var ColumnName = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetDbColumn(ColumnName);

        // Assert
        result.ColumnName.Should().BeSameAs(ColumnName);
    }

    /// <summary>
    /// Checks that the GetDbColumns method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDbColumns()
    {
        // Arrange
        var ColumnNames = _fixture.Create<List<string>>();

        // Act
        var result = this._testClass.GetDbColumns(ColumnNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDbColumns method throws when the ColumnNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDbColumnsWithNullColumnNames()
    {
        FluentActions.Invoking(() => this._testClass.GetDbColumns(default(List<string>))).Should().Throw<ArgumentNullException>().WithParameterName("ColumnNames");
    }

    /// <summary>
    /// Checks that the GetRubrics method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRubricsWithString()
    {
        // Arrange
        var ColumnNames = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetRubrics(ColumnNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRubrics method throws when the ColumnNames parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetRubricsWithStringWithInvalidColumnNames(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetRubrics(value)).Should().Throw<ArgumentNullException>().WithParameterName("ColumnNames");
    }

    /// <summary>
    /// Checks that the GetRubrics method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRubricsWithListOfString()
    {
        // Arrange
        var ColumnNames = _fixture.Create<List<string>>();

        // Act
        var result = this._testClass.GetRubrics(ColumnNames);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRubrics method throws when the ColumnNames parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRubricsWithListOfStringWithNullColumnNames()
    {
        FluentActions.Invoking(() => this._testClass.GetRubrics(default(List<string>))).Should().Throw<ArgumentNullException>().WithParameterName("ColumnNames");
    }

    /// <summary>
    /// Checks that the GetRubrics maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetRubricsWithListOfStringPerformsMapping()
    {
        // Arrange
        var ColumnNames = _fixture.Create<List<string>>();

        // Act
        var result = this._testClass.GetRubrics(ColumnNames);

        // Assert
        result.Capacity.Should().Be(ColumnNames.Capacity);
        result.Count.Should().Be(ColumnNames.Count);
    }

    /// <summary>
    /// Checks that the List property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetList()
    {
        // Arrange
        var testValue = _fixture.Create<List<DbColumn>>();

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
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<DbColumn>();
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForInt()
    {
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<DbColumn>();
        Assert.Fail("Create or modify test");
    }
}