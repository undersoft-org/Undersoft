using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.UnitTests.Rubrics;

/// <summary>
/// Unit tests for the type <see cref="RubricSqlMapping"/>.
/// </summary>
public class RubricSqlMappingTests
{
    private RubricSqlMapping _testClass;
    private IFixture _fixture;
    private string _dbDeckName;
    private Mock<ISeries<int>> _keyOrdinal;
    private Mock<ISeries<int>> _columnOrdinal;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RubricSqlMapping"/>.
    /// </summary>
    public RubricSqlMappingTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._dbDeckName = _fixture.Create<string>();
        this._keyOrdinal = _fixture.Freeze<Mock<ISeries<int>>>();
        this._columnOrdinal = _fixture.Freeze<Mock<ISeries<int>>>();
        this._testClass = _fixture.Create<RubricSqlMapping>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RubricSqlMapping(this._dbDeckName);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RubricSqlMapping(this._dbDeckName, this._keyOrdinal.Object, this._columnOrdinal.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the keyOrdinal parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeyOrdinal()
    {
        FluentActions.Invoking(() => new RubricSqlMapping(this._dbDeckName, default(ISeries<int>), this._columnOrdinal.Object)).Should().Throw<ArgumentNullException>().WithParameterName("keyOrdinal");
    }

    /// <summary>
    /// Checks that instance construction throws when the columnOrdinal parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullColumnOrdinal()
    {
        FluentActions.Invoking(() => new RubricSqlMapping(this._dbDeckName, this._keyOrdinal.Object, default(ISeries<int>))).Should().Throw<ArgumentNullException>().WithParameterName("columnOrdinal");
    }

    /// <summary>
    /// Checks that the constructor throws when the dbDeckName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidDbDeckName(string value)
    {
        FluentActions.Invoking(() => new RubricSqlMapping(value)).Should().Throw<ArgumentNullException>().WithParameterName("dbDeckName");
        FluentActions.Invoking(() => new RubricSqlMapping(value, this._keyOrdinal.Object, this._columnOrdinal.Object)).Should().Throw<ArgumentNullException>().WithParameterName("dbDeckName");
    }

    /// <summary>
    /// Checks that the ColumnOrdinal property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetColumnOrdinal()
    {
        // Arrange
        var testValue = _fixture.Create<ISeries<int>>();

        // Act
        this._testClass.ColumnOrdinal = testValue;

        // Assert
        this._testClass.ColumnOrdinal.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the DbTableName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDbTableName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.DbTableName = testValue;

        // Assert
        this._testClass.DbTableName.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the KeyOrdinal property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetKeyOrdinal()
    {
        // Arrange
        var testValue = _fixture.Create<ISeries<int>>();

        // Act
        this._testClass.KeyOrdinal = testValue;

        // Assert
        this._testClass.KeyOrdinal.Should().BeSameAs(testValue);
    }
}