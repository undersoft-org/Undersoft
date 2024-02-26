using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Remote;
using TOrigin = Undersoft.SDK.Stocks.StockContext;
using TTarget = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.UnitTests.Data.Remote;

/// <summary>
/// Unit tests for the type <see cref="RemoteOneToOne"/>.
/// </summary>
public class RemoteOneToOne_2Tests
{
    private RemoteOneToOne<TOrigin, TTarget> _testClass;
    private IFixture _fixture;
    private Expression<Func<TOrigin, object>> _originkey;
    private Expression<Func<TTarget, object>> _targetkey;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteOneToOne"/>.
    /// </summary>
    public RemoteOneToOne_2Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._originkey = _fixture.Create<Expression<Func<TOrigin, object>>>();
        this._targetkey = _fixture.Create<Expression<Func<TTarget, object>>>();
        this._testClass = _fixture.Create<RemoteOneToOne<TOrigin, TTarget>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteOneToOne<TOrigin, TTarget>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteOneToOne<TOrigin, TTarget>(this._originkey, this._targetkey);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the originkey parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOriginkey()
    {
        FluentActions.Invoking(() => new RemoteOneToOne<TOrigin, TTarget>(default(Expression<Func<TOrigin, object>>), this._targetkey)).Should().Throw<ArgumentNullException>().WithParameterName("originkey");
    }

    /// <summary>
    /// Checks that instance construction throws when the targetkey parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTargetkey()
    {
        FluentActions.Invoking(() => new RemoteOneToOne<TOrigin, TTarget>(this._originkey, default(Expression<Func<TTarget, object>>))).Should().Throw<ArgumentNullException>().WithParameterName("targetkey");
    }

    /// <summary>
    /// Checks that the CreatePredicate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreatePredicate()
    {
        // Arrange
        var entity = _fixture.Create<object>();

        // Act
        var result = this._testClass.CreatePredicate(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreatePredicate method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreatePredicateWithNullEntity()
    {
        FluentActions.Invoking(() => this._testClass.CreatePredicate(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }
}