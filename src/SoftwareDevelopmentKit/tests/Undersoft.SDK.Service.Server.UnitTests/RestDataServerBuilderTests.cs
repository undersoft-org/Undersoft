using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server;
using TStore = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="RestDataServerBuilder"/>.
/// </summary>
[TestClass]
public class RestDataServerBuilder_1Tests
{
    private class TestRestDataServerBuilder : RestDataServerBuilder<TStore>
    {
        public TestRestDataServerBuilder(IServiceRegistry registry) : base(registry)
        {
        }

        public string PublicGetRoutes()
        {
            return base.GetRoutes();
        }
    }

    private TestRestDataServerBuilder _testClass;
    private IFixture _fixture;
    private Mock<IServiceRegistry> _registry;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RestDataServerBuilder"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._registry = _fixture.Freeze<Mock<IServiceRegistry>>();
        this._testClass = _fixture.Create<TestRestDataServerBuilder>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestRestDataServerBuilder(this._registry.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the registry parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRegistry()
    {
        FluentActions.Invoking(() => new TestRestDataServerBuilder(default(IServiceRegistry))).Should().Throw<ArgumentNullException>().WithParameterName("registry");
    }

    /// <summary>
    /// Checks that the AddControllers method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddControllers()
    {
        // Act
        this._testClass.AddControllers();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Build method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuild()
    {
        // Act
        this._testClass.Build();

        // Assert
        _registry.Verify(mock => mock.MergeServices(It.IsAny<bool>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicGetRoutes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetRoutes()
    {
        // Act
        var result = this._testClass.PublicGetRoutes();

        // Assert
        Assert.Fail("Create or modify test");
    }
}