using System;
using System.Collections;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Stocks;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Stocks;

/// <summary>
/// Unit tests for the type <see cref="TableStock"/>.
/// </summary>
public class TableStock_1Tests
{
    private TableStock<T> _testClass;
    private IFixture _fixture;
    private StockOptions _options;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TableStock"/>.
    /// </summary>
    public TableStock_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._options = _fixture.Create<StockOptions>();
        this._testClass = _fixture.Create<TableStock<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TableStock<T>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TableStock<T>(this._options);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new TableStock<T>(default(StockOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }
}

/// <summary>
/// Unit tests for the type <see cref="TableStock"/>.
/// </summary>
public class TableStockTests
{
    private class TestTableStock : TableStock
    {
        public TestTableStock(
            string file,
            string name,
            int elementSize,
            int length,
            Type t,
            bool isOwner
        ) : base(file, name, elementSize, length, t, isOwner
)
        {
        }

        public TestTableStock(string file, string name, int elementSize, int length, Type t) : base(file, name, elementSize, length, t)
        {
        }

        public TestTableStock(string file, string name, int length, int elementSize) : base(file, name, length, elementSize)
        {
        }

        public TestTableStock(string file, string name, Type t) : base(file, name, t)
        {
        }

        public TestTableStock(SectorOptions options) : base(options)
        {
        }

        public bool PublicDoOpen()
        {
            return base.DoOpen();
        }
    }

    private TestTableStock _testClass;
    private IFixture _fixture;
    private string _file;
    private string _name;
    private int _elementSize;
    private int _length;
    private Type _t;
    private bool _isOwner;
    private SectorOptions _options;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="TableStock"/>.
    /// </summary>
    public TableStockTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._file = _fixture.Create<string>();
        this._name = _fixture.Create<string>();
        this._elementSize = _fixture.Create<int>();
        this._length = _fixture.Create<int>();
        this._t = _fixture.Create<Type>();
        this._isOwner = _fixture.Create<bool>();
        this._options = _fixture.Create<SectorOptions>();
        this._testClass = _fixture.Create<TestTableStock>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestTableStock(this._file, this._name, this._elementSize, this._length, this._t, this._isOwner);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTableStock(this._file, this._name, this._elementSize, this._length, this._t);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTableStock(this._file, this._name, this._length, this._elementSize);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTableStock(this._file, this._name, this._t);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestTableStock(this._options);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the t parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullT()
    {
        FluentActions.Invoking(() => new TestTableStock(this._file, this._name, this._elementSize, this._length, default(Type), this._isOwner)).Should().Throw<ArgumentNullException>().WithParameterName("t");
        FluentActions.Invoking(() => new TestTableStock(this._file, this._name, this._elementSize, this._length, default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("t");
        FluentActions.Invoking(() => new TestTableStock(this._file, this._name, default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("t");
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new TestTableStock(default(SectorOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
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
        FluentActions.Invoking(() => new TestTableStock(value, this._name, this._elementSize, this._length, this._t, this._isOwner)).Should().Throw<ArgumentNullException>().WithParameterName("file");
        FluentActions.Invoking(() => new TestTableStock(value, this._name, this._elementSize, this._length, this._t)).Should().Throw<ArgumentNullException>().WithParameterName("file");
        FluentActions.Invoking(() => new TestTableStock(value, this._name, this._length, this._elementSize)).Should().Throw<ArgumentNullException>().WithParameterName("file");
        FluentActions.Invoking(() => new TestTableStock(value, this._name, this._t)).Should().Throw<ArgumentNullException>().WithParameterName("file");
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
        FluentActions.Invoking(() => new TestTableStock(this._file, value, this._elementSize, this._length, this._t, this._isOwner)).Should().Throw<ArgumentNullException>().WithParameterName("name");
        FluentActions.Invoking(() => new TestTableStock(this._file, value, this._elementSize, this._length, this._t)).Should().Throw<ArgumentNullException>().WithParameterName("name");
        FluentActions.Invoking(() => new TestTableStock(this._file, value, this._length, this._elementSize)).Should().Throw<ArgumentNullException>().WithParameterName("name");
        FluentActions.Invoking(() => new TestTableStock(this._file, value, this._t)).Should().Throw<ArgumentNullException>().WithParameterName("name");
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
        var buffer = _fixture.Create<object[]>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.Write(buffer, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Write method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallWriteWithArrayOfObjectAndLongAndTypeAndIntWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.Write(default(object[]), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
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
        var buffer = _fixture.Create<object[]>();
        var position = _fixture.Create<long>();
        var t = _fixture.Create<Type>();
        var timeout = _fixture.Create<int>();

        // Act
        this._testClass.Read(buffer, position, t, timeout);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallReadWithArrayOfObjectAndLongAndTypeAndIntWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.Read(default(object[]), _fixture.Create<long>(), _fixture.Create<Type>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
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
    /// Checks that the CopyTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyToWithBufferAndPosition()
    {
        // Arrange
        var buffer = _fixture.Create<object[]>();
        var position = _fixture.Create<int>();

        // Act
        this._testClass.CopyTo(buffer, position);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyToWithBufferAndPositionWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.CopyTo(default(object[]), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the CopyTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyToWithDestinationAndLengthAndPosition()
    {
        // Arrange
        var destination = _fixture.Create<ITableStock>();
        var length = _fixture.Create<uint>();
        var position = _fixture.Create<int>();

        // Act
        this._testClass.CopyTo(destination, length, position);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyTo method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyToWithDestinationAndLengthAndPositionWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.CopyTo(default(ITableStock), _fixture.Create<uint>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the GetEnumerator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEnumeratorWithNoParameters()
    {
        // Act
        var result = this._testClass.GetEnumerator();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAdd()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        this._testClass.Add(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Clear method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClear()
    {
        // Act
        this._testClass.Clear();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallContains()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = this._testClass.Contains(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Contains method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallContainsWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Contains(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Remove method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemove()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = this._testClass.Remove(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Remove method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoveWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Remove(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the IndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIndexOf()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = this._testClass.IndexOf(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIndexOfWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.IndexOf(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Insert method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallInsert()
    {
        // Arrange
        var index = _fixture.Create<int>();
        var item = _fixture.Create<object>();

        // Act
        this._testClass.Insert(index, item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Insert method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallInsertWithNullItem()
    {
        FluentActions.Invoking(() => this._testClass.Insert(_fixture.Create<int>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the RemoveAt method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoveAt()
    {
        // Arrange
        var index = _fixture.Create<int>();

        // Act
        this._testClass.RemoveAt(index);

        // Assert
        Assert.Fail("Create or modify test");
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
    /// Checks that the GetEnumerator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEnumeratorForIEnumerableWithNoParameters()
    {
        // Act
        var result = ((IEnumerable)this._testClass).GetEnumerator();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Count property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetCount()
    {
        // Assert
        this._testClass.Count.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsReadOnly property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIsReadOnly()
    {
        // Assert
        this._testClass.IsReadOnly.As<object>().Should().BeAssignableTo<bool>();

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