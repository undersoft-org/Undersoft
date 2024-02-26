using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Infrastructure.Database;
using Undersoft.SDK.Service.Infrastructure.Database.Relation;
using TContext = System.String;
using TEntity = System.String;
using TLeft = System.String;
using TRight = System.String;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests.Database;

/// <summary>
/// Unit tests for the type <see cref="EntityTypeMapping"/>.
/// </summary>
[TestClass]
public class EntityTypeMapping_1Tests
{
    private class TestEntityTypeMapping : EntityTypeMapping<TEntity>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
        }
    }

    private TestEntityTypeMapping _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EntityTypeMapping"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestEntityTypeMapping>();
    }

    /// <summary>
    /// Checks that the SetBuilder method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetBuilder()
    {
        // Arrange
        var modelBuilder = _fixture.Create<ModelBuilder>();

        // Act
        this._testClass.SetBuilder(modelBuilder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetBuilder method throws when the modelBuilder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetBuilderWithNullModelBuilder()
    {
        FluentActions.Invoking(() => this._testClass.SetBuilder(default(ModelBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("modelBuilder");
    }
}

/// <summary>
/// Unit tests for the type <see cref="DbStoreModelBuilderExtensions"/>.
/// </summary>
[TestClass]
public class DbStoreModelBuilderExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ApplyIdentity method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallApplyIdentity()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();

        // Act
        var result = builder.ApplyIdentity<TContext>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ApplyIdentity method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyIdentityWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).ApplyIdentity<TContext>()).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the ApplyMapping method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallApplyMapping()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var entityBuilder = _fixture.Create<EntityTypeMapping<TEntity>>();

        // Act
        var result = builder.ApplyMapping<TEntity>(entityBuilder
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ApplyMapping method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyMappingWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).ApplyMapping<TEntity>(_fixture.Create<EntityTypeMapping<TEntity>>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the ApplyMapping method throws when the entityBuilder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyMappingWithNullEntityBuilder()
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().ApplyMapping<TEntity>(default(EntityTypeMapping<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("entityBuilder");
    }

    /// <summary>
    /// Checks that the ApplyIdentifiers method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallApplyIdentifiersWithBuilderAndType()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = builder.ApplyIdentifiers(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ApplyIdentifiers method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyIdentifiersWithBuilderAndTypeWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).ApplyIdentifiers(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the ApplyIdentifiers method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyIdentifiersWithBuilderAndTypeWithNullType()
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().ApplyIdentifiers(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the ApplyIdentifiers method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallApplyIdentifiersWithTEntityAndModelBuilder()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();

        // Act
        var result = builder.ApplyIdentifiers<TEntity>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ApplyIdentifiers method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyIdentifiersWithTEntityAndModelBuilderWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).ApplyIdentifiers<TEntity>()).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndExpandSiteAndBoolAndString()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var expandSite = _fixture.Create<ExpandSite>();
        var autoinclude = _fixture.Create<bool>();
        var dbSchema = _fixture.Create<string>();

        // Act
        var result = builder.RelateSetToSet<TLeft, TRight>(expandSite, autoinclude, dbSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndExpandSiteAndBoolAndStringWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RelateSetToSet<TLeft, TRight>(_fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the dbSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndExpandSiteAndBoolAndStringWithInvalidDbSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<ExpandSite>(), _fixture.Create<bool>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("dbSchema");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelateSetToSetWithBuilderAndLeftMemberAndRightMemberAndExpandSiteAndAutoincludeAndParentSchemaAndChildSchema()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var leftMember = _fixture.Create<Expression<Func<TRight, object>>>();
        var rightMember = _fixture.Create<Expression<Func<TLeft, object>>>();
        var expandSite = _fixture.Create<ExpandSite>();
        var autoinclude = _fixture.Create<bool>();
        var parentSchema = _fixture.Create<string>();
        var childSchema = _fixture.Create<string>();

        // Act
        var result = builder.RelateSetToSet<TLeft, TRight>(leftMember, rightMember, expandSite, autoinclude, parentSchema, childSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRelateSetToSetWithBuilderAndLeftMemberAndRightMemberAndExpandSiteAndAutoincludeAndParentSchemaAndChildSchemaWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RelateSetToSet<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), _fixture.Create<Expression<Func<TLeft, object>>>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the parentSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithBuilderAndLeftMemberAndRightMemberAndExpandSiteAndAutoincludeAndParentSchemaAndChildSchemaWithInvalidParentSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), _fixture.Create<Expression<Func<TLeft, object>>>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("parentSchema");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the childSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithBuilderAndLeftMemberAndRightMemberAndExpandSiteAndAutoincludeAndParentSchemaAndChildSchemaWithInvalidChildSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), _fixture.Create<Expression<Func<TLeft, object>>>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("childSchema");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelateSetToSetWithBuilderAndLeftMemberAndLeftTableNameAndRightMemberAndRightTableNameAndExpandSiteAndAutoincludeAndParentSchemaAndChildSchema()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var leftMember = _fixture.Create<Expression<Func<TRight, object>>>();
        var LeftTableName = _fixture.Create<string>();
        var rightMember = _fixture.Create<Expression<Func<TLeft, object>>>();
        var rightTableName = _fixture.Create<string>();
        var expandSite = _fixture.Create<ExpandSite>();
        var autoinclude = _fixture.Create<bool>();
        var parentSchema = _fixture.Create<string>();
        var childSchema = _fixture.Create<string>();

        // Act
        var result = builder.RelateSetToSet<TLeft, TRight>(leftMember, LeftTableName, rightMember, rightTableName, expandSite, autoinclude, parentSchema, childSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRelateSetToSetWithBuilderAndLeftMemberAndLeftTableNameAndRightMemberAndRightTableNameAndExpandSiteAndAutoincludeAndParentSchemaAndChildSchemaWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RelateSetToSet<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), _fixture.Create<string>(), _fixture.Create<Expression<Func<TLeft, object>>>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the LeftTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithBuilderAndLeftMemberAndLeftTableNameAndRightMemberAndRightTableNameAndExpandSiteAndAutoincludeAndParentSchemaAndChildSchemaWithInvalidLeftTableName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), value, _fixture.Create<Expression<Func<TLeft, object>>>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("LeftTableName");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the rightTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithBuilderAndLeftMemberAndLeftTableNameAndRightMemberAndRightTableNameAndExpandSiteAndAutoincludeAndParentSchemaAndChildSchemaWithInvalidRightTableName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), _fixture.Create<string>(), _fixture.Create<Expression<Func<TLeft, object>>>(), value, _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("rightTableName");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the parentSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithBuilderAndLeftMemberAndLeftTableNameAndRightMemberAndRightTableNameAndExpandSiteAndAutoincludeAndParentSchemaAndChildSchemaWithInvalidParentSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), _fixture.Create<string>(), _fixture.Create<Expression<Func<TLeft, object>>>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("parentSchema");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the childSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithBuilderAndLeftMemberAndLeftTableNameAndRightMemberAndRightTableNameAndExpandSiteAndAutoincludeAndParentSchemaAndChildSchemaWithInvalidChildSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), _fixture.Create<string>(), _fixture.Create<Expression<Func<TLeft, object>>>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("childSchema");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndString()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var leftName = _fixture.Create<string>();
        var rightName = _fixture.Create<string>();
        var expandSite = _fixture.Create<ExpandSite>();
        var autoinclude = _fixture.Create<bool>();
        var dbSchema = _fixture.Create<string>();

        // Act
        var result = builder.RelateSetToSet<TLeft, TRight>(leftName, rightName, expandSite, autoinclude, dbSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndStringWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RelateSetToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the leftName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndStringWithInvalidLeftName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(value, _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("leftName");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the rightName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndStringWithInvalidRightName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<string>(), value, _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("rightName");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the dbSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndStringWithInvalidDbSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("dbSchema");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndString()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var leftName = _fixture.Create<string>();
        var leftTableName = _fixture.Create<string>();
        var rightName = _fixture.Create<string>();
        var rightTableName = _fixture.Create<string>();
        var expandSite = _fixture.Create<ExpandSite>();
        var autoinclude = _fixture.Create<bool>();
        var parentSchema = _fixture.Create<string>();
        var childSchema = _fixture.Create<string>();

        // Act
        var result = builder.RelateSetToSet<TLeft, TRight>(leftName, leftTableName, rightName, rightTableName, expandSite, autoinclude, parentSchema, childSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RelateSetToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the leftName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidLeftName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(value, _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("leftName");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the leftTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidLeftTableName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<string>(), value, _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("leftTableName");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the rightName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidRightName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), value, _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("rightName");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the rightTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidRightTableName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), value, _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("rightTableName");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the parentSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidParentSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("parentSchema");
    }

    /// <summary>
    /// Checks that the RelateSetToSet method throws when the childSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateSetToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidChildSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateSetToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("childSchema");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRalateSetToSetExplicitlyWithBuilderAndLeftNameAndRightNameAndExpandSiteAndDbSchema()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var leftName = _fixture.Create<string>();
        var rightName = _fixture.Create<string>();
        var expandSite = _fixture.Create<ExpandSite>();
        var dbSchema = _fixture.Create<string>();

        // Act
        var result = builder.RalateSetToSetExplicitly<TLeft, TRight>(leftName, rightName, expandSite, dbSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRalateSetToSetExplicitlyWithBuilderAndLeftNameAndRightNameAndExpandSiteAndDbSchemaWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RalateSetToSetExplicitly<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method throws when the leftName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRalateSetToSetExplicitlyWithBuilderAndLeftNameAndRightNameAndExpandSiteAndDbSchemaWithInvalidLeftName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RalateSetToSetExplicitly<TLeft, TRight>(value, _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("leftName");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method throws when the rightName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRalateSetToSetExplicitlyWithBuilderAndLeftNameAndRightNameAndExpandSiteAndDbSchemaWithInvalidRightName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RalateSetToSetExplicitly<TLeft, TRight>(_fixture.Create<string>(), value, _fixture.Create<ExpandSite>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("rightName");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method throws when the dbSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRalateSetToSetExplicitlyWithBuilderAndLeftNameAndRightNameAndExpandSiteAndDbSchemaWithInvalidDbSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RalateSetToSetExplicitly<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("dbSchema");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRalateSetToSetExplicitlyWithBuilderAndLeftMemberAndRighMemberAndExpandSiteAndDbSchema()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var leftMember = _fixture.Create<Expression<Func<TRight, object>>>();
        var righMember = _fixture.Create<Expression<Func<TLeft, object>>>();
        var expandSite = _fixture.Create<ExpandSite>();
        var dbSchema = _fixture.Create<string>();

        // Act
        var result = builder.RalateSetToSetExplicitly<TLeft, TRight>(leftMember, righMember, expandSite, dbSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRalateSetToSetExplicitlyWithBuilderAndLeftMemberAndRighMemberAndExpandSiteAndDbSchemaWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RalateSetToSetExplicitly<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), _fixture.Create<Expression<Func<TLeft, object>>>(), _fixture.Create<ExpandSite>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method throws when the dbSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRalateSetToSetExplicitlyWithBuilderAndLeftMemberAndRighMemberAndExpandSiteAndDbSchemaWithInvalidDbSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RalateSetToSetExplicitly<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), _fixture.Create<Expression<Func<TLeft, object>>>(), _fixture.Create<ExpandSite>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("dbSchema");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRalateSetToSetExplicitlyWithBuilderAndLeftNameAndLeftTableNameAndRightNameAndRightTableNameAndExpandSiteAndParentSchemaAndChildSchema()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var leftName = _fixture.Create<string>();
        var leftTableName = _fixture.Create<string>();
        var rightName = _fixture.Create<string>();
        var rightTableName = _fixture.Create<string>();
        var expandSite = _fixture.Create<ExpandSite>();
        var parentSchema = _fixture.Create<string>();
        var childSchema = _fixture.Create<string>();

        // Act
        var result = builder.RalateSetToSetExplicitly<TLeft, TRight>(leftName, leftTableName, rightName, rightTableName, expandSite, parentSchema, childSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRalateSetToSetExplicitlyWithBuilderAndLeftNameAndLeftTableNameAndRightNameAndRightTableNameAndExpandSiteAndParentSchemaAndChildSchemaWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RalateSetToSetExplicitly<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method throws when the leftName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRalateSetToSetExplicitlyWithBuilderAndLeftNameAndLeftTableNameAndRightNameAndRightTableNameAndExpandSiteAndParentSchemaAndChildSchemaWithInvalidLeftName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RalateSetToSetExplicitly<TLeft, TRight>(value, _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("leftName");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method throws when the leftTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRalateSetToSetExplicitlyWithBuilderAndLeftNameAndLeftTableNameAndRightNameAndRightTableNameAndExpandSiteAndParentSchemaAndChildSchemaWithInvalidLeftTableName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RalateSetToSetExplicitly<TLeft, TRight>(_fixture.Create<string>(), value, _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("leftTableName");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method throws when the rightName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRalateSetToSetExplicitlyWithBuilderAndLeftNameAndLeftTableNameAndRightNameAndRightTableNameAndExpandSiteAndParentSchemaAndChildSchemaWithInvalidRightName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RalateSetToSetExplicitly<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), value, _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("rightName");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method throws when the rightTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRalateSetToSetExplicitlyWithBuilderAndLeftNameAndLeftTableNameAndRightNameAndRightTableNameAndExpandSiteAndParentSchemaAndChildSchemaWithInvalidRightTableName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RalateSetToSetExplicitly<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), value, _fixture.Create<ExpandSite>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("rightTableName");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method throws when the parentSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRalateSetToSetExplicitlyWithBuilderAndLeftNameAndLeftTableNameAndRightNameAndRightTableNameAndExpandSiteAndParentSchemaAndChildSchemaWithInvalidParentSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RalateSetToSetExplicitly<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("parentSchema");
    }

    /// <summary>
    /// Checks that the RalateSetToSetExplicitly method throws when the childSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRalateSetToSetExplicitlyWithBuilderAndLeftNameAndLeftTableNameAndRightNameAndRightTableNameAndExpandSiteAndParentSchemaAndChildSchemaWithInvalidChildSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RalateSetToSetExplicitly<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("childSchema");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelateOneToSetWithTLeftAndTRightAndModelBuilderAndExpandSiteAndBoolAndString()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var expandSite = _fixture.Create<ExpandSite>();
        var autoinclude = _fixture.Create<bool>();
        var dbSchema = _fixture.Create<string>();

        // Act
        var result = builder.RelateOneToSet<TLeft, TRight>(expandSite, autoinclude, dbSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRelateOneToSetWithTLeftAndTRightAndModelBuilderAndExpandSiteAndBoolAndStringWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RelateOneToSet<TLeft, TRight>(_fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the dbSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToSetWithTLeftAndTRightAndModelBuilderAndExpandSiteAndBoolAndStringWithInvalidDbSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToSet<TLeft, TRight>(_fixture.Create<ExpandSite>(), _fixture.Create<bool>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("dbSchema");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelateOneToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndString()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var leftName = _fixture.Create<string>();
        var rightName = _fixture.Create<string>();
        var expandSite = _fixture.Create<ExpandSite>();
        var autoinclude = _fixture.Create<bool>();
        var dbSchema = _fixture.Create<string>();

        // Act
        var result = builder.RelateOneToSet<TLeft, TRight>(leftName, rightName, expandSite, autoinclude, dbSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRelateOneToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndStringWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RelateOneToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the leftName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndStringWithInvalidLeftName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToSet<TLeft, TRight>(value, _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("leftName");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the rightName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndStringWithInvalidRightName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToSet<TLeft, TRight>(_fixture.Create<string>(), value, _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("rightName");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the dbSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToSetWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndStringWithInvalidDbSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("dbSchema");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelateOneToSetWithTLeftAndTRightAndModelBuilderAndExpressionOfFuncOfTRightAndObjectAndExpressionOfFuncOfTLeftAndObjectAndExpandSiteAndBoolAndString()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var leftMember = _fixture.Create<Expression<Func<TRight, object>>>();
        var rightMember = _fixture.Create<Expression<Func<TLeft, object>>>();
        var expandSite = _fixture.Create<ExpandSite>();
        var autoinclude = _fixture.Create<bool>();
        var dbSchema = _fixture.Create<string>();

        // Act
        var result = builder.RelateOneToSet<TLeft, TRight>(leftMember, rightMember, expandSite, autoinclude, dbSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRelateOneToSetWithTLeftAndTRightAndModelBuilderAndExpressionOfFuncOfTRightAndObjectAndExpressionOfFuncOfTLeftAndObjectAndExpandSiteAndBoolAndStringWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RelateOneToSet<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), _fixture.Create<Expression<Func<TLeft, object>>>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the dbSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToSetWithTLeftAndTRightAndModelBuilderAndExpressionOfFuncOfTRightAndObjectAndExpressionOfFuncOfTLeftAndObjectAndExpandSiteAndBoolAndStringWithInvalidDbSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToSet<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), _fixture.Create<Expression<Func<TLeft, object>>>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("dbSchema");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelateOneToSetWithModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndString()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var leftName = _fixture.Create<string>();
        var leftTableName = _fixture.Create<string>();
        var rightName = _fixture.Create<string>();
        var rightTableName = _fixture.Create<string>();
        var expandSite = _fixture.Create<ExpandSite>();
        var autoinclude = _fixture.Create<bool>();
        var parentSchema = _fixture.Create<string>();
        var childSchema = _fixture.Create<string>();

        // Act
        var result = builder.RelateOneToSet<TLeft, TRight>(leftName, leftTableName, rightName, rightTableName, expandSite, autoinclude, parentSchema, childSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRelateOneToSetWithModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RelateOneToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the leftName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToSetWithModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidLeftName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToSet<TLeft, TRight>(value, _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("leftName");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the leftTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToSetWithModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidLeftTableName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToSet<TLeft, TRight>(_fixture.Create<string>(), value, _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("leftTableName");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the rightName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToSetWithModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidRightName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), value, _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("rightName");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the rightTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToSetWithModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidRightTableName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), value, _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("rightTableName");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the parentSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToSetWithModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidParentSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("parentSchema");
    }

    /// <summary>
    /// Checks that the RelateOneToSet method throws when the childSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToSetWithModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidChildSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToSet<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("childSchema");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelateOneToOneWithModelBuilderAndExpandSiteAndBoolAndString()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var expandSite = _fixture.Create<ExpandSite>();
        var autoinclude = _fixture.Create<bool>();
        var dbSchema = _fixture.Create<string>();

        // Act
        var result = builder.RelateOneToOne<TLeft, TRight>(expandSite, autoinclude, dbSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRelateOneToOneWithModelBuilderAndExpandSiteAndBoolAndStringWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RelateOneToOne<TLeft, TRight>(_fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the dbSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToOneWithModelBuilderAndExpandSiteAndBoolAndStringWithInvalidDbSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToOne<TLeft, TRight>(_fixture.Create<ExpandSite>(), _fixture.Create<bool>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("dbSchema");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndString()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var leftName = _fixture.Create<string>();
        var rightName = _fixture.Create<string>();
        var expandSite = _fixture.Create<ExpandSite>();
        var autoinclude = _fixture.Create<bool>();
        var dbSchema = _fixture.Create<string>();

        // Act
        var result = builder.RelateOneToOne<TLeft, TRight>(leftName, rightName, expandSite, autoinclude, dbSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndStringWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RelateOneToOne<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the leftName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndStringWithInvalidLeftName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToOne<TLeft, TRight>(value, _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("leftName");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the rightName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndStringWithInvalidRightName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToOne<TLeft, TRight>(_fixture.Create<string>(), value, _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("rightName");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the dbSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndStringAndStringAndExpandSiteAndBoolAndStringWithInvalidDbSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToOne<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("dbSchema");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndExpressionOfFuncOfTRightAndObjectAndExpressionOfFuncOfTLeftAndObjectAndExpandSiteAndBoolAndString()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var leftMember = _fixture.Create<Expression<Func<TRight, object>>>();
        var rightMember = _fixture.Create<Expression<Func<TLeft, object>>>();
        var expandSite = _fixture.Create<ExpandSite>();
        var autoinclude = _fixture.Create<bool>();
        var dbSchema = _fixture.Create<string>();

        // Act
        var result = builder.RelateOneToOne<TLeft, TRight>(leftMember, rightMember, expandSite, autoinclude, dbSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndExpressionOfFuncOfTRightAndObjectAndExpressionOfFuncOfTLeftAndObjectAndExpandSiteAndBoolAndStringWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RelateOneToOne<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), _fixture.Create<Expression<Func<TLeft, object>>>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the dbSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndExpressionOfFuncOfTRightAndObjectAndExpressionOfFuncOfTLeftAndObjectAndExpandSiteAndBoolAndStringWithInvalidDbSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToOne<TLeft, TRight>(_fixture.Create<Expression<Func<TRight, object>>>(), _fixture.Create<Expression<Func<TLeft, object>>>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("dbSchema");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndString()
    {
        // Arrange
        var builder = _fixture.Create<ModelBuilder>();
        var leftName = _fixture.Create<string>();
        var leftTableName = _fixture.Create<string>();
        var rightName = _fixture.Create<string>();
        var rightTableName = _fixture.Create<string>();
        var expandSite = _fixture.Create<ExpandSite>();
        var autoinclude = _fixture.Create<bool>();
        var parentSchema = _fixture.Create<string>();
        var childSchema = _fixture.Create<string>();

        // Act
        var result = builder.RelateOneToOne<TLeft, TRight>(leftName, leftTableName, rightName, rightTableName, expandSite, autoinclude, parentSchema, childSchema);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithNullBuilder()
    {
        FluentActions.Invoking(() => default(ModelBuilder).RelateOneToOne<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the leftName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidLeftName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToOne<TLeft, TRight>(value, _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("leftName");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the leftTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidLeftTableName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToOne<TLeft, TRight>(_fixture.Create<string>(), value, _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("leftTableName");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the rightName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidRightName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToOne<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), value, _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("rightName");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the rightTableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidRightTableName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToOne<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), value, _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("rightTableName");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the parentSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidParentSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToOne<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("parentSchema");
    }

    /// <summary>
    /// Checks that the RelateOneToOne method throws when the childSchema parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallRelateOneToOneWithTLeftAndTRightAndModelBuilderAndStringAndStringAndStringAndStringAndExpandSiteAndBoolAndStringAndStringWithInvalidChildSchema(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<ModelBuilder>().RelateOneToOne<TLeft, TRight>(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<ExpandSite>(), _fixture.Create<bool>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("childSchema");
    }
}