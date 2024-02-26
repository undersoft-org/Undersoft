using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Updating;
using E = System.String;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Updating;

/// <summary>
/// Unit tests for the type <see cref="UpdaterExtensions"/>.
/// </summary>
public class UpdaterExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the PatchTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchToWithTAndEAndTAndEAndIInvoker()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var target = _fixture.Create<E>();
        var traceChanges = _fixture.Create<IInvoker>();

        // Act
        var result = item.PatchTo<T, E>(target, traceChanges);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchTo method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchToWithTAndEAndTAndEAndIInvokerWithNullItem()
    {
        FluentActions.Invoking(() => default(T).PatchTo<T, E>(_fixture.Create<E>(), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PatchTo method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchToWithTAndEAndTAndEAndIInvokerWithNullTarget()
    {
        FluentActions.Invoking(() => _fixture.Create<T>().PatchTo<T, E>(default(E), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the PatchTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchToWithObjectAndObjectAndIInvoker()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var target = _fixture.Create<object>();
        var traceChanges = _fixture.Create<IInvoker>();

        // Act
        var result = item.PatchTo(target, traceChanges);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchTo method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchToWithObjectAndObjectAndIInvokerWithNullItem()
    {
        FluentActions.Invoking(() => default(object).PatchTo(_fixture.Create<object>(), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PatchTo method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchToWithObjectAndObjectAndIInvokerWithNullTarget()
    {
        FluentActions.Invoking(() => _fixture.Create<object>().PatchTo(default(object), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the PatchFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchFromWithTAndEAndTAndEAndIInvoker()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var source = _fixture.Create<E>();
        var traceChanges = _fixture.Create<IInvoker>();

        // Act
        var result = item.PatchFrom<T, E>(source, traceChanges);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchFrom method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchFromWithTAndEAndTAndEAndIInvokerWithNullItem()
    {
        FluentActions.Invoking(() => default(T).PatchFrom<T, E>(_fixture.Create<E>(), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PatchFrom method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchFromWithTAndEAndTAndEAndIInvokerWithNullSource()
    {
        FluentActions.Invoking(() => _fixture.Create<T>().PatchFrom<T, E>(default(E), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the PatchFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchFromWithObjectAndObjectAndIInvoker()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var source = _fixture.Create<object>();
        var traceChanges = _fixture.Create<IInvoker>();

        // Act
        var result = item.PatchFrom(source, traceChanges);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchFrom method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchFromWithObjectAndObjectAndIInvokerWithNullItem()
    {
        FluentActions.Invoking(() => default(object).PatchFrom(_fixture.Create<object>(), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PatchFrom method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchFromWithObjectAndObjectAndIInvokerWithNullSource()
    {
        FluentActions.Invoking(() => _fixture.Create<object>().PatchFrom(default(object), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the PatchTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchToWithTAndEAndTAndIInvoker()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var traceChanges = _fixture.Create<IInvoker>();

        // Act
        var result = item.PatchTo<T, E>(traceChanges);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchTo method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchToWithTAndEAndTAndIInvokerWithNullItem()
    {
        FluentActions.Invoking(() => default(T).PatchTo<T, E>(_fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PatchTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchToWithEAndObjectAndIInvoker()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var traceChanges = _fixture.Create<IInvoker>();

        // Act
        var result = item.PatchTo<E>(traceChanges);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchTo method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchToWithEAndObjectAndIInvokerWithNullItem()
    {
        FluentActions.Invoking(() => default(object).PatchTo<E>(_fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PutTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutToWithTAndEAndTAndEAndIInvoker()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var target = _fixture.Create<E>();
        var traceChanges = _fixture.Create<IInvoker>();

        // Act
        var result = item.PutTo<T, E>(target, traceChanges);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutTo method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutToWithTAndEAndTAndEAndIInvokerWithNullItem()
    {
        FluentActions.Invoking(() => default(T).PutTo<T, E>(_fixture.Create<E>(), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PutTo method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutToWithTAndEAndTAndEAndIInvokerWithNullTarget()
    {
        FluentActions.Invoking(() => _fixture.Create<T>().PutTo<T, E>(default(E), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the PutTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutToWithObjectAndObjectAndIInvoker()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var target = _fixture.Create<object>();
        var traceChanges = _fixture.Create<IInvoker>();

        // Act
        var result = item.PutTo(target, traceChanges);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutTo method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutToWithObjectAndObjectAndIInvokerWithNullItem()
    {
        FluentActions.Invoking(() => default(object).PutTo(_fixture.Create<object>(), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PutTo method throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutToWithObjectAndObjectAndIInvokerWithNullTarget()
    {
        FluentActions.Invoking(() => _fixture.Create<object>().PutTo(default(object), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that the PutTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutToWithTAndEAndTAndIInvoker()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var traceChanges = _fixture.Create<IInvoker>();

        // Act
        var result = item.PutTo<T, E>(traceChanges);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutTo method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutToWithTAndEAndTAndIInvokerWithNullItem()
    {
        FluentActions.Invoking(() => default(T).PutTo<T, E>(_fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PutTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutToWithEAndObjectAndIInvoker()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var traceChanges = _fixture.Create<IInvoker>();

        // Act
        var result = item.PutTo<E>(traceChanges);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutTo method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutToWithEAndObjectAndIInvokerWithNullItem()
    {
        FluentActions.Invoking(() => default(object).PutTo<E>(_fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PutFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutFromWithTAndEAndTAndEAndIInvoker()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var source = _fixture.Create<E>();
        var traceChanges = _fixture.Create<IInvoker>();

        // Act
        var result = item.PutFrom<T, E>(source, traceChanges);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutFrom method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutFromWithTAndEAndTAndEAndIInvokerWithNullItem()
    {
        FluentActions.Invoking(() => default(T).PutFrom<T, E>(_fixture.Create<E>(), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PutFrom method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutFromWithTAndEAndTAndEAndIInvokerWithNullSource()
    {
        FluentActions.Invoking(() => _fixture.Create<T>().PutFrom<T, E>(default(E), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the PutFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutFromWithObjectAndObjectAndIInvoker()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var source = _fixture.Create<object>();
        var traceChanges = _fixture.Create<IInvoker>();

        // Act
        var result = item.PutFrom(source, traceChanges);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutFrom method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutFromWithObjectAndObjectAndIInvokerWithNullItem()
    {
        FluentActions.Invoking(() => default(object).PutFrom(_fixture.Create<object>(), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the PutFrom method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutFromWithObjectAndObjectAndIInvokerWithNullSource()
    {
        FluentActions.Invoking(() => _fixture.Create<object>().PutFrom(default(object), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }
}