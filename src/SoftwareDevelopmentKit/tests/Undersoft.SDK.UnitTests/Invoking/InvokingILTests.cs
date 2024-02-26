using System;
using System.Reflection;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Invoking;

namespace Undersoft.SDK.UnitTests.Invoking;

/// <summary>
/// Unit tests for the type <see cref="InvokingIL"/>.
/// </summary>
public class InvokingILTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreate()
    {
        // Arrange
        var methodInfo = _fixture.Create<MethodInfo>();

        // Act
        var result = InvokingIL.Create(methodInfo);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Create method throws when the methodInfo parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateWithNullMethodInfo()
    {
        FluentActions.Invoking(() => InvokingIL.Create(default(MethodInfo))).Should().Throw<ArgumentNullException>().WithParameterName("methodInfo");
    }
}