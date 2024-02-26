using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event.Handler;
using THandler = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Event.Handler;

/// <summary>
/// Unit tests for the type <see cref="EventHandlerTransientFactory"/>.
/// </summary>
public class EventHandlerTransientFactory_1Tests
{
    private class TestEventHandlerTransientFactory : EventHandlerTransientFactory<THandler>
    {
        public TestEventHandlerTransientFactory() : base()
        {
        }

        public IEventHandler PublicCreateHandler()
        {
            return base.CreateHandler();
        }
    }

    private TestEventHandlerTransientFactory _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventHandlerTransientFactory"/>.
    /// </summary>
    public EventHandlerTransientFactory_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestEventHandlerTransientFactory>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestEventHandlerTransientFactory();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the PublicCreateHandler method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateHandler()
    {
        // Act
        var result = this._testClass.PublicCreateHandler();

        // Assert
        Assert.Fail("Create or modify test");
    }
}

/// <summary>
/// Unit tests for the type <see cref="EventHandlerTransientFactory"/>.
/// </summary>
public class EventHandlerTransientFactoryTests
{
    private class TestEventHandlerTransientFactory : EventHandlerTransientFactory
    {
        public TestEventHandlerTransientFactory(Type handlerType) : base(handlerType)
        {
        }

        public IEventHandler PublicCreateHandler()
        {
            return base.CreateHandler();
        }
    }

    private TestEventHandlerTransientFactory _testClass;
    private IFixture _fixture;
    private Type _handlerType;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventHandlerTransientFactory"/>.
    /// </summary>
    public EventHandlerTransientFactoryTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._handlerType = _fixture.Create<Type>();
        this._testClass = _fixture.Create<TestEventHandlerTransientFactory>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestEventHandlerTransientFactory(this._handlerType);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the handlerType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullHandlerType()
    {
        FluentActions.Invoking(() => new TestEventHandlerTransientFactory(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("handlerType");
    }

    /// <summary>
    /// Checks that the GetHandler method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetHandler()
    {
        // Act
        var result = this._testClass.GetHandler();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsInFactories method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsInFactories()
    {
        // Arrange
        var handlerFactories = _fixture.Create<List<IEventHandlerFactory>>();

        // Act
        var result = this._testClass.IsInFactories(handlerFactories);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsInFactories method throws when the handlerFactories parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsInFactoriesWithNullHandlerFactories()
    {
        FluentActions.Invoking(() => this._testClass.IsInFactories(default(List<IEventHandlerFactory>))).Should().Throw<ArgumentNullException>().WithParameterName("handlerFactories");
    }

    /// <summary>
    /// Checks that the PublicCreateHandler method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateHandler()
    {
        // Act
        var result = this._testClass.PublicCreateHandler();

        // Assert
        Assert.Fail("Create or modify test");
    }
}