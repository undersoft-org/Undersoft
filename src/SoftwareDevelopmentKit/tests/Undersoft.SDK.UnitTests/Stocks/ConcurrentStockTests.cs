using System;
using System.Threading;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Stocks;

namespace Undersoft.SDK.UnitTests.Stocks;

/// <summary>
/// Unit tests for the type <see cref="ConcurrentStock"/>.
/// </summary>
public class ConcurrentStockTests
{
    private class TestConcurrentStock : ConcurrentStock
    {
        public TestConcurrentStock(string file, string name, int nodeCount, long nodeBufferSize) : base(file, name, nodeCount, nodeBufferSize)
        {
        }

        public TestConcurrentStock(string file, string name) : base(file, name)
        {
        }

        public bool PublicDoOpen()
        {
            return base.DoOpen();
        }

        public void PublicDoClose()
        {
            base.DoClose();
        }

        public ConcurrentStock.Node* PublicGetNodeForWriting(int timeout)
        {
            return base.GetNodeForWriting(timeout);
        }

        public void PublicPostNode(ConcurrentStock.Node* node)
        {
            base.PostNode(node);
        }

        public ConcurrentStock.Node* PublicGetNodeForReading(int timeout)
        {
            return base.GetNodeForReading(timeout);
        }

        public void PublicReturnNode(ConcurrentStock.Node* node)
        {
            base.ReturnNode(node);
        }

        public EventWaitHandle PublicDataExists { get => base.DataExists; set => base.DataExists = value; }
        public EventWaitHandle PublicNodeAvailable { get => base.NodeAvailable; set => base.NodeAvailable = value; }

        public long PublicNodeHeaderOffset => base.NodeHeaderOffset;

        public long PublicNodeOffset => base.NodeOffset;

        public long PublicNodeBufferOffset => base.NodeBufferOffset;
    }

    private TestConcurrentStock _testClass;
    private IFixture _fixture;
    private string _file;
    private string _name;
    private int _nodeCount;
    private long _nodeBufferSize;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ConcurrentStock"/>.
    /// </summary>
    public ConcurrentStockTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._file = _fixture.Create<string>();
        this._name = _fixture.Create<string>();
        this._nodeCount = _fixture.Create<int>();
        this._nodeBufferSize = _fixture.Create<long>();
        this._testClass = _fixture.Create<TestConcurrentStock>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestConcurrentStock(this._file, this._name, this._nodeCount, this._nodeBufferSize);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestConcurrentStock(this._file, this._name);

        // Assert
        instance.Should().NotBeNull();
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
        FluentActions.Invoking(() => new TestConcurrentStock(value, this._name, this._nodeCount, this._nodeBufferSize)).Should().Throw<ArgumentNullException>().WithParameterName("file");
        FluentActions.Invoking(() => new TestConcurrentStock(value, this._name)).Should().Throw<ArgumentNullException>().WithParameterName("file");
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
        FluentActions.Invoking(() => new TestConcurrentStock(this._file, value, this._nodeCount, this._nodeBufferSize)).Should().Throw<ArgumentNullException>().WithParameterName("name");
        FluentActions.Invoking(() => new TestConcurrentStock(this._file, value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the CheckArchive method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCheckArchive()
    {
        // Arrange
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.CheckArchive(timeout);

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
    /// Checks that the PublicGetNodeForWriting method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetNodeForWriting()
    {
        // Arrange
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.PublicGetNodeForWriting(timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicPostNode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPostNode()
    {
        // Arrange
        var node = _fixture.Create<ConcurrentStock.Node*>();

        // Act
        this._testClass.PublicPostNode(node);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithSourceAndStartIndexAndTimeout()
    {
        // Arrange
        var source = _fixture.Create<byte[]>();
        var startIndex = _fixture.Create<int>();
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.Write(source, startIndex, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithSourceAndStartIndexAndTimeoutWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.Write(default(byte[]), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithObjectAndIntAndTypeAndInt()
    {
        // Arrange
        var source = _fixture.Create<object>();
        var startIndex = _fixture.Create<int>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.Write(source, startIndex, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithObjectAndIntAndTypeAndIntWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.Write(default(object), _fixture.Create<int>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithArrayOfObjectAndIntAndTypeAndInt()
    {
        // Arrange
        var source = _fixture.Create<object[]>();
        var startIndex = _fixture.Create<int>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.Write(source, startIndex, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithArrayOfObjectAndIntAndTypeAndIntWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.Write(default(object[]), _fixture.Create<int>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithSourceAndLengthAndTAndTimeout()
    {
        // Arrange
        var source = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.Write(source, length, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithWriteFuncAndTimeout()
    {
        // Arrange
        Func<nint, int> writeFunc = x => _fixture.Create<int>();
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.Write(writeFunc, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method throws when the writeFunc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithWriteFuncAndTimeoutWithNullWriteFunc()
    {
        FluentActions.Invoking(() => this._testClass.Write(default(Func<nint, int>), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("writeFunc");
    }

    /// <summary>
    /// Checks that the ReadNodeHeader method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadNodeHeader()
    {
        // Act
        var result = this._testClass.ReadNodeHeader();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicGetNodeForReading method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetNodeForReading()
    {
        // Arrange
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.PublicGetNodeForReading(timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicReturnNode method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReturnNode()
    {
        // Arrange
        var node = _fixture.Create<ConcurrentStock.Node*>();

        // Act
        this._testClass.PublicReturnNode(node);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithArrayOfByteAndIntAndTypeAndInt()
    {
        // Arrange
        var destination = _fixture.Create<byte[]>();
        var startIndex = _fixture.Create<int>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.Read(destination, startIndex, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithArrayOfByteAndIntAndTypeAndIntWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.Read(default(byte[]), _fixture.Create<int>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithObjectAndIntAndTypeAndInt()
    {
        // Arrange
        var destination = _fixture.Create<object>();
        var startIndex = _fixture.Create<int>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.Read(destination, startIndex, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithObjectAndIntAndTypeAndIntWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.Read(default(object), _fixture.Create<int>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithArrayOfObjectAndIntAndTypeAndInt()
    {
        // Arrange
        var destination = _fixture.Create<object[]>();
        var startIndex = _fixture.Create<int>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.Read(destination, startIndex, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithArrayOfObjectAndIntAndTypeAndIntWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.Read(default(object[]), _fixture.Create<int>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithDestinationAndLengthAndTAndTimeout()
    {
        // Arrange
        var destination = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.Read(destination, length, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithReadFuncAndTimeout()
    {
        // Arrange
        Func<nint, int> readFunc = x => _fixture.Create<int>();
        var timeout = _fixture.Create<int>();

        // Act
        var result = this._testClass.Read(readFunc, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method throws when the readFunc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithReadFuncAndTimeoutWithNullReadFunc()
    {
        FluentActions.Invoking(() => this._testClass.Read(default(Func<nint, int>), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("readFunc");
    }

    /// <summary>
    /// Checks that the GetDefault method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDefault()
    {
        // Arrange
        var t = _fixture.Create<Type>();

        // Act
        var result = TestConcurrentStock.GetDefault(t);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDefault method throws when the t parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetDefaultWithNullT()
    {
        FluentActions.Invoking(() => TestConcurrentStock.GetDefault(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("t");
    }

    /// <summary>
    /// Checks that setting the PublicDataExists property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPublicDataExists()
    {
        this._testClass.CheckProperty(x => x.PublicDataExists, _fixture.Create<EventWaitHandle>(), _fixture.Create<EventWaitHandle>());
    }

    /// <summary>
    /// Checks that setting the PublicNodeAvailable property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPublicNodeAvailable()
    {
        this._testClass.CheckProperty(x => x.PublicNodeAvailable, _fixture.Create<EventWaitHandle>(), _fixture.Create<EventWaitHandle>());
    }

    /// <summary>
    /// Checks that the PublicNodeHeaderOffset property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicNodeHeaderOffset()
    {
        // Assert
        this._testClass.PublicNodeHeaderOffset.As<object>().Should().BeAssignableTo<long>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicNodeOffset property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicNodeOffset()
    {
        // Assert
        this._testClass.PublicNodeOffset.As<object>().Should().BeAssignableTo<long>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicNodeBufferOffset property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicNodeBufferOffset()
    {
        // Assert
        this._testClass.PublicNodeBufferOffset.As<object>().Should().BeAssignableTo<long>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexer()
    {
        this._testClass[_fixture.Create<int>()].As<object>().Should().BeAssignableTo<ConcurrentStock.Node*>();
        Assert.Fail("Create or modify test");
    }
}