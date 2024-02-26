using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swashbuckle.AspNetCore.SwaggerGen;
using Undersoft.SDK.Service.Server.Documentation;

namespace Undersoft.SDK.Service.Server.UnitTests.Documentation;

/// <summary>
/// Unit tests for the type <see cref="IgnoreApiDocument"/>.
/// </summary>
[TestClass]
public class IgnoreApiDocumentTests
{
    private IgnoreApiDocument _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="IgnoreApiDocument"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<IgnoreApiDocument>();
    }

    /// <summary>
    /// Checks that the Apply method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallApply()
    {
        // Arrange
        var swaggerDoc = _fixture.Create<OpenApiDocument>();
        var context = _fixture.Create<DocumentFilterContext>();

        // Act
        this._testClass.Apply(swaggerDoc, context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Apply method throws when the swaggerDoc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyWithNullSwaggerDoc()
    {
        FluentActions.Invoking(() => this._testClass.Apply(default(OpenApiDocument), _fixture.Create<DocumentFilterContext>())).Should().Throw<ArgumentNullException>().WithParameterName("swaggerDoc");
    }

    /// <summary>
    /// Checks that the Apply method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyWithNullContext()
    {
        FluentActions.Invoking(() => this._testClass.Apply(_fixture.Create<OpenApiDocument>(), default(DocumentFilterContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }
}

/// <summary>
/// Unit tests for the type <see cref="AuthorizeCheckOperationFilter"/>.
/// </summary>
[TestClass]
public class AuthorizeCheckOperationFilterTests
{
    private AuthorizeCheckOperationFilter _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="AuthorizeCheckOperationFilter"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<AuthorizeCheckOperationFilter>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new AuthorizeCheckOperationFilter();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Apply method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallApply()
    {
        // Arrange
        var operation = _fixture.Create<OpenApiOperation>();
        var context = _fixture.Create<OperationFilterContext>();

        // Act
        this._testClass.Apply(operation, context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Apply method throws when the operation parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyWithNullOperation()
    {
        FluentActions.Invoking(() => this._testClass.Apply(default(OpenApiOperation), _fixture.Create<OperationFilterContext>())).Should().Throw<ArgumentNullException>().WithParameterName("operation");
    }

    /// <summary>
    /// Checks that the Apply method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyWithNullContext()
    {
        FluentActions.Invoking(() => this._testClass.Apply(_fixture.Create<OpenApiOperation>(), default(OperationFilterContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }
}

/// <summary>
/// Unit tests for the type <see cref="JsonIgnoreFilter"/>.
/// </summary>
[TestClass]
public class JsonIgnoreFilterTests
{
    private JsonIgnoreFilter _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="JsonIgnoreFilter"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<JsonIgnoreFilter>();
    }

    /// <summary>
    /// Checks that the Apply method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallApply()
    {
        // Arrange
        var operation = _fixture.Create<OpenApiOperation>();
        var context = _fixture.Create<OperationFilterContext>();

        // Act
        this._testClass.Apply(operation, context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Apply method throws when the operation parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyWithNullOperation()
    {
        FluentActions.Invoking(() => this._testClass.Apply(default(OpenApiOperation), _fixture.Create<OperationFilterContext>())).Should().Throw<ArgumentNullException>().WithParameterName("operation");
    }

    /// <summary>
    /// Checks that the Apply method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyWithNullContext()
    {
        FluentActions.Invoking(() => this._testClass.Apply(_fixture.Create<OpenApiOperation>(), default(OperationFilterContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }
}

/// <summary>
/// Unit tests for the type <see cref="SwaggerExcludeAttribute"/>.
/// </summary>
[TestClass]
public class SwaggerExcludeAttributeTests
{
    private SwaggerExcludeAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SwaggerExcludeAttribute"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<SwaggerExcludeAttribute>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="SwaggerExcludeFilter"/>.
/// </summary>
[TestClass]
public class SwaggerExcludeFilterTests
{
    private SwaggerExcludeFilter _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SwaggerExcludeFilter"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<SwaggerExcludeFilter>();
    }

    /// <summary>
    /// Checks that the Apply method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallApply()
    {
        // Arrange
        var schema = _fixture.Create<OpenApiSchema>();
        var context = _fixture.Create<SchemaFilterContext>();

        // Act
        this._testClass.Apply(schema, context);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Apply method throws when the schema parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyWithNullSchema()
    {
        FluentActions.Invoking(() => this._testClass.Apply(default(OpenApiSchema), _fixture.Create<SchemaFilterContext>())).Should().Throw<ArgumentNullException>().WithParameterName("schema");
    }

    /// <summary>
    /// Checks that the Apply method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallApplyWithNullContext()
    {
        FluentActions.Invoking(() => this._testClass.Apply(_fixture.Create<OpenApiSchema>(), default(SchemaFilterContext))).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }
}