using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Workflows;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Workflows;

/// <summary>
/// Unit tests for the type <see cref="WorkPointer"/>.
/// </summary>
public class WorkPointerTests
{
    private WorkPointer _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkPointer"/>.
    /// </summary>
    public WorkPointerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<WorkPointer>();
    }

    /// <summary>
    /// Checks that setting the Pointer property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPointer()
    {
        this._testClass.CheckProperty(x => x.Pointer, _fixture.Create<nint>(), _fixture.Create<nint>());
    }
}

/// <summary>
/// Unit tests for the type <see cref="WorkPointers"/>.
/// </summary>
public class WorkPointersTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRangeWithTAndLong()
    {
        // Arrange
        var id = _fixture.Create<long>();

        // Act
        var result = WorkPointers.GetRange<T>(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRangeWithT()
    {
        // Act
        var result = WorkPointers.GetRange<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRangeWithNoParameters()
    {
        // Act
        var result = WorkPointers.GetRange();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetTypedRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetTypedRangeWithTAndLong()
    {
        // Arrange
        var id = _fixture.Create<long>();

        // Act
        var result = WorkPointers.GetTypedRange<T>(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetTypedRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetTypedRangeWithT()
    {
        // Act
        var result = WorkPointers.GetTypedRange<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetTypedRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetTypedRangeWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = WorkPointers.GetTypedRange(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetTypedRange method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetTypedRangeWithTypeWithNullType()
    {
        FluentActions.Invoking(() => WorkPointers.GetTypedRange(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithTAndLong()
    {
        // Arrange
        var id = _fixture.Create<long>();

        // Act
        var result = WorkPointers.Get<T>(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithT()
    {
        // Act
        var result = WorkPointers.Get<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetWithNoParameters()
    {
        // Act
        var result = WorkPointers.Get();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetTyped method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetTypedWithT()
    {
        // Act
        var result = WorkPointers.GetTyped<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetTyped method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetTypedWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = WorkPointers.GetTyped(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetTyped method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetTypedWithTypeWithNullType()
    {
        FluentActions.Invoking(() => WorkPointers.GetTyped(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetTyped method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetTypedWithTAndLong()
    {
        // Arrange
        var id = _fixture.Create<long>();

        // Act
        var result = WorkPointers.GetTyped<T>(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveTyped method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveTypedWithT()
    {
        // Act
        var result = WorkPointers.RemoveTyped<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveTyped method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveTypedWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = WorkPointers.RemoveTyped(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveTyped method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveTypedWithTypeWithNullType()
    {
        FluentActions.Invoking(() => WorkPointers.RemoveTyped(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithT()
    {
        // Act
        var result = WorkPointers.Remove<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveWithKey()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = WorkPointers.Remove<T>(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveRange()
    {
        // Arrange
        var keys = _fixture.Create<IEnumerable<long>>();

        // Act
        WorkPointers.RemoveRange<T>(keys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoveRange method throws when the keys parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveRangeWithNullKeys()
    {
        FluentActions.Invoking(() => WorkPointers.RemoveRange<T>(default(IEnumerable<long>))).Should().Throw<ArgumentNullException>().WithParameterName("keys");
    }

    /// <summary>
    /// Checks that the SetTyped method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetTyped()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = WorkPointers.SetTyped<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSet()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = WorkPointers.Set<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithTAndT()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = WorkPointers.Add<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithObject()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = WorkPointers.Add(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithObjectWithNullItem()
    {
        FluentActions.Invoking(() => WorkPointers.Add(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithItemAndKey()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var key = _fixture.Create<long>();

        // Act
        var result = WorkPointers.Add<T>(item, key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRangeWithIEnumerableOfT()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<T>>();

        // Act
        var result = WorkPointers.AddRange<T>(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRange method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRangeWithIEnumerableOfTWithNullItems()
    {
        FluentActions.Invoking(() => WorkPointers.AddRange<T>(default(IEnumerable<T>))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the AddRange method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddRangeWithArrayOfObject()
    {
        // Arrange
        var items = _fixture.Create<object[]>();

        // Act
        var result = WorkPointers.AddRange(items);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddRange method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddRangeWithArrayOfObjectWithNullItems()
    {
        FluentActions.Invoking(() => WorkPointers.AddRange(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the AddTyped method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddTypedWithTAndObject()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = WorkPointers.AddTyped<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddTyped method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddTypedWithTAndObjectWithNullItem()
    {
        FluentActions.Invoking(() => WorkPointers.AddTyped<T>(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the AddTyped method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddTypedWithTypeAndItem()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var item = _fixture.Create<object>();

        // Act
        var result = WorkPointers.AddTyped(type, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddTyped method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddTypedWithTypeAndItemWithNullType()
    {
        FluentActions.Invoking(() => WorkPointers.AddTyped(default(Type), _fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the AddTyped method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddTypedWithTypeAndItemWithNullItem()
    {
        FluentActions.Invoking(() => WorkPointers.AddTyped(_fixture.Create<Type>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the AddTypedAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAddTypedAsync()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = await WorkPointers.AddTypedAsync<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAddAsyncWithTAndTAsync()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = await WorkPointers.AddAsync<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallAddAsyncWithItemAndIdAsync()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var id = _fixture.Create<long>();

        // Act
        var result = await WorkPointers.AddAsync<T>(item, id);

        // Assert
        Assert.Fail("Create or modify test");
    }
}