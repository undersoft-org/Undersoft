using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Hosting;

namespace Undersoft.SDK.Service.UnitTests.Hosting;

/// <summary>
/// Unit tests for the type <see cref="ServiceHostRemoteImplementations"/>.
/// </summary>
public class ServiceHostRemoteImplementationsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the AddOpenDataRemoteImplementations method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddOpenDataRemoteImplementations()
    {
        // Arrange
        var reg = _fixture.Create<IServiceRegistry>();

        // Act
        reg.AddOpenDataRemoteImplementations();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddOpenDataRemoteImplementations method throws when the reg parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddOpenDataRemoteImplementationsWithNullReg()
    {
        FluentActions.Invoking(() => default(IServiceRegistry).AddOpenDataRemoteImplementations()).Should().Throw<ArgumentNullException>().WithParameterName("reg");
    }
}