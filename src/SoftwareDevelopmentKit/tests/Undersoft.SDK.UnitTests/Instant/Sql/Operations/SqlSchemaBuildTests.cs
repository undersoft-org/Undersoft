using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Sql;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="SqlSchemaBuild"/>.
/// </summary>
public class SqlSchemaBuildTests
{
    private SqlSchemaBuild _testClass;
    private IFixture _fixture;
    private SqlConnection __sqlcn;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SqlSchemaBuild"/>.
    /// </summary>
    public SqlSchemaBuildTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this.__sqlcn = _fixture.Create<SqlConnection>();
        this._testClass = _fixture.Create<SqlSchemaBuild>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SqlSchemaBuild(this.__sqlcn);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the _sqlcn parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNull_sqlcn()
    {
        FluentActions.Invoking(() => new SqlSchemaBuild(default(SqlConnection))).Should().Throw<ArgumentNullException>().WithParameterName("_sqlcn");
    }

    /// <summary>
    /// Checks that the SchemaPrepare method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSchemaPrepare()
    {
        // Arrange
        var buildtype = _fixture.Create<BuildDbSchemaType>();

        // Act
        this._testClass.SchemaPrepare(buildtype);

        // Assert
        Assert.Fail("Create or modify test");
    }
}