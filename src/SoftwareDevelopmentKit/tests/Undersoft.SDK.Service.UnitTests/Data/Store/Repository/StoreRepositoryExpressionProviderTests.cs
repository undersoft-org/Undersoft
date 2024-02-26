using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Data.Store.Repository;
using T = System.String;
using TEntity = Undersoft.SDK.Origin;
using TResult = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Store.Repository;

/// <summary>
/// Unit tests for the type <see cref="StoreRepositoryExpressionProvider"/>.
/// </summary>
public class StoreRepositoryExpressionProvider_1Tests
{
    private StoreRepositoryExpressionProvider<TEntity> _testClass;
    private IFixture _fixture;
    private Mock<IDataStoreContext> _context;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="StoreRepositoryExpressionProvider"/>.
    /// </summary>
    public StoreRepositoryExpressionProvider_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._context = _fixture.Freeze<Mock<IDataStoreContext>>();
        this._testClass = _fixture.Create<StoreRepositoryExpressionProvider<TEntity>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new StoreRepositoryExpressionProvider<TEntity>(this._context.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullContext()
    {
        FluentActions.Invoking(() => new StoreRepositoryExpressionProvider<TEntity>(default(IDataStoreContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
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

        _context.Setup(mock => mock.Query<TEntity>()).Returns(_fixture.Create<IQueryable<TEntity>>());

        // Act
        var result = this._testClass.Execute<TResult>(expression);

        // Assert
        _context.Verify(mock => mock.Query<TEntity>());

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