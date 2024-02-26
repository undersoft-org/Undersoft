using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server;
using TAuth = System.String;
using TDto = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="OpenDataServerBuilder"/>.
/// </summary>
[TestClass]
public class OpenDataServerBuilder_1Tests
{
    private class TestOpenDataServerBuilder : OpenDataServerBuilder<TStore>
    {
        public TestOpenDataServerBuilder(IServiceRegistry registry) : base(registry)
        {
        }

        public TestOpenDataServerBuilder(IServiceRegistry registry, string routePrefix, int pageLimit) : base(registry, routePrefix, pageLimit)
        {
        }

        public string PublicGetRoutes()
        {
            return base.GetRoutes();
        }
    }

    private TestOpenDataServerBuilder _testClass;
    private IFixture _fixture;
    private Mock<IServiceRegistry> _registry;
    private string _routePrefix;
    private int _pageLimit;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="OpenDataServerBuilder"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._registry = _fixture.Freeze<Mock<IServiceRegistry>>();
        this._routePrefix = _fixture.Create<string>();
        this._pageLimit = _fixture.Create<int>();
        this._testClass = _fixture.Create<TestOpenDataServerBuilder>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestOpenDataServerBuilder(this._registry.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestOpenDataServerBuilder(this._registry.Object, this._routePrefix, this._pageLimit);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the registry parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRegistry()
    {
        FluentActions.Invoking(() => new TestOpenDataServerBuilder(default(IServiceRegistry))).Should().Throw<ArgumentNullException>().WithParameterName("registry");
        FluentActions.Invoking(() => new TestOpenDataServerBuilder(default(IServiceRegistry), this._routePrefix, this._pageLimit)).Should().Throw<ArgumentNullException>().WithParameterName("registry");
    }

    /// <summary>
    /// Checks that the constructor throws when the routePrefix parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidRoutePrefix(string value)
    {
        FluentActions.Invoking(() => new TestOpenDataServerBuilder(this._registry.Object, value, this._pageLimit)).Should().Throw<ArgumentNullException>().WithParameterName("routePrefix");
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
    /// Checks that the EntitySet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEntitySetWithEntityType()
    {
        // Arrange
        var entityType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.EntitySet(entityType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EntitySet method throws when the entityType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEntitySetWithEntityTypeWithNullEntityType()
    {
        FluentActions.Invoking(() => this._testClass.EntitySet(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("entityType");
    }

    /// <summary>
    /// Checks that the EntitySet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEntitySetWithTDto()
    {
        // Act
        var result = this._testClass.EntitySet<TDto>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEdm method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEdm()
    {
        // Act
        var result = this._testClass.GetEdm();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BuildEdm method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuildEdm()
    {
        // Act
        this._testClass.BuildEdm();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddODataServicer method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddODataServicer()
    {
        // Arrange
        var mvc = _fixture.Create<IMvcBuilder>();

        // Act
        var result = this._testClass.AddODataServicer(mvc);

        // Assert
        _registry.Verify(mock => mock.MergeServices(It.IsAny<bool>()));

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddODataServicer method throws when the mvc parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddODataServicerWithNullMvc()
    {
        FluentActions.Invoking(() => this._testClass.AddODataServicer(default(IMvcBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("mvc");
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
    /// Checks that the AddInvocations method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddInvocations()
    {
        // Act
        var result = this._testClass.AddInvocations<TAuth>();

        // Assert
        Assert.Fail("Create or modify test");
    }
}