using System;
using System.Text.Json;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Object.Detail;
using T = System.String;
using TDetail = Undersoft.SDK.Service.Data.Object.Detail.ObjectDetail;
using TKind = System.AttributeTargets;

namespace Undersoft.SDK.Service.UnitTests.Data.Object.Detail;

/// <summary>
/// Unit tests for the type <see cref="ObjectDetail"/>.
/// </summary>
public class ObjectDetail_2Tests
{
    private ObjectDetail<TDetail, TKind> _testClass;
    private IFixture _fixture;
    private TKind _kind;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ObjectDetail"/>.
    /// </summary>
    public ObjectDetail_2Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._kind = _fixture.Create<TKind>();
        this._testClass = _fixture.Create<ObjectDetail<TDetail, TKind>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ObjectDetail<TDetail, TKind>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ObjectDetail<TDetail, TKind>(this._kind);

        // Assert
        instance.Should().NotBeNull();
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
    /// Checks that setting the Data property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetData()
    {
        this._testClass.CheckProperty(x => x.Data, _fixture.Create<byte[]>(), _fixture.Create<byte[]>());
    }

    /// <summary>
    /// Checks that setting the Document property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDocument()
    {
        this._testClass.CheckProperty(x => x.Document, _fixture.Create<JsonDocument>(), _fixture.Create<JsonDocument>());
    }

    /// <summary>
    /// Checks that setting the Name property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetName()
    {
        this._testClass.CheckProperty(x => x.Name);
    }

    /// <summary>
    /// Checks that setting the Identifiers property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIdentifiers()
    {
        this._testClass.CheckProperty(x => x.Identifiers, _fixture.Create<IdentifierSet<TDetail>>(), _fixture.Create<IdentifierSet<TDetail>>());
    }

    /// <summary>
    /// Checks that setting the Kind property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetKind()
    {
        this._testClass.CheckProperty(x => x.Kind, _fixture.Create<TKind>(), _fixture.Create<TKind>());
    }
}