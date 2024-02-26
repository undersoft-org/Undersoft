using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Client.Attributes;

namespace Undersoft.SDK.Service.UnitTests.Data.Client.Attributes;

/// <summary>
/// Unit tests for the type <see cref="ApiDataAttribute"/>.
/// </summary>
public class ApiDataAttributeTests
{
    private ApiDataAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ApiDataAttribute"/>.
    /// </summary>
    public ApiDataAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<ApiDataAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ApiDataAttribute();

        // Assert
        instance.Should().NotBeNull();
    }
}