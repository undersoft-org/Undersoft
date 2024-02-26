using System;
using System.Collections;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series.Universe;
using Undersoft.SDK.Uniques;
using V = System.String;

namespace Undersoft.SDK.UnitTests.Series.Universe;

/// <summary>
/// Unit tests for the type <see cref="Universe"/>.
/// </summary>
public class Universe_1Tests
{
    private Universe<V> _testClass;
    private IFixture _fixture;
    private int _size;
    private bool _safeThread;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Universe"/>.
    /// </summary>
    public Universe_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._size = _fixture.Create<int>();
        this._safeThread = _fixture.Create<bool>();
        this._testClass = _fixture.Create<Universe<V>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Universe<V>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Universe<V>(this._size, this._safeThread);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Initialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInitialize()
    {
        // Arrange
        var range = _fixture.Create<int>();
        var safeThred = _fixture.Create<bool>();

        // Act
        this._testClass.Initialize(range, safeThred);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAdd()
    {
        // Arrange
        var key = _fixture.Create<int>();
        var obj = _fixture.Create<V>();

        // Act
        var result = this._testClass.Add(key, obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContains()
    {
        // Arrange
        var key = _fixture.Create<int>();

        // Act
        var result = this._testClass.Contains(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var key = _fixture.Create<int>();

        // Act
        var result = this._testClass.Get(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEnumerator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEnumeratorWithNoParameters()
    {
        // Act
        var result = this._testClass.GetEnumerator();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Next method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNext()
    {
        // Arrange
        var key = _fixture.Create<int>();

        // Act
        var result = this._testClass.Next(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Previous method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPrevious()
    {
        // Arrange
        var key = _fixture.Create<int>();

        // Act
        var result = this._testClass.Previous(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemove()
    {
        // Arrange
        var key = _fixture.Create<int>();

        // Act
        var result = this._testClass.Remove(key);

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
        var key = _fixture.Create<int>();
        var value = _fixture.Create<V>();

        // Act
        var result = this._testClass.Set(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryAdd method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryAdd()
    {
        // Arrange
        var key = _fixture.Create<int>();

        // Act
        var result = this._testClass.TryAdd(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryContains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryContains()
    {
        // Arrange
        var key = _fixture.Create<int>();

        // Act
        var result = this._testClass.TryContains(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryRemove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryRemove()
    {
        // Arrange
        var key = _fixture.Create<int>();

        // Act
        var result = this._testClass.TryRemove(key);

        // Assert
        Assert.Fail("Create or modify test");
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
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.Equals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareTo()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

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
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the GetEnumerator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEnumeratorForIEnumerableWithNoParameters()
    {
        // Act
        var result = ((IEnumerable)this._testClass).GetEnumerator();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Count property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetCount()
    {
        // Assert
        this._testClass.Count.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexMax property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIndexMax()
    {
        // Assert
        this._testClass.IndexMax.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexMin property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIndexMin()
    {
        // Assert
        this._testClass.IndexMin.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
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

    /// <summary>
    /// Checks that the TypeId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.TypeId = testValue;

        // Assert
        this._testClass.TypeId.Should().Be(testValue);
    }
}