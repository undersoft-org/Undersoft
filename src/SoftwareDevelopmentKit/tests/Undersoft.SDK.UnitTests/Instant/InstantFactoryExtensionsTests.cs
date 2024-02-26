using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Instant;

/// <summary>
/// Unit tests for the type <see cref="InstantFactoryExtensions"/>.
/// </summary>
public class InstantFactoryExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ToInstant method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToInstantWithTAndTAndInstantType()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var mode = _fixture.Create<InstantType>();

        // Act
        var result = item.ToInstant<T>(mode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToInstant method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToInstantWithTypeAndMode()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var mode = _fixture.Create<InstantType>();

        // Act
        var result = type.ToInstant(mode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToInstant method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToInstantWithTypeAndModeWithNullType()
    {
        FluentActions.Invoking(() => default(Type).ToInstant(_fixture.Create<InstantType>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetInstantCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetInstantCreatorWithObjectAndInstantType()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var mode = _fixture.Create<InstantType>();

        // Act
        var result = item.GetInstantCreator(mode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetInstantCreator method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetInstantCreatorWithObjectAndInstantTypeWithNullItem()
    {
        FluentActions.Invoking(() => default(object).GetInstantCreator(_fixture.Create<InstantType>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the GetInstantCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetInstantCreatorWithTAndTAndInstantType()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var mode = _fixture.Create<InstantType>();

        // Act
        var result = item.GetInstantCreator<T>(mode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToInstant method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToInstantWithObjectAndInstantType()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var mode = _fixture.Create<InstantType>();

        // Act
        var result = item.ToInstant(mode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToInstant method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToInstantWithObjectAndInstantTypeWithNullItem()
    {
        FluentActions.Invoking(() => default(object).ToInstant(_fixture.Create<InstantType>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }
}