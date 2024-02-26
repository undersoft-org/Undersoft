using System;
using System.Linq;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Operation.Query;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TResult = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Query;

/// <summary>
/// Unit tests for the type <see cref="Query"/>.
/// </summary>
public class Query_3Tests
{
    private class TestQuery : Query<TStore, TEntity, TResult>
    {
        public TestQuery(object[] keys) : base(keys)
        {
        }

        public TestQuery(Func<IRepository<TEntity>, IQueryable<TEntity>> transformations) : base(transformations)
        {
        }

        public TestQuery(object[] keys, params Expression<Func<TEntity, object>>[] expanders) : base(keys, expanders)
        {
        }

        public TestQuery(Expression<Func<TEntity, bool>> predicate) : base(predicate)
        {
        }

        public TestQuery(params Expression<Func<TEntity, object>>[] expanders) : base(expanders)
        {
        }

        public TestQuery(
                                                                                       Expression<Func<TEntity, bool>> predicate,
                                                                                       params Expression<Func<TEntity, object>>[] expanders
                                                                                   ) : base(predicate, expanders
                                                                               )
        {
        }

        public TestQuery(
                                                                                       SortExpression<TEntity> sortTerms,
                                                                                       params Expression<Func<TEntity, object>>[] expanders
                                                                                   ) : base(sortTerms, expanders
                                                                               )
        {
        }

        public TestQuery(
                                                                                       Expression<Func<TEntity, bool>> predicate,
                                                                                       SortExpression<TEntity> sortTerms,
                                                                                       params Expression<Func<TEntity, object>>[] expanders
                                                                                   ) : base(predicate, sortTerms, expanders
                                                                               )
        {
        }
    }

    private TestQuery _testClass;
    private IFixture _fixture;
    private object[] _keys;
    private Func<IRepository<TEntity>, IQueryable<TEntity>> _transformations;
    private Expression<Func<TEntity, object>>[] _expanders;
    private Expression<Func<TEntity, bool>> _predicate;
    private SortExpression<TEntity> _sortTerms;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Query"/>.
    /// </summary>
    public Query_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._keys = _fixture.Create<object[]>();
        this._transformations = x => _fixture.Create<IQueryable<TEntity>>();
        this._expanders = _fixture.Create<Expression<Func<TEntity, object>>[]>();
        this._predicate = _fixture.Create<Expression<Func<TEntity, bool>>>();
        this._sortTerms = _fixture.Create<SortExpression<TEntity>>();
        this._testClass = _fixture.Create<TestQuery>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestQuery(this._keys);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestQuery(this._transformations);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestQuery(this._keys, this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestQuery(this._predicate);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestQuery(this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestQuery(this._predicate, this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestQuery(this._sortTerms, this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestQuery(this._predicate, this._sortTerms, this._expanders);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeys()
    {
        FluentActions.Invoking(() => new TestQuery(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
        FluentActions.Invoking(() => new TestQuery(default(object[]), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that instance construction throws when the transformations parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTransformations()
    {
        FluentActions.Invoking(() => new TestQuery(default(Func<IRepository<TEntity>, IQueryable<TEntity>>))).Should().Throw<ArgumentNullException>().WithParameterName("transformations");
    }

    /// <summary>
    /// Checks that instance construction throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpanders()
    {
        FluentActions.Invoking(() => new TestQuery(this._keys, default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new TestQuery(default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new TestQuery(this._predicate, default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new TestQuery(this._sortTerms, default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new TestQuery(this._predicate, this._sortTerms, default(Expression<Func<TEntity, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new TestQuery(default(Expression<Func<TEntity, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
        FluentActions.Invoking(() => new TestQuery(default(Expression<Func<TEntity, bool>>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
        FluentActions.Invoking(() => new TestQuery(default(Expression<Func<TEntity, bool>>), this._sortTerms, this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that instance construction throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSortTerms()
    {
        FluentActions.Invoking(() => new TestQuery(default(SortExpression<TEntity>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
        FluentActions.Invoking(() => new TestQuery(this._predicate, default(SortExpression<TEntity>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
    }

    /// <summary>
    /// Checks that the Offset property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOffset()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.Offset = testValue;

        // Assert
        this._testClass.Offset.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Limit property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLimit()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.Limit = testValue;

        // Assert
        this._testClass.Limit.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Count property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCount()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.Count = testValue;

        // Assert
        this._testClass.Count.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Processings property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProcessings()
    {
        // Arrange
        var testValue = _fixture.Create<Delegate>();

        // Act
        this._testClass.Processings = testValue;

        // Assert
        this._testClass.Processings.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Sort property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSort()
    {
        // Assert
        this._testClass.Sort.Should().BeAssignableTo<SortExpression<TEntity>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Input property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetInput()
    {
        // Assert
        this._testClass.Input.Should().BeAssignableTo<object>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Output property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetOutput()
    {
        // Assert
        this._testClass.Output.Should().BeAssignableTo<object>();

        Assert.Fail("Create or modify test");
    }
}