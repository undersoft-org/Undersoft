using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Instant.Sql;

namespace Undersoft.SDK.UnitTests.Instant.Sql;

/// <summary>
/// Unit tests for the type <see cref="DataReader"/>.
/// </summary>
public class DataReaderTests
{
    private DataReader _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _resultsetIInstantSeries;
    private InstantSeriesItem[] _resultsetUnknownType;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DataReader"/>.
    /// </summary>
    public DataReaderTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._resultsetIInstantSeries = _fixture.Freeze<Mock<IInstantSeries>>();
        this._resultsetUnknownType = _fixture.Create<InstantSeriesItem[]>();
        this._testClass = _fixture.Create<DataReader>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DataReader(this._resultsetIInstantSeries.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new DataReader(this._resultsetUnknownType);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the resultset parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullResultset()
    {
        FluentActions.Invoking(() => new DataReader(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("resultset");
        FluentActions.Invoking(() => new DataReader(default(InstantSeriesItem[]))).Should().Throw<ArgumentNullException>().WithParameterName("resultset");
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
    /// Checks that the NextResult method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNextResult()
    {
        // Act
        var result = this._testClass.NextResult();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRead()
    {
        // Act
        var result = this._testClass.Read();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSchemaTable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSchemaTable()
    {
        // Act
        var result = this._testClass.GetSchemaTable();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetName()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetName(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDataTypeName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDataTypeName()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetDataTypeName(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetFieldType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetFieldType()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetFieldType(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetValue method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetValue()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetValue(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetValues method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetValues()
    {
        // Arrange
        var values = _fixture.Create<object[]>();

        // Act
        var result = this._testClass.GetValues(values);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetValues method throws when the values parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetValuesWithNullValues()
    {
        FluentActions.Invoking(() => this._testClass.GetValues(default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("values");
    }

    /// <summary>
    /// Checks that the GetOrdinal method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetOrdinal()
    {
        // Arrange
        var name = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetOrdinal(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetOrdinal method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetOrdinalWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetOrdinal(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetBoolean method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBoolean()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetBoolean(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetByte method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetByte()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetByte(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBytes()
    {
        // Arrange
        var i = _fixture.Create<int>();
        var fieldOffset = _fixture.Create<long>();
        var buffer = _fixture.Create<byte[]>();
        var bufferoffset = _fixture.Create<int>();
        var length = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetBytes(i, fieldOffset, buffer, bufferoffset, length);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBytes method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetBytesWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.GetBytes(_fixture.Create<int>(), _fixture.Create<long>(), default(byte[]), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the GetChar method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetChar()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetChar(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetChars method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetChars()
    {
        // Arrange
        var i = _fixture.Create<int>();
        var fieldoffset = _fixture.Create<long>();
        var buffer = _fixture.Create<char[]>();
        var bufferoffset = _fixture.Create<int>();
        var length = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetChars(i, fieldoffset, buffer, bufferoffset, length);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetChars method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetCharsWithNullBuffer()
    {
        FluentActions.Invoking(() => this._testClass.GetChars(_fixture.Create<int>(), _fixture.Create<long>(), default(char[]), _fixture.Create<int>(), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the GetGuid method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetGuid()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetGuid(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetInt16 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetInt16()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetInt16(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetInt32 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetInt32()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetInt32(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetInt64 method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetInt64()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetInt64(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetFloat method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetFloat()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetFloat(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDouble method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDouble()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetDouble(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetString()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetString(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDecimal method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDecimal()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetDecimal(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetDateTime method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetDateTime()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetDateTime(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetData method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetData()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetData(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsDBNull method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsDBNull()
    {
        // Arrange
        var i = _fixture.Create<int>();

        // Act
        var result = this._testClass.IsDBNull(i);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Dispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDispose()
    {
        // Act
        ((IDisposable)this._testClass).Dispose();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Depth property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetDepth()
    {
        // Assert
        this._testClass.Depth.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsClosed property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIsClosed()
    {
        // Assert
        this._testClass.IsClosed.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RecordsAffected property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRecordsAffected()
    {
        // Assert
        this._testClass.RecordsAffected.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FieldCount property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetFieldCount()
    {
        // Assert
        this._testClass.FieldCount.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForInt()
    {
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<object>();
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanGetIndexerForString()
    {
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<object>();
        Assert.Fail("Create or modify test");
    }
}