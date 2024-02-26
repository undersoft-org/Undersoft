using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Sql;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="InstantSql"/>.
/// </summary>
public class InstantSql_1Tests
{
    private InstantSql<T> _testClass;
    private IFixture _fixture;
    private InstantSqlContext _sqlcontext;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSql"/>.
    /// </summary>
    public InstantSql_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._sqlcontext = _fixture.Create<InstantSqlContext>();
        this._testClass = _fixture.Create<InstantSql<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSql<T>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSql<T>(this._sqlcontext);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the sqlcontext parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSqlcontext()
    {
        FluentActions.Invoking(() => new InstantSql<T>(default(InstantSqlContext))).Should().Throw<ArgumentNullException>().WithParameterName("sqlcontext");
    }

    /// <summary>
    /// Checks that the InstantSeriesCreator property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetInstantSeriesCreator()
    {
        // Assert
        this._testClass.InstantSeriesCreator.Should().BeAssignableTo<IInstantSeries>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Context property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetContext()
    {
        // Assert
        this._testClass.Context.Should().BeAssignableTo<InstantSqlContext>();

        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="Sqlset"/>.
/// </summary>
public class SqlsetTests
{
    private Sqlset _testClass;
    private IFixture _fixture;
    private InstantSqlContext _sqlcontext;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Sqlset"/>.
    /// </summary>
    public SqlsetTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._sqlcontext = _fixture.Create<InstantSqlContext>();
        this._testClass = _fixture.Create<Sqlset>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Sqlset();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Sqlset(this._sqlcontext);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the sqlcontext parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSqlcontext()
    {
        FluentActions.Invoking(() => new Sqlset(default(InstantSqlContext))).Should().Throw<ArgumentNullException>().WithParameterName("sqlcontext");
    }

    /// <summary>
    /// Checks that the InstantSeriesCreator property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetInstantSeriesCreator()
    {
        // Assert
        this._testClass.InstantSeriesCreator.Should().BeAssignableTo<IInstantSeries>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Context property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetContext()
    {
        // Assert
        this._testClass.Context.Should().BeAssignableTo<InstantSqlContext>();

        Assert.Fail("Create or modify test");
    }
}