using System;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Series.Querying;
using Undersoft.SDK.Rubrics;

namespace Undersoft.SDK.UnitTests.Instant.Series.Querying;

/// <summary>
/// Unit tests for the type <see cref="InstantSeriesSortTerm"/>.
/// </summary>
public class InstantSeriesSortTermTests
{
    private InstantSeriesSortTerm _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _table;
    private MemberRubric _sortedRubric;
    private SortDirection _directionSortDirection;
    private int _ordinal;
    private string _rubricName;
    private string _directionString;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSeriesSortTerm"/>.
    /// </summary>
    public InstantSeriesSortTermTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._table = _fixture.Freeze<Mock<IInstantSeries>>();
        this._sortedRubric = _fixture.Create<MemberRubric>();
        this._directionSortDirection = _fixture.Create<SortDirection>();
        this._ordinal = _fixture.Create<int>();
        this._rubricName = _fixture.Create<string>();
        this._directionString = _fixture.Create<string>();
        this._testClass = _fixture.Create<InstantSeriesSortTerm>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSeriesSortTerm();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesSortTerm(this._table.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesSortTerm(this._sortedRubric, this._directionSortDirection, this._ordinal);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesSortTerm(this._rubricName, this._directionString, this._ordinal);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the table parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTable()
    {
        FluentActions.Invoking(() => new InstantSeriesSortTerm(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("table");
    }

    /// <summary>
    /// Checks that instance construction throws when the sortedRubric parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSortedRubric()
    {
        FluentActions.Invoking(() => new InstantSeriesSortTerm(default(MemberRubric), this._directionSortDirection, this._ordinal)).Should().Throw<ArgumentNullException>().WithParameterName("sortedRubric");
    }

    /// <summary>
    /// Checks that the constructor throws when the rubricName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidRubricName(string value)
    {
        FluentActions.Invoking(() => new InstantSeriesSortTerm(value, this._directionString, this._ordinal)).Should().Throw<ArgumentNullException>().WithParameterName("rubricName");
    }

    /// <summary>
    /// Checks that the constructor throws when the direction parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidDirection(string value)
    {
        FluentActions.Invoking(() => new InstantSeriesSortTerm(this._sortedRubric, value, this._ordinal)).Should().Throw<ArgumentNullException>().WithParameterName("direction");
        FluentActions.Invoking(() => new InstantSeriesSortTerm(this._rubricName, value, this._ordinal)).Should().Throw<ArgumentNullException>().WithParameterName("direction");
    }

    /// <summary>
    /// Checks that the Compare method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompare()
    {
        // Arrange
        var term = _fixture.Create<InstantSeriesSortTerm>();

        // Act
        var result = this._testClass.Compare(term);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compare method throws when the term parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareWithNullTerm()
    {
        FluentActions.Invoking(() => this._testClass.Compare(default(InstantSeriesSortTerm))).Should().Throw<ArgumentNullException>().WithParameterName("term");
    }

    /// <summary>
    /// Checks that the Direction property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDirection()
    {
        // Arrange
        var testValue = _fixture.Create<SortDirection>();

        // Act
        this._testClass.Direction = testValue;

        // Assert
        this._testClass.Direction.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the InstantSeriesCreator property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInstantSeriesCreator()
    {
        // Arrange
        var testValue = _fixture.Create<IInstantSeries>();

        // Act
        this._testClass.InstantSeriesCreator = testValue;

        // Assert
        this._testClass.InstantSeriesCreator.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Index property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndex()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.Index = testValue;

        // Assert
        this._testClass.Index.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the RubricId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricId()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.RubricId = testValue;

        // Assert
        this._testClass.RubricId.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the RubricName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.RubricName = testValue;

        // Assert
        this._testClass.RubricName.Should().Be(testValue);
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

    /// <summary>
    /// Checks that the SortedRubric property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSortedRubric()
    {
        // Arrange
        var testValue = _fixture.Create<MemberRubric>();

        // Act
        this._testClass.SortedRubric = testValue;

        // Assert
        this._testClass.SortedRubric.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the TypeString property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeString()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.TypeString = testValue;

        // Assert
        this._testClass.TypeString.Should().Be(testValue);
    }
}