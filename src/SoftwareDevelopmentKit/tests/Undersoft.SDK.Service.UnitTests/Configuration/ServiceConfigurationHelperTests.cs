using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Configuration;
using Undersoft.SDK.Service.Configuration.Options;

namespace Undersoft.SDK.Service.UnitTests.Configuration;

/// <summary>
/// Unit tests for the type <see cref="ServiceConfigurationHelper"/>.
/// </summary>
public class ServiceConfigurationHelperTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the BuildConfiguration method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuildConfiguration()
    {
        // Arrange
        var args = _fixture.Create<string[]>();
        var options = _fixture.Create<ConfigurationOptions>();
        Action<IConfigurationBuilder> builderAction = x => { };

        // Act
        var result = ServiceConfigurationHelper.BuildConfiguration(args, options, builderAction);

        // Assert
        Assert.Fail("Create or modify test");
    }
}