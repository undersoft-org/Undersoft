using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Remote;
using TSource = Undersoft.SDK.Stocks.StockContext;
using TTarget = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.UnitTests.Data.Remote;

/// <summary>
/// Unit tests for the type <see cref="RemoteLink"/>.
/// </summary>
public class RemoteLink_2Tests
{
    private RemoteLink<TSource, TTarget> _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteLink"/>.
    /// </summary>
    public RemoteLink_2Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RemoteLink<TSource, TTarget>>();
    }

    /// <summary>
    /// Checks that setting the LeftEntity property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLeftEntity()
    {
        this._testClass.CheckProperty(x => x.LeftEntity, _fixture.Create<TSource>(), _fixture.Create<TSource>());
    }

    /// <summary>
    /// Checks that setting the RightEntity property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRightEntity()
    {
        this._testClass.CheckProperty(x => x.RightEntity, _fixture.Create<TTarget>(), _fixture.Create<TTarget>());
    }
}

/// <summary>
/// Unit tests for the type <see cref="RemoteLink"/>.
/// </summary>
public class RemoteLinkTests
{
    private RemoteLink _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteLink"/>.
    /// </summary>
    public RemoteLinkTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RemoteLink>();
    }

    /// <summary>
    /// Checks that setting the LeftEntityId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLeftEntityId()
    {
        this._testClass.CheckProperty(x => x.LeftEntityId);
    }

    /// <summary>
    /// Checks that setting the LeftEntity property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLeftEntity()
    {
        this._testClass.CheckProperty(x => x.LeftEntity, _fixture.Create<object>(), _fixture.Create<object>());
    }

    /// <summary>
    /// Checks that setting the RightEntityId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRightEntityId()
    {
        this._testClass.CheckProperty(x => x.RightEntityId);
    }

    /// <summary>
    /// Checks that setting the RightEntity property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRightEntity()
    {
        this._testClass.CheckProperty(x => x.RightEntity, _fixture.Create<object>(), _fixture.Create<object>());
    }
}