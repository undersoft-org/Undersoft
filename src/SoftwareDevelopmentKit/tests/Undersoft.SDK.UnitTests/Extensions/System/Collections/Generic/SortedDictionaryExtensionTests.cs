using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using S = System.String;
using T = System.String;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="SortedDictionaryExtension"/>.
/// </summary>
public class SortedDictionaryExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the AddDictionary method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddDictionary()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        source.AddDictionary<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddDictionary method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddDictionaryWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).AddDictionary<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the AddDictionary method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddDictionaryWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedDictionary<T, S>>().AddDictionary<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the AddOrUpdate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddOrUpdate()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var Key = _fixture.Create<T>();
        var Value = _fixture.Create<S>();
        Func<T, S, S> func = (x, y) => _fixture.Create<S>();

        // Act
        var result = source.AddOrUpdate<T, S>(Key, Value, func
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddOrUpdate method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddOrUpdateWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).AddOrUpdate<T, S>(_fixture.Create<T>(), _fixture.Create<S>(), (x, y) => _fixture.Create<S>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the AddOrUpdate method throws when the func parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddOrUpdateWithNullFunc()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedDictionary<T, S>>().AddOrUpdate<T, S>(_fixture.Create<T>(), _fixture.Create<S>(), default(Func<T, S, S>))).Should().Throw<ArgumentNullException>().WithParameterName("func");
    }

    /// <summary>
    /// Checks that the AddOrUpdateRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddOrUpdateRange()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        source.AddOrUpdateRange<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddOrUpdateRange method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddOrUpdateRangeWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).AddOrUpdateRange<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the AddOrUpdateRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddOrUpdateRangeWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedDictionary<T, S>>().AddOrUpdateRange<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the AddRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRange()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        source.AddRange<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRange method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRangeWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).AddRange<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the AddRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRangeWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedDictionary<T, S>>().AddRange<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the AddRangeLog method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRangeLog()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        var result = source.AddRangeLog<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRangeLog method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRangeLogWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).AddRangeLog<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the AddRangeLog method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRangeLogWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedDictionary<T, S>>().AddRangeLog<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the AddRangeLog maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void AddRangeLogPerformsMapping()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        var result = source.AddRangeLog<T, S>(collection);

        // Assert
        result.Keys.Should().BeSameAs(collection.Keys);
        result.Values.Should().BeSameAs(collection.Values);
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var key = _fixture.Create<T>();

        // Act
        var result = source.Get<T, S>(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).Get<T, S>(_fixture.Create<T>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetDictionary method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDictionary()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var key = _fixture.Create<T>();

        // Act
        var result = source.GetDictionary<T, S>(key
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDictionary method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDictionaryWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).GetDictionary<T, S>(_fixture.Create<T>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRangeWithTAndSAndSortedDictionaryOfTAndSAndIDictionaryOfTAndS()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        var result = source.GetRange<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRange method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeWithTAndSAndSortedDictionaryOfTAndSAndIDictionaryOfTAndSWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).GetRange<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeWithTAndSAndSortedDictionaryOfTAndSAndIDictionaryOfTAndSWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedDictionary<T, S>>().GetRange<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the GetRange maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetRangeWithTAndSAndSortedDictionaryOfTAndSAndIDictionaryOfTAndSPerformsMapping()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        var result = source.GetRange<T, S>(collection);

        // Assert
        result.Keys.Should().BeSameAs(collection.Keys);
        result.Values.Should().BeSameAs(collection.Values);
    }

    /// <summary>
    /// Checks that the GetRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRangeWithTAndSAndSortedDictionaryOfTAndSAndIListOfT()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var collection = _fixture.Create<IList<T>>();

        // Act
        var result = source.GetRange<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRange method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeWithTAndSAndSortedDictionaryOfTAndSAndIListOfTWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).GetRange<T, S>(_fixture.Create<IList<T>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeWithTAndSAndSortedDictionaryOfTAndSAndIListOfTWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedDictionary<T, S>>().GetRange<T, S>(default(IList<T>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the GetRange maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetRangeWithTAndSAndSortedDictionaryOfTAndSAndIListOfTPerformsMapping()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var collection = _fixture.Create<IList<T>>();

        // Act
        var result = source.GetRange<T, S>(collection);

        // Assert
        result.Count.Should().Be(source.Count);
    }

    /// <summary>
    /// Checks that the GetRangeLog method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRangeLog()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        var result = source.GetRangeLog<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRangeLog method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeLogWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).GetRangeLog<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetRangeLog method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeLogWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedDictionary<T, S>>().GetRangeLog<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithSourceAndKeyAndKey2AndItem()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, Dictionary<T, S>>>();
        var key = _fixture.Create<T>();
        var key2 = _fixture.Create<T>();
        var item = _fixture.Create<S>();

        // Act
        source.Put<T, S>(key, key2, item
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithSourceAndKeyAndKey2AndItemWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, Dictionary<T, S>>).Put<T, S>(_fixture.Create<T>(), _fixture.Create<T>(), _fixture.Create<S>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithSourceAndKeyAndItem()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var key = _fixture.Create<T>();
        var item = _fixture.Create<S>();

        // Act
        source.Put<T, S>(key, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithSourceAndKeyAndItemWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).Put<T, S>(_fixture.Create<T>(), _fixture.Create<S>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the PutRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutRange()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        source.PutRange<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutRange method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutRangeWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).PutRange<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the PutRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutRangeWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedDictionary<T, S>>().PutRange<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the RemoveRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveRangeWithTAndSAndSortedDictionaryOfTAndSAndIDictionaryOfTAndS()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        source.RemoveRange<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveRange method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveRangeWithTAndSAndSortedDictionaryOfTAndSAndIDictionaryOfTAndSWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).RemoveRange<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the RemoveRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveRangeWithTAndSAndSortedDictionaryOfTAndSAndIDictionaryOfTAndSWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedDictionary<T, S>>().RemoveRange<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the RemoveRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveRangeWithTAndSAndSortedDictionaryOfTAndSAndIListOfT()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var collection = _fixture.Create<IList<T>>();

        // Act
        source.RemoveRange<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveRange method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveRangeWithTAndSAndSortedDictionaryOfTAndSAndIListOfTWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).RemoveRange<T, S>(_fixture.Create<IList<T>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the RemoveRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveRangeWithTAndSAndSortedDictionaryOfTAndSAndIListOfTWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedDictionary<T, S>>().RemoveRange<T, S>(default(IList<T>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the TryAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAdd()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var Key = _fixture.Create<T>();
        var Value = _fixture.Create<S>();

        // Act
        var result = source.TryAdd<T, S>(Key, Value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAdd method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryAddWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).TryAdd<T, S>(_fixture.Create<T>(), _fixture.Create<S>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the TryRemove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryRemove()
    {
        // Arrange
        var source = _fixture.Create<SortedDictionary<T, S>>();
        var Key = _fixture.Create<T>();

        // Act
        var result = source.TryRemove<T, S>(Key, out var Value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryRemove method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryRemoveWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedDictionary<T, S>).TryRemove<T, S>(_fixture.Create<T>(), out _)).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }
}