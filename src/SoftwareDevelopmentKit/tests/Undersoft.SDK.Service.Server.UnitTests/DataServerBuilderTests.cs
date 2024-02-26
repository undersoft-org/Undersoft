using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Server;
using TAuth = System.String;
using TContext = System.String;

namespace Undersoft.SDK.Service.Server.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="DataServerBuilder"/>.
/// </summary>
[TestClass]
public class DataServerBuilderTests
{
    private class TestDataServerBuilder : DataServerBuilder
    {
        public TestDataServerBuilder() : base()
        {
        }

        public string PublicGetRoutes()
        {
            return base.GetRoutes();
        }

        public Type PublicStoreType { get => base.StoreType; set => base.StoreType = value; }
        public ISeries<Type> PublicContextTypes { get => base.ContextTypes; set => base.ContextTypes = value; }

        public override void Build()
        {
        }
    }

    private TestDataServerBuilder _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DataServerBuilder"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestDataServerBuilder>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestDataServerBuilder();

        // Assert
        instance.Should().NotBeNull();
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
    /// Checks that the AddDataServices method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddDataServices()
    {
        // Act
        var result = this._testClass.AddDataServices<TContext>();

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

    /// <summary>
    /// Checks that setting the PublicStoreType property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPublicStoreType()
    {
        this._testClass.CheckProperty(x => x.PublicStoreType, _fixture.Create<Type>(), _fixture.Create<Type>());
    }

    /// <summary>
    /// Checks that setting the ServiceTypes property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetServiceTypes()
    {
        this._testClass.CheckProperty(x => x.ServiceTypes, _fixture.Create<DataServerTypes>(), _fixture.Create<DataServerTypes>());
    }

    /// <summary>
    /// Checks that setting the RoutePrefix property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRoutePrefix()
    {
        this._testClass.CheckProperty(x => x.RoutePrefix);
    }

    /// <summary>
    /// Checks that setting the PageLimit property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPageLimit()
    {
        this._testClass.CheckProperty(x => x.PageLimit);
    }

    /// <summary>
    /// Checks that setting the PublicContextTypes property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPublicContextTypes()
    {
        this._testClass.CheckProperty(x => x.PublicContextTypes, _fixture.Create<ISeries<Type>>(), _fixture.Create<ISeries<Type>>());
    }
}