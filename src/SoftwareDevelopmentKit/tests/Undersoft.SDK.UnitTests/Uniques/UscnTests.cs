using System;
using System.Collections.Specialized;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.UnitTests.Uniques;

/// <summary>
/// Unit tests for the type <see cref="Uscn"/>.
/// </summary>
public class UscnTests
{
    private Uscn _testClass;
    private IFixture _fixture;
    private long _l;
    private string _s;
    private byte[] _b;
    private long _keyInt64;
    private long _seed;
    private byte[] _keyUnknownType;
    private object _keyObject;
    private short _z;
    private short _y;
    private short _x;
    private short _flagsInt16;
    private long _timeInt64;
    private BitVector32 _flagsBitVector32;
    private DateTime _timeDateTime;
    private Uscn _item;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Uscn"/>.
    /// </summary>
    public UscnTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._l = _fixture.Create<long>();
        this._s = _fixture.Create<string>();
        this._b = _fixture.Create<byte[]>();
        this._keyInt64 = _fixture.Create<long>();
        this._seed = _fixture.Create<long>();
        this._keyUnknownType = _fixture.Create<byte[]>();
        this._keyObject = _fixture.Create<object>();
        this._z = _fixture.Create<short>();
        this._y = _fixture.Create<short>();
        this._x = _fixture.Create<short>();
        this._flagsInt16 = _fixture.Create<short>();
        this._timeInt64 = _fixture.Create<long>();
        this._flagsBitVector32 = _fixture.Create<BitVector32>();
        this._timeDateTime = _fixture.Create<DateTime>();
        this._item = _fixture.Create<Uscn>();
        this._testClass = _fixture.Create<Uscn>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Uscn();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Uscn(this._l);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Uscn(this._s);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Uscn(this._b);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Uscn(this._keyInt64, this._seed);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Uscn(this._keyUnknownType, this._seed);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Uscn(this._keyObject, this._seed);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Uscn(this._keyInt64, this._z, this._y, this._x, this._flagsInt16, this._timeInt64);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Uscn(this._keyUnknownType, this._z, this._y, this._x, this._flagsInt16, this._timeInt64);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Uscn(this._keyObject, this._z, this._y, this._x, this._flagsBitVector32, this._timeDateTime);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Uscn(this._keyObject);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Uscn(this._item);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the b parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullB()
    {
        FluentActions.Invoking(() => new Uscn(default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("b");
    }

    /// <summary>
    /// Checks that instance construction throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKey()
    {
        FluentActions.Invoking(() => new Uscn(default(long), this._seed)).Should().Throw<ArgumentNullException>().WithParameterName("key");
        FluentActions.Invoking(() => new Uscn(default(byte[]), this._seed)).Should().Throw<ArgumentNullException>().WithParameterName("key");
        FluentActions.Invoking(() => new Uscn(default(object), this._seed)).Should().Throw<ArgumentNullException>().WithParameterName("key");
        FluentActions.Invoking(() => new Uscn(default(long), this._z, this._y, this._x, this._flagsInt16, this._timeInt64)).Should().Throw<ArgumentNullException>().WithParameterName("key");
        FluentActions.Invoking(() => new Uscn(default(byte[]), this._z, this._y, this._x, this._flagsInt16, this._timeInt64)).Should().Throw<ArgumentNullException>().WithParameterName("key");
        FluentActions.Invoking(() => new Uscn(default(object), this._z, this._y, this._x, this._flagsBitVector32, this._timeDateTime)).Should().Throw<ArgumentNullException>().WithParameterName("key");
        FluentActions.Invoking(() => new Uscn(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the constructor throws when the s parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidS(string value)
    {
        FluentActions.Invoking(() => new Uscn(value)).Should().Throw<ArgumentNullException>().WithParameterName("s");
    }

    /// <summary>
    /// Checks that the System.IEquatable interface is implemented correctly.
    /// </summary>
    [TestMethod]
    public void ImplementsIEquatable_Uscn()
    {
        // Arrange
        var same = new Uscn(this._keyInt64, this._z, this._y, this._x, this._flagsInt16, this._timeInt64);
        var different = _fixture.Create<Uscn>();

        // Assert
        this._testClass.Equals(default(object)).Should().BeFalse();
        this._testClass.Equals(new object()).Should().BeFalse();
        this._testClass.Equals((object)same).Should().BeTrue();
        this._testClass.Equals((object)different).Should().BeFalse();
        this._testClass.Equals(same).Should().BeTrue();
        this._testClass.Equals(different).Should().BeFalse();
        this._testClass.GetHashCode().Should().Be(same.GetHashCode());
        this._testClass.GetHashCode().Should().NotBe(different.GetHashCode());
        (this._testClass == same).Should().BeTrue();
        (this._testClass == different).Should().BeFalse();
        (this._testClass != same).Should().BeFalse();
        (this._testClass != different).Should().BeTrue();
    }

    /// <summary>
    /// Checks that the System.IComparable interface is implemented correctly.
    /// </summary>
    [TestMethod]
    public void ImplementsIComparable()
    {
        // Arrange
        Uscn baseValue = default(Uscn);
        Uscn equalToBaseValue = default(Uscn);
        Uscn greaterThanBaseValue = default(Uscn);

        // Assert
        baseValue.CompareTo(equalToBaseValue).Should().Be(0);
        baseValue.CompareTo(greaterThanBaseValue).Should().BeLessThan(0);
        greaterThanBaseValue.CompareTo(baseValue).Should().BeGreaterThan(0);
    }

    /// <summary>
    /// Checks that the System.IComparable interface is implemented correctly.
    /// </summary>
    [TestMethod]
    public void ImplementsIComparable_Uscn()
    {
        // Arrange
        Uscn baseValue = default(Uscn);
        Uscn equalToBaseValue = default(Uscn);
        Uscn greaterThanBaseValue = default(Uscn);

        // Assert
        baseValue.CompareTo(equalToBaseValue).Should().Be(0);
        baseValue.CompareTo(greaterThanBaseValue).Should().BeLessThan(0);
        greaterThanBaseValue.CompareTo(baseValue).Should().BeGreaterThan(0);
    }

    /// <summary>
    /// Checks that the SetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetBytes()
    {
        // Arrange
        var value = _fixture.Create<byte[]>();
        var offset = _fixture.Create<int>();

        // Act
        this._testClass.SetBytes(value, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetBytes method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetBytesWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.SetBytes(default(byte[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithOffsetAndLength()
    {
        // Arrange
        var offset = _fixture.Create<int>();
        var length = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetBytes(offset, length);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithNoParameters()
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
    /// Checks that the SetId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetId()
    {
        // Arrange
        var value = _fixture.Create<long>();

        // Act
        var result = this._testClass.SetId(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetCodeNo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetCodeNo()
    {
        // Arrange
        var value = _fixture.Create<string>();

        // Act
        this._testClass.SetCodeNo(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetCodeNo method throws when the value parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallSetCodeNoWithInvalidValue(string value)
    {
        FluentActions.Invoking(() => this._testClass.SetCodeNo(value)).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the GetId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetId()
    {
        // Act
        var result = this._testClass.GetId();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetTypeId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetTypeId()
    {
        // Arrange
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.SetTypeId(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetOriginId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetOriginId()
    {
        // Arrange
        var key = _fixture.Create<int>();

        // Act
        var result = this._testClass.SetOriginId(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetTypeId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetTypeId()
    {
        // Act
        var result = this._testClass.GetTypeId();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueFromXYZ method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueFromXYZ()
    {
        // Arrange
        var vectorZ = _fixture.Create<uint>();
        var vectorY = _fixture.Create<uint>();

        // Act
        var result = this._testClass.ValueFromXYZ(vectorZ, vectorY);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueToXYZ method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueToXYZ()
    {
        // Arrange
        var vectorZ = _fixture.Create<ulong>();
        var vectorY = _fixture.Create<ulong>();
        var value = _fixture.Create<ulong>();

        // Act
        var result = this._testClass.ValueToXYZ(vectorZ, vectorY, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetFlags method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetFlags()
    {
        // Act
        var result = this._testClass.GetFlags();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetFlagsBits method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetFlagsBits()
    {
        // Act
        var result = this._testClass.GetFlagsBits();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetFlagBits method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetFlagBits()
    {
        // Arrange
        var bits = _fixture.Create<BitVector32>();

        // Act
        this._testClass.SetFlagBits(bits);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetFlagBit method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetFlagBit()
    {
        // Arrange
        var flagNumber = _fixture.Create<ushort>();

        // Act
        this._testClass.SetFlagBit(flagNumber);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ClearFlagBit method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClearFlagBit()
    {
        // Arrange
        var flagNumber = _fixture.Create<ushort>();

        // Act
        this._testClass.ClearFlagBit(flagNumber);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetFlagBit method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetFlagBit()
    {
        // Arrange
        var flagNumber = _fixture.Create<ushort>();

        // Act
        var result = this._testClass.GetFlagBit(flagNumber);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetFlag method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetFlag()
    {
        // Arrange
        var flag = _fixture.Create<StateFlags>();

        // Act
        var result = this._testClass.GetFlag(flag);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetFlag method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetFlagWithFlagAndIsOn()
    {
        // Arrange
        var flag = _fixture.Create<StateFlags>();
        var isOn = _fixture.Create<bool>();

        // Act
        this._testClass.SetFlag(flag, isOn);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetFlag method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetFlagWithFlagAndFlagNumber()
    {
        // Arrange
        var flag = _fixture.Create<bool>();
        var flagNumber = _fixture.Create<ushort>();

        // Act
        this._testClass.SetFlag(flag, flagNumber);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetPriority method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPriority()
    {
        // Act
        var result = this._testClass.GetPriority();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetPriority method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetPriority()
    {
        // Arrange
        var priority = _fixture.Create<byte>();

        // Act
        var result = this._testClass.SetPriority(priority);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComparePriority method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComparePriority()
    {
        // Arrange
        var priority = _fixture.Create<byte>();

        // Act
        var result = this._testClass.ComparePriority(priority);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDateLong method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDateLong()
    {
        // Act
        var result = this._testClass.GetDateLong();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDateTime method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDateTime()
    {
        // Act
        var result = this._testClass.GetDateTime();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetDateLong method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetDateLong()
    {
        // Arrange
        var item = _fixture.Create<long>();

        // Act
        this._testClass.SetDateLong(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetGuid method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetGuid()
    {
        // Act
        var result = this._testClass.GetGuid();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetGuid method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetGuid()
    {
        // Arrange
        var guid = _fixture.Create<Guid>();

        // Act
        this._testClass.SetGuid(guid);

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
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithObject()
    {
        // Arrange
        var value = _fixture.Create<object>();

        // Act
        var result = this._testClass.CompareTo(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithObjectWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithUscn()
    {
        // Arrange
        var g = _fixture.Create<Uscn>();

        // Act
        var result = this._testClass.CompareTo(g);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithIUnique()
    {
        // Arrange
        var g = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.CompareTo(g);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the g parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithIUniqueWithNullG()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("g");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithIIdentifiable()
    {
        // Arrange
        var g = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.CompareTo(g);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the g parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithIIdentifiableWithNullG()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("g");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithLong()
    {
        // Arrange
        var g = _fixture.Create<long>();

        // Act
        var result = this._testClass.Equals(g);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithObject()
    {
        // Arrange
        var value = _fixture.Create<object>();

        // Act
        var result = this._testClass.Equals(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithObjectWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithIUnique()
    {
        // Arrange
        var g = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.Equals(g);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the g parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithIUniqueWithNullG()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("g");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithIIdentifiable()
    {
        // Arrange
        var g = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.Equals(g);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the g parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithIIdentifiableWithNullG()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("g");
    }

    /// <summary>
    /// Checks that the ToString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToStringWithNoParameters()
    {
        // Act
        var result = this._testClass.ToString();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToStringWithFormat()
    {
        // Arrange
        var format = _fixture.Create<string>();

        // Act
        var result = this._testClass.ToString(format);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToString method throws when the format parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallToStringWithFormatWithInvalidFormat(string value)
    {
        FluentActions.Invoking(() => this._testClass.ToString(value)).Should().Throw<ArgumentNullException>().WithParameterName("format");
    }

    /// <summary>
    /// Checks that the ToString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToStringWithFormatAndFormatProvider()
    {
        // Arrange
        var format = _fixture.Create<string>();
        var formatProvider = _fixture.Create<IFormatProvider>();

        // Act
        var result = this._testClass.ToString(format, formatProvider);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToString method throws when the formatProvider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToStringWithFormatAndFormatProviderWithNullFormatProvider()
    {
        FluentActions.Invoking(() => this._testClass.ToString(_fixture.Create<string>(), default(IFormatProvider))).Should().Throw<ArgumentNullException>().WithParameterName("formatProvider");
    }

    /// <summary>
    /// Checks that the ToString method throws when the format parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallToStringWithFormatAndFormatProviderWithInvalidFormat(string value)
    {
        FluentActions.Invoking(() => this._testClass.ToString(value, _fixture.Create<IFormatProvider>())).Should().Throw<ArgumentNullException>().WithParameterName("format");
    }

    /// <summary>
    /// Checks that the Auto method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAuto()
    {
        // Act
        var result = this._testClass.Auto();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToTetrahex method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToTetrahex()
    {
        // Act
        var result = this._testClass.ToTetrahex();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromTetrahex method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromTetrahex()
    {
        // Arrange
        var pchchar = _fixture.Create<char[]>();

        // Act
        this._testClass.FromTetrahex(pchchar);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromTetrahex method throws when the pchchar parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromTetrahexWithNullPchchar()
    {
        FluentActions.Invoking(() => this._testClass.FromTetrahex(default(char[]))).Should().Throw<ArgumentNullException>().WithParameterName("pchchar");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithUscn()
    {
        // Arrange
        var g = _fixture.Create<Uscn>();

        // Act
        var result = this._testClass.Equals(g);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithBitVector32()
    {
        // Arrange
        var other = _fixture.Create<BitVector32>();

        // Act
        var result = this._testClass.Equals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithDateTime()
    {
        // Arrange
        var other = _fixture.Create<DateTime>();

        // Act
        var result = this._testClass.Equals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithIUniqueStructure()
    {
        // Arrange
        var other = _fixture.Create<IUniqueStructure>();

        // Act
        var result = this._testClass.Equals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithIUniqueStructureWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IUniqueStructure))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the Dispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDispose()
    {
        // Act
        this._testClass.Dispose();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equality operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualityOperator()
    {
        // Arrange
        var a = _fixture.Create<Uscn>();
        var b = _fixture.Create<Uscn>();

        // Act
        var result = a == b;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Inequality operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInequalityOperator()
    {
        // Arrange
        var a = _fixture.Create<Uscn>();
        var b = _fixture.Create<Uscn>();

        // Act
        var result = a != b;

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CodeNo property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCodeNo()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.CodeNo = testValue;

        // Assert
        this._testClass.CodeNo.Should().Be(testValue);
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

    /// <summary>
    /// Checks that the OriginId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOriginId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.OriginId = testValue;

        // Assert
        this._testClass.OriginId.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the BlockZY property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBlockZY()
    {
        // Arrange
        var testValue = _fixture.Create<uint>();

        // Act
        this._testClass.BlockZY = testValue;

        // Assert
        this._testClass.BlockZY.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the BlockZYX property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBlockZYX()
    {
        // Arrange
        var testValue = _fixture.Create<ulong>();

        // Act
        this._testClass.BlockZYX = testValue;

        // Assert
        this._testClass.BlockZYX.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the BlockZ property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBlockZ()
    {
        // Arrange
        var testValue = _fixture.Create<ushort>();

        // Act
        this._testClass.BlockZ = testValue;

        // Assert
        this._testClass.BlockZ.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the BlockY property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBlockY()
    {
        // Arrange
        var testValue = _fixture.Create<ushort>();

        // Act
        this._testClass.BlockY = testValue;

        // Assert
        this._testClass.BlockY.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the BlockX property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBlockX()
    {
        // Arrange
        var testValue = _fixture.Create<ushort>();

        // Act
        this._testClass.BlockX = testValue;

        // Assert
        this._testClass.BlockX.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Priority property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPriority()
    {
        // Arrange
        var testValue = _fixture.Create<byte>();

        // Act
        this._testClass.Priority = testValue;

        // Assert
        this._testClass.Priority.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Flags property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFlags()
    {
        // Arrange
        var testValue = _fixture.Create<byte>();

        // Act
        this._testClass.Flags = testValue;

        // Assert
        this._testClass.Flags.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Time property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTime()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.Time = testValue;

        // Assert
        this._testClass.Time.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the GUID property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetGUID()
    {
        // Arrange
        var testValue = _fixture.Create<Guid>();

        // Act
        this._testClass.GUID = testValue;

        // Assert
        this._testClass.GUID.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the IsNotEmpty property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIsNotEmpty()
    {
        // Assert
        this._testClass.IsNotEmpty.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsEmpty property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIsEmpty()
    {
        // Assert
        this._testClass.IsEmpty.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Empty property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetEmpty()
    {
        // Assert
        Uscn.Empty.As<object>().Should().BeAssignableTo<Uscn>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetNew()
    {
        // Assert
        Uscn.New.As<object>().Should().BeAssignableTo<Uscn>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForInt()
    {
        var testValue = _fixture.Create<byte[]>();
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<byte[]>();
        this._testClass[_fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForIntAndInt()
    {
        var testValue = _fixture.Create<byte[]>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>()].Should().BeAssignableTo<byte[]>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>()].Should().BeSameAs(testValue);
    }
}