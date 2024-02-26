using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server;
using TServiceStore = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="GrpcDataServerBuilder"/>.
/// </summary>
[TestClass]
public class GrpcDataServerBuilder_1Tests
{
    private class TestGrpcDataServerBuilder : GrpcDataServerBuilder<TServiceStore>
    {
        public TestGrpcDataServerBuilder(IServiceRegistry registry) : base(registry)
        {
        }

        public string PublicGetRoutes()
        {
            return base.GetRoutes();
        }
    }

    private TestGrpcDataServerBuilder _testClass;
    private IFixture _fixture;
    private Mock<IServiceRegistry> _registry;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="GrpcDataServerBuilder"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._registry = _fixture.Freeze<Mock<IServiceRegistry>>();
        this._testClass = _fixture.Create<TestGrpcDataServerBuilder>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestGrpcDataServerBuilder(this._registry.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the registry parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRegistry()
    {
        FluentActions.Invoking(() => new TestGrpcDataServerBuilder(default(IServiceRegistry))).Should().Throw<ArgumentNullException>().WithParameterName("registry");
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

    /// <summary>
    /// Checks that the AddGrpcServicer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddGrpcServicer()
    {
        // Act
        this._testClass.AddGrpcServicer();

        // Assert
        _registry.Verify(mock => mock.MergeServices(It.IsAny<bool>()));

        Assert.Fail("Create or modify test");
    }
}