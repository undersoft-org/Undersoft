using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Configuration;

namespace Undersoft.SDK.Service.UnitTests.Configuration;

/// <summary>
/// Unit tests for the type <see cref="ServiceConfigurationContext"/>.
/// </summary>
public class ServiceConfigurationContextTests
{
    private ServiceConfigurationContext _testClass;
    private IFixture _fixture;
    private Mock<IServiceRegistry> _services;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ServiceConfigurationContext"/>.
    /// </summary>
    public ServiceConfigurationContextTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._services = _fixture.Freeze<Mock<IServiceRegistry>>();
        this._testClass = _fixture.Create<ServiceConfigurationContext>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ServiceConfigurationContext(this._services.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the services parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServices()
    {
        FluentActions.Invoking(() => new ServiceConfigurationContext(default(IServiceRegistry))).Should().Throw<ArgumentNullException>().WithParameterName("services");
    }

    /// <summary>
    /// Checks that the Items property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetItems()
    {
        // Assert
        this._testClass.Items.Should().BeAssignableTo<ISeries<object>>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexer()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<string>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<string>()] = testValue;
        this._testClass[_fixture.Create<string>()].Should().BeSameAs(testValue);
    }
}