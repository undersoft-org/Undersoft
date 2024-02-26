using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Proxies;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Proxies;

/// <summary>
/// Unit tests for the type <see cref="ProxyFactoryExtensions"/>.
/// </summary>
public class ProxyFactoryExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetProxyCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetProxyCreatorWithObject()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = item.GetProxyCreator();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetProxyCreator method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetProxyCreatorWithObjectWithNullItem()
    {
        FluentActions.Invoking(() => default(object).GetProxyCreator()).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the GetProxyCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetProxyCreatorWithTAndT()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = item.GetProxyCreator<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToProxy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToProxyWithObject()
    {
        // Arrange
        var item = _fixture.Create<object>();

        // Act
        var result = item.ToProxy();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToProxy method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToProxyWithObjectWithNullItem()
    {
        FluentActions.Invoking(() => default(object).ToProxy()).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ToProxy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToProxyWithTAndT()
    {
        // Arrange
        var item = _fixture.Create<T>();

        // Act
        var result = item.ToProxy<T>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToProxy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToProxyWithType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = type.ToProxy();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToProxy method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToProxyWithTypeWithNullType()
    {
        FluentActions.Invoking(() => default(Type).ToProxy()).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }
}