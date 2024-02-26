using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Proxies;
using R = System.String;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Proxies;

/// <summary>
/// Unit tests for the type <see cref="ProxyExtensions"/>.
/// </summary>
public class ProxyExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ValueOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueOfWithTAndString()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var name = _fixture.Create<string>();

        // Act
        var result = item.ValueOf<T, R>(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithTAndStringWithNullItem()
    {
        FluentActions.Invoking(() => default(T).ValueOf<T, R>(_fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallValueOfWithTAndStringWithInvalidName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<T>().ValueOf<T, R>(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ValueOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueOfWithRAndObjectAndString()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var name = _fixture.Create<string>();

        // Act
        var result = item.ValueOf<R>(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithRAndObjectAndStringWithNullItem()
    {
        FluentActions.Invoking(() => default(object).ValueOf<R>(_fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallValueOfWithRAndObjectAndStringWithInvalidName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().ValueOf<R>(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ValueOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueOfWithObjectAndString()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var name = _fixture.Create<string>();

        // Act
        var result = item.ValueOf(name);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithObjectAndStringWithNullItem()
    {
        FluentActions.Invoking(() => default(object).ValueOf(_fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallValueOfWithObjectAndStringWithInvalidName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().ValueOf(value)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ValueOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueOfWithTAndInt()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var index = _fixture.Create<int>();

        // Act
        var result = item.ValueOf<T, R>(index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithTAndIntWithNullItem()
    {
        FluentActions.Invoking(() => default(T).ValueOf<T, R>(_fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ValueOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueOfWithRAndObjectAndInt()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var index = _fixture.Create<int>();

        // Act
        var result = item.ValueOf<R>(index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithRAndObjectAndIntWithNullItem()
    {
        FluentActions.Invoking(() => default(object).ValueOf<R>(_fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ValueOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueOfWithObjectAndInt()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var index = _fixture.Create<int>();

        // Act
        var result = item.ValueOf(index);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithObjectAndIntWithNullItem()
    {
        FluentActions.Invoking(() => default(object).ValueOf(_fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ValueOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueOfWithTAndStringAndR()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var name = _fixture.Create<string>();
        var value = _fixture.Create<R>();

        // Act
        var result = item.ValueOf<T, R>(name, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithTAndStringAndRWithNullItem()
    {
        FluentActions.Invoking(() => default(T).ValueOf<T, R>(_fixture.Create<string>(), _fixture.Create<R>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallValueOfWithTAndStringAndRWithInvalidName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<T>().ValueOf<T, R>(value, _fixture.Create<R>())).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ValueOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueOfWithObjectAndStringAndR()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var name = _fixture.Create<string>();
        var value = _fixture.Create<R>();

        // Act
        var result = item.ValueOf<R>(name, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithObjectAndStringAndRWithNullItem()
    {
        FluentActions.Invoking(() => default(object).ValueOf<R>(_fixture.Create<string>(), _fixture.Create<R>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallValueOfWithObjectAndStringAndRWithInvalidName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().ValueOf<R>(value, _fixture.Create<R>())).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ValueOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueOfWithObjectAndStringAndObject()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var name = _fixture.Create<string>();
        var value = _fixture.Create<object>();

        // Act
        var result = item.ValueOf(name, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithObjectAndStringAndObjectWithNullItem()
    {
        FluentActions.Invoking(() => default(object).ValueOf(_fixture.Create<string>(), _fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithObjectAndStringAndObjectWithNullValue()
    {
        FluentActions.Invoking(() => _fixture.Create<object>().ValueOf(_fixture.Create<string>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallValueOfWithObjectAndStringAndObjectWithInvalidName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<object>().ValueOf(value, _fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the ValueOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueOfWithTAndIntAndR()
    {
        // Arrange
        var item = _fixture.Create<T>();
        var index = _fixture.Create<int>();
        var value = _fixture.Create<R>();

        // Act
        var result = item.ValueOf<T, R>(index, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithTAndIntAndRWithNullItem()
    {
        FluentActions.Invoking(() => default(T).ValueOf<T, R>(_fixture.Create<int>(), _fixture.Create<R>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ValueOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueOfWithObjectAndIntAndR()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var index = _fixture.Create<int>();
        var value = _fixture.Create<R>();

        // Act
        var result = item.ValueOf<R>(index, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithObjectAndIntAndRWithNullItem()
    {
        FluentActions.Invoking(() => default(object).ValueOf<R>(_fixture.Create<int>(), _fixture.Create<R>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ValueOf method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallValueOfWithObjectAndIntAndObject()
    {
        // Arrange
        var item = _fixture.Create<object>();
        var index = _fixture.Create<int>();
        var value = _fixture.Create<object>();

        // Act
        var result = item.ValueOf(index, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the item parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithObjectAndIntAndObjectWithNullItem()
    {
        FluentActions.Invoking(() => default(object).ValueOf(_fixture.Create<int>(), _fixture.Create<object>())).Should().Throw<ArgumentNullException>().WithParameterName("item");
    }

    /// <summary>
    /// Checks that the ValueOf method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallValueOfWithObjectAndIntAndObjectWithNullValue()
    {
        FluentActions.Invoking(() => _fixture.Create<object>().ValueOf(_fixture.Create<int>(), default(object))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }
}