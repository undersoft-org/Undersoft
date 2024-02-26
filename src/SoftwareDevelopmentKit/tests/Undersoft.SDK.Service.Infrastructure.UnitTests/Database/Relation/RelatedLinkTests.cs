using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Infrastructure.Database.Relation;
using TLeft = Undersoft.SDK.Stocks.StockContext;
using TRight = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests.Database.Relation;

/// <summary>
/// Unit tests for the type <see cref="RelatedLink"/>.
/// </summary>
[TestClass]
public class RelatedLink_2Tests
{
    private RelatedLink<TLeft, TRight> _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RelatedLink"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RelatedLink<TLeft, TRight>>();
    }

    /// <summary>
    /// Checks that setting the RightEntity property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRightEntity()
    {
        this._testClass.CheckProperty(x => x.RightEntity, _fixture.Create<TRight>(), _fixture.Create<TRight>());
    }

    /// <summary>
    /// Checks that setting the LeftEntity property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLeftEntity()
    {
        this._testClass.CheckProperty(x => x.LeftEntity, _fixture.Create<TLeft>(), _fixture.Create<TLeft>());
    }
}

/// <summary>
/// Unit tests for the type <see cref="RelatedLink"/>.
/// </summary>
[TestClass]
public class RelatedLinkTests
{
    private RelatedLink _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RelatedLink"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RelatedLink>();
    }

    /// <summary>
    /// Checks that setting the RightEntityId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRightEntityId()
    {
        this._testClass.CheckProperty(x => x.RightEntityId, _fixture.Create<long?>(), _fixture.Create<long?>());
    }

    /// <summary>
    /// Checks that setting the LeftEntityId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLeftEntityId()
    {
        this._testClass.CheckProperty(x => x.LeftEntityId, _fixture.Create<long?>(), _fixture.Create<long?>());
    }
}