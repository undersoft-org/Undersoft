using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Infrastructure.Database.Relation;
using TChild = Undersoft.SDK.Stocks.StockContext;
using TParent = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests.Database.Relation;

/// <summary>
/// Unit tests for the type <see cref="RelatedOneToOne"/>.
/// </summary>
[TestClass]
public class RelatedOneToOne_2Tests
{
    private RelatedOneToOne<TParent, TChild> _testClass;
    private IFixture _fixture;
    private ModelBuilder _modelBuilder;
    private ExpandSite _expandSite;
    private string _parentSchema;
    private string _parentName;
    private string _childName;
    private string _parentTableName;
    private string _childTableName;
    private string _childSchema;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RelatedOneToOne"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._modelBuilder = _fixture.Create<ModelBuilder>();
        this._expandSite = _fixture.Create<ExpandSite>();
        this._parentSchema = _fixture.Create<string>();
        this._parentName = _fixture.Create<string>();
        this._childName = _fixture.Create<string>();
        this._parentTableName = _fixture.Create<string>();
        this._childTableName = _fixture.Create<string>();
        this._childSchema = _fixture.Create<string>();
        this._testClass = _fixture.Create<RelatedOneToOne<TParent, TChild>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RelatedOneToOne<TParent, TChild>(this._modelBuilder, this._expandSite, this._parentSchema);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RelatedOneToOne<TParent, TChild>(this._modelBuilder, this._parentName, this._childName, this._expandSite, this._parentSchema);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RelatedOneToOne<TParent, TChild>(this._modelBuilder, this._parentName, this._parentTableName, this._childName, this._childTableName, this._expandSite, this._parentSchema, this._childSchema);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the modelBuilder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullModelBuilder()
    {
        FluentActions.Invoking(() => new RelatedOneToOne<TParent, TChild>(default(ModelBuilder), this._expandSite, this._parentSchema)).Should().Throw<ArgumentNullException>().WithParameterName("modelBuilder");
        FluentActions.Invoking(() => new RelatedOneToOne<TParent, TChild>(default(ModelBuilder), this._parentName, this._childName, this._expandSite, this._parentSchema)).Should().Throw<ArgumentNullException>().WithParameterName("modelBuilder");
        FluentActions.Invoking(() => new RelatedOneToOne<TParent, TChild>(default(ModelBuilder), this._parentName, this._parentTableName, this._childName, this._childTableName, this._expandSite, this._parentSchema, this._childSchema)).Should().Throw<ArgumentNullException>().WithParameterName("modelBuilder");
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
        FluentActions.Invoking(() => new RelatedOneToOne<TParent, TChild>(this._modelBuilder, this._expandSite, value)).Should().Throw<ArgumentNullException>().WithParameterName("parentSchema");
        FluentActions.Invoking(() => new RelatedOneToOne<TParent, TChild>(this._modelBuilder, this._parentName, this._childName, this._expandSite, value)).Should().Throw<ArgumentNullException>().WithParameterName("parentSchema");
        FluentActions.Invoking(() => new RelatedOneToOne<TParent, TChild>(this._modelBuilder, this._parentName, this._parentTableName, this._childName, this._childTableName, this._expandSite, value, this._childSchema)).Should().Throw<ArgumentNullException>().WithParameterName("parentSchema");
    }

    /// <summary>
    /// Checks that the constructor throws when the parentName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidParentName(string value)
    {
        FluentActions.Invoking(() => new RelatedOneToOne<TParent, TChild>(this._modelBuilder, value, this._childName, this._expandSite, this._parentSchema)).Should().Throw<ArgumentNullException>().WithParameterName("parentName");
        FluentActions.Invoking(() => new RelatedOneToOne<TParent, TChild>(this._modelBuilder, value, this._parentTableName, this._childName, this._childTableName, this._expandSite, this._parentSchema, this._childSchema)).Should().Throw<ArgumentNullException>().WithParameterName("parentName");
    }

    /// <summary>
    /// Checks that the constructor throws when the childName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidChildName(string value)
    {
        FluentActions.Invoking(() => new RelatedOneToOne<TParent, TChild>(this._modelBuilder, this._parentName, value, this._expandSite, this._parentSchema)).Should().Throw<ArgumentNullException>().WithParameterName("childName");
        FluentActions.Invoking(() => new RelatedOneToOne<TParent, TChild>(this._modelBuilder, this._parentName, this._parentTableName, value, this._childTableName, this._expandSite, this._parentSchema, this._childSchema)).Should().Throw<ArgumentNullException>().WithParameterName("childName");
    }

    /// <summary>
    /// Checks that the constructor throws when the parentTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidParentTableName(string value)
    {
        FluentActions.Invoking(() => new RelatedOneToOne<TParent, TChild>(this._modelBuilder, this._parentName, value, this._childName, this._childTableName, this._expandSite, this._parentSchema, this._childSchema)).Should().Throw<ArgumentNullException>().WithParameterName("parentTableName");
    }

    /// <summary>
    /// Checks that the constructor throws when the childTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidChildTableName(string value)
    {
        FluentActions.Invoking(() => new RelatedOneToOne<TParent, TChild>(this._modelBuilder, this._parentName, this._parentTableName, this._childName, value, this._expandSite, this._parentSchema, this._childSchema)).Should().Throw<ArgumentNullException>().WithParameterName("childTableName");
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
        FluentActions.Invoking(() => new RelatedOneToOne<TParent, TChild>(this._modelBuilder, this._parentName, this._parentTableName, this._childName, this._childTableName, this._expandSite, this._parentSchema, value)).Should().Throw<ArgumentNullException>().WithParameterName("childSchema");
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