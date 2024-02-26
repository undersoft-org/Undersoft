using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant.Attributes;

namespace Undersoft.SDK.UnitTests.Instant.Attributes;

/// <summary>
/// Unit tests for the type <see cref="InstantAttribute"/>.
/// </summary>
public class InstantAttributeTests
{
    private InstantAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantAttribute"/>.
    /// </summary>
    public InstantAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<InstantAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantAttribute();

        // Assert
        instance.Should().NotBeNull();
    }
}