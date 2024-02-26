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
/// Unit tests for the type <see cref="SortedListExtension"/>.
/// </summary>
public class SortedListExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the AddRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRange()
    {
        // Arrange
        var source = _fixture.Create<SortedList<T, S>>();
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
        FluentActions.Invoking(() => default(SortedList<T, S>).AddRange<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the AddRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRangeWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedList<T, S>>().AddRange<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the AddRangeLog method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRangeLog()
    {
        // Arrange
        var source = _fixture.Create<SortedList<T, S>>();
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
        FluentActions.Invoking(() => default(SortedList<T, S>).AddRangeLog<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the AddRangeLog method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRangeLogWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedList<T, S>>().AddRangeLog<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the AddRangeLog maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void AddRangeLogPerformsMapping()
    {
        // Arrange
        var source = _fixture.Create<SortedList<T, S>>();
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
        var source = _fixture.Create<SortedList<T, S>>();
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
        FluentActions.Invoking(() => default(SortedList<T, S>).Get<T, S>(_fixture.Create<T>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetDictionary method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDictionary()
    {
        // Arrange
        var source = _fixture.Create<SortedList<T, S>>();
        var key = _fixture.Create<T>();

        // Act
        var result = source.GetDictionary<T, S>(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDictionary method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDictionaryWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedList<T, S>).GetDictionary<T, S>(_fixture.Create<T>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRangeWithTAndSAndSortedListOfTAndSAndIDictionaryOfTAndS()
    {
        // Arrange
        var source = _fixture.Create<SortedList<T, S>>();
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
    public void CannotCallGetRangeWithTAndSAndSortedListOfTAndSAndIDictionaryOfTAndSWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedList<T, S>).GetRange<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeWithTAndSAndSortedListOfTAndSAndIDictionaryOfTAndSWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedList<T, S>>().GetRange<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the GetRange maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetRangeWithTAndSAndSortedListOfTAndSAndIDictionaryOfTAndSPerformsMapping()
    {
        // Arrange
        var source = _fixture.Create<SortedList<T, S>>();
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
    public void CanCallGetRangeWithTAndSAndSortedListOfTAndSAndIListOfT()
    {
        // Arrange
        var source = _fixture.Create<SortedList<T, S>>();
        var collection = _fixture.Create<IList<T>>();

        // Act
        var result = source.GetRange<T, S>(collection);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRange method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeWithTAndSAndSortedListOfTAndSAndIListOfTWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedList<T, S>).GetRange<T, S>(_fixture.Create<IList<T>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeWithTAndSAndSortedListOfTAndSAndIListOfTWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedList<T, S>>().GetRange<T, S>(default(IList<T>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the GetRange maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetRangeWithTAndSAndSortedListOfTAndSAndIListOfTPerformsMapping()
    {
        // Arrange
        var source = _fixture.Create<SortedList<T, S>>();
        var collection = _fixture.Create<IList<T>>();

        // Act
        var result = source.GetRange<T, S>(collection);

        // Assert
        result.Capacity.Should().Be(source.Capacity);
        result.Count.Should().Be(source.Count);
    }

    /// <summary>
    /// Checks that the GetRangeLog method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRangeLog()
    {
        // Arrange
        var source = _fixture.Create<SortedList<T, S>>();
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
        FluentActions.Invoking(() => default(SortedList<T, S>).GetRangeLog<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetRangeLog method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeLogWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedList<T, S>>().GetRangeLog<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPut()
    {
        // Arrange
        var source = _fixture.Create<SortedList<T, S>>();
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
    public void CannotCallPutWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedList<T, S>).Put<T, S>(_fixture.Create<T>(), _fixture.Create<S>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the PutRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutRange()
    {
        // Arrange
        var source = _fixture.Create<SortedList<T, S>>();
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
        FluentActions.Invoking(() => default(SortedList<T, S>).PutRange<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the PutRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutRangeWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedList<T, S>>().PutRange<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the RemoveRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveRangeWithTAndSAndSortedListOfTAndSAndIDictionaryOfTAndS()
    {
        // Arrange
        var source = _fixture.Create<SortedList<T, S>>();
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
    public void CannotCallRemoveRangeWithTAndSAndSortedListOfTAndSAndIDictionaryOfTAndSWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedList<T, S>).RemoveRange<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the RemoveRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveRangeWithTAndSAndSortedListOfTAndSAndIDictionaryOfTAndSWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedList<T, S>>().RemoveRange<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the RemoveRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveRangeWithTAndSAndSortedListOfTAndSAndIListOfT()
    {
        // Arrange
        var source = _fixture.Create<SortedList<T, S>>();
        var collection = _fixture.Create<IList<T>>();

        // Act
        source.RemoveRange<T, S>(collection);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveRange method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveRangeWithTAndSAndSortedListOfTAndSAndIListOfTWithNullSource()
    {
        FluentActions.Invoking(() => default(SortedList<T, S>).RemoveRange<T, S>(_fixture.Create<IList<T>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the RemoveRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveRangeWithTAndSAndSortedListOfTAndSAndIListOfTWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<SortedList<T, S>>().RemoveRange<T, S>(default(IList<T>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }
}