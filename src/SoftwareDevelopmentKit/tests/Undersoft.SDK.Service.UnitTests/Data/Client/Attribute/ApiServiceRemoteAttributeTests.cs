using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Client.Attributes;

namespace Undersoft.SDK.Service.UnitTests.Data.Client.Attributes;

/// <summary>
/// Unit tests for the type <see cref="ApiServiceRemoteAttribute"/>.
/// </summary>
public class ApiServiceRemoteAttributeTests
{
    private ApiServiceRemoteAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ApiServiceRemoteAttribute"/>.
    /// </summary>
    public ApiServiceRemoteAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<ApiServiceRemoteAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ApiServiceRemoteAttribute();

        // Assert
        instance.Should().NotBeNull();
    }
}