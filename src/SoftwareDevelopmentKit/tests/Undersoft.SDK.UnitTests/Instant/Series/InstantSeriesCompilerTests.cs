using System;
using System.Reflection.Emit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Series;

namespace Undersoft.SDK.UnitTests.Instant.Series;

/// <summary>
/// Unit tests for the type <see cref="InstantSeriesCompiler"/>.
/// </summary>
public class InstantSeriesCompilerTests
{
    private InstantSeriesCompiler _testClass;
    private IFixture _fixture;
    private InstantSeriesCreator _instantInstantSeriesCreator;
    private bool _safeThread;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSeriesCompiler"/>.
    /// </summary>
    public InstantSeriesCompilerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._instantInstantSeriesCreator = _fixture.Create<InstantSeriesCreator>();
        this._safeThread = _fixture.Create<bool>();
        this._testClass = _fixture.Create<InstantSeriesCompiler>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSeriesCompiler(this._instantInstantSeriesCreator, this._safeThread);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the instantInstantSeriesCreator parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantInstantSeriesCreator()
    {
        FluentActions.Invoking(() => new InstantSeriesCompiler(default(InstantSeriesCreator), this._safeThread)).Should().Throw<ArgumentNullException>().WithParameterName("instantInstantSeriesCreator");
    }

    /// <summary>
    /// Checks that the CompileInstantType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileInstantType()
    {
        // Arrange
        var typeName = _fixture.Create<string>();

        // Act
        var result = this._testClass.CompileInstantType(typeName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileInstantType method throws when the typeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCompileInstantTypeWithInvalidTypeName(string value)
    {
        FluentActions.Invoking(() => this._testClass.CompileInstantType(value)).Should().Throw<ArgumentNullException>().WithParameterName("typeName");
    }

    /// <summary>
    /// Checks that the CreateUniqueKeyProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateUniqueKeyProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateUniqueKeyProperty(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateUniqueKeyProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateUniqueKeyPropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateUniqueKeyProperty(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateUniqueTypeKeyProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateUniqueTypeKeyProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateUniqueTypeKeyProperty(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateUniqueTypeKeyProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateUniqueTypeKeyPropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateUniqueTypeKeyProperty(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }
}