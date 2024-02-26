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
/// Unit tests for the type <see cref="UniqueKey32Extensions"/>.
/// </summary>
public class UniqueKey32ExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the BitAggregate32to16 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBitAggregate32to16()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();

        // Act
        var result = bytes.BitAggregate32to16();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BitAggregate32to16 method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBitAggregate32to16WithNullBytes()
    {
        FluentActions.Invoking(() => default(byte[]).BitAggregate32to16()).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the BitAggregate64to16 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBitAggregate64to16()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();

        // Act
        var result = bytes.BitAggregate64to16();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BitAggregate64to16 method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBitAggregate64to16WithNullBytes()
    {
        FluentActions.Invoking(() => default(byte[]).BitAggregate64to16()).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the BitAggregate64to32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBitAggregate64to32WithByte*()
    {
        // Arrange
        var bytes = _fixture.Create<byte*>();

        // Act
        var result = UniqueKey32Extensions.BitAggregate64to32(bytes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BitAggregate64to32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBitAggregate64to32WithArrayOfByte()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();

        // Act
        var result = bytes.BitAggregate64to32();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BitAggregate64to32 method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBitAggregate64to32WithArrayOfByteWithNullBytes()
    {
        FluentActions.Invoking(() => default(byte[]).BitAggregate64to32()).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
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
    public void CanCallGetHashCodeWithIEquatableOfTAndLong()
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
    public void CannotCallGetHashCodeWithIEquatableOfTAndLongWithNullObj()
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
    public void CanCallGetHashCodeWithIIdentifiableAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();
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
    public void CannotCallGetHashCodeWithIIdentifiableAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IIdentifiable).GetHashCode(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetHashCode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHashCodeWithIUniqueAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IUnique>();
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
    public void CannotCallGetHashCodeWithIUniqueAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IUnique).GetHashCode(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
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
    /// Checks that the UniqueBytes32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes32WithBytesAndSeed()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = bytes.UniqueBytes32(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes32WithBytesAndSeedWithNullBytes()
    {
        FluentActions.Invoking(() => default(byte[]).UniqueBytes32(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes32WithIListAndArrayOfIntAndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var sizes = _fixture.Create<int[]>();
        var totalsize = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueBytes32(sizes, totalsize, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes32WithIListAndArrayOfIntAndIntAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IList).UniqueBytes32(_fixture.Create<int[]>(), _fixture.Create<int>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method throws when the sizes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes32WithIListAndArrayOfIntAndIntAndLongWithNullSizes()
    {
        FluentActions.Invoking(() => _fixture.Create<IList>().UniqueBytes32(default(int[]), _fixture.Create<int>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("sizes");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes32WithIListAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueBytes32(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes32WithIListAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IList).UniqueBytes32(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes32WithNintAndIntAndLong()
    {
        // Arrange
        var ptr = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = ptr.UniqueBytes32(length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes32WithIIdentifiable()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();

        // Act
        var result = obj.UniqueBytes32();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes32WithIIdentifiableWithNullObj()
    {
        FluentActions.Invoking(() => default(IIdentifiable).UniqueBytes32()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes32WithObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueBytes32(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes32WithObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(object).UniqueBytes32(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes32WithArrayOfObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueBytes32(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes32WithArrayOfObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(object[]).UniqueBytes32(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes32WithStringAndLong()
    {
        // Arrange
        var obj = _fixture.Create<string>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueBytes32(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method throws when the obj parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallUniqueBytes32WithStringAndLongWithInvalidObj(string value)
    {
        FluentActions.Invoking(() => value.UniqueBytes32(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueBytes32WithTypeAndLong()
    {
        // Arrange
        var obj = _fixture.Create<Type>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueBytes32(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueBytes32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueBytes32WithTypeAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(Type).UniqueBytes32(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey32WithArrayOfByteAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey32(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey32WithArrayOfByteAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(byte[]).UniqueKey32(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey32WithIListAndArrayOfIntAndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var sizes = _fixture.Create<int[]>();
        var totalsize = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey32(sizes, totalsize, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey32WithIListAndArrayOfIntAndIntAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IList).UniqueKey32(_fixture.Create<int[]>(), _fixture.Create<int>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method throws when the sizes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey32WithIListAndArrayOfIntAndIntAndLongWithNullSizes()
    {
        FluentActions.Invoking(() => _fixture.Create<IList>().UniqueKey32(default(int[]), _fixture.Create<int>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("sizes");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey32WithIListAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey32(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey32WithIListAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IList).UniqueKey32(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey32WithNintAndIntAndLong()
    {
        // Arrange
        var ptr = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = ptr.UniqueKey32(length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey32WithIIdentifiable()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();

        // Act
        var result = obj.UniqueKey32();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey32WithIIdentifiableWithNullObj()
    {
        FluentActions.Invoking(() => default(IIdentifiable).UniqueKey32()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey32WithIIdentifiableAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey32(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey32WithIIdentifiableAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(IIdentifiable).UniqueKey32(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey32WithObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey32(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey32WithObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(object).UniqueKey32(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey32WithArrayOfObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey32(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey32WithArrayOfObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(object[]).UniqueKey32(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey32WithStringAndLong()
    {
        // Arrange
        var obj = _fixture.Create<string>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey32(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method throws when the obj parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallUniqueKey32WithStringAndLongWithInvalidObj(string value)
    {
        FluentActions.Invoking(() => value.UniqueKey32(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallUniqueKey32WithTypeAndLong()
    {
        // Arrange
        var obj = _fixture.Create<Type>();
        var seed = _fixture.Create<long>();

        // Act
        var result = obj.UniqueKey32(seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UniqueKey32 method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallUniqueKey32WithTypeAndLongWithNullObj()
    {
        FluentActions.Invoking(() => default(Type).UniqueKey32(_fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }
}