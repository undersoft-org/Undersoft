using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Sql;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="DataDbSchema"/>.
/// </summary>
public class DataDbSchemaTests
{
    private DataDbSchema _testClass;
    private IFixture _fixture;
    private SqlConnection _sqlDbConnection;
    private string _dbConnectionString;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DataDbSchema"/>.
    /// </summary>
    public DataDbSchemaTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._sqlDbConnection = _fixture.Create<SqlConnection>();
        this._dbConnectionString = _fixture.Create<string>();
        this._testClass = _fixture.Create<DataDbSchema>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DataDbSchema(this._sqlDbConnection);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new DataDbSchema(this._dbConnectionString);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the sqlDbConnection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSqlDbConnection()
    {
        FluentActions.Invoking(() => new DataDbSchema(default(SqlConnection))).Should().Throw<ArgumentNullException>().WithParameterName("sqlDbConnection");
    }

    /// <summary>
    /// Checks that the constructor throws when the dbConnectionString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidDbConnectionString(string value)
    {
        FluentActions.Invoking(() => new DataDbSchema(value)).Should().Throw<ArgumentNullException>().WithParameterName("dbConnectionString");
    }

    /// <summary>
    /// Checks that the DataDbTables property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDataDbTables()
    {
        // Arrange
        var testValue = _fixture.Create<DbTables>();

        // Act
        this._testClass.DataDbTables = testValue;

        // Assert
        this._testClass.DataDbTables.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the DbConfig property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDbConfig()
    {
        // Arrange
        var testValue = _fixture.Create<DbConfig>();

        // Act
        this._testClass.DbConfig = testValue;

        // Assert
        this._testClass.DbConfig.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the DbName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDbName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.DbName = testValue;

        // Assert
        this._testClass.DbName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the DbTables property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDbTables()
    {
        // Arrange
        var testValue = _fixture.Create<List<DbTable>>();

        // Act
        this._testClass.DbTables = testValue;

        // Assert
        this._testClass.DbTables.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the SqlDbConnection property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSqlDbConnection()
    {
        // Arrange
        var testValue = _fixture.Create<SqlConnection>();

        // Act
        this._testClass.SqlDbConnection = testValue;

        // Assert
        this._testClass.SqlDbConnection.Should().BeSameAs(testValue);
    }
}

/// <summary>
/// Unit tests for the type <see cref="DbConfig"/>.
/// </summary>
public class DbConfigTests
{
    private DbConfig _testClass;
    private IFixture _fixture;
    private string __User;
    private string __Password;
    private string __Source;
    private string __Catalog;
    private string __Provider;
    private string _dbConnectionString;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DbConfig"/>.
    /// </summary>
    public DbConfigTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this.__User = _fixture.Create<string>();
        this.__Password = _fixture.Create<string>();
        this.__Source = _fixture.Create<string>();
        this.__Catalog = _fixture.Create<string>();
        this.__Provider = _fixture.Create<string>();
        this._dbConnectionString = _fixture.Create<string>();
        this._testClass = _fixture.Create<DbConfig>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DbConfig();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new DbConfig(this.__User, this.__Password, this.__Source, this.__Catalog, this.__Provider);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new DbConfig(this._dbConnectionString);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the _User parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalid_User(string value)
    {
        FluentActions.Invoking(() => new DbConfig(value, this.__Password, this.__Source, this.__Catalog, this.__Provider)).Should().Throw<ArgumentNullException>().WithParameterName("_User");
    }

    /// <summary>
    /// Checks that the constructor throws when the _Password parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalid_Password(string value)
    {
        FluentActions.Invoking(() => new DbConfig(this.__User, value, this.__Source, this.__Catalog, this.__Provider)).Should().Throw<ArgumentNullException>().WithParameterName("_Password");
    }

    /// <summary>
    /// Checks that the constructor throws when the _Source parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalid_Source(string value)
    {
        FluentActions.Invoking(() => new DbConfig(this.__User, this.__Password, value, this.__Catalog, this.__Provider)).Should().Throw<ArgumentNullException>().WithParameterName("_Source");
    }

    /// <summary>
    /// Checks that the constructor throws when the _Catalog parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalid_Catalog(string value)
    {
        FluentActions.Invoking(() => new DbConfig(this.__User, this.__Password, this.__Source, value, this.__Provider)).Should().Throw<ArgumentNullException>().WithParameterName("_Catalog");
    }

    /// <summary>
    /// Checks that the constructor throws when the _Provider parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalid_Provider(string value)
    {
        FluentActions.Invoking(() => new DbConfig(this.__User, this.__Password, this.__Source, this.__Catalog, value)).Should().Throw<ArgumentNullException>().WithParameterName("_Provider");
    }

    /// <summary>
    /// Checks that the constructor throws when the dbConnectionString parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidDbConnectionString(string value)
    {
        FluentActions.Invoking(() => new DbConfig(value)).Should().Throw<ArgumentNullException>().WithParameterName("dbConnectionString");
    }

    /// <summary>
    /// Checks that the InitCatalog property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInitCatalog()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.InitCatalog = testValue;

        // Assert
        this._testClass.InitCatalog.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the DbConnectionString property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDbConnectionString()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.DbConnectionString = testValue;

        // Assert
        this._testClass.DbConnectionString.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Password property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPassword()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Password = testValue;

        // Assert
        this._testClass.Password.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Provider property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProvider()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Provider = testValue;

        // Assert
        this._testClass.Provider.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Source property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSource()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Source = testValue;

        // Assert
        this._testClass.Source.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the User property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUser()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.User = testValue;

        // Assert
        this._testClass.User.Should().Be(testValue);
    }
}

/// <summary>
/// Unit tests for the type <see cref="DbHand"/>.
/// </summary>
public class DbHandTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Schema property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSchema()
    {
        // Arrange
        var testValue = _fixture.Create<DataDbSchema>();

        // Act
        DbHand.Schema = testValue;

        // Assert
        DbHand.Schema.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Temp property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTemp()
    {
        // Arrange
        var testValue = _fixture.Create<DataDbSchema>();

        // Act
        DbHand.Temp = testValue;

        // Assert
        DbHand.Temp.Should().BeSameAs(testValue);
    }
}