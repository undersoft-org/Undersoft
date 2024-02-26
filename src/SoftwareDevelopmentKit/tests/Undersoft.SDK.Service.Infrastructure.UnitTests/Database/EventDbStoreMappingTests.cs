using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Infrastructure.Database;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests.Database;

/// <summary>
/// Unit tests for the type <see cref="EventDbStoreMapping"/>.
/// </summary>
[TestClass]
public class EventDbStoreMappingTests
{
    private EventDbStoreMapping _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventDbStoreMapping"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<EventDbStoreMapping>();
    }

    /// <summary>
    /// Checks that the Configure method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallConfigure()
    {
        // Arrange
        var builder = _fixture.Create<EntityTypeBuilder<Event>>();

        // Act
        this._testClass.Configure(builder);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Configure method throws when the builder parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallConfigureWithNullBuilder()
    {
        FluentActions.Invoking(() => this._testClass.Configure(default(EntityTypeBuilder<Event>))).Should().Throw<ArgumentNullException>().WithParameterName("builder");
    }
}