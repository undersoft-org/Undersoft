using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Stocks;

namespace Undersoft.SDK.UnitTests.Stocks;

/// <summary>
/// Unit tests for the type <see cref="StockContext"/>.
/// </summary>
public class StockContextTests
{
    private StockContext _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="StockContext"/>.
    /// </summary>
    public StockContextTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<StockContext>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new StockContext();

        // Assert
        instance.Should().NotBeNull();
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
    /// Checks that the ReadStock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadStock()
    {
        // Arrange
        var stock = _fixture.Create<ITableStock>();

        // Act
        var result = this._testClass.ReadStock(stock);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReadStock method throws when the stock parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadStockWithNullStock()
    {
        FluentActions.Invoking(() => this._testClass.ReadStock(default(ITableStock))).Should().Throw<ArgumentNullException>().WithParameterName("stock");
    }

    /// <summary>
    /// Checks that the ReadStockPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadStockPtr()
    {
        // Arrange
        var stock = _fixture.Create<ITableStock>();

        // Act
        var result = this._testClass.ReadStockPtr(stock);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReadStockPtr method throws when the stock parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadStockPtrWithNullStock()
    {
        FluentActions.Invoking(() => this._testClass.ReadStockPtr(default(ITableStock))).Should().Throw<ArgumentNullException>().WithParameterName("stock");
    }

    /// <summary>
    /// Checks that the ReceiveBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReceiveBytesWithArrayOfByteAndInt()
    {
        // Arrange
        var buffer = _fixture.Create<byte[]>();
        var received = _fixture.Create<int>();

        // Act
        var result = this._testClass.ReceiveBytes(buffer, received);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReceiveBytes method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReceiveBytesWithArrayOfByteAndIntWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.ReceiveBytes(default(byte[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the ReceiveBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReceiveBytesWithArrayOfByteAndLong()
    {
        // Arrange
        var buffer = _fixture.Create<byte[]>();
        var received = _fixture.Create<long>();

        // Act
        var result = this._testClass.ReceiveBytes(buffer, received);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReceiveBytes method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReceiveBytesWithArrayOfByteAndLongWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.ReceiveBytes(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the ReceiveBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReceiveBytesWithNintAndLong()
    {
        // Arrange
        var buffer = _fixture.Create<nint>();
        var received = _fixture.Create<long>();

        // Act
        this._testClass.ReceiveBytes(buffer, received);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the WriteStock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteStock()
    {
        // Arrange
        var stock = _fixture.Create<ITableStock>();

        // Act
        this._testClass.WriteStock(stock);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the WriteStock method throws when the stock parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteStockWithNullStock()
    {
        FluentActions.Invoking(() => this._testClass.WriteStock(default(ITableStock))).Should().Throw<ArgumentNullException>().WithParameterName("stock");
    }

    /// <summary>
    /// Checks that the WriteStockPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteStockPtr()
    {
        // Arrange
        var stock = _fixture.Create<ITableStock>();

        // Act
        this._testClass.WriteStockPtr(stock);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the WriteStockPtr method throws when the stock parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteStockPtrWithNullStock()
    {
        FluentActions.Invoking(() => this._testClass.WriteStockPtr(default(ITableStock))).Should().Throw<ArgumentNullException>().WithParameterName("stock");
    }

    /// <summary>
    /// Checks that setting the BlockOffset property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBlockOffset()
    {
        this._testClass.CheckProperty(x => x.BlockOffset);
    }

    /// <summary>
    /// Checks that setting the BlockSize property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBlockSize()
    {
        this._testClass.CheckProperty(x => x.BlockSize);
    }

    /// <summary>
    /// Checks that setting the BufferSize property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBufferSize()
    {
        this._testClass.CheckProperty(x => x.BufferSize);
    }

    /// <summary>
    /// Checks that setting the ClientCount property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClientCount()
    {
        this._testClass.CheckProperty(x => x.ClientCount);
    }

    /// <summary>
    /// Checks that the DeserialBlock property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetDeserialBlock()
    {
        // Assert
        this._testClass.DeserialBlock.Should().BeAssignableTo<byte[]>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the DeserialBlockId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDeserialBlockId()
    {
        this._testClass.CheckProperty(x => x.DeserialBlockId);
    }

    /// <summary>
    /// Checks that the DeserialBlockPtr property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetDeserialBlockPtr()
    {
        // Assert
        this._testClass.DeserialBlockPtr.As<object>().Should().BeAssignableTo<nint>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Elements property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetElements()
    {
        this._testClass.CheckProperty(x => x.Elements);
    }

    /// <summary>
    /// Checks that setting the File property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFile()
    {
        this._testClass.CheckProperty(x => x.File);
    }

    /// <summary>
    /// Checks that setting the FreeSize property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFreeSize()
    {
        this._testClass.CheckProperty(x => x.FreeSize);
    }

    /// <summary>
    /// Checks that setting the ItemCapacity property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetItemCapacity()
    {
        this._testClass.CheckProperty(x => x.ItemCapacity);
    }

    /// <summary>
    /// Checks that setting the ItemCount property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetItemCount()
    {
        this._testClass.CheckProperty(x => x.ItemCount);
    }

    /// <summary>
    /// Checks that setting the ItemSize property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetItemSize()
    {
        this._testClass.CheckProperty(x => x.ItemSize);
    }

    /// <summary>
    /// Checks that setting the NodeCount property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNodeCount()
    {
        this._testClass.CheckProperty(x => x.NodeCount);
    }

    /// <summary>
    /// Checks that setting the ObjectPosition property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetObjectPosition()
    {
        this._testClass.CheckProperty(x => x.ObjectPosition);
    }

    /// <summary>
    /// Checks that setting the ObjectsLeft property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetObjectsLeft()
    {
        this._testClass.CheckProperty(x => x.ObjectsLeft);
    }

    /// <summary>
    /// Checks that setting the Path property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPath()
    {
        this._testClass.CheckProperty(x => x.Path);
    }

    /// <summary>
    /// Checks that setting the SectorId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSectorId()
    {
        this._testClass.CheckProperty(x => x.SectorId, _fixture.Create<ushort>(), _fixture.Create<ushort>());
    }

    /// <summary>
    /// Checks that setting the SerialBlock property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSerialBlock()
    {
        this._testClass.CheckProperty(x => x.SerialBlock, _fixture.Create<byte[]>(), _fixture.Create<byte[]>());
    }

    /// <summary>
    /// Checks that setting the SerialBlockId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSerialBlockId()
    {
        this._testClass.CheckProperty(x => x.SerialBlockId);
    }

    /// <summary>
    /// Checks that the SerialBlockPtr property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSerialBlockPtr()
    {
        // Assert
        this._testClass.SerialBlockPtr.As<object>().Should().BeAssignableTo<nint>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the ServerCount property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetServerCount()
    {
        this._testClass.CheckProperty(x => x.ServerCount);
    }

    /// <summary>
    /// Checks that setting the StockId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetStockId()
    {
        this._testClass.CheckProperty(x => x.StockId, _fixture.Create<ushort>(), _fixture.Create<ushort>());
    }

    /// <summary>
    /// Checks that setting the UsedSize property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUsedSize()
    {
        this._testClass.CheckProperty(x => x.UsedSize);
    }
}