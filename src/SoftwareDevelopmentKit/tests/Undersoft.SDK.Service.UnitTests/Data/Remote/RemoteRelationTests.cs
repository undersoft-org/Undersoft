using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Service.Data.Remote;
using Undersoft.SDK.Uniques;
using TOrigin = Undersoft.SDK.Stocks.StockContext;
using TTarget = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.UnitTests.Data.Remote;

/// <summary>
/// Unit tests for the type <see cref="RemoteRelation"/>.
/// </summary>
public class RemoteRelation_2Tests
{
    private class TestRemoteRelation : RemoteRelation<TOrigin, TTarget>
    {
        public TestRemoteRelation() : base()
        {
        }

        public override Expression<Func<TTarget, bool>> CreatePredicate(object entity)
        {
            return default(Expression<Func<TTarget, bool>>);
        }
    }

    private TestRemoteRelation _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteRelation"/>.
    /// </summary>
    public RemoteRelation_2Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestRemoteRelation>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRemoteRelation();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that setting the SourceKey property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSourceKey()
    {
        this._testClass.CheckProperty(x => x.SourceKey, _fixture.Create<Expression<Func<TOrigin, object>>>(), _fixture.Create<Expression<Func<TOrigin, object>>>());
    }

    /// <summary>
    /// Checks that setting the JoinKey property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetJoinKey()
    {
        this._testClass.CheckProperty(x => x.JoinKey, _fixture.Create<Expression<Func<IRemoteLink<TOrigin, TTarget>, object>>>(), _fixture.Create<Expression<Func<IRemoteLink<TOrigin, TTarget>, object>>>());
    }

    /// <summary>
    /// Checks that setting the TargetKey property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTargetKey()
    {
        this._testClass.CheckProperty(x => x.TargetKey, _fixture.Create<Expression<Func<TTarget, object>>>(), _fixture.Create<Expression<Func<TTarget, object>>>());
    }

    /// <summary>
    /// Checks that setting the Predicate property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPredicate()
    {
        this._testClass.CheckProperty(x => x.Predicate, x => _fixture.Create<Expression<Func<TTarget, bool>>>(), x => _fixture.Create<Expression<Func<TTarget, bool>>>());
    }

    /// <summary>
    /// Checks that setting the MiddleSet property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMiddleSet()
    {
        this._testClass.CheckProperty(x => x.MiddleSet, _fixture.Create<Expression<Func<TOrigin, IEnumerable<IRemoteLink<TOrigin, TTarget>>>>>(), _fixture.Create<Expression<Func<TOrigin, IEnumerable<IRemoteLink<TOrigin, TTarget>>>>>());
    }

    /// <summary>
    /// Checks that the RemoteRubric property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRemoteRubric()
    {
        // Assert
        this._testClass.RemoteRubric.Should().BeAssignableTo<MemberRubric>();

        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="RemoteRelation"/>.
/// </summary>
public class RemoteRelationTests
{
    private class TestRemoteRelation : RemoteRelation
    {
        public TestRemoteRelation() : base()
        {
        }
    }

    private TestRemoteRelation _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteRelation"/>.
    /// </summary>
    public RemoteRelationTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestRemoteRelation>();
    }

    /// <summary>
    /// Checks that setting the Name property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetName()
    {
        this._testClass.CheckProperty(x => x.Name);
    }

    /// <summary>
    /// Checks that setting the Towards property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTowards()
    {
        this._testClass.CheckProperty(x => x.Towards, _fixture.Create<Towards>(), _fixture.Create<Towards>());
    }

    /// <summary>
    /// Checks that the Empty property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetEmpty()
    {
        // Assert
        this._testClass.Empty.Should().BeAssignableTo<IUnique>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoteRubric property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRemoteRubric()
    {
        // Assert
        this._testClass.RemoteRubric.Should().BeAssignableTo<MemberRubric>();

        Assert.Fail("Create or modify test");
    }
}