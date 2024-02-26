using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Client.Attributes;

namespace Undersoft.SDK.Service.UnitTests.Data.Client.Attributes;

/// <summary>
/// Unit tests for the type <see cref="ServiceClientAttribute"/>.
/// </summary>
public class ServiceClientAttributeTests
{
    private ServiceClientAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServiceClientAttribute"/>.
    /// </summary>
    public ServiceClientAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<ServiceClientAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ServiceClientAttribute();

        // Assert
        instance.Should().NotBeNull();
    }
}