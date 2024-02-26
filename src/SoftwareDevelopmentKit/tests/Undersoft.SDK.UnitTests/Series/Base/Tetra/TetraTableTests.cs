using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series;
using Undersoft.SDK.Series.Base;
using Undersoft.SDK.Series.Base.Tetra;
using V = System.String;

namespace Undersoft.SDK.UnitTests.Series.Base.Tetra;

/// <summary>
/// Unit tests for the type <see cref="TetraTable"/>.
/// </summary>
public class TetraTable_1Tests
{
    private TetraTable<V> _testClass;
    private IFixture _fixture;
    private TetraSeriesBase<V> _hashcatalog;
    private int _size;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TetraTable"/>.
    /// </summary>
    public TetraTable_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._hashcatalog = _fixture.Create<TetraSeriesBase<V>>();
        this._size = _fixture.Create<int>();
        this._testClass = _fixture.Create<TetraTable<V>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TetraTable<V>(this._hashcatalog, this._size);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the hashcatalog parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullHashcatalog()
    {
        FluentActions.Invoking(() => new TetraTable<V>(default(TetraSeriesBase<V>), this._size)).Should().Throw<ArgumentNullException>().WithParameterName("hashcatalog");
    }

    /// <summary>
    /// Checks that the GetId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetId()
    {
        // Arrange
        var key = _fixture.Create<ulong>();

        // Act
        var result = TetraTable<V>.GetId(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetPosition method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPosition()
    {
        // Arrange
        var key = _fixture.Create<ulong>();
        var size = _fixture.Create<long>();

        // Act
        var result = TetraTable<V>.GetPosition(key, size);

        // Assert
        Assert.Fail("Create or modify test");
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
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForUint()
    {
        var testValue = _fixture.Create<ISeriesItem<V>[]>();
        this._testClass[_fixture.Create<uint>()].Should().BeAssignableTo<ISeriesItem<V>[]>();
        this._testClass[_fixture.Create<uint>()] = testValue;
        this._testClass[_fixture.Create<uint>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForUintAndUint()
    {
        var testValue = _fixture.Create<ISeriesItem<V>>();
        this._testClass[_fixture.Create<uint>(), _fixture.Create<uint>()].Should().BeAssignableTo<ISeriesItem<V>>();
        this._testClass[_fixture.Create<uint>(), _fixture.Create<uint>()] = testValue;
        this._testClass[_fixture.Create<uint>(), _fixture.Create<uint>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForUlong()
    {
        var testValue = _fixture.Create<ISeriesItem<V>[]>();
        this._testClass[_fixture.Create<ulong>()].Should().BeAssignableTo<ISeriesItem<V>[]>();
        this._testClass[_fixture.Create<ulong>()] = testValue;
        this._testClass[_fixture.Create<ulong>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForUlongAndLong()
    {
        var testValue = _fixture.Create<ISeriesItem<V>>();
        this._testClass[_fixture.Create<ulong>(), _fixture.Create<long>()].Should().BeAssignableTo<ISeriesItem<V>>();
        this._testClass[_fixture.Create<ulong>(), _fixture.Create<long>()] = testValue;
        this._testClass[_fixture.Create<ulong>(), _fixture.Create<long>()].Should().BeSameAs(testValue);
    }
}