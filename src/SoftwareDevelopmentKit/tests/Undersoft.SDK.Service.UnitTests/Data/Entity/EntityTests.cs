using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Entity;

namespace Undersoft.SDK.Service.UnitTests.Data.Entity;

/// <summary>
/// Unit tests for the type <see cref="Entity"/>.
/// </summary>
public class EntityTests
{
    private Entity _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Entity"/>.
    /// </summary>
    public EntityTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Entity>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Entity();

        // Assert
        instance.Should().NotBeNull();
    }
}