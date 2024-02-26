using System;
using System.Collections;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="ArrayListExtensions"/>.
/// </summary>
public class ArrayListExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Resize method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallResize()
    {
        // Arrange
        var array = _fixture.Create<ArrayList>();
        var size = _fixture.Create<int>();

        // Act
        var result = array.Resize(size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Resize method throws when the array parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallResizeWithNullArray()
    {
        FluentActions.Invoking(() => default(ArrayList).Resize(_fixture.Create<int>())).Should().Throw<ArgumentNullException>().WithParameterName("array");
    }
}