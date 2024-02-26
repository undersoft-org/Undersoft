using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Swashbuckle.AspNetCore.SwaggerGen;
using Undersoft.SDK.Service.Server.Documentation;

namespace Undersoft.SDK.Service.Server.UnitTests.Documentation;

/// <summary>
/// Unit tests for the type <see cref="OpenApiOptions"/>.
/// </summary>
[TestClass]
public class OpenApiOptionsTests
{
    private OpenApiOptions _testClass;
    private IFixture _fixture;
    private Mock<IApiVersionDescriptionProvider> _provider;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="OpenApiOptions"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._provider = _fixture.Freeze<Mock<IApiVersionDescriptionProvider>>();
        this._testClass = _fixture.Create<OpenApiOptions>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new OpenApiOptions(this._provider.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the provider parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullProvider()
    {
        FluentActions.Invoking(() => new OpenApiOptions(default(IApiVersionDescriptionProvider))).Should().Throw<ArgumentNullException>().WithParameterName("provider");
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Arrange
        var options = _fixture.Create<SwaggerGenOptions>();

        _provider.Setup(mock => mock.ApiVersionDescriptions).Returns(_fixture.Create<IReadOnlyList<ApiVersionDescription>>());

        // Act
        this._testClass.Configure(options);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithNullOptions()
    {
        FluentActions.Invoking(() => this._testClass.Configure(default(SwaggerGenOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }
}