using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Series;
using Undersoft.SDK.Series.Enumerators;
using V = System.String;

namespace Undersoft.SDK.UnitTests.Series.Enumerators;

/// <summary>
/// Unit tests for the type <see cref="SeriesItemEnumerator"/>.
/// </summary>
public class SeriesItemEnumerator_1Tests
{
    private SeriesItemEnumerator<V> _testClass;
    private IFixture _fixture;
    private Mock<ISeries<V>> _map;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SeriesItemEnumerator"/>.
    /// </summary>
    public SeriesItemEnumerator_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._map = _fixture.Freeze<Mock<ISeries<V>>>();
        this._testClass = _fixture.Create<SeriesItemEnumerator<V>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SeriesItemEnumerator<V>(this._map.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the Map parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMap()
    {
        FluentActions.Invoking(() => new SeriesItemEnumerator<V>(default(ISeries<V>))).Should().Throw<ArgumentNullException>().WithParameterName("Map");
    }

    /// <summary>
    /// Checks that the Dispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDispose()
    {
        // Act
        this._testClass.Dispose();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MoveNext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMoveNext()
    {
        // Act
        var result = this._testClass.MoveNext();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Reset method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReset()
    {
        // Act
        this._testClass.Reset();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Current property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetCurrent()
    {
        // Assert
        this._testClass.Current.Should().BeAssignableTo<object>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Index property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIndex()
    {
        // Assert
        this._testClass.Index.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetKey()
    {
        // Assert
        this._testClass.Key.As<object>().Should().BeAssignableTo<long>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Value property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetValue()
    {
        // Assert
        this._testClass.Value.As<object>().Should().BeAssignableTo<V>();

        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="ItemSeriesAsync"/>.
/// </summary>
public class ItemSeriesAsync_1Tests
{
    private ItemSeriesAsync<V> _testClass;
    private IFixture _fixture;
    private Mock<ISeries<V>> _map;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ItemSeriesAsync"/>.
    /// </summary>
    public ItemSeriesAsync_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._map = _fixture.Freeze<Mock<ISeries<V>>>();
        this._testClass = _fixture.Create<ItemSeriesAsync<V>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ItemSeriesAsync<V>(this._map.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the Map parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMap()
    {
        FluentActions.Invoking(() => new ItemSeriesAsync<V>(default(ISeries<V>))).Should().Throw<ArgumentNullException>().WithParameterName("Map");
    }

    /// <summary>
    /// Checks that the DisposeAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallDisposeAsync()
    {
        // Act
        await this._testClass.DisposeAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MoveNext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMoveNext()
    {
        // Act
        var result = this._testClass.MoveNext();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MoveNextAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallMoveNextAsync()
    {
        // Act
        var result = await this._testClass.MoveNextAsync();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Reset method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReset()
    {
        // Act
        this._testClass.Reset();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Current property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetCurrent()
    {
        // Assert
        this._testClass.Current.Should().BeAssignableTo<object>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Index property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIndex()
    {
        // Assert
        this._testClass.Index.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetKey()
    {
        // Assert
        this._testClass.Key.As<object>().Should().BeAssignableTo<long>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Value property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetValue()
    {
        // Assert
        this._testClass.Value.As<object>().Should().BeAssignableTo<V>();

        Assert.Fail("Create or modify test");
    }
}