using System;
using System.Threading;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Stocks;

namespace Undersoft.SDK.UnitTests.Stocks;

/// <summary>
/// Unit tests for the type <see cref="SharedStock"/>.
/// </summary>
public class SharedStockTests
{
    private class TestSharedStock : SharedStock
    {
        public TestSharedStock(
            string path,
            string name,
            long elementSize,
            long length,
            bool ownsSharedMemory,
            bool fixsize
        ) : base(path, name, elementSize, length, ownsSharedMemory, fixsize
)
        {
        }

        public TestSharedStock(SectorOptions options) : base(options)
        {
        }

        public void PublicWrite(object data, long position, Type t, int timeout)
        {
            base.Write(data, position, t, timeout);
        }

        public void PublicWrite(object[] buffer, long position, Type t, int timeout)
        {
            base.Write(buffer, position, t, timeout);
        }

        public void PublicWrite(object[] buffer, int index, int count, long position, Type t, int timeout)
        {
            base.Write(buffer, index, count, position, t, timeout);
        }

        public void PublicWrite(nint ptr, long length, long position, Type t, int timeout)
        {
            base.Write(ptr, length, position, t, timeout);
        }

        public void PublicWrite(Action<nint> writeFunc, long position)
        {
            base.Write(writeFunc, position);
        }

        public object PublicRead(object data, long position, Type t, int timeout)
        {
            return base.Read(data, position, t, timeout);
        }

        public void PublicRead(object[] buffer, long position, Type t, int timeout)
        {
            base.Read(buffer, position, t, timeout);
        }

        public void PublicRead(object[] buffer, int index, int count, long position, Type t, int timeout)
        {
            base.Read(buffer, index, count, position, t, timeout);
        }

        public void PublicRead(nint destination, long length, long position, Type t, int timeout)
        {
            base.Read(destination, length, position, t, timeout);
        }

        public void PublicRead(Action<nint> readFunc, long bufferPosition)
        {
            base.Read(readFunc, bufferPosition);
        }

        public void PublicDispose(bool disposeManagedResources)
        {
            base.Dispose(disposeManagedResources);
        }

        public ManualResetEvent PublicWriteWaitEvent => base.WriteWaitEvent;

        public ManualResetEvent PublicReadWaitEvent => base.ReadWaitEvent;
    }

    private TestSharedStock _testClass;
    private IFixture _fixture;
    private string _path;
    private string _name;
    private long _elementSize;
    private long _length;
    private bool _ownsSharedMemory;
    private bool _fixsize;
    private SectorOptions _options;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SharedStock"/>.
    /// </summary>
    public SharedStockTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._path = _fixture.Create<string>();
        this._name = _fixture.Create<string>();
        this._elementSize = _fixture.Create<long>();
        this._length = _fixture.Create<long>();
        this._ownsSharedMemory = _fixture.Create<bool>();
        this._fixsize = _fixture.Create<bool>();
        this._options = _fixture.Create<SectorOptions>();
        this._testClass = _fixture.Create<TestSharedStock>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestSharedStock(this._path, this._name, this._elementSize, this._length, this._ownsSharedMemory, this._fixsize);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestSharedStock(this._options);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new TestSharedStock(default(SectorOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the constructor throws when the path parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidPath(string value)
    {
        FluentActions.Invoking(() => new TestSharedStock(value, this._name, this._elementSize, this._length, this._ownsSharedMemory, this._fixsize)).Should().Throw<ArgumentNullException>().WithParameterName("path");
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
        FluentActions.Invoking(() => new TestSharedStock(this._path, value, this._elementSize, this._length, this._ownsSharedMemory, this._fixsize)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the AcquireReadLock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAcquireReadLock()
    {
        // Arrange
        var millisecondsTimeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.AcquireReadLock(millisecondsTimeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReleaseReadLock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReleaseReadLock()
    {
        // Act
        this._testClass.ReleaseReadLock();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AcquireWriteLock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAcquireWriteLock()
    {
        // Arrange
        var millisecondsTimeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.AcquireWriteLock(millisecondsTimeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReleaseWriteLock method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReleaseWriteLock()
    {
        // Act
        this._testClass.ReleaseWriteLock();

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
        var data = _fixture.Create<object>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicWrite(data, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicWrite method throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithObjectAndLongAndTypeAndIntWithNullData()
    {
        FluentActions.Invoking(() => this._testClass.PublicWrite(default(object), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that the PublicWrite method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithArrayOfObjectAndLongAndTypeAndInt()
    {
        // Arrange
        var buffer = _fixture.Create<object[]>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicWrite(buffer, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicWrite method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithArrayOfObjectAndLongAndTypeAndIntWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.PublicWrite(default(object[]), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the PublicWrite method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithArrayOfObjectAndIntAndIntAndLongAndTypeAndInt()
    {
        // Arrange
        var buffer = _fixture.Create<object[]>();
        var index = _fixture.Create<int>();
        var count = _fixture.Create<int>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicWrite(buffer, index, count, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicWrite method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithArrayOfObjectAndIntAndIntAndLongAndTypeAndIntWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.PublicWrite(default(object[]), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the PublicWrite method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithPtrAndLengthAndPositionAndTAndTimeout()
    {
        // Arrange
        var ptr = _fixture.Create<nint>();
        var length = _fixture.Create<long>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicWrite(ptr, length, position, t, timeout);

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
    public void CanCallReadWithObjectAndLongAndTypeAndInt()
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
    public void CannotCallReadWithObjectAndLongAndTypeAndIntWithNullData()
    {
        FluentActions.Invoking(() => this._testClass.PublicRead(default(object), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that the PublicRead method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithArrayOfObjectAndLongAndTypeAndInt()
    {
        // Arrange
        var buffer = _fixture.Create<object[]>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicRead(buffer, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRead method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithArrayOfObjectAndLongAndTypeAndIntWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.PublicRead(default(object[]), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the PublicRead method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithArrayOfObjectAndIntAndIntAndLongAndTypeAndInt()
    {
        // Arrange
        var buffer = _fixture.Create<object[]>();
        var index = _fixture.Create<int>();
        var count = _fixture.Create<int>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.PublicRead(buffer, index, count, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRead method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithArrayOfObjectAndIntAndIntAndLongAndTypeAndIntWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.PublicRead(default(object[]), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the PublicRead method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithDestinationAndLengthAndPositionAndTAndTimeout()
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
    public void CanCallReadWithReadFuncAndBufferPosition()
    {
        // Arrange
        Action<nint> readFunc = x => { };
        var bufferPosition = _fixture.Create<long>();

        // Act
        this._testClass.PublicRead(readFunc, bufferPosition);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicRead method throws when the readFunc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithReadFuncAndBufferPositionWithNullReadFunc()
    {
        FluentActions.Invoking(() => this._testClass.PublicRead(default(Action<nint>), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("readFunc");
    }

    /// <summary>
    /// Checks that the PublicDispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDispose()
    {
        // Arrange
        var disposeManagedResources = _fixture.Create<bool>();

        // Act
        this._testClass.PublicDispose(disposeManagedResources);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicWriteWaitEvent property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicWriteWaitEvent()
    {
        // Assert
        this._testClass.PublicWriteWaitEvent.Should().BeAssignableTo<ManualResetEvent>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicReadWaitEvent property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicReadWaitEvent()
    {
        // Assert
        this._testClass.PublicReadWaitEvent.Should().BeAssignableTo<ManualResetEvent>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the ReadWriteTimeout property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetReadWriteTimeout()
    {
        this._testClass.CheckProperty(x => x.ReadWriteTimeout);
    }
}