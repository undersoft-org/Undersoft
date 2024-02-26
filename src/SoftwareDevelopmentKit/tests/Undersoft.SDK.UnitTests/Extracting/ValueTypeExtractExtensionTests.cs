using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Extracting;

namespace Undersoft.SDK.UnitTests.Extracting;

/// <summary>
/// Unit tests for the type <see cref="ValueTypeExtractExtenstion"/>.
/// </summary>
public class ValueTypeExtractExtenstionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithInt()
    {
        // Arrange
        var hash = _fixture.Create<int>();

        // Act
        var result = hash.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithLong()
    {
        // Arrange
        var hash = _fixture.Create<long>();

        // Act
        var result = hash.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithUint()
    {
        // Arrange
        var hash = _fixture.Create<uint>();

        // Act
        var result = hash.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithUlong()
    {
        // Arrange
        var hash = _fixture.Create<ulong>();

        // Act
        var result = hash.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytesWithValueType()
    {
        // Arrange
        var objvalue = _fixture.Create<ValueType>();

        // Act
        var result = objvalue.GetBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method throws when the objvalue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetBytesWithValueTypeWithNullObjvalue()
    {
        FluentActions.Invoking(() => default(ValueType).GetBytes()).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
    }

    /// <summary>
    /// Checks that the GetPrimitiveBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPrimitiveBytes()
    {
        // Arrange
        var objvalue = _fixture.Create<object>();

        // Act
        var result = objvalue.GetPrimitiveBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetPrimitiveBytes method throws when the objvalue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetPrimitiveBytesWithNullObjvalue()
    {
        FluentActions.Invoking(() => default(object).GetPrimitiveBytes()).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
    }

    /// <summary>
    /// Checks that the GetPrimitiveLong method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPrimitiveLong()
    {
        // Arrange
        var objvalue = _fixture.Create<object>();

        // Act
        var result = objvalue.GetPrimitiveLong();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetPrimitiveLong method throws when the objvalue parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetPrimitiveLongWithNullObjvalue()
    {
        FluentActions.Invoking(() => default(object).GetPrimitiveLong()).Should().Throw<ArgumentNullException>().WithParameterName("objvalue");
    }

    /// <summary>
    /// Checks that the StructureFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureFromWithValueTypeAndByte*()
    {
        // Arrange
        var structure = _fixture.Create<ValueType>();
        var binary = _fixture.Create<byte*>();

        // Act
        structure.StructureFrom(binary);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureFrom method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureFromWithValueTypeAndByte*WithNullStructure()
    {
        FluentActions.Invoking(() => default(ValueType).StructureFrom(_fixture.Create<byte*>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureFromWithStructureAndBinaryAndOffset()
    {
        // Arrange
        var structure = _fixture.Create<ValueType>();
        var binary = _fixture.Create<byte[]>();
        var offset = _fixture.Create<long>();

        // Act
        structure.StructureFrom(binary, offset);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureFrom method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureFromWithStructureAndBinaryAndOffsetWithNullStructure()
    {
        FluentActions.Invoking(() => default(ValueType).StructureFrom(_fixture.Create<byte[]>(), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the StructureFrom method throws when the binary parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureFromWithStructureAndBinaryAndOffsetWithNullBinary()
    {
        FluentActions.Invoking(() => _fixture.Create<ValueType>().StructureFrom(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("binary");
    }

    /// <summary>
    /// Checks that the StructureFrom method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureFromWithValueTypeAndNint()
    {
        // Arrange
        var structure = _fixture.Create<ValueType>();
        var binary = _fixture.Create<nint>();

        // Act
        structure.StructureFrom(binary);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureFrom method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureFromWithValueTypeAndNintWithNullStructure()
    {
        FluentActions.Invoking(() => default(ValueType).StructureFrom(_fixture.Create<nint>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }
}