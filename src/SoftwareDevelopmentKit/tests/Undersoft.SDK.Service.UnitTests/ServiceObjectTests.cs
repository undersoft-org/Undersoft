using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service;
using T = System.String;

namespace Undersoft.SDK.Service.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ServiceObject"/>.
/// </summary>
public class ServiceObject_1Tests
{
    private ServiceObject<T> _testClass;
    private IFixture _fixture;
    private T _obj;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServiceObject"/>.
    /// </summary>
    public ServiceObject_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._obj = _fixture.Create<T>();
        this._testClass = _fixture.Create<ServiceObject<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ServiceObject<T>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ServiceObject<T>(this._obj);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullObj()
    {
        FluentActions.Invoking(() => new ServiceObject<T>(default(T))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Value property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetValue()
    {
        // Arrange
        var testValue = _fixture.Create<T>();

        // Act
        this._testClass.Value = testValue;

        // Assert
        this._testClass.Value.Should().BeSameAs(testValue);
    }
}

/// <summary>
/// Unit tests for the type <see cref="ServiceObject"/>.
/// </summary>
public class ServiceObjectTests
{
    private ServiceObject _testClass;
    private IFixture _fixture;
    private object _obj;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServiceObject"/>.
    /// </summary>
    public ServiceObjectTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._obj = _fixture.Create<object>();
        this._testClass = _fixture.Create<ServiceObject>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ServiceObject();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ServiceObject(this._obj);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the obj parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullObj()
    {
        FluentActions.Invoking(() => new ServiceObject(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("obj");
    }

    /// <summary>
    /// Checks that the Value property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetValue()
    {
        // Arrange
        var testValue = _fixture.Create<object>();

        // Act
        this._testClass.Value = testValue;

        // Assert
        this._testClass.Value.Should().BeSameAs(testValue);
    }
}