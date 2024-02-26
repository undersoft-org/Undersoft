using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Workflows;

namespace Undersoft.SDK.UnitTests.Workflows;

/// <summary>
/// Unit tests for the type <see cref="WorkMethods"/>.
/// </summary>
public class WorkMethodsTests
{
    private WorkMethods _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkMethods"/>.
    /// </summary>
    public WorkMethodsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<WorkMethods>();
    }

    /// <summary>
    /// Checks that the EmptyVector method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyVector()
    {
        // Arrange
        var size = _fixture.Create<int>();

        // Act
        var result = this._testClass.EmptyVector(size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EmptyItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyItem()
    {
        // Act
        var result = this._testClass.EmptyItem();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EmptyTable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyTable()
    {
        // Arrange
        var size = _fixture.Create<int>();

        // Act
        var result = this._testClass.EmptyTable(size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithValue()
    {
        // Arrange
        var value = _fixture.Create<IInvoker>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithValueWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithValuePerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<IInvoker>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithObjectAndIInvoker()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<IInvoker>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndIInvokerWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(object), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndIInvokerWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(_fixture.Create<object>(), default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithObjectAndIInvokerPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<IInvoker>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithLongAndIInvoker()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<IInvoker>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithLongAndIInvokerWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(_fixture.Create<long>(), default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithLongAndIInvokerPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<IInvoker>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }
}