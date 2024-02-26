using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Identifier;

namespace Undersoft.SDK.Service.UnitTests.Data.Identifier;

/// <summary>
/// Unit tests for the type <see cref="IdentifiersMapping"/>.
/// </summary>
public class IdentifiersMappingTests
{
    private IdentifiersMapping _testClass;
    private IFixture _fixture;
    private Type _type;
    private ModelBuilder _builder;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="IdentifiersMapping"/>.
    /// </summary>
    public IdentifiersMappingTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._type = _fixture.Create<Type>();
        this._builder = _fixture.Create<ModelBuilder>();
        this._testClass = _fixture.Create<IdentifiersMapping>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new IdentifiersMapping(this._type, this._builder);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullType()
    {
        FluentActions.Invoking(() => new IdentifiersMapping(default(Type), this._builder)).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that instance construction throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullBuilder()
    {
        FluentActions.Invoking(() => new IdentifiersMapping(this._type, default(ModelBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Act
        var result = this._testClass.Configure();

        // Assert
        Assert.Fail("Create or modify test");
    }
}