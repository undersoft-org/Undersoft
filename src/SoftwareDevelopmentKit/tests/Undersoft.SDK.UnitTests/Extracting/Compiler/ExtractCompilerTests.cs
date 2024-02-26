using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Extracting.Compiler;

namespace Undersoft.SDK.UnitTests.Extracting.Compiler;

/// <summary>
/// Unit tests for the type <see cref="ExtractCompiler"/>.
/// </summary>
public partial class ExtractCompilerTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the BytesToValueStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesToValueStructureWithArrayAndStructureAndOffset()
    {
        // Arrange
        var array = _fixture.Create<byte[]>();
        var structure = _fixture.Create<ValueType>();
        var offset = _fixture.Create<ulong>();

        // Act
        var result = ExtractCompiler.BytesToValueStructure(array, structure, offset
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BytesToValueStructure method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesToValueStructureWithArrayAndStructureAndOffsetWithNullArray()
    {
        FluentActions.Invoking(() => ExtractCompiler.BytesToValueStructure(default(byte[]), _fixture.Create<ValueType>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the BytesToValueStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesToValueStructureWithArrayAndStructureAndOffsetWithNullStructure()
    {
        FluentActions.Invoking(() => ExtractCompiler.BytesToValueStructure(_fixture.Create<byte[]>(), default(ValueType), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the BytesToValueStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesToValueStructureWithArrayOfByteAndObjectAndUlong()
    {
        // Arrange
        var ptr = _fixture.Create<byte[]>();
        var structure = _fixture.Create<object>();
        var offset = _fixture.Create<ulong>();

        // Act
        var result = ExtractCompiler.BytesToValueStructure(ptr, structure, offset
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BytesToValueStructure method throws when the ptr parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesToValueStructureWithArrayOfByteAndObjectAndUlongWithNullPtr()
    {
        FluentActions.Invoking(() => ExtractCompiler.BytesToValueStructure(default(byte[]), _fixture.Create<object>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("ptr");
    }

    /// <summary>
    /// Checks that the BytesToValueStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesToValueStructureWithArrayOfByteAndObjectAndUlongWithNullStructure()
    {
        FluentActions.Invoking(() => ExtractCompiler.BytesToValueStructure(_fixture.Create<byte[]>(), default(object), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithByte*AndUintAndByte*AndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<uint>();
        var src = _fixture.Create<byte*>();
        var srcOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        ExtractCompiler.CopyBlock(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithByte*AndUlongAndByte*AndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<ulong>();
        var src = _fixture.Create<byte*>();
        var srcOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        ExtractCompiler.CopyBlock(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndUintAndArrayOfByteAndUintAndUint()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<uint>();
        var src = _fixture.Create<byte[]>();
        var srcOffset = _fixture.Create<uint>();
        var count = _fixture.Create<uint>();

        // Act
        ExtractCompiler.CopyBlock(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndUintAndArrayOfByteAndUintAndUintWithNullDest()
    {
        FluentActions.Invoking(() => ExtractCompiler.CopyBlock(default(byte[]), _fixture.Create<uint>(), _fixture.Create<byte[]>(), _fixture.Create<uint>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndUintAndArrayOfByteAndUintAndUintWithNullSrc()
    {
        FluentActions.Invoking(() => ExtractCompiler.CopyBlock(_fixture.Create<byte[]>(), _fixture.Create<uint>(), default(byte[]), _fixture.Create<uint>(), _fixture.Create<uint>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the CopyBlock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyBlockWithArrayOfByteAndUlongAndArrayOfByteAndUlongAndUlong()
    {
        // Arrange
        var dest = _fixture.Create<byte[]>();
        var destOffset = _fixture.Create<ulong>();
        var src = _fixture.Create<byte[]>();
        var srcOffset = _fixture.Create<ulong>();
        var count = _fixture.Create<ulong>();

        // Act
        ExtractCompiler.CopyBlock(dest, destOffset, src, srcOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndUlongAndArrayOfByteAndUlongAndUlongWithNullDest()
    {
        FluentActions.Invoking(() => ExtractCompiler.CopyBlock(default(byte[]), _fixture.Create<ulong>(), _fixture.Create<byte[]>(), _fixture.Create<ulong>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the CopyBlock method throws when the src parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyBlockWithArrayOfByteAndUlongAndArrayOfByteAndUlongAndUlongWithNullSrc()
    {
        FluentActions.Invoking(() => ExtractCompiler.CopyBlock(_fixture.Create<byte[]>(), _fixture.Create<ulong>(), default(byte[]), _fixture.Create<ulong>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("src");
    }

    /// <summary>
    /// Checks that the GetExtractor method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetExtractor()
    {
        // Act
        var result = ExtractCompiler.GetExtractor();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PointerToValueStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPointerToValueStructureWithByte*AndObjectAndUlong()
    {
        // Arrange
        var ptr = _fixture.Create<byte*>();
        var structure = _fixture.Create<object>();
        var offset = _fixture.Create<ulong>();

        // Act
        var result = ExtractCompiler.PointerToValueStructure(ptr, structure, offset
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PointerToValueStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPointerToValueStructureWithByte*AndObjectAndUlongWithNullStructure()
    {
        FluentActions.Invoking(() => ExtractCompiler.PointerToValueStructure(_fixture.Create<byte*>(), default(object), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the PointerToValueStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPointerToValueStructureWithByte*AndValueTypeAndUlong()
    {
        // Arrange
        var ptr = _fixture.Create<byte*>();
        var structure = _fixture.Create<ValueType>();
        var offset = _fixture.Create<ulong>();

        // Act
        var result = ExtractCompiler.PointerToValueStructure(ptr, structure, offset
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PointerToValueStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPointerToValueStructureWithByte*AndValueTypeAndUlongWithNullStructure()
    {
        FluentActions.Invoking(() => ExtractCompiler.PointerToValueStructure(_fixture.Create<byte*>(), default(ValueType), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the PointerToValueStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPointerToValueStructureWithNintAndObjectAndUlong()
    {
        // Arrange
        var ptr = _fixture.Create<nint>();
        var structure = _fixture.Create<object>();
        var offset = _fixture.Create<ulong>();

        // Act
        var result = ExtractCompiler.PointerToValueStructure(ptr, structure, offset
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PointerToValueStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPointerToValueStructureWithNintAndObjectAndUlongWithNullStructure()
    {
        FluentActions.Invoking(() => ExtractCompiler.PointerToValueStructure(_fixture.Create<nint>(), default(object), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the PointerToValueStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPointerToValueStructureWithNintAndValueTypeAndUlong()
    {
        // Arrange
        var ptr = _fixture.Create<nint>();
        var structure = _fixture.Create<ValueType>();
        var offset = _fixture.Create<ulong>();

        // Act
        var result = ExtractCompiler.PointerToValueStructure(ptr, structure, offset
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PointerToValueStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPointerToValueStructureWithNintAndValueTypeAndUlongWithNullStructure()
    {
        FluentActions.Invoking(() => ExtractCompiler.PointerToValueStructure(_fixture.Create<nint>(), default(ValueType), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the ValueStructureToBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueStructureToBytesWithObject()
    {
        // Arrange
        var structure = _fixture.Create<object>();

        // Act
        var result = ExtractCompiler.ValueStructureToBytes(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueStructureToBytes method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueStructureToBytesWithObjectWithNullStructure()
    {
        FluentActions.Invoking(() => ExtractCompiler.ValueStructureToBytes(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the ValueStructureToBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueStructureToBytesWithObjectAndArrayOfByteAndUlong()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var ptr = _fixture.Create<byte[]>();
        var offset = _fixture.Create<ulong>();

        // Act
        ExtractCompiler.ValueStructureToBytes(structure, ref ptr, offset
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueStructureToBytes method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueStructureToBytesWithObjectAndArrayOfByteAndUlongWithNullStructure()
    {
        var ptr = _fixture.Create<byte[]>();
        FluentActions.Invoking(() => ExtractCompiler.ValueStructureToBytes(default(object), ref ptr, _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the ValueStructureToBytes method throws when the ptr parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueStructureToBytesWithObjectAndArrayOfByteAndUlongWithNullPtr()
    {
        var ptr = default(byte[]);
        FluentActions.Invoking(() => ExtractCompiler.ValueStructureToBytes(_fixture.Create<object>(), ref ptr, _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("ptr");
    }

    /// <summary>
    /// Checks that the ValueStructureToBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueStructureToBytesWithValueType()
    {
        // Arrange
        var structure = _fixture.Create<ValueType>();

        // Act
        var result = ExtractCompiler.ValueStructureToBytes(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueStructureToBytes method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueStructureToBytesWithValueTypeWithNullStructure()
    {
        FluentActions.Invoking(() => ExtractCompiler.ValueStructureToBytes(default(ValueType))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the ValueStructureToIntPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueStructureToIntPtr()
    {
        // Arrange
        var structure = _fixture.Create<object>();

        // Act
        var result = ExtractCompiler.ValueStructureToIntPtr(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueStructureToIntPtr method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueStructureToIntPtrWithNullStructure()
    {
        FluentActions.Invoking(() => ExtractCompiler.ValueStructureToIntPtr(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the ValueStructureToPointer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueStructureToPointerWithObject()
    {
        // Arrange
        var structure = _fixture.Create<object>();

        // Act
        var result = ExtractCompiler.ValueStructureToPointer(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueStructureToPointer method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueStructureToPointerWithObjectWithNullStructure()
    {
        FluentActions.Invoking(() => ExtractCompiler.ValueStructureToPointer(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the ValueStructureToPointer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueStructureToPointerWithObjectAndByte*AndUlong()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var ptr = _fixture.Create<byte*>();
        var offset = _fixture.Create<ulong>();

        // Act
        ExtractCompiler.ValueStructureToPointer(structure, ptr, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueStructureToPointer method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueStructureToPointerWithObjectAndByte*AndUlongWithNullStructure()
    {
        FluentActions.Invoking(() => ExtractCompiler.ValueStructureToPointer(default(object), _fixture.Create<byte*>(), _fixture.Create<ulong>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }
}