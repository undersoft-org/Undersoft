using System;
using System.Linq.Expressions;
using System.Threading;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Repository;
using T = System.String;
using TEntity = Undersoft.SDK.Service.Data.Entity.OpenEntity;
using TResult = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository;

/// <summary>
/// Unit tests for the type <see cref="RepositoryExpressionProvider"/>.
/// </summary>
public class RepositoryExpressionProvider_1Tests
{
    private RepositoryExpressionProvider<TEntity> _testClass;
    private IFixture _fixture;
    private DbSet<TEntity> _targetDbSet;
    private DataServiceQuery<TEntity> _targetDsSet;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RepositoryExpressionProvider"/>.
    /// </summary>
    public RepositoryExpressionProvider_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._targetDbSet = _fixture.Create<DbSet<TEntity>>();
        this._targetDsSet = _fixture.Create<DataServiceQuery<TEntity>>();
        this._testClass = _fixture.Create<RepositoryExpressionProvider<TEntity>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RepositoryExpressionProvider<TEntity>(this._targetDbSet);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RepositoryExpressionProvider<TEntity>(this._targetDsSet);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the targetDbSet parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTargetDbSet()
    {
        FluentActions.Invoking(() => new RepositoryExpressionProvider<TEntity>(default(DbSet<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("targetDbSet");
    }

    /// <summary>
    /// Checks that instance construction throws when the targetDsSet parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTargetDsSet()
    {
        FluentActions.Invoking(() => new RepositoryExpressionProvider<TEntity>(default(DataServiceQuery<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("targetDsSet");
    }

    /// <summary>
    /// Checks that the CreateQuery method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateQueryWithExpression()
    {
        // Arrange
        var expression = _fixture.Create<Expression>();

        // Act
        var result = this._testClass.CreateQuery(expression);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateQuery method throws when the expression parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateQueryWithExpressionWithNullExpression()
    {
        FluentActions.Invoking(() => this._testClass.CreateQuery(default(Expression))).Should().Throw<ArgumentNullException>().WithParameterName("expression");
    }

    /// <summary>
    /// Checks that the CreateQuery maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void CreateQueryWithExpressionPerformsMapping()
    {
        // Arrange
        var expression = _fixture.Create<Expression>();

        // Act
        var result = this._testClass.CreateQuery(expression);

        // Assert
        result.Expression.Should().BeSameAs(expression);
    }

    /// <summary>
    /// Checks that the CreateQuery method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateQueryWithTAndExpression()
    {
        // Arrange
        var expression = _fixture.Create<Expression>();

        // Act
        var result = this._testClass.CreateQuery<T>(expression);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateQuery method throws when the expression parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateQueryWithTAndExpressionWithNullExpression()
    {
        FluentActions.Invoking(() => this._testClass.CreateQuery<T>(default(Expression))).Should().Throw<ArgumentNullException>().WithParameterName("expression");
    }

    /// <summary>
    /// Checks that the Execute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExecuteWithExpression()
    {
        // Arrange
        var expression = _fixture.Create<Expression>();

        // Act
        var result = this._testClass.Execute(expression);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Execute method throws when the expression parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExecuteWithExpressionWithNullExpression()
    {
        FluentActions.Invoking(() => this._testClass.Execute(default(Expression))).Should().Throw<ArgumentNullException>().WithParameterName("expression");
    }

    /// <summary>
    /// Checks that the Execute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExecuteWithTResultAndExpression()
    {
        // Arrange
        var expression = _fixture.Create<Expression>();

        // Act
        var result = this._testClass.Execute<TResult>(expression);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Execute method throws when the expression parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExecuteWithTResultAndExpressionWithNullExpression()
    {
        FluentActions.Invoking(() => this._testClass.Execute<TResult>(default(Expression))).Should().Throw<ArgumentNullException>().WithParameterName("expression");
    }

    /// <summary>
    /// Checks that the ExecuteAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallExecuteAsync()
    {
        // Arrange
        var expression = _fixture.Create<Expression>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        // Act
        var result = this._testClass.ExecuteAsync<TResult>(expression, cancellationToken);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ExecuteAsync method throws when the expression parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallExecuteAsyncWithNullExpression()
    {
        FluentActions.Invoking(() => this._testClass.ExecuteAsync<TResult>(default(Expression), _fixture.Create<CancellationToken>())).Should().Throw<ArgumentNullException>().WithParameterName("expression");
    }
}