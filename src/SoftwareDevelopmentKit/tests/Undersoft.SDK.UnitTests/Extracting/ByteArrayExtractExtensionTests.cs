using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Extracting;

namespace Undersoft.SDK.UnitTests.Extracting;

/// <summary>
/// Unit tests for the type <see cref="ByteArrayExtractExtenstion"/>.
/// </summary>
public class ByteArrayExtractExtenstionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the BlockEqual method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBlockEqualWithSourceAndDest()
    {
        // Arrange
        var source = _fixture.Create<byte[]>();
        var dest = _fixture.Create<byte[]>();

        // Act
        var result = source.BlockEqual(dest);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BlockEqual method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBlockEqualWithSourceAndDestWithNullSource()
    {
        FluentActions.Invoking(() => default(byte[]).BlockEqual(_fixture.Create<byte[]>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the BlockEqual method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBlockEqualWithSourceAndDestWithNullDest()
    {
        FluentActions.Invoking(() => _fixture.Create<byte[]>().BlockEqual(default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the BlockEqual method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBlockEqualWithSourceAndSrcOffsetAndDestAndDestOffsetAndCount()
    {
        // Arrange
        var source = _fixture.Create<nint>();
        var srcOffset = _fixture.Create<long>();
        var dest = _fixture.Create<nint>();
        var destOffset = _fixture.Create<long>();
        var count = _fixture.Create<long>();

        // Act
        var result = source.BlockEqual(srcOffset, dest, destOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndArrayOfByteAndUint()
    {
        // Arrange
        var src = _fixture.Create<byte[]>();
        var dest = _fixture.Create<byte[]>();
        var count = _fixture.Create<uint>();

        // Act
        src.CopyBlock(dest, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUintWithNullSrc()
    {
        FluentActions.Invoking(() => default(byte[]).CopyBlock(_fixture.Create<byte[]>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUintWithNullDest()
    {
        FluentActions.Invoking(() => _fixture.Create<byte[]>().CopyBlock(default(byte[]), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndArrayOfByteAndUintAndUint()
    {
        // Arrange
        var src = _fixture.Create<byte[]>();
        var dest = _fixture.Create<byte[]>();
        var offset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        src.CopyBlock(dest, offset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUintAndUintWithNullSrc()
    {
        FluentActions.Invoking(() => default(byte[]).CopyBlock(_fixture.Create<byte[]>(), _fixture.Create<uint>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUintAndUintWithNullDest()
    {
        FluentActions.Invoking(() => _fixture.Create<byte[]>().CopyBlock(default(byte[]), _fixture.Create<uint>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndArrayOfByteAndUlong()
    {
        // Arrange
        var src = _fixture.Create<byte[]>();
        var dest = _fixture.Create<byte[]>();
        var count = _fixture.Create<ulong>();

        // Act
        src.CopyBlock(dest, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUlongWithNullSrc()
    {
        FluentActions.Invoking(() => default(byte[]).CopyBlock(_fixture.Create<byte[]>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUlongWithNullDest()
    {
        FluentActions.Invoking(() => _fixture.Create<byte[]>().CopyBlock(default(byte[]), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndArrayOfByteAndUlongAndUlong()
    {
        // Arrange
        var src = _fixture.Create<byte[]>();
        var dest = _fixture.Create<byte[]>();
        var offset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        src.CopyBlock(dest, offset, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUlongAndUlongWithNullSrc()
    {
        FluentActions.Invoking(() => default(byte[]).CopyBlock(_fixture.Create<byte[]>(), _fixture.Create<ulong>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndArrayOfByteAndUlongAndUlongWithNullDest()
    {
        FluentActions.Invoking(() => _fixture.Create<byte[]>().CopyBlock(default(byte[]), _fixture.Create<ulong>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the ToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToStructureWithArrayOfByteAndTypeAndLong()
    {
        // Arrange
        var binary = _fixture.Create<byte[]>();
        var structure = _fixture.Create<Type>();
        var offset = _fixture.Create<long>();

        // Act
        var result = binary.ToStructure(structure, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToStructure method throws when the binary parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToStructureWithArrayOfByteAndTypeAndLongWithNullBinary()
    {
        FluentActions.Invoking(() => default(byte[]).ToStructure(_fixture.Create<Type>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("binary");
    }

    /// <summary>
    /// Checks that the ToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToStructureWithArrayOfByteAndTypeAndLongWithNullStructure()
    {
        FluentActions.Invoking(() => _fixture.Create<byte[]>().ToStructure(default(Type), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the ToInt32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToInt32()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var offset = _fixture.Create<int>();

        // Act
        var result = bytes.ToInt32(offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToInt32 method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToInt32WithNullBytes()
    {
        FluentActions.Invoking(() => default(byte[]).ToInt32(_fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the ToInt64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToInt64()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var offset = _fixture.Create<int>();

        // Act
        var result = bytes.ToInt64(offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToInt64 method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToInt64WithNullBytes()
    {
        FluentActions.Invoking(() => default(byte[]).ToInt64(_fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the ToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToStructureWithArrayOfByteAndObjectAndLong()
    {
        // Arrange
        var binary = _fixture.Create<byte[]>();
        var structure = _fixture.Create<object>();
        var offset = _fixture.Create<long>();

        // Act
        var result = binary.ToStructure(structure, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToStructure method throws when the binary parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToStructureWithArrayOfByteAndObjectAndLongWithNullBinary()
    {
        FluentActions.Invoking(() => default(byte[]).ToStructure(_fixture.Create<object>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("binary");
    }

    /// <summary>
    /// Checks that the ToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToStructureWithArrayOfByteAndObjectAndLongWithNullStructure()
    {
        FluentActions.Invoking(() => _fixture.Create<byte[]>().ToStructure(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the ToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToStructureWithArrayOfByteAndValueTypeAndLong()
    {
        // Arrange
        var binary = _fixture.Create<byte[]>();
        var structure = _fixture.Create<ValueType>();
        var offset = _fixture.Create<long>();

        // Act
        var result = binary.ToStructure(structure, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToStructure method throws when the binary parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToStructureWithArrayOfByteAndValueTypeAndLongWithNullBinary()
    {
        FluentActions.Invoking(() => default(byte[]).ToStructure(_fixture.Create<ValueType>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("binary");
    }

    /// <summary>
    /// Checks that the ToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToStructureWithArrayOfByteAndValueTypeAndLongWithNullStructure()
    {
        FluentActions.Invoking(() => _fixture.Create<byte[]>().ToStructure(default(ValueType), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the ToUInt32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToUInt32()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var offset = _fixture.Create<int>();

        // Act
        var result = bytes.ToUInt32(offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToUInt32 method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToUInt32WithNullBytes()
    {
        FluentActions.Invoking(() => default(byte[]).ToUInt32(_fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the ToUInt64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToUInt64()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var offset = _fixture.Create<int>();

        // Act
        var result = bytes.ToUInt64(offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToUInt64 method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToUInt64WithNullBytes()
    {
        FluentActions.Invoking(() => default(byte[]).ToUInt64(_fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }
}