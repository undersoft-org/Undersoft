using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Updating;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Updating;

/// <summary>
/// Unit tests for the type <see cref="Updater"/>.
/// </summary>
public class Updater_1Tests
{
    private Updater<T> _testClass;
    private IFixture _fixture;
    private T _item;
    private Mock<IInvoker> _traceChanges;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Updater"/>.
    /// </summary>
    public Updater_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._item = _fixture.Create<T>();
        this._traceChanges = _fixture.Freeze<Mock<IInvoker>>();
        this._testClass = _fixture.Create<Updater<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Updater<T>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Updater<T>(this._item);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Updater<T>(this._item, this._traceChanges.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullItem()
    {
        FluentActions.Invoking(() => new Updater<T>(default(T))).Should().Throw<ArgumentNullException>().WithParameterName("item");
        FluentActions.Invoking(() => new Updater<T>(default(T), this._traceChanges.Object)).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that instance construction throws when the traceChanges parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTraceChanges()
    {
        FluentActions.Invoking(() => new Updater<T>(this._item, default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("traceChanges");
    }

    /// <summary>
    /// Checks that the Patch method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatch()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = this._testClass.Patch(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Patch method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Patch(default(T))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PatchFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchFrom()
    {
        // Arrange
        var source = _fixture.Create<T>();

        // Act
        var result = this._testClass.PatchFrom(source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchFrom method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchFromWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.PatchFrom(default(T))).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Put method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPut()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = this._testClass.Put(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Put method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Put(default(T))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PutFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutFrom()
    {
        // Arrange
        var source = _fixture.Create<T>();

        // Act
        var result = this._testClass.PutFrom(source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutFrom method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutFromWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.PutFrom(default(T))).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Detect method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDetect()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = this._testClass.Detect(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Detect method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDetectWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Detect(default(T))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Clone method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClone()
    {
        // Act
        var result = this._testClass.Clone();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Devisor property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDevisor()
    {
        // Arrange
        var testValue = _fixture.Create<T>();

        // Act
        this._testClass.Devisor = testValue;

        // Assert
        this._testClass.Devisor.Should().BeSameAs(testValue);
    }
}