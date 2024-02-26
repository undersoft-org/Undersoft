using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Sql;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="SqlMapper"/>.
/// </summary>
public class SqlMapperTests
{
    private SqlMapper _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _table;
    private bool _keysFromDeck;
    private string[] _dbTableNames;
    private string _tablePrefix;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SqlMapper"/>.
    /// </summary>
    public SqlMapperTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._table = _fixture.Freeze<Mock<IInstantSeries>>();
        this._keysFromDeck = _fixture.Create<bool>();
        this._dbTableNames = _fixture.Create<string[]>();
        this._tablePrefix = _fixture.Create<string>();
        this._testClass = _fixture.Create<SqlMapper>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SqlMapper(this._table.Object, this._keysFromDeck, this._dbTableNames, this._tablePrefix);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTable()
    {
        FluentActions.Invoking(() => new SqlMapper(default(IInstantSeries), this._keysFromDeck, this._dbTableNames, this._tablePrefix)).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that the constructor throws when the tablePrefix parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidTablePrefix(string value)
    {
        FluentActions.Invoking(() => new SqlMapper(this._table.Object, this._keysFromDeck, this._dbTableNames, value)).Should().Throw<ArgumentNullException>().WithParameterName("tablePrefix");
    }

    /// <summary>
    /// Checks that the CardsMapped property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCardsMapped()
    {
        // Arrange
        var testValue = _fixture.Create<IInstantSeries>();

        // Act
        this._testClass.CardsMapped = testValue;

        // Assert
        this._testClass.CardsMapped.Should().BeSameAs(testValue);
    }
}