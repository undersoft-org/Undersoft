using System;
using System.Collections;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Extracting;

namespace Undersoft.SDK.UnitTests.Extracting;

/// <summary>
/// Unit tests for the type <see cref="ObjectExtractExtenstion"/>.
/// </summary>
public class ObjectExtractExtenstionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the CompareBlocks method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareBlocks()
    {
        // Arrange
        var source = _fixture.Create<byte*>();
        var srcOffset = _fixture.Create<long>();
        var dest = _fixture.Create<byte*>();
        var destOffset = _fixture.Create<long>();
        var count = _fixture.Create<long>();

        // Act
        var result = ObjectExtractExtenstion.CompareBlocks(source, srcOffset, dest, destOffset, count
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithObjAndForKeys()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var forKeys = _fixture.Create<bool>();

        // Act
        var result = obj.GetBytes(forKeys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetBytesWithObjAndForKeysWithNullObj()
    {
        FluentActions.Invoking(() => default(IList).GetBytes(_fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithObjvalueAndBufferAndLengthAndForKeys()
    {
        // Arrange
        var objvalue = _fixture.Create<IList>();
        var buffer = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var forKeys = _fixture.Create<bool>();

        // Act
        var result = objvalue.GetBytes(ref buffer, length, forKeys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method throws when the objvalue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetBytesWithObjvalueAndBufferAndLengthAndForKeysWithNullObjvalue()
    {
        var buffer = _fixture.Create<byte*>();
        FluentActions.Invoking(() => default(IList).GetBytes(ref buffer, _fixture.Create<int>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithArrayOfInt()
    {
        // Arrange
        var objvalue = _fixture.Create<int[]>();

        // Act
        var result = objvalue.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method throws when the objvalue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetBytesWithArrayOfIntWithNullObjvalue()
    {
        FluentActions.Invoking(() => default(int[]).GetBytes()).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithArrayOfLong()
    {
        // Arrange
        var objvalue = _fixture.Create<long[]>();

        // Act
        var result = objvalue.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method throws when the objvalue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetBytesWithArrayOfLongWithNullObjvalue()
    {
        FluentActions.Invoking(() => default(long[]).GetBytes()).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithObjvalueAndForKeys()
    {
        // Arrange
        var objvalue = _fixture.Create<object>();
        var forKeys = _fixture.Create<bool>();

        // Act
        var result = objvalue.GetBytes(forKeys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method throws when the objvalue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetBytesWithObjvalueAndForKeysWithNullObjvalue()
    {
        FluentActions.Invoking(() => default(object).GetBytes(_fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
    }

    /// <summary>
    /// Checks that the GetTrackingAddress method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetTrackingAddress()
    {
        // Arrange
        var objvalue = _fixture.Create<object>();

        // Act
        var result = objvalue.GetTrackingAddress();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetTrackingAddress method throws when the objvalue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetTrackingAddressWithNullObjvalue()
    {
        FluentActions.Invoking(() => default(object).GetTrackingAddress()).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
    }

    /// <summary>
    /// Checks that the GetTrackingTarget method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetTrackingTarget()
    {
        // Arrange
        var ptr = _fixture.Create<nint>();

        // Act
        var result = ptr.GetTrackingTarget();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FreeTrackingAddress method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFreeTrackingAddress()
    {
        // Arrange
        var ptr = _fixture.Create<nint>();

        // Act
        ptr.FreeTrackingAddress();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithString()
    {
        // Arrange
        var objvalue = _fixture.Create<string>();

        // Act
        var result = objvalue.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method throws when the objvalue parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetBytesWithStringWithInvalidObjvalue(string value)
    {
        FluentActions.Invoking(() => value.GetBytes()).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithArrayOfUint()
    {
        // Arrange
        var objvalue = _fixture.Create<uint[]>();

        // Act
        var result = objvalue.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method throws when the objvalue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetBytesWithArrayOfUintWithNullObjvalue()
    {
        FluentActions.Invoking(() => default(uint[]).GetBytes()).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithArrayOfUlong()
    {
        // Arrange
        var objvalue = _fixture.Create<ulong[]>();

        // Act
        var result = objvalue.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method throws when the objvalue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetBytesWithArrayOfUlongWithNullObjvalue()
    {
        FluentActions.Invoking(() => default(ulong[]).GetBytes()).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
    }

    /// <summary>
    /// Checks that the GetSequentialBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSequentialBytes()
    {
        // Arrange
        var objvalue = _fixture.Create<object>();

        // Act
        var result = objvalue.GetSequentialBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSequentialBytes method throws when the objvalue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetSequentialBytesWithNullObjvalue()
    {
        FluentActions.Invoking(() => default(object).GetSequentialBytes()).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
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
        var result = structure.GetSize();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSize method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetSizeWithNullStructure()
    {
        FluentActions.Invoking(() => default(object).GetSize()).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the GetSizes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSizes()
    {
        // Arrange
        var structure = _fixture.Create<object>();

        // Act
        var result = structure.GetSizes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSizes method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetSizesWithNullStructure()
    {
        FluentActions.Invoking(() => default(object).GetSizes()).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the GetStructureBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetStructureBytes()
    {
        // Arrange
        var structure = _fixture.Create<object>();

        // Act
        var result = structure.GetStructureBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetStructureBytes method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetStructureBytesWithNullStructure()
    {
        FluentActions.Invoking(() => default(object).GetStructureBytes()).Should().Throw<ArgumentNullException>().WithParameterName("structure");
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
        var result = structure.GetStructureIntPtr();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetStructureIntPtr method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetStructureIntPtrWithNullStructure()
    {
        FluentActions.Invoking(() => default(object).GetStructureIntPtr()).Should().Throw<ArgumentNullException>().WithParameterName("structure");
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
        var result = structure.GetStructurePointer();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetStructurePointer method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetStructurePointerWithNullStructure()
    {
        FluentActions.Invoking(() => default(object).GetStructurePointer()).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the GetValueStructureBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetValueStructureBytes()
    {
        // Arrange
        var structure = _fixture.Create<object>();

        // Act
        var result = structure.GetValueStructureBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetValueStructureBytes method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetValueStructureBytesWithNullStructure()
    {
        FluentActions.Invoking(() => default(object).GetValueStructureBytes()).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureEqual method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureEqual()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var other = _fixture.Create<object>();

        // Act
        var result = structure.StructureEqual(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureEqual method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureEqualWithNullStructure()
    {
        FluentActions.Invoking(() => default(object).StructureEqual(_fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureEqual method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureEqualWithNullOther()
    {
        FluentActions.Invoking(() => _fixture.Create<object>().StructureEqual(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the StructureFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureFromWithObjectAndByte*()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var binary = _fixture.Create<byte*>();

        // Act
        var result = structure.StructureFrom(binary);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureFrom method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureFromWithObjectAndByte*WithNullStructure()
    {
        FluentActions.Invoking(() => default(object).StructureFrom(_fixture.Create<byte*>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureFromWithObjectAndArrayOfByteAndLong()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var binary = _fixture.Create<byte[]>();
        var offset = _fixture.Create<long>();

        // Act
        var result = structure.StructureFrom(binary, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureFrom method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureFromWithObjectAndArrayOfByteAndLongWithNullStructure()
    {
        FluentActions.Invoking(() => default(object).StructureFrom(_fixture.Create<byte[]>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureFrom method throws when the binary parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureFromWithObjectAndArrayOfByteAndLongWithNullBinary()
    {
        FluentActions.Invoking(() => _fixture.Create<object>().StructureFrom(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("binary");
    }

    /// <summary>
    /// Checks that the StructureFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureFromWithObjectAndNint()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var binary = _fixture.Create<nint>();

        // Act
        var result = structure.StructureFrom(binary);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureFrom method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureFromWithObjectAndNintWithNullStructure()
    {
        FluentActions.Invoking(() => default(object).StructureFrom(_fixture.Create<nint>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureToWithObjectAndByte*()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var binary = _fixture.Create<byte*>();

        // Act
        structure.StructureTo(binary);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureTo method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureToWithObjectAndByte*WithNullStructure()
    {
        FluentActions.Invoking(() => default(object).StructureTo(_fixture.Create<byte*>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureToWithObjectAndNint()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var binary = _fixture.Create<nint>();

        // Act
        structure.StructureTo(binary);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureTo method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureToWithObjectAndNintWithNullStructure()
    {
        FluentActions.Invoking(() => default(object).StructureTo(_fixture.Create<nint>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureToWithObjectAndArrayOfByteAndLong()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var binary = _fixture.Create<byte[]>();
        var offset = _fixture.Create<long>();

        // Act
        structure.StructureTo(ref binary, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureTo method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureToWithObjectAndArrayOfByteAndLongWithNullStructure()
    {
        var binary = _fixture.Create<byte[]>();
        FluentActions.Invoking(() => default(object).StructureTo(ref binary, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureTo method throws when the binary parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureToWithObjectAndArrayOfByteAndLongWithNullBinary()
    {
        var binary = default(byte[]);
        FluentActions.Invoking(() => _fixture.Create<object>().StructureTo(ref binary, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("binary");
    }

    /// <summary>
    /// Checks that the TryGetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetBytesWithIListAndArrayOfByteAndBool()
    {
        // Arrange
        var objvalue = _fixture.Create<IList>();
        var forKeys = _fixture.Create<bool>();

        // Act
        var result = objvalue.TryGetBytes(out var bytes, forKeys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGetBytes method throws when the objvalue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryGetBytesWithIListAndArrayOfByteAndBoolWithNullObjvalue()
    {
        FluentActions.Invoking(() => default(IList).TryGetBytes(out _, _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
    }

    /// <summary>
    /// Checks that the TryGetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryGetBytesWithObjectAndArrayOfByteAndBool()
    {
        // Arrange
        var objvalue = _fixture.Create<object>();
        var forKeys = _fixture.Create<bool>();

        // Act
        var result = objvalue.TryGetBytes(out var bytes, forKeys);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryGetBytes method throws when the objvalue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryGetBytesWithObjectAndArrayOfByteAndBoolWithNullObjvalue()
    {
        FluentActions.Invoking(() => default(object).TryGetBytes(out _, _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
    }
}