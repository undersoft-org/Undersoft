using System;
using System.Data;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Sql;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="SqlReader"/>.
/// </summary>
public class SqlReader_1Tests
{
    private SqlReader<T> _testClass;
    private IFixture _fixture;
    private Mock<IDataReader> __dr;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SqlReader"/>.
    /// </summary>
    public SqlReader_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this.__dr = _fixture.Freeze<Mock<IDataReader>>();
        this._testClass = _fixture.Create<SqlReader<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SqlReader<T>(this.__dr.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the _dr parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNull_dr()
    {
        FluentActions.Invoking(() => new SqlReader<T>(default(IDataReader))).Should().Throw<ArgumentNullException>().WithParameterName("_dr");
    }

    /// <summary>
    /// Checks that the DeckFromSchema method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeckFromSchema()
    {
        // Arrange
        var schema = _fixture.Create<DataTable>();
        var operColumns = _fixture.Create<ISeries<MemberRubric>>();
        var insAndDel = _fixture.Create<bool>();

        // Act
        var result = this._testClass.DeckFromSchema(schema, operColumns, insAndDel);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeckFromSchema method throws when the schema parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeckFromSchemaWithNullSchema()
    {
        FluentActions.Invoking(() => this._testClass.DeckFromSchema(default(DataTable), _fixture.Create<ISeries<MemberRubric>>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("schema");
    }

    /// <summary>
    /// Checks that the DeckFromSchema method throws when the operColumns parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeckFromSchemaWithNullOperColumns()
    {
        FluentActions.Invoking(() => this._testClass.DeckFromSchema(_fixture.Create<DataTable>(), default(ISeries<MemberRubric>), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("operColumns");
    }

    /// <summary>
    /// Checks that the DeleteRead method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeleteRead()
    {
        // Arrange
        var toDeleteCards = _fixture.Create<IInstantSeries>();

        __dr.Setup(mock => mock.GetSchemaTable()).Returns(_fixture.Create<DataTable>());
        __dr.Setup(mock => mock.Read()).Returns(_fixture.Create<bool>());
        __dr.Setup(mock => mock.NextResult()).Returns(_fixture.Create<bool>());

        // Act
        var result = this._testClass.DeleteRead(toDeleteCards);

        // Assert
        __dr.Verify(mock => mock.GetSchemaTable());
        __dr.Verify(mock => mock.Read());
        __dr.Verify(mock => mock.NextResult());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DeleteRead method throws when the toDeleteCards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeleteReadWithNullToDeleteCards()
    {
        FluentActions.Invoking(() => this._testClass.DeleteRead(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("toDeleteCards");
    }

    /// <summary>
    /// Checks that the ReadLoaded method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadLoaded()
    {
        // Arrange
        var tableName = _fixture.Create<string>();
        var keyNames = _fixture.Create<ISeries<string>>();

        __dr.Setup(mock => mock.GetSchemaTable()).Returns(_fixture.Create<DataTable>());
        __dr.Setup(mock => mock.Read()).Returns(_fixture.Create<bool>());

        // Act
        var result = this._testClass.ReadLoaded(tableName, keyNames);

        // Assert
        __dr.Verify(mock => mock.GetSchemaTable());
        __dr.Verify(mock => mock.Read());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReadLoaded method throws when the tableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallReadLoadedWithInvalidTableName(string value)
    {
        FluentActions.Invoking(() => this._testClass.ReadLoaded(value, _fixture.Create<ISeries<string>>())).Should().Throw<ArgumentNullException>().WithParameterName("tableName");
    }

    /// <summary>
    /// Checks that the InsertRead method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsertRead()
    {
        // Arrange
        var toInsertCards = _fixture.Create<IInstantSeries>();

        __dr.Setup(mock => mock.GetSchemaTable()).Returns(_fixture.Create<DataTable>());
        __dr.Setup(mock => mock.Read()).Returns(_fixture.Create<bool>());
        __dr.Setup(mock => mock.NextResult()).Returns(_fixture.Create<bool>());

        // Act
        var result = this._testClass.InsertRead(toInsertCards);

        // Assert
        __dr.Verify(mock => mock.GetSchemaTable());
        __dr.Verify(mock => mock.Read());
        __dr.Verify(mock => mock.NextResult());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InsertRead method throws when the toInsertCards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInsertReadWithNullToInsertCards()
    {
        FluentActions.Invoking(() => this._testClass.InsertRead(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("toInsertCards");
    }

    /// <summary>
    /// Checks that the UpdateRead method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdateRead()
    {
        // Arrange
        var toUpdateCards = _fixture.Create<IInstantSeries>();

        __dr.Setup(mock => mock.GetSchemaTable()).Returns(_fixture.Create<DataTable>());
        __dr.Setup(mock => mock.Read()).Returns(_fixture.Create<bool>());
        __dr.Setup(mock => mock.NextResult()).Returns(_fixture.Create<bool>());

        // Act
        var result = this._testClass.UpdateRead(toUpdateCards);

        // Assert
        __dr.Verify(mock => mock.GetSchemaTable());
        __dr.Verify(mock => mock.Read());
        __dr.Verify(mock => mock.NextResult());

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UpdateRead method throws when the toUpdateCards parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUpdateReadWithNullToUpdateCards()
    {
        FluentActions.Invoking(() => this._testClass.UpdateRead(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("toUpdateCards");
    }
}