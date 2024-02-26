using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server;

namespace Undersoft.SDK.Service.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="RemoteResultAttribute"/>.
/// </summary>
[TestClass]
public class RemoteResultAttributeTests
{
    private RemoteResultAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteResultAttribute"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RemoteResultAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteResultAttribute();

        // Assert
        instance.Should().NotBeNull();
    }
}