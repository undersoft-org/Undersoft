using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Infrastructure.Database.Relation;
using TLeft = Undersoft.SDK.Stocks.StockContext;
using TRight = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests.Database.Relation;

/// <summary>
/// Unit tests for the type <see cref="RelatedSetToSet"/>.
/// </summary>
[TestClass]
public class RelatedSetToSet_2Tests
{
    private RelatedSetToSet<TLeft, TRight> _testClass;
    private IFixture _fixture;
    private ModelBuilder _modelBuilder;
    private ExpandSite _expandSite;
    private string _dbSchema;
    private string _leftName;
    private string _rightName;
    private string _leftTableName;
    private string _rightTableName;
    private string _parentSchema;
    private string _childSchema;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RelatedSetToSet"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._modelBuilder = _fixture.Create<ModelBuilder>();
        this._expandSite = _fixture.Create<ExpandSite>();
        this._dbSchema = _fixture.Create<string>();
        this._leftName = _fixture.Create<string>();
        this._rightName = _fixture.Create<string>();
        this._leftTableName = _fixture.Create<string>();
        this._rightTableName = _fixture.Create<string>();
        this._parentSchema = _fixture.Create<string>();
        this._childSchema = _fixture.Create<string>();
        this._testClass = _fixture.Create<RelatedSetToSet<TLeft, TRight>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RelatedSetToSet<TLeft, TRight>(this._modelBuilder, this._expandSite, this._dbSchema);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RelatedSetToSet<TLeft, TRight>(this._modelBuilder, this._leftName, this._rightName, this._expandSite, this._dbSchema);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RelatedSetToSet<TLeft, TRight>(this._modelBuilder, this._leftName, this._leftTableName, this._rightName, this._rightTableName, this._expandSite, this._parentSchema, this._childSchema);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the modelBuilder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullModelBuilder()
    {
        FluentActions.Invoking(() => new RelatedSetToSet<TLeft, TRight>(default(ModelBuilder), this._expandSite, this._dbSchema)).Should().Throw<ArgumentNullException>().WithParameterName("modelBuilder");
        FluentActions.Invoking(() => new RelatedSetToSet<TLeft, TRight>(default(ModelBuilder), this._leftName, this._rightName, this._expandSite, this._dbSchema)).Should().Throw<ArgumentNullException>().WithParameterName("modelBuilder");
        FluentActions.Invoking(() => new RelatedSetToSet<TLeft, TRight>(default(ModelBuilder), this._leftName, this._leftTableName, this._rightName, this._rightTableName, this._expandSite, this._parentSchema, this._childSchema)).Should().Throw<ArgumentNullException>().WithParameterName("modelBuilder");
    }

    /// <summary>
    /// Checks that the constructor throws when the dbSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidDbSchema(string value)
    {
        FluentActions.Invoking(() => new RelatedSetToSet<TLeft, TRight>(this._modelBuilder, this._expandSite, value)).Should().Throw<ArgumentNullException>().WithParameterName("dbSchema");
        FluentActions.Invoking(() => new RelatedSetToSet<TLeft, TRight>(this._modelBuilder, this._leftName, this._rightName, this._expandSite, value)).Should().Throw<ArgumentNullException>().WithParameterName("dbSchema");
    }

    /// <summary>
    /// Checks that the constructor throws when the leftName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidLeftName(string value)
    {
        FluentActions.Invoking(() => new RelatedSetToSet<TLeft, TRight>(this._modelBuilder, value, this._rightName, this._expandSite, this._dbSchema)).Should().Throw<ArgumentNullException>().WithParameterName("leftName");
        FluentActions.Invoking(() => new RelatedSetToSet<TLeft, TRight>(this._modelBuilder, value, this._leftTableName, this._rightName, this._rightTableName, this._expandSite, this._parentSchema, this._childSchema)).Should().Throw<ArgumentNullException>().WithParameterName("leftName");
    }

    /// <summary>
    /// Checks that the constructor throws when the rightName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidRightName(string value)
    {
        FluentActions.Invoking(() => new RelatedSetToSet<TLeft, TRight>(this._modelBuilder, this._leftName, value, this._expandSite, this._dbSchema)).Should().Throw<ArgumentNullException>().WithParameterName("rightName");
        FluentActions.Invoking(() => new RelatedSetToSet<TLeft, TRight>(this._modelBuilder, this._leftName, this._leftTableName, value, this._rightTableName, this._expandSite, this._parentSchema, this._childSchema)).Should().Throw<ArgumentNullException>().WithParameterName("rightName");
    }

    /// <summary>
    /// Checks that the constructor throws when the leftTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidLeftTableName(string value)
    {
        FluentActions.Invoking(() => new RelatedSetToSet<TLeft, TRight>(this._modelBuilder, this._leftName, value, this._rightName, this._rightTableName, this._expandSite, this._parentSchema, this._childSchema)).Should().Throw<ArgumentNullException>().WithParameterName("leftTableName");
    }

    /// <summary>
    /// Checks that the constructor throws when the rightTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidRightTableName(string value)
    {
        FluentActions.Invoking(() => new RelatedSetToSet<TLeft, TRight>(this._modelBuilder, this._leftName, this._leftTableName, this._rightName, value, this._expandSite, this._parentSchema, this._childSchema)).Should().Throw<ArgumentNullException>().WithParameterName("rightTableName");
    }

    /// <summary>
    /// Checks that the constructor throws when the parentSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidParentSchema(string value)
    {
        FluentActions.Invoking(() => new RelatedSetToSet<TLeft, TRight>(this._modelBuilder, this._leftName, this._leftTableName, this._rightName, this._rightTableName, this._expandSite, value, this._childSchema)).Should().Throw<ArgumentNullException>().WithParameterName("parentSchema");
    }

    /// <summary>
    /// Checks that the constructor throws when the childSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidChildSchema(string value)
    {
        FluentActions.Invoking(() => new RelatedSetToSet<TLeft, TRight>(this._modelBuilder, this._leftName, this._leftTableName, this._rightName, this._rightTableName, this._expandSite, this._parentSchema, value)).Should().Throw<ArgumentNullException>().WithParameterName("childSchema");
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Arrange
        var autoinclude = _fixture.Create<bool>();

        // Act
        var result = this._testClass.Configure(autoinclude);

        // Assert
        Assert.Fail("Create or modify test");
    }
}