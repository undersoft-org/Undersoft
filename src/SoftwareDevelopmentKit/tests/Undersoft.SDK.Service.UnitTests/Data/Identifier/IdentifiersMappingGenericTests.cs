using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Identifier;
using TObject = Undersoft.SDK.Stocks.StockContext;

namespace Undersoft.SDK.Service.UnitTests.Data.Identifier;

/// <summary>
/// Unit tests for the type <see cref="IdentifiersMapping"/>.
/// </summary>
public class IdentifiersMapping_1Tests
{
    private IdentifiersMapping<TObject> _testClass;
    private IFixture _fixture;
    private ModelBuilder _builder;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="IdentifiersMapping"/>.
    /// </summary>
    public IdentifiersMapping_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._builder = _fixture.Create<ModelBuilder>();
        this._testClass = _fixture.Create<IdentifiersMapping<TObject>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new IdentifiersMapping<TObject>(this._builder);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullBuilder()
    {
        FluentActions.Invoking(() => new IdentifiersMapping<TObject>(default(ModelBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
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