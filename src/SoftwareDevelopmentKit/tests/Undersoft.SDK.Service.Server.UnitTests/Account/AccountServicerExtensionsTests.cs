using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Server.Accounts;

namespace Undersoft.SDK.Service.Server.UnitTests.Accounts;

/// <summary>
/// Unit tests for the type <see cref="AccountServicerExtensions"/>.
/// </summary>
[TestClass]
public class AccountServicerExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the GetIdentityManager method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetIdentityManager()
    {
        // Arrange
        var servicer = _fixture.Create<IServicer>();

        // Act
        var result = servicer.GetIdentityManager();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetIdentityManager method throws when the servicer parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetIdentityManagerWithNullServicer()
    {
        FluentActions.Invoking(() => default(IServicer).GetIdentityManager()).Should().Throw<ArgumentNullException>().WithParameterName("servicer");
    }
}