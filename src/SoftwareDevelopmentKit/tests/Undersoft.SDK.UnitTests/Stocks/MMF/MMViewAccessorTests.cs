using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Stocks.MMF;
using Undersoft.SDK.Stocks.MMF.Handle;

namespace Undersoft.SDK.UnitTests.Stocks.MMF;

/// <summary>
/// Unit tests for the type <see cref="MMViewAccessor"/>.
/// </summary>
public class MMViewAccessorTests
{
    private MMViewAccessor _testClass;
    private IFixture _fixture;
    private MMView _memoryMappedView;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MMViewAccessor"/>.
    /// </summary>
    public MMViewAccessorTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._memoryMappedView = _fixture.Create<MMView>();
        this._testClass = _fixture.Create<MMViewAccessor>();
    }

    /// <summary>
    /// Checks that instance construction throws when the memoryMappedView parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMemoryMappedView()
    {
        FluentActions.Invoking(() => new MMViewAccessor(default(MMView))).Should().Throw<ArgumentNullException>().WithParameterName("memoryMappedView");
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
    /// Checks that the PtrToStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPtrToStructure()
    {
        // Arrange
        var ptr = _fixture.Create<byte*>();
        var structure = _fixture.Create<object>();

        // Act
        MMViewAccessor.PtrToStructure(ptr, structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PtrToStructure method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPtrToStructureWithNullStructure()
    {
        FluentActions.Invoking(() => MMViewAccessor.PtrToStructure(_fixture.Create<byte*>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the PtrToNewStructure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPtrToNewStructure()
    {
        // Arrange
        var ptr = _fixture.Create<byte*>();
        var t = _fixture.Create<Type>();

        // Act
        var result = MMViewAccessor.PtrToNewStructure(ptr, t);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PtrToNewStructure method throws when the t parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPtrToNewStructureWithNullT()
    {
        FluentActions.Invoking(() => MMViewAccessor.PtrToNewStructure(_fixture.Create<byte*>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("t");
    }

    /// <summary>
    /// Checks that the StructureToPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStructureToPtr()
    {
        // Arrange
        var structure = _fixture.Create<object>();
        var ptr = _fixture.Create<byte*>();

        // Act
        MMViewAccessor.StructureToPtr(structure, ptr);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StructureToPtr method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStructureToPtrWithNullStructure()
    {
        FluentActions.Invoking(() => MMViewAccessor.StructureToPtr(default(object), _fixture.Create<byte*>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWrite()
    {
        // Arrange
        var position = _fixture.Create<long>();
        var structure = _fixture.Create<object>();

        // Act
        this._testClass.Write(position, structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithNullStructure()
    {
        FluentActions.Invoking(() => this._testClass.Write(_fixture.Create<long>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the WriteArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteArray()
    {
        // Arrange
        var position = _fixture.Create<long>();
        var buffer = _fixture.Create<object[]>();
        var index = _fixture.Create<int>();
        var count = _fixture.Create<int>();

        // Act
        this._testClass.WriteArray(position, buffer, index, count);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the WriteArray method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteArrayWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.WriteArray(_fixture.Create<long>(), default(object[]), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRead()
    {
        // Arrange
        var position = _fixture.Create<long>();
        var structure = _fixture.Create<object>();
        var itemSize = _fixture.Create<int>();
        var t = _fixture.Create<Type>();

        // Act
        var result = this._testClass.Read(position, structure, itemSize, t);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithNullStructure()
    {
        FluentActions.Invoking(() => this._testClass.Read(_fixture.Create<long>(), default(object), _fixture.Create<int>(), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the Read method throws when the t parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithNullT()
    {
        FluentActions.Invoking(() => this._testClass.Read(_fixture.Create<long>(), _fixture.Create<object>(), _fixture.Create<int>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("t");
    }

    /// <summary>
    /// Checks that the ReadArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadArray()
    {
        // Arrange
        var position = _fixture.Create<long>();
        var buffer = _fixture.Create<object[]>();
        var index = _fixture.Create<int>();
        var count = _fixture.Create<int>();
        var itemSize = _fixture.Create<int>();
        var t = _fixture.Create<Type>();

        // Act
        this._testClass.ReadArray(position, buffer, index, count, itemSize, t
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReadArray method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadArrayWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.ReadArray(_fixture.Create<long>(), default(object[]), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the ReadArray method throws when the t parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadArrayWithNullT()
    {
        FluentActions.Invoking(() => this._testClass.ReadArray(_fixture.Create<long>(), _fixture.Create<object[]>(), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<int>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("t");
    }

    /// <summary>
    /// Checks that the SafeMemoryMappedViewHandle property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSafeMemoryMappedViewHandle()
    {
        // Assert
        this._testClass.SafeMemoryMappedViewHandle.Should().BeAssignableTo<SafeMMViewHandle>();

        Assert.Fail("Create or modify test");
    }
}