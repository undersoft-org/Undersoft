using System;
using System.Reflection.Emit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math;
using Undersoft.SDK.Instant.Series;

namespace Undersoft.SDK.UnitTests.Instant.Math;

/// <summary>
/// Unit tests for the type <see cref="InstantMathCompilerContext"/>.
/// </summary>
public class InstantMathCompilerContextTests
{
    private InstantMathCompilerContext _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantMathCompilerContext"/>.
    /// </summary>
    public InstantMathCompilerContextTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<InstantMathCompilerContext>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantMathCompilerContext();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the GenLocalLoad method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGenLocalLoad()
    {
        // Arrange
        var g = _fixture.Create<ILGenerator>();
        var a = _fixture.Create<int>();

        // Act
        InstantMathCompilerContext.GenLocalLoad(g, a);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GenLocalLoad method throws when the g parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGenLocalLoadWithNullG()
    {
        FluentActions.Invoking(() => InstantMathCompilerContext.GenLocalLoad(default(ILGenerator), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("g");
    }

    /// <summary>
    /// Checks that the GenLocalStore method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGenLocalStore()
    {
        // Arrange
        var g = _fixture.Create<ILGenerator>();
        var a = _fixture.Create<int>();

        // Act
        InstantMathCompilerContext.GenLocalStore(g, a);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GenLocalStore method throws when the g parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGenLocalStoreWithNullG()
    {
        FluentActions.Invoking(() => InstantMathCompilerContext.GenLocalStore(default(ILGenerator), _fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("g");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAdd()
    {
        // Arrange
        var v = _fixture.Create<IInstantSeries>();

        // Act
        var result = this._testClass.Add(v);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the v parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithNullV()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("v");
    }

    /// <summary>
    /// Checks that the AllocIndexVariable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAllocIndexVariable()
    {
        // Act
        var result = this._testClass.AllocIndexVariable();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GenerateLocalInit method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGenerateLocalInit()
    {
        // Arrange
        var g = _fixture.Create<ILGenerator>();

        // Act
        this._testClass.GenerateLocalInit(g);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GenerateLocalInit method throws when the g parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGenerateLocalInitWithNullG()
    {
        FluentActions.Invoking(() => this._testClass.GenerateLocalInit(default(ILGenerator))).Should().Throw<ArgumentNullException>().WithParameterName("g");
    }

    /// <summary>
    /// Checks that the GetBufforIndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetBufforIndexOf()
    {
        // Arrange
        var v = _fixture.Create<IInstantSeries>();

        // Act
        var result = this._testClass.GetBufforIndexOf(v);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetBufforIndexOf method throws when the v parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetBufforIndexOfWithNullV()
    {
        FluentActions.Invoking(() => this._testClass.GetBufforIndexOf(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("v");
    }

    /// <summary>
    /// Checks that the GetIndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIndexOf()
    {
        // Arrange
        var v = _fixture.Create<IInstantSeries>();

        // Act
        var result = this._testClass.GetIndexOf(v);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIndexOf method throws when the v parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetIndexOfWithNullV()
    {
        FluentActions.Invoking(() => this._testClass.GetIndexOf(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("v");
    }

    /// <summary>
    /// Checks that the GetIndexVariable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIndexVariable()
    {
        // Arrange
        var number = _fixture.Create<int>();

        // Act
        var result = this._testClass.GetIndexVariable(number);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSubIndexOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSubIndexOf()
    {
        // Arrange
        var v = _fixture.Create<IInstantSeries>();

        // Act
        var result = this._testClass.GetSubIndexOf(v);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSubIndexOf method throws when the v parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetSubIndexOfWithNullV()
    {
        FluentActions.Invoking(() => this._testClass.GetSubIndexOf(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("v");
    }

    /// <summary>
    /// Checks that the IsFirstPass method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsFirstPass()
    {
        // Act
        var result = this._testClass.IsFirstPass();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NextPass method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNextPass()
    {
        // Act
        this._testClass.NextPass();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetIndexVariable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetIndexVariable()
    {
        // Arrange
        var number = _fixture.Create<int>();
        var value = _fixture.Create<int>();

        // Act
        this._testClass.SetIndexVariable(number, value);

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
    /// Checks that the ParamItems property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetParamItems()
    {
        // Assert
        this._testClass.ParamItems.Should().BeAssignableTo<IInstantSeries[]>();

        Assert.Fail("Create or modify test");
    }
}