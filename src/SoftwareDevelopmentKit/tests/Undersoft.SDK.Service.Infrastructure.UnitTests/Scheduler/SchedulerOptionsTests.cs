using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quartz;
using Undersoft.SDK.Service.Schedule;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="SchedulerOptions"/>.
/// </summary>
[TestClass]
public class SchedulerOptionsTests
{
    private SchedulerOptions _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SchedulerOptions"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<SchedulerOptions>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SchedulerOptions();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Properties property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProperties()
    {
        // Arrange
        var testValue = _fixture.Create<NameValueCollection>();

        // Act
        this._testClass.Properties = testValue;

        // Assert
        this._testClass.Properties.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Configurator property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetConfigurator()
    {
        // Arrange
        Action<IServiceCollectionQuartzConfigurator> testValue = x => { };

        // Act
        this._testClass.Configurator = testValue;

        // Assert
        this._testClass.Configurator.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the StartDelay property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetStartDelay()
    {
        // Arrange
        var testValue = _fixture.Create<TimeSpan>();

        // Act
        this._testClass.StartDelay = testValue;

        // Assert
        this._testClass.StartDelay.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the StartSchedulerFactory property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetStartSchedulerFactory()
    {
        // Arrange
        Func<IScheduler, Task> testValue = x => _fixture.Create<Task>();

        // Act
        this._testClass.StartSchedulerFactory = testValue;

        // Assert
        this._testClass.StartSchedulerFactory.Should().BeSameAs(testValue);
    }
}