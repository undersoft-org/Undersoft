using System;
using System.Collections;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.UnitTests.Uniques;

/// <summary>
/// Unit tests for the type <see cref="UniqueKey32"/>.
/// </summary>
public class UniqueKey32Tests
{
    private class TestUniqueKey32 : UniqueKey32
    {
        public TestUniqueKey32() : base()
        {
        }

        public byte[] PublicBytes(byte* obj, int length, long seed)
        {
            return base.Bytes(obj, length, seed);
        }

        public long PublicKey(byte* obj, int length, long seed)
        {
            return base.Key(obj, length, seed);
        }
    }

    private TestUniqueKey32 _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="UniqueKey32"/>.
    /// </summary>
    public UniqueKey32Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestUniqueKey32>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestUniqueKey32();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithArrayOfByteAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithArrayOfByteAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithIListAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithIListAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(IList), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithNintAndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithIIdentifiable()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.Bytes(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithIIdentifiableWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithStringAndLong()
    {
        // Arrange
        var obj = _fixture.Create<string>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBytesWithStringAndLongWithInvalidObj(string value)
    {
        FluentActions.Invoking(() => this._testClass.Bytes(value, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithTypeAndLong()
    {
        // Arrange
        var obj = _fixture.Create<Type>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithTypeAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(Type), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the ComputeBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeBytesWithByte*AndIntAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.ComputeBytes(bytes, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeBytesWithArrayOfByteAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.ComputeBytes(bytes, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeBytes method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeBytesWithArrayOfByteAndLongWithNullBytes()
    {
        FluentActions.Invoking(() => this._testClass.ComputeBytes(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the ComputeKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeKeyWithByte*AndIntAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.ComputeKey(bytes, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeKeyWithArrayOfByteAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.ComputeKey(bytes, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeKey method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeKeyWithArrayOfByteAndLongWithNullBytes()
    {
        FluentActions.Invoking(() => this._testClass.ComputeKey(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithArrayOfByteAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithArrayOfByteAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithIListAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithIListAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(IList), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithNintAndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithIIdentifiable()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.Key(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithIIdentifiableWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithIIdentifiableAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithIIdentifiableAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(IIdentifiable), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithStringAndLong()
    {
        // Arrange
        var obj = _fixture.Create<string>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallKeyWithStringAndLongWithInvalidObj(string value)
    {
        FluentActions.Invoking(() => this._testClass.Key(value, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithTypeAndLong()
    {
        // Arrange
        var obj = _fixture.Create<Type>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithTypeAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(Type), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the PublicBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithByte*AndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicBytes(obj, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithByte*AndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicKey(obj, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="UniqueKey64"/>.
/// </summary>
public class UniqueKey64Tests
{
    private class TestUniqueKey64 : UniqueKey64
    {
        public TestUniqueKey64() : base()
        {
        }

        public byte[] PublicBytes(byte* obj, int length, long seed)
        {
            return base.Bytes(obj, length, seed);
        }

        public long PublicKey(byte* obj, int length, long seed)
        {
            return base.Key(obj, length, seed);
        }
    }

    private TestUniqueKey64 _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="UniqueKey64"/>.
    /// </summary>
    public UniqueKey64Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestUniqueKey64>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestUniqueKey64();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithArrayOfByteAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithArrayOfByteAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithIListAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithIListAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(IList), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithNintAndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithIIdentifiable()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.Bytes(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithIIdentifiableWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithStringAndLong()
    {
        // Arrange
        var obj = _fixture.Create<string>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBytesWithStringAndLongWithInvalidObj(string value)
    {
        FluentActions.Invoking(() => this._testClass.Bytes(value, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithTypeAndLong()
    {
        // Arrange
        var obj = _fixture.Create<Type>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithTypeAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(Type), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the ComputeBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeBytesWithByte*AndIntAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.ComputeBytes(bytes, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeBytesWithArrayOfByteAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.ComputeBytes(bytes, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeBytes method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeBytesWithArrayOfByteAndLongWithNullBytes()
    {
        FluentActions.Invoking(() => this._testClass.ComputeBytes(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the ComputeKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeKeyWithByte*AndIntAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.ComputeKey(bytes, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeKeyWithArrayOfByteAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.ComputeKey(bytes, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeKey method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeKeyWithArrayOfByteAndLongWithNullBytes()
    {
        FluentActions.Invoking(() => this._testClass.ComputeKey(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithArrayOfByteAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithArrayOfByteAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithIListAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithIListAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(IList), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithNintAndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithIIdentifiable()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.Key(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithIIdentifiableWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithIIdentifiableAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithIIdentifiableAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(IIdentifiable), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithStringAndLong()
    {
        // Arrange
        var obj = _fixture.Create<string>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallKeyWithStringAndLongWithInvalidObj(string value)
    {
        FluentActions.Invoking(() => this._testClass.Key(value, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithTypeAndLong()
    {
        // Arrange
        var obj = _fixture.Create<Type>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithTypeAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(Type), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the PublicBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithByte*AndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicBytes(obj, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithByte*AndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicKey(obj, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="UniqueKey"/>.
/// </summary>
public class UniqueKeyTests
{
    private class TestUniqueKey : UniqueKey
    {
        public TestUniqueKey() : base()
        {
        }

        public TestUniqueKey(HashBits hashBits) : base(hashBits)
        {
        }

        public byte[] PublicBytes(byte* obj, int length, long seed)
        {
            return base.Bytes(obj, length, seed);
        }

        public long PublicKey(byte* obj, int length, long seed)
        {
            return base.Key(obj, length, seed);
        }
    }

    private TestUniqueKey _testClass;
    private IFixture _fixture;
    private HashBits _hashBits;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="UniqueKey"/>.
    /// </summary>
    public UniqueKeyTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._hashBits = _fixture.Create<HashBits>();
        this._testClass = _fixture.Create<TestUniqueKey>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestUniqueKey();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestUniqueKey(this._hashBits);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithArrayOfByteAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithArrayOfByteAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithIListAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithIListAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(IList), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithNintAndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithIIdentifiable()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.Bytes(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithIIdentifiableWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithStringAndLong()
    {
        // Arrange
        var obj = _fixture.Create<string>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallBytesWithStringAndLongWithInvalidObj(string value)
    {
        FluentActions.Invoking(() => this._testClass.Bytes(value, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Bytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithTypeAndLong()
    {
        // Arrange
        var obj = _fixture.Create<Type>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Bytes(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallBytesWithTypeAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Bytes(default(Type), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the ComputeBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeBytesWithByte*AndIntAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.ComputeBytes(bytes, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeBytesWithArrayOfByteAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.ComputeBytes(bytes, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeBytes method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeBytesWithArrayOfByteAndLongWithNullBytes()
    {
        FluentActions.Invoking(() => this._testClass.ComputeBytes(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the ComputeKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeKeyWithByte*AndIntAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.ComputeKey(bytes, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallComputeKeyWithArrayOfByteAndLong()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.ComputeKey(bytes, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ComputeKey method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallComputeKeyWithArrayOfByteAndLongWithNullBytes()
    {
        FluentActions.Invoking(() => this._testClass.ComputeKey(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithArrayOfByteAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte[]>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithArrayOfByteAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(byte[]), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithIListAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IList>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithIListAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(IList), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithNintAndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<nint>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithIIdentifiable()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();

        // Act
        var result = this._testClass.Key(obj);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithIIdentifiableWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(IIdentifiable))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithIIdentifiableAndLong()
    {
        // Arrange
        var obj = _fixture.Create<IIdentifiable>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithIIdentifiableAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(IIdentifiable), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithObjectAndLong()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithObjectAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(object), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithStringAndLong()
    {
        // Arrange
        var obj = _fixture.Create<string>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallKeyWithStringAndLongWithInvalidObj(string value)
    {
        FluentActions.Invoking(() => this._testClass.Key(value, _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Key method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithTypeAndLong()
    {
        // Arrange
        var obj = _fixture.Create<Type>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.Key(obj, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Key method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallKeyWithTypeAndLongWithNullObj()
    {
        FluentActions.Invoking(() => this._testClass.Key(default(Type), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the PublicBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBytesWithByte*AndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicBytes(obj, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicKey method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallKeyWithByte*AndIntAndLong()
    {
        // Arrange
        var obj = _fixture.Create<byte*>();
        var length = _fixture.Create<int>();
        var seed = _fixture.Create<long>();

        // Act
        var result = this._testClass.PublicKey(obj, length, seed);

        // Assert
        Assert.Fail("Create or modify test");
    }
}