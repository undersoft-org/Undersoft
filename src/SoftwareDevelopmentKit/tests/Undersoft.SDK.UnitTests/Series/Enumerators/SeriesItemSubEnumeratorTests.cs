using System;
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
/// Unit tests for the type <see cref="SeriesItemSubEnumerator"/>.
/// </summary>
public class SeriesItemSubEnumerator_1Tests
{
    private SeriesItemSubEnumerator<V> _testClass;
    private IFixture _fixture;
    private Mock<ISeriesItem<V>> _map;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SeriesItemSubEnumerator"/>.
    /// </summary>
    public SeriesItemSubEnumerator_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._map = _fixture.Freeze<Mock<ISeriesItem<V>>>();
        this._testClass = _fixture.Create<SeriesItemSubEnumerator<V>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SeriesItemSubEnumerator<V>(this._map.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the map parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMap()
    {
        FluentActions.Invoking(() => new SeriesItemSubEnumerator<V>(default(ISeriesItem<V>))).Should().Throw<ArgumentNullException>().WithParameterName("map");
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