using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Proxies;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Proxies;

/// <summary>
/// Unit tests for the type <see cref="ProxyFactory"/>.
/// </summary>
public class ProxyFactoryTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCreatorWithT()
    {
        // Act
        var result = ProxyFactory.GetCreator<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCreatorWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = ProxyFactory.GetCreator(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCreator method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetCreatorWithTypeWithNullType()
    {
        FluentActions.Invoking(() => ProxyFactory.GetCreator(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetCreator maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetCreatorWithTypePerformsMapping()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = ProxyFactory.GetCreator(type);

        // Assert
        result.Type.Should().BeSameAs(type);
    }

    /// <summary>
    /// Checks that the GetCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCreatorWithTypeAndKey()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var key = _fixture.Create<long>();

        // Act
        var result = ProxyFactory.GetCreator(type, key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCreator method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetCreatorWithTypeAndKeyWithNullType()
    {
        FluentActions.Invoking(() => ProxyFactory.GetCreator(default(Type), _fixture.Create<long>())).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetCreator maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetCreatorWithTypeAndKeyPerformsMapping()
    {
        // Arrange
        var @type = _fixture.Create<Type>();
        var key = _fixture.Create<long>();

        // Act
        var result = ProxyFactory.GetCreator(type, key);

        // Assert
        result.Type.Should().BeSameAs(type);
    }

    /// <summary>
    /// Checks that the GetCompiledCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCompiledCreatorWithT()
    {
        // Act
        var result = ProxyFactory.GetCompiledCreator<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCompiledCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCompiledCreatorWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = ProxyFactory.GetCompiledCreator(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCompiledCreator method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetCompiledCreatorWithTypeWithNullType()
    {
        FluentActions.Invoking(() => ProxyFactory.GetCompiledCreator(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetCompiledCreator maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetCompiledCreatorWithTypePerformsMapping()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = ProxyFactory.GetCompiledCreator(type);

        // Assert
        result.Type.Should().BeSameAs(type);
    }

    /// <summary>
    /// Checks that the GetCompiledCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCompiledCreatorWithObject()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = ProxyFactory.GetCompiledCreator(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCompiledCreator method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetCompiledCreatorWithObjectWithNullItem()
    {
        FluentActions.Invoking(() => ProxyFactory.GetCompiledCreator(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the GetCompiledCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCompiledCreatorWithTAndT()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = ProxyFactory.GetCompiledCreator<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateWithObject()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = ProxyFactory.Create(item);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateWithObjectWithNullItem()
    {
        FluentActions.Invoking(() => ProxyFactory.Create(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateWithTAndT()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = ProxyFactory.Create<T>(item);

        // Assert
        Assert.Fail("Create or modify test");
    }
}