using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series;
using Undersoft.SDK.Uniques;
using V = System.String;

namespace Undersoft.SDK.UnitTests.Series;

/// <summary>
/// Unit tests for the type <see cref="Catalog32"/>.
/// </summary>
public class Catalog32_1Tests
{
    private Catalog32<V> _testClass;
    private IFixture _fixture;
    private int __catalogSize;
    private HashBits _bits;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Catalog32"/>.
    /// </summary>
    public Catalog32_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this.__catalogSize = _fixture.Create<int>();
        this._bits = _fixture.Create<HashBits>();
        this._testClass = _fixture.Create<Catalog32<V>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Catalog32<V>(this.__catalogSize, this._bits);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the EmptyItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyItem()
    {
        // Act
        var result = this._testClass.EmptyItem();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EmptyTable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyTable()
    {
        // Arrange
        var size = _fixture.Create<int>();

        // Act
        var result = this._testClass.EmptyTable(size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithItem()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<V>>();

        // Act
        var result = this._testClass.NewItem(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithItemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithObjectAndV()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndVWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(object), _fixture.Create<V>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithObjectAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithLongAndV()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithLongAndVPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().Be(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithValue()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithValuePerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        result.Value.Should().Be(value);
    }
}