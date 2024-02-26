using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SDK.Service.UnitTests.Data.Object;

/// <summary>
/// Unit tests for the type <see cref="DataObject"/>.
/// </summary>
public class DataObjectTests
{
    private class TestDataObject : DataObject
    {
        public TestDataObject() : base()
        {
        }

        public IProxy PublicCreateProxy()
        {
            return base.CreateProxy();
        }
    }

    private TestDataObject _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DataObject"/>.
    /// </summary>
    public DataObjectTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestDataObject>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestDataObject();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the PublicCreateProxy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateProxy()
    {
        // Act
        var result = this._testClass.PublicCreateProxy();

        // Assert
        Assert.Fail("Create or modify test");
    }
}