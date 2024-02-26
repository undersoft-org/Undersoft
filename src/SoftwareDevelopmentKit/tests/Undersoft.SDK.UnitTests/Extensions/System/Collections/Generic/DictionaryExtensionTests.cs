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
/// Unit tests for the type <see cref="DictionaryExtension"/>.
/// </summary>
public class DictionaryExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithTAndSAndDictionaryOfTAndDictionaryOfTAndSAndTAndTAndS()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, Dictionary<T, S>>>();
        var key = _fixture.Create<T>();
        var key2 = _fixture.Create<T>();
        var item = _fixture.Create<S>();

        // Act
        source.Add<T, S>(key, key2, item
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithTAndSAndDictionaryOfTAndDictionaryOfTAndSAndTAndTAndSWithNullSource()
    {
        FluentActions.Invoking(() => default(Dictionary<T, Dictionary<T, S>>).Add<T, S>(_fixture.Create<T>(), _fixture.Create<T>(), _fixture.Create<S>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithDictionaryOfTAndSAndDictionaryOfTAndS()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
        var collection = _fixture.Create<Dictionary<T, S>>();

        // Act
        source.Add<T, S>(collection);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithDictionaryOfTAndSAndDictionaryOfTAndSWithNullSource()
    {
        FluentActions.Invoking(() => default(Dictionary<T, S>).Add<T, S>(_fixture.Create<Dictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Add method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithDictionaryOfTAndSAndDictionaryOfTAndSWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<Dictionary<T, S>>().Add<T, S>(default(Dictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithTAndSAndDictionaryOfTAndSAndIDictionaryOfTAndS()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        source.Add<T, S>(collection);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithTAndSAndDictionaryOfTAndSAndIDictionaryOfTAndSWithNullSource()
    {
        FluentActions.Invoking(() => default(Dictionary<T, S>).Add<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Add method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithTAndSAndDictionaryOfTAndSAndIDictionaryOfTAndSWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<Dictionary<T, S>>().Add<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithIDictionaryOfTAndSAndIDictionaryOfTAndS()
    {
        // Arrange
        var source = _fixture.Create<IDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        source.Add<T, S>(collection);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIDictionaryOfTAndSAndIDictionaryOfTAndSWithNullSource()
    {
        FluentActions.Invoking(() => default(IDictionary<T, S>).Add<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Add method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithIDictionaryOfTAndSAndIDictionaryOfTAndSWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<IDictionary<T, S>>().Add<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the AddWithResult method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithResult()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        var result = source.AddWithResult<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddWithResult method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithResultWithNullSource()
    {
        FluentActions.Invoking(() => default(Dictionary<T, S>).AddWithResult<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the AddWithResult method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithResultWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<Dictionary<T, S>>().AddWithResult<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the AddWithResult maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void AddWithResultPerformsMapping()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        var result = source.AddWithResult<T, S>(collection);

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
        var source = _fixture.Create<Dictionary<T, S>>();
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
        FluentActions.Invoking(() => default(Dictionary<T, S>).Get<T, S>(_fixture.Create<T>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetDictionary method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDictionary()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
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
        FluentActions.Invoking(() => default(Dictionary<T, S>).GetDictionary<T, S>(_fixture.Create<T>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRange()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
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
    public void CannotCallGetRangeWithNullSource()
    {
        FluentActions.Invoking(() => default(Dictionary<T, S>).GetRange<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<Dictionary<T, S>>().GetRange<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the GetRange maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetRangePerformsMapping()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        var result = source.GetRange<T, S>(collection);

        // Assert
        result.Keys.Should().BeSameAs(collection.Keys);
        result.Values.Should().BeSameAs(collection.Values);
    }

    /// <summary>
    /// Checks that the GetRangeLog method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRangeLog()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
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
        FluentActions.Invoking(() => default(Dictionary<T, S>).GetRangeLog<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetRangeLog method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeLogWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<Dictionary<T, S>>().GetRangeLog<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the GetRangeValues method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRangeValues()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
        var collection = _fixture.Create<IList<T>>();

        // Act
        var result = source.GetRangeValues<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRangeValues method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeValuesWithNullSource()
    {
        FluentActions.Invoking(() => default(Dictionary<T, S>).GetRangeValues<T, S>(_fixture.Create<IList<T>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the GetRangeValues method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetRangeValuesWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<Dictionary<T, S>>().GetRangeValues<T, S>(default(IList<T>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the GetRangeValues maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetRangeValuesPerformsMapping()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
        var collection = _fixture.Create<IList<T>>();

        // Act
        var result = source.GetRangeValues<T, S>(collection);

        // Assert
        result.Count.Should().Be(source.Count);
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithTAndSAndDictionaryOfTAndDictionaryOfTAndSAndTAndTAndS()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, Dictionary<T, S>>>();
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
    public void CannotCallPutWithTAndSAndDictionaryOfTAndDictionaryOfTAndSAndTAndTAndSWithNullSource()
    {
        FluentActions.Invoking(() => default(Dictionary<T, Dictionary<T, S>>).Put<T, S>(_fixture.Create<T>(), _fixture.Create<T>(), _fixture.Create<S>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithTAndSAndDictionaryOfTAndSAndIDictionaryOfTAndS()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        source.Put<T, S>(collection);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithTAndSAndDictionaryOfTAndSAndIDictionaryOfTAndSWithNullSource()
    {
        FluentActions.Invoking(() => default(Dictionary<T, S>).Put<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Put method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithTAndSAndDictionaryOfTAndSAndIDictionaryOfTAndSWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<Dictionary<T, S>>().Put<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithTAndSAndDictionaryOfTAndSAndTAndS()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
        var Key = _fixture.Create<T>();
        var Value = _fixture.Create<S>();

        // Act
        source.Put<T, S>(Key, Value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithTAndSAndDictionaryOfTAndSAndTAndSWithNullSource()
    {
        FluentActions.Invoking(() => default(Dictionary<T, S>).Put<T, S>(_fixture.Create<T>(), _fixture.Create<S>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithSourceAndKeyAndValueAndFunc()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
        var Key = _fixture.Create<T>();
        var Value = _fixture.Create<S>();
        Func<T, S, S> func = (x, y) => _fixture.Create<S>();

        // Act
        var result = source.Put<T, S>(Key, Value, func);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithSourceAndKeyAndValueAndFuncWithNullSource()
    {
        FluentActions.Invoking(() => default(Dictionary<T, S>).Put<T, S>(_fixture.Create<T>(), _fixture.Create<S>(), (x, y) => _fixture.Create<S>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Put method throws when the func parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithSourceAndKeyAndValueAndFuncWithNullFunc()
    {
        FluentActions.Invoking(() => _fixture.Create<Dictionary<T, S>>().Put<T, S>(_fixture.Create<T>(), _fixture.Create<S>(), default(Func<T, S, S>))).Should().Throw<ArgumentNullException>().WithParameterName("func");
    }

    /// <summary>
    /// Checks that the PutRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutRange()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
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
        FluentActions.Invoking(() => default(Dictionary<T, S>).PutRange<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the PutRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutRangeWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<Dictionary<T, S>>().PutRange<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the RemoveRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveRangeWithTAndSAndDictionaryOfTAndSAndIDictionaryOfTAndS()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
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
    public void CannotCallRemoveRangeWithTAndSAndDictionaryOfTAndSAndIDictionaryOfTAndSWithNullSource()
    {
        FluentActions.Invoking(() => default(Dictionary<T, S>).RemoveRange<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the RemoveRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveRangeWithTAndSAndDictionaryOfTAndSAndIDictionaryOfTAndSWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<Dictionary<T, S>>().RemoveRange<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the RemoveRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveRangeWithTAndSAndDictionaryOfTAndSAndIListOfT()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
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
    public void CannotCallRemoveRangeWithTAndSAndDictionaryOfTAndSAndIListOfTWithNullSource()
    {
        FluentActions.Invoking(() => default(Dictionary<T, S>).RemoveRange<T, S>(_fixture.Create<IList<T>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the RemoveRange method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveRangeWithTAndSAndDictionaryOfTAndSAndIListOfTWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<Dictionary<T, S>>().RemoveRange<T, S>(default(IList<T>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the TryAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAdd()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
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
        FluentActions.Invoking(() => default(Dictionary<T, S>).TryAdd<T, S>(_fixture.Create<T>(), _fixture.Create<S>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the TryRemove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryRemove()
    {
        // Arrange
        var source = _fixture.Create<Dictionary<T, S>>();
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
        FluentActions.Invoking(() => default(Dictionary<T, S>).TryRemove<T, S>(_fixture.Create<T>(), out _)).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }
}