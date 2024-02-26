using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Infrastructure.Database.Relation;
using TEntity = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests.Database.Relation;

/// <summary>
/// Unit tests for the type <see cref="RelatedSet"/>.
/// </summary>
[TestClass]
public class RelatedSet_1Tests
{
    private class TestRelatedSet : RelatedSet<TEntity>
    {
        public TestRelatedSet() : base()
        {
        }

        public TestRelatedSet(IEnumerable<TEntity> list) : base(list)
        {
        }

        public long PublicGetKeyForItem(TEntity item)
        {
            return base.GetKeyForItem(item);
        }
    }

    private TestRelatedSet _testClass;
    private IFixture _fixture;
    private IEnumerable<TEntity> _list;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RelatedSet"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._list = _fixture.Create<IEnumerable<TEntity>>();
        this._testClass = _fixture.Create<TestRelatedSet>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRelatedSet();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestRelatedSet(this._list);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the list parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullList()
    {
        FluentActions.Invoking(() => new TestRelatedSet(default(IEnumerable<TEntity>))).Should().Throw<ArgumentNullException>().WithParameterName("list");
    }

    /// <summary>
    /// Checks that the PublicGetKeyForItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetKeyForItem()
    {
        // Arrange
        var item = _fixture.Create<TEntity>();

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
        FluentActions.Invoking(() => this._testClass.PublicGetKeyForItem(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Single property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSingle()
    {
        // Assert
        this._testClass.Single.Should().BeAssignableTo<TEntity>();

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