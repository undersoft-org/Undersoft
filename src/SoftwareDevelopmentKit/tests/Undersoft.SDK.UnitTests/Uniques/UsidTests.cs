using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.UnitTests.Uniques;

/// <summary>
/// Unit tests for the type <see cref="Usid"/>.
/// </summary>
public class UsidTests
{
    private Usid _testClass;
    private IFixture _fixture;
    private long _lInt64;
    private ulong _lUInt64;
    private string _ca;
    private byte[] _b;
    private ushort _z;
    private ushort _y;
    private uint _x;
    private object _key;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Usid"/>.
    /// </summary>
    public UsidTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._lInt64 = _fixture.Create<long>();
        this._lUInt64 = _fixture.Create<ulong>();
        this._ca = _fixture.Create<string>();
        this._b = _fixture.Create<byte[]>();
        this._z = _fixture.Create<ushort>();
        this._y = _fixture.Create<ushort>();
        this._x = _fixture.Create<uint>();
        this._key = _fixture.Create<object>();
        this._testClass = _fixture.Create<Usid>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Usid(this._lInt64);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Usid(this._lUInt64);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Usid(this._ca);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Usid(this._b);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Usid(this._z, this._y, this._x);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Usid(this._key);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the b parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullB()
    {
        FluentActions.Invoking(() => new Usid(default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("b");
    }

    /// <summary>
    /// Checks that instance construction throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullKey()
    {
        FluentActions.Invoking(() => new Usid(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the constructor throws when the ca parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidCa(string value)
    {
        FluentActions.Invoking(() => new Usid(value)).Should().Throw<ArgumentNullException>().WithParameterName("ca");
    }

    /// <summary>
    /// Checks that the System.IEquatable interface is implemented correctly.
    /// </summary>
    [TestMethod]
    public void ImplementsIEquatable_IUnique()
    {
        // Arrange
        var same = _fixture.Create<IUnique>();
        var different = _fixture.Create<IUnique>();

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
        Usid baseValue = default(Usid);
        Usid equalToBaseValue = default(Usid);
        Usid greaterThanBaseValue = default(Usid);

        // Assert
        baseValue.CompareTo(equalToBaseValue).Should().Be(0);
        baseValue.CompareTo(greaterThanBaseValue).Should().BeLessThan(0);
        greaterThanBaseValue.CompareTo(baseValue).Should().BeGreaterThan(0);
    }

    /// <summary>
    /// Checks that the System.IComparable interface is implemented correctly.
    /// </summary>
    [TestMethod]
    public void ImplementsIComparable_IUnique()
    {
        // Arrange
        Usid baseValue = default(Usid);
        IUnique equalToBaseValue = default(IUnique);
        IUnique greaterThanBaseValue = default(IUnique);

        // Assert
        baseValue.CompareTo(equalToBaseValue).Should().Be(0);
        baseValue.CompareTo(greaterThanBaseValue).Should().BeLessThan(0);
        greaterThanBaseValue.CompareTo(baseValue).Should().BeGreaterThan(0);
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
    /// Checks that the SetKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetKey()
    {
        // Arrange
        var value = _fixture.Create<long>();

        // Act
        this._testClass.SetKey(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetKey()
    {
        // Act
        var result = this._testClass.GetKey();

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
    public void CanCallCompareToWithUsid()
    {
        // Arrange
        var g = _fixture.Create<Usid>();

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
    public void CanCallEqualsWithUsid()
    {
        // Arrange
        var g = _fixture.Create<Usid>();

        // Act
        var result = this._testClass.Equals(g);

        // Assert
        Assert.Fail("Create or modify test");
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
    public void CanCallEqualsWithString()
    {
        // Arrange
        var g = _fixture.Create<string>();

        // Act
        var result = this._testClass.Equals(g);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the g parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallEqualsWithStringWithInvalidG(string value)
    {
        FluentActions.Invoking(() => this._testClass.Equals(value)).Should().Throw<ArgumentNullException>().WithParameterName("g");
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
    /// Checks that the SetTypeKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetTypeKey()
    {
        // Arrange
        var seed = _fixture.Create<ulong>();

        // Act
        this._testClass.SetTypeKey(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetTypeKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetTypeKey()
    {
        // Act
        var result = this._testClass.GetTypeKey();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualsWithIIdentifiable()
    {
        // Arrange
        var other = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.Equals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithIIdentifiableWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareToWithIIdentifiable()
    {
        // Arrange
        var other = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithIIdentifiableWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the Equality operator functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEqualityOperator()
    {
        // Arrange
        var a = _fixture.Create<Usid>();
        var b = _fixture.Create<Usid>();

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
        var a = _fixture.Create<Usid>();
        var b = _fixture.Create<Usid>();

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
        var testValue = _fixture.Create<uint>();

        // Act
        this._testClass.BlockX = testValue;

        // Assert
        this._testClass.BlockX.Should().Be(testValue);
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
        Usid.Empty.As<object>().Should().BeAssignableTo<Usid>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetNew()
    {
        // Assert
        Usid.New.As<object>().Should().BeAssignableTo<Usid>();

        Assert.Fail("Create or modify test");
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
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexer()
    {
        var testValue = _fixture.Create<byte[]>();
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<byte[]>();
        this._testClass[_fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>()].Should().BeSameAs(testValue);
    }
}