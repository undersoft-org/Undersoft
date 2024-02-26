using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series.Universe;
using V = System.String;

namespace Undersoft.SDK.UnitTests.Series.Universe;

/// <summary>
/// Unit tests for the type <see cref="UniverseEnumerator"/>.
/// </summary>
public class UniverseEnumerator_1Tests
{
    private UniverseEnumerator<V> _testClass;
    private IFixture _fixture;
    private Universe<V> _map;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="UniverseEnumerator"/>.
    /// </summary>
    public UniverseEnumerator_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._map = _fixture.Create<Universe<V>>();
        this._testClass = _fixture.Create<UniverseEnumerator<V>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new UniverseEnumerator<V>(this._map);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the Map parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMap()
    {
        FluentActions.Invoking(() => new UniverseEnumerator<V>(default(Universe<V>))).Should().Throw<ArgumentNullException>().WithParameterName("Map");
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
    /// Checks that the HasNext method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallHasNext()
    {
        // Act
        var result = this._testClass.HasNext();

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
    /// Checks that the Next method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNext()
    {
        // Act
        var result = this._testClass.Next();

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
    /// Checks that the Key property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetKey()
    {
        // Assert
        this._testClass.Key.As<object>().Should().BeAssignableTo<int>();

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