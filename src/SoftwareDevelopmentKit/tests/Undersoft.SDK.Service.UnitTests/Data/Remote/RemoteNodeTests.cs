using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Remote;
using TLeft = Undersoft.SDK.Stocks.StockContext;
using TRight = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.UnitTests.Data.Remote;

/// <summary>
/// Unit tests for the type <see cref="RemoteNode"/>.
/// </summary>
public class RemoteNode_2Tests
{
    private class TestRemoteNode : RemoteNode<TLeft, TRight>
    {
        public TestRemoteNode() : base()
        {
        }

        public TestRemoteNode(IEnumerable<IRemoteLink<TLeft, TRight>> list) : base(list)
        {
        }

        public long PublicGetKeyForItem(IRemoteLink<TLeft, TRight> item)
        {
            return base.GetKeyForItem(item);
        }

        public void PublicInsertItem(int index, IRemoteLink<TLeft, TRight> item)
        {
            base.InsertItem(index, item);
        }
    }

    private TestRemoteNode _testClass;
    private IFixture _fixture;
    private IEnumerable<IRemoteLink<TLeft, TRight>> _list;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteNode"/>.
    /// </summary>
    public RemoteNode_2Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._list = _fixture.Create<IEnumerable<IRemoteLink<TLeft, TRight>>>();
        this._testClass = _fixture.Create<TestRemoteNode>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRemoteNode();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRemoteNode(this._list);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the list parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullList()
    {
        FluentActions.Invoking(() => new TestRemoteNode(default(IEnumerable<IRemoteLink<TLeft, TRight>>))).Should().Throw<ArgumentNullException>().WithParameterName("list");
    }

    /// <summary>
    /// Checks that the PublicGetKeyForItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetKeyForItem()
    {
        // Arrange
        var item = _fixture.Create<IRemoteLink<TLeft, TRight>>();

        // Act
        var result = this._testClass.PublicGetKeyForItem(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicGetKeyForItem method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetKeyForItemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicGetKeyForItem(default(IRemoteLink<TLeft, TRight>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicInsertItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsertItem()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var item = _fixture.Create<IRemoteLink<TLeft, TRight>>();

        // Act
        this._testClass.PublicInsertItem(index, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicInsertItem method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInsertItemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicInsertItem(_fixture.Create<int>(), default(IRemoteLink<TLeft, TRight>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Single property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSingle()
    {
        // Assert
        this._testClass.Single.Should().BeAssignableTo<IRemoteLink<TLeft, TRight>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexer()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<object>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<object>()] = testValue;
        this._testClass[_fixture.Create<object>()].Should().BeSameAs(testValue);
    }
}