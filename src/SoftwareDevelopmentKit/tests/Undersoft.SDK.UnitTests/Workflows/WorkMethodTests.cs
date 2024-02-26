using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Series;
using Undersoft.SDK.Workflows;

namespace Undersoft.SDK.UnitTests.Workflows;

/// <summary>
/// Unit tests for the type <see cref="WorkMethod"/>.
/// </summary>
public class WorkMethodTests
{
    private WorkMethod _testClass;
    private IFixture _fixture;
    private Mock<IInvoker> _value;
    private long _keyInt64;
    private object _keyObject;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkMethod"/>.
    /// </summary>
    public WorkMethodTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._value = _fixture.Freeze<Mock<IInvoker>>();
        this._keyInt64 = _fixture.Create<long>();
        this._keyObject = _fixture.Create<object>();
        this._testClass = _fixture.Create<WorkMethod>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new WorkMethod();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkMethod(this._value.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkMethod(this._keyInt64, this._value.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new WorkMethod(this._keyObject, this._value.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullValue()
    {
        FluentActions.Invoking(() => new WorkMethod(default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new WorkMethod(this._keyInt64, default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new WorkMethod(this._keyObject, default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that instance construction throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKey()
    {
        FluentActions.Invoking(() => new WorkMethod(default(long), this._value.Object)).Should().Throw<ArgumentNullException>().WithParameterName("key");
        FluentActions.Invoking(() => new WorkMethod(default(object), this._value.Object)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareTo()
    {
        // Arrange
        var other = _fixture.Create<object>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var y = _fixture.Create<object>();

        // Act
        var result = this._testClass.Equals(y);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the y parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullY()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("y");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytes()
    {
        // Act
        var result = this._testClass.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCode()
    {
        // Act
        var result = this._testClass.GetHashCode();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIdBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIdBytes()
    {
        // Act
        var result = this._testClass.GetIdBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithItem()
    {
        // Arrange
        var item = _fixture.Create<ISeriesItem<IInvoker>>();

        // Act
        this._testClass.Set(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithItemWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(ISeriesItem<IInvoker>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithValue()
    {
        // Arrange
        var value = _fixture.Create<IInvoker>();

        // Act
        this._testClass.Set(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithValueWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithKeyAndValue()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<IInvoker>();

        // Act
        this._testClass.Set(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithKeyAndValueWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(object), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Set method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithKeyAndValueWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<object>(), default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Id property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.Id = testValue;

        // Assert
        this._testClass.Id.Should().Be(testValue);
    }
}