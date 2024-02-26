using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event.Bus;
using TEvent = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Bus;

/// <summary>
/// Unit tests for the type <see cref="EventNameAttribute"/>.
/// </summary>
public class EventNameAttributeTests
{
    private EventNameAttribute _testClass;
    private IFixture _fixture;
    private string _name;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventNameAttribute"/>.
    /// </summary>
    public EventNameAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._name = _fixture.Create<string>();
        this._testClass = _fixture.Create<EventNameAttribute>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EventNameAttribute(this._name);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidName(string value)
    {
        FluentActions.Invoking(() => new EventNameAttribute(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the GetNameOrDefault method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetNameOrDefaultWithNoParameters()
    {
        // Act
        var result = EventNameAttribute.GetNameOrDefault<TEvent>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetNameOrDefault method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetNameOrDefaultWithType()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();

        // Act
        var result = EventNameAttribute.GetNameOrDefault(eventType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetNameOrDefault method throws when the eventType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetNameOrDefaultWithTypeWithNullEventType()
    {
        FluentActions.Invoking(() => EventNameAttribute.GetNameOrDefault(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }

    /// <summary>
    /// Checks that the GetName method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetName()
    {
        // Arrange
        var eventType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetName(eventType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetName method throws when the eventType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetNameWithNullEventType()
    {
        FluentActions.Invoking(() => this._testClass.GetName(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("eventType");
    }
}