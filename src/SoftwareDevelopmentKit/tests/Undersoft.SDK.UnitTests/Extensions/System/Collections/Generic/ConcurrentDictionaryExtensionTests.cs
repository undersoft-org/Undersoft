using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using S = System.String;
using T = System.String;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ConcurrentDictionaryExtension"/>.
/// </summary>
public class ConcurrentDictionaryExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAdd()
    {
        // Arrange
        var source = _fixture.Create<ConcurrentDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        var result = source.Add<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithNullSource()
    {
        FluentActions.Invoking(() => default(ConcurrentDictionary<T, S>).Add<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Add method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<ConcurrentDictionary<T, S>>().Add<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }

    /// <summary>
    /// Checks that the Add maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void AddPerformsMapping()
    {
        // Arrange
        var source = _fixture.Create<ConcurrentDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        var result = source.Add<T, S>(collection);

        // Assert
        result.Keys.Should().BeSameAs(collection.Keys);
        result.Values.Should().BeSameAs(collection.Values);
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithSourceAndKeyAndKey2AndItem()
    {
        // Arrange
        var source = _fixture.Create<ConcurrentDictionary<T, Dictionary<T, S>>>();
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
        FluentActions.Invoking(() => default(ConcurrentDictionary<T, Dictionary<T, S>>).Put<T, S>(_fixture.Create<T>(), _fixture.Create<T>(), _fixture.Create<S>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutWithTAndSAndConcurrentDictionaryOfTAndSAndIDictionaryOfTAndS()
    {
        // Arrange
        var source = _fixture.Create<ConcurrentDictionary<T, S>>();
        var collection = _fixture.Create<IDictionary<T, S>>();

        // Act
        source.Put<T, S>(collection
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithTAndSAndConcurrentDictionaryOfTAndSAndIDictionaryOfTAndSWithNullSource()
    {
        FluentActions.Invoking(() => default(ConcurrentDictionary<T, S>).Put<T, S>(_fixture.Create<IDictionary<T, S>>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Put method throws when the collection parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithTAndSAndConcurrentDictionaryOfTAndSAndIDictionaryOfTAndSWithNullCollection()
    {
        FluentActions.Invoking(() => _fixture.Create<ConcurrentDictionary<T, S>>().Put<T, S>(default(IDictionary<T, S>))).Should().Throw<ArgumentNullException>().WithParameterName("collection");
    }
}