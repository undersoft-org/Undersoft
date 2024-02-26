using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Stocks;

namespace Undersoft.SDK.UnitTests.Stocks;

/// <summary>
/// Unit tests for the type <see cref="FileStock"/>.
/// </summary>
public class FileStockTests
{
    private FileStock _testClass;
    private IFixture _fixture;
    private string _file;
    private string _name;
    private int _bufferSize;
    private Type __type;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="FileStock"/>.
    /// </summary>
    public FileStockTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._file = _fixture.Create<string>();
        this._name = _fixture.Create<string>();
        this._bufferSize = _fixture.Create<int>();
        this.__type = _fixture.Create<Type>();
        this._testClass = _fixture.Create<FileStock>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new FileStock(this._file, this._name, this._bufferSize, this.__type);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new FileStock(this._file, this._name, this.__type);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the _type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNull_type()
    {
        FluentActions.Invoking(() => new FileStock(this._file, this._name, this._bufferSize, default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("_type");
        FluentActions.Invoking(() => new FileStock(this._file, this._name, default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("_type");
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
        FluentActions.Invoking(() => new FileStock(value, this._name, this._bufferSize, this.__type)).Should().Throw<ArgumentNullException>().WithParameterName("file");
        FluentActions.Invoking(() => new FileStock(value, this._name, this.__type)).Should().Throw<ArgumentNullException>().WithParameterName("file");
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
        FluentActions.Invoking(() => new FileStock(this._file, value, this._bufferSize, this.__type)).Should().Throw<ArgumentNullException>().WithParameterName("name");
        FluentActions.Invoking(() => new FileStock(this._file, value, this.__type)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the Rewrite method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRewrite()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var structure = _fixture.Create<object>();

        // Act
        this._testClass.Rewrite(index, structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Rewrite method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRewriteWithNullStructure()
    {
        FluentActions.Invoking(() => this._testClass.Rewrite(_fixture.Create<int>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
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
        this._testClass.Write(data, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithObjectAndLongAndTypeAndIntWithNullData()
    {
        FluentActions.Invoking(() => this._testClass.Write(default(object), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithArrayOfObjectAndLongAndTypeAndInt()
    {
        // Arrange
        var data = _fixture.Create<object[]>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.Write(data, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithArrayOfObjectAndLongAndTypeAndIntWithNullData()
    {
        FluentActions.Invoking(() => this._testClass.Write(default(object[]), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
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
        this._testClass.Write(buffer, index, count, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithArrayOfObjectAndIntAndIntAndLongAndTypeAndIntWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.Write(default(object[]), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithNintAndLongAndLongAndTypeAndInt()
    {
        // Arrange
        var ptr = _fixture.Create<nint>();
        var length = _fixture.Create<long>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.Write(ptr, length, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithWriteFuncAndPosition()
    {
        // Arrange
        Action<nint> writeFunc = x => { };
        var position = _fixture.Create<long>();

        // Act
        this._testClass.Write(writeFunc, position);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method throws when the writeFunc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithWriteFuncAndPositionWithNullWriteFunc()
    {
        FluentActions.Invoking(() => this._testClass.Write(default(Action<nint>), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("writeFunc");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithByte*AndLongAndLongAndTypeAndInt()
    {
        // Arrange
        var ptr = _fixture.Create<byte*>();
        var length = _fixture.Create<long>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.Write(ptr, length, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
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
        var result = this._testClass.Read(data, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithObjectAndLongAndTypeAndIntWithNullData()
    {
        FluentActions.Invoking(() => this._testClass.Read(default(object), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithArrayOfObjectAndLongAndTypeAndInt()
    {
        // Arrange
        var data = _fixture.Create<object[]>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.Read(data, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithArrayOfObjectAndLongAndTypeAndIntWithNullData()
    {
        FluentActions.Invoking(() => this._testClass.Read(default(object[]), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
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
        this._testClass.Read(buffer, index, count, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithArrayOfObjectAndIntAndIntAndLongAndTypeAndIntWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.Read(default(object[]), _fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
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
        this._testClass.Read(destination, length, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
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
        this._testClass.Read(destination, length, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithReadFuncAndPosition()
    {
        // Arrange
        Action<nint> readFunc = x => { };
        var position = _fixture.Create<long>();

        // Act
        this._testClass.Read(readFunc, position);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method throws when the readFunc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithReadFuncAndPositionWithNullReadFunc()
    {
        FluentActions.Invoking(() => this._testClass.Read(default(Action<nint>), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("readFunc");
    }

    /// <summary>
    /// Checks that the CopyTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyTo()
    {
        // Arrange
        var destination = _fixture.Create<ITableStock>();
        var length = _fixture.Create<uint>();
        var startIndex = _fixture.Create<int>();

        // Act
        this._testClass.CopyTo(destination, length, startIndex);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyToWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.CopyTo(default(ITableStock), _fixture.Create<uint>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWriteWithNoParameters()
    {
        // Act
        this._testClass.Write();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallReadWithNoParameters()
    {
        // Act
        this._testClass.Read();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForInt()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForIntAndIntAndType()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Type>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Type>()] = testValue;
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Type>()].Should().BeSameAs(testValue);
    }
}