using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Client.Attributes;

namespace Undersoft.SDK.Service.UnitTests.Data.Client.Attributes;

/// <summary>
/// Unit tests for the type <see cref="OpenServiceAttribute"/>.
/// </summary>
public class OpenServiceAttributeTests
{
    private OpenServiceAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="OpenServiceAttribute"/>.
    /// </summary>
    public OpenServiceAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<OpenServiceAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new OpenServiceAttribute();

        // Assert
        instance.Should().NotBeNull();
    }
}