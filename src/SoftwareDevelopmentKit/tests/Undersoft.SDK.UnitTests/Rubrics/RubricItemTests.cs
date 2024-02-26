using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.UnitTests.Rubrics;

/// <summary>
/// Unit tests for the type <see cref="RubricItem"/>.
/// </summary>
public class RubricItemTests
{
    private RubricItem _testClass;
    private IFixture _fixture;
    private Mock<ISeriesItem<MemberRubric>> _valueISeriesItemMemberRubric;
    private MemberRubric _valueMemberRubric;
    private object _keyObject;
    private ulong _keyUInt64;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RubricItem"/>.
    /// </summary>
    public RubricItemTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._valueISeriesItemMemberRubric = _fixture.Freeze<Mock<ISeriesItem<MemberRubric>>>();
        this._valueMemberRubric = _fixture.Create<MemberRubric>();
        this._keyObject = _fixture.Create<object>();
        this._keyUInt64 = _fixture.Create<ulong>();
        this._testClass = _fixture.Create<RubricItem>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RubricItem();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RubricItem(this._valueISeriesItemMemberRubric.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RubricItem(this._valueMemberRubric);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RubricItem(this._keyObject, this._valueMemberRubric);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RubricItem(this._keyUInt64, this._valueMemberRubric);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullValue()
    {
        FluentActions.Invoking(() => new RubricItem(default(ISeriesItem<MemberRubric>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new RubricItem(default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new RubricItem(this._keyObject, default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("value");
        FluentActions.Invoking(() => new RubricItem(this._keyUInt64, default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that instance construction throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKey()
    {
        FluentActions.Invoking(() => new RubricItem(default(object), this._valueMemberRubric)).Should().Throw<ArgumentNullException>().WithParameterName("key");
        FluentActions.Invoking(() => new RubricItem(default(ulong), this._valueMemberRubric)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithISeriesItemOfMemberRubric()
    {
        // Arrange
        var other = _fixture.Create<ISeriesItem<MemberRubric>>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithISeriesItemOfMemberRubricWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(ISeriesItem<MemberRubric>))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithObject()
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
    public void CannotCallCompareToWithObjectWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithLong()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.CompareTo(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithY()
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
    public void CannotCallEqualsWithYWithNullY()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("y");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithLong()
    {
        // Arrange
        var key = _fixture.Create<long>();

        // Act
        var result = this._testClass.Equals(key);

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
        var item = _fixture.Create<ISeriesItem<MemberRubric>>();

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
        FluentActions.Invoking(() => this._testClass.Set(default(ISeriesItem<MemberRubric>))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithValue()
    {
        // Arrange
        var value = _fixture.Create<MemberRubric>();

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
        FluentActions.Invoking(() => this._testClass.Set(default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetWithKeyAndValue()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<MemberRubric>();

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
        FluentActions.Invoking(() => this._testClass.Set(default(object), _fixture.Create<MemberRubric>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Set method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithKeyAndValueWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Set(_fixture.Create<object>(), default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("value");
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