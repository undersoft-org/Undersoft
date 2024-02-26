using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Identifier;
using TObject = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.UnitTests.Data.Identifier;

/// <summary>
/// Unit tests for the type <see cref="Identifier"/>.
/// </summary>
public class Identifier_1Tests
{
    private Identifier<TObject> _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Identifier"/>.
    /// </summary>
    public Identifier_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Identifier<TObject>>();
    }

    /// <summary>
    /// Checks that setting the Object property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetObject()
    {
        this._testClass.CheckProperty(x => x.Object, _fixture.Create<TObject>(), _fixture.Create<TObject>());
    }
}

/// <summary>
/// Unit tests for the type <see cref="Identifier"/>.
/// </summary>
public class IdentifierTests
{
    private Identifier _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Identifier"/>.
    /// </summary>
    public IdentifierTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Identifier>();
    }

    /// <summary>
    /// Checks that setting the ObjectId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetObjectId()
    {
        this._testClass.CheckProperty(x => x.ObjectId);
    }

    /// <summary>
    /// Checks that setting the Kind property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetKind()
    {
        this._testClass.CheckProperty(x => x.Kind, _fixture.Create<IdKind>(), _fixture.Create<IdKind>());
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
    /// Checks that setting the Value property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetValue()
    {
        this._testClass.CheckProperty(x => x.Value);
    }

    /// <summary>
    /// Checks that setting the Key property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetKey()
    {
        this._testClass.CheckProperty(x => x.Key);
    }
}