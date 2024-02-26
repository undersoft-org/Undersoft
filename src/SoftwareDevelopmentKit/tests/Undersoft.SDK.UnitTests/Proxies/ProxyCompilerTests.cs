using System;
using System.Reflection.Emit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.UnitTests.Proxies;

/// <summary>
/// Unit tests for the type <see cref="ProxyCompiler"/>.
/// </summary>
public class ProxyCompilerTests
{
    private ProxyCompiler _testClass;
    private IFixture _fixture;
    private ProxyCreator _instantSleeve;
    private Mock<ISeries<RubricModel>> _rubricBuilders;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ProxyCompiler"/>.
    /// </summary>
    public ProxyCompilerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._instantSleeve = _fixture.Create<ProxyCreator>();
        this._rubricBuilders = _fixture.Freeze<Mock<ISeries<RubricModel>>>();
        this._testClass = _fixture.Create<ProxyCompiler>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ProxyCompiler(this._instantSleeve, this._rubricBuilders.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the instantSleeve parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantSleeve()
    {
        FluentActions.Invoking(() => new ProxyCompiler(default(ProxyCreator), this._rubricBuilders.Object)).Should().Throw<ArgumentNullException>().WithParameterName("instantSleeve");
    }

    /// <summary>
    /// Checks that instance construction throws when the rubricBuilders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRubricBuilders()
    {
        FluentActions.Invoking(() => new ProxyCompiler(this._instantSleeve, default(ISeries<RubricModel>))).Should().Throw<ArgumentNullException>().WithParameterName("rubricBuilders");
    }

    /// <summary>
    /// Checks that the CompileProxyType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompileProxyType()
    {
        // Arrange
        var typeName = _fixture.Create<string>();

        // Act
        var result = this._testClass.CompileProxyType(typeName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompileProxyType method throws when the typeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCompileProxyTypeWithInvalidTypeName(string value)
    {
        FluentActions.Invoking(() => this._testClass.CompileProxyType(value)).Should().Throw<ArgumentNullException>().WithParameterName("typeName");
    }

    /// <summary>
    /// Checks that the CreateCompareToMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateCompareToMethod()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateCompareToMethod(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateCompareToMethod method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateCompareToMethodWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateCompareToMethod(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateEqualsMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateEqualsMethod()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateEqualsMethod(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateEqualsMethod method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateEqualsMethodWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateEqualsMethod(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateFieldsAndProperties method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateFieldsAndProperties()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateFieldsAndProperties(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateFieldsAndProperties method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateFieldsAndPropertiesWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateFieldsAndProperties(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateGetBytesMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateGetBytesMethod()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateGetBytesMethod(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateGetBytesMethod method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateGetBytesMethodWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateGetBytesMethod(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateGetEmptyProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateGetEmptyProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateGetEmptyProperty(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateGetEmptyProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateGetEmptyPropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateGetEmptyProperty(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateGetIdBytesMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateGetIdBytesMethod()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateGetIdBytesMethod(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateGetIdBytesMethod method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateGetIdBytesMethodWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateGetIdBytesMethod(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateTargetProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateTargetProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();
        var @type = _fixture.Create<Type>();
        var name = _fixture.Create<string>();

        // Act
        this._testClass.CreateTargetProperty(tb, type, name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateTargetProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateTargetPropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateTargetProperty(default(TypeBuilder), _fixture.Create<Type>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateTargetProperty method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateTargetPropertyWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.CreateTargetProperty(_fixture.Create<TypeBuilder>(), default(Type), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the CreateTargetProperty method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCreateTargetPropertyWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.CreateTargetProperty(_fixture.Create<TypeBuilder>(), _fixture.Create<Type>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the CreateItemByIntProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateItemByIntProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateItemByIntProperty(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateItemByIntProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateItemByIntPropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateItemByIntProperty(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateItemByStringProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateItemByStringProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateItemByStringProperty(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateItemByStringProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateItemByStringPropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateItemByStringProperty(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateCodeProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateCodeProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();
        var @type = _fixture.Create<Type>();
        var name = _fixture.Create<string>();

        // Act
        this._testClass.CreateCodeProperty(tb, type, name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateCodeProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateCodePropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateCodeProperty(default(TypeBuilder), _fixture.Create<Type>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateCodeProperty method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateCodePropertyWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.CreateCodeProperty(_fixture.Create<TypeBuilder>(), default(Type), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the CreateCodeProperty method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCreateCodePropertyWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.CreateCodeProperty(_fixture.Create<TypeBuilder>(), _fixture.Create<Type>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the CreateRubricsProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateRubricsProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();
        var @type = _fixture.Create<Type>();
        var name = _fixture.Create<string>();

        // Act
        this._testClass.CreateRubricsProperty(tb, type, name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateRubricsProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateRubricsPropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateRubricsProperty(default(TypeBuilder), _fixture.Create<Type>(), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateRubricsProperty method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateRubricsPropertyWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.CreateRubricsProperty(_fixture.Create<TypeBuilder>(), default(Type), _fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the CreateRubricsProperty method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallCreateRubricsPropertyWithInvalidName(string value)
    {
        FluentActions.Invoking(() => this._testClass.CreateRubricsProperty(_fixture.Create<TypeBuilder>(), _fixture.Create<Type>(), value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the CreateIdProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateIdProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateIdProperty(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateIdProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateIdPropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateIdProperty(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateTypeIdProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateTypeIdProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateTypeIdProperty(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateTypeIdProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateTypeIdPropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateTypeIdProperty(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateValueArrayProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateValueArrayProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateValueArrayProperty(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateValueArrayProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateValueArrayPropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateValueArrayProperty(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the GetTypeBuilder method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetTypeBuilder()
    {
        // Arrange
        var typeName = _fixture.Create<string>();

        // Act
        var result = this._testClass.GetTypeBuilder(typeName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetTypeBuilder method throws when the typeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetTypeBuilderWithInvalidTypeName(string value)
    {
        FluentActions.Invoking(() => this._testClass.GetTypeBuilder(value)).Should().Throw<ArgumentNullException>().WithParameterName("typeName");
    }
}