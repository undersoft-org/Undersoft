using System;
using System.Collections;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Uniques;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Uniques;

/// <summary>
/// Unit tests for the type <see cref="UniqueKey64Extensions"/>.
/// </summary>
public class UniqueKey64ExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ComparableDouble method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComparableDouble()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var t = _fixture.Create<Type>();

        // Act
        var result = obj.ComparableDouble(t);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComparableDouble method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComparableDoubleWithNullObj()
    {
        FluentActions.Invoking(() => default(object).ComparableDouble(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the ComparableInt64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComparableInt64()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = obj.ComparableInt64(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComparableInt64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComparableInt64WithNullObj()
    {
        FluentActions.Invoking(() => default(object).ComparableInt64(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCodeWithArrayOfByteAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.GetHashCode(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetHashCodeWithArrayOfByteAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(byte[]).GetHashCode(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCodeWithTAndIEquatableOfTAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IEquatable<T>>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.GetHashCode<T>(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetHashCodeWithTAndIEquatableOfTAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IEquatable<T>).GetHashCode<T>(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCodeWithIListAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.GetHashCode(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetHashCodeWithIListAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IList).GetHashCode(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCodeWithNintAndIntAndLong()
    {
        // Arrange
        var ptr = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = ptr.GetHashCode(length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCodeWithIOrigin()
    {
        // Arrange
        var obj = _fixture.Create<IOrigin>();

        // Act
        var result = obj.GetHashCode();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetHashCodeWithIOriginWithNullObj()
    {
        FluentActions.Invoking(() => default(IOrigin).GetHashCode()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCodeWithIIdentifiable()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();

        // Act
        var result = obj.GetHashCode();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetHashCodeWithIIdentifiableWithNullObj()
    {
        FluentActions.Invoking(() => default(IIdentifiable).GetHashCode()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCodeWithObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.GetHashCode(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetHashCodeWithObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(object).GetHashCode(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCodeWithStringAndLong()
    {
        // Arrange
        var obj = _fixture.Create<string>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.GetHashCode(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method throws when the obj parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetHashCodeWithStringAndLongWithInvalidObj(string value)
    {
        FluentActions.Invoking(() => value.GetHashCode(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCodeWithTypeAndLong()
    {
        // Arrange
        var obj = _fixture.Create<Type>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.GetHashCode(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetHashCode method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetHashCodeWithTypeAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(Type).GetHashCode(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the NullOrEquals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNullOrEqualsWithICollectionAndObject()
    {
        // Arrange
        var obj = _fixture.Create<ICollection>();
        var value = _fixture.Create<object>();

        // Act
        var result = obj.NullOrEquals(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NullOrEquals method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNullOrEqualsWithICollectionAndObjectWithNullObj()
    {
        FluentActions.Invoking(() => default(ICollection).NullOrEquals(_fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the NullOrEquals method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNullOrEqualsWithICollectionAndObjectWithNullValue()
    {
        FluentActions.Invoking(() => _fixture.Create<ICollection>().NullOrEquals(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NullOrEquals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNullOrEqualsWithObjectAndObject()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var value = _fixture.Create<object>();

        // Act
        var result = obj.NullOrEquals(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NullOrEquals method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNullOrEqualsWithObjectAndObjectWithNullObj()
    {
        FluentActions.Invoking(() => default(object).NullOrEquals(_fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the NullOrEquals method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNullOrEqualsWithObjectAndObjectWithNullValue()
    {
        FluentActions.Invoking(() => _fixture.Create<object>().NullOrEquals(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes64WithArrayOfByteAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = bytes.UniqueBytes64(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes64WithArrayOfByteAndLongWithNullBytes()
    {
        FluentActions.Invoking(() => default(byte[]).UniqueBytes64(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes64WithIListAndArrayOfIntAndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var sizes = _fixture.Create<int[]>();
        var totalsize = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueBytes64(sizes, totalsize, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes64WithIListAndArrayOfIntAndIntAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IList).UniqueBytes64(_fixture.Create<int[]>(), _fixture.Create<int>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method throws when the sizes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes64WithIListAndArrayOfIntAndIntAndLongWithNullSizes()
    {
        FluentActions.Invoking(() => _fixture.Create<IList>().UniqueBytes64(default(int[]), _fixture.Create<int>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("sizes");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes64WithIListAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueBytes64(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes64WithIListAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IList).UniqueBytes64(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes64WithBytesAndLengthAndSeed()
    {
        // Arrange
        var bytes = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = bytes.UniqueBytes64(length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes64WithIOrigin()
    {
        // Arrange
        var obj = _fixture.Create<IOrigin>();

        // Act
        var result = obj.UniqueBytes64();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes64WithIOriginWithNullObj()
    {
        FluentActions.Invoking(() => default(IOrigin).UniqueBytes64()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes64WithIIdentifiable()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();

        // Act
        var result = obj.UniqueBytes64();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes64WithIIdentifiableWithNullObj()
    {
        FluentActions.Invoking(() => default(IIdentifiable).UniqueBytes64()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes64WithObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueBytes64(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes64WithObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(object).UniqueBytes64(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes64WithArrayOfObjectAndArrayOfIntAndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object[]>();
        var sizes = _fixture.Create<int[]>();
        var totalsize = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueBytes64(sizes, totalsize, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes64WithArrayOfObjectAndArrayOfIntAndIntAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(object[]).UniqueBytes64(_fixture.Create<int[]>(), _fixture.Create<int>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method throws when the sizes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes64WithArrayOfObjectAndArrayOfIntAndIntAndLongWithNullSizes()
    {
        FluentActions.Invoking(() => _fixture.Create<object[]>().UniqueBytes64(default(int[]), _fixture.Create<int>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("sizes");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes64WithArrayOfObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueBytes64(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes64WithArrayOfObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(object[]).UniqueBytes64(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes64WithStringAndLong()
    {
        // Arrange
        var obj = _fixture.Create<string>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueBytes64(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method throws when the obj parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallUniqueBytes64WithStringAndLongWithInvalidObj(string value)
    {
        FluentActions.Invoking(() => value.UniqueBytes64(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes64WithTypeAndLong()
    {
        // Arrange
        var obj = _fixture.Create<Type>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueBytes64(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes64WithTypeAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(Type).UniqueBytes64(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKeyWithArrayOfByteAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = bytes.UniqueKey(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKeyWithArrayOfByteAndLongWithNullBytes()
    {
        FluentActions.Invoking(() => default(byte[]).UniqueKey(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the UniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKeyWithTAndIEquatableOfTAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IEquatable<T>>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey<T>(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKeyWithTAndIEquatableOfTAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IEquatable<T>).UniqueKey<T>(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKeyWithIListAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKeyWithIListAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IList).UniqueKey(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKeyWithNintAndIntAndLong()
    {
        // Arrange
        var ptr = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = ptr.UniqueKey(length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKeyWithIOrigin()
    {
        // Arrange
        var obj = _fixture.Create<IOrigin>();

        // Act
        var result = obj.UniqueKey();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKeyWithIOriginWithNullObj()
    {
        FluentActions.Invoking(() => default(IOrigin).UniqueKey()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKeyWithIOriginAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IOrigin>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKeyWithIOriginAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IOrigin).UniqueKey(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKeyWithIIdentifiable()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();

        // Act
        var result = obj.UniqueKey();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKeyWithIIdentifiableWithNullObj()
    {
        FluentActions.Invoking(() => default(IIdentifiable).UniqueKey()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKeyWithIIdentifiableAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKeyWithIIdentifiableAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IIdentifiable).UniqueKey(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKeyWithObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKeyWithObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(object).UniqueKey(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKeyWithArrayOfObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKeyWithArrayOfObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(object[]).UniqueKey(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKeyWithStringAndLong()
    {
        // Arrange
        var obj = _fixture.Create<string>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey method throws when the obj parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallUniqueKeyWithStringAndLongWithInvalidObj(string value)
    {
        FluentActions.Invoking(() => value.UniqueKey(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKeyWithTypeAndLong()
    {
        // Arrange
        var obj = _fixture.Create<Type>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKeyWithTypeAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(Type).UniqueKey(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey64WithArrayOfByteAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = bytes.UniqueKey64(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey64WithArrayOfByteAndLongWithNullBytes()
    {
        FluentActions.Invoking(() => default(byte[]).UniqueKey64(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey64WithIListAndArrayOfIntAndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var sizes = _fixture.Create<int[]>();
        var totalsize = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey64(sizes, totalsize, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey64WithIListAndArrayOfIntAndIntAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IList).UniqueKey64(_fixture.Create<int[]>(), _fixture.Create<int>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method throws when the sizes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey64WithIListAndArrayOfIntAndIntAndLongWithNullSizes()
    {
        FluentActions.Invoking(() => _fixture.Create<IList>().UniqueKey64(default(int[]), _fixture.Create<int>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("sizes");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey64WithIListAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey64(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey64WithIListAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IList).UniqueKey64(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey64WithNintAndIntAndLong()
    {
        // Arrange
        var ptr = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = ptr.UniqueKey64(length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey64WithIIdentifiable()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();

        // Act
        var result = obj.UniqueKey64();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey64WithIIdentifiableWithNullObj()
    {
        FluentActions.Invoking(() => default(IIdentifiable).UniqueKey64()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey64WithIIdentifiableAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey64(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey64WithIIdentifiableAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IIdentifiable).UniqueKey64(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey64WithObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey64(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey64WithObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(object).UniqueKey64(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey64WithArrayOfObjectAndArrayOfIntAndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object[]>();
        var sizes = _fixture.Create<int[]>();
        var totalsize = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey64(sizes, totalsize, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey64WithArrayOfObjectAndArrayOfIntAndIntAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(object[]).UniqueKey64(_fixture.Create<int[]>(), _fixture.Create<int>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method throws when the sizes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey64WithArrayOfObjectAndArrayOfIntAndIntAndLongWithNullSizes()
    {
        FluentActions.Invoking(() => _fixture.Create<object[]>().UniqueKey64(default(int[]), _fixture.Create<int>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("sizes");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey64WithArrayOfObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey64(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey64WithArrayOfObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(object[]).UniqueKey64(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey64WithStringAndLong()
    {
        // Arrange
        var obj = _fixture.Create<string>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey64(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method throws when the obj parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallUniqueKey64WithStringAndLongWithInvalidObj(string value)
    {
        FluentActions.Invoking(() => value.UniqueKey64(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey64WithTypeAndLong()
    {
        // Arrange
        var obj = _fixture.Create<Type>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey64(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey64 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey64WithTypeAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(Type).UniqueKey64(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }
}