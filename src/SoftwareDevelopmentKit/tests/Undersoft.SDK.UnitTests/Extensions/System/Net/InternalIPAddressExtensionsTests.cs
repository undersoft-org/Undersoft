using System;
using System.Net;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="InternalIPAddressExtensions"/>.
/// </summary>
public class InternalIPAddressExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the ToIPv4String method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallToIPv4String()
    {
        // Arrange
        var address = _fixture.Create<IPAddress>();

        // Act
        var result = address.ToIPv4String();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ToIPv4String method throws when the address parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallToIPv4StringWithNullAddress()
    {
        FluentActions.Invoking(() => default(IPAddress).ToIPv4String()).Should().Throw<ArgumentNullException>().WithParameterName("address");
    }
}