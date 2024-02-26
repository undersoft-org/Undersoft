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
/// Unit tests for the type <see cref="OpenApiDefaultValues"/>.
/// </summary>
[TestClass]
public class OpenApiDefaultValuesTests
{
    private OpenApiDefaultValues _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="OpenApiDefaultValues"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<OpenApiDefaultValues>();
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