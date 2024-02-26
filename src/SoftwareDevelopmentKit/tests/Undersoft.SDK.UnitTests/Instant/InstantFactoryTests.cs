using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Instant;

/// <summary>
/// Unit tests for the type <see cref="InstantFactory"/>.
/// </summary>
public class InstantFactoryTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetCompiledCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCompiledCreatorWithMode()
    {
        // Arrange
        var mode = _fixture.Create<InstantType>();

        // Act
        var result = InstantFactory.GetCompiledCreator<T>(mode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCompiledCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCompiledCreatorWithTypeAndMode()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var mode = _fixture.Create<InstantType>();

        // Act
        var result = InstantFactory.GetCompiledCreator(type, mode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCompiledCreator method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetCompiledCreatorWithTypeAndModeWithNullType()
    {
        FluentActions.Invoking(() => InstantFactory.GetCompiledCreator(default(Type), _fixture.Create<InstantType>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetCompiledCreator maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetCompiledCreatorWithTypeAndModePerformsMapping()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var mode = _fixture.Create<InstantType>();

        // Act
        var result = InstantFactory.GetCompiledCreator(type, mode);

        // Assert
        result.Type.Should().BeSameAs(type);
    }

    /// <summary>
    /// Checks that the GetCompiledCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCompiledCreatorWithObjectAndInstantType()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var mode = _fixture.Create<InstantType>();

        // Act
        var result = InstantFactory.GetCompiledCreator(item, mode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCompiledCreator method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetCompiledCreatorWithObjectAndInstantTypeWithNullItem()
    {
        FluentActions.Invoking(() => InstantFactory.GetCompiledCreator(default(object), _fixture.Create<InstantType>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the GetCompiledCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCompiledCreatorWithTAndTAndInstantType()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var mode = _fixture.Create<InstantType>();

        // Act
        var result = InstantFactory.GetCompiledCreator<T>(item, mode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateWithObjectAndInstantType()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var mode = _fixture.Create<InstantType>();

        // Act
        var result = InstantFactory.Create(item, mode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateWithObjectAndInstantTypeWithNullItem()
    {
        FluentActions.Invoking(() => InstantFactory.Create(default(object), _fixture.Create<InstantType>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateWithTAndTAndInstantType()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var mode = _fixture.Create<InstantType>();

        // Act
        var result = InstantFactory.Create<T>(item, mode);

        // Assert
        Assert.Fail("Create or modify test");
    }
}