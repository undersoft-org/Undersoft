using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using E = System.String;
using T = System.String;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="JsonSerializerExtension"/>.
/// </summary>
public class JsonSerializerExtensionTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ToJsonBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToJsonBytesWithObject()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = obj.ToJsonBytes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToJsonBytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToJsonBytesWithObjectWithNullObj()
    {
        FluentActions.Invoking(() => default(object).ToJsonBytes()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the ToJsonBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToJsonBytesWithObjectAndType()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = obj.ToJsonBytes(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToJsonBytes method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToJsonBytesWithObjectAndTypeWithNullObj()
    {
        FluentActions.Invoking(() => default(object).ToJsonBytes(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the ToJsonBytes method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToJsonBytesWithObjectAndTypeWithNullType()
    {
        FluentActions.Invoking(() => _fixture.Create<object>().ToJsonBytes(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the ToJsonDocument method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToJsonDocumentWithObjectAndType()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = obj.ToJsonDocument(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToJsonDocument method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToJsonDocumentWithObjectAndTypeWithNullObj()
    {
        FluentActions.Invoking(() => default(object).ToJsonDocument(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the ToJsonDocument method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToJsonDocumentWithObjectAndTypeWithNullType()
    {
        FluentActions.Invoking(() => _fixture.Create<object>().ToJsonDocument(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the ToJsonDocument method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToJsonDocumentWithTAndT()
    {
        // Arrange
        var obj = _fixture.Create<T>();

        // Act
        var result = obj.ToJsonDocument<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToJsonElement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToJsonElementWithObjectAndType()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = obj.ToJsonElement(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToJsonElement method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToJsonElementWithObjectAndTypeWithNullObj()
    {
        FluentActions.Invoking(() => default(object).ToJsonElement(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the ToJsonElement method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToJsonElementWithObjectAndTypeWithNullType()
    {
        FluentActions.Invoking(() => _fixture.Create<object>().ToJsonElement(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the ToJsonElement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToJsonElementWithTAndT()
    {
        // Arrange
        var obj = _fixture.Create<T>();

        // Act
        var result = obj.ToJsonElement<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJsonDocument method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonDocumentWithTypeAndJsonDocument()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var doc = _fixture.Create<JsonDocument>();

        // Act
        var result = type.FromJsonDocument(doc);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJsonDocument method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonDocumentWithTypeAndJsonDocumentWithNullType()
    {
        FluentActions.Invoking(() => default(Type).FromJsonDocument(_fixture.Create<JsonDocument>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the FromJsonDocument method throws when the doc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonDocumentWithTypeAndJsonDocumentWithNullDoc()
    {
        FluentActions.Invoking(() => _fixture.Create<Type>().FromJsonDocument(default(JsonDocument))).Should().Throw<ArgumentNullException>().WithParameterName("doc");
    }

    /// <summary>
    /// Checks that the FromJsonDocument method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonDocumentWithJsonDocument()
    {
        // Arrange
        var doc = _fixture.Create<JsonDocument>();

        // Act
        var result = doc.FromJsonDocument<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJsonDocument method throws when the doc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonDocumentWithJsonDocumentWithNullDoc()
    {
        FluentActions.Invoking(() => default(JsonDocument).FromJsonDocument<T>()).Should().Throw<ArgumentNullException>().WithParameterName("doc");
    }

    /// <summary>
    /// Checks that the FromJsonDocument method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonDocumentWithTAndJsonDocument()
    {
        // Arrange
        var obj = _fixture.Create<T>();
        var doc = _fixture.Create<JsonDocument>();

        // Act
        var result = obj.FromJsonDocument<T>(doc);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJsonDocument method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonDocumentWithTAndJsonDocumentWithNullObj()
    {
        FluentActions.Invoking(() => default(T).FromJsonDocument<T>(_fixture.Create<JsonDocument>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the FromJsonDocument method throws when the doc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonDocumentWithTAndJsonDocumentWithNullDoc()
    {
        FluentActions.Invoking(() => _fixture.Create<T>().FromJsonDocument<T>(default(JsonDocument))).Should().Throw<ArgumentNullException>().WithParameterName("doc");
    }

    /// <summary>
    /// Checks that the FromJsonElement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonElementWithTypeAndJsonElement()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var doc = _fixture.Create<JsonElement>();

        // Act
        var result = type.FromJsonElement(doc);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJsonElement method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonElementWithTypeAndJsonElementWithNullType()
    {
        FluentActions.Invoking(() => default(Type).FromJsonElement(_fixture.Create<JsonElement>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the FromJsonElement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonElementWithJsonElement()
    {
        // Arrange
        var doc = _fixture.Create<JsonElement>();

        // Act
        var result = doc.FromJsonElement<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJsonElement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonElementWithTAndJsonElement()
    {
        // Arrange
        var obj = _fixture.Create<T>();
        var doc = _fixture.Create<JsonElement>();

        // Act
        var result = obj.FromJsonElement<T>(doc);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJsonElement method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonElementWithTAndJsonElementWithNullObj()
    {
        FluentActions.Invoking(() => default(T).FromJsonElement<T>(_fixture.Create<JsonElement>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the ToJsonBytes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToJsonBytesWithTAndT()
    {
        // Arrange
        var obj = _fixture.Create<T>();

        // Act
        var result = obj.ToJsonBytes<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToJsonString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToJsonStringWithObject()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = obj.ToJsonString();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToJsonString method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToJsonStringWithObjectWithNullObj()
    {
        FluentActions.Invoking(() => default(object).ToJsonString()).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the ToJsonString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToJsonStringWithTAndT()
    {
        // Arrange
        var obj = _fixture.Create<T>();

        // Act
        var result = obj.ToJsonString<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToJsonStream method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallToJsonStreamWithObjectAndStreamAsync()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var stream = _fixture.Create<Stream>();

        // Act
        await obj.ToJsonStream(stream);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToJsonStream method throws when the obj parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallToJsonStreamWithObjectAndStreamWithNullObjAsync()
    {
        await FluentActions.Invoking(() => default(object).ToJsonStream(_fixture.Create<Stream>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the ToJsonStream method throws when the stream parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallToJsonStreamWithObjectAndStreamWithNullStreamAsync()
    {
        await FluentActions.Invoking(() => _fixture.Create<object>().ToJsonStream(default(Stream))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("stream");
    }

    /// <summary>
    /// Checks that the ToJsonStream method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallToJsonStreamWithTAndStreamAsync()
    {
        // Arrange
        var obj = _fixture.Create<T>();
        var stream = _fixture.Create<Stream>();

        // Act
        await obj.ToJsonStream<T>(stream);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToJsonStream method throws when the stream parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallToJsonStreamWithTAndStreamWithNullStreamAsync()
    {
        await FluentActions.Invoking(() => _fixture.Create<T>().ToJsonStream<T>(default(Stream))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("stream");
    }

    /// <summary>
    /// Checks that the ToJsonBuffer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToJsonBufferWithObjectAndArrayOfByte()
    {
        // Arrange
        var obj = _fixture.Create<object>();
        var buffer = _fixture.Create<byte[]>();

        // Act
        var result = obj.ToJsonBuffer(ref buffer);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToJsonBuffer method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToJsonBufferWithObjectAndArrayOfByteWithNullObj()
    {
        var buffer = _fixture.Create<byte[]>();
        FluentActions.Invoking(() => default(object).ToJsonBuffer(ref buffer)).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the ToJsonBuffer method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToJsonBufferWithObjectAndArrayOfByteWithNullBuffer()
    {
        var buffer = default(byte[]);
        FluentActions.Invoking(() => _fixture.Create<object>().ToJsonBuffer(ref buffer)).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the ToJsonBuffer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToJsonBufferWithTAndArrayOfByte()
    {
        // Arrange
        var obj = _fixture.Create<T>();
        var buffer = _fixture.Create<byte[]>();

        // Act
        var result = obj.ToJsonBuffer<T>(ref buffer);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToJsonBuffer method throws when the buffer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToJsonBufferWithTAndArrayOfByteWithNullBuffer()
    {
        var buffer = default(byte[]);
        FluentActions.Invoking(() => _fixture.Create<T>().ToJsonBuffer<T>(ref buffer)).Should().Throw<ArgumentNullException>().WithParameterName("buffer");
    }

    /// <summary>
    /// Checks that the FromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonWithBytesAndType()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = bytes.FromJson(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonWithBytesAndTypeWithNullBytes()
    {
        FluentActions.Invoking(() => default(byte[]).FromJson(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonWithBytesAndTypeWithNullType()
    {
        FluentActions.Invoking(() => _fixture.Create<byte[]>().FromJson(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the FromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonWithBytes()
    {
        // Arrange
        var bytes = _fixture.Create<byte[]>();

        // Act
        var result = bytes.FromJson<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonWithBytesWithNullBytes()
    {
        FluentActions.Invoking(() => default(byte[]).FromJson<T>()).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the FromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonWithTypeAndBytes()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var bytes = _fixture.Create<byte[]>();

        // Act
        var result = type.FromJson(bytes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonWithTypeAndBytesWithNullType()
    {
        FluentActions.Invoking(() => default(Type).FromJson(_fixture.Create<byte[]>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonWithTypeAndBytesWithNullBytes()
    {
        FluentActions.Invoking(() => _fixture.Create<Type>().FromJson(default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the FromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonWithStringAndType()
    {
        // Arrange
        var str = _fixture.Create<string>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = str.FromJson(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonWithStringAndTypeWithNullType()
    {
        FluentActions.Invoking(() => _fixture.Create<string>().FromJson(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the str parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFromJsonWithStringAndTypeWithInvalidStr(string value)
    {
        FluentActions.Invoking(() => value.FromJson(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("str");
    }

    /// <summary>
    /// Checks that the FromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonWithString()
    {
        // Arrange
        var str = _fixture.Create<string>();

        // Act
        var result = str.FromJson<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the str parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFromJsonWithStringWithInvalidStr(string value)
    {
        FluentActions.Invoking(() => value.FromJson<T>()).Should().Throw<ArgumentNullException>().WithParameterName("str");
    }

    /// <summary>
    /// Checks that the FromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonWithTypeAndString()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var str = _fixture.Create<string>();

        // Act
        var result = type.FromJson(str);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonWithTypeAndStringWithNullType()
    {
        FluentActions.Invoking(() => default(Type).FromJson(_fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the str parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallFromJsonWithTypeAndStringWithInvalidStr(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<Type>().FromJson(value)).Should().Throw<ArgumentNullException>().WithParameterName("str");
    }

    /// <summary>
    /// Checks that the FromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonWithStreamAndType()
    {
        // Arrange
        var str = _fixture.Create<Stream>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = str.FromJson(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the str parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonWithStreamAndTypeWithNullStr()
    {
        FluentActions.Invoking(() => default(Stream).FromJson(_fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("str");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonWithStreamAndTypeWithNullType()
    {
        FluentActions.Invoking(() => _fixture.Create<Stream>().FromJson(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the FromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonWithStream()
    {
        // Arrange
        var str = _fixture.Create<Stream>();

        // Act
        var result = str.FromJson<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the str parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonWithStreamWithNullStr()
    {
        FluentActions.Invoking(() => default(Stream).FromJson<T>()).Should().Throw<ArgumentNullException>().WithParameterName("str");
    }

    /// <summary>
    /// Checks that the FromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromJsonWithTypeAndStream()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var str = _fixture.Create<Stream>();

        // Act
        var result = type.FromJson(str);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonWithTypeAndStreamWithNullType()
    {
        FluentActions.Invoking(() => default(Type).FromJson(_fixture.Create<Stream>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the FromJson method throws when the str parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromJsonWithTypeAndStreamWithNullStr()
    {
        FluentActions.Invoking(() => _fixture.Create<Type>().FromJson(default(Stream))).Should().Throw<ArgumentNullException>().WithParameterName("str");
    }

    /// <summary>
    /// Checks that the PatchFromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchFromJsonWithTAndEAndEAndString()
    {
        // Arrange
        var obj = _fixture.Create<E>();
        var str = _fixture.Create<string>();

        // Act
        var result = obj.PatchFromJson<T, E>(str);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchFromJson method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchFromJsonWithTAndEAndEAndStringWithNullObj()
    {
        FluentActions.Invoking(() => default(E).PatchFromJson<T, E>(_fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the PatchFromJson method throws when the str parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallPatchFromJsonWithTAndEAndEAndStringWithInvalidStr(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<E>().PatchFromJson<T, E>(value)).Should().Throw<ArgumentNullException>().WithParameterName("str");
    }

    /// <summary>
    /// Checks that the PutFromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutFromJsonWithTAndEAndEAndString()
    {
        // Arrange
        var obj = _fixture.Create<E>();
        var str = _fixture.Create<string>();

        // Act
        var result = obj.PutFromJson<T, E>(str);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutFromJson method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutFromJsonWithTAndEAndEAndStringWithNullObj()
    {
        FluentActions.Invoking(() => default(E).PutFromJson<T, E>(_fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the PutFromJson method throws when the str parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallPutFromJsonWithTAndEAndEAndStringWithInvalidStr(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<E>().PutFromJson<T, E>(value)).Should().Throw<ArgumentNullException>().WithParameterName("str");
    }

    /// <summary>
    /// Checks that the PatchFromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchFromJsonWithTAndEAndEAndArrayOfByte()
    {
        // Arrange
        var obj = _fixture.Create<E>();
        var bytes = _fixture.Create<byte[]>();

        // Act
        var result = obj.PatchFromJson<T, E>(bytes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchFromJson method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchFromJsonWithTAndEAndEAndArrayOfByteWithNullObj()
    {
        FluentActions.Invoking(() => default(E).PatchFromJson<T, E>(_fixture.Create<byte[]>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the PatchFromJson method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchFromJsonWithTAndEAndEAndArrayOfByteWithNullBytes()
    {
        FluentActions.Invoking(() => _fixture.Create<E>().PatchFromJson<T, E>(default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the PutFromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutFromJsonWithTAndEAndEAndArrayOfByte()
    {
        // Arrange
        var obj = _fixture.Create<E>();
        var bytes = _fixture.Create<byte[]>();

        // Act
        var result = obj.PutFromJson<T, E>(bytes);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutFromJson method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutFromJsonWithTAndEAndEAndArrayOfByteWithNullObj()
    {
        FluentActions.Invoking(() => default(E).PutFromJson<T, E>(_fixture.Create<byte[]>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the PutFromJson method throws when the bytes parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutFromJsonWithTAndEAndEAndArrayOfByteWithNullBytes()
    {
        FluentActions.Invoking(() => _fixture.Create<E>().PutFromJson<T, E>(default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("bytes");
    }

    /// <summary>
    /// Checks that the PatchFromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPatchFromJsonWithTAndEAndEAndStream()
    {
        // Arrange
        var obj = _fixture.Create<E>();
        var str = _fixture.Create<Stream>();

        // Act
        var result = obj.PatchFromJson<T, E>(str);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PatchFromJson method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchFromJsonWithTAndEAndEAndStreamWithNullObj()
    {
        FluentActions.Invoking(() => default(E).PatchFromJson<T, E>(_fixture.Create<Stream>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the PatchFromJson method throws when the str parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPatchFromJsonWithTAndEAndEAndStreamWithNullStr()
    {
        FluentActions.Invoking(() => _fixture.Create<E>().PatchFromJson<T, E>(default(Stream))).Should().Throw<ArgumentNullException>().WithParameterName("str");
    }

    /// <summary>
    /// Checks that the PutFromJson method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallPutFromJsonWithTAndEAndEAndStream()
    {
        // Arrange
        var obj = _fixture.Create<E>();
        var str = _fixture.Create<Stream>();

        // Act
        var result = obj.PutFromJson<T, E>(str);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PutFromJson method throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutFromJsonWithTAndEAndEAndStreamWithNullObj()
    {
        FluentActions.Invoking(() => default(E).PutFromJson<T, E>(_fixture.Create<Stream>())).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the PutFromJson method throws when the str parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallPutFromJsonWithTAndEAndEAndStreamWithNullStr()
    {
        FluentActions.Invoking(() => _fixture.Create<E>().PutFromJson<T, E>(default(Stream))).Should().Throw<ArgumentNullException>().WithParameterName("str");
    }
}