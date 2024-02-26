using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Stocks;

namespace Undersoft.SDK.UnitTests.Stocks;

/// <summary>
/// Unit tests for the type <see cref="TableStockHandle"/>.
/// </summary>
public class TableStockHandleTests
{
    private TableStockHandle _testClass;
    private IFixture _fixture;
    private Type _t;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TableStockHandle"/>.
    /// </summary>
    public TableStockHandleTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._t = _fixture.Create<Type>();
        this._testClass = _fixture.Create<TableStockHandle>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TableStockHandle(this._t);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the t parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullT()
    {
        FluentActions.Invoking(() => new TableStockHandle(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("t");
    }

    /// <summary>
    /// Checks that the GetPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPtr()
    {
        // Arrange
        var structure = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.GetPtr(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetPtr method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetPtrWithNullStructure()
    {
        FluentActions.Invoking(() => this._testClass.GetPtr(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the PtrToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPtrToStructureWithPointer()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();

        // Act
        var result = this._testClass.PtrToStructure(pointer);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PtrToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPtrToStructureWithPointerAndStructure()
    {
        // Arrange
        var pointer = _fixture.Create<nint>();
        var structure = _fixture.Create<object>();

        // Act
        this._testClass.PtrToStructure(pointer, structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PtrToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPtrToStructureWithPointerAndStructureWithNullStructure()
    {
        FluentActions.Invoking(() => this._testClass.PtrToStructure(_fixture.Create<nint>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the ReadArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadArrayWithArrayOfObjectAndByte*AndIntAndInt()
    {
        // Arrange
        var buffer = _fixture.Create<object[]>();
        var source = _fixture.Create<byte*>();
        var index = _fixture.Create<int>();
        var count = _fixture.Create<int>();

        // Act
        this._testClass.ReadArray(ref buffer, source, index, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReadArray method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadArrayWithArrayOfObjectAndByte*AndIntAndIntWithNullBuffer()
    {
        var buffer = default(object[]);
        FluentActions.Invoking(() => this._testClass.ReadArray(ref buffer, _fixture.Create<byte*>(), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the ReadArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadArrayWithBufferAndDestIndexAndSourceAndIndexAndCount()
    {
        // Arrange
        var buffer = _fixture.Create<object[]>();
        var destIndex = _fixture.Create<int>();
        var source = _fixture.Create<byte*>();
        var index = _fixture.Create<int>();
        var count = _fixture.Create<int>();

        // Act
        this._testClass.ReadArray(ref buffer, destIndex, source, index, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReadArray method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadArrayWithBufferAndDestIndexAndSourceAndIndexAndCountWithNullBuffer()
    {
        var buffer = default(object[]);
        FluentActions.Invoking(() => this._testClass.ReadArray(ref buffer, _fixture.Create<int>(), _fixture.Create<byte*>(), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the ReadArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadArrayWithArrayOfObjectAndNintAndIntAndInt()
    {
        // Arrange
        var buffer = _fixture.Create<object[]>();
        var source = _fixture.Create<nint>();
        var index = _fixture.Create<int>();
        var count = _fixture.Create<int>();

        // Act
        this._testClass.ReadArray(ref buffer, source, index, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReadArray method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadArrayWithArrayOfObjectAndNintAndIntAndIntWithNullBuffer()
    {
        var buffer = default(object[]);
        FluentActions.Invoking(() => this._testClass.ReadArray(ref buffer, _fixture.Create<nint>(), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the SizeOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSizeOf()
    {
        // Arrange
        var t = _fixture.Create<object>();

        // Act
        var result = this._testClass.SizeOf(t);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SizeOf method throws when the t parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSizeOfWithNullT()
    {
        FluentActions.Invoking(() => this._testClass.SizeOf(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("t");
    }

    /// <summary>
    /// Checks that the StructureToPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureToPtr()
    {
        // Arrange
        var s = _fixture.Create<object>();
        var pointer = _fixture.Create<nint>();

        // Act
        this._testClass.StructureToPtr(s, pointer);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureToPtr method throws when the s parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureToPtrWithNullS()
    {
        FluentActions.Invoking(() => this._testClass.StructureToPtr(default(object), _fixture.Create<nint>())).Should().Throw<ArgumentNullException>().WithParameterName("s");
    }

    /// <summary>
    /// Checks that the WriteArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteArrayWithDestinationAndSrcIndexAndBufferAndIndexAndCount()
    {
        // Arrange
        var destination = _fixture.Create<byte*>();
        var srcIndex = _fixture.Create<int>();
        var buffer = _fixture.Create<object[]>();
        var index = _fixture.Create<int>();
        var count = _fixture.Create<int>();

        // Act
        this._testClass.WriteArray(destination, srcIndex, ref buffer, index, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the WriteArray method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteArrayWithDestinationAndSrcIndexAndBufferAndIndexAndCountWithNullBuffer()
    {
        var buffer = default(object[]);
        FluentActions.Invoking(() => this._testClass.WriteArray(_fixture.Create<byte*>(), _fixture.Create<int>(), ref buffer, _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the WriteArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteArrayWithByte*AndArrayOfObjectAndIntAndInt()
    {
        // Arrange
        var destination = _fixture.Create<byte*>();
        var buffer = _fixture.Create<object[]>();
        var index = _fixture.Create<int>();
        var count = _fixture.Create<int>();

        // Act
        this._testClass.WriteArray(destination, ref buffer, index, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the WriteArray method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteArrayWithByte*AndArrayOfObjectAndIntAndIntWithNullBuffer()
    {
        var buffer = default(object[]);
        FluentActions.Invoking(() => this._testClass.WriteArray(_fixture.Create<byte*>(), ref buffer, _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the WriteArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteArrayWithNintAndArrayOfObjectAndIntAndInt()
    {
        // Arrange
        var destination = _fixture.Create<nint>();
        var buffer = _fixture.Create<object[]>();
        var index = _fixture.Create<int>();
        var count = _fixture.Create<int>();

        // Act
        this._testClass.WriteArray(destination, ref buffer, index, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the WriteArray method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteArrayWithNintAndArrayOfObjectAndIntAndIntWithNullBuffer()
    {
        var buffer = default(object[]);
        FluentActions.Invoking(() => this._testClass.WriteArray(_fixture.Create<nint>(), ref buffer, _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }
}