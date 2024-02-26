using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Remote.Repository;

namespace Undersoft.SDK.Service.UnitTests.Data.Remote.Repository;

/// <summary>
/// Unit tests for the type <see cref="RemoteAttribute"/>.
/// </summary>
public class RemoteAttributeTests
{
    private RemoteAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteAttribute"/>.
    /// </summary>
    public RemoteAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RemoteAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteAttribute();

        // Assert
        instance.Should().NotBeNull();
    }
}