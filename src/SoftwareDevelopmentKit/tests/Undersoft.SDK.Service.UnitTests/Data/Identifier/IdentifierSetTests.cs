using System;
using System.Collections.ObjectModel;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Identifier;
using TObject = Undersoft.SDK.Service.Data.Remote.RemoteLink;

namespace Undersoft.SDK.Service.UnitTests.Data.Identifier;

/// <summary>
/// Unit tests for the type <see cref="IdentifierSet"/>.
/// </summary>
public class IdentifierSet_1Tests
{
    private class TestIdentifierSet : IdentifierSet<TObject>
    {
        public TestIdentifierSet() : base()
        {
        }

        public long PublicGetKeyForItem(Identifier<TObject> item)
        {
            return base.GetKeyForItem(item);
        }

        public void PublicClearItems()
        {
            base.ClearItems();
        }

        public void PublicSetItem(int index, Identifier<TObject> item)
        {
            base.SetItem(index, item);
        }

        public void PublicInsertItem(int index, Identifier<TObject> item)
        {
            base.InsertItem(index, item);
        }

        public void PublicRemoveItem(int index)
        {
            base.RemoveItem(index);
        }

        public KeyedCollection<long, Identifier<TObject>> PublicDictionary => base.Dictionary;
    }

    private TestIdentifierSet _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="IdentifierSet"/>.
    /// </summary>
    public IdentifierSet_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestIdentifierSet>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestIdentifierSet();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Search method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSearch()
    {
        // Arrange
        var id = _fixture.Create<object>();

        // Act
        var result = this._testClass.Search(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Search method throws when the id parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSearchWithNullId()
    {
        FluentActions.Invoking(() => this._testClass.Search(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("id");
    }

    /// <summary>
    /// Checks that the PublicGetKeyForItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetKeyForItem()
    {
        // Arrange
        var item = _fixture.Create<Identifier<TObject>>();

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
        FluentActions.Invoking(() => this._testClass.PublicGetKeyForItem(default(Identifier<TObject>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicClearItems method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClearItems()
    {
        // Act
        this._testClass.PublicClearItems();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicSetItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetItem()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var item = _fixture.Create<Identifier<TObject>>();

        // Act
        this._testClass.PublicSetItem(index, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicSetItem method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetItemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.PublicSetItem(_fixture.Create<int>(), default(Identifier<TObject>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicInsertItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsertItem()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var item = _fixture.Create<Identifier<TObject>>();

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
        FluentActions.Invoking(() => this._testClass.PublicInsertItem(_fixture.Create<int>(), default(Identifier<TObject>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PublicRemoveItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveItem()
    {
        // Arrange
        var index = _fixture.Create<int>();

        // Act
        this._testClass.PublicRemoveItem(index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UpdateIdentifiers method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUpdateIdentifiers()
    {
        // Arrange
        var model = _fixture.Create<TObject>();

        // Act
        this._testClass.UpdateIdentifiers(model);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDictionary property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicDictionary()
    {
        // Assert
        this._testClass.PublicDictionary.Should().BeAssignableTo<KeyedCollection<long, Identifier<TObject>>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForIdKind()
    {
        var testValue = _fixture.Create<Identifier<TObject>>();
        this._testClass[_fixture.Create<IdKind>()].Should().BeAssignableTo<Identifier<TObject>>();
        this._testClass[_fixture.Create<IdKind>()] = testValue;
        this._testClass[_fixture.Create<IdKind>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForObject()
    {
        var testValue = _fixture.Create<Identifier<TObject>>();
        this._testClass[_fixture.Create<object>()].Should().BeAssignableTo<Identifier<TObject>>();
        this._testClass[_fixture.Create<object>()] = testValue;
        this._testClass[_fixture.Create<object>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForInt()
    {
        var testValue = _fixture.Create<Identifier<TObject>>();
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<Identifier<TObject>>();
        this._testClass[_fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>()].Should().BeSameAs(testValue);
    }
}