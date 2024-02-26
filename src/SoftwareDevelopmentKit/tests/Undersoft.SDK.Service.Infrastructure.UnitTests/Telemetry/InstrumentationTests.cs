using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="Instrumentation"/>.
/// </summary>
[TestClass]
public class InstrumentationTests
{
    private Instrumentation _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Instrumentation"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<Instrumentation>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Instrumentation();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Dispose method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDispose()
    {
        // Act
        this._testClass.Dispose();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ActivitySource property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetActivitySource()
    {
        // Assert
        this._testClass.ActivitySource.Should().BeAssignableTo<ActivitySource>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RequestCounter property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRequestCounter()
    {
        // Assert
        this._testClass.RequestCounter.Should().BeAssignableTo<Counter<long>>();

        Assert.Fail("Create or modify test");
    }
}