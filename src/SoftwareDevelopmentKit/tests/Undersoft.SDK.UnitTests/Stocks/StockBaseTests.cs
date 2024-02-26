using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Stocks;

namespace Undersoft.SDK.UnitTests.Stocks;

/// <summary>
/// Unit tests for the type <see cref="StockBase"/>.
/// </summary>
public class StockBaseTests
{
    private class TestStockBase : StockBase
    {
        public TestStockBase(
            string file,
            string name,
            long elementSize,
            long length,
            bool ownsSharedMemory,
            bool fixSize = false,
            Type itemType = null
        ) : base(file, name, elementSize, length, ownsSharedMemory, fixSize, itemType)
        {
        }

        public TestStockBase(SectorOptions options) : base(options)
        {
        }

        public bool PublicDoOpen()
        {
            return base.DoOpen();
        }

        public void PublicCreateView()
        {
            base.CreateView();
        }

        public void PublicDoClose()
        {
            base.DoClose();
        }

        public void PublicWrite(object source, long position, Type @type, int timeout)
        {
            base.Write(source, position, type, timeout);
        }

        public void PublicWrite(object[] source, long position, Type @type, int timeout)
        {
            base.Write(source, position, type, timeout);
        }

        public void PublicWrite(object[] source, int index, int count, long position, Type @type, int timeout)
        {
            base.Write(source, index, count, position, type, timeout);
        }

        public void PublicWrite(nint source, long length, long position, Type t, int timeout)
        {
            base.Write(source, length, position, t, timeout);
        }

        public void PublicWrite(byte* source, long length, long position, Type t, int timeout)
        {
            base.Write(source, length, position, t, timeout);
        }

        public void PublicWrite(Action<nint> writeFunc, long position)
        {
            base.Write(writeFunc, position);
        }

        public object PublicRead(object data, long position, Type t, int timeout)
        {
            return base.Read(data, position, t, timeout);
        }

        public void PublicRead(object[] destination, long position, Type t, int timeout)
        {
            base.Read(destination, position, t, timeout);
        }

        public void PublicRead(object[] destination, int index, int count, long position, Type t, int timeout)
        {
            base.Read(destination, index, count, position, t, timeout);
        }

        public void PublicRead(nint destination, long length, long position, Type t, int timeout)
        {
            base.Read(destination, length, position, t, timeout);
        }

        public void PublicRead(byte* destination, long length, long position, Type t, int timeout)
        {
            base.Read(destination, length, position, t, timeout);
        }

        public void PublicRead(Action<nint> readFunc, long position)
        {
            base.Read(readFunc, position);
        }

        public void PublicDispose(bool disposeManagedResources)
        {
            base.Dispose(disposeManagedResources);
        }

        public long PublicHeaderOffset => base.HeaderOffset;

        public long PublicBufferOffset => base.BufferOffset;
    }

    private TestStockBase _testClass;
    private IFixture _fixture;
    private string _file;
    private string _name;
    private long _elementSize;
    private long _length;
    private bool _ownsSharedMemory;
    private bool _fixSize;
    private Type _itemType;
    private SectorOptions _options;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="StockBase"/>.
    /// </summary>
    public StockBaseTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._file = _fixture.Create<string>();
        this._name = _fixture.Create<string>();
        this._elementSize = _fixture.Create<long>();
        this._length = _fixture.Create<long>();
        this._ownsSharedMemory = _fixture.Create<bool>();
        this._fixSize = _fixture.Create<bool>();
        this._itemType = _fixture.Create<Type>();
        this._options = _fixture.Create<SectorOptions>();
        this._testClass = _fixture.Create<TestStockBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestStockBase(this._file, this._name, this._elementSize, this._length, this._ownsSharedMemory, this._fixSize, this._itemType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestStockBase(this._options);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new TestStockBase(default(SectorOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the constructor throws when the file parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidFile(string value)
    {
        FluentActions.Invoking(() => new TestStockBase(value, this._name, this._elementSize, this._length, this._ownsSharedMemory, this._fixSize, this._itemType)).Should().Throw<ArgumentNullException>().WithParameterName("file");
    }

    /// <summary>
    /// Checks that the constructor throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidName(string value)
    {
        FluentActions.Invoking(() => new TestStockBase(this._file, value, this._elementSize, this._length, this._ownsSharedMemory, this._fixSize, this._itemType)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the Open method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOpen()
    {
        // Act
        this._testClass.Open();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDoOpen method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDoOpen()
    {
        // Act
        var result = this._testClass.PublicDoOpen();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetStockPtr method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetStockPtr()
    {
        // Act
        var result = this._testClass.GetStockPtr();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicCreateView method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateView()
    {
        // Act
        this._testClass.PublicCreateView();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PreReadHeader method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPreReadHeader()
    {
        // Act
        this._testClass.PreReadHeader();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReadHeader method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadHeader()
    {
        // Act
        this._testClass.ReadHeader();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the InitHeader method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInitHeader()
    {
        // Act
        this._testClass.InitHeader();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the WriteHeader method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteHeader()
    {
        // Act
        this._testClass.WriteHeader();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Close method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClose()
    {
        // Act
        this._testClass.Close();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDoClose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDoClose()
    {
        // Act
        this._testClass.PublicDoClose();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicWrite method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithObjectAndLongAndTypeAndInt()
    {
        // Arrange
        var source = _fixture.Create<object>();
        var position = _fixture.Create<long>();
        var @type = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicWrite(source, position, type, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicWrite method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithObjectAndLongAndTypeAndIntWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.PublicWrite(default(object), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the PublicWrite method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithArrayOfObjectAndLongAndTypeAndInt()
    {
        // Arrange
        var source = _fixture.Create<object[]>();
        var position = _fixture.Create<long>();
        var @type = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicWrite(source, position, type, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicWrite method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithArrayOfObjectAndLongAndTypeAndIntWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.PublicWrite(default(object[]), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the PublicWrite method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithSourceAndIndexAndCountAndPositionAndTypeAndTimeout()
    {
        // Arrange
        var source = _fixture.Create<object[]>();
        var index = _fixture.Create<int>();
        var count = _fixture.Create<int>();
        var position = _fixture.Create<long>();
        var @type = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicWrite(source, index, count, position, type, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicWrite method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithSourceAndIndexAndCountAndPositionAndTypeAndTimeoutWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.PublicWrite(default(object[]), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the PublicWrite method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithNintAndLongAndLongAndTypeAndInt()
    {
        // Arrange
        var source = _fixture.Create<nint>();
        var length = _fixture.Create<long>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicWrite(source, length, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicWrite method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithByte*AndLongAndLongAndTypeAndInt()
    {
        // Arrange
        var source = _fixture.Create<byte*>();
        var length = _fixture.Create<long>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicWrite(source, length, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicWrite method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithWriteFuncAndPosition()
    {
        // Arrange
        Action<nint> writeFunc = x => { };
        var position = _fixture.Create<long>();

        // Act
        this._testClass.PublicWrite(writeFunc, position);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicWrite method throws when the writeFunc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithWriteFuncAndPositionWithNullWriteFunc()
    {
        FluentActions.Invoking(() => this._testClass.PublicWrite(default(Action<nint>), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("writeFunc");
    }

    /// <summary>
    /// Checks that the PublicRead method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithDataAndPositionAndTAndTimeout()
    {
        // Arrange
        var data = _fixture.Create<object>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.PublicRead(data, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRead method throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithDataAndPositionAndTAndTimeoutWithNullData()
    {
        FluentActions.Invoking(() => this._testClass.PublicRead(default(object), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that the PublicRead method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithDestinationAndPositionAndTAndTimeout()
    {
        // Arrange
        var destination = _fixture.Create<object[]>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicRead(destination, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRead method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithDestinationAndPositionAndTAndTimeoutWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.PublicRead(default(object[]), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the PublicRead method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithDestinationAndIndexAndCountAndPositionAndTAndTimeout()
    {
        // Arrange
        var destination = _fixture.Create<object[]>();
        var index = _fixture.Create<int>();
        var count = _fixture.Create<int>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicRead(destination, index, count, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRead method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithDestinationAndIndexAndCountAndPositionAndTAndTimeoutWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.PublicRead(default(object[]), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the PublicRead method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithNintAndLongAndLongAndTypeAndInt()
    {
        // Arrange
        var destination = _fixture.Create<nint>();
        var length = _fixture.Create<long>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicRead(destination, length, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRead method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithByte*AndLongAndLongAndTypeAndInt()
    {
        // Arrange
        var destination = _fixture.Create<byte*>();
        var length = _fixture.Create<long>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicRead(destination, length, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRead method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithReadFuncAndPosition()
    {
        // Arrange
        Action<nint> readFunc = x => { };
        var position = _fixture.Create<long>();

        // Act
        this._testClass.PublicRead(readFunc, position);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRead method throws when the readFunc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithReadFuncAndPositionWithNullReadFunc()
    {
        FluentActions.Invoking(() => this._testClass.PublicRead(default(Action<nint>), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("readFunc");
    }

    /// <summary>
    /// Checks that the Dispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDisposeWithNoParameters()
    {
        // Act
        this._testClass.Dispose();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicDispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDisposeWithDisposeManagedResources()
    {
        // Arrange
        var disposeManagedResources = _fixture.Create<bool>();

        // Act
        this._testClass.PublicDispose(disposeManagedResources);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Exists property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetExists()
    {
        this._testClass.CheckProperty(x => x.Exists);
    }

    /// <summary>
    /// Checks that setting the FixSize property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFixSize()
    {
        this._testClass.CheckProperty(x => x.FixSize);
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
    /// Checks that setting the ClusterId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClusterId()
    {
        this._testClass.CheckProperty(x => x.ClusterId, _fixture.Create<ushort>(), _fixture.Create<ushort>());
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
    /// Checks that setting the BufferSize property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBufferSize()
    {
        this._testClass.CheckProperty(x => x.BufferSize);
    }

    /// <summary>
    /// Checks that setting the UsedSize property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetUsedSize()
    {
        this._testClass.CheckProperty(x => x.UsedSize);
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
    /// Checks that setting the ItemSize property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetItemSize()
    {
        this._testClass.CheckProperty(x => x.ItemSize);
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
    /// Checks that setting the ItemCapacity property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetItemCapacity()
    {
        this._testClass.CheckProperty(x => x.ItemCapacity);
    }

    /// <summary>
    /// Checks that the SharedMemorySize property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSharedMemorySize()
    {
        // Assert
        this._testClass.SharedMemorySize.As<object>().Should().BeAssignableTo<long>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the UsedMemorySize property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetUsedMemorySize()
    {
        // Assert
        this._testClass.UsedMemorySize.As<object>().Should().BeAssignableTo<long>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FreeMemorySize property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetFreeMemorySize()
    {
        // Assert
        this._testClass.FreeMemorySize.As<object>().Should().BeAssignableTo<long>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicHeaderOffset property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicHeaderOffset()
    {
        // Assert
        this._testClass.PublicHeaderOffset.As<object>().Should().BeAssignableTo<long>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicBufferOffset property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicBufferOffset()
    {
        // Assert
        this._testClass.PublicBufferOffset.As<object>().Should().BeAssignableTo<long>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsOwnerOfSharedMemory property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIsOwnerOfSharedMemory()
    {
        // Assert
        this._testClass.IsOwnerOfSharedMemory.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ShuttingDown property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetShuttingDown()
    {
        // Assert
        this._testClass.ShuttingDown.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }
}