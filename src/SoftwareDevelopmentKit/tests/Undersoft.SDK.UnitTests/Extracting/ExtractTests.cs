using System;
using System.Collections;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Extracting;

namespace Undersoft.SDK.UnitTests.Extracting;

/// <summary>
/// Unit tests for the type <see cref="Extract"/>.
/// </summary>
public partial class ExtractTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the BlockEqual method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBlockEqualWithSourceAndSrcOffsetAndDestAndDestOffsetAndCount()
    {
        // Arrange
        var source = _fixture.Create<byte*>();
        var srcOffset = _fixture.Create<long>();
        var dest = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<long>();
        var count = _fixture.Create<long>();

        // Act
        var result = Extract.BlockEqual(source, srcOffset, dest, destOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

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
        var result = Extract.BlockEqual(source, dest);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BlockEqual method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBlockEqualWithSourceAndDestWithNullSource()
    {
        FluentActions.Invoking(() => Extract.BlockEqual(default(byte[]), _fixture.Create<byte[]>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the BlockEqual method throws when the dest parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBlockEqualWithSourceAndDestWithNullDest()
    {
        FluentActions.Invoking(() => Extract.BlockEqual(_fixture.Create<byte[]>(), default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("dest");
    }

    /// <summary>
    /// Checks that the BytesToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesToStructureWithArrayOfByteAndObjectAndLong()
    {
        // Arrange
        var binary = _fixture.Create<byte[]>();
        var structure = _fixture.Create<object>();
        var offset = _fixture.Create<long>();

        // Act
        var result = Extract.BytesToStructure(binary, structure, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BytesToStructure method throws when the binary parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesToStructureWithArrayOfByteAndObjectAndLongWithNullBinary()
    {
        FluentActions.Invoking(() => Extract.BytesToStructure(default(byte[]), _fixture.Create<object>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("binary");
    }

    /// <summary>
    /// Checks that the BytesToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesToStructureWithArrayOfByteAndObjectAndLongWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.BytesToStructure(_fixture.Create<byte[]>(), default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the BytesToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesToStructureWithArrayOfByteAndValueTypeAndLong()
    {
        // Arrange
        var binary = _fixture.Create<byte[]>();
        var structure = _fixture.Create<ValueType>();
        var offset = _fixture.Create<long>();

        // Act
        var result = Extract.BytesToStructure(binary, ref structure, offset
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BytesToStructure method throws when the binary parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesToStructureWithArrayOfByteAndValueTypeAndLongWithNullBinary()
    {
        var structure = _fixture.Create<ValueType>();
        FluentActions.Invoking(() => Extract.BytesToStructure(default(byte[]), ref structure, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("binary");
    }

    /// <summary>
    /// Checks that the BytesToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesToStructureWithArrayOfByteAndValueTypeAndLongWithNullStructure()
    {
        var structure = default(ValueType);
        FluentActions.Invoking(() => Extract.BytesToStructure(_fixture.Create<byte[]>(), ref structure, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the BytesToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesToStructureWithArrayOfByteAndTypeAndLong()
    {
        // Arrange
        var binary = _fixture.Create<byte[]>();
        var structure = _fixture.Create<Type>();
        var offset = _fixture.Create<long>();

        // Act
        var result = Extract.BytesToStructure(binary, structure, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BytesToStructure method throws when the binary parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesToStructureWithArrayOfByteAndTypeAndLongWithNullBinary()
    {
        FluentActions.Invoking(() => Extract.BytesToStructure(default(byte[]), _fixture.Create<Type>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("binary");
    }

    /// <summary>
    /// Checks that the BytesToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesToStructureWithArrayOfByteAndTypeAndLongWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.BytesToStructure(_fixture.Create<byte[]>(), default(Type), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the GetSize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSize()
    {
        // Arrange
        var structure = _fixture.Create<object>();

        // Act
        var result = Extract.GetSize(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSize method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetSizeWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.GetSize(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the GetSizes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSizesWithList()
    {
        // Arrange
        var list = _fixture.Create<IList>();

        // Act
        var result = Extract.GetSizes(list);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSizes method throws when the list parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetSizesWithListWithNullList()
    {
        FluentActions.Invoking(() => Extract.GetSizes(default(IList))).Should().Throw<ArgumentNullException>().WithParameterName("list");
    }

    /// <summary>
    /// Checks that the GetSizes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSizesWithObject()
    {
        // Arrange
        var structure = _fixture.Create<object>();

        // Act
        var result = Extract.GetSizes(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSizes method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetSizesWithObjectWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.GetSizes(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the GetSizes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSizesWithArray()
    {
        // Arrange
        var array = _fixture.Create<object[]>();

        // Act
        var result = Extract.GetSizes(array);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSizes method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetSizesWithArrayWithNullArray()
    {
        FluentActions.Invoking(() => Extract.GetSizes(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }

    /// <summary>
    /// Checks that the GetStructureBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetStructureBytesWithObject()
    {
        // Arrange
        var structure = _fixture.Create<object>();

        // Act
        var result = Extract.GetStructureBytes(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetStructureBytes method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetStructureBytesWithObjectWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.GetStructureBytes(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the GetStructureBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetStructureBytesWithValueType()
    {
        // Arrange
        var structure = _fixture.Create<ValueType>();

        // Act
        var result = Extract.GetStructureBytes(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetStructureBytes method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetStructureBytesWithValueTypeWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.GetStructureBytes(default(ValueType))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the GetStructureIntPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetStructureIntPtr()
    {
        // Arrange
        var structure = _fixture.Create<object>();

        // Act
        var result = Extract.GetStructureIntPtr(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetStructureIntPtr method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetStructureIntPtrWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.GetStructureIntPtr(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the GetStructurePointer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetStructurePointer()
    {
        // Arrange
        var structure = _fixture.Create<object>();

        // Act
        var result = Extract.GetStructurePointer(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetStructurePointer method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetStructurePointerWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.GetStructurePointer(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the PointerToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPointerToStructureWithByte*AndObject()
    {
        // Arrange
        var binary = _fixture.Create<byte*>();
        var structure = _fixture.Create<object>();

        // Act
        var result = Extract.PointerToStructure(binary, structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PointerToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPointerToStructureWithByte*AndObjectWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.PointerToStructure(_fixture.Create<byte*>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the PointerToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPointerToStructureWithByte*AndTypeAndLong()
    {
        // Arrange
        var binary = _fixture.Create<byte*>();
        var structure = _fixture.Create<Type>();
        var offset = _fixture.Create<long>();

        // Act
        var result = Extract.PointerToStructure(binary, structure, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PointerToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPointerToStructureWithByte*AndTypeAndLongWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.PointerToStructure(_fixture.Create<byte*>(), default(Type), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the PointerToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPointerToStructureWithByte*AndValueType()
    {
        // Arrange
        var binary = _fixture.Create<byte*>();
        var structure = _fixture.Create<ValueType>();

        // Act
        var result = Extract.PointerToStructure(binary, structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PointerToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPointerToStructureWithByte*AndValueTypeWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.PointerToStructure(_fixture.Create<byte*>(), default(ValueType))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the PointerToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPointerToStructureWithNintAndObject()
    {
        // Arrange
        var binary = _fixture.Create<nint>();
        var structure = _fixture.Create<object>();

        // Act
        var result = Extract.PointerToStructure(binary, structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PointerToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPointerToStructureWithNintAndObjectWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.PointerToStructure(_fixture.Create<nint>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the PointerToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPointerToStructureWithNintAndTypeAndInt()
    {
        // Arrange
        var binary = _fixture.Create<nint>();
        var structure = _fixture.Create<Type>();
        var offset = _fixture.Create<int>();

        // Act
        var result = Extract.PointerToStructure(binary, structure, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PointerToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPointerToStructureWithNintAndTypeAndIntWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.PointerToStructure(_fixture.Create<nint>(), default(Type), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the PointerToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPointerToStructureWithNintAndValueType()
    {
        // Arrange
        var binary = _fixture.Create<nint>();
        var structure = _fixture.Create<ValueType>();

        // Act
        var result = Extract.PointerToStructure(binary, structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PointerToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPointerToStructureWithNintAndValueTypeWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.PointerToStructure(_fixture.Create<nint>(), default(ValueType))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureToBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureToBytesWithObjectAndArrayOfByteAndLong()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var binary = _fixture.Create<byte[]>();
        var offset = _fixture.Create<long>();

        // Act
        Extract.StructureToBytes(structure, ref binary, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureToBytes method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureToBytesWithObjectAndArrayOfByteAndLongWithNullStructure()
    {
        var binary = _fixture.Create<byte[]>();
        FluentActions.Invoking(() => Extract.StructureToBytes(default(object), ref binary, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureToBytes method throws when the binary parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureToBytesWithObjectAndArrayOfByteAndLongWithNullBinary()
    {
        var binary = default(byte[]);
        FluentActions.Invoking(() => Extract.StructureToBytes(_fixture.Create<object>(), ref binary, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("binary");
    }

    /// <summary>
    /// Checks that the StructureToBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureToBytesWithValueTypeAndArrayOfByteAndLong()
    {
        // Arrange
        var structure = _fixture.Create<ValueType>();
        var binary = _fixture.Create<byte[]>();
        var offset = _fixture.Create<long>();

        // Act
        Extract.StructureToBytes(structure, ref binary, offset
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureToBytes method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureToBytesWithValueTypeAndArrayOfByteAndLongWithNullStructure()
    {
        var binary = _fixture.Create<byte[]>();
        FluentActions.Invoking(() => Extract.StructureToBytes(default(ValueType), ref binary, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureToBytes method throws when the binary parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureToBytesWithValueTypeAndArrayOfByteAndLongWithNullBinary()
    {
        var binary = default(byte[]);
        FluentActions.Invoking(() => Extract.StructureToBytes(_fixture.Create<ValueType>(), ref binary, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("binary");
    }

    /// <summary>
    /// Checks that the StructureToPointer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureToPointerWithObjectAndByte*()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var binary = _fixture.Create<byte*>();

        // Act
        Extract.StructureToPointer(structure, binary);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureToPointer method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureToPointerWithObjectAndByte*WithNullStructure()
    {
        FluentActions.Invoking(() => Extract.StructureToPointer(default(object), _fixture.Create<byte*>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureToPointer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureToPointerWithObjectAndNint()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var binary = _fixture.Create<nint>();

        // Act
        Extract.StructureToPointer(structure, binary);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureToPointer method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureToPointerWithObjectAndNintWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.StructureToPointer(default(object), _fixture.Create<nint>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the ValueStructureToPointer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueStructureToPointerWithValueTypeAndByte*()
    {
        // Arrange
        var structure = _fixture.Create<ValueType>();
        var binary = _fixture.Create<byte*>();

        // Act
        Extract.ValueStructureToPointer(structure, binary);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueStructureToPointer method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueStructureToPointerWithValueTypeAndByte*WithNullStructure()
    {
        FluentActions.Invoking(() => Extract.ValueStructureToPointer(default(ValueType), _fixture.Create<byte*>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the ValueStructureToPointer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueStructureToPointerWithObjectAndNint()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var binary = _fixture.Create<nint>();

        // Act
        Extract.ValueStructureToPointer(structure, binary);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueStructureToPointer method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueStructureToPointerWithObjectAndNintWithNullStructure()
    {
        FluentActions.Invoking(() => Extract.ValueStructureToPointer(default(object), _fixture.Create<nint>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the Perform property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPerform()
    {
        // Assert
        Extract.Perform.Should().BeAssignableTo<IExtract>();

        Assert.Fail("Create or modify test");
    }
}