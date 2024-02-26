using System;
using System.Reflection.Emit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Math;
using Undersoft.SDK.Instant.Math.Set;
using Undersoft.SDK.Instant.Series;

namespace Undersoft.SDK.UnitTests.Instant.Math.Set;

/// <summary>
/// Unit tests for the type <see cref="SubMathSet"/>.
/// </summary>
public class SubMathSetTests
{
    private SubMathSet _testClass;
    private IFixture _fixture;
    private MathSetFormula _evalRubric;
    private MathSet _formuler;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SubMathSet"/>.
    /// </summary>
    public SubMathSetTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._evalRubric = _fixture.Create<MathSetFormula>();
        this._formuler = _fixture.Create<MathSet>();
        this._testClass = _fixture.Create<SubMathSet>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SubMathSet(this._evalRubric, this._formuler);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the evalRubric parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullEvalRubric()
    {
        FluentActions.Invoking(() => new SubMathSet(default(MathSetFormula), this._formuler)).Should().Throw<ArgumentNullException>().WithParameterName("evalRubric");
    }

    /// <summary>
    /// Checks that instance construction throws when the formuler parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullFormuler()
    {
        FluentActions.Invoking(() => new SubMathSet(this._evalRubric, default(MathSet))).Should().Throw<ArgumentNullException>().WithParameterName("formuler");
    }

    /// <summary>
    /// Checks that the Compile method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompile()
    {
        // Arrange
        var g = _fixture.Create<ILGenerator>();
        var cc = _fixture.Create<InstantMathCompilerContext>();

        // Act
        this._testClass.Compile(g, cc);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Compile method throws when the g parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileWithNullG()
    {
        FluentActions.Invoking(() => this._testClass.Compile(default(ILGenerator), _fixture.Create<InstantMathCompilerContext>())).Should().Throw<ArgumentNullException>().WithParameterName("g");
    }

    /// <summary>
    /// Checks that the Compile method throws when the cc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileWithNullCc()
    {
        FluentActions.Invoking(() => this._testClass.Compile(_fixture.Create<ILGenerator>(), default(InstantMathCompilerContext))).Should().Throw<ArgumentNullException>().WithParameterName("cc");
    }

    /// <summary>
    /// Checks that the CompileAssign method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileAssign()
    {
        // Arrange
        var g = _fixture.Create<ILGenerator>();
        var cc = _fixture.Create<InstantMathCompilerContext>();
        var post = _fixture.Create<bool>();
        var @partial = _fixture.Create<bool>();

        // Act
        this._testClass.CompileAssign(g, cc, post, partial
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileAssign method throws when the g parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileAssignWithNullG()
    {
        FluentActions.Invoking(() => this._testClass.CompileAssign(default(ILGenerator), _fixture.Create<InstantMathCompilerContext>(), _fixture.Create<bool>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("g");
    }

    /// <summary>
    /// Checks that the CompileAssign method throws when the cc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompileAssignWithNullCc()
    {
        FluentActions.Invoking(() => this._testClass.CompileAssign(_fixture.Create<ILGenerator>(), default(InstantMathCompilerContext), _fixture.Create<bool>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("cc");
    }

    /// <summary>
    /// Checks that the SetDimensions method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetDimensions()
    {
        // Arrange
        var formuler = _fixture.Create<MathSet>();

        // Act
        this._testClass.SetDimensions(formuler);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the colCount property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetcolCount()
    {
        // Assert
        this._testClass.colCount.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Data property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetData()
    {
        // Assert
        this._testClass.Data.Should().BeAssignableTo<IInstantSeries>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FieldId property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetFieldId()
    {
        // Assert
        this._testClass.FieldId.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Formuler property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFormuler()
    {
        // Arrange
        var testValue = _fixture.Create<MathSet>();

        // Act
        this._testClass.Formuler = testValue;

        // Assert
        this._testClass.Formuler.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the rowCount property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetrowCount()
    {
        // Assert
        this._testClass.rowCount.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Rubric property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubric()
    {
        // Arrange
        var testValue = _fixture.Create<MathSetFormula>();

        // Act
        this._testClass.Rubric = testValue;

        // Assert
        this._testClass.Rubric.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the RubricName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRubricName()
    {
        // Assert
        this._testClass.RubricName.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RubricType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRubricType()
    {
        // Assert
        this._testClass.RubricType.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Size property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSize()
    {
        // Assert
        this._testClass.Size.Should().BeAssignableTo<MathSetSize>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SubFormuler property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSubFormuler()
    {
        // Arrange
        var testValue = _fixture.Create<SubMathSet>();

        // Act
        this._testClass.SubFormuler = testValue;

        // Assert
        this._testClass.SubFormuler.Should().BeSameAs(testValue);
    }
}