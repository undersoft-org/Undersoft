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
/// Unit tests for the type <see cref="RemoteSetToSet"/>.
/// </summary>
public class RemoteSetToSet_2Tests
{
    private RemoteSetToSet<TOrigin, TTarget> _testClass;
    private IFixture _fixture;
    private Expression<Func<IRemoteLink<TOrigin, TTarget>, object>> _joinKey;
    private Expression<Func<TTarget, object>> _targetKey;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteSetToSet"/>.
    /// </summary>
    public RemoteSetToSet_2Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._joinKey = _fixture.Create<Expression<Func<IRemoteLink<TOrigin, TTarget>, object>>>();
        this._targetKey = _fixture.Create<Expression<Func<TTarget, object>>>();
        this._testClass = _fixture.Create<RemoteSetToSet<TOrigin, TTarget>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteSetToSet<TOrigin, TTarget>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteSetToSet<TOrigin, TTarget>(this._joinKey, this._targetKey);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the joinKey parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullJoinKey()
    {
        FluentActions.Invoking(() => new RemoteSetToSet<TOrigin, TTarget>(default(Expression<Func<IRemoteLink<TOrigin, TTarget>, object>>), this._targetKey)).Should().Throw<ArgumentNullException>().WithParameterName("joinKey");
    }

    /// <summary>
    /// Checks that instance construction throws when the targetKey parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTargetKey()
    {
        FluentActions.Invoking(() => new RemoteSetToSet<TOrigin, TTarget>(this._joinKey, default(Expression<Func<TTarget, object>>))).Should().Throw<ArgumentNullException>().WithParameterName("targetKey");
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