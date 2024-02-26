using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Query;
using Undersoft.SDK.Service.Operation.Remote.Query;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TResult = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Query;

/// <summary>
/// Unit tests for the type <see cref="RemoteQuery"/>.
/// </summary>
public class RemoteQuery_3Tests
{
    private class TestRemoteQuery : RemoteQuery<TStore, TDto, TResult>
    {
        public TestRemoteQuery(object[] keys) : base(keys)
        {
        }

        public TestRemoteQuery(object[] keys, params Expression<Func<TDto, object>>[] expanders) : base(keys, expanders)
        {
        }

        public TestRemoteQuery(Expression<Func<TDto, bool>> predicate) : base(predicate)
        {
        }

        public TestRemoteQuery(params Expression<Func<TDto, object>>[] expanders) : base(expanders)
        {
        }

        public TestRemoteQuery(
                                                                                          Expression<Func<TDto, bool>> predicate,
                                                                                          params Expression<Func<TDto, object>>[] expanders
                                                                                      ) : base(predicate, expanders
                                                                                  )
        {
        }

        public TestRemoteQuery(
                                                                                          SortExpression<TDto> sortTerms,
                                                                                          params Expression<Func<TDto, object>>[] expanders
                                                                                      ) : base(sortTerms, expanders
                                                                                  )
        {
        }

        public TestRemoteQuery(
                                                                                          Expression<Func<TDto, bool>> predicate,
                                                                                          SortExpression<TDto> sortTerms,
                                                                                          params Expression<Func<TDto, object>>[] expanders
                                                                                      ) : base(predicate, sortTerms, expanders
                                                                                  )
        {
        }
    }

    private TestRemoteQuery _testClass;
    private IFixture _fixture;
    private object[] _keys;
    private Expression<Func<TDto, object>>[] _expanders;
    private Expression<Func<TDto, bool>> _predicate;
    private SortExpression<TDto> _sortTerms;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteQuery"/>.
    /// </summary>
    public RemoteQuery_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._keys = _fixture.Create<object[]>();
        this._expanders = _fixture.Create<Expression<Func<TDto, object>>[]>();
        this._predicate = _fixture.Create<Expression<Func<TDto, bool>>>();
        this._sortTerms = _fixture.Create<SortExpression<TDto>>();
        this._testClass = _fixture.Create<TestRemoteQuery>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRemoteQuery(this._keys);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteQuery(this._keys, this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteQuery(this._predicate);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteQuery(this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteQuery(this._predicate, this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteQuery(this._sortTerms, this._expanders);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteQuery(this._predicate, this._sortTerms, this._expanders);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKeys()
    {
        FluentActions.Invoking(() => new TestRemoteQuery(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
        FluentActions.Invoking(() => new TestRemoteQuery(default(object[]), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that instance construction throws when the expanders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullExpanders()
    {
        FluentActions.Invoking(() => new TestRemoteQuery(this._keys, default(Expression<Func<TDto, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new TestRemoteQuery(default(Expression<Func<TDto, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new TestRemoteQuery(this._predicate, default(Expression<Func<TDto, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new TestRemoteQuery(this._sortTerms, default(Expression<Func<TDto, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
        FluentActions.Invoking(() => new TestRemoteQuery(this._predicate, this._sortTerms, default(Expression<Func<TDto, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("expanders");
    }

    /// <summary>
    /// Checks that instance construction throws when the predicate parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullPredicate()
    {
        FluentActions.Invoking(() => new TestRemoteQuery(default(Expression<Func<TDto, bool>>))).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
        FluentActions.Invoking(() => new TestRemoteQuery(default(Expression<Func<TDto, bool>>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
        FluentActions.Invoking(() => new TestRemoteQuery(default(Expression<Func<TDto, bool>>), this._sortTerms, this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("predicate");
    }

    /// <summary>
    /// Checks that instance construction throws when the sortTerms parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullSortTerms()
    {
        FluentActions.Invoking(() => new TestRemoteQuery(default(SortExpression<TDto>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
        FluentActions.Invoking(() => new TestRemoteQuery(this._predicate, default(SortExpression<TDto>), this._expanders)).Should().Throw<ArgumentNullException>().WithParameterName("sortTerms");
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
        this._testClass.Sort.Should().BeAssignableTo<SortExpression<TDto>>();

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