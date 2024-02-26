using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Invoking;
using T = System.String;
using TItem = System.String;
using TResult = System.String;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="SeriesLinqExtensions"/>.
/// </summary>
public class SeriesLinqExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the DoEach method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDoEach()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Func<TItem, TResult> action = x => _fixture.Create<TResult>();

        // Act
        var result = items.DoEach<TItem, TResult>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DoEach method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDoEachWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).DoEach<TItem, TResult>(x => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the DoEach method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDoEachWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().DoEach<TItem, TResult>(default(Func<TItem, TResult>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForOnly method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForOnlyWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndTResult()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Func<TItem, bool> condition = x => _fixture.Create<bool>();
        Func<TItem, TResult> action = x => _fixture.Create<TResult>();

        // Act
        var result = items.ForOnly<TItem, TResult>(condition, action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForOnly method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndTResultWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ForOnly<TItem, TResult>(x => _fixture.Create<bool>(), x => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForOnly method throws when the condition parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndTResultWithNullCondition()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnly<TItem, TResult>(default(Func<TItem, bool>), x => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("condition");
    }

    /// <summary>
    /// Checks that the ForOnly method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndTResultWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnly<TItem, TResult>(x => _fixture.Create<bool>(), default(Func<TItem, TResult>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForOnly method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForOnlyWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndIntAndTResult()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Func<TItem, bool> condition = x => _fixture.Create<bool>();
        Func<TItem, int, TResult> action = (x, y) => _fixture.Create<TResult>();

        // Act
        var result = items.ForOnly<TItem, TResult>(condition, action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForOnly method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndIntAndTResultWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ForOnly<TItem, TResult>(x => _fixture.Create<bool>(), (x, y) => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForOnly method throws when the condition parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndIntAndTResultWithNullCondition()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnly<TItem, TResult>(default(Func<TItem, bool>), (x, y) => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("condition");
    }

    /// <summary>
    /// Checks that the ForOnly method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndIntAndTResultWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnly<TItem, TResult>(x => _fixture.Create<bool>(), default(Func<TItem, int, TResult>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForOnlyAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForOnlyAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndIntAndTResult()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Func<TItem, bool> condition = x => _fixture.Create<bool>();
        Func<TItem, int, TResult> action = (x, y) => _fixture.Create<TResult>();

        // Act
        var result = items.ForOnlyAsync<TItem, TResult>(condition, action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForOnlyAsync method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndIntAndTResultWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ForOnlyAsync<TItem, TResult>(x => _fixture.Create<bool>(), (x, y) => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForOnlyAsync method throws when the condition parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndIntAndTResultWithNullCondition()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnlyAsync<TItem, TResult>(default(Func<TItem, bool>), (x, y) => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("condition");
    }

    /// <summary>
    /// Checks that the ForOnlyAsync method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndIntAndTResultWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnlyAsync<TItem, TResult>(x => _fixture.Create<bool>(), default(Func<TItem, int, TResult>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForOnlyAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForOnlyAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndTResult()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Func<TItem, bool> condition = x => _fixture.Create<bool>();
        Func<TItem, TResult> action = x => _fixture.Create<TResult>();

        // Act
        var result = items.ForOnlyAsync<TItem, TResult>(condition, action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForOnlyAsync method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndTResultWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ForOnlyAsync<TItem, TResult>(x => _fixture.Create<bool>(), x => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForOnlyAsync method throws when the condition parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndTResultWithNullCondition()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnlyAsync<TItem, TResult>(default(Func<TItem, bool>), x => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("condition");
    }

    /// <summary>
    /// Checks that the ForOnlyAsync method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndFuncOfTItemAndTResultWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnlyAsync<TItem, TResult>(x => _fixture.Create<bool>(), default(Func<TItem, TResult>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForOnly method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForOnlyWithTItemAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndActionOfTItem()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Func<TItem, bool> condition = x => _fixture.Create<bool>();
        Action<TItem> action = x => { };

        // Act
        items.ForOnly<TItem>(condition, action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForOnly method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyWithTItemAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndActionOfTItemWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ForOnly<TItem>(x => _fixture.Create<bool>(), x => { })).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForOnly method throws when the condition parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyWithTItemAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndActionOfTItemWithNullCondition()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnly<TItem>(default(Func<TItem, bool>), x => { })).Should().Throw<ArgumentNullException>().WithParameterName("condition");
    }

    /// <summary>
    /// Checks that the ForOnly method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyWithTItemAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndActionOfTItemWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnly<TItem>(x => _fixture.Create<bool>(), default(Action<TItem>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForOnly method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForOnlyWithIEnumerableOfTItemAndFuncOfTItemAndBoolAndActionOfTItemAndInt()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Func<TItem, bool> condition = x => _fixture.Create<bool>();
        Action<TItem, int> action = (x, y) => { };

        // Act
        items.ForOnly<TItem>(condition, action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForOnly method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyWithIEnumerableOfTItemAndFuncOfTItemAndBoolAndActionOfTItemAndIntWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ForOnly<TItem>(x => _fixture.Create<bool>(), (x, y) => { })).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForOnly method throws when the condition parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyWithIEnumerableOfTItemAndFuncOfTItemAndBoolAndActionOfTItemAndIntWithNullCondition()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnly<TItem>(default(Func<TItem, bool>), (x, y) => { })).Should().Throw<ArgumentNullException>().WithParameterName("condition");
    }

    /// <summary>
    /// Checks that the ForOnly method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForOnlyWithIEnumerableOfTItemAndFuncOfTItemAndBoolAndActionOfTItemAndIntWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnly<TItem>(x => _fixture.Create<bool>(), default(Action<TItem, int>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForOnlyAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallForOnlyAsyncWithTItemAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndActionOfTItemAsync()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Func<TItem, bool> condition = x => _fixture.Create<bool>();
        Action<TItem> action = x => { };

        // Act
        await items.ForOnlyAsync<TItem>(condition, action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForOnlyAsync method throws when the items parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallForOnlyAsyncWithTItemAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndActionOfTItemWithNullItemsAsync()
    {
        await FluentActions.Invoking(() => default(IEnumerable<TItem>).ForOnlyAsync<TItem>(x => _fixture.Create<bool>(), x => { })).Should().ThrowAsync<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForOnlyAsync method throws when the condition parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallForOnlyAsyncWithTItemAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndActionOfTItemWithNullConditionAsync()
    {
        await FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnlyAsync<TItem>(default(Func<TItem, bool>), x => { })).Should().ThrowAsync<ArgumentNullException>().WithParameterName("condition");
    }

    /// <summary>
    /// Checks that the ForOnlyAsync method throws when the action parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallForOnlyAsyncWithTItemAndIEnumerableOfTItemAndFuncOfTItemAndBoolAndActionOfTItemWithNullActionAsync()
    {
        await FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForOnlyAsync<TItem>(x => _fixture.Create<bool>(), default(Action<TItem>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForEach method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForEachWithTItemAndIEnumerableOfTItemAndActionOfTItem()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Action<TItem> action = x => { };

        // Act
        items.ForEach<TItem>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForEach method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachWithTItemAndIEnumerableOfTItemAndActionOfTItemWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ForEach<TItem>(x => { })).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForEach method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachWithTItemAndIEnumerableOfTItemAndActionOfTItemWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForEach<TItem>(default(Action<TItem>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForEach method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForEachWithTItemAndIEnumerableOfTItemAndActionOfTItemAndInt()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Action<TItem, int> action = (x, y) => { };

        // Act
        items.ForEach<TItem>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForEach method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachWithTItemAndIEnumerableOfTItemAndActionOfTItemAndIntWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ForEach<TItem>((x, y) => { })).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForEach method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachWithTItemAndIEnumerableOfTItemAndActionOfTItemAndIntWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForEach<TItem>(default(Action<TItem, int>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForEach method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForEachWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndIntAndTResult()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Func<TItem, int, TResult> action = (x, y) => _fixture.Create<TResult>();

        // Act
        var result = items.ForEach<TItem, TResult>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForEach method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndIntAndTResultWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ForEach<TItem, TResult>((x, y) => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForEach method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndIntAndTResultWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForEach<TItem, TResult>(default(Func<TItem, int, TResult>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForEach method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForEachWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndTResult()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Func<TItem, TResult> action = x => _fixture.Create<TResult>();

        // Act
        var result = items.ForEach<TItem, TResult>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForEach method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndTResultWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ForEach<TItem, TResult>(x => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForEach method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndTResultWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForEach<TItem, TResult>(default(Func<TItem, TResult>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForEachAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForEachAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndIntAndTResult()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Func<TItem, int, TResult> action = (x, y) => _fixture.Create<TResult>();

        // Act
        var result = items.ForEachAsync<TItem, TResult>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForEachAsync method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndIntAndTResultWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ForEachAsync<TItem, TResult>((x, y) => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForEachAsync method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndIntAndTResultWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForEachAsync<TItem, TResult>(default(Func<TItem, int, TResult>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForEachAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForEachAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndTResult()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Func<TItem, TResult> action = x => _fixture.Create<TResult>();

        // Act
        var result = items.ForEachAsync<TItem, TResult>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForEachAsync method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndTResultWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ForEachAsync<TItem, TResult>(x => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForEachAsync method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachAsyncWithTItemAndTResultAndIEnumerableOfTItemAndFuncOfTItemAndTResultWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForEachAsync<TItem, TResult>(default(Func<TItem, TResult>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForEachAsync method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForEachAsyncWithIAsyncEnumerableOfTItemAndFuncOfTItemAndTResult()
    {
        // Arrange
        var items = _fixture.Create<IAsyncEnumerable<TItem>>();
        Func<TItem, TResult> action = x => _fixture.Create<TResult>();

        // Act
        var result = items.ForEachAsync<TItem, TResult>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForEachAsync method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachAsyncWithIAsyncEnumerableOfTItemAndFuncOfTItemAndTResultWithNullItems()
    {
        FluentActions.Invoking(() => default(IAsyncEnumerable<TItem>).ForEachAsync<TItem, TResult>(x => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForEachAsync method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachAsyncWithIAsyncEnumerableOfTItemAndFuncOfTItemAndTResultWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IAsyncEnumerable<TItem>>().ForEachAsync<TItem, TResult>(default(Func<TItem, TResult>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForEach method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallForEachWithTItemAndTResultAndIQueryableOfTItemAndFuncOfTItemAndTResult()
    {
        // Arrange
        var items = _fixture.Create<IQueryable<TItem>>();
        Func<TItem, TResult> action = x => _fixture.Create<TResult>();

        // Act
        var result = items.ForEach<TItem, TResult>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForEach method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachWithTItemAndTResultAndIQueryableOfTItemAndFuncOfTItemAndTResultWithNullItems()
    {
        FluentActions.Invoking(() => default(IQueryable<TItem>).ForEach<TItem, TResult>(x => _fixture.Create<TResult>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForEach method throws when the action parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallForEachWithTItemAndTResultAndIQueryableOfTItemAndFuncOfTItemAndTResultWithNullAction()
    {
        FluentActions.Invoking(() => _fixture.Create<IQueryable<TItem>>().ForEach<TItem, TResult>(default(Func<TItem, TResult>))).Should().Throw<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForEachAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallForEachAsyncWithTItemAndTResultAndIQueryableOfTItemAndFuncOfTItemAndTResultAsync()
    {
        // Arrange
        var items = _fixture.Create<IQueryable<TItem>>();
        Func<TItem, TResult> action = x => _fixture.Create<TResult>();

        // Act
        var result = await items.ForEachAsync<TItem, TResult>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForEachAsync method throws when the items parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallForEachAsyncWithTItemAndTResultAndIQueryableOfTItemAndFuncOfTItemAndTResultWithNullItemsAsync()
    {
        await FluentActions.Invoking(() => default(IQueryable<TItem>).ForEachAsync<TItem, TResult>(x => _fixture.Create<TResult>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForEachAsync method throws when the action parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallForEachAsyncWithTItemAndTResultAndIQueryableOfTItemAndFuncOfTItemAndTResultWithNullActionAsync()
    {
        await FluentActions.Invoking(() => _fixture.Create<IQueryable<TItem>>().ForEachAsync<TItem, TResult>(default(Func<TItem, TResult>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForEachAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallForEachAsyncWithTItemAndIEnumerableOfTItemAndActionOfTItemAsync()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Action<TItem> action = x => { };

        // Act
        await items.ForEachAsync<TItem>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForEachAsync method throws when the items parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallForEachAsyncWithTItemAndIEnumerableOfTItemAndActionOfTItemWithNullItemsAsync()
    {
        await FluentActions.Invoking(() => default(IEnumerable<TItem>).ForEachAsync<TItem>(x => { })).Should().ThrowAsync<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForEachAsync method throws when the action parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallForEachAsyncWithTItemAndIEnumerableOfTItemAndActionOfTItemWithNullActionAsync()
    {
        await FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForEachAsync<TItem>(default(Action<TItem>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ForEachAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallForEachAsyncWithTItemAndIEnumerableOfTItemAndActionOfTItemAndIntAsync()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Action<TItem, int> action = (x, y) => { };

        // Act
        await items.ForEachAsync<TItem>(action);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ForEachAsync method throws when the items parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallForEachAsyncWithTItemAndIEnumerableOfTItemAndActionOfTItemAndIntWithNullItemsAsync()
    {
        await FluentActions.Invoking(() => default(IEnumerable<TItem>).ForEachAsync<TItem>((x, y) => { })).Should().ThrowAsync<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ForEachAsync method throws when the action parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallForEachAsyncWithTItemAndIEnumerableOfTItemAndActionOfTItemAndIntWithNullActionAsync()
    {
        await FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().ForEachAsync<TItem>(default(Action<TItem, int>))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("action");
    }

    /// <summary>
    /// Checks that the ToListAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallToListAsync()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        var callback = _fixture.Create<IInvoker>();

        // Act
        var result = await items.ToListAsync<TItem>(callback);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToListAsync method throws when the items parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallToListAsyncWithNullItemsAsync()
    {
        await FluentActions.Invoking(() => default(IEnumerable<TItem>).ToListAsync<TItem>(_fixture.Create<IInvoker>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ToArrayAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallToArrayAsync()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        var callback = _fixture.Create<IInvoker>();

        // Act
        var result = await items.ToArrayAsync<TItem>(callback);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToArrayAsync method throws when the items parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallToArrayAsyncWithNullItemsAsync()
    {
        await FluentActions.Invoking(() => default(IEnumerable<TItem>).ToArrayAsync<TItem>(_fixture.Create<IInvoker>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ToRegistryAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallToRegistryAsync()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        var repeatable = _fixture.Create<bool>();
        var callback = _fixture.Create<IInvoker>();

        // Act
        var result = await items.ToRegistryAsync<TItem>(repeatable, callback);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToRegistryAsync method throws when the items parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallToRegistryAsyncWithNullItemsAsync()
    {
        await FluentActions.Invoking(() => default(IEnumerable<TItem>).ToRegistryAsync<TItem>(_fixture.Create<bool>(), _fixture.Create<IInvoker>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ToCatalogAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallToCatalogAsync()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        var callback = _fixture.Create<IInvoker>();

        // Act
        var result = await items.ToCatalogAsync<TItem>(callback);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToCatalogAsync method throws when the items parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallToCatalogAsyncWithNullItemsAsync()
    {
        await FluentActions.Invoking(() => default(IEnumerable<TItem>).ToCatalogAsync<TItem>(_fixture.Create<IInvoker>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ToListingAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallToListingAsync()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        var callback = _fixture.Create<IInvoker>();

        // Act
        var result = await items.ToListingAsync<TItem>(callback);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToListingAsync method throws when the items parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallToListingAsyncWithNullItemsAsync()
    {
        await FluentActions.Invoking(() => default(IEnumerable<TItem>).ToListingAsync<TItem>(_fixture.Create<IInvoker>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ToListing method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToListing()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        var callback = _fixture.Create<IInvoker>();

        // Act
        var result = items.ToListing<TItem>(callback);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToListing method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToListingWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ToListing<TItem>(_fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ToChainAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallToChainAsync()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        var callback = _fixture.Create<IInvoker>();

        // Act
        var result = await items.ToChainAsync<TItem>(callback);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToChainAsync method throws when the items parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallToChainAsyncWithNullItemsAsync()
    {
        await FluentActions.Invoking(() => default(IEnumerable<TItem>).ToChainAsync<TItem>(_fixture.Create<IInvoker>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ToChain method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToChain()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        var callback = _fixture.Create<IInvoker>();

        // Act
        var result = items.ToChain<TItem>(callback);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToChain method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToChainWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ToChain<TItem>(_fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ToRegistry method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToRegistry()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        var repeatable = _fixture.Create<bool>();
        var callback = _fixture.Create<IInvoker>();

        // Act
        var result = items.ToRegistry<TItem>(repeatable, callback);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToRegistry method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToRegistryWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ToRegistry<TItem>(_fixture.Create<bool>(), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ToCatalog method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToCatalog()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        var callback = _fixture.Create<IInvoker>();

        // Act
        var result = items.ToCatalog<TItem>(callback);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToCatalog method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToCatalogWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ToCatalog<TItem>(_fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the ToTypedRegistry method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToTypedRegistry()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        var repeatable = _fixture.Create<bool>();
        var callback = _fixture.Create<IInvoker>();

        // Act
        var result = items.ToTypedRegistry<TItem>(repeatable, callback);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToTypedRegistry method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToTypedRegistryWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ToTypedRegistry<TItem>(_fixture.Create<bool>(), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the CommitAsync method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallCommitAsync()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();

        // Act
        var result = await items.CommitAsync<TItem>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CommitAsync method throws when the items parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallCommitAsyncWithNullItemsAsync()
    {
        await FluentActions.Invoking(() => default(IEnumerable<TItem>).CommitAsync<TItem>()).Should().ThrowAsync<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Commit method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCommitWithTItemAndIEnumerableOfTItem()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();

        // Act
        var result = items.Commit<TItem>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Commit method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCommitWithTItemAndIEnumerableOfTItemWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).Commit<TItem>()).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Commit method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCommitWithItemsAndActionAfterCommit()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();
        Action<TItem[]> actionAfterCommit = x => { };

        // Act
        var result = items.Commit<TItem>(actionAfterCommit);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Commit method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCommitWithItemsAndActionAfterCommitWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).Commit<TItem>(x => { })).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the Commit method throws when the actionAfterCommit parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCommitWithItemsAndActionAfterCommitWithNullActionAfterCommit()
    {
        FluentActions.Invoking(() => _fixture.Create<IEnumerable<TItem>>().Commit<TItem>(default(Action<TItem[]>))).Should().Throw<ArgumentNullException>().WithParameterName("actionAfterCommit");
    }

    /// <summary>
    /// Checks that the ToObservableCollection method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToObservableCollection()
    {
        // Arrange
        var items = _fixture.Create<IEnumerable<TItem>>();

        // Act
        var result = items.ToObservableCollection<TItem>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToObservableCollection method throws when the items parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToObservableCollectionWithNullItems()
    {
        FluentActions.Invoking(() => default(IEnumerable<TItem>).ToObservableCollection<TItem>()).Should().Throw<ArgumentNullException>().WithParameterName("items");
    }

    /// <summary>
    /// Checks that the CreateLockTransaction method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateLockTransaction()
    {
        // Act
        var result = SeriesLinqExtensions.CreateLockTransaction();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToArray()
    {
        // Arrange
        var query = _fixture.Create<IQueryable<T>>();

        // Act
        var result = query.ToArray<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToArray method throws when the query parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToArrayWithNullQuery()
    {
        FluentActions.Invoking(() => default(IQueryable<T>).ToArray<T>()).Should().Throw<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that the ToList method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToList()
    {
        // Arrange
        var query = _fixture.Create<IQueryable<T>>();

        // Act
        var result = query.ToList<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToList method throws when the query parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToListWithNullQuery()
    {
        FluentActions.Invoking(() => default(IQueryable<T>).ToList<T>()).Should().Throw<ArgumentNullException>().WithParameterName("query");
    }

    /// <summary>
    /// Checks that the EnsureOne method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEnsureOne()
    {
        // Arrange
        var query = _fixture.Create<IEnumerable<T>>();

        // Act
        var result = query.EnsureOne<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EnsureOne method throws when the query parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEnsureOneWithNullQuery()
    {
        FluentActions.Invoking(() => default(IEnumerable<T>).EnsureOne<T>()).Should().Throw<ArgumentNullException>().WithParameterName("query");
    }
}