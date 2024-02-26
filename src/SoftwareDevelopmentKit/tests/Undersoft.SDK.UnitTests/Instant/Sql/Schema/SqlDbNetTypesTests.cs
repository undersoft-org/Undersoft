using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Instant.Sql;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="DbNetTypes"/>.
/// </summary>
public class DbNetTypesTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the SqlNetDefaults property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSqlNetDefaults()
    {
        // Assert
        DbNetTypes.SqlNetDefaults.Should().BeAssignableTo<Dictionary<Type, object>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SqlNetTypes property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSqlNetTypes()
    {
        // Assert
        DbNetTypes.SqlNetTypes.Should().BeAssignableTo<Dictionary<Type, string>>();

        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="SqlNetType"/>.
/// </summary>
public class SqlNetTypeTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the NetTypeToSql method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNetTypeToSql()
    {
        // Arrange
        var netType = _fixture.Create<Type>();

        // Act
        var result = SqlNetType.NetTypeToSql(netType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NetTypeToSql method throws when the netType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNetTypeToSqlWithNullNetType()
    {
        FluentActions.Invoking(() => SqlNetType.NetTypeToSql(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("netType");
    }

    /// <summary>
    /// Checks that the SqlNetVal method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSqlNetVal()
    {
        // Arrange
        var fieldRow = _fixture.Create<IInstant>();
        var fieldName = _fixture.Create<string>();
        var prefix = _fixture.Create<string>();
        var tableName = _fixture.Create<string>();

        // Act
        var result = SqlNetType.SqlNetVal(fieldRow, fieldName, prefix, tableName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SqlNetVal method throws when the fieldRow parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSqlNetValWithNullFieldRow()
    {
        FluentActions.Invoking(() => SqlNetType.SqlNetVal(default(IInstant), _fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("fieldRow");
    }

    /// <summary>
    /// Checks that the SqlNetVal method throws when the fieldName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSqlNetValWithInvalidFieldName(string value)
    {
        FluentActions.Invoking(() => SqlNetType.SqlNetVal(_fixture.Create<IInstant>(), value, _fixture.Create<string>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("fieldName");
    }

    /// <summary>
    /// Checks that the SqlNetVal method throws when the prefix parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSqlNetValWithInvalidPrefix(string value)
    {
        FluentActions.Invoking(() => SqlNetType.SqlNetVal(_fixture.Create<IInstant>(), _fixture.Create<string>(), value, _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("prefix");
    }

    /// <summary>
    /// Checks that the SqlNetVal method throws when the tableName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSqlNetValWithInvalidTableName(string value)
    {
        FluentActions.Invoking(() => SqlNetType.SqlNetVal(_fixture.Create<IInstant>(), _fixture.Create<string>(), _fixture.Create<string>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("tableName");
    }

    /// <summary>
    /// Checks that the SqlTypeToNet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSqlTypeToNet()
    {
        // Arrange
        var sqlType = _fixture.Create<string>();

        // Act
        var result = SqlNetType.SqlTypeToNet(sqlType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SqlTypeToNet method throws when the sqlType parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSqlTypeToNetWithInvalidSqlType(string value)
    {
        FluentActions.Invoking(() => SqlNetType.SqlTypeToNet(value)).Should().Throw<ArgumentNullException>().WithParameterName("sqlType");
    }
}