using System;
using System.Text.Json;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Serialization;
using E = System.String;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Serialization;

/// <summary>
/// Unit tests for the type <see cref="JsonDocumentSerializer"/>.
/// </summary>
public class JsonDocumentSerializerTests
{
    private JsonDocumentSerializer _testClass;
    private IFixture _fixture;
    private Mock<ISerializableJsonDocument> _container;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="JsonDocumentSerializer"/>.
    /// </summary>
    public JsonDocumentSerializerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._container = _fixture.Freeze<Mock<ISerializableJsonDocument>>();
        this._testClass = _fixture.Create<JsonDocumentSerializer>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new JsonDocumentSerializer();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new JsonDocumentSerializer(this._container.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the container parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullContainer()
    {
        FluentActions.Invoking(() => new JsonDocumentSerializer(default(ISerializableJsonDocument))).Should().Throw<ArgumentNullException>().WithParameterName("container");
    }

    /// <summary>
    /// Checks that the ToDocument method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToDocumentWithTAndT()
    {
        // Arrange
        var detail = _fixture.Create<T>();

        // Act
        var result = this._testClass.ToDocument<T>(detail);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToDocument method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToDocumentWithObject()
    {
        // Arrange
        var detail = _fixture.Create<object>();

        // Act
        var result = this._testClass.ToDocument(detail);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToDocument method throws when the detail parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToDocumentWithObjectWithNullDetail()
    {
        FluentActions.Invoking(() => this._testClass.ToDocument(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("detail");
    }

    /// <summary>
    /// Checks that the ToElement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToElementWithTAndT()
    {
        // Arrange
        var detail = _fixture.Create<T>();

        // Act
        var result = this._testClass.ToElement<T>(detail);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToElement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToElementWithObject()
    {
        // Arrange
        var detail = _fixture.Create<object>();

        // Act
        var result = this._testClass.ToElement(detail);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToElement method throws when the detail parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToElementWithObjectWithNullDetail()
    {
        FluentActions.Invoking(() => this._testClass.ToElement(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("detail");
    }

    /// <summary>
    /// Checks that the FromDocument method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromDocumentWithTAndJsonDocument()
    {
        // Arrange
        var doc = _fixture.Create<JsonDocument>();

        // Act
        var result = this._testClass.FromDocument<T>(doc);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromDocument method throws when the doc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromDocumentWithTAndJsonDocumentWithNullDoc()
    {
        FluentActions.Invoking(() => this._testClass.FromDocument<T>(default(JsonDocument))).Should().Throw<ArgumentNullException>().WithParameterName("doc");
    }

    /// <summary>
    /// Checks that the FromDocument method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromDocumentWithJsonDocument()
    {
        // Arrange
        var doc = _fixture.Create<JsonDocument>();

        // Act
        var result = this._testClass.FromDocument(doc);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromDocument method throws when the doc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromDocumentWithJsonDocumentWithNullDoc()
    {
        FluentActions.Invoking(() => this._testClass.FromDocument(default(JsonDocument))).Should().Throw<ArgumentNullException>().WithParameterName("doc");
    }

    /// <summary>
    /// Checks that the FromElement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromElementWithEle()
    {
        // Arrange
        var ele = _fixture.Create<JsonElement>();

        // Act
        var result = this._testClass.FromElement<T>(ele);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromElement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallFromElementWithEleAndType()
    {
        // Arrange
        var ele = _fixture.Create<JsonElement>();
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.FromElement(ele, type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FromElement method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallFromElementWithEleAndTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.FromElement(_fixture.Create<JsonElement>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the Serialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSerializeWithTAndT()
    {
        // Arrange
        var detail = _fixture.Create<T>();

        // Act
        var result = this._testClass.Serialize<T>(detail);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Serialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSerializeWithObject()
    {
        // Arrange
        var detail = _fixture.Create<object>();

        // Act
        var result = this._testClass.Serialize(detail);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Serialize method throws when the detail parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSerializeWithObjectWithNullDetail()
    {
        FluentActions.Invoking(() => this._testClass.Serialize(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("detail");
    }

    /// <summary>
    /// Checks that the Deserialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeserializeWithTAndArrayOfByte()
    {
        // Arrange
        var data = _fixture.Create<byte[]>();

        // Act
        var result = this._testClass.Deserialize<T>(data);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Deserialize method throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeserializeWithTAndArrayOfByteWithNullData()
    {
        FluentActions.Invoking(() => this._testClass.Deserialize<T>(default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that the Deserialize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDeserializeWithArrayOfByte()
    {
        // Arrange
        var data = _fixture.Create<byte[]>();

        // Act
        var result = this._testClass.Deserialize(data);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Deserialize method throws when the data parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDeserializeWithArrayOfByteWithNullData()
    {
        FluentActions.Invoking(() => this._testClass.Deserialize(default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("data");
    }

    /// <summary>
    /// Checks that the GetObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetObjectWithT()
    {
        // Act
        var result = this._testClass.GetObject<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetObject method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetObjectWithNoParameters()
    {
        // Act
        var result = this._testClass.GetObject();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPropertyWithSelect()
    {
        // Arrange
        Func<JsonDocument, JsonElement> @select = x => _fixture.Create<JsonElement>();

        // Act
        var result = this._testClass.GetProperty<T>(select);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetProperty method throws when the select parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetPropertyWithSelectWithNullSelect()
    {
        FluentActions.Invoking(() => this._testClass.GetProperty<T>(default(Func<JsonDocument, JsonElement>))).Should().Throw<ArgumentNullException>().WithParameterName("select");
    }

    /// <summary>
    /// Checks that the GetProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPropertyWithTypeAndSelect()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        Func<JsonDocument, JsonElement> @select = x => _fixture.Create<JsonElement>();

        // Act
        var result = this._testClass.GetProperty(type, select);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetProperty method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetPropertyWithTypeAndSelectWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.GetProperty(default(Type), x => _fixture.Create<JsonElement>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetProperty method throws when the select parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetPropertyWithTypeAndSelectWithNullSelect()
    {
        FluentActions.Invoking(() => this._testClass.GetProperty(_fixture.Create<Type>(), default(Func<JsonDocument, JsonElement>))).Should().Throw<ArgumentNullException>().WithParameterName("select");
    }

    /// <summary>
    /// Checks that the SetDocument method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetDocumentWithT()
    {
        // Arrange
        var structure = _fixture.Create<T>();

        // Act
        this._testClass.SetDocument<T>(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetDocument method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetDocumentWithObject()
    {
        // Arrange
        var structure = _fixture.Create<object>();

        // Act
        this._testClass.SetDocument(structure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetDocument method throws when the structure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetDocumentWithObjectWithNullStructure()
    {
        FluentActions.Invoking(() => this._testClass.SetDocument(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("structure");
    }

    /// <summary>
    /// Checks that the SetElement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetElementWithEAndFuncOfTAndE()
    {
        // Arrange
        var element = _fixture.Create<E>();
        Func<T, E> @select = x => _fixture.Create<E>();

        // Act
        this._testClass.SetElement<T, E>(element, select);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetElement method throws when the select parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetElementWithEAndFuncOfTAndEWithNullSelect()
    {
        FluentActions.Invoking(() => this._testClass.SetElement<T, E>(_fixture.Create<E>(), default(Func<T, E>))).Should().Throw<ArgumentNullException>().WithParameterName("select");
    }

    /// <summary>
    /// Checks that the SetElement method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetElementWithObjectAndFuncOfTAndObject()
    {
        // Arrange
        var element = _fixture.Create<object>();
        Func<T, object> @select = x => _fixture.Create<object>();

        // Act
        this._testClass.SetElement<T>(element, select);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetElement method throws when the element parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetElementWithObjectAndFuncOfTAndObjectWithNullElement()
    {
        FluentActions.Invoking(() => this._testClass.SetElement<T>(default(object), x => _fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("element");
    }

    /// <summary>
    /// Checks that the SetElement method throws when the select parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetElementWithObjectAndFuncOfTAndObjectWithNullSelect()
    {
        FluentActions.Invoking(() => this._testClass.SetElement<T>(_fixture.Create<object>(), default(Func<T, object>))).Should().Throw<ArgumentNullException>().WithParameterName("select");
    }

    /// <summary>
    /// Checks that the Type property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetType()
    {
        // Assert
        this._testClass.Type.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Document property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDocument()
    {
        // Arrange
        _container.Setup(mock => mock.Document).Returns(_fixture.Create<JsonDocument>());

        var testValue = _fixture.Create<JsonDocument>();

        // Act
        this._testClass.Document = testValue;

        // Assert
        this._testClass.Document.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the TypeName property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeName()
    {
        // Arrange
        _container.Setup(mock => mock.TypeName).Returns(_fixture.Create<string>());

        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.TypeName = testValue;

        // Assert
        this._testClass.TypeName.Should().Be(testValue);
    }
}