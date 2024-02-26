using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.UnitTests.Uniques;

/// <summary>
/// Unit tests for the type <see cref="Unique"/>.
/// </summary>
public class UniqueTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Bit32 property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetBit32()
    {
        // Assert
        Unique.Bit32.Should().BeAssignableTo<UniqueKey32>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Bit64 property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetBit64()
    {
        // Assert
        Unique.Bit64.Should().BeAssignableTo<UniqueKey64>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewId property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetNewId()
    {
        // Assert
        Unique.NewId.As<object>().Should().BeAssignableTo<long>();

        Assert.Fail("Create or modify test");
    }
}